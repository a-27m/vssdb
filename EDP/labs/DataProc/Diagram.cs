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
            Polygon
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

        public Diagram(Size size, double[] values, KindOfDiagram kind)
        {
            sz = size;
            Y = (double[])values.Clone();
            kindOfDiagram = kind;
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;

            Color cl = Color.FromArgb(255, 250, 242);

            g.Clear(cl);//Color.FromKnownColor(KnownColor.ControlLight));

            #region Zoom calculation

            zoom_x = sz.Width / (Y.Length + 1);

            ptMargins = new PointF(zoom_x, new Font(FONT_FACE, FONT_HEIGHT).GetHeight() * 3f);
            float MaxMin = (float)(StatisticsProcessor.FindMax(Y) - StatisticsProcessor.FindMin(Y));
            float Ampl = (MaxMin > float.Epsilon ? MaxMin : 1);

            zoom_y = (sz.Height - 2 * ptMargins.Y - 1) / Ampl;

            #endregion

            g.Transform = new Matrix(1, 0, 0, -1, 0, sz.Height - 1);

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

                default:
                    DrawHistogram(g, zoom_x, zoom_y);
                    break;
            }
            #endregion

            DrawValues(g, zoom_x, zoom_y);
        }

        private void DrawValues(Graphics g, float zoom_x, float zoom_y)
        {
            Font font = new Font(FONT_FACE, FONT_HEIGHT, FontStyle.Bold);
            SolidBrush brush =
                new SolidBrush(Color.FromKnownColor(KnownColor.ControlText));

            double max = StatisticsProcessor.FindMax(Y);
            double min = StatisticsProcessor.FindMin(Y);
            int stps = 20;

            g.ScaleTransform(1, -1);
            for (int i = 0; i < stps; i++)
            {
                PointF point = new PointF(
                    0,
                    -((float)((max - min)*i/stps + min) * zoom_y + ptMargins.Y + 0.5f * font.Height)
                    );

                string valStr = string.Format("{0:F2}", (max - min)*i/stps + min);
                g.DrawString(valStr, font, brush, point);
            }
            g.ScaleTransform(1, -1);
        }

        private void DrawAxes(Graphics g, float zoom_x, float zoom_y)
        {
            Pen penAxes = new Pen(Color.Gray, 1);
            g.DrawLine(penAxes,
                ptMargins.X,
                ptMargins.Y / 2f,
                ptMargins.X,
                sz.Height - ptMargins.Y / 2f);

            g.DrawLine(penAxes,
                ptMargins.X / 2,
                ptMargins.Y,
                sz.Width - ptMargins.X / 2f,
                ptMargins.Y);

            g.DrawRectangle(Pens.Red,
                ptMargins.X, ptMargins.Y,
                sz.Width - 2f * ptMargins.X, sz.Height - 2f * ptMargins.Y);
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
            DrawAxes(g, zoom_x, zoom_y);

            double min = StatisticsProcessor.FindMin(Y);
            double max= StatisticsProcessor.FindMax(Y);
            float oy = 0;
            float zy = zoom_y;
            
            if (max < 0) // signs equals -           
            {
                oy = sz.Height - 2* ptMargins.Y;
                zy = (sz.Height - 2 * ptMargins.Y - 1) / (float)Math.Abs(min);
            }
            else if (min > 0) // signs equals +
            {}
            else// signs differs
            {}

            for (int i = 0; i < Y.Length; i++)
            {
                RectangleF rect = new RectangleF(
                    i * zoom_x + ptMargins.X / 2f,
                    (float)(Y[i] * zy > 0 ? 0 : Y[i] * zy) + oy + ptMargins.Y,
                    1f * zoom_x,
                    (float)(Math.Abs(Y[i]) * zy));

                if (rect.Height < float.Epsilon)
                    rect.Height += float.Epsilon;

                LinearGradientBrush lgb = new LinearGradientBrush(rect,
                    penColor, Color.FromKnownColor(KnownColor.ControlDark), 75);

                g.FillRectangle(lgb, rect);
            }
        }

        private void DrawPolygon(Graphics g, float zoom_x, float zoom_y)
        {
            DrawAxes(g, zoom_x, zoom_y);

            PointF[] polyPts = new PointF[Y.Length];
            float ptDeltaX = sz.Height / 200;
            float ptDeltaY = sz.Width / 200;

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
        }
    }
}
