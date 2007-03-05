using System;
using System.Drawing;
using System.Windows.Forms;
using Fractions;

namespace ММИО_л1
{
    public partial class FormSTables : Form
    {
        int tableCount = 0;
        int I = 0;
        string[][] dataToPopulate;
        int maxCols;

        public FormSTables()
        {
            InitializeComponent();
        }

        public void AddTable(int[] basis, Fraction[] c, Fraction[,] table)
        {
            if (++tableCount == 1)
            {
                dataGridView1.Rows.Add();
                for (int j = 5; j < c.Length + 5; j++)
                    dataGridView1[j, 0].Value = c[j - 5].ToString();
                I = 1;
            }

            dataGridView1.Rows.Add(table.GetLength(1) + 1);

            for (int i = 0; i < table.GetLength(0); i++)
                for (int j = 0; j < table.GetLength(1); j++)
                    dataGridView1[j + 4, I + i].Value = table[i, j].ToString();

            for (int i = 0; i < basis.Length; i++)
            {
                dataGridView1[0, I + i].Value = tableCount.ToString();
                dataGridView1[1, I + i].Value = (i + 1).ToString();
                dataGridView1[2, I + i].Value = "A" + basis[i].ToString();
                dataGridView1[3, I + i].Value = c[basis[i] - 1];
            }

            I += table.GetLength(0);
            I++;// indent

            dataGridView1.AutoResizeColumns();
        }

        void UpdateGrid()
        {
            for (int i = 0; i < maxCols; i++)
            {
                dataGridView1.Columns.Add((DataGridViewColumn)(colA0.Clone()));
                dataGridView1.Columns.GetLastColumn(DataGridViewElementStates.None,
                    DataGridViewElementStates.None).HeaderText = "A" + (i + 1).ToString();
            }

        }
    }
}