using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using DekartGraphic;
using System.Drawing.Printing;

namespace Lab_03
{
    public partial class Form3 : Form
    {
        DekartForm dForm = null;

        //double h = 0.1;
        double h = 0.001225;
        float a, b;

        public Form3()
        {
            InitializeComponent();
			//TopMost = false;
		}

        #region functions

        public static double f(double x)
        { return 1.0 / (x * x) - Math.Exp(-x); }

        double df_analytic(double x)
        { return -2.0 / (x * x * x) + Math.Exp(-x); }
        double d2f_analytic(double x)
        { return 6.0 / (x * x * x * x) - Math.Exp(-x); }
        double d3f_analytic(double x)
        { return -24.0 / (x * x * x * x * x) + Math.Exp(-x); }

        double df_numeric2(double x)
        { return (f(x + h) - f(x - h)) / 2.0 / h; }
        double d2f_numeric2(double x)
        {
            return (f(x + h) - 2 * f(x) + f(x - h)) /
                (h * h);
        }
        double d3f_numeric2(double x)
        {
            return (f(x + 2 * h) +
                2 * (f(x - h) - f(x + h)) -
                f(x - 2 * h)) /
               (2 * (h * h * h));
        }

        double df_numeric4(double x)
        {
            return (-f(x + 1.5 * h)
                + 27 * f(x + 0.5 * h)
                - 27 * f(x - 0.5 * h)
                + f(x - 1.5 * h))
                / 24.0 / h;
        }
        double d2f_numeric4(double x)
        {
            return (-f(x + 2 * h)
                + 16 * f(x + h)
                - 30 * f(x)
                + 16 * f(x - h)
                - f(x - 2 * h))
                / (12 * h * h);
        }
        double d3f_numeric4(double x)
        {
            return (-f(x + 3 * h)
                + 16 * f(x + 2 * h)
                - 29 * f(x + h)
                + 29 * f(x - h)
                - 16 * f(x - 2 * h)
                + f(x - 3 * h))
                / (24 * h * h * h);
        }

        double df_error2(double x)
        {
            return
                Math.Abs(df_analytic(x) - df_numeric2(x));
        }
        double d2f_error2(double x)
        {
            return
                Math.Abs(d2f_analytic(x) - d2f_numeric2(x));
        }
        double d3f_error2(double x)
        {
            return
                Math.Abs(d3f_analytic(x) - d3f_numeric2(x));
        }

        double df_error4(double x)
        {
            return
                Math.Abs(df_analytic(x) - df_numeric4(x));
        }
        double d2f_error4(double x)
        {
            return
                Math.Abs(d2f_analytic(x) - d2f_numeric4(x));
        }
        double d3f_error4(double x)
        {
            return
                Math.Abs(d3f_analytic(x) - d3f_numeric4(x));
        }
		
        #endregion

        private void tool_f_Click(object sender, EventArgs e)
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

            if ((!checkBoxReuse.Checked) || (dForm == null))
            {
                dForm = new DekartForm(100, 100, 50, 400);
                dForm.Size = new Size(440, 540);
            }
            else
            { dForm.RemoveAllGraphics(); }

            dForm.Text = "Green - f(x)";
            dForm.AddGraphic(new DoubleFunction(f), a, b, DrawModes.DrawLines,
                Color.Green);
            dForm.Show();
        }

        private void tool_df_Click(object sender, EventArgs e)
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

            if ((!checkBoxReuse.Checked) || (dForm == null))
            {
                dForm = new DekartForm(150, 150, 50, 200);
                dForm.Size = new Size(730, 560);
            }
            else
            { dForm.RemoveAllGraphics(); }

            dForm.Text = "'First derivate' | "+
				"Green - numeric | "+
				"Blue - analytic | "+
				"Red - error";

            dForm.AddGraphic(df_numeric2, a, b, DrawModes.DrawLines,
                Color.Green);
            dForm.AddGraphic(df_numeric4, a, b, DrawModes.DrawLines,
                Color.Olive);
            dForm.AddGraphic(df_analytic, a, b, DrawModes.DrawLines,
                Color.Blue);
            dForm.AddGraphic(df_error2, a, b, DrawModes.DrawLines,
                Color.Red);
            dForm.AddGraphic(df_error4, a, b, DrawModes.DrawLines,
                Color.Magenta);
            dForm.Show();
        }

        private void tool_d2f_Click(object sender, EventArgs e)
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

            if ((!checkBoxReuse.Checked) || (dForm == null))
            {
                dForm = new DekartForm(150, 150, 50, 600);
                dForm.Size = new Size(730, Screen.PrimaryScreen.Bounds.Height - 50/*560*/);
                dForm.Top = 5;
            }
            else
            { dForm.RemoveAllGraphics(); }

            dForm.Text = "'Second derivate' | "+
				"Green - numeric | "+
				"Blue - Analytic | "+
				"Red - Error";
            dForm.AddGraphic(d2f_numeric2, a, b, DrawModes.DrawLines,
                Color.Green);
            dForm.AddGraphic(d2f_numeric4, a, b, DrawModes.DrawLines,
                Color.Olive);
            dForm.AddGraphic(d2f_analytic, a, b, DrawModes.DrawLines,
                Color.Blue);
            dForm.AddGraphic(d2f_error2, a, b, DrawModes.DrawLines,
                Color.Red);
            dForm.AddGraphic(d2f_error4, a, b, DrawModes.DrawLines,
                Color.Magenta);
            dForm.Show();
        }

        private void tool_d3f_Click(object sender, EventArgs e)
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

            if ((!checkBoxReuse.Checked) || (dForm == null))
            {
                dForm = new DekartForm(75, 75, 25, 150);
                dForm.Size = new Size(400,
					Screen.PrimaryScreen.Bounds.Height - 50/*560*/);
                dForm.Top = 5;
            }
            else
            { dForm.RemoveAllGraphics(); }

            dForm.Text = "'Third derivate' | "+
				"Green - numeric | "+
				"Blue - analytic | "+
				"Red - error o(h^2) | "+
				"Magenta - error o(h^4)";

            dForm.AddGraphic(d3f_numeric2, a, b, DrawModes.DrawLines,
                Color.Green);
            dForm.AddGraphic(d3f_numeric4, a, b, DrawModes.DrawLines,
                Color.Olive);

            dForm.AddGraphic(d3f_analytic, a, b, DrawModes.DrawLines,
                Color.Blue);

            dForm.AddGraphic(d3f_error2, a, b, DrawModes.DrawLines,
                Color.Red);
            dForm.AddGraphic(d3f_error4, a, b, DrawModes.DrawLines,
                Color.Magenta);
            dForm.Show();
        }

		private void integrationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new FormIntgr().Show();
		}
    }
}