using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using DekartGraphic;
//using Polish;

namespace Root1
{

    public partial class Form1 : Form
    {
        Matrix matrix;
        DekartForm dForm = null;

        double lastRoot = 0;

        double f1(double x)
        {
            return Math.Sin(x * x - 4);
        }

        public Form1()
        {
            InitializeComponent();
            matrix = new Matrix(300, 0f, 0f, -300, 200, 200);
            //mgs = new List<MathGraphic>();
        }

        void dForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (double.IsNaN(lastRoot))
                    return;
                if (poly1.N <= 1)
                    return;
                poly1 = poly1 / lastRoot;

                f = poly1.Evaluate;
                df = poly1.Diff().Evaluate;
                FindRoot();
            }
        }

        // x^4-10*x^3+35*x^2-50*x+24
        Polynom poly1 = new Polynom(1, -10, 35, -50, 24);

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

                if (stepsMaden % 100 == 0)
                {
                    if (silent)
                        return double.NaN;

                    if (MessageBox.Show("Performed " + stepsMaden.ToString()
                        + " steps, continue?", "Разошлось наверно?",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) != DialogResult.OK)
                    {
                        return Double.NaN;
                    }
                }
            }
            while ((Math.Abs(p0 - p_prev) >= eps) &&
                (Math.Abs(f(p0)) > eps));

            return p0;
        }

            double p0;
            double eps;
			float x1, x2;
            DoubleFunction f ;
            DoubleFunction df;

        private void button1_Click(object sender, EventArgs e)
        {
            ReadPolynom();

             f = poly1.Evaluate;
            df = poly1.Diff().Evaluate;

            #region read eps, p0, x1, x2
            errorProvider.Clear();

            try
            {
                eps = float.Parse(textE.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textE, "Wrong float number");
                return;
            }
            if (eps < 0)
            {
                errorProvider.SetError(textE, "Has to be > 0");
                return;
            }
            
            try
            {
                p0 = float.Parse(textP0.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textP0, "Wrong float number");
                return;
            }

			try
			{ x1 = float.Parse(textX1.Text); }
			catch ( FormatException )
			{ errorProvider.SetError(textX1, "Wrong float number"); return; }

			try
			{ x2 = float.Parse(textX2.Text); }
			catch ( FormatException )
			{ errorProvider.SetError(textX2, "Wrong float number"); return; }

            #endregion

            if (poly1.N>0)
            FindRoot();
        }

        private void FindRoot()
        {
            double res = double.NaN;
            List<PointF[]> lines = null;

            #region prepare dform
            if (dForm == null)
            {
                dForm = new DekartForm(100, 100, 300, 300);
                dForm.Size = new Size(750, 600);
                dForm.Use_IsVisible = false;
                dForm.toolStripContainer1.ContentPanel.MouseUp +=
                    new MouseEventHandler(dForm_MouseClick);
                dForm.FormClosed += new FormClosedEventHandler(delegate(object s, FormClosedEventArgs eva)
                {
                    dForm = null;
                });
            }
            else
                dForm.RemoveAllGraphics();

            #endregion

            dForm.AddGraphic(f, x1, x2, DrawModes.DrawLines, Color.Green);
            dForm.Show();
            dForm.Update2();

            res = NewtoneRafson(f, df, p0, eps, out lines, false);
            lastRoot = res;

            #region Print results

            if (lines != null)
                foreach (PointF[] pts in lines)
                    dForm.AddPolygon(Color.Red, DrawModes.DrawLines, pts);

            dForm.Update2();

            if (double.IsNaN(res))
            {
                MessageBox.Show("Корни не найдены.");
                return;
            }

            listRoots.Items.Add("x" + (listRoots.Items.Count + 1) + " = "
                + res.ToString("F16"));
            listY.Items.Add("y" + (listY.Items.Count + 1) + " = "
                + poly1.Evaluate(res).ToString("F16"));
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textE.Text = 0.0001.ToString();
            textP0.Text = "1";
            //double[] c = new double[9];
            //c[1] = 1;
            //for (int i = 3; i < c.Length; i+=2)
            //    c[i] = -c[i - 2] / (i - 1) / (i);

            //Array.Reverse(c);

            //poly1 = new Polynom(c);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ReadPolynom();

            listRoots.Items.Clear();
            listY.Items.Clear();

            this.textBoxFx.Text = poly1.ToString();
            dataGridView1.AutoResizeColumns();
        }

        private void ReadPolynom()
        {
            poly1 = new Polynom(new double[dataGridView1.RowCount - 1]);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[0, i].Value == null)
                {
                    poly1[i] = 0;
                    continue;
                }
                try
                {
                    poly1[i] = double.Parse(dataGridView1[0, i].Value.ToString());
                }
                catch (FormatException)
                {
                    errorProvider.SetError(dataGridView1, "Wrong float number");
                    break;
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = dataGridView1.RowCount - 2; i >= 0; i--)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (dataGridView1.RowCount - i - 2).ToString();
            }
        }
    }

    public class Polynom
    {
        double[] a;

        public int N
        {
            get
            {
                return a.Length - 1;
            }
        }

        public double this[int i]
        {
            get
            {
                return a[i];
            }
            set
            {
                if (i <= N)
                    a[i] = value;
            }
        }

        public Polynom(params double[] a)
        {
            this.a = (double[])a.Clone();
        }

        public double Evaluate(double x)
        {
            double result = a[0];
            for (int i = 1; i < a.Length; i++)
                result = result * x + a[i];
            return result;
        }

        public Polynom Diff()
        {
            if (this.N < 1)
                return new Polynom(0);

            double[] d = new double[a.Length - 1];
            for (int i = 0; i < a.Length - 1; i++)
                d[i] = a[i] * (a.Length - i - 1);

            return new Polynom(d);
        }

        public static Polynom operator /(Polynom P, double z)
        {
            if (P.N < 1)
                throw new InvalidOperationException("Polynom P is constant");

            double[] a = new double[P.a.Length - 1];

            a[0] = P.a[0];
            for (int i = 1; i < a.Length; i++)
                a[i] = a[i - 1] * z + P.a[i];

            return new Polynom(a);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < a.Length - 2; i++)
            {
                if (a[i] == 0)
                    continue;
                str += string.Format("{2}{0}x^{1}",
                    a[i] == 1 ? "" : (a[i] == -1 ? "-" : a[i].ToString()),
                    N - i,
                    a[i] < 0 ? "" : "+");
            }

            double v;

            if (a.Length > 0)
            {
                if (a.Length > 1)
                {
                    v = a[a.Length - 2];
                    if (v != 0)
                    {
                        str += string.Format("{1}{0}x",
                            v == 1 ? "" : (v == -1 ? "-" : v.ToString()),
                            v < 0 ? "" : "+");
                    }
                }

                v = a[a.Length - 1];
                if (v != 0)
                {
                    str += string.Format("{1}{0}", v, v < 0 ? "" : "+");
                }
            }
            return str;
        }
    }
}