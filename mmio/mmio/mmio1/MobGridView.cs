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
        string[] rowHeaders, colHeaders;
        int rH, cW;
        Point editingCell;

        Font valueTextFont = new Font("Arial", 10, FontStyle.Regular);
        SolidBrush valueTextBrush = new SolidBrush(Color.Black);
        StringFormat valueStrFormat = new StringFormat();

        /// <summary>
        /// max col number
        /// </summary>
        int colcount;

        public object this[int column, int row]
        {
            get { return rows[row][column]; }
            set { rows[row][column] = value; }
        }

        public ICollection<object[]> Rows
        {
            get { return rows; }
        }

        public int ColumnCount
        {
            get
            {
                return colcount;
            }
        }

        public MobGridView()
        {
            rows = new List<object[]>();
            rowHeaders = new string[1];
            colHeaders = new string[1];
            colcount = 0;
            rH = oy = 20;
            cW = ox = 30;

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.BackColor = Color.LightBlue;
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Pen gridPen = new Pen(Color.Black, 1f);

            //draw grid
            //int maxX = e.ClipRectangle.Width < colcount * cW ? e.ClipRectangle.Width : colcount * cW;
            //int maxY = e.ClipRectangle.Height < rows.Count * rH ? e.ClipRectangle.Height : rows.Count * rH;
            int maxX = colcount * cW;
            int maxY = rows.Count * rH;

            for (int y = oy-rH; y <= maxY + oy; y += rH)
                g.DrawLine(gridPen, ox - cW, y, maxX + ox, y);

            for (int x = ox-cW; x <= maxX + ox; x += cW) //cW[k]
                g.DrawLine(gridPen, x, oy - rH, x, maxY + oy);


            // draw text

            int j = 0;
            RectangleF bndRect = new RectangleF();
            SizeF strSize;
            bndRect.Width = cW;
            bndRect.Height = rH;


            bndRect.Y = oy - rH;
            for (int i = 0; i < colHeaders.GetLength(0); i++)
            {
                if (colHeaders[i] == null) continue;

                strSize = g.MeasureString(colHeaders[i].ToString(), valueTextFont);
                bndRect.X = i * cW + (cW - strSize.Width) / 2 + ox - cW;

                g.DrawString(colHeaders[i].ToString(),
                    valueTextFont, valueTextBrush, bndRect, valueStrFormat);
            }

            foreach (object[] line in rows)
            {
                if (rowHeaders[j] != null)
                {
                    strSize = g.MeasureString(rowHeaders[j].ToString(), valueTextFont);
                    bndRect.X = ox - cW + (cW - strSize.Width - 2);
                    bndRect.Y = j * rH + oy - rH;

                    g.DrawString(rowHeaders[j].ToString(),
                        valueTextFont, valueTextBrush, bndRect, valueStrFormat);
                }

                bndRect.Y = j * rH + oy;
                for (int i = 0; i < line.GetLength(0); i++)
                {
                    if (line[i] == null) continue;

                    strSize = g.MeasureString(line[i].ToString(), valueTextFont);
                    bndRect.X = i * cW + (cW - strSize.Width) / 2 + ox;

                    g.DrawString(line[i].ToString(), valueTextFont, valueTextBrush, bndRect, valueStrFormat);
                }
                j++;
            }
        }

        public void ClearColumns()
        {
            colcount = 0;
        }

        public void ClearRows()
        {
            //for (IEnumerator<object[]> i = rows.GetEnumerator(); i.MoveNext(); )
            //{
            //    i.Current = null;
            //}

            rows.Clear();
        }

        public void AddColumn(string Title)
        {
            colcount++;
            for (int i = 0; i < rows.Count; i++)
            {
                object[] tmp = rows[i];
                ArrayResize<object>(ref tmp, rows[i].GetLength(0) + 1);
                rows[i] = tmp;
            }


            ArrayResize<string>(ref colHeaders, colHeaders.GetLength(0) + 1);
            colHeaders[colHeaders.GetLength(0) - 1] = Title;
        }

        public void AddRow(string Title)
        {
            rows.Add(new object[colcount]);
            ArrayResize<string>(ref rowHeaders, rowHeaders.GetLength(0) + 1);
            rowHeaders[rowHeaders.GetLength(0) - 1] = Title;
        }

        public void AddRows(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                rows.Add(new object[colcount]);
            }
            ArrayResize(ref rowHeaders, rowHeaders.GetLength(0) + Count);
        }

        public void SetRowHeaderText(int index, string Caption)
        {
            rowHeaders[index] = Caption;
        }

        public void SetColumnHeaderText(int index, string Caption)
        {
            colHeaders[index] = Caption;
        }

        // Array.Resize<Fraction>() cf replacement
        public void ArrayResize<Type>(ref Type[] array, int NewSize)
        {
            if (array.Length == NewSize) return; // ?

            Type[] tmpArray = new Type[NewSize];
            if (array.Length < NewSize)
            {
                array.CopyTo(tmpArray, 0);
            }
            else
            {
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    tmpArray[i] = array[i];
                }
            }

            array = tmpArray;
        }

        int mx, my;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            mx = e.X;
            my = e.Y;
        }

        int ox, oy;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ox += (e.X - mx);
                oy += (e.Y - my);

                mx = e.X;
                my = e.Y;

                Refresh();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            int r, c;

            c = (int)((e.X - ox) / cW);
            r = (int)((e.Y - oy) / rH);

            if ((r > rows.Count - 1)
                || (c > colcount - 1)
                || (c < 0) || (r < 0))
            {
                textBox1.Visible = false; return;
            }

            if (rows[r][c] != null)
                textBox1.Text = rows[r][c].ToString();
            editingCell.X = c;
            editingCell.Y = r;
            textBox1.Visible = true;
            textBox1.Focus();
            textBox1.SelectAll();            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                rows[editingCell.Y][editingCell.X] = textBox1.Text;
                textBox1.Text = "";
                textBox1.Visible = false;
                this.Refresh();
            }
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            // cancel edit
            textBox1.Text = "";
            textBox1.Visible = false;
        }
    }
}
