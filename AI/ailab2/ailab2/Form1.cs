using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using pre3d;

namespace ailab2
{
    public partial class Form1 : Form
    {
        Graphic3D g3d;
        double a, b, c, h;
        public double gorka(double x, double y)
        {
            if (y >= 0)
                return (1 - x / a - y / c) * h;
            else
                return (1 - x / a - y / b) * h;
        }

        public Form1()
        {
            InitializeComponent();

            h = 4;
            a = 5;
            b = -3;
            c = 2;
            g3d = new Graphic3D(gorka, 0f, 10f, -10f, 10f, 5e-1f);
            g3d.phiV = -45f;
            g3d.phiH = -45f;
            g3d.zoom = 10;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (g3d != null)
                g3d.Draw(e.Graphics);
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
                    g3d.phiV += (e.Y - mouse_y0) / (float)(pictureBox1.Height) * 45;
                    mouse_x0 = e.X;
                    mouse_y0 = e.Y;
                }
                Refresh();
            }
        }
    }
}
