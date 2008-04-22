//#define debug

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
    public delegate double DoubleOfVectorFunction(double x, double y);

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

            textH.Text = 0.01.ToString();
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
                hx = float.Parse(textH.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textH, "Wrong float number");
                return;
            }
            if (eps < 0)
            {
                errorProvider.SetError(textH, "Has to be > 0");
                return;
            }

            hy = hx;

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

        double f1(double x, double y)
        {
#if debug
            if (X.Length < 2)
                throw new ArgumentException("Too few args", "X");
#endif
            // original
            //double x = X[0];
            //double y = X[1];
            return x * x * x - 2 * Math.Sin(x) - y;
            //return x * x - 4;
        }
        double f2(double x, double y)
        {
#if debug
            if (X.Length < 2)
                throw new ArgumentException("Too few args", "X");
#endif
            // original
            //double x = X[0];
            //double y = X[1];
            return Math.Sqrt(y + 7) * Math.Cos(y) - x;
            //return 0;
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
        double f2x(double t)
        {
            return Math.Sqrt(t + 7) * Math.Cos(t);
            //return Math.Sin(Math.Pow(t + 5, Math.Cos(t + 5)));
            //return t * t;
        }
        double f2y(double t)
        {
            return t;
        }
        double df1x(double z0, double z1)
        {
            return (f1(z0 + h, z1) - f1(z0 - h, z1)) / 2 / h;
        }
        double df1y(double z0, double z1)
        {
            return (f1(z0, z1 + h) - f1(z0, z1 - h)) / 2 / h;
        }
        double df2x(double z0, double z1)
        {
            return (f2(z0 + h, z1) - f2(z0 - h, z1)) / 2 / h;
        }
        double df2y(double z0, double z1)
        {
            return (f2(z0, z1 + h) - f2(z0, z1 - h)) / 2 / h;
        }

        double h = 1e-3;

        #region numerical derivates definitions
        double dFx(DoubleOfVectorFunction f, params double[] z)
        {
            return (f(z[0] + h, z[1]) - f(z[0] - h, z[1])) / 2 / h;
        }
        double dFy(DoubleOfVectorFunction f, params double[] z)
        {
            return (f(z[0], z[1] + h) - f(z[0], z[1] - h)) / 2 / h;
        }

        #endregion

        //private Complex Newtone(DoubleOfVectorFunction[] Fns,
        //    Complex z0, double eps, out int iterations)
        //{  //a:=eval(diff(f,x),[x=x0,y=y0]);b:=eval(diff(f,y),[x=x0,y=y0]);d:=eval(f,[x=x0,y=y0]);k(x,y):=a*(x-x0)+b*(y-y0)+d
        //    double x = z0.re;
        //    double y = z0.im;
        //    double x0, y0;
        //    DoubleOfVectorFunction F = Fns[0];
        //    DoubleOfVectorFunction G = Fns[1];
        //    iterations = 0;

        //    do
        //    {
        //        x0 = x;
        //        y0 = y;

        //        #region eval {F, G, dFx, dFy, dGx, dGy} @ (x0,y0)
        //        double F0 = F(x0, y0);
        //        double G0 = G(x0, y0);
        //        double dFx0 = dFx(F, x0, y0);
        //        double dFy0 = dFy(F, x0, y0);
        //        double dGx0 = dFx(G, x0, y0);
        //        double dGy0 = dFy(G, x0, y0);
        //        double t = -dGx0 * dFy0 + dFx0 * dGy0;

        //        if (t == 0)
        //            return Complex.NaN;
        //        if (double.IsNaN(t))
        //            return Complex.NaN;

        //        #endregion

        //        x = (G0 * dFy0 - dGy0 * F0) / t + x0;
        //        y = (dGx0 * F0 - dFx0 * G0) / t + y0;

        //        if (++iterations % 200 == 0)
        //            return Complex.NaN;

        //    } while (Math.Sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0)) >= eps);

        //    return new Complex(x, y);
        //}

        private Complex Newtone(DoubleOfVectorFunction[] Fns,
            Complex z0, double eps, out int iterations)
        {   //a:=eval(diff(f,x),[x=x0,y=y0]);
            //b:=eval(diff(f,y),[x=x0,y=y0]);
            //d:=eval(f,[x=x0,y=y0]);
            //k(x,y):=a*(x-x0)+b*(y-y0)+d
            double x = z0.re;
            double y = z0.im;
            double x0, y0;
            DoubleOfVectorFunction F = Fns[0];
            DoubleOfVectorFunction G = Fns[1];
            iterations = 0;

            do
            {
                x0 = x;
                y0 = y;

                #region eval {F, G, dFx, dFy, dGx, dGy} @ (x0,y0)

                double F0 = f1(x0, y0);
                double G0 = f2(x0, y0);
                double dFx0 = df1x(x0, y0);
                double dFy0 = df1y(x0, y0);
                double dGx0 = df2x(x0, y0);
                double dGy0 = df2y(x0, y0);

                double t = -dGx0 * dFy0 + dFx0 * dGy0;

                if (t == 0)
                    return Complex.NaN;
                if (double.IsNaN(t))
                    return Complex.NaN;

                #endregion

                x = (G0 * dFy0 - dGy0 * F0) / t + x0;
                y = (dGx0 * F0 - dFx0 * G0) / t + y0;

                if (++iterations % 200 == 0)
                    return Complex.NaN;

            } while (Math.Abs(x - x0) >= eps || Math.Abs(y - y0) >= eps);
            //} while (Math.Sqrt((x - x0) * (x - x0) + (y - y0) * (y - y0)) >= eps);

            return new Complex(x, y);
        }

        public double delta = 0.01;
        public bool Near(Complex x, Complex y)
        {
            if ((Math.Abs(x.re - y.re) < delta) &&
                (Math.Abs(x.im - y.im) < delta))
                return true;
            return false;
        }

        double hx = 0.01;
        double hy = 0.01;

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

            double y1 = x1, y2 = x2;

            DoubleOfVectorFunction[] dovf = new DoubleOfVectorFunction[] { f1, f2 };
            Complex c = new Complex(0);

            for (double y = y1; y < y2; y += hy)
                for (double x = x1; x < x2; x += hx)
                {
                    int iterations;
                    float percent;
                    c.re = x;
                    c.im = y;
                    res = Newtone(dovf, c, eps, out iterations);

                    bool inRange = true;
                    inRange &= res.re > x1;
                    inRange &= res.re < x2;
                    inRange &= res.im > y1;
                    inRange &= res.im < y2;


                    if (Complex.IsNaN(res) || !inRange)
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

                        percent = iterations / 15f;
                        if (percent > 1f)
                            percent = 1f;

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
                Color.Black, Color.DimGray, Color.DimGray, Color.Gray);
            dForm.AddGraphic(dotGraphic);

            MathGraphic mg;
            mg = new MathGraphic(Color.White, DrawModes.DrawLines, f1x, f1y,
                -5f, 5f, 0.01f);
            dForm.AddGraphic(mg);

            mg = new MathGraphic(Color.White, DrawModes.DrawLines, f2x, f2y,
                -5f, 5f, 0.01f);
            dForm.AddGraphic(mg);

            dForm.Show();
            dForm.Update2();

            foreach (Root z in roots)
            {
                listRoots.Items.Add("z" + (listRoots.Items.Count + 1) + " = "
                   + z.value.ToString("F6"));
                listY.Items.Add("f,g" + (listY.Items.Count + 1) + " = "
                    + f1(z.value.re, z.value.im).ToString("F6") + ", "
                    + f2(z.value.re, z.value.im).ToString("F6"));
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