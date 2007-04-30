using System;
using System.Drawing;
using System.Windows.Forms;

namespace pre3d
{
    public partial class Form1 : Form
    {
        Graphic3D g3d = null;

        public Form1()
        {
            InitializeComponent();
        }

        double fxy(double x, double y)
        {
            //return 0;
            //return x * y / 2f;
            //return Math.Sin(x) * Math.Cos(y);
           // return -Math.Sqrt(x * x + y * y) + 4;
            return x * x * Math.Cos(y);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g3d = new Graphic3D(fxy, -2f, 2f, -2f, 2f, 0.2f);
            g3d.phiV = -45f;
            g3d.phiH = -45f;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (g3d != null)
            {
                g3d.Draw(e.Graphics);
                Text = string.Format("h: {0:f2} deg., v: {1:f2}", g3d.phiH, g3d.phiV);
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            if (g3d != null)
            {
                g3d.ox = pictureBox1.Size.Width / 2f;
                g3d.oy = pictureBox1.Size.Height / 2f;
                Refresh();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (g3d == null)
                return;
            if (e.Button == MouseButtons.Right)
            {
                g3d.zoom *= 0.8f;
            }

            Refresh();
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (g3d == null)
                return;

            //if (ctrlKeyPressed)
            //{
            //    g3d.alphaZ += e.Delta / 12;
            //}
            //else
            //{
            //    g3d.alphaX += e.Delta / 12;
            //    g3d.alphaY += e.Delta / 12;
            //}

            if (ctrlKeyPressed)
            {
                g3d.phiV += e.Delta / 12;
            }
            else
            {
                g3d.phiH += e.Delta / 12;
            }

            Refresh();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        bool ctrlKeyPressed = false;

        private void pictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            ctrlKeyPressed = e.Control;
        }
        private void pictureBox1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrlKeyPressed = e.Control;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (g3d == null)
                return;
            g3d.mz += ctrlKeyPressed ? -0.1f : 0.1f;
            Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        int mouse_x0, mouse_y0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse_x0 = e.X;
                mouse_y0 = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (g3d == null)
                return;
            if (e.Button == MouseButtons.Left)
            {
                int deltaX = e.X - mouse_x0;
                int deltaY = e.Y - mouse_y0;
                if ((deltaX == 0) && (deltaY == 0))
                {
                    // zoom
                    g3d.zoom /= 0.8f;
                }
                else
                {
                    // rotate
                    g3d.phiH += (mouse_x0 - e.X) / (float)(pictureBox1.Width) * 45;
                    g3d.phiV += (e.Y - mouse_y0) / (float)(pictureBox1.Height) *45;
                    mouse_x0 = e.X;
                    mouse_y0 = e.Y;
                }
                Refresh();
            }
        }
    }
}