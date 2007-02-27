using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DekartGraphic;

namespace ММИО_л1
{
	public partial class Form1 : Form
	{
		int n = 0, m = 0;

		public int N
		{
			get { return n; }
			set { n = value; numericUpDownN.Value = value; }
		}

		public int M
		{
			get { return m; }
			set { m = value; numericUpDownM.Value = value; }
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			dataGridView1.AutoResizeColumn(e.ColumnIndex);
		}

		private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			this.M = dataGridView1.RowCount-1;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			N = (int)(numericUpDownN.Value);
			M = (int)(numericUpDownM.Value);
			GridMyResize(N, M);
			dataGridView1.Select();
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

			dataGridView1.Columns.Add(new DataGridViewColumn(SignCol.CellTemplate));

			col = new DataGridViewColumn(CoefCol0.CellTemplate);
			col.HeaderText = "b";
			dataGridView1.Columns.Add(col);

			dataGridView1.Rows.Add(conds + 1);

			dataGridView1.AutoResizeColumns();
		}
	}
}