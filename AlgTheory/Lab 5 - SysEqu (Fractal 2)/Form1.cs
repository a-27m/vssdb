#define debug

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using ComplexNumbers;
using DekartGraphic;

namespace Lab_5___SysEqu__Fractal_2_
{
    public delegate double DoubleOfComplexFunction(double[] X);

    public partial class Form1 : Form
    {
        Matrix matrix;
        DekartForm dForm = null;

        double eps;
        float x1, x2;

        public Form1()
        {
            InitializeComponent();
            matrix = new Matrix(300, 0f, 0f, -300, 200, 200);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textE.Text = 0.001.ToString();
            textP0.Text = "1";

            textX1.Text = (-1.5).ToString();
            textX2.Text = 1.5.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        double f1(double[] X)
        {
#if debug
            if (X.Length < 2)
                throw new ArgumentException("Too few args", "X");
#endif

            // original
            double x = X[0];
            double y = X[1];
            return x * x * x - 2 * Math.Sin(x) - y;
        }
        double f2(double[] X)
        {
#if debug
            if (X.Length < 2)
                throw new ArgumentException("Too few args", "X");
#endif
         
            // original
            double x = X[0];
            double y = X[1];
            return Math.Sqrt(y + 7) * Math.Cos(y) - x;
        }

        double h = 1e-3;

        double dF_dx(DoubleOfComplexFunction f, Complex z)
        {
            return f(
        }

        private Complex Newtone(DoubleOfComplexFunction[] F,
            Complex z0, double eps, out int iterations)
        {
            Complex x_old, x = z0;

            iterations = 0;

            do
            {
                x_old = x;

                double dx = F[1]

                iterations++;

                if (iterations % 200 == 0)
                    return Complex.NaN;

            } while (Complex.Norm(x - x_old) >= eps);

            return x;
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

            //double x1 = -2;
            //double x2 = 2;
            double hx = 0.01;

            //double y1 = -2;
            //double y2 = 2;
            double hy = 0.01;

            for (double y = x1; y < x2; y += hy)
                for (double x = x1; x < x2; x += hx)
                {
                    int iterations;
                    float percent;
                    res = Newtone(new DoubleOfComplexFunction[] {f1, f2 }, new Complex(x, y), eps, out iterations);
                    percent = iterations / 30f;
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
            g = (int)Math.Round(c.G * percent);
            b = (int)Math.Round(c.B * percent);

            return Color.FromArgb(r, g, b);
        }
    }
}