using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cglr1
{
    public partial class Form1 : Form
    {
        List<Point> pts;
        Random rnd;

        public Form1()
        {
            InitializeComponent();
            pts = new List<Point>();
            rnd = new Random(DateTime.Now.Millisecond);
        }

        float cellSize = 2f;
        Brush pixelBrush = Brushes.Black;

        private void Plot(Graphics g, int x, int y)
        {
            g.FillRectangle(pixelBrush, x * cellSize + 1, y * cellSize + 1, cellSize, cellSize);
        }

        private void Plot(Graphics g, int x, int y, Color c)
        {
            (pixelBrush as SolidBrush).Color = c;
            g.FillRectangle(pixelBrush, x * cellSize + 1, y * cellSize + 1, cellSize, cellSize);
        }

        Color ptc(float p)
        {
            int val = (int)(255f * p);
            if (val < 0) return Color.Red;
            if (val > 255) return Color.Blue;
            return Color.FromArgb(val, val, val);
        }

        private void Line(Graphics g, int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                Plot(g, x1, y1);
                return;
            }

            int x, y;
            x = x1;
            y = y1;
            int Δx, Δy;
            Δx = x2 - x1;
            Δy = y2 - y1;
            float ΔyΔx = (float)Δy / (float)Δx;
            float e;

            int dx = Math.Sign(Δx);
            int dy = Math.Sign(Δy);

            if (x1 == x2)
            {
                for (int i = y1; i <= y2; i += dy)
                    Plot(g, x1, i);
                return;
            }

            if (y1 == y2)
            {
                for (int i = x1; i < x2; i += dx)
                    Plot(g, i, y1);
                return;
            }


            if (ΔyΔx > 0)
            {
                e = ΔyΔx - 0.5f;
                //float e2 = e / 2f;

                for (int i = 0; i < Math.Abs(Δx); i++)
                {
                    this.Plot(g, x, y);//, ptc(Math.Abs(e - e2)/e2));
                   // e2 = e / 2f;

                    while (e >= 0)
                    {
                        y = y + dy;
                        this.Plot(g, x, y);//, ptc(Math.Abs(e - e2) / e2));
                        e = e - 1f;
                    }
                    x = x + dx;
                    e = e + ΔyΔx;
                }
            }
            else
            {
                e = -1f/ΔyΔx - 0.5f;

                for (int i = 0; i < Math.Abs(Δy); i++)
                {
                    this.Plot(g, x, y);
                    while (e >= 0)
                    {
                        x = x + dx;
                        e = e - 1f;
                        this.Plot(g, x, y);
                    }
                    y = y + dy;
                    e = e - 1f/ΔyΔx;
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBox1.CreateGraphics().Clear(Color.White);
            pts.Clear();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pts == null) return;
            if (pts.Count < 2) return;

            Point prev = pts[0];
            foreach (Point p in pts)
            {
                this.Line(e.Graphics, prev.X, prev.Y, p.X, p.Y);
                prev = p;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pts.Add(new Point(
                (int)(e.X / cellSize),
                (int)(e.Y / cellSize)
                ));
            pictureBox1.Refresh();
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            //buttonClear_Click(sender, e);

            timer.Enabled = !timer.Enabled;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //pts.Clear();

            pts.Add(new Point(
                rnd.Next((int)(pictureBox1.Width/cellSize)),
                rnd.Next((int)(pictureBox1.Height/cellSize))));
            pts.Add(new Point(
                rnd.Next((int)(pictureBox1.Width / cellSize)),
                rnd.Next((int)(pictureBox1.Height / cellSize))));

            pictureBox1.Refresh();
        }
    }
}
