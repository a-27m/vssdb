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

        public Form1()
        {
            InitializeComponent();

            c1 = 300;
            c2 = 620;
            c3 = 200;
            n1 = 5;
            n2 = 5;
            N = 15;

            errorProvider1.Clear();

            textBoxC1.Text = c1.ToString();
            textBoxC2.Text = c2.ToString();
            textBoxC3.Text = c3.ToString();
            textBoxN1.Text = n1.ToString();
            textBoxN2.Text = n2.ToString();
            textBoxN.Text = N.ToString();

            e = new int[10, 10];
            p = new float[10, 10];
            q = new int[10];
        }

        private void button1_Click(object sender, EventArgs ep)
        {
            dgv1.Rows.Clear();
            dgv1.Columns.Clear();

            for (int i = 0; i < 10; i++)
                dgv1.Columns.Add((i + 1).ToString(), "F" + (i + 1).ToString());

            dgv1.Rows.Add(10);
            for (int i = 0; i < 10; i++)
                dgv1.Rows[i].HeaderCell.Value = "E" + (i + 1).ToString();

            dgv1.AutoResizeColumns();

            errorProvider1.Clear();

            ctrlToVal(textBoxC1, out c1);
            ctrlToVal(textBoxC2, out c2);
            ctrlToVal(textBoxC3, out c3);
            ctrlToVal(textBoxN1, out n1);
            ctrlToVal(textBoxN2, out n2);
            ctrlToVal(textBoxN, out N);

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    e[i, j] = 10 * i + j + 11;
                }

            MatrixToGrid(e, dgv1);
        }

        private void MatrixToGrid(int[,] a, DataGridView dgv)
        {
            // check rows columns
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    dgv[j, i].Value = a[i, j];
        }

        private void ctrlToVal(TextBox textBox, out int val)
        {
            if (!int.TryParse(textBox.Text, out val))
                errorProvider1.SetError(textBox, "Ожидается целое число");
        }
    }
}
