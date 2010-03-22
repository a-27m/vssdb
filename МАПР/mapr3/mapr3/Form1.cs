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
        int c1, c2, c3, n1, n2, Variant;

        int n = 11;

        private float q(int j)
        {
            j++;
            return (n + 1f - j) * j / (26f * n);
        }

        private float p(int i, int j)
        {
            return 1f - 0.01f * (Variant + i);
        }

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

        private void MatrixToGrid(int[,] m, DataGridView dgv) { MatrixToGrid<int>(m, dgv); }
        private void MatrixToGrid<TElement>(TElement[,] m, DataGridView dgv)
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

        private void buttonCriteries_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            int iE;
            int income;

            float alpha = 0.5f;

            iE = MiniMax(a, out income);
            PrintResult(iE, income, "Minimax (Wild)");

            iE = Laplace(a, out income);
            PrintResult(iE, income, "Laplace (neutral)");

            iE = Savage(a, out income);
            PrintResult(iE, income, "Savage (min regret)");

            iE = Hurwitz(a, alpha, out income);
            PrintResult(iE, income, "Hurwitz, a=" + alpha.ToString("F2"));

            iE = Production(a, out income);
            PrintResult(iE, income, "Production");


            iE = BayesLaplace(a, out income);
            PrintResult(iE, income, "Bayes-Laplace");

            iE = HodgeLehmann(a, alpha, out income);
            PrintResult(iE, income, "Hodge-Lehmann");

            iE = Geymeyer(a, out income);
            PrintResult(iE, income, "Geymeyer");
            
            iE = MostProbable(a, out income);
            PrintResult(iE, income, "Probable outcome");
        }

        private void PrintResult(int iE, int income, string methodName)
        {
            string strFormatCriteria = "{0}:\t\tE{1}, with income {2}" + Environment.NewLine;
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

        private int MaxiMin(int[,] a, out int minValue)
        {
            int iE = 0;
            minValue = int.MaxValue;
            
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int max = MaxValueInRow(a, i);
                if (max < minValue)
                {
                    minValue = max;
                    iE = i;
                }
            }

            return iE;
        }

        private int MaxValueInRow(int[,] a, int i)
        {
            int max = int.MinValue;

            for (int j = 0; j < a.GetLength(1); j++)

                if (a[i, j] > max)

                    max = a[i, j];

            return max;
        }

        private int MinValueInRow(int[,] a, int i)
        {
            int min = int.MaxValue;

            for (int j = 0; j < a.GetLength(1); j++)

                if (a[i, j] < min)

                    min = a[i, j];

            return min;
        }

        private int Laplace(int[,] a, out int income)
        {
            income = int.MinValue;
            int iE = -1;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                // srednee
                int mid = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    mid += a[i, j];
                }
                mid /= a.GetLength(1);

                // is it max?
                if (mid >= income)
                {
                    income = mid;
                    iE = i;
                }
            }

            return iE;
        }

        private int Savage(int[,] a, out int income)
        {
            income = int.MinValue;
            int iE = -1;

            // maryca zhaluy
            int[,] r = new int[a.GetLength(0), a.GetLength(1)];

            for (int j = 0; j < a.GetLength(1); j++)
            {
                // look for max in col
                int maxVal = a[0, j];
                //int maxI = 0;
                for (int i = 1; i < a.GetLength(0); i++)
                {
                    if (a[i, j] > maxVal)
                    {
                        maxVal = a[i, j];
                  //      maxI = i;
                    }
                }

                for (int i = 0; i < a.GetLength(0); i++)
                    r[i, j] = maxVal - a[i, j];
            }

            MatrixToGrid(r, dgv1);

            iE = MaxiMin(r, out income);

            income = MaxValueInRow(a, iE) - income;

            return iE;
        }

        private int Hurwitz(int[,] a, float alpha, out int income)
        {
            if (alpha < 0f) throw new ArgumentOutOfRangeException("alpha");
            if (alpha > 1f) throw new ArgumentOutOfRangeException("alpha");

            int iE = -1;
            float maxValue = float.MinValue;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                int min = MinValueInRow(a, i);
                int max = MaxValueInRow(a, i);
                float f = alpha * max + (1f - alpha) * min;

                if (f > maxValue)
                {
                    maxValue = (int)f;
                    iE = i;
                }
            }

            income = (int)maxValue;

            return iE;
        }

        private int Production(int[,] a, out int income)
        {
            income = 0;

            // calc min
            int min = a[0,0];
            foreach (int e in a)
                if (e < min) min = e;

            if (min <= 0)
            {
                // update to eliminate all non-positive
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        a[i, j] += -min; // since min < 0
            }

            MatrixToGrid(a, dgv1);
            
            int iE = 0;
            double maxValue = double.MinValue;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                double prod = a[i, 0];
                for (int j = 1; j < a.GetLength(1); j++) prod *= a[i, j];

                if (prod > maxValue)
                {
                    maxValue = prod;
                    iE = i;
                }
            }

            return iE;
        }

        
        private int BayesLaplace(int[,] a, out int income)
        {
            int iE = 0;
            float maxValue = float.MinValue;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                float sum = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    sum += a[i, j] * q(j) * p(i, j);
                }

                if (sum > maxValue)
                {
                    maxValue = sum;
                    iE = i;
                }
            }

            income = (int)maxValue;

            return iE;
        }

        private int HodgeLehmann(int[,] a, float alpha, out int income)
        {
            if (alpha < 0f) throw new ArgumentOutOfRangeException("alpha");
            if (alpha > 1f) throw new ArgumentOutOfRangeException("alpha");

            int iE = 0;
            float maxValue = float.MinValue;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                float sum = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    sum += a[i, j] * q(j) * p(i, j);
                }

                int min = MinValueInRow(a, i);

                float f = alpha * sum - (1f - alpha) * min;

                if (f > maxValue)
                {
                    maxValue = f;
                    iE = i;
                }
            }

            income = (int)maxValue;

            return iE;
        }

        private int Geymeyer(int[,] a, out int income)
        {
            float min = float.MaxValue;
            int iE = -1;

            // calc min
            int minE = a[0, 0];
            foreach (int e in a)
                if (e < minE) minE = e;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                float max = float.MinValue;

                if (minE <= 0)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        float eqp = a[i, j] * q(j) / p(i, j);
                        if (eqp > max) max = eqp;
                    }
                }
                else
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        float eqp = a[i, j] * q(j) * p(i, j);
                        if (eqp > max) max = eqp;
                    }
                }

                if (max < min)
                {
                    min = max;
                    iE = i;
                }
            }

            income = (int)min;
            return iE;
        }

        private int MostProbable(int[,] a, out int income)
        {
            income = 0;
            int iE = 0;

            //float[,] fl = new float[n, n];

            //for (int i = 0; i < a.GetLength(0); i++)
            //    for (int j = 0; j < a.GetLength(1); j++)
            //        fl[i, j] = q(j); 

            //MatrixToGrid(fl, dgv1);

            float maxValue = float.MinValue;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                float sum = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                    sum += q(j) * p(i, j);

                if (sum > maxValue)
                {
                    maxValue = sum;
                    iE = i;
                }
            }

            income = (int)maxValue;
            return iE;
        }

        private void dgv1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex < 0) || (e.RowIndex < 0))
            {

                e.Handled = true;
                return;
            }
        }
    }
}
