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
        double[,] A, T, U;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = (int)numericUpDown1.Value;
            SetSize(n);
        }

        private void SetSize(int n)
        {
            dgvA.Rows.Clear();
            dgvA.Columns.Clear();

            for (int i = 0; i < n; i++)
            {
                dgvA.Columns.Add("c" + (i + 1).ToString(), (i + 1).ToString());
                dgvX.Columns.Add("c" + (i + 1).ToString(), (i + 1).ToString());
                dgvT.Columns.Add("c" + (i + 1).ToString(), (i + 1).ToString());
            }

            dgvA.Rows.Add(n);
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

        public void PrintA()
        {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        dgvA[j, i].Value = A[i, j].ToString("F4");
                    }
                }
        }

        void Find()
        {
            T = new double[n, n];

            PrepareT(0, 1);
            U = T;

            while (CheckZero() == false)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = i+1; j < n; j++)
                    {
                        PrepareT(i, j);
                        Print(dgvT, T, true);

                        A = MultMatrixReverse(T, A);
                        A = MultMatrix(A, T);

                        U = MultMatrix(U, T);
                    }
                }
            }
        }

        private double[,] MultMatrix(double[,] A, double[,] B)
        {
            double[,] r = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    r[i, j] += A[i, j] * B[j, i];
                }
            }

            return r;
        }

        private double[,] MultMatrixReverse(double[,] A, double[,] TransB)
        {
            double[,] r = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    r[i, j] += A[i, j] * TransB[i, j];
                }
            }

            return r;
        }

        private void Print(DataGridView dgv, double[,] A, bool Add)
        {
            int offset = 0;
            if (Add)
            {
                dgv.Rows.Add(n + 1);
                offset = dgv.Rows.Count - A.GetLength(0);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dgv[j, i+ offset].Value = A[i, j].ToString("F4");
                }
            }
        }


        private void PrepareT(int I, int J)
        {
            T = new double[n,n];

            double alpha = 0.5*Math.Atan(2*A[I,J] / (A[I,I] - A[J,J]));

            for (int i = 0; i < n; i++) T[i,i] = 1;

            T[I,I] = Math.Cos(alpha);
            T[I,J] = Math.Sin(alpha);
            T[J,I] = -Math.Sin(alpha);
            T[J,J] = Math.Cos(alpha);
        }

        private bool CheckZero()
        {
            double sD = 0, sS = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) sD += A[i, j];
                    else sS += A[i, j];
                }
            }

            return sS < 0.001;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReadA();
            Find();
            Print(dgvA, A, false);
            Print(dgvX, U, true);
        }

        
    }
}
