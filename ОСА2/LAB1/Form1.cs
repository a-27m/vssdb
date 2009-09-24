using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComplexNumbers;
using DekartGraphic;
using System.Collections.Generic;


namespace lab1
{
    public partial class Form1 : Form
    {
        float zoom = 100;
        float dx, dy;
        List<MathGraphic> grs;

        Complex A1, A2, k1, k2;
        double x0, v0;

        Complex exp(Complex z)
        {
            return new Complex(
                Math.Exp(z.re) * Math.Cos(z.im),
                Math.Exp(z.re) * Math.Sin(z.im));
        }

        double fx(double t)
        {
            Complex _t = new Complex(t);
            return (A1 * exp(k1 * _t) + A2 * exp(k2 * _t)).re;
        }

        double fv(double t)
        {
            Complex _t = new Complex(t);
            return (A1 * k1 * exp(k1 * _t) + A2 * k2 * exp(k2 * _t)).re;
        }

        public Form1()
        {
            InitializeComponent();
            v0 = 1;
            x0 = 1;
            //k1 = new Complex(0, 1);
            //k2 = new Complex(0, -1);
            k1 = new Complex(1, 0);
            k2 = new Complex(-1, 0);

            textBoxk1r.Text = k1.re.ToString();
            textBoxk1i.Text = k1.im.ToString();
            textBoxk2r.Text = k2.re.ToString();
            textBoxk2i.Text = k2.im.ToString();

            grs = new List<MathGraphic>();

            ssLabel1.Text = "";
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            grs.Clear();

            try
            {
                k1.re = double.Parse(textBoxk1r.Text);
                k1.im = double.Parse(textBoxk1i.Text);
                k2.re = double.Parse(textBoxk2r.Text);
                k2.im = double.Parse(textBoxk2i.Text);
            }
            catch (FormatException)
            {
                textBoxk1r.Text = k1.re.ToString();
                textBoxk1i.Text = k1.im.ToString();
                textBoxk2r.Text = k2.re.ToString();
                textBoxk2i.Text = k2.im.ToString();

                MessageBox.Show("Wrong number format", "Parameters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("Accepted", "Parameters", MessageBoxButtons.OK, MessageBoxIcon.Information);

            pictureBox1.Refresh();
        }

        private void AddGraphic(double _x0, double _v0)
        {
            float T = 4f;
            float n = 4;
            MathGraphic m;

            Complex X0 = new Complex(_x0);
            Complex V0 = new Complex(_v0);
            A1 = (V0 - k2 * X0) / (k1 - k2);
            A2 = (V0 - k1 * X0) / (k2 - k1);

            m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                fx, fv, -T, T, 1e-2f);
            grs.Add(m);

            PointF[] ar;
            float dt = 15f / zoom;

            for (int i = 0; i <= n; i++)
            {
                ar = new PointF[3];

                double t = i * 2f * T / n - 2f * T;

                float x1 = (float)fx(t);
                float y1 = (float)fv(t);

                float x2 = (float)fx(t + dt);
                float y2 = (float)fv(t + dt);

                float xs = x2 - x1;
                float ys = y2 - y1;

                float ds = (float)Math.Sqrt(xs * xs + ys * ys);

                //xs *= dt / ds;
                //ys *= dt / ds;
                xs = xs / ds * dt;
                ys = ys / ds * dt;

                float xn = ys / 3f;
                float yn = -xs / 3f;

                ar[0] = new PointF(x1 + xn, y1 + yn);
                ar[1] = new PointF(x1 + xs, y1 + ys); 
                ar[2] = new PointF(x1 - xn, y1 - yn); 
                
                m = new MathGraphic(ar);
                m.DrawingMode = DrawModes.DrawLines;
                m.PenColor = Color.Green;
                m.PenWidth = 0f;

                grs.Add(m);
            }
           
        }

        void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            x0 = (e.X - dx) / zoom;
            v0 = (e.Y - dy) / -zoom;

            AddGraphic(x0, v0);

            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            dx = pictureBox1.Width / 2f;
            dy = pictureBox1.Height / 2f;
            g.Transform = new Matrix(zoom, 0, 0, -zoom, dx, dy);
            foreach (MathGraphic m in grs) m.Draw(g, false);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            x0 = (e.X - dx) / zoom;
            v0 = (e.Y - dy) / -zoom;

            ssLabel1.Text = x0.ToString("F3") + "; " + v0.ToString("F3");
        }
    }
}
