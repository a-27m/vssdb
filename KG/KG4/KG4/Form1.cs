using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KG4
{
    public partial class Form1 : Form
    {
        Point[] pts;
        Point[] velocity;
        int[] convex;
        Random rnd;

        public Form1()
        {
            InitializeComponent();
            pts = new Point[1];
            rnd = new Random();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (Point p in pts)
                e.Graphics.FillEllipse(Brushes.White, p.X, p.Y, 5f, 5f);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveAll();
            MakeConvex();
            pictureBox1.Refresh();
        }

        private void MakeConvex()
        {
            // find min y
            int minIndex = 0;
            int minVal = pts[minIndex].Y;
            for (int i = 0; i < pts.Length; i++)
            {
                if (pts[i].Y < minVal)
                {
                    minIndex = i;
                    minVal = pts[i].Y;
                }
            }

            // chain
            convex[0] = minIndex;
            int convI = 0;
            while (0==1)
            {
                double minCos = double.MaxValue;
                minIndex = -1;
                for (int i = 0; i < pts.Length; i++)
                {
                    //Math.Cos(pts[i].Y)
                }
            }
        }

        private void MoveAll()
        {
            //int maxVel = 3;

            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].Offset(velocity[i]);
            }

            for (int i = 0; i < pts.Length; i++)
            {
                Point t= pts[i];
                t.Offset(-(pictureBox1.Width / 2), -(pictureBox1.Height / 2));
                //if (pts[i].X * pts[i].X + pts[i].Y * pts[i].Y > 200*200)
                if (t.X * t.X + t.Y * t.Y > 200 * 200)
                {
                    //float tgA = pts[i].Y / pts[i].X;
                    //velocity[i].X = -velocity[i].Y;
                    //velocity[i].Y = -velocity[i].X;
                    //pts[i].Offset(-velocity[i].X, -velocity[i].Y);
                    //do { velocity[i].X = rnd.Next(2 * maxVel+1) - maxVel; } while (velocity[i].X == 0);
                    //do { velocity[i].Y = rnd.Next(2 * maxVel+1) - maxVel; } while (velocity[i].Y == 0);
                    //pts[i].Offset(velocity[i].X, velocity[i].Y);

                    //velocity[i].X = -velocity[i].Y;
                    //velocity[i].Y = -velocity[i].X;

                    //pts[i].X = rnd.Next(pictureBox1.Width);
                    //pts[i].Y = rnd.Next(pictureBox1.Height);

                    pts[i].X = (pictureBox1.Width) / 2;
                    pts[i].Y = (pictureBox1.Height) / 2;

                }
//                pts[i].Offset(pictureBox1.Width / 2, pictureBox1.Height / 2);
            }
        }

        private void Generate(int count, int maxX, int maxY, int maxVel)
        {
            if (maxVel == 0) throw new ArgumentException("maxVel");

            pts = new Point[count];
            velocity = new Point[count];

            for (int i = 0; i < count; i++)
            {
                pts[i].X = rnd.Next(maxX);
                pts[i].Y = rnd.Next(maxY);

                do { velocity[i].X = rnd.Next(2 * maxVel+1) - maxVel;// } while (velocity[i].X == 0);
                //do {
                    velocity[i].Y = rnd.Next(2 * maxVel+1) - maxVel; } while ((velocity[i].X | velocity[i].Y) == 0);
            }                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generate(20, pictureBox1.Width - 5, pictureBox1.Height - 5, 3);

            timer1.Enabled = !timer1.Enabled;
        }
    }
}
