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
        List<List<Point>> ptsOut;
        Point ptPreview;

        float cellSize = 1f;
        Brush pixelBrush = Brushes.Black;
        bool needFill = false;
        bool drawPoly = true;

        public Form1()
        {
            InitializeComponent();
            pts = new List<Point>();

            buttonDraw.Checked = drawPoly;
        }

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

        double angel;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Gray);

            DrawUserPolygon(e);

            DrawResultPolygons(e);

            DrawAngles(e);
        }

        private void DrawAngles(PaintEventArgs e)
        {
            if (pts == null) return;
            if (pts.Count < 2) return;

            pts.Add(pts[0]);
            pts.Add(pts[1]);

            for (int i = 0; i < pts.Count - 2; i++)
            {
                SignП(pts[i], pts[i + 1], pts[i + 2]);

                e.Graphics.DrawString(
                    string.Format("{0}° (sin: {1})",
                    (int)(Math.Acos(-P) / Math.PI * 180f), P.ToString("F1")),
                    new Font("Arial", 10f), Brushes.Black, pts[i + 1]);
            }

            pts.RemoveAt(pts.Count - 1);
            pts.RemoveAt(pts.Count - 1);
        }

        private void DrawUserPolygon(PaintEventArgs e)
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

        private void DrawResultPolygons(PaintEventArgs e)
        {
            Point prev;
            Brush oldPixelBrush = pixelBrush;
            pixelBrush = new SolidBrush(Color.LightGray);

            if (ptsOut == null)
            {
                pixelBrush = oldPixelBrush;
                return;
            }

            float polyCount = ptsOut.Count - 1;
            float k = 0;
            foreach (List<Point> polygon in ptsOut)
            {
                if (polygon.Count < 2) continue;

                float r = 0;
                //angel = k / (polyCount + 1) * Math.PI * 2;
                double a1 = (k % 2) * 2 - 1;
                int dx = (int)(Math.Cos(angel * a1) * r);
                int dy = (int)(Math.Sin(angel * a1) * r);

                pixelBrush = new SolidBrush(Color.FromArgb(150, GeoColor(k / polyCount)));

                e.Graphics.FillPolygon(pixelBrush, polygon.ToArray());

                prev = polygon[0];
                foreach (Point p in polygon)
                {
                    this.Line(e.Graphics, prev.X + dx, prev.Y + dy, p.X + dx, p.Y + dy);
                    prev = p;
                }

                this.Line(e.Graphics, prev.X + dx, prev.Y + dy, polygon[0].X + dx, polygon[0].Y + dy);

                k++;
            }

            pixelBrush = oldPixelBrush;
        }

        private Color GeoColor(double p)
        {
            int r, g, b;

            if (p < 1f / 4f)
            {
                r = 0;
                g = (int)(255f * 4f * p);
                b = 255;
                return Color.FromArgb(r, g, b);
            }
            if (p < 2f / 4f)
            {
                r = 0;
                g = 255;
                b = 255 - (int)(255f * 4f * (p - 1f / 4f));
                return Color.FromArgb(r, g, b);
            }
            if (p < 3f / 4f)
            {
                r = (int)(255f * 4f * (p - 2f / 4f));
                g = 255;
                b = 0;
                return Color.FromArgb(r, g, b);
            }
            r = 255;
            g = 255 - (int)(255f * 4f * (p - 3f / 4f));
            b = 0;
            return Color.FromArgb(r, g, b);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //needFill = true;

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
            ptsOut.Clear();
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
            /*
             * 1 find where to cut
             *     true:   cut into two pieces
             *                  put pieces into input list
             *             goto 1
             *     false:  end
             */
            List<Point> poly1, poly2;

            ptsOut = new List<List<Point>>();
            List<List<Point>> ptsIn = new List<List<Point>>();

            ptsIn.Add(pts);

            while (ptsIn.Count > 0 && ptsOut.Count < pts.Count)
            {
                //if (HasSelfSection(ptsIn[0]))
                //{
                //    ptsIn.RemoveAt(0);
                //    continue;
                //}

                ptsIn[0].Add(ptsIn[0][0]);
                bool cuts = BreakPolygon(ptsIn[0], out poly1, out poly2);
                ptsIn[0].RemoveAt(ptsIn.Count - 1);

                if (!cuts) 
                {
                    ptsOut.Add(ptsIn[0]);
                    ptsIn.RemoveAt(0);

                    continue;
                }

                ptsIn.RemoveAt(0);

                if (Opuhli(poly1))
                    ptsOut.Add(poly1);
                else
                    ptsIn.Add(poly1);

                if (Opuhli(poly2))
                    ptsOut.Add(poly2);
                else
                    ptsIn.Add(poly2);
            }

            pictureBox1.Refresh();
        }

        private bool Opuhli(List<Point> poly)
        {
            for (int i = 1; i < poly.Count - 1; i++)
            {
                if (SignП(poly[i - 1], poly[i], poly[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool HasSelfSection(List<Point> poly)
        {
            for (int i = 0; i < poly.Count - 1 /* -1 do not check the last one*/; i++)
            {
                for (int j = 0; j < poly.Count - 1; j++)
                {
                    float t;
                    CalcIntersect(poly[i], poly[i + 1], poly[j], poly[j + 1], out t);

                    if (float.IsNaN(t)) continue;

                    if (Math.Abs(t) < 1e-8f) continue;
                    if (Math.Abs(t-1) < 1e-8f) continue;

                    if (t > 0f && t < 1f) return true;
                }
            }

            return false;
        }

        private bool BreakPolygon(List<Point> poly, out List<Point> polyPart1, out List<Point> polyPart2)
        {
            bool cutTakesPlace = false;
            polyPart1 = new List<Point>();
            polyPart2 = new List<Point>();

            for (int i = 1; i < poly.Count - 1; i++)
            {
                if (SignП(poly[i - 1], poly[i], poly[i + 1]) > 0)
                {
                    cutTakesPlace = true;

                    int s;
                    // cut here
                    Point Q = GetIntersectPoint(poly, i - 1, out s);
                    
                    int k;

                    polyPart1.Add(Q);
                    polyPart1.Add(poly[s + 1]);
                    // to i-1 incl, i++
                    k = s + 1 + 1;
                    do
                    {
                        if (k > poly.Count - 1) k -= poly.Count;

                        polyPart1.Add(poly[k]);

                        //k++;
                    }
                    while (k++ != i - 1);

                    polyPart2.Add(Q);
                    polyPart2.Add(poly[s]);
                    // to i incl, i--
                    k = s - 1;
                    do
                    {
                        if (k < 0) k += poly.Count - 1;

                        polyPart2.Add(poly[k]);

                        //k--;
                    }
                    while (k-- != i);

                    break;
                }
            }
            return cutTakesPlace;
        }
        /*
        private void buttonBreak_Click1(object sender, EventArgs e)
        {
            int k = 0;

            List<Point> ptsBackup = new List<Point>();
            ptsBackup.AddRange(pts);

            ptsOut = new List<List<Point>>();
            ptsOut.Add(new List<Point>());

            if (pts.Count > 3)
            {
                pts.Add(pts[0]);

                ptsOut[0].Add(pts[0]);

                while (pts.Count > 2)
                {
                    if (SignП(pts[0], pts[1], pts[2]) < 0)
                    {
                        ptsOut[k].Add(pts[1]);
                        pts.RemoveAt(0);

                        //// change phantom
                        //if (pts.Count > 1)
                        //{
                        //    pts.RemoveAt(pts.Count - 1);
                        //    pts.Add(pts[0]);
                        //}
                    }
                    else
                    {

                        // replace v2 with v3' in polygon #k, but v2 isnt added yet, so just add V3'
                        ptsOut[k].Add(nearestV3);

                        // start new polygon with v3'-v2-v3 and continue do checks
                        ptsOut.Add(new List<Point>());
                        ptsOut[k + 1].Add(nearestV3);
                        ptsOut[k + 1].Add(pts[1]);

                        // make the new polygon current
                        k++;

                        pts.RemoveAt(0); 
                        //pts[0] = nearestV3;
                        // change phantom
                        //pts.RemoveAt(pts.Count - 1);
                        //pts.Add(nearestV3);
                    }
                }

                pts.RemoveAt(pts.Count - 1);
            }

            // add last points to the last polygon
            ptsOut[k].AddRange(pts);

            // restore user input
            pts.Clear();
            pts.AddRange(ptsBackup);

            pictureBox1.Refresh();

            //timer1.Enabled = true;
        }
        */

        /// <summary>Finds nearest intersection point Q = ViVi+1 ∩ S</summary>
        /// <param name="i">poly[i] and poly[i+1] are ends of the side which cuts</param>
        /// <param name="s">index, side (poly[s];poly[s+1]) is S </param>
        /// <returns>Intersection point Q</returns>
        private Point GetIntersectPoint(List<Point> poly, int i, out int s)
        {
            float tNearest = float.MaxValue;
            Point nearest = Point.Empty;
            int sNearest = -1;

            for (s = 0; s < poly.Count - 1; s++)
            {
                if ((s - i >= -1) && (s - i <= 1)) continue; // skip V1V2 itself

                Point Q;
                float t_s;

                Q = CalcIntersect(
                    poly[i], poly[i + 1], // V1V2
                    poly[s], poly[s + 1], // Si
                    out t_s
                    );

                if (float.IsNaN(t_s)) continue;

                if (t_s < tNearest)
                {
                    t_s = tNearest;
                    nearest = Q;
                    sNearest = s;
                }
            }

            s = sNearest;
            return nearest;
        }

        private Point CalcIntersect(Point v1, Point v2, Point s1, Point s2, out float t)
        {
            float q;

            float denominator = (s2.Y - s1.Y) * (v2.X - v1.X) - (s2.X - s1.X) * (v2.Y - v1.Y);

            if (denominator == 0)
            {
                t = float.NaN;
                return Point.Empty;
            }

            t = (s2.X - s1.X) * (v1.Y - s1.Y) - (s2.Y - s1.Y) * (v1.X - s1.X);
            t /= denominator;

            q = (v2.X - v1.X) * (v1.Y - s1.Y) - (v2.Y - v1.Y) * (v1.X - s1.X);
            q /= denominator;

            if (q < 0f || q > 1f)
            {
                t = float.NaN;
                return Point.Empty;
            }

            return new Point(
                (int)(v1.X + t * (v2.X - v1.X)),
                (int)(v1.Y + t * (v2.Y - v1.Y))
                );
        }

        float P;
        public int SignП(Point v1, Point v2, Point v3)
        {

            // metodi4ka
            //P = (v3.X - v1.X) * (v2.Y - v1.Y) - (v3.Y - v2.Y) * (v2.X - v1.X);

            // cos
            //P = (v1.X - v2.X) * (v3.X - v2.X) + (v1.Y - v2.Y) * (v3.Y - v2.Y);

            // Xa*Yc-Xc*Ya
            P = (v1.X - v2.X) * (v3.Y - v2.Y) -
                (v3.X - v2.X) * (v1.Y - v2.Y);

            if (P == 0f) return 0;

            P /= (float)(
                Math.Sqrt((v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y)) *
                Math.Sqrt((v3.X - v2.X) * (v3.X - v2.X) + (v3.Y - v2.Y) * (v3.Y - v2.Y))
                );

            return Math.Sign(P);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angel += Math.PI * 2f / 20f;

            if (angel >= Math.PI * 2) angel -= Math.PI * 2;

            pictureBox1.Refresh();
        }

        private void buttonResultAsInput_Click(object sender, EventArgs e)
        {
            if (ptsOut != null)
                if (ptsOut.Count > 0)
                {
                    pts = ptsOut[0];
                }

            pictureBox1.Refresh();
        }
    }
}