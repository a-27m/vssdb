using System;
using System.Windows.Forms;
using DekartGraphic;

namespace Lab_03
{
    public partial class FormIntgr : Form
    {
        double a, b;
        DoubleFunction f = Form3.f;

        double F(double x)
        {
            return -1 / x + Math.Exp(-x);
        }

        public FormIntgr()
        {
            InitializeComponent();
        }

        private void buttonEval_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBoxA.Text);
                b = float.Parse(textBoxB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Parsing error, aborted.");
                return;
            }

            int n = (int)numericUpDownN.Value;

            double res = 0;
            if (radioSimpson.Checked)
            {
                res = Simpson(a, b, n);
                textBox2Simp.Text = res.ToString();
                textBox2SimpDelta.Text = Math.Abs(res - F(b) + F(a)).ToString("F20");
            }

            if (radioTrapezium.Checked)
            {
                res = Trapezium(a, b, n);
                textBox1Trap.Text = res.ToString();
                textBox1TrapDelta.Text = Math.Abs(res - F(b) + F(a)).ToString("F20");
            }

            if (radioGauss2.Checked)
            {
                res = Gauss2(a, b);
                textBox3Gauss2.Text = res.ToString();
                textBox3Gauss2Delta.Text = Math.Abs(res - F(b) + F(a)).ToString("F20");
            }

            if (radioGauss3.Checked)
            {
                res = Gauss3(a, b);
                textBox4Gauss3.Text = res.ToString();
                textBox4Gauss3Delta.Text = Math.Abs(res - F(b) + F(a)).ToString("F20");
            }

            if (radioBull.Checked)
            {
                res = BullNatural(a, b, n);
                textBox6Bull.Text = res.ToString();
                textBox6BullDelta.Text = Math.Abs(res - F(b) + F(a)).ToString("F20");
            }

            if (radioRomberg.Checked)
            {
                res = Romberg(a, b, n);
                textBox5Romberg.Text = res.ToString();
                textBox5RombergDelta.Text = Math.Abs(res - F(b) + F(a)).ToString("F20");
            }
        }

        private double Romberg(double a, double b, int k)
        {
            double k4 = Math.Pow(4, k);
            int j = k;
            return (k4 * _romberg(a, b, j, k - 1) - _romberg(a, b, j - 1, k - 1))
                / (k4 - 1);
        }
        private double _romberg(double a, double b, int j, int k)
        {
            if (k == 0)
                return Trapezium(a, b, j);
            if (k == 1)
                return Simpson(a, b, j);
            if (k == 2)
                return Bull(a, b, j);

            double k4 = Math.Pow(4, k);
            return (k4 * _romberg(a, b, j, k - 1) - _romberg(a, b, j - 1, k - 1))
                / (k4 - 1);
        }

        private double Bull(double a, double b, int j)
        {
            return (16 * Simpson(a, b, j)
                - Simpson(a, b, j - 1))
                / 15.0;
        }
        private double BullNatural(double a, double b, int n)
        {
            double sum = 0;
            n = (n + n % 4);
            double h = (b - a) / n;
            for (int k4 = 4; k4 <= n; k4 += 4)
            {
                sum += 7 * f(a + k4 * h - 4 * h)
                    + 32 * f(a + k4 * h - 3 * h)
                    + 12 * f(a + k4 * h - 2 * h)
                    + 32 * f(a + k4 * h - 1 * h)
                    + 7 * f(a + k4 * h);
            }
            return sum * 2.0 * h / 45.0;
        }
        private double Trapezium(double a, double b, int n)
        {
            double Sum = (f(a) + f(b)) / 2.0;
            double h = (b - a) / n;
            for (int i = 1; i < n - 1; i++)
                Sum += f(a + h * i);
            return Sum * h;
        }
        private double Simpson(double a, double b, int n)
        {
            n = n + n % 2;
            double h = (b - a) / n;
            n /= 2;

            double Sum = f(a) + f(b)
                + 4 * f(b - h);

            for (int i = 2; i < 2 * n; i += 2)
            {
                // even
                Sum += 2.0 * f(a + i * h);
                // odd
                Sum += 4.0 * f(a + i * h - h);
            }

            return Sum * h / 3.0;
        }
        private double Gauss2(double a, double b)
        {
            double ab2 = (a + b) / 2.0;
            double h = (b - a) / 2.0;

            double t1 = -Math.Sqrt(1.0 / 3.0);
            double t2 = -t1;

            double x1 = ab2 + h * t1;
            double x2 = ab2 + h * t2;

            return (f(x1) + f(x2)) * h;
        }
        private double Gauss3(double a, double b)
        {
            double ab2 = (a + b) / 2.0;
            double h = (b - a) / 2.0;

            double t1 = -Math.Sqrt(0.6);
            double t2 = 0;
            double t3 = -t2;

            double x1 = ab2 + h * t1;
            double x2 = ab2 + 0;
            double x3 = ab2 + h * t3;

            double sum =
                5 * (f(x1) + f(x3)) + 8 * f(x2);

            return sum / 9.0 * h;
        }
    }
}