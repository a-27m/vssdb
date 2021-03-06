using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DekartGraphic;

namespace Lab_02
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        float a = 0f;
        float b = 2f;
        int n = 2;

        PointF[] givenPoints;

        double[] m;

        double f(double x)
        {
            // Vika
            //return (2 * x * x + Math.Log(x + 1, Math.E));

            // Ksu
            //return x*x*Math.Log(x,Math.E)-x;

            // Runte Paradox
            //return 1 / (1 + 12 * x * x);

            // My function
            return (Math.Cos(x) + 2.0) / (x + 1);
        }

        double deriv_f(double x)
        {
            return -Math.Sin(x) / (x + 1) -
          (Math.Cos(x) + 2.0) / (x + 1) / (x + 1);
        }

        double deriv2_f(double x)
        {
            return -Math.Cos(x) / (x + 1) +
                2 * Math.Sin(x) / (x + 1) / (x + 1) +
                2 / (x + 1) / (x + 1) / (x + 1) * (Math.Cos(x) + 2);
        }

        double taylor(double x)
        {
            double x0 = (a + b) / 2.0;
            return f(x0) + (deriv_f(x0) + 0.5 * deriv2_f(x0) * (x - x0)) * (x - x0);
        }

        double taylor_err(double x)
        {
            return Math.Abs(f(x) - taylor(x));
        }

        double lagrange(double x)
        {
            double sum = 0.0;
            for (int k = 0; k <= n; k++)
            {
                double numerator = 1;
                double denominator = 1;
                for (int i = 0; i <= n; i++)
                {
                    if (i == k) continue;
                    numerator *= (x - givenPoints[i].X);
                    denominator *= (givenPoints[k].X - givenPoints[i].X);
                }
                sum += givenPoints[k].Y * numerator / denominator;
            }

            return sum;
        }

        double lagrange_err(double x)
        {
            return Math.Abs(lagrange(x) - f(x));
        }

        double newtone(double x)
        {
            double[,] diff = new double[n + 1, n + 1];
            double h = (b - a) / n;
            for (int ii = 0; ii <= n; ii++)
                diff[ii, ii] = givenPoints[ii].Y;

            for (int i2 = 1; i2 <= n; i2++)
                for (int i1 = i2 - 1; i1 >= 0; i1--)
                    diff[i1, i2] = (diff[i1 + 1, i2] - diff[i1, i2 - 1]) /
                        ((i2 - i1) * h);

            double sum = 0;

            for (int i = 0; i <= n; i++)
            {
                double mul = 1;
                for (int k = 0; k <= i - 1; k++)
                    mul *= x - givenPoints[k].X;

                sum += mul * diff[0, i];
            }

            return sum;
        }

        double newtone_err(double x)
        {
            return Math.Abs(newtone(x) - f(x));
        }

        double splines(double x)
        {
            double h = (b - a) / n;
            int k = (int)Math.Floor((x - a) / h);
            return
                m[k] / 6 / H(k) * Math.Pow(givenPoints[k + 1].X - x, 3) +
                m[k + 1] / 6 / H(k) * Math.Pow(x - givenPoints[k].X, 3) +
                (givenPoints[k].Y / H(k) - m[k] * H(k) / 6) * (givenPoints[k + 1].X - x) +
                (givenPoints[k + 1].Y / H(k) - m[k + 1] * H(k) / 6) * (x - givenPoints[k].X);
        }

        double H(int k)
        {
            if (k == n) throw new ArgumentOutOfRangeException("k", "k must to be less than n");
            return givenPoints[k + 1].X -
                givenPoints[k].X;
        }

        double D(int k)
        {
            if (k == n) throw new ArgumentOutOfRangeException("k", "k must to be less than n");
            return (givenPoints[k+1].Y - givenPoints[k].Y)/H(k);
        }

        double splines_err(double x)
        {
            return Math.Abs(splines(x) - f(x));
        }

        double ab(double x)
        {
            double val = 2.0;
            if ((a < x) && (x < b)) return val * Math.Cos(100 * Math.PI * x) / 2.0 + val / 2.0;
            return 0.0;
        }

        private void buttonTask1_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBoxA.Text);
                b = float.Parse(textBoxB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Parsing error, aborted.");
                return;
            }

            DekartForm df = new DekartForm(40, 40,
                Screen.PrimaryScreen.WorkingArea.Width / 2,
                Screen.PrimaryScreen.WorkingArea.Height / 2);
            df.WindowState = FormWindowState.Maximized;
            df.Text = "Red - f(x) | Olive - df(x)/dx | Green - d²f(x)/dx²";

            df.AddGraphic(new DoubleFunction(f), a, b, DrawModes.DrawLines,
                Color.Red);
            df.AddGraphic(new DoubleFunction(deriv_f), a, b, DrawModes.DrawLines,
                Color.Olive);
            df.AddGraphic(new DoubleFunction(deriv2_f), a, b, DrawModes.DrawLines,
                Color.Green);
			df.Show();
			//DrawAllGraphics();

        }

        private void buttonTaylor_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBoxA.Text);
                b = float.Parse(textBoxB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Parsing error, aborted.");
                return;
            }

            DekartForm df = new DekartForm(150, 150, 50, 430);
            df.Size = new Size(440, 540);
            df.Text = "Red - error | Olive - Taylor's row | Green - f(x)";

            df.AddGraphic(new DoubleFunction(taylor_err), a, b, DrawModes.DrawLines,
                Color.Red);
            df.AddGraphic(new DoubleFunction(taylor), a, b, DrawModes.DrawLines,
                Color.Olive);
            df.AddGraphic(new DoubleFunction(f), a, b, DrawModes.DrawPoints,
                Color.Green);
            //df.DrawAllGraphics();
			df.Show();
        }

        private void buttonLagr_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBoxA.Text);
                b = float.Parse(textBoxB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Parsing error, aborted.");
                return;
            }

            n = (int)numericN.Value;

            float h = (b - a) / n;

            givenPoints = new PointF[n + 1];

            // fill table givenPoints with known values
            for (int i = 0; i <= n; i++)
            {
                givenPoints[i].X = a + i * h;
                givenPoints[i].Y = (float)f(givenPoints[i].X);
            }

            DekartForm df = new DekartForm(150, 150, 50, 430);
            df.Size = new Size(440, 540);
            df.Text = "n = "+n.ToString()+" | Red - error | "+
                "Olive - Lagrange polynom | Green - f(x)";

            df.AddGraphic(new DoubleFunction(lagrange_err), a, b, DrawModes.DrawLines,
                Color.Red);
            df.AddGraphic(new DoubleFunction(lagrange), a, b, DrawModes.DrawLines,
                Color.Olive);
            df.AddGraphic(new DoubleFunction(f), a, b, DrawModes.DrawPoints,
                Color.Green);
			df.Show();//			DrawAllGraphics();
        }

        private void buttonNewtone_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBoxA.Text);
                b = float.Parse(textBoxB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Parsing error, aborted.");
                return;
            }

            n = (int)numericN.Value;
            float h = (b - a) / n;

            givenPoints = new PointF[n + 1];

            // fill table givenPoints with known values
            for (int i = 0; i <= n; i++)
            {
                givenPoints[i].X = a + i * h;
                givenPoints[i].Y = (float)f(givenPoints[i].X);
            }

            DekartForm df = new DekartForm(150, 150, 50, 430);
            df.Size = new Size(440, 540);
            df.Text = "n = "+n.ToString()+" | Red - error | "+
                "Olive - Newton's interpolation polynom | Green - f(x)";

            df.AddGraphic(new DoubleFunction(newtone_err), a, b, DrawModes.DrawLines,
                Color.Red);
            df.AddGraphic(new DoubleFunction(newtone), a, b, DrawModes.DrawLines,
                Color.Olive);
            df.AddGraphic(new DoubleFunction(f), a, b, DrawModes.DrawPoints,
                Color.Green);
			df.Show();//.DrawAllGraphics();

        }

        private void buttonChe_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBoxA.Text);
                b = float.Parse(textBoxB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Parsing error, aborted.");
                return;
            }

            n = (int)numericN.Value;
            float h = (b - a) / n;

            givenPoints = new PointF[n + 1];

            // fill table givenPoints with known values
            for (int i = 0; i <= n; i++)
            {
                double ksi = Math.Cos(Math.PI * (2 * i + 1) / (2 * n + 2));
                double xi = (a + b) / 2.0 - (b - a) / 2.0 * ksi;
                givenPoints[i].X = (float)xi;
                givenPoints[i].Y = (float)f(givenPoints[i].X);
            }

            DekartForm df = new DekartForm(150, 150, 50, 430);
            df.Size = new Size(440, 540);
            df.Text = "n = " + n.ToString() + " | Red - error | "+
                "Olive - Chebyshev's polynom | Green - f(x)";

            df.AddGraphic(new DoubleFunction(lagrange_err), a, b, DrawModes.DrawLines,
                Color.Red);
            df.AddGraphic(new DoubleFunction(lagrange), a, b, DrawModes.DrawLines,
                Color.Olive);
            df.AddGraphic(new DoubleFunction(f), a, b, DrawModes.DrawPoints,
                Color.Green);
			df.Show();//.DrawAllGraphics();
        }

        private void buttonSplines_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBoxA.Text);
                b = float.Parse(textBoxB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Parsing error, aborted.");
                return;
            }

            n = (int)numericN.Value;
            float h = (b - a) / n;

            givenPoints = new PointF[n + 1];

            // fill table givenPoints with known values
            for (int i = 0; i <= n; i++)
            {
                givenPoints[i].X = a + i * h;
                givenPoints[i].Y = (float)f(givenPoints[i].X);
            }

            double[] P = new double[n + 1];
            double[] q = new double[n + 1];
                     m = new double[n + 1];

            double[] _a = new double[n];
            double[] _b = new double[n];
            double[] _c = new double[n];
            double[] _v = new double[n];

            m[0] = m[n] = 0;
            _b[0] = 2 * (H(0) + H(1));

            for (int k = 0; k < n; k++)
            {
                _a[k] = H(k);
                if (k>0) _b[k] = 2 * (H(k - 1) + H(k));
                if (k<n-1) _c[k] = H(k + 1);
                if (k>0) _v[k] = 6 * (D(k) - D(k - 1));
            }

            P[n-1] = givenPoints[n-1].Y / H(n - 1);
            q[n-1] = givenPoints[n].Y / H(n - 1);

            for (int k = n - 1; k > 0; k--)
            {
                P[k - 1] = -_a[k] / (_b[k] + _c[k] * P[k]);
                q[k - 1] = (_v[k] - _c[k] * q[k]) / (_b[k] + _c[k] * P[k]);
            }

            m[1] = (_v[1] - _c[1] * q[1]) / (_b[1] + _c[1] * P[1]);

            for (int k = 1; k < n - 1; k++)
                m[k + 1] = P[k] * m[k] + q[k];

            DekartForm df = new DekartForm(150, 150, 50, 430);
            df.Size = new Size(440, 540);
            df.Text = "n = " + n.ToString() + " | Red - error | "+
                "Olive - Splines (natural), Green - f(x)";

            df.AddGraphic(new DoubleFunction(splines_err), a, b, DrawModes.DrawLines,
                Color.Red);
            df.AddGraphic(new DoubleFunction(splines), a, b, DrawModes.DrawLines,
                Color.Olive);
            df.AddGraphic(new DoubleFunction(f), a, b, DrawModes.DrawPoints,
                Color.Green);
			df.Show();//.DrawAllGraphics();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

//double _newtone(int i1, int i2)
//{
//    if (i2 < i1) throw new ArgumentOutOfRangeException("i2<i1");

//    if (i2 == i1) return f(givenPoints[i1].X);

//    return (_newtone(i1 + 1, i2) - _newtone(i1, i2 - 1)) /
//        (givenPoints[i2].X - givenPoints[0].X);
//}
