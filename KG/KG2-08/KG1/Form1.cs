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

        double lambda = 0.30;
        double mju = 0.6;
        float eps = 1e-3f;

        Vector r0, r1, r2, r3;
        Vector r(double u)
        {
            //return x * x + y * y - 1;
            return (1.0 - u) * (1.0 - u) * (1.0 - u) * r0
                + 3.0 * u * (1.0 - u) * (1.0 - u) * r1
                + 3.0 * u * u * (1.0 - u) * r2
                + u * u * u * r3;
        }

        class Segment
        {
            public static Vector r0_global;

            public Vector r1, r2;
            public Vector r3;

            Segment prev;
            public Segment Previous
            {
                get { return prev; }
                set { prev = value; }
            }

            public Vector r0
            {
                get { return prev == null ?  r0_global : prev.r3; }
            }
        }

        List<Segment> sgs;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBoxLambda.Text, out lambda))
            {
                MessageBox.Show("Wrong number format in lambda!");
                return;
            }
           // pts = tabulate(-2, 2, -2, 2, 2000, 2000);

            //status1.Text = pts.Length.ToString();
            if (sgs == null) return;
            if (sgs.Count < 1) return;

            firstSegment = true;
            foreach (Segment s in sgs)
            {
                if (firstSegment)
                {
                    s.r1 = (s.r0 + s.r3) * 0.5;
                    s.r2 = (s.r0 + s.r3) * 0.5;
                    firstSegment = false;
                }
                else
                {
                    s.r1 = lambda * (s.r0 - s.Previous.r2) + s.r0;
                    s.r2 = (lambda * lambda) * (s.r0 - 2 * s.Previous.r2 + s.Previous.r1)
                        + mju / 3.0 * (s.r0 - s.Previous.r2) + 2 * s.r1 - s.r0;
                }
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (sgs == null) return;
            if (sgs.Count < 1) return;

            Graphics g = e.Graphics;
            
            g.Transform = new System.Drawing.Drawing2D.Matrix(mx, 0, 0, -my, ox, oy);
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.Clear(Color.White);

            List<Segment>.Enumerator l = sgs.GetEnumerator();
            while(l.MoveNext())
            {
                r0 = l.Current.r0;
                r1 = l.Current.r1;
                r2 = l.Current.r2;
                r3 = l.Current.r3;

                for (float u = 0; u <= 1; u += eps)
                {
                    PointF p = r(u).ToPointF();
                    g.FillEllipse(Brushes.Black, p.X, p.Y, 2f / mx, 2f / my);
                }
            }

            Pen pen = new Pen(Color.Green, 0f);
            
            foreach(Segment s in sgs)
            {
                pen.Color = Color.Green;
                g.DrawLine(pen, s.r3.ToPointF(), s.r2.ToPointF());
                pen.Color = Color.Blue;
                g.DrawLine(pen, s.r2.ToPointF(), s.r1.ToPointF());
                pen.Color = Color.Red;
                g.DrawLine(pen, s.r1.ToPointF(), s.r0.ToPointF());

                g.FillEllipse(Brushes.Gray, s.r3.ToPointF().X-4f/mx, s.r3.ToPointF().Y-4f/my, 8f / mx, 8f / my);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxLambda.Text = lambda.ToString("F3");
            textBoxMju.Text = mju.ToString("F3");

            ox = pictureBox1.Width / 2;
            oy = pictureBox1.Height / 2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxLambda.Text, out lambda))
            {
                if (lambda > 3) lambda = 0;
                else
                    if (lambda < 0) lambda = 0;
                button1_Click(sender, e);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxMju.Text, out mju))
            {
                if (mju > 3) mju = 0;
                else
                    if (mju < 0) mju = 0;
                button1_Click(sender, e);
            }
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            ox = pictureBox1.Width / 2;
            oy = pictureBox1.Height / 2;

            pictureBox1.Refresh();
        }

        Segment last;
        bool firstSegment = true;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (sgs == null)
            { 
                sgs = new List<Segment>();
                Segment.r0_global = new Vector((e.X - ox) / mx, -(e.Y - oy) / my);
                return;
            }

            // check if it's node
            // ...

            Segment prev = last;
            last = new Segment();
            last.r3 = new Vector((e.X - ox) / mx, -(e.Y - oy) / my);
            last.Previous = prev; 
            
            if (firstSegment)
            {
                last.r1 = (last.r0 + last.r3) * 0.5;
                last.r2 = (last.r0 + last.r3) * 0.5;
                firstSegment = false;
            }
            else
            {
                last.r1 = lambda * (last.r0 - last.Previous.r2) + last.r0;
                last.r2 = (lambda * lambda) * (last.r0 - 2 * last.Previous.r2 + last.Previous.r1) + mju / 3.0 * (last.r0 - last.Previous.r2) + 2 * last.r1 - last.r0;
            }

            sgs.Add(last);

            pictureBox1.Refresh();
        }
    }
}
