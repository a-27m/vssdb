using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace DekartGraphic
{
    public delegate double DoubleFunction(double x);

    public enum DrawModes
    {
        DrawLines,
        DrawPoints,
        DrawFilledPolygon
    }

    public class MathGraphic
    {

        [Serializable()]
        public struct ColorSchema
        {
            public Color backgroundColor;
            public Color gridColor;
            public Color axesColor;
            public Color textColor;

            public static ColorSchema BlackAndWhite
            {
                get
                {
                    ColorSchema cs;
                    cs.axesColor = Color.Black;
                    cs.backgroundColor = Color.White;
                    cs.gridColor = Color.Gray;
                    cs.textColor = Color.Black;
                    return cs;
                }
            }
            public static ColorSchema Default
            {
                get
                {
                    ColorSchema cs;
                    cs.axesColor = Color.Black;
                    cs.backgroundColor = Color.BlanchedAlmond;
                    cs.gridColor = Color.FromArgb(0, 0, 180);
                    cs.textColor = Color.Black;
                    return cs;
                }
            }

            public ColorSchema(Color backgroundColor, Color gridColor,
                Color axesColor, Color textColor)
            {
                this.axesColor = axesColor;
                this.backgroundColor = backgroundColor;
                this.gridColor = gridColor;
                this.textColor = textColor;
            }
        }

        protected ColorSchema m_CurrentColorSchema = ColorSchema.Default;
        public ColorSchema CurrentColorSchema
        {
            get
            {
                return m_CurrentColorSchema;
            }
            set
            {
                m_CurrentColorSchema.axesColor = value.axesColor;
                m_CurrentColorSchema.backgroundColor = value.backgroundColor;
                m_CurrentColorSchema.gridColor = value.gridColor;
                m_CurrentColorSchema.textColor = value.textColor;
            }
        }

        protected PointF[][] graphic;
        private bool tabulated = false;

        private DrawModes drawingMode = DrawModes.DrawPoints;
        public DrawModes DrawingMode
        {
            get
            {
                return drawingMode;
            }
            set
            {
                drawingMode = value;
            }
        }

        Color penColor;
        public Color PenColor
        {
            get
            {
                return penColor;
            }
            set
            {
                penColor = value;
            }
        }

        float penWidth = 0;
        public float PenWidth
        {
            get
            {
                return penWidth;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                penWidth = value;
            }
        }

        public MathGraphic(Color PenColor, DrawModes drawMode,
            DoubleFunction f, float x1, float x2, float StepX)
        {
            this.penColor = PenColor;
            this.penWidth = 1f;

            this.drawingMode = drawMode;

            graphic = Tabulate(f, x1, x2, StepX);

            tabulated = true;
        }

        public MathGraphic(Color PenColor, DrawModes drawMode,
            DoubleFunction fx, DoubleFunction fy, float T1, float T2, float StepT)
        {
            this.penColor = PenColor;
            this.penWidth = 1f;

            this.drawingMode = drawMode;

            graphic = Tabulate(fx, fy, T1, T2, StepT);

            tabulated = true;
        }

        public MathGraphic(PointF[] pts)
        {
            graphic = new PointF[1][];
            graphic[0] = pts;

            tabulated = true;
        }

        public void Draw(GTranslator gt)
        {
            Draw(gt, true);
        }
        public void Draw(GTranslator gt, bool EraseBkGnd)
        {
            if (!tabulated)
                return; // ?

            if (EraseBkGnd)
            {
                gt.Clear(CurrentColorSchema.backgroundColor);
            }

            DrawCoordinateSystem(gt);
            DrawGraphic(gt);
        }
        public virtual void DrawGraphic(GTranslator gt)
        {
            float m_zoom = gt.zoom.X;
            Pen pen = new Pen(penColor, penWidth / m_zoom);

            //g.SmoothingMode = SmoothingMode.HighQuality;

            switch (drawingMode)
            {
                    /*
                case DrawModes.DrawLines:
                        #region For each ( PointF[] segment in graphic ) check visibility and draw
                        foreach (PointF[] segment in graphic)
                        {
                            for (int i = 0; i < segment.Length - 1; i++)
                            {
                                PointF pt1 = segment[i];
                                PointF pt2 = segment[i + 1];

                                if (g.ClipBounds.Left > pt1.X)
                                    pt1.X = g.ClipBounds.Left;

                                if (g.ClipBounds.Right < pt1.X)
                                    pt1.X = g.ClipBounds.Right;

                                if (g.ClipBounds.Top > pt1.Y)
                                    pt1.Y = g.ClipBounds.Top;

                                if (g.ClipBounds.Bottom < pt1.Y)
                                    pt1.Y = g.ClipBounds.Bottom;

                                if (g.ClipBounds.Left > pt2.X)
                                    pt2.X = g.ClipBounds.Left;

                                if (g.ClipBounds.Right < pt2.X)
                                    pt2.X = g.ClipBounds.Right;

                                if (g.ClipBounds.Top > pt2.Y)
                                    pt2.Y = g.ClipBounds.Top;

                                if (g.ClipBounds.Bottom < pt2.Y)
                                    pt2.Y = g.ClipBounds.Bottom;

                                g.DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
                            }
                        }
                        #endregion
                    break;
                */
                case DrawModes.DrawPoints:
                    float dotWidth = pen.Width;
                    foreach (PointF[] segment in graphic)
                        for (int i = 0; i < segment.Length; i++)
                            gt.DrawEllipse(pen,
                                segment[i].X - dotWidth / 2f, segment[i].Y - dotWidth / 2f,
                                dotWidth, dotWidth);
                    break;

                case DrawModes.DrawFilledPolygon:
                    SolidBrush brush = new SolidBrush(pen.Color);
                    Pen pen1 = (Pen)pen.Clone();
                    pen1.Width = 2f / m_zoom;
                    foreach (PointF[] segment in graphic)
                    {
                        if (segment.Length < 2)
                            continue;
                        gt.FillPolygon(brush, segment);
                        
                        gt.DrawPolygon(pen1, segment);
                    }
                    break;
            }
        }
        public virtual void DrawCoordinateSystem(GTranslator gt)
        {
            float m_zoom_x = gt.zoom.X;
            float m_zoom_y = gt.zoom.Y;
            float ox = gt.Ox;
            float oy = gt.Oy;

            Pen GridPen = new Pen(CurrentColorSchema.gridColor, 0f);
            GridPen.DashStyle = DashStyle.Solid;

            Pen AxePen = new Pen(CurrentColorSchema.axesColor,
                2 / (m_zoom_x > m_zoom_y ?
                m_zoom_y : m_zoom_x));

            StringFormat stringFormatX = new StringFormat();
            StringFormat stringFormatY = new StringFormat();
            stringFormatX.LineAlignment = StringAlignment.Center;
            stringFormatY.LineAlignment = StringAlignment.Center;
            stringFormatX.Alignment = StringAlignment.Far;
            //stringFormatX.FormatFlags = StringFormatFlags..DirectionVertical;

            Font font = new Font("Arial",
                8 / (m_zoom_x + m_zoom_y) * 2, FontStyle.Regular);


            //gt.ScaleTransform(1, -1);

            float x1, x2, y1, y2;

            x1 = gt.VisibleClipBounds.Left;
            x2 = gt.VisibleClipBounds.Right;
            y1 = gt.VisibleClipBounds.Top;
            y2 = gt.VisibleClipBounds.Bottom;

            #region Grid and text

            float dx = 30f / m_zoom_x, dy = 30f / m_zoom_y;// шаг сетки

            float textX = -(ox - 3) / m_zoom_x;
            float textY = -oy / m_zoom_y + gt.VisibleClipBounds.Height;

            for (float x = (float)(int)Math.Ceiling(x1 / dx) * dx; x < x2; x += dx)
            {
                string label = x.ToString("#0.###");
                gt.DrawLine(GridPen, x, y1, x, y2);
                gt.DrawString(label, font, Color.Black,
                    new PointF(x, textY), stringFormatX);
            }

            for (float y = (float)(int)Math.Ceiling(y1 / dy) * dy; y < y2; y += dy)
            {
                gt.DrawString((-y).ToString("#0.####"), font, Color.Black,
                   new PointF(textX, y), stringFormatY);
                gt.DrawLine(GridPen, x1, y, x2, y);
            }

            #endregion

            #region Axes
            gt.DrawLine(AxePen, x1, 0, x2, 0);
            gt.DrawLine(AxePen, x2 - 10 / m_zoom_x, 0 - 3 / m_zoom_y, x2, 0);
            gt.DrawLine(AxePen, x2 - 10 / m_zoom_x, 0 + 3 / m_zoom_y, x2, 0);

            gt.DrawLine(AxePen, 0, y1, 0, y2);
            gt.DrawLine(AxePen, 0, y1, 0 - 3 / m_zoom_x, y1 + 10 / m_zoom_y);
            gt.DrawLine(AxePen, 0, y1, 0 + 3 / m_zoom_x, y1 + 10 / m_zoom_y);

            AxePen.Width = 0;
            gt.DrawLine(AxePen, x1, y2 - 1 / m_zoom_y, x2, y2 - 1f / m_zoom_y);
            gt.DrawLine(AxePen, x1, y1, x1, y2);
            #endregion

            //g.ScaleTransform(1, -1);
        }

        public static PointF[][] Tabulate(DoubleFunction fx, DoubleFunction fy,
            float T1, float T2, float StepT)
        {
            if (StepT < float.Epsilon)
                throw new ArgumentOutOfRangeException("StepT", "Step is too small");
            if (fx == null)
                throw new ArgumentNullException("fx");
            if (fy == null)
                throw new ArgumentNullException("fy");

            float dt = StepT;
            float x, y;

            List<PointF> pts = new List<PointF>();
            List<PointF[]> grAsList = new List<PointF[]>();

            int i = 0;
            for (float t = T1; t <= T2; t += dt, i++)
            {
                try
                {
                    x = (float)fx(t);
                    y = (float)fy(t);

                    if ((x > int.MaxValue) || (x < int.MinValue))
                        throw new ArithmeticException();
                    if (float.IsInfinity(x) || float.IsNaN(x))
                        throw new ArithmeticException();

                    if ((y > int.MaxValue) || (y < int.MinValue))
                        throw new ArithmeticException();
                    if (float.IsInfinity(y) || float.IsNaN(y))
                        throw new ArithmeticException();
                }
                catch (ArithmeticException)
                {
                    if (pts.Count > 0)
                    {
                        grAsList.Add(pts.ToArray());
                        pts.Clear();
                    }
                    continue;
                }

                pts.Add(new PointF(x, y));
            }
            if (pts.Count > 0)
                grAsList.Add(pts.ToArray());

            return grAsList.ToArray();
        }

        public static PointF[][] Tabulate(DoubleFunction fy,
            float LeftXBound, float RightXBound, float StepX)
        {
            return Tabulate(delegate(double x)
            {
                return x;
            }, fy,
                LeftXBound, RightXBound, StepX);
        }
    }

    public struct PointF
    {
        float x, y;

        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }

        public PointF(float x, float y) { this.x = x; this.y = y; }
    }

    public class Zoom
    {
        public const float zoomStepFactor = 1.25f;
        protected const float max_zoom_x = 40000f;
        protected const float max_zoom_y = 40000f;
        protected const float min_zoom_x = float.Epsilon;
        protected const float min_zoom_y = float.Epsilon;

        protected float zoom_x, zoom_y;

        public float X
        {
            get { return zoom_x; }
            set
            {
                if ((value < max_zoom_x) &&
                    (value > min_zoom_x))
                    zoom_x = value;
            }
        }

        public float Y
        {
            get { return zoom_y; }
            set
            {
                if ((value < max_zoom_y) &&
                    (value > min_zoom_y))
                    zoom_y = value;
            }
        }

        public float XY
        {
            set { X = Y = value; }
        }

        public Zoom()
        { zoom_x = 1f; zoom_y = 1f; }

        public Zoom(float X, float Y)
        { zoom_x = X; zoom_y = Y; }

        public void ZoomIn()
        {
            X *= zoomStepFactor;
            Y *= zoomStepFactor;
        }

        public void ZoomOut()
        {
            X /= zoomStepFactor;
            Y /= zoomStepFactor;
        }
    }

    public class GTranslator
    {
        public Graphics g;
        public Zoom zoom;
        float ox, oy;

        public float Ox
        {
            get { return ox; }
            set { ox = value; }
        }

        public float Oy
        {
            get { return oy; }
            set { oy = value; }
        }


        internal void Clear(Color color)
        {
            g.Clear(color);
        }

        internal void DrawEllipse(Pen pen, float x, float y, float dotWidthX, float dotWidthY)
        {

            g.DrawEllipse(pen, x1, y1, dotWidth1, dotWidth1);
        }

        internal void FillPolygon(SolidBrush brush, PointF[] segment)
        {
            throw new NotImplementedException();
        }

        internal void DrawPolygon(Pen pen1, PointF[] segment)
        {
            throw new NotImplementedException();
        }

        public Rectangle VisibleClipBounds
        {
            get { throw new NotImplementedException(); }
        }

        internal void DrawLine(Pen GridPen, float x, float y1, float x_4, float y2)
        {
            throw new NotImplementedException();
        }

        internal void DrawString(string label, Font font, Color color, PointF pointF, StringFormat stringFormatX)
        {
            throw new NotImplementedException();
        }
    }
}