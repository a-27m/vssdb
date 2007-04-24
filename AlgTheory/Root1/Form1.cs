using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using DekartGraphic;
using Polish;

namespace Root1
{
    public partial class Form1 : Form
    {
        List<MathGraphic> mgs;
        Matrix matrix;

        double f1(double x)
        {
            return Math.Sin(x * x - 4);
        }

        double fxy(double x, double y)
        {
            double a = 5;
            double b = 1;
            double c = 5;
            return a * x * x + b * y * y * y + c * x * y * y + x * x * x * x * x * x * x;

            //return x * x * x + y * y * y - x * y;
        }

        public Form1()
        {
            InitializeComponent();
            matrix = new Matrix(300, 0f, 0f, -300, 200, 200);
            mgs = new List<MathGraphic>();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mgs != null)
            {
                if (mgs.Count < 1)
                    return;

                Invalidate();

                List<MathGraphic>.Enumerator i = mgs.GetEnumerator();
                i.MoveNext();

                e.Graphics.Transform = matrix;
                //i.Current.DrawCoordinateSystem(e.Graphics);
                i.Current.Draw(e.Graphics);

                while (i.MoveNext())
                    i.Current.DrawGraphic(e.Graphics);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            PointF[] pts = new PointF[] { new PointF(e.X, e.Y) };
            Matrix tmp = matrix.Clone();
            tmp.Invert();
            tmp.TransformPoints(pts);
            Text = string.Format("{0}, {1}", pts[0].X, pts[0].Y);
        }

        double[] Iteration(DoubleFunction f, double a, double b, double h)
        {
            List<double> roots = new List<double>();
            int lastSign = Math.Sign(f(a));

            for (double x = a; x <= b; x += h)
            {
                int sign = Math.Sign(f(x));
                if (sign == 0)
                    sign = lastSign;
                if (sign != lastSign)
                {
                    roots.Add(x);
                    //OnRootFound(x);
                }
                lastSign = sign;
            }

            return roots.ToArray();
        }

        double fy0(double x)
        {
            return fxy(x, y);
        }
        double fx0(double y)
        {
            return fxy(x, y);
        }

        double x, y;

        private void button1_Click(object sender, EventArgs e)
        {
            DekartForm df = new DekartForm(30, 30, 200, 200);

            List<PointF> pts = new List<PointF>();

            double x1 = -3;
            double x2 = 3;
            double hx = 1e-2;

            double y1 = -3;
            double y2 = 3;
            double hy = 1e-2;

            for (y = y1; y < y2; y += hy)
            {
                double[] rootX = Iteration(fy0, x1, x2, hx);

                for (int i = 0; i < rootX.Length; i++)
                    pts.Add(new PointF((float)rootX[i], (float)y));
            }

            for (x = x1; x < x2; x += hx)
            {
                double[] rootY = Iteration(fx0, y1, y2, hy);

                for (int i = 0; i < rootY.Length; i++)
                    pts.Add(new PointF((float)x, (float)rootY[i]));
            }


            df.AddPolygon(Color.Gray, DrawModes.DrawPoints, pts.ToArray());
            df.Show();
            df.Update2();
            //MathGraphic mg = new MathGraphic(pts.ToArray());
            //mg.PenColor = Color.Green;

            //mg.PenWidth = 1f;
            //mgs.Add(mg);

            Refresh();
        }
    }
}