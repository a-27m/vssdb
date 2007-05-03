﻿#define debug

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
    public delegate double DoubleOfVectorFunction(params double[] X);

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

        double f1(params double[] X)
        {
#if debug
            if (X.Length < 2)
                throw new ArgumentException("Too few args", "X");
#endif

            // original
            double x = X[0];
            double y = X[1];
            return x * x * x - 2 * Math.Sin(x) - y;
            //return x * x - 4;
        }
        double f2(params double[] X)
        {
#if debug
            if (X.Length < 2)
                throw new ArgumentException("Too few args", "X");
#endif

            // original
            double x = X[0];
            double y = X[1];
            return Math.Sqrt(y + 7) * Math.Cos(y) - x;
            //return 0;
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

        private Complex Newtone(DoubleOfVectorFunction[] Fns,
            Complex z0, double eps, out int iterations)
        {
            double x = z0.re;
            double y = z0.im;
            double x0, y0;

            iterations = 0;

            DoubleOfVectorFunction F = Fns[0];
            DoubleOfVectorFunction G = Fns[1];

            do
            {
                x0 = x;
                y0 = y;

                //get new approximation in (x,y)
                //by evaluation of known expressions respectively

                //a:=eval(diff(f,x),[x=x0,y=y0]);b:=eval(diff(f,y),[x=x0,y=y0]);
                //d:=eval(f,[x=x0,y=y0]);
                //k(x,y):=a*(x-x0)+b*(y-y0)+d

                double F0 = F(x0, y0);
                double G0 = G(x0, y0);
                double dFx0 = dFx(F, x0, y0);
                double dFy0 = dFy(F, x0, y0);
                double dGx0 = dFx(G, x0, y0);
                double dGy0 = dFy(G, x0, y0);
                double t = -dGx0 * dFy0 + dFx0 * dGy0;

                if (t == 0)
                    return Complex.NaN;
                if (double.IsNaN(t))
                    return Complex.NaN;
                x = (G0 * dFy0 - dGy0 * F0) / t + x0;
                y = (dGx0 * F0 - dFx0 * G0) / t + y0;

                //x = G(x0, y0);
                //y = F(x, y0);

                iterations++;

                if (iterations % 200 == 0)
                    return Complex.NaN;

                //} while (Math.Sqrt(x * x + y * y) - Math.Sqrt(x0 * x0 + y0 * y0) >= eps);
            } while (Math.Abs(Math.Abs(F(x, y) - G(x, y)) - Math.Abs(F(x0, y0) - G(x0, y0))) >= eps);


            return new Complex(x,y);
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
            double hx = 0.1;

            //double y1 = -2;
            //double y2 = 2;
            double hy = 0.1;

            for (double y = x1; y < x2; y += hy)
                for (double x = x1; x < x2; x += hx)
                {
                    int iterations;
                    float percent;
                    res = Newtone(new DoubleOfVectorFunction[] { f1, f2 }, new Complex(x, y), eps, out iterations);
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
                listY.Items.Add("f,g" + (listY.Items.Count + 1) + " = "
                    + f1(z.value.re, z.value.im).ToString("F6") +", "
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