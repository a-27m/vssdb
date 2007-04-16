using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DekartGraphic;

namespace AlgTheory
{
    public partial class Form1 : Form
    {

        float x1 = 0, x2 = 7;

        const double eps = 1e-7;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool ok = true;

            try
            {
                x1 = float.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                errorProvider1.SetError(textBox1, "Неверный формат вещественного числа");
                ok = false;
            }

            try
            {
                x2 = float.Parse(textBox2.Text);
            }
            catch (FormatException)
            {
                errorProvider1.SetError(textBox2, "Неверный формат вещественного числа");
                ok = false;
            }

            if (!ok)
                return;

            DekartForm df = new DekartForm(50, 50, 30, 150);
            df.Text = "y ≈ sin(x)";
            df.AddGraphic(new DoubleFunction(delegate(double x)
            {
                double a, sum =x;
                uint n = 2;
                a = x;
                do
                {
                    a *= -x * x / n / (n + 1);
                    sum += a;
                    n += 2;
                }
                while (Math.Abs(a) >= eps);

                listBox1.Items.Add("x = "+ x.ToString("f3")+ ", n = "+n.ToString() );
                return sum;
            }), x1, x2, DrawModes.DrawPoints, Color.Green);

            df.Show();
            df.Update2();
        }
    }
}