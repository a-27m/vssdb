using System;
using System.Drawing;
using System.Windows.Forms;
using Fractions;

namespace ММИО_л1
{
    public partial class FormSTables : Form
    {
        int tableCount = 0;

        public FormSTables()
        {
            InitializeComponent();
        }

        public void AddTable(int[] basis, Fraction[] c, Fraction[,] table)
        {
            if (dataGridView1.ColumnCount < table.GetLength(0) +5)
            {

            }

            if (tableCount++ == 1)
            {
                dataGridView1.Rows.Add();
                for (int j = 5; j < c.Length + 5; j++)
                    dataGridView1.Rows[0].Cells[j] = c.ToString();
            }

            dataGridView1.Rows.Add(table.GetLength(1));
        }
    }
}