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
            return Math.Sin(x)*Math.Cos(y);
            //return -Math.Sqrt(x * x + y * y) + 4;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g3d = new Graphic3D(fxy, -5f, 5f, -5f, 5f, 0.2f);
            g3d.alphaX = 180 + 30+45;
            g3d.alphaY = -30+45;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (g3d != null)
                g3d.Draw(e.Graphics);
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
                g3d.zoom -= 10;
            }
            if (e.Button == MouseButtons.Left)
            {
                g3d.zoom += 10;
            }
            if (e.Button == MouseButtons.Middle)
            {
                g3d.alphaX += 10;
                g3d.alphaY += 10;
            }
            Refresh();
        }
    }
}