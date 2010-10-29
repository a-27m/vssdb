using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KG5_Triang
{
    public partial class Form1 : Form
    {
        //int[] convex;
        PointF[] pts;
        Random rnd;
        Font font;
        Pen penConvex;
        Pen penTriangle;
        //int gridStep = 50;
        IList<Triangle> triangles;

        void Flip(ref Triangle A, ref Triangle B)
        {
            //int i1, j1, i2, j2;

            //for(int i = 0; i < 3; i++)
            //for(int j = 0; j < 3; j++)
            //if (A.v[i] == B.v[j])
            //{i1 = i;}
        }

        IList<Triangle> SHull(PointF[] points)
        { 
            List<Triangle> trs = new List<Triangle>();

            // select a seed point x_0 from points[], 
            // sort according to |x_i - x_0|^2.
            float x0, y0;
            x0 = points[0].X;
            y0 = points[0].Y;

            Array.Sort<PointF>(points, 
                delegate(PointF a, PointF b)
                {
                    float dx_ab, dy_ab;
                    dx_ab = a.X - b.X;
                    dy_ab = a.Y - b.Y;
                    return Math.Sign(
                        dx_ab * (a.X + b.X) - 2 * x0 * dx_ab +
                        dy_ab * (a.Y + b.Y) - 2 * y0 * dy_ab
                        );
                }
            );

            List<int> convhull = new List<int>();

            if (IsCCW(points[0], points[1], points[2]))
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

            x0 = (points[0].X + points[1].X + points[2].X) / 3f;
            y0 = (points[0].Y + points[1].Y + points[2].Y) / 3f;

            Array.Sort<PointF>(points, 
                delegate(PointF a, PointF b)
                {
                    float dx_ab, dy_ab;
                    dx_ab = a.X - b.X;
                    dy_ab = a.Y - b.Y;
                    return Math.Sign(
                        dx_ab * (a.X + b.X) - 2 * x0 * dx_ab +
                        dy_ab * (a.Y + b.Y) - 2 * y0 * dy_ab
                        );
                }
            );

            for (int i = 3; i < points.Length; i++)
            { 
                // traverse hull and check visibility condition
                bool prevVisible = false;

                int startEdge = 0;
                int endingEdge = 0;
                int edgeIndex = 0;
                bool visible;

                foreach (int edge in convhull)
                {
                    int edgeNext = edge + 1;
                    edgeNext = edgeNext % convhull.Count;

                    visible = TestVisible(points[i], points[edge], points[edgeNext]);

                    if (visible && edgeIndex == 0)
                        prevVisible = true;

                    if (visible && !prevVisible)
                        startEdge = edge;

                    if (!visible && prevVisible)
                        endingEdge = edge;

                    prevVisible = visible;
                }

                List<int> edgesToRemove = new List<int>();
                for (int edge = startEdge; edge != endingEdge; edge++)
                {
                    int edgeNext;

                    edge = edge % convhull.Count;
                    edgeNext = (edge + 1) % convhull.Count;

                    Triangle t;
                    t = new Triangle(points[convhull[edge]], points[i], points[convhull[edgeNext]]);
                    trs.Add(t);

                    if (edge != startEdge && edge != endingEdge)
                    {
                        edgesToRemove.Add(convhull[edge]);
                        //convhull.Remove(edge);
                        //endingEdge--;
                        //if (endingEdge < 0) endingEdge += convhull.Count;
                    }
                }

                foreach (int index in edgesToRemove)
                    convhull.Remove(index);
                convhull.Insert(startEdge + 1, i);
            }

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

            return OA.X * OB.Y - OA.Y * OB.X > 0;
        }

        private bool IsCCW(PointF A, PointF B, PointF C)
        {
            PointF AB = PointF.Empty;
            PointF AC = PointF.Empty;
            AB.X = B.X - A.X;
            AB.Y = B.Y - A.Y;
            AC.X = C.X - A.X;
            AC.Y = C.Y - A.Y;

            return AB.X * AC.Y - AB.Y * AC.X < 0;
        }

        public Form1()
        {
            InitializeComponent();

            rnd = new Random();

            font = new Font("Arial", 10f);
            penConvex = new Pen(Color.DarkGray, 2f);
            penTriangle = new Pen(Color.Green, 1f);

            Generate();
        }

        private void Generate()
        {
            int N = (int)numericUpDown1.Value;
            pts = new PointF[N];
            for (int i = 0; i < N; i++)
            {
                pts[i].X = rnd.Next(pictureBox1.Width);
                pts[i].Y = rnd.Next(pictureBox1.Height);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //if (convex != null)
            //{
            //    PointF prev = pts[convex[0]];
            //    for (int i = 0; i < convex.Length && convex[i] != -1; i++)
            //    {
            //        g.DrawLine(penConvex, prev, pts[convex[i]]);
            //        prev = pts[convex[i]];
            //    }
            //    g.DrawLine(penConvex, prev, pts[convex[0]]);
            //}

            if (triangles != null)
            {
                int i = 0;
                foreach (Triangle t in triangles)
                {
                    g.DrawLine(penTriangle, t.v[0], t.v[1]);
                    g.DrawLine(penTriangle, t.v[1], t.v[2]);
                    g.DrawLine(penTriangle, t.v[2], t.v[0]);
                    g.DrawString(i.ToString(), font, Brushes.Green, t.center);
                    i++;
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
            Generate();
            Refresh();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            
        }

        private void buttonTriangulate_Click(object sender, EventArgs e)
        {
            triangles = SHull(pts);

            pictureBox1.Refresh();
        }
    }
}
