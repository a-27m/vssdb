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
        int[] convex, hamilton;
        Random rnd;

        public Form1()
        {
            InitializeComponent();
            pts = new Point[1];
            rnd = new Random(); 
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (Point p in pts)
                e.Graphics.FillEllipse(Brushes.White, p.X, p.Y, 5f, 5f);

            if (convex != null)
            {
                Point prev = pts[convex[0]];
                for (int i = 0; i < convex.Length && convex[i]!=-1; i++)
                {
                    g.DrawLine(Pens.White, prev, pts[convex[i]]);
                    prev = pts[convex[i]];
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveAll();
            MakeConvex();
            ConvexToGamilton();
            pictureBox1.Refresh();
        }

        private void ConvexToGamilton()
        {
            // if (gamilton == null) gamilton = new int[pts.Length];

            hamilton = (int[])convex.Clone();

            // determine inner points
            List<int> inside = new List<int>();
            for (int i = 0; i < pts.Length; i++) inside.Add(i);
            for (int i = 0; i < convex.Length && convex[i] != -1; i++) inside.RemoveAt(convex[i]);

            while (inside.Count > 0)
            {
                // choose one. strategy is to pick the farthest rel to convex nodes.
                float maxDistance = float.MinValue;
                int farthestInside = -1;
                int nearestHamiltonNode = -1;
                int farthestInsideFutureHamiltonInsertIndex = -1;

                //int far = 0; //int i = 0;
                foreach (int i in inside)
                {
                    float minDistance = float.MaxValue;
                    nearestHamiltonNode = -1;

                    // current inside point translates to (0,0)
                    // others respective to their relational position
                    Point[] pTr = (Point[])pts.Clone();
                    for (int k = 0; k < pts.Length; k++)
                        pTr[k].Offset(-pts[i].X, -pts[i].Y);

                    // max distance lookup
                    for (int h = 0; h < hamilton.Length - 1 && hamilton[h + 1] != -1; h++)
                    {
                        float distance;
                        int p = hamilton[h];
                        int q = hamilton[h + 1];
                        int x1 = pTr[p].X;
                        int y1 = pTr[p].Y;
                        int x2 = pTr[q].X;
                        int y2 = pTr[q].Y;

                        distance = (float)(2.0 * (x1 * y2 - x2 * y1) / Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)));

                        if (distance < minDistance) 
                        { 
                            minDistance = distance; 
                            nearestHamiltonNode = p;
                        }
                    }

                    if (minDistance > maxDistance)
                    {
                        maxDistance = minDistance;
                        farthestInside = i;
                        farthestInsideFutureHamiltonInsertIndex = nearestHamiltonNode;
                    }
                }
                
                //   i n s e r t 
                // hamilton[farthestInsideFutureHamiltonInsertIndex]
                // farthestInside
                // hamilton[farthestInsideFutureHamiltonInsertIndex+1]
                ;
                // determine conv[i] and conv[i+1]

            }
        }

        private void MakeConvex()
        {
            if (convex == null) convex = new int[pts.Length];

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
            int convI = 1;
            int magic = 1;
            do
            {
                minIndex = -1;

                double maxCos = -1.1;
                for (int i = 0; i < pts.Length; i++)
                {
                    Point p = pts[i];
                    p.Offset(-pts[convex[convI - 1]].X, -pts[convex[convI - 1]].Y);

                    double cos;
                    if (magic * p.Y >= 0)
                    {
                        cos = p.X / Math.Sqrt(p.X * p.X + p.Y * p.Y);

                        if (magic * cos > maxCos)
                        {
                            maxCos = magic * cos;
                            minIndex = i;
                        }
                    }
                }

                if (minIndex == -1) { magic = -1; continue; }

                convex[convI++] = minIndex;

                if (convI >= pts.Length) break;
            }
            while (pts[convex[convI - 1]] != pts[convex[0]]);

            for(int i = convI; i < pts.Length; i++) convex[i] = -1;
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
                if (t.X * t.X + t.Y * t.Y > Math.Pow(Math.Min(pictureBox1.Width/2, pictureBox1.Height/2),2))
                {
                    //float tgA = pts[i].Y / pts[i].X;
                    //velocity[i].X = -velocity[i].Y;
                    //velocity[i].Y = -velocity[i].X;
                    //pts[i].Offset(-velocity[i].X, -velocity[i].Y);
                    //do { velocity[i].X = rnd.Next(2 * maxVel+1) - maxVel; } while (velocity[i].X == 0);
                    //do { velocity[i].Y = rnd.Next(2 * maxVel+1) - maxVel; } while (velocity[i].Y == 0);
                    
                    //pts[i].Offset(-velocity[i].X, -velocity[i].Y);

                    //velocity[i].X = -velocity[i].X;
                    //velocity[i].Y = -velocity[i].Y;

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
            Generate(200, pictureBox1.Width - 5, pictureBox1.Height - 5, 3);

            timer1.Enabled = !timer1.Enabled;
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
