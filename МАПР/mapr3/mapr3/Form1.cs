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
        int[,] a;
        float[,] p;
        int[] q;
        int c1, c2, c3, n1, n2, Variant;

        int n = 11;

        public Form1()
        {
            InitializeComponent();

            c1 = 20;
            c2 = 50;
            c3 = 10;
            n1 = 5;
            n2 = 5;
            Variant = 15;

            errorProvider1.Clear();

            textBoxC1.Text = c1.ToString();
            textBoxC2.Text = c2.ToString();
            textBoxC3.Text = c3.ToString();
            textBoxN1.Text = n1.ToString();
            textBoxN2.Text = n2.ToString();
            textBoxN.Text = Variant.ToString();

            p = new float[n, n];
            q = new int[n];
        }

        private void buttonBuildIncome_Click(object sender, EventArgs ep)
        {
            errorProvider1.Clear();
            bool ok = true;

            ok &= ctrlToVal(textBoxC1, out c1);
            ok &= ctrlToVal(textBoxC2, out c2);
            ok &= ctrlToVal(textBoxC3, out c3);
            ok &= ctrlToVal(textBoxN1, out n1);
            ok &= ctrlToVal(textBoxN2, out n2);
            ok &= ctrlToVal(textBoxN, out Variant);

            if (!ok) return;

            BuildEmptyGridWithHeaders(Variant);

            a = BuildIncomeMatrix(n, c1, c2, c3, n1, n2, Variant);

            MatrixToGrid(a, dgv1);

            dgv1.AutoResizeColumns();

            // make square cells
            //for (int i = 0; i < dgv1.Rows.Count; i++)
            //{
            //    dgv1.Rows[i].Height = dgv1.Columns[1].Width; 
            //}
        }

        private void BuildEmptyGridWithHeaders(int N)
        {
            dgv1.Rows.Clear();
            dgv1.Columns.Clear();

            for (int i = 0; i < n; i++)
                dgv1.Columns.Add((i + 1).ToString(), "F" + (N + i).ToString());

            dgv1.Rows.Add(n);
            for (int i = 0; i < n; i++)
                dgv1.Rows[i].HeaderCell.Value = "E" + (N + i).ToString();
        }

        private int[,] BuildIncomeMatrix(int n, int c1, int c2, int c3, int n1, int n2, int N)
        {
            int[,] e = new int[n, n];

            // Ei alternative
            // Fj condition
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    e[i, j] = 0;

                    int Ei = N + i; // buses
                    int Fj = N + j; // passes

                    // c1 - gas
                    // c2 - income
                    // c3 - penalty

                    int d = Fj - Ei;

                    // lack of buses
                    if (d > 0)
                    {
                        Fj = Ei;

                        if (d > n2)
                            e[i, j] -= c3 * (d - n2);
                    }
                    else
                    {
                        if (-d > n1)
                            e[i, j] += (-d - n1) * c2; // работают с полной отдачей
                    }

                    e[i, j] += Fj * c2 - Ei * c1;
                }

            return e;
        }

        private void MatrixToGrid(int[,] m, DataGridView dgv)
        {
            if (m == null) return;

            if (m.GetLength(0) > dgv.RowCount)
            {
                return;
            }
            if (m.GetLength(1) > dgv.ColumnCount)
            {
                return;
            }

            // check rows columns
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dgv1[j,i].Value = m[i, j];
        }

        private bool ctrlToVal(TextBox textBox, out int val)
        {
            if (!int.TryParse(textBox.Text, out val))
            {
                errorProvider1.SetError(textBox, "Ожидается целое число");
                return false;
            }

            return true;
        }

        private void buttonCriteries_Click(object sender, EventArgs e)
        {
            int iE;
            int income;

            iE = MiniMax(a, out income);
            PrintResult(iE, income, "Minimax");

            iE = MiniMax(a, out income);
            PrintResult(iE, income, "Minimax");

            iE = MiniMax(a, out income);
            PrintResult(iE, income, "Minimax");

            iE = MiniMax(a, out income);
            PrintResult(iE, income, "Minimax");

        }

        private void PrintResult(int iE, int income, string methodName)
        {

            string strFormatCriteria = "{0}:\t\tE{1}, with income {2}";
            textBox1.AppendText(string.Format(strFormatCriteria,
                methodName, iE + Variant, income));
        }

        private int MiniMax(int[,] a, out int maxValue)
        {
            int iE = 0;
            maxValue = int.MinValue;
            
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int min = MinValueInRow(a, i);
                if (min > maxValue)
                {
                    maxValue = min;
                    iE = i;
                }
            }

            return iE;
        }

        private int MinValueInRow(int[,] a, int i)
        {
            int min = int.MaxValue;

            for (int j = 0; j < a.GetLength(1); j++)

                if (a[i, j] < min)

                    min = a[i, j];

            return min;
        }
    }
}
