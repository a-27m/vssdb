using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DekartGraphic;
using System.Drawing.Drawing2D;

namespace lab5___АЧХ__nonlinear_resonance_
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
            for (int i = 0; i < n; i++) Y[i] = new double[p + 1 ]; //+1 is for X==Y[][0]
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
        float a1, a2, h;

        double a(double A) { return A; }

        double SigmaAPlus(double a)
        { return 3.0 / 8.0 * a * a + Math.Sqrt(f * f / (4.0 * a * a) - mju * mju); }
        double SigmaAMinus(double a) 
        { return 3.0 / 8.0 * a * a - Math.Sqrt(f * f / (4.0 * a * a) - mju * mju); }

        double fA(double a)
        { return 2.0 * a * Math.Sqrt(mju * mju + Math.Pow(sigma - 3.0 / 8.0 * a * a, 2)); }

        public Form1()
        {
            InitializeComponent();
            grsAT = new List<MathGraphic>();
            grsGammaT = new List<MathGraphic>();
            grsAGamma = new List<MathGraphic>();

            sigma = 2;
            f = 2;
            mju = 0.4;

            h = 1e-3f;

            a1 = 0;
            a2 = 4;

            dx = pictureBox1.Width / 3f;
            dy = pictureBox1.Height / 2f;

            textBoxSigma.Text = sigma.ToString();
            textBoxF.Text = f.ToString();
            textBoxMju.Text = mju.ToString();
            textBoxX1.Text = a1.ToString();
            textBoxX2.Text = a2.ToString();
        }

        private void buttonGO_Click(object sender, EventArgs e)
        {
            MathGraphic m;

            #region in/out
            try
            {
                sigma = double.Parse(textBoxSigma.Text);
                f = double.Parse(textBoxF.Text);
                mju = double.Parse(textBoxMju.Text);
                a1 = float.Parse(textBoxX1.Text);
                a2 = float.Parse(textBoxX2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Wrong number format");

                textBoxSigma.Text = sigma.ToString();
                textBoxF.Text = f.ToString();
                textBoxMju.Text = mju.ToString();
                textBoxX1.Text = a1.ToString();
                textBoxX2.Text = a2.ToString();

                return;
            }
            #endregion

            if (radioAS.Checked)
            {
                grsAT.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    SigmaAPlus, a, a1, a2, h);
                grsAT.Add(m);
                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    SigmaAMinus, a, a1, a2, h);
                grsAT.Add(m);
            }
            if (radioAF.Checked)
            {
                grsGammaT.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    fA, a, a1, a2, h);
                grsGammaT.Add(m);
            }

            pictureBox1.Refresh();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (radioAS.Checked) currGraphic = grsAT;
            if (radioAF.Checked) currGraphic = grsGammaT;

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

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Text = trackBar1.Value.ToString();
        }
    }
}
