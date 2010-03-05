using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Loader
{
    public partial class Form1 : Form
    {
        class Disposition
        {
            private int? robotAt = null;
            public int? RobotAt
            {
                get { return robotAt; }
            }

            private float currentCost = 0f;
            public float TotalCost
            {
                get { return currentCost; }
            }

            private int[] boxAt = null;

            private Disposition parent = null;
            public Disposition Parent
            {
                get { return parent; }
                set { parent = value; }
            }

            public delegate float CostEvaluator(int A, int B);

            private CostEvaluator fullCost;

            public Disposition(int? RobotAt, int BoxesCount, CostEvaluator FullCost)
            {
                boxAt = new int[BoxesCount];
                for (int i = 0; i < BoxesCount; boxAt[i] = i++) ;

                robotAt = RobotAt;

                fullCost = FullCost;
            }

            public Disposition(Disposition disposition)
            {
                boxAt = new int[disposition.boxAt.Length];
                for (int i = 0; i < boxAt.Length; i++)
                    boxAt[i] = disposition.boxAt[i];

                robotAt = disposition.robotAt;
                fullCost = disposition.fullCost;
                parent = disposition;
                currentCost = disposition.currentCost;
            }

            public float GoTo(int pos)
            {
                float cost = fullCost(robotAt ?? -1, pos) / 2f;

                currentCost += cost;
                robotAt = pos;
                return cost;
            }

            /// <summary>
            /// Оnly the first box at iFrom will be moved
            /// </summary>
            public float Drag(int iFrom, int iTo)
            {
                if (robotAt != iFrom)
                    throw new InvalidOperationException("Robot stands not at 'From' box");

                for (int i = 0; i < boxAt.Length; i++)
                    if (boxAt[i] == iFrom)
                    {
                        boxAt[i] = iTo;
                        robotAt = iTo;
                        currentCost += fullCost(iFrom, iTo);
                        return fullCost(iFrom, iTo);
                    }

                throw new ArgumentOutOfRangeException("No boxes at 'From' location");
            }

            public float DragTo(int iTo)
            {
                return Drag(robotAt ?? -1, iTo);
            }

            public bool IsCollected
            {
                get
                {
                    int n = boxAt.Length;

                    if (n < 2) return true;

                    for (int i = 1; i < n; i++)
                        if (boxAt[i - 1] != boxAt[i])
                            return false;

                    return true;
                }
            }

            public int FindUncollected(int CollectionPointIndex)
            {
                for (int i = 0; i < boxAt.Length; i++)
                {
                    if (boxAt[i] != CollectionPointIndex)
                        return i;
                }

                return -1;
            }
        }

        List<Point> boxes;
        List<Point> lines;
        List<float> weights;
        Point robot;
        public float Tarif = 1f;

        int d = 8;
        Font fontLen;

        public Form1()
        {
            InitializeComponent();

            boxes = new List<Point>();

            robot.X = pictureBox1.Width >> 1;
            robot.Y = pictureBox1.Height * 3 / 4;

            fontLen = new Font("Arial", 8f);
        }

        #region I/O
        private void DrawBox(Graphics g, Point at)
        {
            Pen penStroke = Pens.Black;
            Brush brFill = new SolidBrush(Color.Firebrick);
            int d2 = d << 1;
            int d4 = d2 << 1;
            int d_2 = d >> 1;

            Rectangle[] recs = new Rectangle[3];
            // Yellow
            recs[0] = new Rectangle(at.X - d2, at.Y - d2, d4, d4);
            // Green
            recs[1] = new Rectangle(at.X - d, at.Y - d2, d2, d4);
            // Blue
            recs[2] = new Rectangle(at.X - d, at.Y - d, d2, d2);

            g.FillRectangles(brFill, recs);
            g.DrawRectangles(penStroke, recs);

            g.DrawLine(penStroke, at.X - d, at.Y + d_2, at.X + d_2, at.Y - d);
            g.DrawLine(penStroke, at.X - d_2, at.Y + d, at.X + d, at.Y - d_2);
        }

        private void DrawBot(Graphics g, Point at)
        {
            Pen penStroke = Pens.Black;
            Brush brFill = new SolidBrush(Color.Silver);

            Rectangle rect = new Rectangle(at.X - d * 3, at.Y - d * 3, d * 6, d * 6);
            //g.FillRectangle(brFill, rect);
            //g.DrawRectangle(penStroke, rect);
            g.FillEllipse(brFill, rect);
            g.DrawEllipse(penStroke, rect);
        }

        private void DrawRoads(Graphics g)
        {
            Random rnd = new Random();

            if (lines != null)
                if (lines.Count > 1)
                {
                    Point prev = lines[0];
                    int iw = 0;

                    foreach(Point curr in lines)
                    {
                        if (prev == curr)
                        {
                            iw++;
                            continue;
                        }

                        string caption = weights[iw].ToString("F1");
                            //FullCost(prev, curr).ToString("F1");

                        float t = 0.25f;// +0.333f * ((iw / 2) % 2); // (float)rnd.NextDouble();

                        RectangleF rect = new RectangleF(
                            prev.X + t*(curr.X - prev.X),
                            prev.Y + t*(curr.Y - prev.Y),
                            1,
                            1);

                        SizeF measure = g.MeasureString(
                            caption,
                            fontLen
                            );

                        rect.Inflate(measure.Width/2f, measure.Height/2f);

                        Pen penArrow = new Pen(Color.Black);
                        penArrow.StartCap = LineCap.ArrowAnchor;
                        penArrow.Width = 5;

                        //g.DrawLine(penArrow, prev, curr);

                        Point mid = new Point(
                            (int)rect.Left,
                            (int)rect.Top
                            );

                        g.DrawCurve(Pens.Blue, new Point[] { prev, mid, curr});

                        g.FillRectangle(Brushes.YellowGreen, rect);
                        g.DrawRectangle(Pens.Black, rect.Left, rect.Top, rect.Width, rect.Height);

                        g.DrawString(
                            caption,
                            fontLen,
                            Brushes.Black,
                            rect.Left,
                            rect.Top
                            );

                        prev = curr;
                        iw++;
                    }
                }
        }

        private bool IsInside(Point ptCenter, Point ptClick, int width)
        {
            bool inside = true;

            if (
                (Math.Abs(ptClick.X - ptCenter.X) > width) ||
                (Math.Abs(ptClick.Y - ptCenter.Y) > width)
                ) inside = false;

            return inside;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(pictureBox1.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawGrid(e.Graphics, 100);

            DrawRoads(e.Graphics);

            foreach (Point p in boxes)
                DrawBox(e.Graphics, p);

            if (cursorOn == 2)
                DrawBot(e.Graphics, ptCursor);
            else
                DrawBot(e.Graphics, robot);

            if (cursorOn == 1)
                DrawBox(e.Graphics, ptCursor);
        }

        private void DrawGrid(Graphics g, int step)
        {
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            for (int x = 0; x < w; x+=step)
                g.DrawLine(Pens.LightGray, x, 0, x, h);

            for (int y = 0; y < h; y += step)
                g.DrawLine(Pens.LightGray, 0, y, w, y);
        }

        Point ptCursor;
        int cursorOn = 0;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            ptCursor.X = e.X;
            ptCursor.Y = e.Y;

            if (cursorOn != 0)
                pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point ptClick = new Point(e.X, e.Y);

            // search if box is already there
            for (int i = 0; i < boxes.Count; i++)
            {
                if (IsInside(boxes[i], ptClick, d * 2))
                {
                    // start move selected
                    boxes.RemoveAt(i);
                    cursorOn = 1;
                }
            }

            if (IsInside(robot, ptClick, d * 3))
            {
                cursorOn = 2;
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Point ptClick = new Point(e.X, e.Y);

            if (cursorOn == 2)
            {
                if (pictureBox1.ClientRectangle.Contains(ptClick))
                {
                    robot = ptClick;
                }
            }
            else
            {
                if (!IsInside(robot, ptClick, d * 3))
                {
                    if (pictureBox1.ClientRectangle.Contains(ptClick))
                        boxes.Add(ptClick);
                }
            }

            cursorOn = 0;
            pictureBox1.Refresh();
        }
        
        #endregion

        private void buttonClear_Click(object sender, EventArgs e)
        {
            boxes.Clear();
            lines.Clear();

            pictureBox1.Refresh();
        }

        private void buttonPerebor_Click(object sender, EventArgs e)
        {
            textBox1.Text += "Traverse:";

            List<Disposition> open, closed;

            open = new List<Disposition>();
            closed = new List<Disposition>();

            Disposition initState =
                new Disposition(null, boxes.Count, FullCost);

            float minCost = float.MaxValue;
            //int minCostFrom = -1, minCostTo = -1;
            Disposition minCostDispos = null;

            // where to collect
            for (int i_where = 0; i_where < boxes.Count; i_where++)
            {
                open.Clear();

                // from which to start
                for (int i_from = 0; i_from < boxes.Count; i_from++)
                {
                    //if (i_from == i_where) continue;

                    Disposition t = new Disposition(initState);
                    t.GoTo(i_from);
                    open.Add(t);
                }

                while (open.Count > 1)
                {
                    int q = 0;
                    Disposition t = open[q];

                    while (true)
                    {
                        int u = t.FindUncollected(i_where);
                        if (u == -1) break;

                        t = new Disposition(t);
                        t.GoTo(u);
                        closed.Add(t);

                        t = new Disposition(t);
                        t.DragTo(i_where);
                        closed.Add(t);
                    }

                    if (minCost > t.TotalCost)
                    {
                        minCost = t.TotalCost;
                        minCostDispos = t;
                    }

                    closed.Add(open[q]);
                    open.RemoveAt(q);
                }

                if (minCostDispos == null)
                    textBox1.Text += Environment.NewLine + "No solution";
                else
                    textBox1.Text += Environment.NewLine +
                        minCostDispos.TotalCost.ToString("F2");

            }

            if (minCostDispos == null)
            {
                textBox1.Text += Environment.NewLine +
                    "No solution" +
                    Environment.NewLine;

                return;
            }

            textBox1.Text += Environment.NewLine +
                minCostDispos.TotalCost.ToString("F2") +
                Environment.NewLine;

            CreateRoads(minCostDispos);

            pictureBox1.Refresh();
        }

        private void buttonHeuristics_Click(object sender, EventArgs e)
        {
            textBox1.Text += "Heuristics:";
            if (boxes.Count < 1)
            {
                textBox1.Text += Environment.NewLine +
                    "No boxes - no job" +
                    Environment.NewLine;

                return;
            }

            List<Disposition> open, closed;

            open = new List<Disposition>();
            closed = new List<Disposition>();

            Disposition initState =
                new Disposition(null, boxes.Count, FullCost);

            float minCost = float.MaxValue;
            Disposition minCostDispos = null;

            // where to collect

            int sumX = 0, sumY = 0;

            for (int i = 0; i < boxes.Count; i++) 
            { 
                sumX += boxes[i].X;
                sumY += boxes[i].Y;
            }
            
            Point mid = new Point(sumX / boxes.Count, sumY / boxes.Count);

            float minFC = float.MaxValue;
            int i_where = -1;
            for (int i = 0; i < boxes.Count; i++)
            {
                float fc = FullCost(mid, boxes[i]);
                if (fc < minFC)
                {
                    minFC = fc;
                    i_where = i;
                }
            }

            {
                open.Clear();

                // from which to start
                float nearLength = float.MaxValue;
                int i_from = -1;
                for (int i = 0; i < boxes.Count; i++)
                {
                    float fc = FullCost(robot, boxes[i]);
                    if (fc < nearLength)
                    {
                        nearLength = fc;
                        i_from = i;
                    }
                }

                //for (int i_from = 0; i_from < boxes.Count; i_from++)
                {
                    Disposition t = new Disposition(initState);
                    t.GoTo(i_from);
                    closed.Add(t);
                    t = new Disposition(t);
                    t.DragTo(i_where);
                    open.Add(t);
                }

                while (open.Count > 0)
                {
                    int q = 0;
                    Disposition t = open[q];

                    while (true)
                    {
                        int u = t.FindUncollected(i_where);
                        if (u == -1) break;

                        t = new Disposition(t);
                        t.GoTo(u);
                        closed.Add(t);

                        t = new Disposition(t);
                        t.DragTo(i_where);
                        closed.Add(t);
                    }

                    if (minCost > t.TotalCost)
                    {
                        minCost = t.TotalCost;
                        minCostDispos = t;
                    }

                    closed.Add(open[q]);
                    open.RemoveAt(q);
                }

                textBox1.Text +=  Environment.NewLine +
                    minCostDispos.TotalCost.ToString("F2");

            }

            if (minCostDispos == null)
            {
                textBox1.Text += Environment.NewLine +
                    "No solution" +
                    Environment.NewLine;

                return;
            }

            textBox1.Text += Environment.NewLine + 
                minCostDispos.TotalCost.ToString("F2") + 
                Environment.NewLine;

            CreateRoads(minCostDispos);

            pictureBox1.Refresh();
        }

        private void CreateRoads(Disposition minCostDispos)
        {
            lines = new List<Point>();
            weights = new List<float>();
            Disposition curr = minCostDispos;
            Disposition prev = curr;
            while (curr.Parent != null)
            {
                lines.Add(boxes[curr.RobotAt ?? 0]);
                weights.Add(prev.TotalCost - curr.TotalCost);
                prev = curr;
                curr = curr.Parent;
            }

            lines.Add(robot);
            weights.Add(
                0.5f * FullCost(boxes[prev.RobotAt ?? -1], robot)
                );
        }

        public float FullCost(int A, int B)
        {
            int dx, dy;

            if (A == -1)
            {
                dx = boxes[B].X - robot.X;
                dy = boxes[B].Y - robot.Y;
            }
            else
            {
                dx = boxes[B].X - boxes[A].X;
                dy = boxes[B].Y - boxes[A].Y;
            }

            return (float)Math.Sqrt(dx * dx + dy * dy) * Tarif;
        }
        public float FullCost(Point A, Point B)
        {
            int dx, dy;

            dx = B.X - A.X;
            dy = B.Y - A.Y;
        
            return (float)Math.Sqrt(dx * dx + dy * dy) * Tarif;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }
    }
}
