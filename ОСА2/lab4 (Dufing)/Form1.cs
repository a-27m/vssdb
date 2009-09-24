using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DekartGraphic;
using System.Drawing.Drawing2D;

namespace lab4__Dufing_
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
            int n = (int)Math.Ceiling((x2-x1) / h);

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
            for (int i = 0; i < p; i++) Y[0][i+1] = Y0[i];
            for (int i = 0; i < n; i++) Y[i][0] = x1 + h * i;

            for (int step = 0; step < n-1; step++)
            {
                // calculate koefs for this step

                // k1 = 
                for (int i = 0; i < p; i++)
                {
                    k1[i] = F[i](Y[step]);
                    YforEvenK[i+1] = Y[step][i+1] + k1[i] * h2;
                }

                // k2 = 
                YforEvenK[0] = Y[step][0] + h2;
                for (int i = 0; i < p; i++)
                {
                    k2[i] = F[i](YforEvenK);
                    YforOddK[i+1] = Y[step][i+1] + k2[i] * h2;
                }
                
                // k3 = 
                YforOddK[0] = Y[step][0] + h2;
                for (int i = 0; i < p; i++)
                {
                    k3[i] = F[i](YforOddK);
                    YforEvenK[i+1] = Y[step][i+1] + k3[i] * h;
                }

                // k4 = 
                YforEvenK[0] = Y[step][0] + h;
                for (int i = 0; i < p; i++)
                {
                    k4[i] = F[i](YforEvenK);
                }

                for (int i = 0; i < p; i++)
                {
                    Y[step+1][i+1] = Y[step][i+1] + (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]) * h / 6.0;
                }
            }

            return Y;
        }

        List<MathGraphic> currGraphic, grsAT, grsGammaT, grsAGamma;

        float zoom = 100;
        float dx, dy;

        double sigma, f, mju;
        double x1, x2, h;
        double[] Y0;
        double[][] Y;
        double T0, Tmax;
        int n;


        double a(double[] X)
        {
            // T1 = X[0]
            // a = X[1]
            // gamma = X[2]
            return -mju * X[1] + 0.5 * f * Math.Sin(X[2]);
        }

        double gamma(double[] X)
        {
            // T1 = X[0]
            // a = X[1]
            // gamma = X[2]
            return sigma - 3.0/8.0 * X[1]*X[1] + f / 2.0 / X[1] * Math.Cos(X[2]);
        }

        double fx(double i) { return Y[(int)i][0]; }
        double fa(double i) { return Y[(int)i][1]; }
        double fgamma(double i) { return Y[(int)i][2]; }

        public Form1()
        {
            InitializeComponent();
            grsAT = new List<MathGraphic>();
            grsGammaT = new List<MathGraphic>();
            grsAGamma = new List<MathGraphic>();

            Y0 = new double[2];

            h = 1e-2;
            sigma = 0.8;
            f = 2;
            mju = 0.1;

            Y0[0] = 1;  // a(0)
            Y0[1] = 1;  // gamma(0);

            x1 = 0;
            x2 = 30;

            dx = pictureBox1.Width / 3f;
            dy = pictureBox1.Height / 2f;

            textBoxH.Text = h.ToString();
            textBoxSigma.Text = sigma.ToString();
            textBoxF.Text = f.ToString();
            textBoxMju.Text = mju.ToString();
            textBoxA0.Text = Y0[0].ToString();
            textBoxGamma0.Text = Y0[1].ToString();
            textBoxX1.Text = x1.ToString();
            textBoxX2.Text = x2.ToString();
        }

        private void buttonGO_Click(object sender, EventArgs e)
        {
            MathGraphic m;

            #region in/out
            try
            {
                h = double.Parse(textBoxH.Text);
                sigma = double.Parse(textBoxSigma.Text);
                f = double.Parse(textBoxF.Text);
                mju = double.Parse(textBoxMju.Text);
                Y0[0] = double.Parse(textBoxA0.Text);
                Y0[1] = double.Parse(textBoxGamma0.Text);
                x1 = double.Parse(textBoxX1.Text);
                x2 = double.Parse(textBoxX2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Wrong number format");

                textBoxH.Text = h.ToString();
                textBoxSigma.Text = sigma.ToString();
                textBoxF.Text = f.ToString();
                textBoxMju.Text = mju.ToString();
                textBoxA0.Text = Y0[0].ToString();
                textBoxGamma0.Text = Y0[1].ToString();
                textBoxX1.Text = x1.ToString();
                textBoxX2.Text = x2.ToString();

                return;
            }
            #endregion

            // Y[step][variable]
            Y = RK4ST(new DoubleVectorFunction[] { a, gamma }, Y0, x1, x2, h);
            n = Y.Length;

            //for (int i = 0; i < n; i++)
            //{
            //    listBox1.Items.Add(String.Format("x: {0:F5}   a: {1:F5}   g: {2:F5}",
            //        Y[i][0], Y[i][1], Y[i][2])); // Y[step][variable]
            //}                        

            if (radioAT.Checked)
            {
                grsAT.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    fx, fa, 0, n - 1, 1);
                grsAT.Add(m);
            }
            if (radioGammaT.Checked)
            {
                grsGammaT.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    fx, fgamma, 0, n - 1, 1);
                grsGammaT.Add(m);
            }
            if (radioAGamma.Checked)
            {
                grsAGamma.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    fa, fgamma, 0, n - 1, 1);
                grsAGamma.Add(m);
            }

            pictureBox1.Refresh();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (radioAT.Checked) currGraphic = grsAT;
            if (radioGammaT.Checked) currGraphic = grsGammaT;
            if (radioAGamma.Checked) currGraphic = grsAGamma;

            if (currGraphic == null) return;

            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.Transform = new Matrix(zoom, 0, 0, -zoom, dx, dy);
            foreach (MathGraphic mg in currGraphic) mg.Draw(g, false);
        }

        //private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left) return;

        //    if (!radioVX.Checked) return;

        //    x0 = (e.X - dx) / zoom;
        //    v0 = (e.Y - dy) / -zoom;

        //    textBoxX0.Text = x0.ToString("F3");
        //    textBoxV0.Text = v0.ToString("F3");

        //    Compute();
        //    AddGraphicVX();

        //    pictureBox1.Refresh();
        //}

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
