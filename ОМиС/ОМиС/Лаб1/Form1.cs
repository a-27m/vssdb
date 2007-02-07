using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Лаб1
{
	public partial class Form1 : Form
	{
		GraphicsPath grPath;
		Timer timer;
		double deltaTime=0;

		public Form1()
		{
			InitializeComponent();
			grPath = new GraphicsPath(FillMode.Winding);
			timer = new Timer();
			timer.Interval = 100;
			timer.Tick += new EventHandler(timer_Tick);
		}

		void timer_Tick(object sender, EventArgs e)
		{
			if ( IsInAction )
				deltaTime += timer.Interval;
			else
				deltaTime = 0;
			Refresh();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawPath(Pens.Black, grPath);
			Font font = new Font(FontFamily.GenericSansSerif, 20f);			
			e.Graphics.DrawString(
				string.Format("{0:F2}",GetPathLength()/deltaTime),
				font,
				Brushes.Black,
				new PointF(0,0));
		}

		private int mx = 0, my = 0;
		private bool IsInAction;

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if ( !IsInAction )
			{
				grPath.Reset();
				mx = e.X;
				my = e.Y;
				return;
			}

			if ( grPath.PointCount < 1 )
			{
				grPath.StartFigure();
				grPath.AddLine(e.X, e.Y, e.X + 1, e.Y + 1);
			}
			grPath.AddLine(mx, my, e.X, e.Y);

			mx = e.X;
			my = e.Y;

			Refresh();
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			if ( e.Button == MouseButtons.Left )
				timer.Enabled = (IsInAction = !IsInAction);

			if ( e.Button == MouseButtons.Right )
			{
				IsInAction = false;
				timer.Enabled = false;
				deltaTime = 0;
				grPath.Reset();
				mx = e.X;
				my = e.Y;

				Refresh();
			}
		}

		protected double GetPathLength()
		{
			double len = 0;
			for ( int i = 1; i < grPath.PointCount; i++ )
			{
				PointF p1 = grPath.PathPoints[i-1];
				PointF p2 = grPath.PathPoints[i];
				len += Math.Sqrt(
					( p2.X - p1.X ) * ( p2.X - p1.X ) +
					( p2.Y - p1.Y ) * ( p2.Y - p1.Y ));
			}
			return len;
		}
	}
}