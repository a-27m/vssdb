using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataProc;

namespace mapr3
{
    public partial class Form1 : Form
    {
        int c1, c2, c3, n1, n2, N;
        int[,] e;
        float[,] p;
        int[] q;

        int n = 11;

        public Form1()
        {
            InitializeComponent();

            c1 = 20;
            c2 = 50;
            c3 = 20;
            n1 = 5;
            n2 = 5;
            N = 4;

            errorProvider1.Clear();

            textBoxC1.Text = c1.ToString();
            textBoxC2.Text = c2.ToString();
            textBoxC3.Text = c3.ToString();
            textBoxN1.Text = n1.ToString();
            textBoxN2.Text = n2.ToString();
            textBoxN.Text = N.ToString();

            e = new int[n, n];
            p = new float[n, n];
            q = new int[n];
        }

        private void button1_Click(object sender, EventArgs ep)
        {
            dgv1.Rows.Clear();
            dgv1.Columns.Clear();

            for (int i = 0; i < n; i++)
                dgv1.Columns.Add((i + 1).ToString(), "F" + (N+i).ToString());

            dgv1.Rows.Add(n);
            for (int i = 0; i < n; i++)
                dgv1.Rows[i].HeaderCell.Value = "E" + (N + i).ToString();

            dgv1.AutoResizeColumns();

            errorProvider1.Clear();

            ctrlToVal(textBoxC1, out c1);
            ctrlToVal(textBoxC2, out c2);
            ctrlToVal(textBoxC3, out c3);
            ctrlToVal(textBoxN1, out n1);
            ctrlToVal(textBoxN2, out n2);
            ctrlToVal(textBoxN, out N);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    int Ei = N + i;
                    int Fi = N + j; 

                    e[i, j] = Fi * c2 - Ei*c1;

                    int d = Fi - Ei;
                    
                    // недостаток
                    if (d > n2)
                        e[i, j] -= c3 * d;

                    if (-d > n1)
                        e[i, j] += -d * c1; // возвращаем затраты (маршрутки не использованы)
                    
                }

            MatrixToGrid(e, dgv1);
        }

        private void MatrixToGrid(int[,] a, DataGridView dgv)
        {
            // check rows columns
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dgv1[j,i].Value = a[i, j];

        }

        private void ctrlToVal(TextBox textBox, out int val)
        {
            if (!int.TryParse(textBox.Text, out val))
                errorProvider1.SetError(textBox, "Ожидается целое число");
        }
    }
}
