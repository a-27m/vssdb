using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace KG5_Triang
{
    public partial class Form1 : Form, IComparer<PointF>
    {
        //int[] convex;
        PointF[] pts;
        Random rnd;
        Font font;
        Pen penConvex;
        Pen penTriangle, penTriangleNF;
        //int gridStep = 50;
        IList<Triangle> triangles, trianglesNoFlip;

        /// <summary>
        /// Used for sorting in Compare() only!
        /// </summary>
        float x0, y0;

        public static bool Flip(ref Triangle A, ref Triangle B)
        {
            int[] i = new int[2];
            int[] j = new int[2];
            int k=3, l=3;
            int eq = 0;

            for (int p = 0; p < 3; p++)
                for (int q = 0; q < 3; q++)
                    if (A.v[p] == B.v[q])
                    {
                        if (eq > 2-1) return false;

                        i[eq] = p;
                        j[eq] = q;

                        k -= p;
                        l -= q;

                        eq++;
                    }
            
            // if (eq == 0) arn't adjacent;
            if (eq != 2) return false;
            // if (eq == 3) are the same one triangle;

            //PointF tmp = A.v[i[1]];
            A.v[i[1]] = B.v[l];
            B.v[j[0]] = A.v[k];

            return true;
        }

        IList<Triangle> SHull(PointF[] points)
        { 
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
                bool visible;

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

                    if (edge == endingEdge) break;
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

            for (int i = 0; i < trs.Count-1; i++)
            {
                for (int j = i+1; j < trs.Count; j++)
                {
                    Triangle A = trs[i];
                    Triangle B = trs[j];

                    // if (needed) 
                    {
                        Flip(ref A, ref B);
                        trs[i] = A;
                        trs[j] = B;
                    }
                }
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

            return OA.X * OB.Y - OA.Y * OB.X < 0;
        }

        public Form1()
        {
            InitializeComponent();

            rnd = new Random();

            font = new Font("Arial", 10f);
            penConvex = new Pen(Color.DarkGray, 2f);
            penTriangle = new Pen(Color.LightGreen, 1f);
            penTriangleNF = new Pen(Color.LightBlue, 1f);

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
            if (trianglesNoFlip != null)
            {
                int i = 0;
                foreach (Triangle t in trianglesNoFlip)
                {
                    g.DrawLine(penTriangleNF, t.v[0], t.v[1]);
                    g.DrawLine(penTriangleNF, t.v[1], t.v[2]);
                    g.DrawLine(penTriangleNF, t.v[2], t.v[0]);
                    g.DrawString(i.ToString(), font, Brushes.Blue, t.center);
                    i++;
                }
            }

            if (triangles != null)
            {
                int i = 0;
                foreach (Triangle t in triangles)
                {
                    g.DrawLine(penTriangle, t.v[0], t.v[1]);
                    g.DrawLine(penTriangle, t.v[1], t.v[2]);
                    g.DrawLine(penTriangle, t.v[2], t.v[0]);
                    g.DrawString(i.ToString(), font, Brushes.LightGreen, t.center);
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
    }
}
