using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DekartGraphic;
using System.Drawing.Drawing2D;

namespace lab2__fluctuations_
{
    public partial class Form1 : Form
    {
        List<MathGraphic> currGraphic, grsXt, grsVt, grsVx;

        float zoom = 100;
        float dx, dy;

        double x0, v0, k, w, n, P;
        double A, B1, B2, delta, w1;
        float T0, Tmax;

        double fx(double t)
        {
            return Math.Exp(-n * t) * (B1 * Math.Cos(w1 * t) + B2 * Math.Sin(w1 * t)) +
                A * Math.Cos(k * t - delta);
        }

        double fv(double t)
        {
            return Math.Exp(-n * t) *
                ((B2 * w1 - B1 * n) * Math.Cos(w1 * t) + ((B2 * n - B1 * w)) * Math.Sin(w1 * t)) -
                A * k * Math.Sin(k * t - delta);
        }

        void Compute()
        {
            w1 = Math.Sqrt(w * w - n * n);
            A = P / Math.Sqrt(w1 * w1 * w1 * w1 + 4 * n * n * k * k);
            delta = Math.Atan(2 * n * k / (w1 * w1));
            B1 = x0 - A * Math.Cos(delta);
            B2 = (v0 + B1 * n - A * k * Math.Sin(delta)) / w1;
        }

        public Form1()
        {
            InitializeComponent();
            grsXt = new List<MathGraphic>();
            grsVt = new List<MathGraphic>();
            grsVx = new List<MathGraphic>();
            x0 = 1;
            v0 = 3;
            k = 1.8;
            w = 2.1;
            n = 0.0025;
            P = 20;
            T0 = 0;
            Tmax = 300;
            dx = pictureBox1.Width / 3f;
            dy = pictureBox1.Height / 2f;

            textBoxX0.Text = x0.ToString();
            textBoxV0.Text = v0.ToString();
            textBoxK.Text = k.ToString();
            textBoxW.Text = w.ToString();
            textBoxN.Text = n.ToString();
            textBoxP.Text = P.ToString();
            textBoxT0.Text = T0.ToString();
            textBoxT1.Text = Tmax.ToString();
        }

        private void buttonGO_Click(object sender, EventArgs e)
        {
            MathGraphic m;
            
            try
            {
                x0 = double.Parse(textBoxX0.Text);
                v0 = double.Parse(textBoxV0.Text);
                k = double.Parse(textBoxK.Text);
                w = double.Parse(textBoxW.Text);
                n = double.Parse(textBoxN.Text);
                P = double.Parse(textBoxP.Text);
                T0 = float.Parse(textBoxT0.Text);
                Tmax = float.Parse(textBoxT1.Text);
            }
            catch (FormatException) {
                MessageBox.Show("Wrong number format");

                textBoxX0.Text = x0.ToString();
                textBoxV0.Text = v0.ToString();
                textBoxK.Text = k.ToString();
                textBoxW.Text = w.ToString();
                textBoxN.Text = n.ToString();
                textBoxP.Text = P.ToString();
                textBoxT0.Text = T0.ToString();
                textBoxT1.Text = Tmax.ToString();

                return;
            }

            Compute();
            if (radioXT.Checked)
            {
                grsXt.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    fx, T0, Tmax, 1e-2f);
                grsXt.Add(m);
            }
            if (radioVT.Checked)
            {
                grsVt.Clear();

                m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                    fv, T0, Tmax, 1e-2f);
                grsVt.Add(m);
            }
            if (radioVX.Checked)
            {
                AddGraphicVX();
            }

            pictureBox1.Refresh();
        }

        private void AddGraphicVX()
        {
            MathGraphic m;
            grsVx.Clear();

            m = new MathGraphic(Color.Green, DrawModes.DrawLines,
                fx, fv, T0, Tmax, 1e-2f);

            grsVx.Add(m);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (radioXT.Checked) currGraphic = grsXt;
            if (radioVT.Checked) currGraphic = grsVt;
            if (radioVX.Checked) currGraphic = grsVx;

            if (currGraphic == null) return;

            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.Transform = new Matrix(zoom, 0, 0, -zoom, dx, dy);
            foreach (MathGraphic mg in currGraphic) mg.Draw(g, false);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) return;

            if (!radioVX.Checked) return;

            x0 = (e.X - dx) / zoom;
            v0 = (e.Y - dy) / -zoom;

            textBoxX0.Text = x0.ToString("F3");
            textBoxV0.Text = v0.ToString("F3");

            Compute();
            AddGraphicVX();

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
