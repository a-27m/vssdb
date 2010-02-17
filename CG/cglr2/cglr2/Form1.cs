using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cglr2
{
    public partial class Form1 : Form
    {
        List<Point> pts;

        public Form1()
        {
            InitializeComponent();
            pts = new List<Point>();
        }

        float cellSize = 1f;
        Brush pixelBrush = Brushes.Black;
        bool needFill = false;
        bool drawPoly = true;

        private void Plot(Graphics g, int x, int y)
        {
            g.FillRectangle(pixelBrush, x * cellSize + 1, y * cellSize + 1, cellSize, cellSize);
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
                for (int i = y1; (y2 - i) * dy > 0; i += dy)
                    Plot(g, x1, i);
                return;
            }

            if (y1 == y2)
            {
                for (int i = x1; (x2 - i) * dx > 0; i += dx)
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

                    while (e > 0)
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
                e = -1f / ΔyΔx - 0.5f;

                for (int i = 0; i < Math.Abs(Δy); i++)
                {
                    this.Plot(g, x, y);
                    while (e > 0)
                    {
                        x = x + dx;
                        e = e - 1f;
                        this.Plot(g, x, y);
                    }
                    y = y + dy;
                    e = e - 1f / ΔyΔx;
                }
            }
        }

        private void FillUp(Graphics g, int y1, int y2)
        {
            //List<Point> pts2 = new List<Point>(pts.AsQueryable().Distinct());
            //pts = pts2;            

            // ребра
            int n = pts.Count + 1;

            List<int> sap;
            sap = new List<int>(n);

            int[] Y = new int[n - 1];
            int[] I = new int[n - 1];

            int k = 0;
            foreach (Point p in pts) { Y[k] = p.Y; I[k] = k; k++; }

            Array.Sort<int, int>(Y, I);

            pts.Add(pts[0]); // ATTENTION! TEMPORARY ADD FIRST PT TO THE END OF LIST

            int m = 0; // index in Y - list of vertices

            for (int yi = y1; yi < y2; yi++)
            {
                if (m < Y.Length)
                    if (yi == Y[m])
                    {
                        do
                        {
                            int lextr = LocalExtr(m, Y, I);
                            if (lextr == 0)
                            {// remove old rebro and place new
                                if (pts[I[m] + 1].Y > Y[m])
                                {
                                    sap.Add(I[m]);
                                    int prev = I[m] - 1;
                                    if (prev < 0) prev += pts.Count - 1; // -1 to skip phantom last pt
                                    sap.Remove(prev);
                                }
                                else
                                {
                                    sap.Remove(I[m]);
                                    int nouvelle = I[m] - 1;
                                    if (nouvelle < 0) nouvelle += pts.Count - 1;
                                    sap.Add(nouvelle);
                                }
                            }
                            else
                            {
                                if (lextr > 0)  // max
                                {// add new rebra to SAP
                                    k = I[m];

                                    sap.Add(k);

                                    if (k == 0)
                                        sap.Add(n - 1 - 1); // предпоследний и без фиктивной последней вершины
                                    else
                                        sap.Add(k - 1);
                                }
                                else
                                {// remove both rebra
                                    sap.Remove(I[m]);
                                    int prev = I[m] - 1;
                                    if (prev < 0) prev += pts.Count - 1;
                                    sap.Remove(prev);
                                }
                            }
                            m++;
                        }
                        while ((m < Y.Length) && Y[m] == Y[m - 1]);
                    }

                if (sap.Count == 0) continue;
                //sap = sap.AsQueryable().Distinct().ToList();
                // исключить вершины 
                int[] sax = new int[sap.Count];
                int sax_i = 0;

                for (int i = 0; i < sap.Count; i++)
                {
                    int p0_x = pts[sap[i]].X;
                    int p0_y = pts[sap[i]].Y;
                    int p1_x = pts[sap[i] + 1].X;
                    int p1_y = pts[sap[i] + 1].Y;

                    float t = (float)(yi - p0_y) / (float)(p1_y - p0_y);

                    int x = (int)(p0_x + (p1_x - p0_x) * t);
                    sax[sax_i++] = x;
                }

                Array.Sort<int>(sax);

                for (int j = 0; j < sax.Length; j += 2)
                {
                    Line(g, sax[j], yi, sax[j + 1]+1, yi);
                }
            }

            pts.RemoveAt(pts.Count - 1); // REMOVE TEMPORARY COPY OF THE 1ST POINT AT THE END
        }

        private int LocalExtr(int m, int[] Y, int[] I)
        {
            int prevI = I[m] - 1;
            if (prevI < 0) prevI += pts.Count - 1;
            int prevY = pts[prevI].Y;
            int nextY = pts[I[m] + 1].Y;

            return (
                Math.Sign(prevY - Y[m]) +
                Math.Sign(nextY - Y[m])
                ) / 2;
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

            this.Line(e.Graphics, prev.X, prev.Y, pts[0].X, pts[0].Y);

            if (needFill)
                FillUp(e.Graphics, 0, (int)(pictureBox1.Height/cellSize));
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (pts.Count > 2)
                    pts.RemoveAt(pts.Count - 1);

                needFill = true;
                drawPoly = false;
                return;
            }

            //if (pts.Count > 1)
            //    pts.RemoveAt(pts.Count - 1);

            //pts.Add(new Point(
            //    (int)(e.X / cellSize),
            //    (int)(e.Y / cellSize)
            //    ));
            pts.Add(new Point(
                (int)(e.X / cellSize)+1,
                (int)(e.Y / cellSize)+1
                ));

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pts == null) return;

            if (!drawPoly) return;

            if (pts.Count > 0)
            {
                Point p = pts[pts.Count - 1];
                p.X = (int)(e.X / cellSize);
                p.Y = (int)(e.Y / cellSize);

                pts[pts.Count - 1] = p;

                pictureBox1.Refresh();
            }
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            buttonDraw.Checked = !buttonDraw.Checked;
            drawPoly = buttonDraw.Checked;

            if (!drawPoly)
            {
                if (pts == null) return;
                if (pts.Count > 2)
                    pts.RemoveAt(pts.Count - 1);
            }

            pictureBox1.Refresh();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            pts.Clear();
            needFill = false;
            pictureBox1.Refresh();
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            needFill = true;
            pictureBox1.Refresh();
        }
    }
}
