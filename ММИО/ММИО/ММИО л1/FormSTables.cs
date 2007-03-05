using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Fractions;

namespace ММИО_л1
{
    public partial class FormSTables : Form
    {
        int tableCount = 0;
        List<string[]> dataToPopulate;
        int maxCols;

        public FormSTables()
        {
            InitializeComponent();
            dataToPopulate = new List<string[]>();
        }

        public void AddTable(int[] basis, Fraction[] c, Fraction[,] table)
        {
            maxCols = table.GetLength(1) > maxCols ? table.GetLength(1) : maxCols;

            if (++tableCount == 1)
            {
                string[] lineC = new string[c.Length + 5];
                for (int j = 5; j < c.Length + 5; j++)
                    lineC[j] = c[j - 5].ToString();
                dataToPopulate.Add(lineC);
            }

            string[] line;
            for (int i = 0; i < table.GetLength(0)-1; i++)
            {
                line = new string[table.GetLength(1) + 4];
                line[0] = tableCount.ToString();
                line[1] = (i + 1).ToString();
                line[2] = "A" + basis[i].ToString();
                line[3] = c[basis[i] - 1].ToString();
                for (int j = 0; j < table.GetLength(1); j++)
                    line[j + 4] = table[i, j].ToString();

                dataToPopulate.Add(line);
            }

            line = new string[table.GetLength(1) + 4];
            line[0] = tableCount.ToString();
            line[1] = "—";
            line[2] = "—";
            line[3] = "Δj:";
            for (int j = 0; j < table.GetLength(1); j++)
                line[j + 4] = table[table.GetLength(0)-1, j].ToString();

            dataToPopulate.Add(line);
        }

        void UpdateGrid()
        {
            dataGridView1.Rows.Clear();
            for (int i = dataGridView1.ColumnCount; i <= maxCols + 4; i++)
            {
                dataGridView1.Columns.Add((DataGridViewColumn)(colA0.Clone()));
                dataGridView1.Columns.GetLastColumn(DataGridViewElementStates.None,
                    DataGridViewElementStates.None).HeaderText = "A" + (dataGridView1.ColumnCount-5).ToString();
            }

            dataGridView1.Rows.Add(dataToPopulate.Count);
            List<string[]>.Enumerator enu = dataToPopulate.GetEnumerator();
            for (int i = 0; enu.MoveNext(); i++)
            {
                for (int j = 0; j < enu.Current.Length; j++)
                    dataGridView1[j, i].Value = enu.Current[j];
            }

            dataGridView1.AutoResizeColumns();
        }

        private void FormSTables_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormSTables_Shown(object sender, EventArgs e)
        {
            UpdateGrid();
        }
    }
}