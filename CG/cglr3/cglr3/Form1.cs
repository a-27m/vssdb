using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace cglr3
{
    public partial class Form1 : Form
    {
        List<Point> pts;
        List<List<Point>> pResult;
        Point ptPreview;

        public Form1()
        {
            InitializeComponent();
            pts = new List<Point>();
            pResult = new List<List<Point>>();

            buttonDraw.Checked = drawPoly;
        }

        float cellSize = 1f;
        Brush pixelBrush = Brushes.Black;
        bool needFill = false;
        bool drawPoly = true;

        private void Plot(Graphics g, int x, int y)
        {
            g.FillRectangle(pixelBrush, x * cellSize + 1, y * cellSize + 1, cellSize, cellSize);
        }

        private void Plot(Graphics g, int x, int y, Color c)
        {
            (pixelBrush as SolidBrush).Color = c;
            g.FillRectangle(pixelBrush, x * cellSize + 1, y * cellSize + 1, cellSize, cellSize);
            (pixelBrush as SolidBrush).Color = Color.Black;
        }

        Color ptc(float p)
        {
            p = 1f - p;
            int val = (int)(255f * p);
            if (val < 0) return Color.Red;
            if (val > 255) return Color.Blue;
            return Color.FromArgb(val, val, val);
        }

        private void LineWu(Graphics g, int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                Plot(g, x1, y1);
                return;
            }

            int Δx, Δy;
            Δx = x2 - x1;
            Δy = y2 - y1;

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

            if (Math.Abs(Δx) > Math.Abs(Δy))
            {
                //swap(ref x1, ref y1);
                //swap(ref x2, ref y2);


                float ΔyΔx = (float)Δy / (float)Δx;

                // main loop
                float intery = y1 + ΔyΔx * dy; // first y-intersection for the main loop
                for (int x = x1; x != x2; x += dx)
                {
                    Plot(g, x, ipart(intery), ptc(rfpart(intery)));
                    Plot(g, x, ipart(intery) + dy, ptc(fpart(intery)));
                    intery = intery + ΔyΔx;
                }

               for (int x = x1; x != x2; x += dx)
                {
                    Plot(g, x, ipart(intery), ptc(rfpart(intery)));
                    Plot(g, x, ipart(intery) + dy, ptc(fpart(intery)));
                    intery = intery + ΔyΔx;
                }
            }
        }

        private void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        private int ipart(float a)
        {
            return (int)Math.Truncate(a);
        }
        private float fpart(float a)
        {
            return (float)(a - Math.Truncate(a));
        }
        private float rfpart(float a)
        { return (float)(1f - (a - Math.Truncate(a))); }

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

            float ΔyΔx = (float)Δy / (float)Δx;

            //if (Math.Abs(ΔyΔx) == 1)
            //{
            //    for (int i = 0; i <= Math.Abs(Δx / dx); i++)
            //    {
            //        Plot(g, x1, y1);
            //        y1 += dy;
            //        x1 += dx;
            //    }
            //    return;
            //}

            //float w, e1;

            if ((ΔyΔx > 0))
            {
                /* w = 1f - ΔyΔx;
                 e1 = .5f;

                 for (int i = 0; i < Δx/dx; i++)
                 {
                     if (e1 >= w)
                     {
                         y = y + dy; 
                         e1 = e1 - w;
                     }
                     else //(e1 < w)
                     {
                         e1 = e1 + ΔyΔx;
                     }

                     x = x + dx;
                     this.Plot(g, x, y, ptc(e1));
                 }
                 */

                e = ΔyΔx - 0.5f;

                for (int i = 0; i < Math.Abs(Δx); i++)
                {
                    this.Plot(g, x, y);
                    while (e > 0)
                    {
                        y = y + dy;
                        e = e - 1f;
                        this.Plot(g, x, y);
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
                            int lExtr = IsLocalExtreme(m, Y, I);

                            if (lExtr > 0)  // max => add new rebra to SAP
                            {
                                k = I[m];
                                sap.Add(k);

                                if (--k < 0) k += n - 1; // предпоследний и без фиктивной последней вершины
                                sap.Add(k);
                            }

                            if (lExtr < 0)  // min => remove both rebra
                            {
                                sap.Remove(I[m]);
                                int prev = I[m] - 1;
                                if (prev < 0) prev += pts.Count - 1;
                                sap.Remove(prev);
                            }

                            if (lExtr == 0) // no extr => remove upper rebro and place bottom
                            {
                                //if (pts[I[m] + 1].Y == Y[m]) // rebro is on the scanline => 
                                //{
                                //    // Y[m] = -1;
                                //    // Array.Sort<int, int>(Y, I);
                                //    m++; // skipped to the next point //by continue, so do it now
                                //    continue;
                                //}

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
                            m++;
                        }
                        while ((m < Y.Length) && Y[m] == Y[m - 1]);
                    }

                if (sap.Count == 0) continue;

                // исключить вершины 
                int[] sax = new int[sap.Count];
                int sax_i = 0;

                for (int i = 0; i < sap.Count; i++)
                {
                    int x;

                    int p0_x = pts[sap[i]].X;
                    int p0_y = pts[sap[i]].Y;
                    int p1_x = pts[sap[i] + 1].X;
                    int p1_y = pts[sap[i] + 1].Y;

                    float t = (float)(yi - p0_y) / (float)(p1_y - p0_y);

                    x = (int)(p0_x + (p1_x - p0_x) * t);
                    sax[sax_i++] = x;
                }

                Array.Sort<int>(sax);

                for (int j = 0; j < sax.Length; j += 2)
                {
                    Line(g, sax[j], yi, sax[j + 1] + 1, yi);
                }
            }

            pts.RemoveAt(pts.Count - 1); // REMOVE TEMPORARY COPY OF THE 1ST POINT AT THE END
        }

        private int IsLocalExtreme(int m, int[] Y, int[] I)
        {
            int prevI = I[m] - 1;
            if (prevI < 0) prevI += pts.Count - 1;
            int prevY = pts[prevI].Y;

            int nextY = pts[I[m] + 1].Y;

            return (
                Math.Sign(prevY - Y[m]) +
                Math.Sign(nextY - Y[m])
                ) >> 1;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == (char)Keys.Escape)
            {
                drawPoly = buttonDraw.Checked = false;

                pictureBox1.Refresh();
            }
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

            if (drawPoly)
            {
                this.Line(e.Graphics, prev.X, prev.Y, ptPreview.X, ptPreview.Y);
                prev = ptPreview;
            }

            this.Line(e.Graphics, prev.X, prev.Y, pts[0].X, pts[0].Y);

            if (needFill)
                FillUp(e.Graphics, 0, (int)(pictureBox1.Height / cellSize));

            //if (drawPoly && needFill)
            //{
            //    pts.Add(ptPreview);
            //    FillUp(e.Graphics, 0, (int)(pictureBox1.Height / cellSize));
            //    pts.RemoveAt(pts.Count - 1);
            //}

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                needFill = true;

                drawPoly = false;
                buttonDraw.Checked = false;
            }
            else
            {
                pts.Add(new Point(
                    (int)(e.X / cellSize) + 1,
                    (int)(e.Y / cellSize) + 1
                    ));
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pts == null) return;

            if (!drawPoly) return;

            ptPreview.X = (int)(e.X / cellSize);
            ptPreview.Y = (int)(e.Y / cellSize);

            pictureBox1.Refresh();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            drawPoly = buttonDraw.Checked = !buttonDraw.Checked;

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

        private void buttonBreak_Click(object sender, EventArgs e)
        {           
            List<List<Point>> ptsOut;
            int k = 0;

            ptsOut = new List<List<Point>>();
            ptsOut.Add(new List<Point>());

            pts.Add(pts[0]);
            pts.Add(pts[1]);

            for (int i = 0; i < pts.Count-2; i++) 
            {
                if (SignП(
                    pts[i + 0],
                    pts[i + 1],
                    pts[i + 2]) < 0)
                {
                    ptsOut[k].Add(pts[i]);
                }
                else 
                {

                }
            }

            pts.RemoveAt(pts.Count-1);

            pts.Clear();
            pts.AddRange(ptsOut[0]);

           // pictureBox1.Refresh();
        }

        public int SignП(Point v1, Point v2, Point v3)
        {
            float P;

            // metodi4ka
            //P = (v3.X - v1.X) * (v2.Y - v1.Y) - (v3.Y - v2.Y) * (v2.X - v1.X);

            // cos
            //P = (v1.X - v2.X) * (v3.X - v2.X) + (v1.Y - v2.Y) * (v3.Y - v2.Y);

            // Xa*Yc-Xc*Ya
            P = (v1.X - v2.X) * (v3.Y - v2.Y)- 
                (v3.X - v2.X) * (v1.Y - v2.Y);

            P /= (float)(
                Math.Sqrt((v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y)) *
                Math.Sqrt((v3.X - v2.X) * (v3.X - v2.X) + (v3.Y - v2.Y) * (v3.Y - v2.Y))
                );

            pictureBox1.CreateGraphics().DrawString(
                string.Format("{0}° (sin={1})",
                (int)(Math.Acos(P)/Math.PI*180f), P.ToString("F2")), 
                new Font("Arial", 10f), Brushes.Blue, v2);

            return Math.Sign(P);
        }
    }
}