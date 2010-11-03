using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace KG5_Triang
{
    public partial class Form1 : Form, IComparer<PointF>
    {
        //int[] convex;
        PointF[] pts;
        List<PointF> userpts;
        Random rnd;
        Font font;
        Pen penConvex;
        Pen penTriangle, penTriangleNF, penCirc;
        //int gridStep = 50;
        IList<Triangle> triangles, trianglesNoFlip;

        float[] CircR = null;
        PointF[] CircXY = null;


        /// <summary>
        /// Used for sorting in Compare() only!
        /// </summary>
        float x0, y0;

        public Form1()
        {
            InitializeComponent();

            rnd = new Random();

            font = new Font("Arial", 6f);
            penConvex = new Pen(Color.DarkGray, 2f);
            penTriangle = new Pen(Color.LightGreen, 1.5f);
            penTriangleNF = new Pen(Color.LightBlue, 1f);
            penCirc = new Pen(Color.DimGray, 1f);

            userpts = new List<PointF>();

            //Generate();
        }

        #region IComparer<PointF> Members

        public int Compare(PointF a, PointF b)
        {
            float dx_ab, dy_ab;
            dx_ab = a.X - b.X;
            dy_ab = a.Y - b.Y;
            return Math.Sign(
                dx_ab * (a.X + b.X) - 2 * x0 * dx_ab +
                dy_ab * (a.Y + b.Y) - 2 * y0 * dy_ab
                );
        }

        #endregion

        IList<Triangle> SHull(PointF[] points)
        {
            if (points.Length < 3) return null;

            List<Triangle> trs = new List<Triangle>();

            // select a seed point x_0 from points[], 
            // sort according to |x_i - x_0|^2.
            x0 = points[0].X;
            y0 = points[0].Y;

            Array.Sort<PointF>(points, this);

            List<int> convhull = new List<int>();

            if (Triangle.MakesCCW(points[0], points[1], points[2]))
            {
                // keep [0 1 2]
                convhull.Add(0);
                convhull.Add(1);
                convhull.Add(2);

                trs.Add(new Triangle(points[0], points[1], points[2]));
            }
            else
            {
                // make [0 2 1]

                convhull.Add(0);
                convhull.Add(2);
                convhull.Add(1);
                trs.Add(new Triangle(points[0], points[2], points[1]));
            }

            x0 = trs[0].center.X;// (points[0].X + points[1].X + points[2].X) / 3f;
            y0 = trs[0].center.Y;// (points[0].Y + points[1].Y + points[2].Y) / 3f;

            Array.Sort<PointF>(points,3,points.Length-3, this);

            for (int i = 3; i < points.Length; i++)
            {
                // traverse hull and check visibility condition
                bool prevVisible = false;

                int startEdge = 0;
                int endingEdge = 0;
                bool visible = false;

                for (int edge = 0; edge < convhull.Count; edge++)
                {
                    int edgeNext = edge + 1;
                    edgeNext = edgeNext % convhull.Count;

                    visible = TestVisible(points[i], points[convhull[edge]], points[convhull[edgeNext]]);

                    if (visible && edge == 0)
                        prevVisible = true;

                    if (visible && !prevVisible)
                        startEdge = edge;

                    if (!visible && prevVisible)
                        endingEdge = edge;

                    prevVisible = visible;
                }

                // check last + first
                {
                    int edge = convhull.Count - 1;
                    int edgeNext = 0;

                    visible = TestVisible(points[i], points[convhull[edge]], points[convhull[edgeNext]]);

                    if (visible && !prevVisible)
                        startEdge = edge;

                    if (!visible && prevVisible)
                        endingEdge = edge;
                }

                List<int> edgesToRemove = new List<int>();
                for (int edge = startEdge; edge != endingEdge; edge++)
                {
                    int edgeNext;

                    edge = edge % convhull.Count;
                    edgeNext = (edge + 1) % convhull.Count;

                    Triangle t;
                    t = new Triangle(points[convhull[edge]], points[i], points[convhull[edgeNext]]);
                    t.MakeCCW();
                    trs.Add(t);

                    if (edge != startEdge && edge != endingEdge)
                    {
                        edgesToRemove.Add(convhull[edge]);
                        //convhull.Remove(edge);
                        //endingEdge--;
                        //if (endingEdge < 0) endingEdge += convhull.Count;
                    }

                    if (edgeNext == endingEdge) break;
                }

                convhull.Insert(
                    (startEdge + 1) % convhull.Count,
                    i
                    );

                foreach (int item in edgesToRemove)
                    convhull.Remove(item);


            }

            trianglesNoFlip = new List<Triangle>();

            foreach (Triangle t in trs)
                trianglesNoFlip.Add(new Triangle(t.v[0], t.v[1], t.v[2]));

            bool someWasFlipped = true; int flipcycles = 0;
            while (someWasFlipped)
            {
                someWasFlipped = false;
                for (int i = 0; i < trs.Count - 1; i++)
                {
                    for (int j = i + 1; j < trs.Count; j++)
                    {
                        Triangle A = trs[i];
                        Triangle B = trs[j];

                        //if (needed) 
                        {
                            someWasFlipped |= Flip(ref A, ref B);
                            trs[i] = A;
                            trs[j] = B;
                        }
                    }
                }
                flipcycles++;
            }

            Debug.Print("FlipCycles: {0}", flipcycles);
            return trs;
        }

        private bool TestVisible(PointF lookFrom, PointF A, PointF B)
        {
            PointF OA = PointF.Empty;
            PointF OB = PointF.Empty;
            OA.X = A.X - lookFrom.X;
            OA.Y = A.Y - lookFrom.Y;
            OB.X = B.X - lookFrom.X;
            OB.Y = B.Y - lookFrom.Y;

            return OA.X * OB.Y - OA.Y * OB.X < 0;
        }

        public static bool Flip(ref Triangle A, ref Triangle B)
        {
            int[] i = new int[2];
            int[] j = new int[2];
            int k = 3, l = 3;
            int eq = 0;

            for (int p = 0; p < 3; p++)
                for (int q = 0; q < 3; q++)
                    if (A.v[p] == B.v[q])
                    {
                        if (eq > 2 - 1) return false;

                        i[eq] = p;
                        j[eq] = q;

                        k -= p;
                        l -= q;

                        eq++;
                    }

            // if (eq == 0) arn't adjacent;
            if (eq != 2) return false;
            // if (eq == 3) are the same one triangle;

            PointF a, b, c, d;
            a = A.v[i[0]];
            b = A.v[k];
            c = A.v[i[1]];
            d = B.v[l];

            double angleAlphaBeta = angle(a, b, c) + angle(a, d, c);
            double angleGammaDelta = angle(b, a, d) + angle(b, c, d);

            if (angleAlphaBeta > angleGammaDelta)
            {
                //PointF tmp = A.v[i[1]];
                A.v[i[1]] = B.v[l];
                B.v[j[0]] = A.v[k];
            }
            else return false;

            return true;
        }

        public static double angle(PointF a, PointF b, PointF c)
        {
            PointF ba = PointF.Empty, bc = PointF.Empty;
            
            ba.X = a.X - b.X;
            ba.Y = a.Y - b.Y;

            bc.X = c.X - b.X;
            bc.Y = c.Y - b.Y;

            double dot = ba.X * bc.X + ba.Y * bc.Y;
            double m_ba = ba.X * ba.X + ba.Y * ba.Y;
            double m_bc = bc.X * bc.X + bc.Y * bc.Y;

            return Math.Acos(dot / (m_ba * m_bc));
        }

        private void Generate()
        {
            userpts.Clear();

            int N = (int)numericUpDown1.Value;
            pts = new PointF[N];
            for (int i = 0; i < N; i++)
            {
                pts[i].X = rnd.Next(pictureBox1.Width);
                pts[i].Y = rnd.Next(pictureBox1.Height);
                userpts.Add(pts[i]);
            }
        }

        private void EvalCircles()
        {
            IList<Triangle> trs = null;
            if (trs == null)
            {
                if (checkBoxFlip.Checked)
                    trs = triangles;
                else
                    trs = trianglesNoFlip;
            }

            if (!checkBoxCirc.Checked || trs == null)
            {
                CircR = null;
                CircXY = null;
                return;
            }
            
            
            CircR = new float[trs.Count];
            CircXY = new PointF[trs.Count];

            int i = 0;
            foreach (Triangle item in trs)
            {
                float xa, xb, xc, ya, yb, yc;
                xa = item.v[0].X;
                xb = item.v[1].X;
                xc = item.v[2].X;
                ya = item.v[0].Y;
                yb = item.v[1].Y;
                yc = item.v[2].Y;

                double a, b, c;
                a = Math.Sqrt((xb - xc) * (xb - xc) + (yb - yc) * (yb - yc));
                b = Math.Sqrt((xa - xc) * (xa - xc) + (ya - yc) * (ya - yc));
                c = Math.Sqrt((xb - xa) * (xb - xa) + (yb - ya) * (yb - ya));

                double s = Math.Abs(((xb - xa) * (yc - ya) - (xc - xa) * (yb - ya)) / 2.0);

                double a11;//, a12, a13;
                double a21;//, a22, a23;
                double a31;//, a32, a33;
                a11 = xa * xa + ya * ya;
                a21 = xb * xb + yb * yb;
                a31 = xc * xc + yc * yc;

                CircR[i] = (float)(a * b * c / (4 * s));
                CircXY[i].X = (float)((a21 * yc - a31 * yb - a11 * yc + a31 * ya + a11 * yb - a21 * ya) / (4 * s)) - CircR[i];
                CircXY[i].Y = (float)(-(a21 * xc - a31 * xb - a11 * xc + a31 * xa + a11 * xb - a21 * xa) / (4 * s)) - CircR[i];

                i++;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (trianglesNoFlip != null && !checkBoxFlip.Checked)
            {
                if (CircR != null && CircXY != null)
                {
                    if (CircR.Length == CircXY.Length)
                    {
                        for (int i = 0; i < CircR.Length; i++)
                        {
                            g.DrawEllipse(penCirc, CircXY[i].X, CircXY[i].Y, 2f * CircR[i], 2f * CircR[i]);
                        }
                    }
                }

                //int n = 0;
                foreach (Triangle t in trianglesNoFlip)
                {
                    g.DrawLine(penTriangleNF, t.v[0], t.v[1]);
                    g.DrawLine(penTriangleNF, t.v[1], t.v[2]);
                    g.DrawLine(penTriangleNF, t.v[2], t.v[0]);
                    //g.DrawString((n++).ToString(), font, Brushes.Blue, t.center);

                }
            }

            if (triangles != null && checkBoxFlip.Checked)
            {
                if (CircR != null && CircXY != null)
                {
                    if (CircR.Length == CircXY.Length)
                    {
                        for (int i = 0; i < CircR.Length; i++)
                        {
                            g.DrawEllipse(penCirc, CircXY[i].X, CircXY[i].Y, 2f * CircR[i], 2f * CircR[i]);
                        }
                    }
                }
                //int n = 0;
                foreach (Triangle t in triangles)
                {
                    g.DrawLine(penTriangle, t.v[0], t.v[1]);
                    g.DrawLine(penTriangle, t.v[1], t.v[2]);
                    g.DrawLine(penTriangle, t.v[2], t.v[0]);
                    //g.DrawString((n++).ToString(), font, Brushes.LightGreen, t.center);
                }
            }

            float r = 2;
            if (pts != null)
            {
                int i = 0;
                foreach (PointF p in pts)
                {
                    g.FillRectangle(Brushes.White, p.X - r, p.Y - r, 2 * r, 2 * r);
                    g.DrawString(i.ToString(), font, Brushes.White, p);
                    i++;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            userpts.Add(new PointF(e.X, e.Y));
            pts = userpts.ToArray();
            buttonTriangulate_Click(sender, e);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            
        }

        private void checkBoxFlip_CheckedChanged(object sender, EventArgs e)
        {
            EvalCircles();
            pictureBox1.Refresh();
        }

        private void checkBoxCirc_CheckedChanged(object sender, EventArgs e)
        {
            EvalCircles();
            pictureBox1.Refresh();
        }

        private void buttonTriangulate_Click(object sender, EventArgs e)
        {
            triangles = SHull(pts);
            EvalCircles();

            pictureBox1.Refresh();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Generate();
            pictureBox1.Refresh();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pts = null;
            userpts.Clear();
            triangles = null;
            trianglesNoFlip = null;
            pictureBox1.Refresh();
        }
    }
}
