using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace mmio1
{
    public partial class MobGridView : UserControl
    {
        List<object[]> rows;

        public object this[int column, int row]
        {
            get { return rows[row][column]; }
            set { rows[row][column] = value; }
        }

        public ICollection<object[]> Rows { get { return rows; } }

        public int ColumnCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MobGridView()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush br = new SolidBrush(Color.PaleGreen);

            e.Graphics.FillRectangle(br, e.ClipRectangle);
        }

        internal void RowsAdd(int Count)
        {
            throw new NotImplementedException();
        }

        internal void ColumnsAdd(int Count)
        {
            throw new NotImplementedException();
        }

        internal void SetColumnHeaderText(int ColumnIndex, string Caption)
        {
            throw new NotImplementedException();
        }

        internal void ClearColumns()
        {
            throw new NotImplementedException();
        }

        internal void ClearRows()
        {
            throw new NotImplementedException();
        }

        internal void AddColumn()
        {
            throw new NotImplementedException();
        }

        internal void AddColumn(string p)
        {
            throw new NotImplementedException();
        }

        internal void AddRow(string p)
        {
            throw new NotImplementedException();
        }

        internal void SetRowHeaderText(int p, string p_2)
        {
            throw new NotImplementedException();
        }
    }
}
