using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace pre3d
{
    public delegate double DoubleFunction3d(double x, double y);

    public class Point3d
    {
        public float x, y, z;

        public Point3d(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point3d Clone()
        {
            return (Point3d)this.MemberwiseClone();
        }
    }

    public class Graphic3D
    {
        protected Point3d[][] pts;

        public Graphic3D(DoubleFunction3d fxy,
            float x1, float x2,
            float y1, float y2,
            float Step)
        {
            pts = Tabulate(fxy, x1, x2, y1, y2, Step, Step);
        }

        public void Draw(Graphics g)
        {
            g.Clear(Color.White);

            float zoom = 50f;
            float ox = 150;
            float oy = 150;

            g.Transform = new Matrix(zoom, 0, 0, zoom, ox, oy);

            Pen pen = new Pen(Color.Black, 1f / zoom);

            //float dz = (float)(0.5 / Math.Sqrt(2));
            //float ptSize = 0.5F / zoom;

            PointF p1 = new PointF();
            PointF p2 = new PointF();
            PointF p3 = new PointF();

            g.DrawEllipse(pen, 0f, 0f, 3f / zoom, 3f / zoom);

            for (int j = 1; j < pts.Length; j++)
            {
                for (int i = 1; i < pts[j].Length; i++) // в pts[j] меняется y
                {
                    //float dzy = (float)(dz * i);

                    p1.X = (float)(pts[i][j].y - pts[i][j].x/Math.Sqrt(2));
                    p1.Y = (float)(pts[i][j].x / Math.Sqrt(2) - pts[i][j].z);

                    p2.X = (float)(pts[i-1][j].y - pts[i-1][j].x / Math.Sqrt(2));
                    p2.Y = (float)(pts[i - 1][j].x / Math.Sqrt(2) - pts[i - 1][j].z);

                    p3.X = (float)(pts[i][j-1].y - pts[i][j-1].x / Math.Sqrt(2));
                    p3.Y = (float)(pts[i][j-1].x / Math.Sqrt(2) - pts[i][j-1].z);

                    g.DrawLine(pen, p1, p2);
                    g.DrawLine(pen, p1, p3);
                }
            }
        }

        protected PointF As2d(Point3d p3, float dzx)
        {
            PointF p2 = new PointF();
            p2.X = p3.y - dzx;
            return p2;
        }

        public static Point3d[][] Tabulate(DoubleFunction3d fxy,
            float x1, float x2,
            float y1, float y2,
            float StepX, float StepY)
        {
            if (StepX < float.Epsilon)
                throw new ArgumentOutOfRangeException("StepX", "Step is too small");
            if (StepY < float.Epsilon)
                throw new ArgumentOutOfRangeException("StepY", "Step is too small");

            if (fxy == null)
                throw new ArgumentNullException("fx");

            List<Point3d> dots = new List<Point3d>();
            List<Point3d[]> surf = new List<Point3d[]>();

            float z;

            for (float x = x1; x <= x2; x += StepX)
            {
                for (float y = y1; y <= y2; y += StepY)
                {
                    try
                    {
                        z = (float)fxy(x, y);

                        if ((z > int.MaxValue) || (z < int.MinValue))
                            throw new ArithmeticException();
                        if (float.IsInfinity(z) || float.IsNaN(z))
                            throw new ArithmeticException();
                    }
                    catch (ArithmeticException)
                    {
                        z = 0;
                    }

                    dots.Add(new Point3d(x, y, z));
                }

                surf.Add(dots.ToArray());
                dots.Clear();
            }
            return surf.ToArray();
        }
    }
}
