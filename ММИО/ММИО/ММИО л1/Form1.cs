using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DekartGraphic;

namespace ММИО_л1
{
	public partial class Form1 : Form
	{
        protected bool IsNewDocument = true;

		public Form1()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
            if (e.ColumnIndex > -1)
			dataGridView1.AutoResizeColumn(e.ColumnIndex);
		}

        private void GridMyResize(int vars, int conds)
		{
			dataGridView1.Columns.Clear();
			dataGridView1.Rows.Clear();
			DataGridViewColumn col;

			for ( int i = 0; i < vars; i++ )
			{
			col = new DataGridViewColumn(CoefCol0.CellTemplate);
				col.HeaderText = "x"+(i+1).ToString();
				dataGridView1.Columns.Add(col);
			}

            col = new DataGridViewColumn(SignCol.CellTemplate);
            col.HeaderText = SignCol.HeaderText;
			dataGridView1.Columns.Add(col);

			col = new DataGridViewColumn(CoefCol0.CellTemplate);
			col.HeaderText = "b";
			dataGridView1.Columns.Add(col);

			dataGridView1.Rows.Add();
            dataGridView1.Rows[0].HeaderCell.Value = "F = ";

            for (int i = 1; i <= conds; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = "(" + i.ToString() + ")";
            }

			dataGridView1.AutoResizeColumns();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (this.IsNewDocument)
            {
                FormAskDim fad = new FormAskDim();
                if (fad.ShowDialog(this) != DialogResult.OK)
                    Close();
                GridMyResize(fad.N, fad.M);
                dataGridView1.Select();
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1d;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.7d;
        }
    }
}