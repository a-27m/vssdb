using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DataProc
{
    public class Diagram
    {
        public enum KindOfDiagram
        {
            LeftArrows,
            Histogram,
            Polygon
        }

        KindOfDiagram kindOfDiagram = KindOfDiagram.Polygon;

        public KindOfDiagram DiagramKind
        {
            get { return kindOfDiagram; }
            set { kindOfDiagram = value; }
        }

        double[] Y;
        float zoom_x, zoom_y;
        public Color penColor = Color.FromKnownColor(KnownColor.ControlText);
        public Size sz;
        public PointF ptCenter;
        public PointF ptMargins;

        public Diagram(Size size, double[] values)
        {
            sz = size;
            Y = (double[])values.Clone();
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;

            //Color cl = Color.FromArgb(33, 85, 143);
            g.Clear(Color.FromKnownColor(KnownColor.ControlLight));

            #region Zoom calculation

            zoom_x = sz.Width / (Y.Length + 1);

            float MaxMin = (float)
                (StatisticsProcessor.FindMax(Y) -
                StatisticsProcessor.FindMin(Y));
            if (MaxMin > float.Epsilon)

                zoom_y = sz.Height / MaxMin * 0.8f;
            else
                zoom_y = sz.Height * 0.8f;

            #endregion

            ptMargins = new PointF(zoom_x, 0.05f * sz.Height);

            g.Transform = new Matrix(1, 0, 0, -1, 0, sz.Height - MaxMin/2f);

            DrawAxes(g, zoom_x, zoom_y);

            #region switch Kind Of Diagram

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

                default:
                    DrawHistogram(g, zoom_x, zoom_y);
                    break;
            }
            #endregion

            DrawValues(g, zoom_x, zoom_y);
        }

        private void DrawValues(Graphics g, float zoom_x, float zoom_y)
        {
           // Font font = new Font("Arial", 0.2f*zoom_x);
	Font font = new Font("Arial", 10f);
            SolidBrush brush =
                new SolidBrush(Color.FromKnownColor(KnownColor.ControlText));

            g.ScaleTransform(1, -1);
            for (int i = 0; i < Y.Length; i++)
            {
                PointF point = new PointF(
                    i * zoom_x + ptMargins.X / 2f,
                    -(
                    (float)Y[i] * zoom_y + 
                    float.Epsilon + 
                    ptMargins.Y / 2f +
                    1.5f*font.Height )
                    );

                string valStr = string.Format("{0:F2}", Y[i]);
                g.DrawString(valStr, font, brush, point);
            }
            g.ScaleTransform(1, -1);
        }

        private void DrawAxes(Graphics g, float zoom_x, float zoom_y)
        {
            Pen penAxes = new Pen(Color.Black, 1);
            g.DrawLine(penAxes,
                0 + ptMargins.X / 2,
                0 + ptMargins.Y / 2,
                0 + ptMargins.X / 2,
                g.ClipBounds.Bottom);

            g.DrawLine(penAxes,
                0 + ptMargins.X / 2,
                0 + ptMargins.Y / 2,
                g.ClipBounds.Right,
                0 + ptMargins.Y / 2);
        }

        private void DrawLeftSideArrows(Graphics g, float zoom_x, float zoom_y)
        {
            DrawAxes(g, zoom_x, zoom_y);

            Pen pen = new Pen(penColor, 2);
            Pen penArrow = new Pen(penColor, 1);

            penArrow.StartCap = penArrow.EndCap = LineCap.Round;

            for (int i = 0; i < Y.Length; i++)
            {
                PointF pt1 = new PointF();
                pt1.X = (i + 1) * zoom_x;
                pt1.Y = (float)Y[i] * zoom_y;

                PointF pt2 = new PointF();
                pt2.X = i * zoom_x;
                pt2.Y = (float)Y[i] * zoom_y;

                // line
                g.DrawLine(pen, pt1.X + ptMargins.X / 2f, pt1.Y + ptMargins.Y / 2f,
                    pt2.X + ptMargins.X / 2f, pt2.Y + ptMargins.Y / 2f);
                DrawArrowEars(g, penArrow, pt2, zoom_x / 8, 180, 20);
            }
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
                p.X + ptMargins.X / 2 + r * (float)Math.Cos(alpha),
                p.Y + ptMargins.Y / 2 + r * (float)Math.Sin(alpha),
                p.X + ptMargins.X / 2,
                p.Y + ptMargins.Y / 2);

            alpha = DirectionAngle / 180 * Math.PI - OpeningAngle / 180 * Math.PI;
            g.DrawLine(pen,
                p.X + ptMargins.X / 2 + r * (float)Math.Cos(alpha),
                p.Y + ptMargins.Y / 2 + r * (float)Math.Sin(alpha),
                p.X + ptMargins.X / 2,
                p.Y + ptMargins.Y / 2);

        }

        private void DrawHistogram(Graphics g, float zoom_x, float zoom_y)
        {
            for (int i = 0; i < Y.Length; i++)
            {
                // rect
                RectangleF rect = new RectangleF(
                    i * zoom_x + ptMargins.X / 2f,
                    ptMargins.Y / 2f,
                    zoom_x,
                    (float)Y[i] * zoom_y + float.Epsilon);

                LinearGradientBrush lgb = new LinearGradientBrush(rect,
                    Color.FromKnownColor(KnownColor.ControlDark), penColor, 75);

                g.FillRectangle(lgb, rect);
            }
        }

        private void DrawPolygon(Graphics g, float zoom_x, float zoom_y)
        {
            PointF[] polyPts = new PointF[Y.Length];
            float ptDeltaX = sz.Height / 200;
            float ptDeltaY = sz.Width / 200;

            Pen penCrosses = new Pen(penColor, 5);
            penCrosses.EndCap = penCrosses.StartCap = LineCap.Round;

            for (int i = 0; i < Y.Length; i++)
            {
                polyPts[i].X = i * zoom_x + ptMargins.X;
                polyPts[i].Y = (float)Y[i] * zoom_y + ptMargins.Y;

                g.DrawLine(penCrosses,
                    PointF.Add(polyPts[i], new SizeF(-ptDeltaX, -ptDeltaY)),
                    PointF.Add(polyPts[i], new SizeF(ptDeltaX, ptDeltaY)));
                g.DrawLine(penCrosses,
                    PointF.Add(polyPts[i], new SizeF(+ptDeltaX, -ptDeltaY)),
                    PointF.Add(polyPts[i], new SizeF(-ptDeltaX, +ptDeltaY)));
            }

            if (Y.Length > 1)
                g.DrawLines(new Pen(penColor, 2), polyPts);
        }
    }
}
