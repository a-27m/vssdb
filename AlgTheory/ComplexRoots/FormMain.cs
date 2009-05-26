using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using ComplexNumbers;
using DekartGraphic;
using Fractal;

namespace ComplexRoots
{
    public partial class FormMain : Form
    {
        static int MAX_ITERATIONS = 30;

        BitmapGraphicForm bgf;
        Polynom poly1;

        double eps;
        float x1, y1, x2, y2;

        ComplexFunction f;
        ComplexFunction df;
        Color[,] preColor;

        Color[] baseColors = new Color[] { 
                Color.FromArgb(0xFF4A26),
                Color.FromArgb(0xDAFF26),
                Color.FromArgb(0x26FF4A),
                Color.FromArgb(0x26DAFF),
                Color.FromArgb(0x4A26FF),
                Color.FromArgb(0xFF26DA)
            };

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textE.Text = 0.001.ToString();

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

            if (poly1.N < 1)
            {
                MessageBox.Show("Задайте полином как минимум первой степени.", "Повторите ввод",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            f = poly1.Evaluate;
            df = poly1.Diff().Evaluate;

            #region read eps, x1, x2, y1, y2
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

            try
            {
                y1 = float.Parse(textY1.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textY1, "Wrong float number");
                return;
            }

            try
            {
                y2 = float.Parse(textY2.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textY2, "Wrong float number");
                return;
            }

            #endregion

            bgf = new BitmapGraphicForm(new PointF(x1, y1), new PointF(x2, y2));
            bgf.ResizeEvent += new EventHandler(bgf_Resize);
            bgf.ZoomEvent += new EventHandler(bgf_ZoomEvent);

            float ratioM = (x2 - x1) / (y2 - y1);
            float ratioS = (float)bgf.PictureWidth / bgf.PictureHeight;

            Text += bgf.PictureWidth.ToString() + ", ";
            if (ratioM / ratioS > 1)
            {
                bgf.PictureHeight = (int)(bgf.PictureHeight * ratioS / ratioM);
            }
            else
            {
                bgf.PictureWidth = (int)(bgf.PictureWidth * ratioM / ratioS);
            }
            Text += bgf.PictureWidth.ToString() + ", ";

            PrecacheColors();
            //eps *= eps;

            FindRoot();
        }

        void bgf_ZoomEvent(object sender, EventArgs e)
        {
            x1 = bgf.mathLeftBottom.X;
            y1 = bgf.mathLeftBottom.Y;
            x2 = bgf.mathRightTop.X;
            y2 = bgf.mathRightTop.Y;

            textX1.Text = x1.ToString();
            textX2.Text = x2.ToString();

            textY1.Text = y1.ToString();
            textY2.Text = y2.ToString();
        }

        void bgf_Resize(object sender, EventArgs e)
        {
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

            //double epsManhattan = eps * 1.2;
            do
            {
                p_prev = p0;
                p0 = p0 - f(p0) / df(p0);

                if (++iterationsTotal > MAX_ITERATIONS)
                    return Complex.NaN;
            }
            while (Complex.Norm(p0 - p_prev) >= eps * Complex.Norm(p0));
            //while (f(p0).x2y2 >= eps);
            //while ((p0 - p_prev).x2y2 >= eps);

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
            DateTime begin = DateTime.Now;

            Complex res = Complex.NaN;

            listRoots.Items.Clear();
            listY.Items.Clear();

            List<Root> roots = new List<Root>();

            Bitmap bitmap = new Bitmap(bgf.PictureWidth + 1, bgf.PictureHeight + 1,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            

            int ir = 0;

            Complex p0;
            double hx = (x2 - x1) / bgf.PictureWidth; // 0.01
            double hy = (y2 - y1) / bgf.PictureHeight; // 0.01

            if (hx < hy) hx = hy; else hy = hx;

            double x, y;
            x = x1;
            y = y1;
            for (int j = bitmap.Height - 1; j >= 0; y += hy, j--)
            {
                x = x1;
                for (int i = 0; i < bitmap.Width; x += hx, i++)
                {
                    int iterations;
                    p0.re = x;
                    p0.im = y;
                    res = NewtoneRafson(f, df, p0, eps, out iterations);

                    if (Complex.IsNaN(res))
                    {
                        bitmap.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        if (roots.Count == 0)
                        {
                            Root newRoot;
                            newRoot.value = res;
                            roots.Add(newRoot);
                        }

                        bool needAdd = true;
                        ir = 0;
                        foreach (Root r in roots)
                        {
                            if (Near(r.value, res))
                            {
                                bitmap.SetPixel(i, j, preColor[ir % baseColors.Length, iterations]);

                                needAdd = false;
                                break;
                            }
                            ir++;
                        }
                        if (needAdd)
                        {
                            Root newRoot;
                            newRoot.value = res;
                            roots.Add(newRoot);

                            bitmap.SetPixel(i, j, preColor[roots.Count % baseColors.Length, iterations]);
                        }
                    }
                }
            }


            DateTime end = DateTime.Now;

            bgf.Text = end.Subtract(begin).ToString();
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighQuality;

            ir = 0;
            foreach (Root r in roots)
            {
                float size1 = 3;
                int rx = (int)((r.value.re - x1) / hx);
                int ry = bitmap.Height - (int)((r.value.im - y1) / hy);

                g.FillEllipse(
                    new SolidBrush(
                        preColor[ir % baseColors.Length, MAX_ITERATIONS / 3]),
                    rx - size1, ry - size1, size1 * 2, size1 * 2
                    );

                float size2 = 6;
                g.DrawEllipse(
                    new Pen(
                        preColor[ir % baseColors.Length, MAX_ITERATIONS / 2]),
                    rx - size2, ry - size2, size2 * 2, size2 * 2
                    );

                ir++;
            }

            bgf.SetBitmap(bitmap);

            if (bgf.Visible)
                bgf.Refresh();
            else
                bgf.Show();

            foreach (Root z in roots)
            {
                listRoots.Items.Add("z" + (listRoots.Items.Count + 1) + " = "
                   + z.value.ToString("F6"));
                listY.Items.Add("f" + (listY.Items.Count + 1) + " = "
                    + poly1.Evaluate(z.value).ToString("F6"));
            }
        }

        private void PrecacheColors()
        {
            preColor = new Color[baseColors.Length, MAX_ITERATIONS + 1];

            for (int bC = 0; bC < baseColors.Length; bC++)
            {
                for (int i = 0; i <= MAX_ITERATIONS; i++)
                    preColor[bC, i] = ColorModifer.Brightness(
                        baseColors[bC],
                        (float)i / MAX_ITERATIONS);
            }
        }

    }

    struct Root
    {
        public Complex value;
        //public Color color;
    }

    class ColorModifer
    {
        public static Color Brightness(Color c, float percent)
        {
            int r, g, b;
            percent = 1 - percent;

            r = (int)Math.Round(c.R * percent);
            g = (int)Math.Round(c.G * percent);
            b = (int)Math.Round(c.B * percent);

            return Color.FromArgb(r, g, b);
        }
    }

    public class Polynom
    {
        Complex[] a;

        /// <summary>
        /// Gets the mathematical power of the polygon
        /// </summary>
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