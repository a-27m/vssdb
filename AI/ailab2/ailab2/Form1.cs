using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using pre3d;

namespace ailab2
{
    public partial class Form1 : Form
    {
        private struct ViewParams
        {
            public float phiV, phiH;
            public float zoom;
            public float ox, oy;
        }

        #region declarations
        delegate double MeasureDelegate(Point3D point1, Point3D point2);
        delegate void SearchDelegate();

        List<Graphic3D> syncList;
        Point3D[] gorkaPath;
        PointF[] gorka2d;
        List<Point3dNode>[] chkpntList;
        List<Point3dNode> path;
        Point3dNode startPos, finishPos;

        List<Point3dNode> bestPath;
        double bestPathLen;
        bool showBestPath, showPath;

        List<Point3dNode> lOpen, lClosed;

        Graphic3D g3d;//, g3dCheckPoints;
        double a, b, c, h, v0;
        int n;
        ViewParams vpr;
        bool SetStartState = false, SetFinishState = false;

        Pen penPath, penBestPath, penGorka;

        MeasureDelegate measuringMethod;
        SearchDelegate searchMethod;
        #endregion

        public double gorka(double x, double y)
        {
            double z;

            if (y >= 0)
                z = (1 - x / a - y / c) * h;
            else
                z = (1 - x / a - y / b) * h;

            return Math.Sign(h) == Math.Sign(z) ? z : 0;
        }

        public Form1()
        {
            InitializeComponent();

            h = 6;
            a = 9;
            b = -8;
            c = 5;
            n = 5;
            v0 = 2f;

            textBoxA.Text = a.ToString("F1");
            textBoxB.Text = b.ToString("F1");
            textBoxC.Text = c.ToString("F1");
            textBoxH.Text = h.ToString("F1");
            textBoxV0.Text = v0.ToString("F1");
            textBoxN.Text = n.ToString();

            g3d = new Graphic3D(gorka, 0f, 20f, -20f, 20f, 5e-1f);

            vpr.phiH = 150f;
            vpr.phiV = 105f;
            vpr.zoom = 20;
            vpr.ox = pictureBox1.Width / 2f;
            vpr.oy = pictureBox1.Height / 2f;

            syncList = new List<Graphic3D>();
            syncList.Add(g3d);

            SetupCheckpionts();
            MakeGorkaShape();

            lOpen = new List<Point3dNode>();
            lClosed = new List<Point3dNode>();
            path = new List<Point3dNode>();

            penPath = new Pen(Color.OrangeRed, 1f / vpr.zoom);
            penBestPath = new Pen(Color.LimeGreen, 3f / vpr.zoom);
            penBestPath.LineJoin = LineJoin.Round;
            penGorka = new Pen(Color.Black, 1.5f / vpr.zoom);
            penGorka.LineJoin = LineJoin.Round;

            pictureBox1.Refresh();

            measuringMethod = this.MeasureDist;
            searchMethod = this.BreadthFirstSearch;
        }

        private void SetupCheckpionts()
        {
            chkpntList = new List<Point3dNode>[4];
            chkpntList[0] = new List<Point3dNode>();
            chkpntList[1] = new List<Point3dNode>();
            chkpntList[2] = new List<Point3dNode>();
            chkpntList[3] = new List<Point3dNode>();

            //chkpntList.Clear();
            Point3dNode p;

            float dx = (float)a / n;
            for (int i = 0; i <= n; i++)
            {
                p = new Point3dNode(i * dx, (float)(-b / a * (i * dx) + b), 0f);
                p.Region = 1;
                chkpntList[0].Add(p);

                p = new Point3dNode(i * dx, 0f, (float)(-h / a * (i * dx) + h));
                p.Region = 2;
                chkpntList[1].Add(p);

                p = new Point3dNode(i * dx, (float)(-c / a * (i * dx) + c), 0f);
                p.Region = 3;
                chkpntList[2].Add(p);

            }

            //chkpntList.Add(new Point3dNode(0f, (float)c, 0f));
            //chkpntList.Add(new Point3dNode(0f, (float)b, 0f));
            //chkpntList.Add(new Point3dNode(0f, 0f, (float)h));
            //chkpntList.Add(new Point3dNode((float)a, 0f, 0f));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (g3d != null)
            {
                SyncViewToGraphics();
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                g3d.Draw(e.Graphics);

                PointF p2d = new PointF();

                #region gorka shape
                if (gorkaPath != null)
                {

                    gorka2d = new PointF[gorkaPath.Length];

                    for (int i = 0; i < gorkaPath.Length; i++)
                        g3d.Project(ref gorka2d[i], gorkaPath[i]);

                    e.Graphics.DrawLines(penGorka, gorka2d);
                }
                #endregion

                float r = 2;
                foreach (List<Point3dNode> line in chkpntList)
                    foreach (Point3D p3d in line)
                    {
                        g3d.Project(ref p2d, p3d);
                        e.Graphics.FillEllipse(Brushes.Blue,

                            p2d.X - r / vpr.zoom, p2d.Y - r / vpr.zoom,
                            2 * r / vpr.zoom, 2 * r / vpr.zoom);
                    }

                r = 3;
                if (startPos != null)
                {
                    g3d.Project(ref p2d, startPos);
                    e.Graphics.FillEllipse(Brushes.Green,
                        p2d.X - r / vpr.zoom, p2d.Y - r / vpr.zoom,
                        2 * r / vpr.zoom, 2 * r / vpr.zoom);
                }

                r = 3;
                if (finishPos != null)
                {
                    g3d.Project(ref p2d, finishPos);
                    e.Graphics.FillEllipse(Brushes.Red,
                        p2d.X - r / vpr.zoom, p2d.Y - r / vpr.zoom,
                        2 * r / vpr.zoom, 2 * r / vpr.zoom);
                }

                if (showPath)
                {
                    DrawMyPath(e.Graphics, path, penPath);
                }
                if (showBestPath)
                {
                    DrawMyPath(e.Graphics, bestPath, penBestPath);
                }
            }
        }

        private void DrawMyPath(Graphics g, List<Point3dNode> path, Pen pen)
        {
            if (path != null)
            {
                if (path.Count > 0)
                {
                    PointF p2d = new PointF();
                    PointF[] pts = new PointF[path.Count];

                    int i = 0;
                    foreach (Point3dNode p in path)
                    {
                        g3d.Project(ref /*out*/ p2d, p);
                        pts[i++] = p2d;
                    }

                    g.DrawLines(pen, pts);
                }
            }
        }

        private void SyncViewToGraphics()
        {
            foreach (Graphic3D g in syncList)
            {
                g.phiH = vpr.phiH;
                g.phiV = vpr.phiV;
                g.zoom = vpr.zoom;
                g.ox = vpr.ox;
                g.oy = vpr.oy;
            }
        }

        #region navigation
        float zoomFactor = 1.25f;
        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            if (g3d == null) return;

            vpr.zoom *= zoomFactor;

            penPath = new Pen(penPath.Color, penPath.Width / zoomFactor);
            penBestPath = new Pen(penBestPath.Color, penBestPath.Width / zoomFactor);
            penBestPath.LineJoin = LineJoin.Round;
            penGorka = new Pen(penGorka.Color, penGorka.Width / zoomFactor);
            penGorka.LineJoin = LineJoin.Round;

            pictureBox1.Refresh();
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            if (g3d == null) return;

            vpr.zoom /= zoomFactor;

            penPath = new Pen(penPath.Color, penPath.Width * zoomFactor);
            penBestPath = new Pen(penBestPath.Color, penBestPath.Width * zoomFactor);
            penBestPath.LineJoin = LineJoin.Round;
            penGorka = new Pen(penGorka.Color, penGorka.Width * zoomFactor);
            penGorka.LineJoin = LineJoin.Round;

            pictureBox1.Refresh();
        }

        int mouse_x0, mouse_y0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            {
                mouse_x0 = e.X;
                mouse_y0 = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (g3d == null) return;

            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mouse_x0;
                int deltaY = e.Y - mouse_y0;

                // rotate
                vpr.phiH += (-deltaX) / (float)(pictureBox1.Width) * 360 * 2; // *45
                vpr.phiV += (deltaY) / (float)(pictureBox1.Height) * 360 * 2;

                mouse_x0 = e.X;
                mouse_y0 = e.Y;

                Refresh();
            }
            if (e.Button == MouseButtons.Right)
            {
                int deltaX = e.X - mouse_x0;
                int deltaY = e.Y - mouse_y0;

                // pan
                vpr.ox += deltaX;
                vpr.oy += deltaY;

                mouse_x0 = e.X;
                mouse_y0 = e.Y;

                Refresh();
            }
        }
        #endregion

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (ReadABCHN() == false) return;

            bestPath = null;

            g3d.ReTabulate(gorka, 0f, 20f, -20f, 20f, 5e-1f, 5e-1f);
            SetupCheckpionts();
            MakeGorkaShape();

            if (finishPos != null)
            {
                chkpntList[3].Clear();
                chkpntList[3].Add(finishPos);
            }

            Refresh();
        }

        private void MakeGorkaShape()
        {
            if (gorkaPath == null)
                gorkaPath = new Point3D[8];

            gorkaPath[0] = new Point3D((float)a, 0, 0);
            gorkaPath[1] = new Point3D(0, (float)b, 0);
            gorkaPath[2] = new Point3D(0, (float)c, 0);
            gorkaPath[3] = new Point3D((float)a, 0, 0);
            gorkaPath[4] = new Point3D(0, 0, (float)h);
            gorkaPath[5] = new Point3D(0, (float)b, 0);
            gorkaPath[6] = new Point3D(0, (float)c, 0);
            gorkaPath[7] = new Point3D(0, 0, (float)h);
        }

        private bool ReadABCHN()
        {
            errorProvider.Clear();
            try
            {
                a = double.Parse(textBoxA.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxA, "Wrong double number");
                return false;
            }

            try
            {
                b = double.Parse(textBoxB.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxB, "Wrong double number");
                return false;
            }

            try
            {
                c = double.Parse(textBoxC.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxC, "Wrong double number");
                return false;
            }

            try
            {
                h = double.Parse(textBoxH.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxH, "Wrong double number");
                return false;
            }

            int nOld = n;
            try
            {
                n = int.Parse(textBoxN.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxN, "Wrong integer number");
                return false;
            }

            if (n <= 0)
            {
                errorProvider.SetError(textBoxN, "Has to be positive");
                n = nOld;
                return false;
            }

            try
            {
                v0 = double.Parse(textBoxV0.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textBoxV0, "Wrong double number");
                return false;
            }

            return true;
        }

        private void checkBoxStart_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStart.Checked)
            {
                if (SetFinishState)
                    checkBoxFinish.Checked = false;

                Cursor = Cursors.Cross;
                SetStartState = true;
            }
            else
            {
                Cursor = Cursors.Default;
                SetStartState = false;
            }
        }

        private void checkBoxFinish_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFinish.Checked)
            {
                if (SetStartState)
                    checkBoxStart.Checked = false;

                Cursor = Cursors.Cross;
                SetFinishState = true;
            }
            else
            {
                Cursor = Cursors.Default;
                SetFinishState = false;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!SetStartState && !SetFinishState) return;

            Point3dNode p;

            float eX = (e.X - vpr.ox) / vpr.zoom;
            float eY = (e.Y - vpr.oy) / vpr.zoom;

            double sinPhiH = Graphic3D.sin(vpr.phiH);
            double cosPhiH = Graphic3D.cos(vpr.phiH);
            double sinPhiV = Graphic3D.sin(vpr.phiV);
            double cosPhiV = Graphic3D.cos(vpr.phiV);

            //
            // ex   sinPhiH          -cosPhiH
            // ey   cosPhiH·cosPhiV  sinPhiH·cosPhiV
            //

            double Det = sinPhiH * sinPhiH * cosPhiV + cosPhiH * cosPhiV * cosPhiH;
            double Dx = eX * sinPhiH * cosPhiV + eY * cosPhiH;
            double Dy = sinPhiH * eY - cosPhiH * cosPhiV * eX;

            p = new Point3dNode((float)(Dx / Det), (float)(Dy / Det), 0f);

            Cursor = Cursors.Default;

            if (SetStartState)
            {
                p.Region = 0;
                startPos = p;
                checkBoxStart.Checked = false;
                SetStartState = false;
            }

            if (SetFinishState)
            {
                p.Region = 4;
                finishPos = p;
                checkBoxFinish.Checked = false;
                SetFinishState = false;

                if (chkpntList != null)
                {
                    chkpntList[3].Clear();
                    chkpntList[3].Add(finishPos);
                }
            }

            Refresh();
        }

        bool traversed = true;
        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (!traversed)
            {
                traversed = true;
                Log("Aborted by user.");
                return;
            }

            if (startPos == null)
            {
                MessageBox.Show("Select a start point please.");
                return;
            }
            if (finishPos == null)
            {
                MessageBox.Show("Select a finish point please.");
                return;
            }

            lOpen.Clear();
            lClosed.Clear();
            showBestPath = true;
            showPath = true;

            buttonApply.Enabled = false;
            checkBoxStart.Enabled = false;
            checkBoxFinish.Enabled = false;
            groupBoxSearch.Enabled = false;
            groupBoxOptimization.Enabled = false;

            buttonFind.Text = "Abort";
            //bool solved = false, failed = false;

            Log("~~~~ start ~~~~");
            bestPath = null;

            try
            {
                searchMethod();
            }
            finally
            {
                buttonApply.Enabled = true;
                checkBoxStart.Enabled = true;
                checkBoxFinish.Enabled = true;
                groupBoxSearch.Enabled = true;
                groupBoxOptimization.Enabled = true;

                showBestPath = true;
                showPath = false;
                buttonFind.Text = "Find";
                Refresh();
            }
            Log("~~ done ~~");
        }

        private void BreadthFirstSearch()  
        {
            //1. Поместить все узлы из множества So в список OPEN.
            lOpen.Add(startPos);

            traversed = false;
            while (!traversed)
            {
                //Log(string.Format("Open: {0}, closed: {1}.", lOpen.Count, lClosed.Count));

                if (lOpen.Count == 0)
                {
                    traversed = true;
                    break;
                }
                if (lOpen[0].Region == 4)
                {
                    GeneratePath();
                    Animate();
                    TestPath(path);
                }

                if (lOpen[0].Region <= 3) // можно раскрыть
                {
                    //4. Раскрыть вершину n и все порождённые вершины поместить в список OPEN настроив указатели к вершине n
                    for (int i = 0; i < chkpntList[lOpen[0].Region + 1 - 1].Count; i++)
                    {
                        Point3dNode t = new Point3dNode(chkpntList[lOpen[0].Region + 1 - 1][i]);
                        t.Previous = lOpen[0];

                        //5. Если порожденная вершина целевая, т.е. принадлежит Sq то выдать решение с помощью указателей, иначе перейти к шагу №2.
                        if (t.Equals(finishPos))
                        {
                            GeneratePath();
                            Animate();
                            TestPath(path);
                        }
                        else
                        {
                            lOpen.Add(t);
                        }
                    }
                }

                lClosed.Add(lOpen[0]);
                lOpen.RemoveAt(0);
            }

            Log(string.Format("Best path BFS: {0:#.##}", bestPathLen));
        }

        private void DepthFirstSearch()
        {
            //1. Поместить все узлы из множества So в список OPEN.
            lOpen.Add(startPos);

            traversed = false;
            while (!traversed)
            {
                //Log(string.Format("Open: {0}, closed: {1}.", lOpen.Count, lClosed.Count));

                if (lOpen.Count == 0)
                {
                    traversed = true;
                    break;
                }
                if (lOpen[0].Region == 4)
                {
                    GeneratePath();
                    Animate();
                    TestPath(path);
                }

                if (lOpen[0].Region <= 3) // можно раскрыть
                {
                    //4. Раскрыть вершину n и все порождённые вершины поместить в список OPEN настроив указатели к вершине n
                    for (int i = 0; i < chkpntList[lOpen[0].Region + 1 - 1].Count; i++)
                    {
                        Point3dNode t = new Point3dNode(chkpntList[lOpen[0].Region + 1 - 1][i]);
                        t.Previous = lOpen[0];

                        //5. Если порожденная вершина целевая, т.е. принадлежит Sq то выдать решение с помощью указателей, иначе перейти к шагу №2.
                        if (t.Equals(finishPos))
                        {
                            GeneratePath();
                            Animate();
                            TestPath(path);
                        }
                        else
                        {
                            lOpen.Insert(1, t);
                        }
                    }
                }

                lClosed.Add(lOpen[0]);
                lOpen.RemoveAt(0);         
            }
            Log(string.Format("Best path DFS: {0:#.##}", bestPathLen));
        }

        private void HeuristicsSearch()
        {
            //1. Поместить все узлы из множества So в список OPEN.
            lOpen.Add(startPos);

            traversed = false;
            while (!traversed)
            {
                //Log(string.Format("Open: {0}, closed: {1}.", lOpen.Count, lClosed.Count));

                if (lOpen.Count == 0)
                {
                    traversed = true;
                    break;
                }
                if (lOpen[0].Region == 4)
                {
                    GeneratePath();
                    Animate();
                    TestPath(path);
                }

                int q = 0;
                int p = 1;
                if (lOpen[q].Region <= 3) // можно раскрыть
                {
                    //4. Раскрыть вершину n и все порождённые вершины поместить в список OPEN настроив указатели к вершине n
                    for (int i = 0; i < chkpntList[lOpen[q].Region + 1 - 1].Count; i++)
                    {
                        Point3dNode t = new Point3dNode(chkpntList[lOpen[q].Region + 1 - 1][i]);
                        t.Previous = lOpen[q];

                        //5. Если порожденная вершина целевая, т.е. принадлежит Sq то выдать решение с помощью указателей, иначе перейти к шагу №2.
                        if (t.Equals(finishPos))
                        {
                            GeneratePath();
                            Animate();
                            TestPath(path);
                        }
                        else
                        {
                            lOpen.Insert(p, t);
                        }
                    }
                }

                lClosed.Add(lOpen[q]);
                lOpen.RemoveAt(q);
            }
        }

        private void Animate()
        {
            if (checkBoxLog.Checked)
            {
                Refresh();
                System.Threading.Thread.Sleep(10);
            }
            Application.DoEvents();
        }

        private void Log(string p) { Log(p, false); }
        private void Log(string p, bool sameLine)
        {
            //if (!checkBoxLog.Checked) return;

            if (sameLine)
                textBoxLog.AppendText(p);
            else
                textBoxLog.AppendText(Environment.NewLine + p);
            return;
        }

        private void TestPath(List<Point3dNode> path)
        {
            if (bestPath == null)
            {
                bestPathLen = double.MaxValue;
                bestPath = new List<Point3dNode>();
            }

            if (path.Count < 2)
            {
                //throw new ArgumentException();
                return;
            }

            double cost = 0;
            double dist = 0, time = 0;
            List<Point3dNode>.Enumerator i = path.GetEnumerator();
            i.MoveNext();
            Point3dNode prev = i.Current;
            for (; i.MoveNext(); )
            {
                //cost += measuringMethod((Point3D)prev, (Point3D)i.Current);
                dist += MeasureDist((Point3D)prev, (Point3D)i.Current);
                time += MeasureTime((Point3D)prev, (Point3D)i.Current);
                prev = i.Current;
            }

            if (measuringMethod == MeasureDist) cost = dist;
            if (measuringMethod == MeasureTime) cost = time;

            if (cost < bestPathLen)
            {
                bestPath.Clear();
                bestPath.AddRange(path);
                bestPathLen = cost;
            }

            Debug.Print("dist: {0}, time: {1}; best: {2}", dist, time, bestPathLen);

            Log(string.Format(
                "Dist.: {0:#.000}, time.: {1:#.000}; best: {2:#.000}",
                dist, time, bestPathLen)
                );
        }

        private double MeasureDist(Point3D point1, Point3D point2)
        {
            return Math.Sqrt(
                (point1.x - point2.x) * (point1.x - point2.x) +
                (point1.y - point2.y) * (point1.y - point2.y) +
                (point1.z - point2.z) * (point1.z - point2.z)
                );
        }
        private double MeasureTime(Point3D point1, Point3D point2)
        {
            double s =
                Math.Sqrt(
                (point1.x - point2.x) * (point1.x - point2.x) +
                (point1.y - point2.y) * (point1.y - point2.y) +
                (point1.z - point2.z) * (point1.z - point2.z)
                );

            if (Math.Abs(s) < 1e-3) return 0;

            double sinAlpha = Math.Abs(point2.z - point1.z) / s;

            double v = v0 / Math.Sqrt(1+15*sinAlpha*sinAlpha);

            return s/v;
        }

        private void GeneratePath()
        {
            if (path == null) 
                path = new List<Point3dNode>();
            else
                path.Clear();

            path.Add(finishPos);
            Point3dNode curr = lOpen[0];
            while (curr != null)
            {
                path.Add(curr);
                curr = curr.Previous;
            }
        }
        
        #region radio-buttons logic

        private void rbTime_CheckedChanged(object sender, EventArgs e)
        {
            measuringMethod = this.MeasureTime;
        }

        private void rbDist_CheckedChanged(object sender, EventArgs e)
        {
            measuringMethod = this.MeasureDist;
        }

        private void rbBFS_CheckedChanged(object sender, EventArgs e)
        {
            searchMethod = this.BreadthFirstSearch;
        }

        private void rbDFS_CheckedChanged(object sender, EventArgs e)
        {
            searchMethod = this.DepthFirstSearch;
        }

        private void rbHS_CheckedChanged(object sender, EventArgs e)
        {
            searchMethod = this.HeuristicsSearch;
        }
        #endregion
    }

    public class Point3dNode : Point3D
    {
        public Point3dNode Previous;
        public int Region;

        public Point3dNode(float x, float y, float z)
            : base(x, y, z)
        {
            Previous = null;
            Region = -1;
        }

        public Point3dNode(Point3dNode p)
            : base(p.x, p.y, p.z)
        {
            Previous = p.Previous;
            Region = p.Region;
        }

        new public bool Equals(object obj)
        {
            if (obj is Point3dNode)
            {
                Point3dNode p = (Point3dNode)obj;

                return
                    p.Region == this.Region &&
                    p.x == this.x &&
                    p.y == this.y &&
                    p.z == this.z;
            }

            return base.Equals(obj);
        }

        public override string ToString()
        {
            return string.Format("[{0}] at ({1}, {2}, {3})",
                Region, x, y, z);
        }
    }
}
