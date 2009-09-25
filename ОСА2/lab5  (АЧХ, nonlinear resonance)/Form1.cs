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
        //public delegate double DoubleVectorFunction(double[] X);
        //public double[][] RK4ST(DoubleVectorFunction[] F, double[] Y0, double x1, double x2, double h)
        //{
        //    // assert F.Length == Y0.Length;

        //    // p - Number of equations === number of variables
        //    int p = F.Length;

        //    // n - Integration steps
        //    int n = (int)Math.Ceiling((x2-x1) / h);

        //    double[] k1 = new double[p];
        //    double[] k2 = new double[p];
        //    double[] k3 = new double[p];
        //    double[] k4 = new double[p];
        //    double[] YforEvenK = new double[p + 1];
        //    double[] YforOddK = new double[p + 1]; 
            
        //    double h2 = h / 2.0;

        //    // Y[step][variable]
        //    double[][] Y = new double[n][];
        //    for (int i = 0; i < n; i++) Y[i] = new double[p + 1 ]; //+1 is for X==Y[][0]
        //    for (int i = 0; i < p; i++) Y[0][i+1] = Y0[i];
        //    for (int i = 0; i < n; i++) Y[i][0] = x1 + h * i;

        //    for (int step = 0; step < n-1; step++)
        //    {
        //        // calculate koefs for this step

        //        // k1 = 
        //        for (int i = 0; i < p; i++)
        //        {
        //            k1[i] = F[i](Y[step]);
        //            YforEvenK[i+1] = Y[step][i+1] + k1[i] * h2;
        //        }

        //        // k2 = 
        //        YforEvenK[0] = Y[step][0] + h2;
        //        for (int i = 0; i < p; i++)
        //        {
        //            k2[i] = F[i](YforEvenK);
        //            YforOddK[i+1] = Y[step][i+1] + k2[i] * h2;
        //        }
                
        //        // k3 = 
        //        YforOddK[0] = Y[step][0] + h2;
        //        for (int i = 0; i < p; i++)
        //        {
        //            k3[i] = F[i](YforOddK);
        //            YforEvenK[i+1] = Y[step][i+1] + k3[i] * h;
        //        }

        //        // k4 = 
        //        YforEvenK[0] = Y[step][0] + h;
        //        for (int i = 0; i < p; i++)
        //        {
        //            k4[i] = F[i](YforEvenK);
        //        }

        //        for (int i = 0; i < p; i++)
        //        {
        //            Y[step+1][i+1] = Y[step][i+1] + (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]) * h / 6.0;
        //        }
        //    }

        //    return Y;
        //}

        PointF[] arPts;
        List<MathGraphic> currGraphic, grsAS, grsAF, grsAGamma;
        Ball ball;

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
            grsAS = new List<MathGraphic>();
            grsAF = new List<MathGraphic>();
            grsAGamma = new List<MathGraphic>();

            sigma = 2;
            f = 2;
            mju = 0.4;

            h = 1e-3f;

            a1 = 0;
            a2 = 2.5f;

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

            List<PointF> pts = new List<PointF>();
            PointF[][] Y;
            if (radioAS.Checked)
            {
                grsAS.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    SigmaAPlus, a, a1, a2, h);
                grsAS.Add(m);
                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    SigmaAMinus, a, a1, a2, h);
                grsAS.Add(m);

                Y = MathGraphic.Tabulate(SigmaAPlus, a, a1, a2, h);
                for (int i = 0; i < Y.Length; i++)
                    pts.AddRange(Y[i]);

                Y = MathGraphic.Tabulate(SigmaAMinus, a, a1, a2, h);
                for (int i = 0; i < Y.Length; i++)
                    pts.AddRange(Y[i]);
            }
            if (radioAF.Checked)
            {
                grsAF.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    fA, a, a1, a2, h);
                grsAF.Add(m);

                Y = MathGraphic.Tabulate(fA, a, a1, a2, h);
                for (int i = 0; i < Y.Length; i++)
                    pts.AddRange(Y[i]);
            }
            
            arPts = pts.ToArray();
            Array.Sort<PointF>(arPts, (Comparison<PointF>)
                delegate(PointF A, PointF B)
                {
                    return Math.Sign(A.X - B.X);
                });

            ball = new Ball(-1, 1, 20/zoom);
            timer1.Start();
            
            pictureBox1.Refresh();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (radioAS.Checked) currGraphic = grsAS;
            if (radioAF.Checked) currGraphic = grsAF;

            if (currGraphic == null) return;

            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.Transform = new Matrix(zoom, 0, 0, -zoom, dx, dy);
            foreach (MathGraphic mg in currGraphic) mg.Draw(g, false);

            if (ball != null) ball.Paint(g);
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
            labelBallSpeed.Text = trackBar1.Value.ToString()+"%";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball == null) return;

            double[] vals = x2_from_x1(ball.X1);


            int min_i = 0; 
            double min_diff = Math.Abs(vals[0] - ball.X2);

            for (int i = 0; i < vals.Length; i++)
            {
                double diff = Math.Abs(vals[i] - ball.X2);
                if (diff < min_diff)
                {
                    min_i = i;
                    min_diff = diff;
                }
            }
            if (Math.Abs(min_diff / ball.X2) < 0.2)
            {
                ball.Shift(10f / zoom * (trackBar1.Value / 100f), 0);
                ball.X2 = (float)vals[min_i];
            }
            else            
            {
                ball.X2 += Math.Sign(vals[min_i] - ball.X2) * Math.Sign(trackBar1.Value) * 10f / zoom * (trackBar1.Value / 100f);
            }

            pictureBox1.Refresh();
        }

        private double[] x2_from_x1(float x1)
        {
            float eps = 1e-2f;
            int a = 0;
            int b = arPts.Length - 1;
            int i = arPts.Length / 2;
            // quicksearch
            while (Math.Abs(a - b) > 2)
            {
                if (x1 > arPts[i].X)
                    a = i;
                else b = i;
                i = (a + b) / 2;
            }
            a = b = i;
            for (; (Math.Abs(arPts[a].X - x1) < eps) && (a>0); a--) ;
            for (; (Math.Abs(arPts[b].X - x1) < eps) && (b<arPts.Length-1); b++) ;

            double[] X2 = new double[b - a + 1];
            for (int j = a; j <= b; j++) X2[j-a] = arPts[j].Y;

            Array.Sort(X2);

            return X2;
        }
    }

    public class Ball
    {
        protected float x1;
        protected float x2;
        public Color color = Color.Firebrick;
        protected float r;
        protected SolidBrush ballBrush;
        Bitmap m;

        public Ball(float n1, float n2, float Radius)
        {
            x1 = n1;
            x2 = n2;

            r = Radius;

            ballBrush = new SolidBrush(color);
            m = new Bitmap("1.png");
        }

        public void Paint(Graphics g)
        {
            Matrix matrix = g.Transform.Clone();
            float zoom = matrix.Elements[0];
            float dx = matrix.Elements[4];
            float dy = matrix.Elements[5]; 
            g.ResetTransform();
            g.TranslateTransform(x1 * zoom + dx - m.Width / 2, -x2 * zoom + dy - m.Height);

            g.RotateTransform(90);
            g.DrawImage(m, 0, 0);
            g.Transform = matrix;

            //g.FillEllipse(ballBrush,
            //    x1 - r, x2,
            //    2f * r, 2f * r);
        }

        public void Shift(float dx1, float dx2)
        {
            x1 += dx1; 
            x2 += dx2;
        }

        public float X1
        {
            get { return x1; }
            set { x1 = value; }
        }
        public float X2
        {
            get { return x2; }
            set { x2 = value; }
        }
    }
}
