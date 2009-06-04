using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab_6___Own_vect_and_num
{
    public partial class Form1 : Form
    {
        int n;
        double eps;
        double[,] A, T, U;

        public Form1()
        {
            InitializeComponent();

            textBoxEps.Text = (1e-3).ToString();
        }

        void Find()
        {
            U = null;

            while (CheckZero() == false)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = i+1; j < n; j++)
                    {
                        PrepareT(i, j);

                        A = MultMatrixReverse(T, A);
                        A = MultMatrix(A, T);

                        if (U == null) U = (double[,])T.Clone();
                        else U = MultMatrix(U, T);

                        PrintWide(dgvT, T, A, true);

                        if (CheckZero()) goto stop;
                    }
                }
            }
        stop:
            return;
        }

        private void PrepareT(int I, int J)
        {
            T = new double[n,n];

            double alpha = 0.5*Math.Atan(2*A[I,J] / (A[I,I] - A[J,J]));

            for (int i = 0; i < n; i++) T[i,i] = 1;

            T[I,I] = Math.Cos(alpha);
            T[I,J] = -Math.Sin(alpha);
            T[J,I] = Math.Sin(alpha);
            T[J,J] = Math.Cos(alpha);
        }

        private double[,] MultMatrix(double[,] A, double[,] B)
        {
            double[,] r = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        r[i, j] += A[i,k] * B[k, j];
                    }
                }
            }
            return r;
        }

        private double[,] MultMatrixReverse(double[,] A, double[,] B)
        {
            double[,] r = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        r[i, j] += A[k, i] * B[k, j];
                    }
                }
            }

            return r;
        }

        private bool CheckZero()
        {
            double sD = 0, sS = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) sD += Math.Abs(A[i, j]);
                    else sS += Math.Abs(A[i, j]);
                }
            }

            return sS < eps/(n*n-n);
        }

        private void SetSize(DataGridView dgv, int n)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            for (int i = 0; i < n; i++)
            {
                dgv.Columns.Add("c" + (i + 1).ToString(), (i + 1).ToString());
            }
        }

        public void ReadA()
        {
            A = new double[n, n];

            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        A[i, j] = double.Parse(dgvA[j, i].Value.ToString());
                    }
                }
            }
            catch (FormatException) { MessageBox.Show("Неверный формат числа"); }
        }

        private void Print(DataGridView dgv, double[,] A, bool Add)
        {
            int offset = 0;
            if (Add)
            {
                dgv.Rows.Add(n);
                offset = dgv.Rows.Count - A.GetLength(0);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dgv[j, i+ offset].Value = A[i, j].ToString("F4");
                }
            }
            dgv.Rows.Add(1);
        }

        private void PrintWide(DataGridView dgv, double[,] T, double[,] U, bool Add)
        {
            int offset = 0;
            if (Add)
            {
                dgv.Rows.Add(n);
                offset = dgv.Rows.Count - A.GetLength(0);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dgv[j, i + offset].Value = T[i, j].ToString("F4");
                    dgv[j+n+1, i + offset].Value = U[i, j].ToString("F4");
                }
            }

            dgv.Rows.Add(1); // div
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = (int)numericUpDown1.Value;
            SetSize(dgvA, n);
            SetSize(dgvX, n);
            SetSize(dgvT, n);
            
            dgvA.Rows.Add(n);

            dgvT.Columns.Add("div", "");
            for (int i = 0; i < n; i++)
            {
                dgvT.Columns.Add("c" + (i + 1).ToString(), (i + 1).ToString());
            }

            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReadA();
            try
            {
                eps = double.Parse(textBoxEps.Text);
            }catch(FormatException)
            {
                MessageBox.Show("Неверный формат числа в поле \"точность\"");
                return;
            }

            dgvT.Rows.Clear();
            dgvX.Rows.Clear();
            listBox1.Items.Clear();

            Find();

            if (U!= null) Print(dgvX, U, true);

            for (int i = 0; i < n; i++)
            {
                listBox1.Items.Add("L"+(i+1).ToString()+" = "+A[i,i].ToString("F4"));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            for(int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                {
                    string val = rnd.Next(-10, 10).ToString();
                    dgvA[j, i].Value = val;
                    dgvA[i, j].Value = val;
                }
        }

        
    }
}
