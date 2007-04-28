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

        public float zoom = 50f;
        public float ox = 150;
        public float oy = 150;

        //public float alphaX = (float)(5f / 4f * Math.PI);
        //public float alphaY = (float)0f;
        //public float alphaZ = (float)(1f / 2f * Math.PI);
        public float alphaX = (float)(180 + 45);
        public float alphaY = (float)0f;
        public float alphaZ = (float)(90);

        float z_max, z_min;

        float sinX, sinY, sinZ;
        float cosX, cosY, cosZ;

        public void Draw(Graphics g)
        {
            g.Clear(Color.White);
            g.Transform = new Matrix(zoom, 0, 0, zoom, ox, oy);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Black, 0.45f / zoom);

            PointF p1 = new PointF();
            PointF p2 = new PointF();
            PointF p3 = new PointF();
            PointF p4 = new PointF();

            //            g.DrawEllipse(pen, 0f, 0f, 3f / zoom, 3f / zoom);

            cosX = (float)Math.Cos(alphaX / 180f * Math.PI);
            cosY = (float)Math.Cos(alphaY / 180f * Math.PI);
            cosZ = (float)Math.Cos(alphaZ / 180f * Math.PI);

            sinX = (float)Math.Sin(alphaX / 180f * Math.PI);
            sinY = (float)Math.Sin(alphaY / 180f * Math.PI);
            sinZ = (float)Math.Sin(alphaZ / 180f * Math.PI);

            for (int j = 1; j < pts.Length; j++)
            {
                for (int i = 1; i < pts[j].Length; i++) // в pts[j] меняется y
                {
                    Project(ref p1, pts[i][j]);//, cosX, cosY, cosZ);
                    Project(ref p2, pts[i - 1][j]);//, cosX, cosY, cosZ);
                    Project(ref p3, pts[i][j - 1]);//, cosX, cosY, cosZ);
                    Project(ref p4, pts[i - 1][j - 1]);//, cosX, cosY, cosZ);

                    int v = (int)((pts[i][j].z - z_min) / (z_max - z_min) * 200) + 50;

                    //g.FillPolygon(new SolidBrush(Color.FromArgb(v, v, v)),
                    //    new PointF[] { p1, p2, p4, p3 });
                    g.DrawLine(pen, p1, p2);
                    g.DrawLine(pen, p1, p3);
                }
            }

            PointF ptO = new PointF();
            PointF ptOx = new PointF();
            PointF ptOy = new PointF();
            PointF ptOz = new PointF();
            pen.Color = Color.Green;
            pen.Width = 2f / zoom;

            Project(ref ptO, new Point3d(0, 0, 0));//, cosX, cosY, cosZ);
            Project(ref ptOx, new Point3d(5, 0, 0));//, cosX, cosY, cosZ);
            Project(ref ptOy, new Point3d(0, 5, 0));//, cosX, cosY, cosZ);
            Project(ref ptOz, new Point3d(0, 0, 5));//, cosX, cosY, cosZ);

            g.DrawLine(pen, ptO, ptOx);
            g.DrawLine(pen, ptO, ptOz);
            pen.Color = Color.Red;
            g.DrawLine(pen, ptO, ptOy);
        }

        protected void Project(ref PointF p2d, Point3d p3d)
        {
            //p2d.X = cosY * p3d.y + cosX * p3d.x;
            //p2d.Y = -cosX * p3d.x - cosZ * p3d.z;

            //mx = 

            p2d.X = p3d.x * cosX + p3d.y * cosY + p3d.z * cosZ;
            p2d.Y = p3d.x * sinX + p3d.y * sinY + p3d.z * sinZ;
            p2d.Y = -p2d.Y;
        }

        public Point3d[][] Tabulate(DoubleFunction3d fxy,
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
                    if (z_max < z)
                        z_max = z;
                    if (z_min > z)
                        z_min = z;
                }

                surf.Add(dots.ToArray());
                dots.Clear();
            }
            return surf.ToArray();
        }
    }
}
