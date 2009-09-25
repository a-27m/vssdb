using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DekartGraphic;
using System.Drawing.Drawing2D;

namespace lab2__Hunter_Victim_
{
    public partial class Form1 : Form
    {
        public delegate double DoubleVectorFunction(double[] X);
        public double[][] RK4ST(DoubleVectorFunction[] F, double[] Y0, double x1, double x2, double h)
        {
            // assert F.Length == Y0.Length;

            // p - Number of equations === number of variables
            int p = F.Length;

            // n - Integration steps
            int n = (int)Math.Ceiling((x2 - x1) / h);

            double[] k1 = new double[p];
            double[] k2 = new double[p];
            double[] k3 = new double[p];
            double[] k4 = new double[p];
            double[] YforEvenK = new double[p + 1];
            double[] YforOddK = new double[p + 1];

            double h2 = h / 2.0;

            // Y[step][variable]
            double[][] Y = new double[n][];
            for (int i = 0; i < n; i++) Y[i] = new double[p + 1 /*1 is for X==Y[][0] */];
            for (int i = 0; i < p; i++) Y[0][i + 1] = Y0[i];
            for (int i = 0; i < n; i++) Y[i][0] = x1 + h * i;

            for (int step = 0; step < n - 1; step++)
            {
                // calculate koefs for this step

                // k1 = 
                for (int i = 0; i < p; i++)
                {
                    k1[i] = F[i](Y[step]);
                    YforEvenK[i + 1] = Y[step][i + 1] + k1[i] * h2;
                }

                // k2 = 
                YforEvenK[0] = Y[step][0] + h2;
                for (int i = 0; i < p; i++)
                {
                    k2[i] = F[i](YforEvenK);
                    YforOddK[i + 1] = Y[step][i + 1] + k2[i] * h2;
                }

                // k3 = 
                YforOddK[0] = Y[step][0] + h2;
                for (int i = 0; i < p; i++)
                {
                    k3[i] = F[i](YforOddK);
                    YforEvenK[i + 1] = Y[step][i + 1] + k3[i] * h;
                }

                // k4 = 
                YforEvenK[0] = Y[step][0] + h;
                for (int i = 0; i < p; i++)
                {
                    k4[i] = F[i](YforEvenK);
                }

                for (int i = 0; i < p; i++)
                {
                    Y[step + 1][i + 1] = Y[step][i + 1] + (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]) * h / 6.0;
                }
            }

            return Y;
        }

        List<MathGraphic> currGraphic, grsN1T, grsN2T, grsN1N2;

        float zoom = 100;
        float dx, dy;

        double b11, b12, b21, b22, C2;
        double h;
        double[] Y0;
        double[][] Y;
        double T0, Tmax;
        int n;
        double alpha;

        double n1(double[] X)
        {
            // t = X[0]
            // n1 = X[1]
            // n2 = X[2]
            return (b12 * X[2] - b11) * X[1];
        }

        double n2(double[] X)
        {
            // t = X[0]
            // n1 = X[1]
            // n2 = X[2]
            return (b22 - b21 * X[1]) * X[2] - C2;
        }

        double ft(double i) { return Y[(int)i][0]; }
        double fN1(double i) { return Y[(int)i][1]; }
        double fN2(double i) { return Y[(int)i][2]; }
        double fAsympt(double x1)
        {
            // n1 = Y[i][1];
            //return (C2 / b22) + alpha * Y[(int)i][1];

            return (C2 / b22) + alpha * x1;
        }

        public Form1()
        {
            InitializeComponent();
            grsN1T = new List<MathGraphic>();
            grsN2T = new List<MathGraphic>();
            grsN1N2 = new List<MathGraphic>();

            Y0 = new double[2];

            h = 1e-2;
            b11 = 1.1;
            b12 = 1.1;
            b21 = 1.1;
            b22 = 1.1;
            C2 = 0.2;

            Y0[0] = 1;  // n1(0)
            Y0[1] = 1;  // n2(0);

            T0 = 0;
            Tmax = 5;


            dx = pictureBox1.Width / 3f;
            dy = pictureBox1.Height / 2f;

            textBoxH.Text = h.ToString();
            textBoxB11.Text = b11.ToString();
            textBoxB12.Text = b12.ToString();
            textBoxB21.Text = b21.ToString();
            textBoxN1_0.Text = Y0[0].ToString();
            textBoxN2_0.Text = Y0[1].ToString();
            textBoxB22.Text = b22.ToString();
            textBoxC2.Text = C2.ToString();
            textBoxT1.Text = T0.ToString();
            textBoxT2.Text = Tmax.ToString();
        }

        private void buttonGO_Click(object sender, EventArgs e)
        {
            MathGraphic m;

            #region in/out
            try
            {
                h = double.Parse(textBoxH.Text);
                b11 = double.Parse(textBoxB11.Text);
                b12 = double.Parse(textBoxB12.Text);
                b21 = double.Parse(textBoxB21.Text);
                b22 = double.Parse(textBoxB22.Text);
                C2 = double.Parse(textBoxC2.Text);
                Y0[0] = double.Parse(textBoxN1_0.Text);
                Y0[1] = double.Parse(textBoxN2_0.Text);
                T0 = double.Parse(textBoxT1.Text);
                Tmax = double.Parse(textBoxT2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Wrong number format");

                textBoxH.Text = h.ToString();
                textBoxB11.Text = b11.ToString();
                textBoxB12.Text = b12.ToString();
                textBoxB21.Text = b21.ToString();
                textBoxN1_0.Text = Y0[0].ToString();
                textBoxN2_0.Text = Y0[1].ToString();
                textBoxB22.Text = b22.ToString();
                textBoxC2.Text = C2.ToString();
                textBoxT1.Text = T0.ToString();
                textBoxT2.Text = Tmax.ToString();

                return;
            }
            #endregion

            Compute();

            if (radioN1T.Checked)
            {
                grsN1T.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    ft, fN1, 0, n - 1, 1);
                grsN1T.Add(m);
            }
            if (radioN2T.Checked)
            {
                grsN2T.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    ft, fN2, 0, n - 1, 1);
                grsN2T.Add(m);
            }
            if (radioN1N2.Checked)
            {
                grsN1N2.Clear();

                grsN1N2.Add(new MathGraphic(Color.Green, DrawModes.DrawLines,
                    fN1, fN2, 0, n - 1, 1));
                grsN1N2.Add(new MathGraphic(Color.BlueViolet, DrawModes.DrawLines,
                    fAsympt, 0, pictureBox1.Width / zoom, (float)h));
            }

            pictureBox1.Refresh();
        }

        private void Compute()
        {
            // Y[step][variable]
            Y = RK4ST(new DoubleVectorFunction[] { n1, n2 }, Y0, T0, Tmax, h);
            n = Y.Length;
            alpha = b21 / (b22 / C2 * (b22 + b11) - b12);
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (radioN1T.Checked) currGraphic = grsN1T;
            if (radioN2T.Checked) currGraphic = grsN2T;
            if (radioN1N2.Checked) currGraphic = grsN1N2;

            if (currGraphic == null) return;

            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.Transform = new Matrix(zoom, 0, 0, -zoom, dx, dy);
            bool firstPlot = true;
            foreach (MathGraphic mg in currGraphic)
            {
                if (firstPlot) { mg.Draw(g, true); firstPlot = false; }
                else mg.DrawGraphic(g);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            if (!radioN1N2.Checked)
                return;

            Y0[0] = (e.X - dx) / zoom; // n1(0)
            Y0[1] = (e.Y - dy) / -zoom; // n2(0)

            textBoxN1_0.Text = Y0[0].ToString("F3");
            textBoxN2_0.Text = Y0[1].ToString("F3");

            Compute();

            grsN1N2.Clear();
            grsN1N2.Add(new MathGraphic(Color.Green, DrawModes.DrawLines,
                fN1, fN2, 0, n - 1, 1));
            grsN1N2.Add(new MathGraphic(Color.BlueViolet, DrawModes.DrawLines,
                fAsympt, 0, pictureBox1.Width/zoom, (float)h));

            pictureBox1.Refresh();
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            zoom *= 1.25f;
            pictureBox1.Refresh();
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            zoom /= 1.25f;
            pictureBox1.Refresh();
        }

        int mx, my;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mx = e.X; my = e.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dx += e.X - mx; dy += e.Y - my;
                pictureBox1.Refresh();
            }
        }
    }
}
