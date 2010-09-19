using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KG1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float mx = 100, my = 100;
        float ox = 100, oy = 100;

        double l1(double x, double y)
        {
            return 0;
        }

        double l2(double x, double y)
        {
            return 0;
        }

        double l1l2(double x, double y)
        {
            return x * x + y * y - 1;
        }

        double l3(double x, double y)
        {
            return x-1;
        }

        double l4(double x, double y)
        {
            return y-1;
        }

        double lambda = 0.1;
        double eps = 1e-3;

        Vector r0, r1, r2, r3;

        Vector r(double u)
        {
            //return x * x + y * y - 1;
            return (1.0 - u) * (1.0 - u) * (1.0 - u) * r0
                + 3.0 * u * (1.0 - u) * (1.0 - u) * r1
                + 3.0 * u * u * (1.0 - u) * r2
                + u * u * u * r3;
        }

        double y1(double x, double l)
        {
            double f = 0.1e1 / (double)(-1 + l) * ((double)(l * x) - (double)l + Math.Sqrt((double)(-3 * l * l * x * x - 6 * l * l * x + 9 * l * l - 4 * x * x - 12 * l + 4 + 8 * l * x * x + 4 * l * x))) / 0.2e1;
            return f;

        }
        double y2(double x, double l)
        {
            double f = -(-(double)(l * x) + (double)l + Math.Sqrt((double)(-3 * l * l * x * x - 6 * l * l * x + 9 * l * l - 4 * x * x - 12 * l + 4 + 8 * l * x * x + 4 * l * x))) / (double)(-1 + l) / 0.2e1;

            return f;
        }

        double S(double x, double y) { return 0.0; }

        PointF[] tabulate(double x1, double x2, double y1, double y2, double nx, double ny)
        {
            List<PointF> pts = new List<PointF>();

            double hx = (x2 - x1) / nx;
            double hy = (y2 - y1) / ny;

            for (double x = x1; x <= x2; x += hx)
                for (double y = y1; y <= y2; y += hy)
                {
                    if (Math.Abs(S(x, y)) < eps) pts.Add(new PointF((float)x, (float)y));
                }

            return pts.ToArray();
        }


        List<PointF> pts;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out lambda))
            {
                MessageBox.Show("Wrong number format in lambda!");
                return;
            }
           // pts = tabulate(-2, 2, -2, 2, 2000, 2000);

            //status1.Text = pts.Length.ToString();

            pictureBox1.Refresh();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pts == null) return;
            if (pts.Count < 2) return;

            Graphics g = e.Graphics;
            
            g.Transform = new System.Drawing.Drawing2D.Matrix(mx, 0, 0, -my, ox, oy);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.Clear(Color.White);

            List<PointF>.Enumerator l = pts.GetEnumerator();
            l.MoveNext();
            r0 = new Vector(l.Current);
            while(l.MoveNext())
            {
                r0 = r3;
                r3 = new Vector(l.Current);

                r1 = (r0 + r3) * 0.3;
                r2 = (r0 + r3) * 0.6;

                for (float u = 0; u <= 1; u += 1e-3f)
                {
                    PointF p = r(u).ToPoint();
                    g.FillEllipse(Brushes.Black, p.X, p.Y, 2f / mx, 2f / my);
                }
            }

            Pen pen = new Pen(Color.Black, 0f);
            
            foreach(PointF p in pts)
            {
                g.DrawLines(pen, pts.ToArray());//(Brushes.Black, p.X, p.Y, 2f / mx, 2f / my);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = lambda.ToString("F3");
            ox = pictureBox1.Width / 2;
            oy = pictureBox1.Height / 2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out lambda))
            {
                button1_Click(sender, e);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ox = pictureBox1.Width / 2;
            oy = pictureBox1.Height / 2;

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pts == null) pts = new List<PointF>();

            pts.Add(new PointF((e.X -ox) / mx, -(e.Y-oy) / my));

            pictureBox1.Refresh();
        }
    }
}
