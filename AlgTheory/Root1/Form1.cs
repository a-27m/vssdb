using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DekartGraphic;

namespace Root1
{
    public partial class Form1 : Form
    {
        public delegate void RootFoundHandler(double x);
        public event RootFoundHandler RootFound;

        DekartForm df;

        public Form1()
        {
            InitializeComponent();
            df = new DekartForm(100, 100, 300, 150);
            df.Text = "";
            df.Use_IsVisible = false;
            df.AddGraphic(f1, -10, 10, DrawModes.DrawLines, Color.Green);
            RootFound += new RootFoundHandler(Form1_RootFound);
        }

        void Form1_RootFound(double x)
        {
            df.AddPolygon(Color.Red, DrawModes.DrawLines,
                new PointF((float)x, 1),
                new PointF((float)x, -1));
            df.Update2();
        }

        double f1(double x)
        {
            return Math.Sin(x * x - 4);
        }

        double fxy(double x, double y)
        {
            return x * x * x + y * y * y - x * y;
        }

        public struct complex
        {
            public double real;
            public double imagine;

            public complex(double re, double im)
            {
                real = re;
                imagine = im;
            }

            public complex Add(complex c1, complex c2)
            {
                return new complex(c1.real + c2.real, c1.imagine + c2.imagine);
            }
        }

        double[] Iteration(double a, double b, DoubleFunction f)
        {
            double h = 1e-3;
            List<double> roots = new List<double>();
            int lastSign = Math.Sign(f(a));

            for (double x = a; x <= b; x += h)
            {
                int sign = Math.Sign(f(x));
                if (sign == 0)
                    sign = lastSign;
                if (sign != lastSign)
                {
                    roots.Add(x);
                    OnRootFound(x);
                }
                lastSign = sign;
            }

            return roots.ToArray();
        }

        void OnRootFound(double x)
        {
            if (RootFound != null)
                RootFound(x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            df.Show();
            df.Update2();

            Iteration(-1, 10, f1);
        }
    }
}