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
        int[] convex;
        PointF[] pts;
        Random rnd;
        Font font;
        Pen penConvex;
        Pen penTriangle;
        int gridStep = 50;
        IList<Triangle> triangles;

        public class Triangle
        {
            //public PointF v1, v2, v3;
            public PointF[] v;
            //public Triangle t1, t2, t3;
            public Triangle[] t;

            public PointF center; // ?
            public int hashX;
            public int HashY;

            public Triangle(
                PointF vertex1, PointF vertex2, PointF vertex3, 
                Triangle neighbour1, Triangle neighbour2, Triangle neighbour3
                )
                : this(vertex1, vertex2, vertex3)
            {
                t = new Triangle[3];
                t[0] = neighbour1;
                t[1] = neighbour2;
                t[2] = neighbour3;
            }

            public Triangle(PointF vertex1, PointF vertex2, PointF vertex3)
            {
                v = new PointF[3]; 
                v[0] = vertex1;
                v[1] = vertex2;
                v[2] = vertex3;

                center.X = (vertex1.X + vertex2.X + vertex3.X) / 3f;
                center.Y = (vertex1.Y + vertex2.Y + vertex3.Y) / 3f;
            }
        }

        void Flip(ref Triangle A, ref Triangle B)
        {
            int i1, j1, i2, j2;

            for(int i = 0; i < 3; i++)
            for(int j = 0; j < 3; j++)
            if (A.v[i] == B.v[j])
            {i1 = i;}
        }

        IList<Triangle> DelaunayIterative(PointF[] points)
        {
            List<Triangle> trs = new List<Triangle>();

            // sort by X then by Y
            //Array.Sort<PointF>(points, delegate(PointF a, PointF b) { return Math.Sign(a.Y - b.Y); });
            //Array.Sort<PointF>(points, delegate(PointF a, PointF b) { return Math.Sign(a.X - b.X); });

            // remove duplicates. this way?
            for (int i = 0; i < points.Length - 1; i++)
                if (points[i] == points[i + 1]) points[i] = PointF.Empty;

            Triangle tFirst = new Triangle(points[0], points[1], points[2]);
            tFirst.hashX = (int)Math.Floor(tFirst.center.X / gridStep);

            trs.Add(tFirst);

            //for (int i = 3; i <4; i++)
            for (int i = 3; i < points.Length; i++)
            {
                if (points[i].IsEmpty) continue;

                PointF A = points[i];

                Triangle t;

                t = GetTriangleByPoint(trs, A);
                if (t == null)
                {
                    int v1, v2;
                    t = FindNearestTriangle(trs, A, out v1, out v2);


                    trs.Add(new Triangle(A, t.v[v1], t.v[v2]));
                }
                else
                {
                    /*Triangle t1, t2, t3;
                    t1 = new Triangle(t.v[0], t.v[1], A);
                    t2 = new Triangle(t.v[1], t.v[2], A);
                    t3 = new Triangle(t.v[2], t.v[0], A);
                    */

                    trs.Add(new Triangle(t.v[0], t.v[1], A));
                    trs.Add(new Triangle(t.v[1], t.v[2], A));
                    trs.Add(new Triangle(t.v[2], t.v[0], A));
                }
            }


            return trs;
        }

        private Triangle FindNearestTriangle(IList<Triangle> trsCollection, PointF p, out int v1, out int v2)
        {
            v1 = -1;
            v2 = -1;
            double minDistance = double.MaxValue;
            int minIndex = -1;

            int index = -1;
            foreach (Triangle t in trsCollection)
            {
                index++;
                int l = 2;
                for(int k = 0; k < 3; l = k++)
                {   
                    float distance = -1;
                    // A
                    float x1 = t.v[k].X - p.X;
                    float y1 = t.v[k].Y - p.Y;
                    // B
                    float x2 = t.v[l].X - p.X;
                    float y2 = t.v[l].Y - p.Y;

                    PointF AB = Point.Empty;// vector
                    AB.X = x2 - x1;
                    AB.Y = y2 - y1;
                    
                    //double o = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
                    double o = Math.Sqrt(AB.X * AB.X + AB.Y * AB.Y);
                    // OH = 2*S / o
                    double h = Math.Abs(2 * (x1 * y2 - x2 * y1) / o)/2;



                    double AH = -(x1 * AB.X + y1 * AB.Y) / o;

                    if (AH > o || AH < 0)
                    {
                        distance = float.MaxValue;
                        //distance = (float)Math.Min(Math.Sqrt(x1 * x1 + y1 * y1), Math.Sqrt(x2 * x2 + y2 * y2));
                        //distance = (float)Math.Sqrt((x2 + x1) * (x2 + x1) / 4 + (y2 + y1) * (y2 + y1) / 4);
                    }
                    else
                    {
                        distance = (float)h;
                    }

                    if (distance <= minDistance)
                    {
                        minDistance = distance;
                        minIndex = index;
                        v1 = k;
                        v2 = l;
                    }

                }
            }
            return trsCollection[minIndex];
        }

        private Triangle GetTriangleByPoint(ICollection<Triangle> trsCollection, PointF p)
        {
            bool evenNumberOfIntersections;

            foreach (Triangle t in trsCollection)
            {
                bool signPositive1 = (t.v[0].X - p.X) * (t.v[1].Y - t.v[0].Y) - (t.v[1].X - t.v[0].X) * (t.v[0].Y - p.Y) > 0;
                bool signPositive2 = (t.v[1].X - p.X) * (t.v[2].Y - t.v[1].Y) - (t.v[2].X - t.v[1].X) * (t.v[1].Y - p.Y) > 0;
                bool signPositive3 = (t.v[2].X - p.X) * (t.v[0].Y - t.v[2].Y) - (t.v[0].X - t.v[2].X) * (t.v[2].Y - p.Y) > 0;

                evenNumberOfIntersections = !(signPositive1 ^ signPositive2) & !(signPositive1 ^ signPositive3);

                //if ((((t.v[i].Y <= p.Y) && (p.Y < t.v[j].Y)) || ((t.v[j].Y <= p.Y) && (p.Y < t.v[i].Y))) &&
                // (p.X > (t.v[j].X - t.v[i].X) * (p.Y - t.v[i].Y) / (t.v[j].Y - t.v[i].Y) + t.v[i].X))
                //(t.v[i].X < p.X) && (t.v[j].X > p.X) || (t.v[i].X > p.X) && (t.v[j].X < p.X))
                // (p.X > (t.v[j].X - t.v[i].X) * (p.Y - t.v[i].Y) / (t.v[j].Y - t.v[i].Y) + t.v[i].X))
                //    evenNumberOfIntersections = !evenNumberOfIntersections;

                if (evenNumberOfIntersections) return t;
            }
            return null;
        }

        Triangle[] DelaunayDivide(PointF[] points)
        {
            // sort by X
            Array.Sort<PointF>(points, delegate(PointF a, PointF b) { return Math.Sign(a.X - b.X); });
            // sort by Y
            Array.Sort<PointF>(points, delegate(PointF a, PointF b) { return Math.Sign(a.Y - b.Y); });
            // remove duplicates
            // split
            //return null;


            return null;
        }

        List<Triangle> DelaunayDivide(List<Triangle> Sl, List<Triangle> Sr)
        {
            return null;
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

            if (convex != null)
            {
                PointF prev = pts[convex[0]];
                for (int i = 0; i < convex.Length && convex[i] != -1; i++)
                {
                    g.DrawLine(penConvex, prev, pts[convex[i]]);
                    prev = pts[convex[i]];
                }
                g.DrawLine(penConvex, prev, pts[convex[0]]);
            }

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
            //MakeConvex();
            triangles = DelaunayIterative(pts);

            pictureBox1.Refresh();
        }


        private void MakeConvex()
        {
            //if (convex == null)
                convex = new int[pts.Length];

            // find min y
            int minIndex = 0;
            float minVal = pts[minIndex].Y;
            for (int i = 0; i < pts.Length; i++)
            {
                if (pts[i].Y < minVal)
                {
                    minIndex = i;
                    minVal = pts[i].Y;
                }
            }

            // chain
            convex[0] = minIndex;
            int convI = 1;
            int magic = 1;
            do
            {
                minIndex = -1;

                double maxCos = -1.1;
                for (int i = 0; i < pts.Length; i++)
                {
                    PointF p = pts[i];
                    p.X = p.X - pts[convex[convI - 1]].X;
                    p.Y = p.Y - pts[convex[convI - 1]].Y;

                    double cos;
                    if (magic * p.Y >= 0)
                    {
                        cos = p.X / Math.Sqrt(p.X * p.X + p.Y * p.Y);

                        if (magic * cos > maxCos && p.Y * magic > 0)
                        {
                            maxCos = magic * cos;
                            minIndex = i;
                        }
                    }
                }

                if (minIndex == -1)
                {
                    if (magic == 1) { magic = -1; continue; }
                    else break;
                }

                convex[convI++] = minIndex;

                if (convI >= pts.Length) break;
            }
            while (pts[convex[convI - 1]] != pts[convex[0]]);

            for (int i = convI; i < pts.Length; i++) convex[i] = -1;
        }

    }
}
