using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using DekartGraphic;

namespace ComplexRoots
{
    public partial class Form1 : Form
    {
        Matrix matrix;
        DekartForm dForm = null;
        Polynom poly1;

        double eps;
        float x1, x2;
        ComplexFunction f;
        ComplexFunction df;

        public Form1()
        {
            InitializeComponent();
            matrix = new Matrix(300, 0f, 0f, -300, 200, 200);
            //mgs = new List<MathGraphic>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textE.Text = 0.001.ToString();
            textP0.Text = "1";

            textX1.Text = (-1.5).ToString();
            textX2.Text = 1.5.ToString();
        }

        private void ListsSync(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                try
                {
                    if (sender.Equals(listRoots))
                    {
                        listY.SelectedIndex = listRoots.SelectedIndex;
                    }
                    if (sender.Equals(listY))
                    {
                        listRoots.SelectedIndex = listY.SelectedIndex;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadPolynom();

            f = poly1.Evaluate;
            df = poly1.Diff().Evaluate;

            #region read eps, x1, x2
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
                x1 = float.Parse(textX1.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textX1, "Wrong float number");
                return;
            }

            try
            {
                x2 = float.Parse(textX2.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textX2, "Wrong float number");
                return;
            }

            #endregion

            FindRoot();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ReadPolynom();

            listRoots.Items.Clear();
            listY.Items.Clear();

            this.textBoxFx.Text = poly1.ToString();
            dataGridView1.AutoResizeColumns();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = dataGridView1.RowCount - 2; i >= 0; i--)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (dataGridView1.RowCount - i - 2).ToString();
            }
        }

        private void ReadPolynom()
        {
            poly1 = new Polynom(new Complex[dataGridView1.RowCount - 1]);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1[0, i].Value == null)
                {
                    poly1[i] = new Complex(0);
                    continue;
                }
                try
                {
                    string[] snums = dataGridView1[0, i].Value.ToString().Split(';');
                    poly1[i] = new Complex(double.Parse(snums[0]),
                        snums.Length > 1 ? double.Parse(snums[1]) : 0);
                }
                catch (Exception)
                {
                    errorProvider.SetError(dataGridView1, "Wrong float number");
                    break;
                }
            }
        }

        public static Complex NewtoneRafson(ComplexFunction f, ComplexFunction df,
    Complex p0, double eps, out int iterationsTotal)
        {
            Complex p_prev;
            iterationsTotal = 0;

            do
            {
                p_prev = p0;
                p0 = p0 - f(p0) / df(p0);

                if (++iterationsTotal % 200 == 0)
                    return Complex.NaN;
            }
            while (Complex.Norm(p0 - p_prev) >= eps * Complex.Norm(p0));

            return p0;

        }

        public double delta = 0.01;
        public bool Near(Complex x, Complex y)
        {
            if ((Math.Abs(x.re - y.re) < delta) &&
                (Math.Abs(x.im - y.im) < delta))
                return true;
            return false;
        }

        private void FindRoot()
        {
            Complex res = Complex.NaN;

            #region prepare dform
            if (dForm == null)
            {
                dForm = new DekartForm(100, 100, 300, 300);
                dForm.ClientSize = new Size(600, 600);
                dForm.Use_IsVisible = false;
                dForm.FormClosed += new FormClosedEventHandler(delegate(object s, FormClosedEventArgs eva)
                {
                    dForm = null;
                });
            }
            else
                dForm.RemoveAllGraphics();

            #endregion

            List<Root> roots = new List<Root>();
            List<PointF> pts = new List<PointF>();
            List<Color> colors = new List<Color>();

            Color[] baseColors = new Color[] { 
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Green,
                Color.LightBlue,
                Color.Blue,
                Color.Violet
            };

            ///////////////////////////////////////////////////////////////////////

            //double x1 = -2;
            //double x2 = 2;
            double hx = 0.01;

            //double y1 = -2;
            //double y2 = 2;
            double hy = 0.01;

//          for (double y = y1; y < y2; y += hy)

            for (double y = x1; y < x2; y += hy)
                for (double x = x1; x < x2; x += hx)
                {
                    int iterations;
                    float percent;
                    res = NewtoneRafson(f, df, new Complex(x, y), eps, out iterations);
                    percent = iterations/30f;
                    if (percent > 1f)
                        percent = 1f;

                    if (Complex.IsNaN(res))
                    {
                        colors.Add(Color.Black);
                        pts.Add(new PointF((float)x, (float)y));
                    }
                    else
                    {
                        if (roots.Count == 0)
                        {
                            Root newRoot;
                            newRoot.color = baseColors[roots.Count % baseColors.Length];
                            newRoot.value = res;
                            roots.Add(newRoot);
                        }

                        bool needAdd = true;
                        foreach (Root r in roots)
                            if (Near(r.value, res))
                            {
                                colors.Add(ColorModifer.Brightness(r.color, percent));
                                pts.Add(new PointF((float)x, (float)y));

                                needAdd = false;
                                break;
                            }

                        if (needAdd)
                        {
                            Root newRoot;
                            newRoot.color = baseColors[roots.Count % baseColors.Length];
                            newRoot.value = res;
                            roots.Add(newRoot);

                            colors.Add(ColorModifer.Brightness(newRoot.color, percent));
                            pts.Add(new PointF((float)x, (float)y));
                        }
                    }
                }

            DotGraphic dotGraphic = new DotGraphic(pts.ToArray(), colors.ToArray());
            dotGraphic.CurrentColorSchema = new MathGraphic.ColorSchema(
                Color.Black, Color.DimGray, Color.Black, Color.Gray);
            dForm.AddGraphic(dotGraphic);

            dForm.Show();
            dForm.Update2();

            foreach (Root z in roots)
            {
                listRoots.Items.Add("z" + (listRoots.Items.Count + 1) + " = "
                   + z.value.ToString("F6"));
                listY.Items.Add("f" + (listY.Items.Count + 1) + " = "
                    + poly1.Evaluate(z.value).ToString("F6"));
            }
        }
    }

    struct Root
    {
        public Complex value;
        public Color color;
    }

    class ColorModifer
    {
        public static Color Brightness(Color c, float percent)
        {
            int r, g, b;
            percent = 1 - percent;
            
            r = (int)Math.Round(c.R * percent);
            g =(int)Math.Round(c.G * percent);
            b =(int)Math.Round(c.B * percent);

            return Color.FromArgb(r, g, b);
        }
    }

    public class Polynom
    {
        Complex[] a;

        public int N
        {
            get
            {
                return a.Length - 1;
            }
        }

        public Complex this[int i]
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

        public Polynom(params Complex[] a)
        {
            this.a = (Complex[])a.Clone();
        }

        public Complex Evaluate(Complex x)
        {
            Complex result = a[0];
            for (int i = 1; i < a.Length; i++)
                result = result * x + a[i];
            return result;
        }

        public Polynom Diff()
        {
            if (this.N < 1)
                return new Polynom(new Complex(0));

            Complex[] d = new Complex[a.Length - 1];
            for (int i = 0; i < a.Length - 1; i++)
                d[i] = a[i] * new Complex((a.Length - i - 1));

            return new Polynom(d);
        }

        public static Polynom operator /(Polynom P, Complex z)
        {
            if (P.N < 1)
                throw new InvalidOperationException("Polynom P is constant");

            Complex[] a = new Complex[P.a.Length - 1];

            a[0] = P.a[0];
            for (int i = 1; i < a.Length; i++)
                a[i] = a[i - 1] * z + P.a[i];

            return new Polynom(a);
        }

        public override string ToString()
        {
            string str = "";
            //for (int i = 0; i < a.Length - 2; i++)
            //{
            //    if (a[i] == 0)
            //        continue;
            //    str += string.Format("{2}{0}x^{1}",
            //        a[i] == 1 ? "" : (a[i] == -1 ? "-" : a[i].ToString()),
            //        N - i,
            //        a[i] < 0 ? "" : "+");
            //}

            //double v;

            //if (a.Length > 0)
            //{
            //    if (a.Length > 1)
            //    {
            //        v = a[a.Length - 2];
            //        if (v != 0)
            //        {
            //            str += string.Format("{1}{0}x",
            //                v == 1 ? "" : (v == -1 ? "-" : v.ToString()),
            //                v < 0 ? "" : "+");
            //        }
            //    }

            //    v = a[a.Length - 1];
            //    if (v != 0)
            //    {
            //        str += string.Format("{1}{0}", v, v < 0 ? "" : "+");
            //    }
            //}

            //if (str[0] == '+')
            //    str = str.Substring(1);
            return str;
        }
    }
}