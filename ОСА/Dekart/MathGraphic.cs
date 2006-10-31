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

	public class MathGraphic
	{
		public bool Use_IsVisible = true;
		protected PointF[][] graphic;
		private bool tabulated = false;

		private DrawModes drawingMode = DrawModes.DrawPoints;
		public DrawModes DrawingMode
		{
			get { return drawingMode; }
			set { drawingMode = value; }
		}

		Color penColor;
		public Color PenColor
		{
			get { return penColor; }
			set { penColor = value; }
		}

		float penWidth = 0;
		public float PenWidth
		{
			get { return penWidth; }
			set { penWidth = value; }
		}

		public MathGraphic(Color PenColor, DrawModes drawMode,
			DoubleFunction f, float x1, float x2, float StepX)
		{
			this.penColor = PenColor;
			this.drawingMode = drawMode;

			graphic = Tabulate(f, x1, x2, StepX);
		}

		public MathGraphic(Color PenColor, DrawModes drawMode,
			DoubleFunction fx, DoubleFunction fy, float T1, float T2, float StepT)
		{
			this.penColor = PenColor;
			this.drawingMode = drawMode;

			graphic = Tabulate(fx, fy, T1, T2, StepT);
		}

		public MathGraphic(PointF[] pts)
		{
			graphic = new PointF[1][];
			graphic[0] = pts;
		}
		public void Draw(Graphics g)
		{
			Draw(g, true);
		}
		public virtual void Draw(Graphics g, bool EraseBkGnd)
		{
			if ( !tabulated )
				return;

			if ( EraseBkGnd )
			{
				g.Clear(Color.Azure);
			}

			DrawCoordinateSystem(g);
			DrawGraphic(g);
		}
		public void DrawGraphic(Graphics g)
		{
			Pen pen = new Pen(penColor, penWidth);
			float m_zoom = g.Transform.Elements[0];

			g.SmoothingMode = SmoothingMode.HighQuality;

			switch ( drawingMode )
			{
			case DrawModes.DrawLines:
				if ( !Use_IsVisible )
				{
					foreach ( PointF[] segment in graphic )
					{
						for ( int i = 0; i < segment.Length - 1; i++ )
						{
							PointF pt1 = segment[i];
							PointF pt2 = segment[i + 1];

							if ( g.ClipBounds.Left > pt1.X )
								pt1.X = g.ClipBounds.Left;

							if ( g.ClipBounds.Right < pt1.X )
								pt1.X = g.ClipBounds.Right;

							if ( g.ClipBounds.Top > pt1.Y )
								pt1.Y = g.ClipBounds.Top;

							if ( g.ClipBounds.Bottom < pt1.Y )
								pt1.Y = g.ClipBounds.Bottom;

							if ( g.ClipBounds.Left > pt2.X )
								pt2.X = g.ClipBounds.Left;

							if ( g.ClipBounds.Right < pt2.X )
								pt2.X = g.ClipBounds.Right;

							if ( g.ClipBounds.Top > pt2.Y )
								pt2.Y = g.ClipBounds.Top;

							if ( g.ClipBounds.Bottom < pt2.Y )
								pt2.Y = g.ClipBounds.Bottom;

							g.DrawLine(pen, pt1, pt2);
						}
					}
				}
				else
				{
					foreach ( PointF[] segment in graphic )
					{
						for ( int i = 0; i < segment.Length - 1; i++ )
						{
							if ( ( g.IsVisible(segment[i])
								&& ( g.IsVisible(segment[i + 1]) ) ) )
								g.DrawLine(pen, segment[i], segment[i + 1]);
						}
					}
				}
				break;

			case DrawModes.DrawPoints:
				float dotWidth = 0.7f / m_zoom;
				foreach ( PointF[] segment in graphic )
					for ( int i = 0; i < segment.Length; i++ )
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

			float m_zoom_x = Math.Abs(g.Transform.Elements[0]);
			float m_zoom_y = Math.Abs(g.Transform.Elements[3]);
			//float ox = g.Transform.Elements[4];
			//ox = g.Transform.OffsetX;

			Pen GridPen = new Pen(Color.FromArgb(180, Color.Blue), 0f);
			GridPen.DashStyle = DashStyle.Solid;

			Pen AxePen = new Pen(Brushes.Black,
				2 / ( m_zoom_x > m_zoom_y ?
				m_zoom_y : m_zoom_x ));

			StringFormat stringFormatX = new StringFormat();
			StringFormat stringFormatY = new StringFormat();
			stringFormatX.LineAlignment = StringAlignment.Center;
			stringFormatY.LineAlignment = StringAlignment.Center;
			stringFormatX.FormatFlags = StringFormatFlags.DirectionVertical;

			Font font = new Font("Arial",
				8 / ( m_zoom_x + m_zoom_y ) * 2);


			g.ScaleTransform(1, -1);

			float x1, x2, y1, y2;
			x1 = g.VisibleClipBounds.Left;
			x2 = g.VisibleClipBounds.Right;
			y1 = g.VisibleClipBounds.Top;
			y2 = g.VisibleClipBounds.Bottom;

			#region Grid

			float dx = 30f / m_zoom_x, dy = 30f / m_zoom_y;// шаг сетки

			for ( float x = 0; x < x2; x += dx )
			{
				g.DrawLine(GridPen, x, y1, x, y2);
				g.DrawString(x.ToString("#0.###"), font, Brushes.Black,
					new PointF(x, font.GetHeight() / 2), stringFormatX);
			}
			for ( float x = 0; x > x1; x -= dx )
			{
				g.DrawLine(GridPen, x, y1, x, y2);
				g.DrawString(x.ToString("#0.###"), font, Brushes.Black,
					new PointF(x, font.GetHeight() / 2), stringFormatX);
			}

			for ( float y = 0; y < y2; y += dy )
			{
				g.DrawLine(GridPen, x1, y, x2, y);
				g.DrawString(( -y ).ToString("#0.###"), font, Brushes.Black,
					new PointF(0 + 3 / m_zoom_x, y), stringFormatY);
			}
			for ( float y = 0; y > y1; y -= dy )
			{
				g.DrawLine(GridPen, x1, y, x2, y);
				g.DrawString(( -y ).ToString("#0.###"), font, Brushes.Black,
					new PointF(0 + 3 / m_zoom_x, y), stringFormatY);
			}

			//for (float y = (int)Math.Ceiling(y1 / dy) * dy; y < y2; y += dy)
			//{
			//    g.DrawString((-y).ToString("#0.####"), font, Brushes.Black,
			//       new PointF(0 + 3 / m_zoom, y), stringFormatY);
			//    g.DrawLine(GridPen, x1, y, x2, y);
			//}

			#endregion

			#region Axes
			g.DrawLine(AxePen, x1, 0, x2, 0);
			g.DrawLine(AxePen, x2 - 10 / m_zoom_x, 0 - 3 / m_zoom_y, x2, 0);
			g.DrawLine(AxePen, x2 - 10 / m_zoom_x, 0 + 3 / m_zoom_y, x2, 0);

			g.DrawLine(AxePen, 0, y1, 0, y2);
			g.DrawLine(AxePen, 0, y1, 0 - 3 / m_zoom_x, y1 + 10 / m_zoom_y);
			g.DrawLine(AxePen, 0, y1, 0 + 3 / m_zoom_x, y1 + 10 / m_zoom_y);
			#endregion

			g.ScaleTransform(1, -1);
		}

		public static PointF[][] Tabulate(DoubleFunction fx, DoubleFunction fy, float T1, float T2, float StepT)
		{
			if ( StepT < float.Epsilon )
				throw new ArgumentOutOfRangeException("StepT", "Step is too small");
			if ( fx == null )
				throw new ArgumentNullException("fx");
			if ( fy == null )
				throw new ArgumentNullException("fy");

			float dt = StepT;
			float x, y;

			List<PointF> pts = new List<PointF>();
			List<PointF[]> grAsList = new List<PointF[]>();

			int i = 0;
			for ( float t = T1; t <= T2; t += dt, i++ )
			{
				try
				{
					x = (float)fx(t);
					y = (float)fy(t);

					if ( ( x > int.MaxValue ) || ( x < int.MinValue ) )
						throw new ArithmeticException();
					if ( float.IsInfinity(x) || float.IsNaN(x) )
						throw new ArithmeticException();

					if ( ( y > int.MaxValue ) || ( y < int.MinValue ) )
						throw new ArithmeticException();
					if ( float.IsInfinity(y) || float.IsNaN(y) )
						throw new ArithmeticException();
				}
				catch ( ArithmeticException )
				{
					if ( pts.Count > 0 )
					{
						grAsList.Add(pts.ToArray());
						pts.Clear();
					}
					continue;
				}

				pts.Add(new PointF(x, y));
			}
			if ( pts.Count > 0 )
				grAsList.Add(pts.ToArray());

			return grAsList.ToArray();
		}

		public static PointF[][] Tabulate(DoubleFunction fy,
			float LeftXBound, float RightXBound, float StepX)
		{
			return Tabulate(delegate(double x) { return x; }, fy,
				LeftXBound, RightXBound, StepX);
		}
	}
}


