using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Fractions;

namespace mmio1
{
    public partial class FormSTables : Form
    {
        string frFormat = "W";

        int tableCount = 0;
        List<string[]> dataToPopulate;
        int maxCols;

        public FormSTables()
        {
            InitializeComponent();
            dataToPopulate = new List<string[]>();
        }

        public void ResetIterationCounter() { tableCount = 0; }

        public void AddTable(int[] basisJ, Fraction[] c, Fraction[,] table)
        {
            maxCols = table.GetLength(1) > maxCols ? table.GetLength(1) : maxCols;

            if (++tableCount == 1)
            {
                string[] lineC = new string[c.Length + 5];
                for (int j = 5; j < c.Length + 5; j++)
                    lineC[j] = c[j - 5].ToString(frFormat);
                dataToPopulate.Add(lineC);
                dataToPopulate.Add(new string[] { "" });
            }

            string[] line;
            for (int i = 0; i < table.GetLength(0) - 1; i++)
            {
                line = new string[table.GetLength(1) + 4];
                line[0] = tableCount.ToString();
                line[1] = (i + 1).ToString();
                line[2] = "A" + basisJ[i].ToString();
                line[3] = c[basisJ[i] - 1].ToString(frFormat);
                for (int j = 0; j < table.GetLength(1); j++)
                    line[j + 4] = table[i, j].ToString(frFormat);

                dataToPopulate.Add(line);
            }

            line = new string[table.GetLength(1) + 4];
            line[0] = tableCount.ToString();
            line[1] = "—";
            line[2] = "—";
            line[3] = "Δj:";
            for (int j = 0; j < table.GetLength(1); j++)
                line[j + 4] = table[table.GetLength(0) - 1, j].ToString(frFormat);

            dataToPopulate.Add(line);
            dataToPopulate.Add(new string[] { "" });
        }

        void UpdateGrid()
        {
            dataGridView1.Rows.Clear();
            for (int i = dataGridView1.ColumnCount; i < maxCols + 4; i++)
            {
                dataGridView1.Columns.Add((DataGridViewColumn)(colA0.Clone()));
                dataGridView1.Columns.GetLastColumn(DataGridViewElementStates.None,
                    DataGridViewElementStates.None).HeaderText = "A" + (dataGridView1.ColumnCount - 5).ToString();
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

        private void FormSTables_FormClosing(object sender, EventArgs e)
        {
            e.Cancel = true;
            //dataToPopulate = new List<string[]>();
            //tableCount = 0;
            this.Hide();
        }

        private void FormSTables_Shown(object sender, EventArgs e)
        {
            UpdateGrid();
            Size = dataGridView1.GetPreferredSize(Size);
        }

        public void AddTable(Fraction[,] table)
        {
            ++tableCount;

            maxCols = table.GetLength(1) > maxCols ? table.GetLength(1) : maxCols;

            string[] line;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                line = new string[table.GetLength(1) + 4];
                line[0] = tableCount.ToString();
                line[1] = (i + 1).ToString();
                line[2] = "";
                line[3] = "";
                for (int j = 0; j < table.GetLength(1); j++)
                    line[j + 4] = table[i, j].ToString(frFormat);

                dataToPopulate.Add(line);
            }

            dataToPopulate.Add(new string[] { "" });
        }

        public void AddLine(string Title, Fraction[] table)
        {
            //++tableCount;

            maxCols = table.Length+1 > maxCols ? table.Length+1 : maxCols;

            string[] line;
            line = new string[table.Length + 5];
            line[0] = Title;
            line[1] = "";
            line[2] = "";
            line[3] = "";
            line[4] = "";
            for (int j = 0; j < table.Length; j++)
                line[j + 5] = table[j].ToString(frFormat);

            dataToPopulate.Add(line);
            dataToPopulate.Add(new string[] { "" });
        }
    }
}