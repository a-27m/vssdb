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
    }

    class MathGraphic
    {
        protected List<PointF[]> graphic;

        private bool tabulated = false;

        public DrawModes DrawMode = DrawModes.DrawPoints;

        protected DoubleFunction f;

        float l, r;

        int n;

        Color penColor;

        public Color PenColor
        {
            get { return penColor; }
            set { penColor = value; }
        }

        public float LeftBound
        {
            get
            {
                return l;
            }
            set
            {
                l = value;
                Step = 0.001f;
                tabulated = false;
            }
        }

        public float RightBound
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
                Step = 0.001f;
                tabulated = false;
            }
        }

        public float Step
        {
            get
            {
                return (r - l) / n;
            }
            set
            {
                if (value > float.Epsilon)
                {
                    n = (int)((r - l) / value);
                }
            }
        }

        public MathGraphic(DoubleFunction fn)
        {
            n = 100;
            f = fn;
            tabulated = false;
        }

        public void Draw(Graphics g)
        {
            Draw(g, true);
        }

        public virtual void Draw(Graphics g, bool EraseBkGnd)
        {
            if (!tabulated)
                return;
            if (EraseBkGnd)
            {
                g.Clear(Color.Azure);
            }
            //rect = g.VisibleClipBounds;
            DrawCoordinateSystem(g);
            DrawGraphic(g);//new Pen(Brushes.Red, 0f)
            //g.ResetTransform();
        }

        //private void draw_graphic(Graphics g, Pen pen)
        //{
        //    switch (DrawMode)
        //    {
        //        case DrawModes.DrawLines:
        //            foreach (PointF[] segment in graphic)
        //            {
        //                for (int i = 0; i < segment.Length - 1; i++)
        //                {
        //                    if (g.IsVisible(segment[i]) &&
        //                        g.IsVisible(segment[i + 1]))
        //                        g.DrawLine(pen, segment[i], segment[i + 1]);
        //                }
        //            }
        //            break;

        //        case DrawModes.DrawPoints:
        //            float dotWidth = 0.7f / m_zoom;
        //            foreach (PointF[] segment in graphic)
        //                for (int i = 0; i < segment.Length; i++)
        //                    g.DrawEllipse(pen,
        //                        segment[i].X, segment[i].Y,
        //                        dotWidth, dotWidth);
        //            break;
        //    }
        //}

        //private void draw_axes(Graphics g)
        //{
        //    Pen GridPen = new Pen(Color.FromArgb(180, Color.Blue), 0f);
        //    GridPen.DashStyle = DashStyle.Solid;

        //    Pen AxePen = new Pen(Brushes.Black, 2 / m_zoom);

        //    StringFormat stringFormatX = new StringFormat();
        //    StringFormat stringFormatY = new StringFormat();
        //    stringFormatX.LineAlignment = StringAlignment.Center;
        //    stringFormatY.LineAlignment = StringAlignment.Center;
        //    stringFormatX.FormatFlags = StringFormatFlags.DirectionVertical;

        //    Font font = new Font("Arial", 8 / m_zoom);

        //    g.ScaleTransform(1, -1);

        //    #region Grid

        //    float x1, x2, y1, y2;
        //    x1 = g.VisibleClipBounds.Left;
        //    x2 = g.VisibleClipBounds.Right;
        //    y1 = g.VisibleClipBounds.Top;
        //    y2 = g.VisibleClipBounds.Bottom;

        //    float dx = 30f / m_zoom, dy = 30f / m_zoom;// шаг сетки

        //    for (float x = (int)((x1 - O.X) / dx) * dx; x < x2; x += dx)
        //    {
        //        g.DrawLine(GridPen, x, y1, x, y2);
        //        g.DrawString(x.ToString("#0.####"), font, Brushes.Black,
        //            new PointF(x, font.GetHeight() / 2), stringFormatX);
        //    }

        //    for (float y = (int)((y1 - O.Y) / dy) * dy; y < y2; y += dy)
        //    {
        //        g.DrawString((-y).ToString("#0.####"), font, Brushes.Black,
        //            new PointF(0 + 3 / m_zoom, y), stringFormatY);
        //        g.DrawLine(GridPen, x1, y, x2, y);
        //    }
        //    #endregion

        //    #region Axes
        //    g.DrawLine(AxePen, x1, 0, x2, 0);
        //    g.DrawLine(AxePen, x2 - 30 / m_zoom, 0 - 3 / m_zoom, x2, 0);
        //    g.DrawLine(AxePen, x2 - 30 / m_zoom, 0 + 3 / m_zoom, x2, 0);

        //    g.DrawLine(AxePen, 0, y1, 0, y2);
        //    g.DrawLine(AxePen, 0, y2, 0 - 3 / m_zoom, y2 - 10 / m_zoom);
        //    g.DrawLine(AxePen, 0, y2, 0 + 3 / m_zoom, y2 - 10 / m_zoom);
        //    #endregion

        //    g.ScaleTransform(1, -1);
        //}

        public void DrawGraphic(Graphics g)
        {
            Pen pen = new Pen(penColor, 0f);
            float m_zoom = g.Transform.Elements[0];
            // g.Transform = new Matrix(m_zoom, 0f, 0f, -m_zoom, O.X, O.Y);
            g.SmoothingMode = SmoothingMode.HighQuality;

            switch (DrawMode)
            {
                case DrawModes.DrawLines:
                    foreach (PointF[] segment in graphic)
                    {
                        for (int i = 0; i < segment.Length - 1; i++)
                        {
                            if (g.IsVisible(segment[i]) &&
                                g.IsVisible(segment[i + 1]))
                                g.DrawLine(pen, segment[i], segment[i + 1]);
                        }
                    }
                    break;

                case DrawModes.DrawPoints:
                    float dotWidth = 0.7f / m_zoom;
                    foreach (PointF[] segment in graphic)
                        for (int i = 0; i < segment.Length; i++)
                            g.DrawEllipse(pen,
                                segment[i].X, segment[i].Y,
                                dotWidth, dotWidth);
                    break;
            }
        }

        public void DrawCoordinateSystem(Graphics g)
        {
            g.Clear(Color.AntiqueWhite);
            g.SmoothingMode = SmoothingMode.HighQuality;

            float m_zoom = g.Transform.Elements[0];
            //float ox = g.Transform.Elements[4];
            //ox = g.Transform.OffsetX;

            Pen GridPen = new Pen(Color.FromArgb(180, Color.Blue), 0f);
            GridPen.DashStyle = DashStyle.Solid;

            Pen AxePen = new Pen(Brushes.Black, 2 / m_zoom);

            StringFormat stringFormatX = new StringFormat();
            StringFormat stringFormatY = new StringFormat();
            stringFormatX.LineAlignment = StringAlignment.Center;
            stringFormatY.LineAlignment = StringAlignment.Center;
            stringFormatX.FormatFlags = StringFormatFlags.DirectionVertical;

            Font font = new Font("Arial", 8 / m_zoom);


            g.ScaleTransform(1, -1);

            float x1, x2, y1, y2;
            x1 = g.VisibleClipBounds.Left;
            x2 = g.VisibleClipBounds.Right;
            y1 = g.VisibleClipBounds.Top;
            y2 = g.VisibleClipBounds.Bottom;

            #region Grid

            float dx = 30f / m_zoom, dy = 30f / m_zoom;// шаг сетки

            for (float x = 0; x < x2; x += dx)
            {
                g.DrawLine(GridPen, x, y1, x, y2);
                g.DrawString(x.ToString("#0.###"), font, Brushes.Black,
                    new PointF(x, font.GetHeight() / 2), stringFormatX);
            }
            for (float x = 0; x > x1; x -= dx)
            {
                g.DrawLine(GridPen, x, y1, x, y2);
                g.DrawString(x.ToString("#0.###"), font, Brushes.Black,
                    new PointF(x, font.GetHeight() / 2), stringFormatX);
            }

            for (float y = 0; y < y2; y += dy)
            {
                g.DrawLine(GridPen, x1, y, x2, y);
                g.DrawString((-y).ToString("#0.###"), font, Brushes.Black,
                    new PointF(0 + 3 / m_zoom, y), stringFormatY);
            }
            for (float y = 0; y > y1; y -= dy)
            {
                g.DrawLine(GridPen, x1, y, x2, y);
                g.DrawString((-y).ToString("#0.###"), font, Brushes.Black,
                    new PointF(0 + 3 / m_zoom, y), stringFormatY);
            }
            //for (float y = (int)(y1 / dy) * dy; y < y2; y += dy)
            //{
            //    g.DrawString((-y).ToString("#0.####"), font, Brushes.Black,
            //       new PointF(0 + 3 / m_zoom, y), stringFormatY);
            //    g.DrawLine(GridPen, x1, y, x2, y);
            //}
            #endregion

            #region Axes
            g.DrawLine(AxePen, x1, 0, x2, 0);
            g.DrawLine(AxePen, x2 - 10 / m_zoom, 0 - 3 / m_zoom, x2, 0);
            g.DrawLine(AxePen, x2 - 10 / m_zoom, 0 + 3 / m_zoom, x2, 0);

            g.DrawLine(AxePen, 0, y1, 0, y2);
            g.DrawLine(AxePen, 0, y1, 0 - 3 / m_zoom, y1 + 10 / m_zoom);
            g.DrawLine(AxePen, 0, y1, 0 + 3 / m_zoom, y1 + 10 / m_zoom);
            #endregion

            g.ScaleTransform(1, -1);
        }

        public void Tabulate()
        {
            tabulated = false;
            float dx = Step;
            float y;
            int i = 0;

            List<PointF> pts = new List<PointF>();
            graphic = new List<PointF[]>();

            for (float x = LeftBound; i < n; x += dx, i++)
            {
                try
                {
                    y = (float)f(x);
                    if ((y > int.MaxValue) || (y < int.MinValue))
                        throw new ArithmeticException();
                    if (float.IsInfinity(y) || float.IsNaN(y))
                        throw new ArithmeticException();
                }
                catch (ArithmeticException)
                {
                    if (pts.Count > 0)
                    {
                        graphic.Add(pts.ToArray());
                        pts.Clear();
                    }
                    continue;
                }

                pts.Add(new PointF(x, y));
            }
            if (pts.Count > 0)
                graphic.Add(pts.ToArray());
            tabulated = true;
        }

        public double DistanceInSqr(float x1, float y1, float x2, float y2)
        {
            return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
        }
    }
}


