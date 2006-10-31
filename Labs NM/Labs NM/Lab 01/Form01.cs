using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DekartGraphic;

namespace NM_Lab_01
{
    public partial class Form01 : Form
    {
        private delegate void TaskFunction();

        private double delta = 0.0001;

        TaskFunction[] taskFuntions;

        public Form01()
        {
            InitializeComponent();
            textBoxDelta.Text = delta.ToString();

            taskFuntions = new TaskFunction[3];

            taskFuntions[0] = new TaskFunction(Task1);
            taskFuntions[1] = new TaskFunction(Task3);
            taskFuntions[2] = new TaskFunction(Task9);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBoxForm().ShowDialog();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(labelTaskResult.Text);
        }

        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            GetDelta();
            taskFuntions[tabControl1.SelectedIndex]();
        }

        private bool GetDelta()
        {
            if (!double.TryParse(textBoxDelta.Text, out delta))
            {
                MessageBox.Show("Wrong double number passed (delta)!");
                return false;
            }
            if (delta < double.Epsilon)
            {
                MessageBox.Show("Delta is too little for double type.");
                return false;
            }
            return true;
        }

        private void PrintRes(double Sum, int n, double epsilon)
        {
            labelTaskResult.Text = Sum.ToString();
            MessageBox.Show("Evaluation stopped at member #" + n.ToString() + ",\r\n" +
                "Last epsilon = " + epsilon.ToString() + '.');
        }

        void Task1()
        {
            double eps;
            double currentSum = 0.0;
            double previousSum = currentSum;
            int n = 2;

            do
            {
                previousSum = currentSum;
                currentSum += 6.0 / (36.0 * n * n - 24.0 * n - 5.0);
                eps = currentSum - previousSum;
                n++;
            } while (Math.Abs(eps) >= delta);

            PrintRes(currentSum, n, eps);
        }
        void Task3()
        {
            double eps;
            double currentSum = 0.0;
            double previousSum = currentSum;
            int n = 1;

            do
            {
                previousSum = currentSum;
                currentSum += Math.Acos((n % 2 == 0 ? 1.0 : -1.0) * n / (n + 1.0)) /
                    (n * n + 2.0);
                eps = currentSum - previousSum;
                n++;
            } while (Math.Abs(eps) >= delta);

            PrintRes(currentSum, n, eps);
        }
        void Task9()
        {
            double eps;
            double currentSum = 0.0;
            double previousSum = currentSum;
            int n = 1;
            Int64 temp = 2;
            do
            {
                previousSum = currentSum;
                currentSum += (n % 2 == 0 ? 1.0 : -1.0) / temp;
                eps = currentSum - previousSum;
                temp *= 2 * n;
                n++;
            } while (Math.Abs(eps) >= delta);

            PrintRes(currentSum, n, eps);
        }

        double f11(double x)
        {
            double currentSum = 0.0;
            double previousSum = currentSum;
            double eps;
            int n = 1;

            do
            {
                previousSum = currentSum;

                //currentSum += Math.Pow(-1f, n) / Math.Pow(x + n, 1.0 / 3.0);

                currentSum += Math.Pow(
                    Math.Pow(n, 2.0 / 3.0) + Math.Sqrt(n) + 1,
                    -2 * x - 1);

                eps = currentSum - previousSum;
                n++;
                if (n > 10000)
                {
                    //MessageBox.Show("Ряд не сошелся в точке x = " + x.ToString());
                    break;
                }
            } while (Math.Abs(eps) >= delta);

            return currentSum;
        }

        double f_test(double x)
        {
            return x * x;
        }

        private void task11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetDelta();
            DekartForm df = new DekartForm(30, 30, 100, 200);

            df.AddGraphic(new DoubleFunction(f11), -0.7f, 10f, DrawModes.DrawPoints,
                Color.SpringGreen);
            df.Show2();
        }
    }

}