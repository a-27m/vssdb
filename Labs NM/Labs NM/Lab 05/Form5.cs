using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DekartGraphic;


namespace Lab_05
{
	public partial class Form5 : Form
	{
		private enum SolutionMethod
		{
			StillPoint,
			Newtone,
		}

		public Form5()
		{
			InitializeComponent();
		}

		SolutionMethod selectedSolMeth;

		#region functions

		double g1S(double y)
		{
			return Math.Sqrt(y + 7) * Math.Cos(y) - 2.0;
			//return Math.Sin(Math.Pow(y + 5, Math.Cos(y + 5)));//-1.38;
		}
		double g2S(double x)
		{
			return x * x * x - 2 * Math.Sin(x) + 1.2;
			//return Math.Cos(Math.Pow(x + 6, Math.Sin(x + 6)));//-1.3;
		}

		double f1(double[] X)
		{
			if ( X.Length < 2 )
				throw new ArgumentException("Too few args", "X");

			// original
			double x = X[0];
			double y = X[1];
			return x * x * x - 2 * Math.Sin(x) - y;
		}
		double f2(double[] X)
		{
			if ( X.Length < 2 )
				throw new ArgumentException("Too few args", "X");

			// original
			double x = X[0];
			double y = X[1];
			return Math.Sqrt(y + 7) * Math.Cos(y) - x;
		}

		double f1x(double t)
		{
			return t;
		}
		double f1y(double t)
		{
			return t * t * t - 2 * Math.Sin(t);
			//return Math.Cos(Math.Pow(t + 6, Math.Sin(t + 6)));
			//return t * t;
		}
		double f1yS(double t)
		{
			return t * t * t - 2 * Math.Sin(t) + 1.2;
			//return Math.Cos(Math.Pow(t + 6, Math.Sin(t + 6)))-1.38;
			//return t * t;
		}
		double f2x(double t)
		{
			return Math.Sqrt(t + 7) * Math.Cos(t);
			//return Math.Sin(Math.Pow(t + 5, Math.Cos(t + 5)));
			//return t * t;
		}
		double f2xS(double t)
		{
			return Math.Sqrt(t + 7) * Math.Cos(t) - 2.0;
			//return Math.Sin(Math.Pow(t + 5, Math.Cos(t + 5)))-1.3;
			//return t * t;
		}
		double f2y(double t)
		{
			return t;
		}

		double df1x(double[] X)
		{
			// original
			double x = X[0];
			double y = X[1];
			return 3 * x * x - 2 * Math.Cos(x);
		}
		double df1y(double[] X)
		{ return -1; }
		double df2x(double[] X)
		{ return -1; }
		double df2y(double[] X)
		{
			// original
			double x = X[0];
			double y = X[1];
			return Math.Cos(y) / ( 2 * Math.Sqrt(y + 7) ) -
				Math.Sin(y) * Math.Sqrt(y + 7);
		}

		double bisectress(double x) { return x; }

		#endregion

		private void checkPick_CheckedChanged(object sender, EventArgs e)
		{
			textX0.Enabled =
				textY0.Enabled =
				!checkPick.Checked;
		}

		#region radioMethod CheckedChanged

		private void radioStillPt_CheckedChanged(object sender, EventArgs e)
		{
			selectedSolMeth = SolutionMethod.StillPoint;

			textX0.Enabled =
				textY0.Enabled =
				true;
		}

		private void radioNewtone_CheckedChanged(object sender, EventArgs e)
		{
			selectedSolMeth = SolutionMethod.Newtone;

			textX0.Enabled =
				textY0.Enabled =
				true;
		}

		#endregion

		private void buttonSolve_Click(object sender, EventArgs e)
		{
			double x0, y0;
			double eps;
			bool speedUp;

			#region get parameters from form
			errorProvider.Clear();

			try { eps = float.Parse(textE.Text); }
			catch ( FormatException ) {
				errorProvider.SetError(textE, "Wrong float number");
				return;
			}
			if ( eps < 0 ) {
				errorProvider.SetError(textE, "Has to be > 0");
				return;
			}

			speedUp = checkSpeedUp.Checked;
			#endregion

			double[] res = new double[] { double.NaN, double.NaN };
			DekartForm dForm = null;
			List<PointF[]> lines = null;

			switch ( selectedSolMeth ) {

			#region Method Simple Iteration

			case SolutionMethod.StillPoint:

				try { x0 = float.Parse(textX0.Text); }
				catch ( FormatException ) { errorProvider.SetError(textX0, "Wrong float number"); return; }

				try { y0 = float.Parse(textY0.Text); }
				catch ( FormatException ) { errorProvider.SetError(textY0, "Wrong float number"); return; }

				dForm = new DekartForm(200, 200, 200, 300);
				dForm.Size = new Size(750, 600);
				dForm.Use_IsVisible = false;

				dForm.AddGraphic(f1x, f1yS, -5f, 5f, DrawModes.DrawLines, Color.Green);
				dForm.AddGraphic(f2xS, f2y, -5f, 5f, DrawModes.DrawLines, Color.Blue);
				res = FindSysRoot.StillPointMethod(
					new double[] { x0, y0 },
					new DoubleFunction[] { g1S, g2S },
					eps, out lines, speedUp, false);
				break;
			#endregion

			#region Method Newtone

			case SolutionMethod.Newtone:

				try { x0 = float.Parse(textX0.Text); }
				catch ( FormatException ) { errorProvider.SetError(textX0, "Wrong float number"); return; }

				try { y0 = float.Parse(textY0.Text); }
				catch ( FormatException ) { errorProvider.SetError(textY0, "Wrong float number"); return; }

				dForm = new DekartForm(100, 100, 300, 300);
				dForm.Size = new Size(750, 600);
				dForm.Use_IsVisible = false;

				dForm.AddGraphic(f1x, f1y, -5f, 5f, DrawModes.DrawLines, Color.Green);
				dForm.AddGraphic(f2x, f2y, -5f, 5f, DrawModes.DrawLines, Color.Blue);

				DoubleMultiDimFunction[,] J = new DoubleMultiDimFunction[2, 2];
				J[0, 0] = df1x;
				J[0, 1] = df1y;
				J[1, 0] = df2x;
				J[1, 1] = df2y;

				DoubleMultiDimFunction[] F = new DoubleMultiDimFunction[2];
				F[0] = f1;
				F[1] = f2;

				res = FindSysRoot.Newtone(F, J,
					new double[] { x0, y0 }, eps, out lines, false);
				break;

			#endregion

			default:
				return;
			}

			#region Print results

			if ( lines != null ) {
				foreach ( PointF[] pts in lines ) { dForm.AddPolygon(Color.Red, DrawModes.DrawLines, pts); }
			}
			dForm.Show();
			dForm.Update2();

			listRoots.Items.Clear();
			listY.Items.Clear();

			if ( double.IsNaN(res[0]) || double.IsNaN(res[1]) ) {
				MessageBox.Show("Корни не найдены.");
				return;
			}

			listRoots.Items.Add("x" + ( listRoots.Items.Count + 1 ) + " = "
				+ res[0].ToString("F16"));
			listY.Items.Add("y" + ( listY.Items.Count + 1 ) + " = "
				+ res[1].ToString("F16"));
			#endregion
		}

		private void Form5_Load(object sender, EventArgs e)
		{
			textE.Text = 0.001f.ToString();
			textX0.Text = 0f.ToString("F1");
			textY0.Text = 0f.ToString("F1");
		}
	}

	public delegate double DoubleMultiDimFunction(double[] X);

	public class FindSysRoot
	{

		public static double[] StillPointMethod(double[] p0, DoubleFunction[] g, double eps, out List<PointF[]> lines, bool speedUp, bool silent)
		{
			if ( p0.Length != g.Length )
				throw new ArgumentException("p0[] and f[] sizes dont match");
			if ( p0.Length != 2 )
				throw new NotImplementedException("multidimensional case is not implemented yet");

			double[] p_prev = new double[p0.Length];

			int stepsMaden = 0;

			lines = new List<PointF[]>();

			lines.Add(new PointF[] {
				new PointF((float)p0[0], (float)p0[1]),
				new PointF((float)p0[0], (float)p0[1])}
				);

			do {
				p_prev[0] = p0[0];
				p_prev[1] = p0[1];

				p0[0] = g[0](p_prev[1]);
				p0[1] = g[1](speedUp ? p0[0] : p_prev[0]);
				stepsMaden++;

				//lines.Add(new PointF[] {
				//        new PointF((float)p_prev[0], 0),
				//        new PointF((float)p_prev[0], (float)p0[0]),
				//        new PointF((float)p0[0], (float)p0[0]),
				//        new PointF((float)p0[0], 0)}
				//        );			

				lines.Add(new PointF[] {
				        new PointF((float)p_prev[0], (float)p_prev[1]),
				        new PointF((float)p0[0], (float)p0[1])}
						);

				if ( stepsMaden % 100 == 0 ) {
					if ( silent )
						return new double[] { double.NaN, double.NaN };

					if ( MessageBox.Show("Performed " + stepsMaden.ToString()
						+ " steps, continue?", "Разошлось наверно?",
						MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button1) != DialogResult.OK ) {
						return new double[] { double.NaN, double.NaN };
					}
				}
			}
			while ( ro(p0, p_prev) >= eps );

			return p0;
		}

		public static double[] Newtone(DoubleMultiDimFunction[] F, DoubleMultiDimFunction[,] J,
			double[] x0, double eps,
			out List<PointF[]> lines, bool silent)
		{
			if ( F.GetLength(0) > 2 )
				throw new NotImplementedException("Multidimensional case is not implemented yet");
			if ( F.GetLength(0) != J.GetLength(0) )
				throw new ArgumentException("Sizes of J and F are not correct");

			List<PointF> nodes = new List<PointF>();
			lines = new List<PointF[]>();

			DoubleMultiDimFunction[,] _F =
				new DoubleMultiDimFunction[F.GetLength(0), 1];

			for ( int i = 0; i < F.GetLength(0); i++ )
				_F[i, 0] = F[i];

			double[] x_old, x = x0;

			double[,] J1AtPt = new double[J.GetLength(0), J.GetLength(1)];

			int stepsMaden = 0;

			nodes.Add(new PointF((float)x0[0], (float)x0[1]));

			do {
				x_old = (double[])x.Clone();
				J1AtPt = ValAtPt(J, x);
				double delta = det(J1AtPt);

				double t_for_swap = J1AtPt[0, 0];
				J1AtPt[0, 0] = J1AtPt[1, 1] / delta;
				J1AtPt[0, 1] = -J1AtPt[0, 1] / delta;
				J1AtPt[1, 0] = -J1AtPt[1, 0] / delta;
				J1AtPt[1, 1] = t_for_swap / delta;

				double[,] tmp_x = MulAb(J1AtPt, ValAtPt(_F, x));
				for ( int i = 0; i < x.GetLength(0); i++ )
					x[i] -= tmp_x[i, 0];


				nodes.Add(new PointF((float)x[0], (float)x[1]));

				stepsMaden++;

				if ( stepsMaden % 100 == 0 ) {
					if ( silent ) {
						lines.Add(nodes.ToArray());
						return new double[] { double.NaN, double.NaN };
					}

					if ( MessageBox.Show("Performed " + stepsMaden.ToString()
						+ " steps, continue?", "Разошлось наверно?",
						MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button1) != DialogResult.OK ) {
						lines.Add(nodes.ToArray());
						return new double[] { double.NaN, double.NaN };
					}
				}

			} while ( ro(x, x_old) >= eps );

			lines.Add(nodes.ToArray());

			return x;
		}

		private static double det(double[,] m)
		{
			if ( m.GetLength(0) != m.GetLength(1) )
				throw new ArgumentException("Square matrices only");
			if ( m.GetLength(0) == 1 )
				return m[0, 0];
			if ( m.GetLength(0) == 2 )
				return m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
			if ( m.GetLength(0) > 2 )
				throw new NotImplementedException("Multidimensional case is not implemanted yet");
			return double.NaN;
		}

		private static double[,] ValAtPt(DoubleMultiDimFunction[,] W, double[] x)
		{
			double[,] m = new double[W.GetLength(0), W.GetLength(1)];
			for ( int i0 = 0; i0 < W.GetLength(0); i0++ )
				for ( int i1 = 0; i1 < W.GetLength(1); i1++ )
					m[i0, i1] = W[i0, i1](x);
			return m;
		}

		private static double[,] SubAb(double[,] A, double[,] B)
		{
			if ( ( A.GetLength(0) != B.GetLength(0) ) ||
				( A.GetLength(1) != B.GetLength(1) ) )
				throw new ArgumentException("Matrices sizes do not match");

			double[,] m = (double[,])( A.Clone() );
			for ( int i = 0; i < A.GetLength(0); i++ )
				for ( int j = 0; j < A.GetLength(1); j++ )
					m[i, j] -= B[i, j];
			return m;

		}

		private static double[,] MulAb(double[,] A, double[,] B)
		{
			int m = A.GetLength(0);
			// check soglasovannost'
			if ( A.GetLength(1) != B.GetLength(0) )
				throw new ArgumentException("A cannot be multipled on B: sizes do not match");
			int n = A.GetLength(1);
			int p = B.GetLength(1);

			double[,] ab = new double[m, p];
			for ( int i = 0; i < m; i++ )
				for ( int j = 0; j < p; j++ ) {
					ab[i, j] = 0;
					for ( int k = 0; k < n; k++ )
						ab[i, j] += A[i, k] * B[k, j];
				}
			return ab;
		}

		private static double ro(double[] p1, double[] p2)
		{
			double dist = 0;

			if ( p1.Length != p2.Length )
				throw new ArgumentException("Points dimentions do not match!");

			for ( int i = 0; i < p1.Length; i++ )
				dist += Math.Pow(p2[i] - p1[i], 2);

			return Math.Sqrt(dist);
		}
	}
}