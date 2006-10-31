using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DekartGraphic;


namespace Lab_05
{
	public partial class Form5 : Form
	{
		//class Vector<T>
		//{
		//    T[] _A;
		//    public Vector(params T[] A)
		//    {
		//        _A = (T[])A.Clone();
		//    }
		//    public Vector(Vector<T> A)
		//    {
		//        _A = (T[])A.Components.Clone();
		//    }

		//    public int Length
		//    {
		//        get { return _A.Length; }
		//    }

		//    public T[] Components
		//    {
		//        get { return _A; }
		//        set { _A = value; }
		//    }


		//    public T this[int index]
		//    {
		//        get { return _A[index]; }
		//        set
		//        {
		//            if ( index < _A.Length )
		//                _A[index] = value;
		//        }
		//    }

		//    public static Vector<T> operator *(Vector<T> V, double a) {
		//        Vector<T> res = new Vector<T>(V);
		//        for ( int i = 0; i < res.Length; i++ )
		//            res[i] = (double)res[i] * a;
		//        return res;
		//    }
		//}

		private enum SolutionMethod
		{
			StillPoint,
			Newtone,
		}

		public Form5()
		{
			InitializeComponent();
			MaximizeBox = false;
			radioStillPt.Enabled = false;
		}

		double t = 0;

		SolutionMethod selectedSolMeth;

		#region functions

		List<double[]> roots = null;

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
		}

		double f2x(double t)
		{
			return Math.Sqrt(t + 7) * Math.Cos(t);
		}
		double f2y(double t)
		{
			return t;
		}

		double f2_explicit(double x)
		{
			return Math.Sin(Math.Acos(x));
		}
		
		//double g1(double[] X)
		//{
		//    if ( X.Length < 2 )
		//        throw new ArgumentException("Too few args", "X");

		//    // original
		//    double x = X[0];
		//    return f1(X) + x;
		//}

		//double g2(double[] X)
		//{
		//    if ( X.Length < 2 )
		//        throw new ArgumentException("Too few args", "X");

		//    // original
		//    double y = X[1];
		//    return f2(X) + y;
		//}

		//double h(double x)
		//{
		//    if ( roots == null )
		//        return f1(x);

		//    double res = f(x);
		//    foreach ( double p in roots )
		//        res /= x - p;
		//    return res;
		//}

		//double df(double x)
		//{
		//    // original
		//    return 15 * x * x * Math.Cos(x * x * x) - 1;
		//}

		//double g(double x)
		//{
		//    return f(x) - x;
		//}

		double bisectress(double x) { return x; }

		#endregion

		#region radioMethod CheckedChanged

		private void radioStillPt_CheckedChanged(object sender, EventArgs e)
		{
			selectedSolMeth = SolutionMethod.StillPoint;

			//textP0.Enabled = true;

			//textA.Enabled =
			//    textB.Enabled =
			//textP1.Enabled =
			//textP2.Enabled = false;
		}

		private void radioNewtone_CheckedChanged(object sender, EventArgs e)
		{
			selectedSolMeth = SolutionMethod.Newtone;

			textX0.Enabled =
				textY0.Enabled =
				true;

			//textA.Enabled =
			//    textB.Enabled =
			//textP2.Enabled =
			//false;
		}

		#endregion

		private void buttonSolve_Click(object sender, EventArgs e)
		{
			double x0, y0;
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

			double[] res = new double[] { double.NaN, double.NaN };
			DekartForm dForm = null;
			List<PointF[]> lines = null;

			switch ( selectedSolMeth )
			{
			#region Method Still Point
			case SolutionMethod.StillPoint:
				try
				{ x0 = float.Parse(textX0.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textX0, "Wrong float number"); return; }

				try
				{ y0 = float.Parse(textY0.Text); }
				catch ( FormatException )
				{ errorProvider.SetError(textY0, "Wrong float number"); return; }

				dForm = new DekartForm(100, 100, 300, 300);
				dForm.Size = new Size(750, 600);
				dForm.Use_IsVisible = false;

				dForm.AddGraphic(f1x, f1y, -5f, 5f, DrawModes.DrawLines, Color.Green);
				dForm.AddGraphic(f2x, f2y, -5f, 5f, DrawModes.DrawLines, Color.Blue);

				res = FindSysRoot.StillPointMethod(
				    new double[] { x0, y0 },
				    new DoubleMultiDimFunction[] { f1, f2 },
				    eps, out lines, false);
				break;
			#endregion

			//#region Method Newtone
			//case SolutionMethod.Newtone:
			//    try
			//    { x0 = float.Parse(textX0.Text); }
			//    catch ( FormatException )
			//    { errorProvider.SetError(textX0, "Wrong float number"); return; }

			//    try
			//    { y0 = float.Parse(textY0.Text); }
			//    catch ( FormatException )
			//    { errorProvider.SetError(textY0, "Wrong float number"); return; }

			//    dForm = new DekartForm(100, 100, 300, 300);
			//    dForm.Size = new Size(750, 600);
			//    dForm.Use_IsVisible = false;

			//    dForm.AddGraphic(f1, -5f, 5f, DrawModes.DrawLines, Color.Green);
			//    dForm.AddGraphic(f2, -5f, 5f, DrawModes.DrawLines, Color.Green);

			//    res = FindSysRoot.Newtone(f, df, p0, eps, out lines, false);
			//    break;

			//#endregion

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

			if ( double.IsNaN(res[0]) || double.IsNaN(res[1]) )
			{
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
		}
	}

	public delegate double DoubleMultiDimFunction(double[] X);

	public class FindSysRoot
	{
		public static double[] StillPointMethod(double[] p0, DoubleMultiDimFunction[] f, double eps, out List<PointF[]> lines, bool silent)
		{
			if ( p0.Length != f.Length )
				throw new ArgumentException("p0[] and f[] sizes dont match");
			if ( p0.Length != 2 )
				throw new NotImplementedException();

			double[] p_prev = new double[p0.Length];

			int stepsMaden = 0;

			lines = new List<PointF[]>();

			lines.Add(new PointF[] {
				new PointF((float)p0[0], (float)p0[1]),
				new PointF((float)p0[0], (float)p0[1])}
				);

			do
			{
				p_prev[0] = p0[0];
				p_prev[1] = p0[1];

				p0[0] = f[0](p0) + p0[0];// ==g
				p0[1] = f[1](p0) + p0[1];// ==g
				stepsMaden++;

				lines.Add(new PointF[] {
					new PointF((float)p_prev[0], (float)p_prev[1]),
					new PointF((float)p0[0], (float)p0[1])
				});

				if ( stepsMaden % 100 == 0 )
				{
					if ( silent )
						return new double[] { double.NaN, double.NaN };

					if ( MessageBox.Show("Performed " + stepsMaden.ToString()
						+ " steps, continue?", "Разошлось наверно?",
						MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
						MessageBoxDefaultButton.Button1) != DialogResult.OK )
					{
						return new double[] { double.NaN, double.NaN };
					}
				}
			}
			while ( ( Math.Abs(p0[0] - p_prev[0]) >= eps ) &&
				( Math.Abs(p0[1] - p_prev[1]) >= eps ) &&
				( true ) );

			return p0;
		}

		public static double Newtone(DoubleMultiDimFunction[] g, double p0, double eps, out List<PointF[]> lines, bool p)
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}