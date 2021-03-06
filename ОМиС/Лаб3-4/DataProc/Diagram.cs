using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DataProc
{
    public class Diagram
    {
        const float FONT_HEIGHT = 8f;
        const string FONT_FACE = "MS Sans Serif";

        public enum KindOfDiagram
        {
            LeftArrows,
            Histogram,
            Polygon,
            Metrolog
        }

        KindOfDiagram kindOfDiagram = KindOfDiagram.Polygon;

        public KindOfDiagram DiagramKind
        {
            get
            {
                return kindOfDiagram;
            }
            set
            {
                kindOfDiagram = value;
            }
        }

        double[] Y;
        public float zoom_x, zoom_y;
        public Color penColor = Color.FromKnownColor(KnownColor.ControlText);
        public Size sz;
        public PointF ptCenter;
        public PointF ptMargins;
        public List<int> indsd;

        public Diagram(Size size, double[] values)
        {
            sz = size;
            Y = values;
        }

        public Diagram(Size size, double[] values, KindOfDiagram kind)
        {
            sz = size;
            Y = (double[])values.Clone();
            kindOfDiagram = kind;
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;

            //Color cl = Color.FromArgb(255, 250, 242);
            Color cl = Color.FromArgb(240, 240, 242);

            g.Clear(cl);

            g.Transform = new Matrix(1, 0, 0, -1, 0, sz.Height - 1);

            #region Zoom calculation

            zoom_x = sz.Width / (Y.Length + 1f);

            ptMargins = new PointF(zoom_x, new Font(FONT_FACE, FONT_HEIGHT).GetHeight() * 2f);
            float MaxMin = (float)(StatisticsProcessor.FindMax(Y) - StatisticsProcessor.FindMin(Y));
            float Ampl = (MaxMin > float.Epsilon ? MaxMin : 1);

            zoom_y = (sz.Height - 2 * ptMargins.Y - 1) / Ampl;

            #endregion

            #region switch on the kind of the diagram

            switch (kindOfDiagram)
            {
                case KindOfDiagram.LeftArrows:
                    DrawLeftSideArrows(g, zoom_x, zoom_y);
                    break;

                case KindOfDiagram.Histogram:
                    DrawHistogram(g, zoom_x, zoom_y);
                    break;

                case KindOfDiagram.Polygon:
                    DrawPolygon(g, zoom_x, zoom_y);
                    break;

                case KindOfDiagram.Metrolog:
                    DrawMetrolog(g, zoom_x, zoom_y);
                    break;

                default:
                    DrawHistogram(g, zoom_x, zoom_y);
                    break;
            }
            #endregion
        }

        private void DrawMetrolog(Graphics g, float zoom_x, float zoom_y)
        {
            DrawAxes(g, ptMargins.Y);

            PointF[] polyPts = new PointF[Y.Length];
            float ptDeltaX = sz.Height / 400;
            float ptDeltaY = sz.Width / 400;

            Pen penCrosses = new Pen(penColor, 5);
            penCrosses.EndCap = penCrosses.StartCap = LineCap.Round;

            double min = StatisticsProcessor.FindMin(Y);

            for (int i = 0; i < Y.Length; i++)
            {
                polyPts[i].X = i * zoom_x + ptMargins.X;
                polyPts[i].Y = (float)(Y[i] - min) * zoom_y + ptMargins.Y;

                g.DrawLine(penCrosses,
                    PointF.Add(polyPts[i], new SizeF(-ptDeltaX, -ptDeltaY)),
                    PointF.Add(polyPts[i], new SizeF(+ptDeltaX, +ptDeltaY)));
                g.DrawLine(penCrosses,
                    PointF.Add(polyPts[i], new SizeF(+ptDeltaX, -ptDeltaY)),
                    PointF.Add(polyPts[i], new SizeF(-ptDeltaX, +ptDeltaY)));
            }

            if (Y.Length > 1)
                g.DrawLines(new Pen(penColor, 2), polyPts);

            DrawValues(g, ptMargins.Y - (float)min * zoom_y, zoom_x, zoom_y);

            Pen penMids = new Pen(Color.Orange);

            int i0 = 0;
            for (int il = 0; il < indsd.Count; il++)
            {
                int i = indsd[il];
                double[] y1 = new double[i - i0];
                Array.Copy(Y, i0, y1, 0, i - i0);

                float mid = (float)StatisticsProcessor.Srednee(y1);

                float gy = (float)(mid - min) * zoom_y + ptMargins.Y;

                g.DrawLine(penMids, ptMargins.X + i0 * zoom_x, gy, ptMargins.X + i * zoom_x, gy);

                i0 = i;
            }
        }

        private void DrawValues(Graphics g, float oy, float zoom_x, float zoom_y)
        {
            Font font = new Font(FONT_FACE, FONT_HEIGHT, FontStyle.Bold);
            SolidBrush brush =
                new SolidBrush(Color.FromKnownColor(KnownColor.ControlText));

            double max = StatisticsProcessor.FindMax(Y);
            double min = StatisticsProcessor.FindMin(Y);
            int stps = 20;

            g.ScaleTransform(1, -1);
            for (int i = 0; i <= stps; i++)
            {
                PointF point = new PointF(
                    0,
                    -((float)((max - min)*i/stps + min) * zoom_y + 0.5f * font.Height + oy) 
                    );

                string valStr = string.Format("{0:F2}", (max - min)*i/stps + min);
                g.DrawString(valStr, font, brush, point);
            }
            g.ScaleTransform(1, -1);
        }

        private void DrawAxes(Graphics g, float oy)
        {
            Pen penAxes = new Pen(Color.Gray, 1);
            g.DrawLine(penAxes,
                ptMargins.X,
                ptMargins.Y / 2f,
                ptMargins.X,
                sz.Height - ptMargins.Y / 2f);

            g.DrawLine(penAxes,
                ptMargins.X / 2,
                oy,
                sz.Width - ptMargins.X / 2f,
                oy);
        }

        private void DrawLeftSideArrows(Graphics g, float zoom_x, float zoom_y)
        {
            DrawAxes(g, ptMargins.Y);

            Double min = StatisticsProcessor.FindMin(Y);

            Pen pen = new Pen(penColor, 2);
            Pen penArrow = new Pen(penColor, 1.2f);

            penArrow.StartCap = penArrow.EndCap = LineCap.Round;

                PointF pt1 = new PointF();
                PointF pt2 = new PointF();
            for (int i = 0; i < Y.Length; i++)
            {
                pt1.X = (i + 1) * zoom_x;
                pt1.Y = (float)(Y[i]-min) * zoom_y;

                pt2.X = i * zoom_x;
                pt2.Y = (float)(Y[i]-min) * zoom_y;

                // line
                g.DrawLine(pen, pt1.X + ptMargins.X, pt1.Y + ptMargins.Y,
                    pt2.X + ptMargins.X, pt2.Y + ptMargins.Y);
                DrawArrowEars(g, penArrow, pt2, zoom_x / 8, 180, 20);
            }

            DrawValues(g, ptMargins.Y - (float)min * zoom_y, zoom_x, zoom_y);
        }

        /// <summary>
        /// Draws two lines - arrow itself
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <param name="DirectionAngle">In degrees</param>
        /// <param name="OpeningAngle">In degrees</param>
        private void DrawArrowEars(Graphics g, Pen pen, PointF p,
            float r, float DirectionAngle, float OpeningAngle)
        {
            DirectionAngle += 180;

            double alpha;

            alpha = DirectionAngle / 180 * Math.PI + OpeningAngle / 180 * Math.PI;
            g.DrawLine(pen,
                p.X + ptMargins.X + r * (float)Math.Cos(alpha),
                p.Y + ptMargins.Y + r * (float)Math.Sin(alpha),
                p.X + ptMargins.X,
                p.Y + ptMargins.Y);

            alpha = DirectionAngle / 180 * Math.PI - OpeningAngle / 180 * Math.PI;
            g.DrawLine(pen,
                p.X + ptMargins.X + r * (float)Math.Cos(alpha),
                p.Y + ptMargins.Y + r * (float)Math.Sin(alpha),
                p.X + ptMargins.X,
                p.Y + ptMargins.Y );
        }

        private void DrawHistogram(Graphics g, float zoom_x, float zoom_y)
        {
            double min = StatisticsProcessor.FindMin(Y);
            double max= StatisticsProcessor.FindMax(Y);
            float oy = 0;
            float zy = zoom_y;
            
            if (max < 0) // signs equals -           
            {
                oy = sz.Height - ptMargins.Y;
                zy = (sz.Height - 2 * ptMargins.Y - 1) / (float)Math.Abs(min);
            }
            else if (min > 0) // signs equals +
            {
                oy = ptMargins.Y;
                zy = (sz.Height - 2 * ptMargins.Y - 1) / (float)Math.Abs(max);
            }
            else if (max != min) // signs differs
            {
                oy = (sz.Height - 2 * ptMargins.Y - 1) * (float)(Math.Abs(min) / (max - min)) + ptMargins.Y;
                zy = (sz.Height - 2 * ptMargins.Y - 1) / (float)(Math.Abs(min) + Math.Abs(max));
            }
            else // stable zero
            {
                oy = 0;
                zy = sz.Height - 2 * ptMargins.Y - 1;
            }

            DrawAxes(g, oy);

            for (int i = 0; i < Y.Length; i++)
            {
                RectangleF rect = new RectangleF(
                    i * zoom_x+ 0.1f*zoom_x+ ptMargins.X / 2f,
                    (float)(Y[i] * zy > 0 ? 0 : Y[i] * zy) + oy,
                    1f * zoom_x - 0.2f * zoom_x,
                    (float)(Math.Abs(Y[i]) * zy));

                if (rect.Height < float.Epsilon)
                    rect.Height += 1.5f;
                //0e+20f * float.Epsilon;

                LinearGradientBrush lgb = new LinearGradientBrush(rect,
                    penColor, Color.FromKnownColor(KnownColor.ControlDark), 75);

                g.FillRectangle(lgb, rect);
            }

            Font font = new Font(FONT_FACE, FONT_HEIGHT);
            SolidBrush brush =
                new SolidBrush(Color.FromKnownColor(KnownColor.ControlText));

            g.ScaleTransform(1, -1);
            for (int i = 0; i < Y.Length; i++)
            {
                PointF point = new PointF(
                    (i+.5f) * zoom_x + ptMargins.X / 2f,
                    -(float)(Y[i]*zy + 1.0f * font.Height*Math.Sign(Y[i]) + oy)
                    );

                string valStr = Y[i].ToString();
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                float actual_width=0;
                int dig_count = 1;
                while (actual_width < 0.9f * zoom_x && dig_count<=15)
                {
                    double trim_val = Math.Round(Y[i], dig_count++);
                    valStr = trim_val.ToString();
                    actual_width = g.MeasureString(valStr, font, point, sf).Width;
                }
                g.DrawString(valStr, font, brush, point,sf);
            }
            g.ScaleTransform(1, -1);
        }

        private void DrawPolygon(Graphics g, float zoom_x, float zoom_y)
        {
            DrawAxes(g, ptMargins.Y);

            PointF[] polyPts = new PointF[Y.Length];
            float ptDeltaX = sz.Height / 400;
            float ptDeltaY = sz.Width / 400;

            Pen penCrosses = new Pen(penColor, 5);
            penCrosses.EndCap = penCrosses.StartCap = LineCap.Round;

            double min = StatisticsProcessor.FindMin(Y);

            for (int i = 0; i < Y.Length; i++)
            {
                polyPts[i].X = i * zoom_x + ptMargins.X;
                polyPts[i].Y = (float)(Y[i]-min) * zoom_y + ptMargins.Y;

                g.DrawLine(penCrosses,
                    PointF.Add(polyPts[i], new SizeF(-ptDeltaX, -ptDeltaY)),
                    PointF.Add(polyPts[i], new SizeF(+ptDeltaX, +ptDeltaY)));
                g.DrawLine(penCrosses,
                    PointF.Add(polyPts[i], new SizeF(+ptDeltaX, -ptDeltaY)),
                    PointF.Add(polyPts[i], new SizeF(-ptDeltaX, +ptDeltaY)));
            }

            if (Y.Length > 1)
                g.DrawLines(new Pen(penColor, 2), polyPts);

            DrawValues(g, ptMargins.Y - (float)min*zoom_y, zoom_x, zoom_y);
        }
    }
}