using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace KG4
{
    public partial class Form1 : Form
    {
        PointF[] pts;
        PointF[] velocity;
        int[] convex, hamilton;
        Random rnd;
        Font font;
        Pen penConvex, penHamilton;
        
        double maxR2 = 1e20;

        public Form1()
        {
            InitializeComponent();
            rnd = new Random();

            W = pictureBox1.Width;
            H = pictureBox1.Height;

            font = new Font("Arial", 10f);
            penConvex = new Pen(Color.DarkGray, 2f);
            penHamilton = new Pen(Color.Green, 0.2f);

            //panel1.Visible = false;

            buttonGenerate_Click(null, null);
            buttonStart_Click(null, null);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (convex != null && checkBoxConvexHull.Checked)
            {
                PointF prev = pts[convex[0]];
                for (int i = 0; i < convex.Length && convex[i] != -1; i++)
                {
                    g.DrawLine(penConvex, prev, pts[convex[i]]);
                    prev = pts[convex[i]];
                }
                g.DrawLine(penConvex, prev, pts[convex[0]]);
            }
            
            if (hamilton != null && checkBoxHamilton.Checked)
            {
                PointF prev = pts[hamilton[0]];
                for (int i = 0; i < hamilton.Length && hamilton[i] != -1; i++)
                {
                    g.DrawLine(penHamilton, prev, pts[hamilton[i]]);
                    prev = pts[hamilton[i]];
                }
                g.DrawLine(penHamilton, prev, pts[hamilton[0]]);
            }

            float r = 2;
            if (pts != null)
            {
                int i = 0;
                foreach (PointF p in pts)
                {
                    //r = (p.X - pictureBox1.Width / 2) * (p.X - pictureBox1.Width / 2) + (p.Y - pictureBox1.Height / 2) * (p.Y - pictureBox1.Height / 2);
                    //r = (int)Math.Sqrt(r / maxR2 * 100) + r_min;
                    r =  Math.Abs(velocity[i].X) + Math.Abs(velocity[i].Y);
                    r /= 2;
                    i++;                    
                    g.FillRectangle(Brushes.White, p.X - r, p.Y - r, 2 * r, 2 * r);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pts == null) return;

            MoveAll();
            if (checkBoxConvexHull.Checked || checkBoxHamilton.Checked) MakeConvex();
            if (checkBoxHamilton.Checked) ConvexToGamilton();
            pictureBox1.Refresh();
        }

        private void ConvexToGamilton()
        {
            hamilton = (int[])convex.Clone();

            // determine inner points
            List<int> inside = new List<int>();
            for (int i = 0; i < pts.Length; i++) inside.Add(i);
            for (int i = 0; i < convex.Length && convex[i] != -1; i++) inside.Remove(convex[i]);

            while (inside.Count > 0)
            {
                // choose one. strategy is to pick the farthest rel to convex nodes.
                float maxDistance = float.MinValue;
                int farthestInside = -1;
                int nearestHamiltonNode = -1;
                int farthestInsideFutureHamiltonInsertIndex = -1;

                foreach (int i in inside)
                {
                    float minDistance = float.MaxValue;
                    nearestHamiltonNode = -1;

                    // current inside point translates to (0,0)
                    // others respective to their relational position
                    PointF[] pTr = (PointF[])pts.Clone();
                    for (int k = 0; k < pts.Length; k++)
                    {
                        pTr[k].X = pTr[k].X - pts[i].X;
                        pTr[k].Y = pTr[k].Y - pts[i].Y;
                    }

                    // max distance lookup
                    for (int H = 0; H < hamilton.Length - 1 && hamilton[H + 1] != -1; H++)
                    {
                        float distance = -1;
                        int p = hamilton[H];
                        int q = hamilton[H + 1];
                        // A
                        float x1 = pTr[p].X;
                        float y1 = pTr[p].Y;
                        // B
                        float x2 = pTr[q].X;
                        float y2 = pTr[q].Y;

                        // OH = 2*S / o
                        double o2 = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
                        double ho = Math.Abs(2.0 * (x1 * y2 - x2 * y1) / o2);


                        //PointF AB = pTr[q];
                        //AB.X = AB.X - x1; // == B-A
                        //AB.Y = AB.Y - y1;

                        double AH = -(x1 * (x2 - x1) + y1 * (y2 - y1));

                        if (AH > o2 || AH < 0)
                            distance = float.MaxValue;
                        else
                            distance = (float)ho;

                        if (distance <= minDistance)
                        {
                            minDistance = distance;
                            nearestHamiltonNode = H;
                        }
                    }

                    if (minDistance > maxDistance)
                    {
                        maxDistance = minDistance;
                        farthestInside = i;
                        farthestInsideFutureHamiltonInsertIndex = nearestHamiltonNode;
                    }
                }
                if (farthestInsideFutureHamiltonInsertIndex < 0)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Cannot insert any of inside points");
                    return;
                }

                //   i n s e r t 
                //  farthestInside after hamilton[farthestInsideFutureHamiltonInsertIndex]
                for(int i = hamilton.Length-1; i>farthestInsideFutureHamiltonInsertIndex ; i--)
                    hamilton[i] = hamilton[i-1];

                hamilton[farthestInsideFutureHamiltonInsertIndex + 1] = farthestInside;

                inside.Remove(farthestInside);
            }
        }

        private void MakeConvex()
        {
            if (convex == null) convex = new int[pts.Length];

            // find min y
            int minIndex = 0;
            float minVal = pts[minIndex].Y;
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
            int convI = 1;
            int magic = 1;
            do
            {
                minIndex = -1;

                double maxCos = -1.1;
                for (int i = 0; i < pts.Length; i++)
                {
                    PointF p = pts[i];
                    p.X = p.X - pts[convex[convI - 1]].X;
                    p.Y = p.Y - pts[convex[convI - 1]].Y;

                    double cos;
                    if (magic * p.Y >= 0)
                    {
                        cos = p.X / Math.Sqrt(p.X * p.X + p.Y * p.Y);

                        if (magic * cos > maxCos && p.Y * magic > 0)
                        {
                            maxCos = magic * cos;
                            minIndex = i;
                        }
                    }
                }

                if (minIndex == -1) 
                {
                    if (magic == 1) { magic = -1; continue; }
                    else break;
                }

                convex[convI++] = minIndex;

                if (convI >= pts.Length) break;
            }
            while (pts[convex[convI - 1]] != pts[convex[0]]);

            for(int i = convI; i < pts.Length; i++) convex[i] = -1;
        }

        private void MoveAll()
        {
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].X = pts[i].X + velocity[i].X;
                pts[i].Y = pts[i].Y + velocity[i].Y;

                if (pts[i].X < 0 || pts[i].X > W ||
                    pts[i].Y < 0 || pts[i].Y > H)
                //if (Math.Abs(pts[i].X - W/2) < 20 ||
                //    Math.Abs(pts[i].Y - H/2) < 20)
                {
                    GeneratePoint(ref pts[i], ref velocity[i]);
                }
                else
                    UpdateVelocity(ref velocity[i], pts[i]);
            }
        }

        private void Generate(int count, int maxX, int maxY)
        {
            pts = new PointF[count];
            velocity = new PointF[count];
            convex = new int[count];

            for (int i = 0; i < count; i++)
            {
                GeneratePoint(ref pts[i], ref velocity[i]);
            }
        }

        private void GeneratePoint(ref PointF p, ref PointF velocity)
        {
            p.X = rnd.Next(W);
            p.Y = rnd.Next(H);

            UpdateVelocity(ref velocity, p);

            return;
        }

        private void UpdateVelocity(ref PointF velocity, PointF p, float k_vel = 0.01f)
        {
            p.X = p.X - W / 2;
            p.Y = p.Y - H / 2;

            float r = (float)radius(p);
            float vx = p.X / r * Math.Abs(r);
            float vy = p.Y / r * Math.Abs(r);
            velocity.X = vx * k_vel;
            velocity.Y = vy * k_vel;
        }

        private double radius(PointF point)
        {
            return Math.Sqrt(point.X * point.X + point.Y * point.Y);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        int W, H;
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            maxR2 = Math.Pow(Math.Min(pictureBox1.Width / 2, pictureBox1.Height / 2), 2);
            
            W = pictureBox1.Width;
            H = pictureBox1.Height;
            
            Refresh();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Generate((int)numericUpDown1.Value, pictureBox1.Width, pictureBox1.Height);
            if (checkBoxConvexHull.Checked) MakeConvex();
            if (checkBoxHamilton.Checked) ConvexToGamilton();
            pictureBox1.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            /*
            bool play = timer1.Enabled;
            timer1.Enabled = false;

            Generate(200, pictureBox1.Width, pictureBox1.Height);
            if (checkBoxConvexHull.Checked) MakeConvex();
            if (checkBoxHamilton.Checked) ConvexToGamilton();
            pictureBox1.Refresh();


            timer1.Enabled = play;
             */
        }
    }
}
