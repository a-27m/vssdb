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

        float sin(float degree)
        {
            return (float)Math.Sin(degree / 180.0 * Math.PI);
        }
        float cos(float degree)
        {
            return (float)Math.Cos(degree / 180.0 * Math.PI);
        }

        public Graphic3D(DoubleFunction3d fxy,
            float x1, float x2,
            float y1, float y2,
            float Step)
        {
            x_min = x1;
            x_max = x2;
            y_min = y1;
            y_max = y2;
            pts = Tabulate(fxy, x1, x2, y1, y2, Step, Step);
        }

        public float zoom = 50f;
        public float ox = 150;
        public float oy = 150;

        float x_max, x_min;
        float y_max, y_min;
        float z_max, z_min;

        float Xi, Yi, Zi;
        float Xj, Yj, Zj;
        float Xk, Yk, Zk;
        
        public float mx = 1f, my = 1f, mz = 1f;

        public float phiH = 0f, phiV = 0f;

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

            Xi = mx * cos(phiH) * cos(phiV);
            Xj = my * sin(phiH) * cos(phiV);
            Xk = mz * sin(phiV);
            Norm(ref Xi, ref Xj, ref Xk);
            Yi = mx * cos(90f+phiH) * cos(phiV);
            Yj = my *  sin(90f+phiH) * cos(phiV);
            Yk = mz * sin(phiV);
            Norm(ref Yi, ref Yj, ref Yk);
            Zi = mx * cos(phiH) * cos(90f+phiV);
            Zj = my * sin(phiH) * cos(90f+phiV);
            Zk = mz * sin(90f+phiV);
            Norm(ref Zi, ref Zj, ref Zk);

            for (int j = 1; j < pts.Length; j++)
            {
                for (int i = 1; i < pts[j].Length; i++) // в pts[j] меняется y
                {
                    Project(ref p1, pts[i][j]);
                    Project(ref p2, pts[i - 1][j]);
                    Project(ref p3, pts[i][j - 1]);
                    Project(ref p4, pts[i - 1][j - 1]);

                    int v = (int)((pts[i][j].z - z_min) / (z_max - z_min) * 200) + 50;

                    //g.FillPolygon(new SolidBrush(Color.FromArgb(v, v, v)),
                    //    new PointF[] { p1, p2, p4, p3 });
                    pen.Color = Color.FromArgb(v, v, v);
                    g.DrawLine(pen, p1, p2);
                    g.DrawLine(pen, p1, p3);
                }
            }

            #region Axes

            pen.Width =2f / zoom;
            pen.EndCap = LineCap.Round;

            Project(ref p1, new Point3d(0, 0, 0));

            // x
            pen.Color = Color.Blue;
            //Project(ref p1, new Point3d(x_min, 0, 0));
            Project(ref p2, new Point3d(x_max, 0, 0));            
            g.DrawLine(pen, p1, p2);

            // y
            pen.Color = Color.Red;
            //Project(ref p1, new Point3d(0, y_min, 0));
            Project(ref p2, new Point3d(0, y_max, 0));
            g.DrawLine(pen, p1, p2);

            // z
            pen.Color = Color.Green;
            //Project(ref p1, new Point3d(0, 0, z_min));
            Project(ref p2, new Point3d(0, 0, z_max));
            g.DrawLine(pen, p1, p2);

            #endregion
        }

        private void Norm(ref float Xi, ref float Xj, ref float Xk)
        {
            float norm = (float)Math.Sqrt(Xi * Xi + Xj * Xj + Xk * Xk);
            Xi /= norm;
            Xj /= norm;
            Xk /= norm;
        }

        protected void Project(ref PointF p2d, Point3d p3d)
        {
            p2d.X = p3d.x * sin(phiH) + p3d.y * cos(phiH);
            p2d.Y = p3d.x * cos(phiH) * cos(phiV) - p3d.y * sin(phiH) * cos(phiV) - p3d.z * sin(phiV);
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
