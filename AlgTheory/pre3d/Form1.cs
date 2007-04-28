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
            return -Math.Sqrt(x * x + y * y) + 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g3d = new Graphic3D(fxy, -2f, 2f, -2f, 2f, 0.2f);
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (g3d != null)
                g3d.Draw(e.Graphics);
        }
    }
}