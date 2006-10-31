using System;
using System.Windows.Forms;
using DekartGraphic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Lab_04
{
	public partial class Form4 : Form
	{
		private enum SolutionMethod
		{
			StillPoint,
			Bisection,
			NewtoneRafson,
			Cuttings,
			Hord,
			Muller,
		}

		public Form4()
		{
			InitializeComponent();
			MaximizeBox = false;
		}

		double t = 0;

		SolutionMethod selectedSolMeth;

		#region functions

		List<double> roots = null;

		double f(double x)
		{
			// original
			return 5 * Math.Sin(x * x * x) - x;
		}

		double h(double x)
		{
			if ( roots == null )
				return f(x);

			double res = f(x);
			foreach ( double p in roots )
				res /= x - p;
			return res;
		}

		double df(double x)
		{
			// original
			return 15 * x * x * Math.Cos(x * x * x) - 1;
		}

		double d2f(double x)
		{
			// original
			return 30 * x * Math.Cos(x * x * x) - 45 * x * x * x * x * x * Math.Sin(x * x * x);
		}

		double fun(double x)
		{
			return ( Math.Abs(0.5 * Math.Cos(t)) + 0.5 ) * Math.Sin(4 * x - t) / 2;
		}

		double g(double x)
		{
			return f(x) - x;
		}

		double bisectress(double x) { return x; }

		class Parabola
		{
			double a, b;
			double ox, oy;

			public Parabola(double x1, double y1,
				double x2, double y2,
				double x3, double y3)
			{
				ox = x1;
				oy = y1;

				x2 -= ox;
				y2 -= oy;
				x3 -= ox;
				y3 -= oy;

				double det = x2 * x2 * x3 - x3 * x3 * x2;
				a = ( y2 * x3 - y3 * x2 ) / det;
				b = ( x2 * x2 * y3 - x3 * x3 * y2 ) / det;
			}

			public double Eval(double x)
			{
				x -= ox;
				return ( a * x + b ) * x + oy;
			}

		}

		#endregion

		private void RunWave_Click(object sender, EventArgs e)
		{
			DekartForm dForm = new DekartForm(150, 150, 50, 175);
			dForm.Size = new Size(800, 420);
			dForm.Text = "f(x,t) = |cos(t)|*sin(4x)";

			dForm.Show();

			int tmpID = -1;
			for ( t = 0; !dForm.IsDisposed; t += 0.1f )
			{
				if ( t > +2 * Math.PI )
					t -= 2 * (float)Math.PI;

				if ( tmpID >= 0 )
					dForm.RemoveGraphic(tmpID);
				tmpID = dForm.AddGraphic(fun, -5, 5,
					DrawModes.DrawLines, Color.Red);

				dForm.Update2();//.DrawAllGraphics();
				Application.DoEvents();
			}
		}

		private void RollStar_Click(object sender, EventArgs e)
		{
			DekartForm dForm = new DekartForm(150, 150, 180, 175);
			dForm.Size = new Size(400, 425);
			dForm.Text = "f(x) = 5sin(x^3)-x";
			dForm.Show();

			int k = 7;
			int tmpID = -1;
			int grnVal = 150;
			int grnDx = 1;
			Random rnd = new Random((int)( DateTime.Now.Ticks ));
			for ( float phi = -0.01f;
				!dForm.IsDisposed;
				phi += -0.008f )// -phi/5 for !crazy!
			{
				grnVal += ( ( grnVal < 100 ) || ( grnVal > 200 ) )
					? grnDx *= -1 : grnDx;

				if ( phi < -2 * Math.PI )
					phi += 2 * (float)Math.PI;

				int l = 0;
				PointF[] pts = new PointF[k * k];
				float r = 0.5f * (float)Math.Abs(Math.Cos(3 * phi)) + 0.5f;
				//Math.Abs(Math.Cos(t) + 0.5);
				for ( int i = 0; i < k; i++ )
				{
					PointF pti = new PointF(
						r * (float)Math.Cos(2 * i * Math.PI / k + phi),
						r * (float)Math.Sin(2 * i * Math.PI / k + phi));
					for ( int j = 0; j < i; j++ )
					{
						if ( ( j == i - 1 )
							|| ( j == 0 && i == k - 1 ) )
							continue;
						pts[l++] = pti;
						pts[l++] = new PointF(
							   r * (float)Math.Cos(2 * j * Math.PI / k + phi),
							   r * (float)Math.Sin(2 * j * Math.PI / k + phi)
							   );
					}
				}

				Array.Resize<PointF>(ref pts, l);

				Color cl = Color.FromArgb(100, grnVal, 100);

				if ( tmpID >= 0 )
					dForm.RemoveGraphic(tmpID);

				tmpID = dForm.AddPolygon(cl, 0.02f, DrawModes.DrawLines, pts);
				dForm.Update2();
				//.DrawAllGraphics();
				Application.DoEvents();
			}
		}

		private void fxItem_Click(object sender, EventArgs e)
		{
			DekartForm dForm = new DekartForm(75, 75, 320, 300);
			dForm.Size = new Size(700, 600);
			dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);
			dForm.Use_IsVisible = false;
			dForm.Show();
			dForm.Update2();
		}

		#region radioMethod CheckedChanged

		private void radioStillPt_CheckedChanged(object sender, EventArgs e)
		{
			selectedSolMeth = SolutionMethod.StillPoint;

			textP0.Enabled = true;

			//textA.Enabled =
			//    textB.Enabled =
			textP1.Enabled =
			textP2.Enabled = false;
		}

		private void radioBisection_CheckedChanged(object sender, EventArgs e)
		{
			selectedSolMeth = SolutionMethod.Bisection;

			//textA.Enabled =
			//    textB.Enabled =
			textP0.Enabled =
			textP1.Enabled =
			true;

			textP2.Enabled =
			false;
		}

		private void radioNewtone_CheckedChanged(object sender, EventArgs e)
		{
			selectedSolMeth = SolutionMethod.NewtoneRafson;

			textP0.Enabled =
				true;

			//textA.Enabled =
			//    textB.Enabled =
			textP1.Enabled =
			textP2.Enabled =
			false;
		}

		private void radioCutting_CheckedChanged(object sender, EventArgs e)
		{
			selectedSolMeth = SolutionMethod.Cuttings;

			textP0.Enabled =
			textP1.Enabled =
				true;

			//textA.Enabled =
			//    textB.Enabled =
			textP2.Enabled =
			false;
		}

		private void radioHord_CheckedChanged(object sender, EventArgs e)
		{
			selectedSolMeth = SolutionMethod.Hord;

			textP0.Enabled =
			textP1.Enabled =
				true;

			//textA.Enabled =
			//    textB.Enabled =
			textP2.Enabled =
			false;
		}

		private void radioMuller_CheckedChanged(object sender, EventArgs e)
		{
			selectedSolMeth = SolutionMethod.Muller;

			textP0.Enabled =
			textP1.Enabled =
			textP2.Enabled =
				true;

			//textA.Enabled =
			//    textB.Enabled =
			//false;
		}

		#endregion

		private void buttonSolve_Click(object sender, EventArgs e)
		{
			if ( checkAutoSearch.Checked )
			{ AutoFindRoots(); return; }

			double p0, p1, p2;
			double eps;

			errorProvider.Clear();

			try
			{ eps = float.Parse(textE.Text); }
			catch ( FormatException )
			{ errorProvider.SetError(textE, "Wrong float number"); return; }
			if ( eps < 0 )
			{
				errorProvider.SetError(textE, "Has to be > 0");
				return;
			}

			double res = double.NaN;
			DekartForm dForm = null;
			List<PointF[]> lines = null;

			switch ( selectedSolMeth )
			{
			#region Method Still Point
			case SolutionMethod.StillPoint:

				try
				{ p0 = float.Parse(textP0.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP0, "Wrong float number"); return; }

				dForm = new DekartForm(100, 100, 320, 300);
				dForm.Size = new Size(700, 500);

				dForm.AddGraphic(g, -5f, 5f, DrawModes.DrawLines, Color.Green);
				dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Gray);
				dForm.AddGraphic(bisectress, -5f, 5f, DrawModes.DrawLines, Color.Blue);

				res = FindRoot.StillPointMethod(f, p0, eps, out lines, false);
				break;
			#endregion

			#region Method Bisection
			case SolutionMethod.Bisection:
				try
				{ p0 = float.Parse(textP0.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP0, "Wrong float number"); return; }
				try
				{ p1 = float.Parse(textP1.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP1, "Wrong float number"); return; }

				dForm = new DekartForm(100, 100, 175, 300);
				dForm.Use_IsVisible = false;
				dForm.Size = new Size(350, 600);

				dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);

				res = FindRoot.Bisection(f, p0, p1, eps, out lines, false);
				break;

			#endregion

			#region Method Newtone-Rafson
			case SolutionMethod.NewtoneRafson:
				try
				{ p0 = float.Parse(textP0.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP0, "Wrong float number"); return; }

				dForm = new DekartForm(100, 100, 300, 300);
				dForm.Size = new Size(750, 600);
				dForm.Use_IsVisible = false;

				dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);

				res = FindRoot.NewtoneRafson(f, df, p0, eps, out lines, false);
				break;

			#endregion

			#region Method Cuttings
			case SolutionMethod.Cuttings:
				try
				{ p0 = float.Parse(textP0.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP0, "Wrong float number"); return; }
				try
				{ p1 = float.Parse(textP1.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP1, "Wrong float number"); return; }

				dForm = new DekartForm(100, 100, 300, 300);
				dForm.Size = new Size(750, 600);
				dForm.Use_IsVisible = false;

				dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);

				res = FindRoot.Cuttings(f, p0, p1, eps, out lines, false);
				break;

			#endregion

			#region Method Hord
			case SolutionMethod.Hord:
				try
				{ p0 = float.Parse(textP0.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP0, "Wrong float number"); return; }
				try
				{ p1 = float.Parse(textP1.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP1, "Wrong float number"); return; }

				dForm = new DekartForm(100, 100, 300, 300);
				dForm.Size = new Size(750, 600);
				dForm.Use_IsVisible = false;

				dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);

				res = FindRoot.Hord(f, d2f, p0, p1, eps, out lines, false);

				break;

			#endregion

			#region Method Muller
			case SolutionMethod.Muller:
				try
				{ p0 = float.Parse(textP0.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP0, "Wrong float number"); return; }
				try
				{ p1 = float.Parse(textP1.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP1, "Wrong float number"); return; }
				try
				{ p2 = float.Parse(textP2.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textP2, "Wrong float number"); return; }

				dForm = new DekartForm(100, 100, 300, 300);
				dForm.Size = new Size(750, 600);
				dForm.Use_IsVisible = false;

				dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);

				res = FindRoot.Muller(f, p0, p1, p2, eps, ref dForm, false);

				lines = null;
				break;
			#endregion

			default:
				return;
			}

			#region Print results

			if ( lines != null )
			{
				foreach ( PointF[] pts in lines )
				{ dForm.AddPolygon(Color.Red, DrawModes.DrawLines, pts); }
			}
			dForm.Show();
			dForm.Update2();

			listRoots.Items.Clear();
			listY.Items.Clear();

			if ( double.IsNaN(res) )
			{
				MessageBox.Show("Корни не найдены.");
				return;
			}

			listRoots.Items.Add("x" + ( listRoots.Items.Count + 1 ) + " = "
				+ res.ToString("F16"));
			listY.Items.Add("y" + ( listY.Items.Count + 1 ) + " = "
				+ f(res).ToString("F16"));
			#endregion
		}

		private void AutoFindRoots()
		{
			float x1, x2;
			double eps;

			errorProvider.Clear();

			try
			{ eps = float.Parse(textE.Text); }
			catch ( FormatException )
			{ errorProvider.SetError(textE, "Wrong float number"); return; }
			if ( eps < 0 ) { errorProvider.SetError(textE, "Has to be > 0"); return; }

			try
			{ x1 = float.Parse(textX1.Text); }
			catch ( FormatException )
			{ errorProvider.SetError(textX1, "Wrong float number"); return; }

			try
			{ x2 = float.Parse(textX2.Text); }
			catch ( FormatException )
			{ errorProvider.SetError(textX2, "Wrong float number"); return; }

			float step = ( x2 - x1 ) / 100f;

			DekartForm dForm;
			dForm = new DekartForm(100, 100, 175, 300);
			dForm.Use_IsVisible = false;
			dForm.Size = new Size(350, 600);
			dForm.CenterView();

			listRoots.Items.Clear();
			listY.Items.Clear();

			roots = new List<double>();

			for ( float x = x1; x < x2; x += step )
			{
				double res = double.NaN;
				List<PointF[]> lines = null;

				switch ( selectedSolMeth )
				{
				#region Method Still Point
				case SolutionMethod.StillPoint:
					if ( dForm.CountGraphics == 0 )
					{
						dForm.AddGraphic(g, -5f, 5f,
							DrawModes.DrawLines, Color.Green);
						dForm.AddGraphic(f, -5f, 5f,
							DrawModes.DrawLines, Color.Gray);
						dForm.AddGraphic(bisectress, -5f, 5f,
							DrawModes.DrawLines, Color.Blue);
					}

					res = FindRoot.StillPointMethod(h, x, eps, out lines, true);
					break;
				#endregion

				#region Method Bisection
				case SolutionMethod.Bisection:
					if ( dForm.CountGraphics == 0 )
						dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);

					res = FindRoot.Bisection(h, x, x + step, eps, out lines, true);
					break;
				#endregion

				//#region Method Newtone-Rafson
				//case SolutionMethod.NewtoneRafson:
				//    MessageBox.Show("How to evaluate dh/dx?");
				//    return;
				//    if ( dForm.CountGraphics == 0 )

				//        dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);

				//    res = FindRoot.NewtoneRafson(f, df, x, eps, out lines);
				//    break;

				//#endregion

				#region Method Cuttings
				case SolutionMethod.Cuttings:
					if ( dForm.CountGraphics == 0 )
						dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);
					res = FindRoot.Cuttings(h, x, x + step, eps, out lines, true);
					break;
				#endregion

				//#region Method Hord
				//case SolutionMethod.Hord:
				//    if ( dForm.CountGraphics == 0 )
				//        dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);
				//    res = FindRoot.Hord(f, d2f, x, x + step, eps, out lines);
				//    break;
				//#endregion

				#region Method Muller
				case SolutionMethod.Muller:
					if ( dForm.CountGraphics == 0 )
						dForm.AddGraphic(f, -5f, 5f, DrawModes.DrawLines, Color.Green);

					res = FindRoot.Muller(h, x - step, x, x + step, eps, ref dForm, true);
					lines = null;
					break;
				#endregion
				default:
					return;

				}

				if ( lines != null )
				{
					foreach ( PointF[] pts in lines )
					{ dForm.AddPolygon(Color.Red, DrawModes.DrawLines, pts); }
				}

				if ( double.IsNaN(res) )
				{ continue; }
				if ( ( res > x2 ) || ( res < x1 ) )
				{ continue; }

				roots.Add(res);
			}
			roots.Sort();
			foreach ( double p in roots )
			{
				listRoots.Items.Add("x" + ( listRoots.Items.Count + 1 ) + " = "
					+ p.ToString("F16"));
				listY.Items.Add("y" + ( listY.Items.Count + 1 ) + " = "
					+ f(p).ToString("F16"));
			}

			dForm.Show();
			dForm.Update2();
		}

		public class FindRoot
		{
			public static double StillPointMethod(DoubleFunction f,
				double p0, double eps, out List<PointF[]> lines, bool silent)
			{
				double p_prev;

				int stepsMaden = 0;

				lines = new List<PointF[]>();

				lines.Add(new PointF[] {
                    new PointF((float)p0, 0),
                    new PointF((float)p0, (float)(f(p0)-p0))}
					);

				do
				{
					p_prev = p0;
					p0 = f(p0) - p0;// ==g
					stepsMaden++;

					lines.Add(new PointF[] {
                        new PointF((float)p_prev, 0),
                        new PointF((float)p_prev, (float)p0),
                        new PointF((float)p0, (float)p0),
                        new PointF((float)p0, 0)});

					if ( stepsMaden % 100 == 0 )
					{
						if ( silent )
							return double.NaN;

						if ( MessageBox.Show("Performed " + stepsMaden.ToString()
							+ " steps, continue?", "Разошлось наверно?",
							MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
							MessageBoxDefaultButton.Button1) != DialogResult.OK )
						{
							return double.NaN;
						}
					}
				}
				while ( Math.Abs(p0 - p_prev) >= eps );

				return p0;
			}

			public static void AddAB(ref List<PointF[]> lines, double a, double b)
			{
				lines.Add(new PointF[] {
                    new PointF((float)a, -littleThingHeight),
                    new PointF((float)a, +littleThingHeight)});

				lines.Add(new PointF[] {
                    new PointF((float)b, -littleThingHeight),
                    new PointF((float)b, +littleThingHeight)});
			}

			public static float littleThingHeight = 0.05f;

			public static double Bisection(DoubleFunction f,
				double a, double b, double eps, out List<PointF[]> lines, bool silent)
			{
				if ( Math.Sign(f(a)) == Math.Sign(f(b)) )
				{
					if ( !silent )
						MessageBox.Show("Root is not localized well, "
						+ "function signs equal on th e both of interval ends");
					lines = null;
					return double.NaN;
				}

				int stepsMaden = 0;

				lines = new List<PointF[]>();

				AddAB(ref lines, a, b);

				double c;
				do
				{
					c = ( a + b ) / 2.0;
					if ( Math.Sign(f(a)) != Math.Sign(f(c)) )
						b = c;
					else
						a = c;

					AddAB(ref lines, a, b);

					stepsMaden++;
					if ( stepsMaden % 100 == 0 )
					{
						if ( silent )
							return double.NaN;
						if ( MessageBox.Show("Performed " + stepsMaden.ToString()
							+ " steps, continue?", "Что-то не то...",
							MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
							MessageBoxDefaultButton.Button1) != DialogResult.OK )
						{
							return double.NaN;
						}
					}
				}
				while ( ( Math.Abs(a - b) >= eps )
					&& ( f(c) != 0 ) );

				return c;
			}

			public static double NewtoneRafson(DoubleFunction f, DoubleFunction df,
				double p0, double eps, out List<PointF[]> lines, bool silent)
			{
				double p_prev;

				int stepsMaden = 0;

				lines = new List<PointF[]>();

				do
				{
					p_prev = p0;

					p0 = p0 - f(p0) / df(p0); //p0 = gNR(p0);

					stepsMaden++;

					lines.Add(new PointF[] {
                        new PointF((float)p_prev, (float)f(p_prev)),
                        new PointF((float)p0, 0)}
						);

					if ( stepsMaden % 100 == 0 )
					{
						if ( silent )
							return double.NaN;

						if ( MessageBox.Show("Performed " + stepsMaden.ToString()
							+ " steps, continue?", "Разошлось наверно?",
							MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
							MessageBoxDefaultButton.Button1) != DialogResult.OK )
						{
							return Double.NaN;
						}
					}
				}
				while ( ( Math.Abs(p0 - p_prev) >= eps ) &&
					( Math.Abs(f(p0)) > eps ) );

				return p0;
			}

			public static double Hord(DoubleFunction f, DoubleFunction d2f,
				double p0, double p1, double eps, out List<PointF[]> lines, bool silent)
			{
				double p2, c;

				int stepsMaden = 0;

				lines = new List<PointF[]>();

				if ( Math.Sign(p0) != Math.Sign(d2f(p0)) )
				{ c = p0; p2 = p1; }
				else
				{ c = p1; p2 = p0; }

				do
				{
					p1 = p2;
					//p2 = gCut(p0, p1);
					p2 = p1 - f(p1) * ( p1 - c ) /
						( f(p1) - f(c) );

					stepsMaden++;

					lines.Add(new PointF[] {
                        // line from c,f(c) to p1,f(p1)
                        new PointF((float)c, (float)f(c)),
                        new PointF((float)p1, (float)f(p1))}
						);
					lines.Add(new PointF[] {
                        // line from p2,0 to p2,f(p2)
                        new PointF((float)p2, 0),
                        new PointF((float)p2, (float)f(p2))}
							);

					if ( stepsMaden % 100 == 0 )
					{
						if ( silent )
							return double.NaN;

						if ( MessageBox.Show("Performed " + stepsMaden.ToString()
							+ " steps, continue?", "Разошлось наверно?",
							MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
							MessageBoxDefaultButton.Button1) != DialogResult.OK )
						{
							return double.NaN;
						}
					}
				}
				while ( ( Math.Abs(p1 - p2) >= eps ) &&
					( Math.Abs(f(p2)) > eps ) );

				return p2;
			}

			public static double Cuttings(DoubleFunction f,
				double p1, double p2, double eps, out List<PointF[]> lines, bool silent)
			{
				double p0;

				int stepsMaden = 0;

				lines = new List<PointF[]>();

				do
				{
					p0 = p1;
					p1 = p2;

					p2 = p1 - f(p1) * ( p1 - p0 ) /
						( f(p1) - f(p0) );

					stepsMaden++;

					lines.Add(new PointF[] {
                        new PointF((float)p0, (float)f(p0)),
                        new PointF((float)p1, (float)f(p1))}
						);

					lines.Add(new PointF[] {
                        new PointF((float)p2, (float)f(p2)),
                        new PointF((float)p2, 0)}
						);

					if ( stepsMaden % 100 == 0 )
					{
						if ( silent )
							return double.NaN;

						if ( MessageBox.Show("Performed " + stepsMaden.ToString()
							+ " steps, continue?", "Разошлось наверно?",
							MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
							MessageBoxDefaultButton.Button1) != DialogResult.OK )
						{
							return double.NaN;
						}
					}

				}
				while ( ( Math.Abs(p2 - p1) >= eps ) &&
					( Math.Abs(f(p2)) > eps ) );

				return p2;
			}

			private static double w(DoubleFunction f,
				double xn_2, double xn_1, double xn)
			{
				return
					( f(xn_1) - f(xn) )
					/ ( xn_1 - xn )

					+ ( f(xn) - 2 * f(xn_1) + f(xn_2) )
					/ ( xn_1 - xn_2 );
			}

			private static double NextRoot(DoubleFunction f,
				double xn_2, double xn_1, double xn)
			{
				double ВтораяРазделённаяРазность =
					( f(xn) - 2 * f(xn_1) + f(xn_2) )
					/ ( xn - xn_1 )
					/ ( xn_1 - xn_2 );
				double W = w(f, xn_2, xn_1, xn);
				double res1 = xn + 2 * f(xn) /
					( -W -
					Math.Sqrt(
					Math.Abs(W * W - 4 * f(xn) * ВтораяРазделённаяРазность))
					);
				double res2 = xn + 2 * f(xn) /
					( -W +
					Math.Sqrt(
					Math.Abs(W * W - 4 * f(xn) * ВтораяРазделённаяРазность))
					);

				return Math.Abs(res1 - xn) > Math.Abs(res2 - xn) ? res2 : res1;
			}

			private static void swap(ref object a, ref object b)
			{
				object t;
				t = a;
				a = b;
				b = t;
			}

			private static IComparable Min(
				IComparable a, IComparable b, IComparable c)
			{
				IComparable t;
				if ( a.CompareTo(b) < 0 )
					t = a;
				else
					t = b;

				if ( c.CompareTo(t) < 0 )
					return c;
				else
					return t;
			}

			private static IComparable Max(
				IComparable a, IComparable b, IComparable c)
			{
				IComparable t;
				if ( a.CompareTo(b) > 0 )
					t = a;
				else
					t = b;

				if ( c.CompareTo(t) > 0 )
					return c;
				else
					return t;
			}

			public static double Muller(DoubleFunction f,
				double p1, double p2, double p3, double eps,
				ref DekartForm dForm, bool silent)
			{
				double p0;
				int stepsMaden = 0;

				Parabola parabola = new Parabola(p1, f(p1), p2, f(p2), p3, f(p3));

				dForm.AddGraphic(parabola.Eval,
					(float)(double)Min(p1, p2, p3),
					(float)(double)Max(p1, p2, p3),
					DrawModes.DrawLines, Color.Red);

				do
				{
					p0 = p1;
					p1 = p2;
					p2 = p3;
					p3 = NextRoot(f, p0, p1, p2);

					stepsMaden++;

					parabola = new Parabola(p1, f(p1), p2, f(p2), p3, f(p3));

					dForm.AddGraphic(parabola.Eval,
						(float)(double)Min(p1, p2, p3),
						(float)(double)Max(p1, p2, p3),
						DrawModes.DrawLines, Color.Red);

					if ( stepsMaden % 100 == 0 )
					{
						if ( silent )
							return double.NaN;

						if ( MessageBox.Show("Performed " + stepsMaden.ToString()
							+ " steps, continue?", "Разошлось наверно?",
							MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
							MessageBoxDefaultButton.Button1) != DialogResult.OK )
						{
							return double.NaN;
						}
					}

				}
				while ( ( Math.Abs(p3 - p2) >= eps ) &&
					( Math.Abs(f(p3)) > eps ) );

				return p3;
			}

		}

		private void Form4_Load(object sender, EventArgs e)
		{
			textE.Text = 0.0001.ToString();
			checkAutoSearch.Checked = !checkAutoSearch.Checked;
			checkAutoSearch.Checked = !checkAutoSearch.Checked;
		}

		private void ListsSync(object sender, EventArgs e)
		{
			if ( sender is ListBox )
			{
				try
				{
					if ( sender.Equals(listRoots) )
					{ listY.SelectedIndex = listRoots.SelectedIndex; }
					if ( sender.Equals(listY) )
					{ listRoots.SelectedIndex = listY.SelectedIndex; }
				}
				catch ( ArgumentOutOfRangeException )
				{ }
			}
		}

		private void checkAutoSearch_CheckedChanged(object sender, EventArgs e)
		{
			groupInterval.Enabled
				= !( radioNewtone.Enabled
				= radioHord.Enabled
				= groupFirstApproximation.Enabled
				= !checkAutoSearch.Checked );
			radioNewtone.Checked = radioHord.Checked = false;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}