using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fractions;
using System.Runtime.Serialization;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace ММИО_л1
{
    public partial class Form3 : Form, IForm1
    {
        Fraction[,] c;
        Fraction[,] x;

        Fraction[] a;
        Fraction[] b;

        Fraction[] u;
        Fraction[] v;

        List<Point> cycle;

        int n, m;

        protected bool IsNewDocument = true;

        public Form3()
        {
            InitializeComponent();
            dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 60;

            n = 5;
            m = 5;

            GridMyResize();

            x = new Fraction[m, n];
            c = new Fraction[m, n];

            Random rnd = new Random();
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = (Fraction)rnd.Next(20);
                    x[i, j] = (Fraction)(rnd.Next(20) * 10 + 100);
                }

            a = new Fraction[m];
            b = new Fraction[n];

            for (int i = 0; i < m; i++)
            {
                a[i] = new Fraction();
                for (int j = 0; j < n; j++)
                    a[i] += x[i, j];
            }

            for (int j = 0; j < n; j++)
            {
                b[j] = new Fraction();
                for (int i = 0; i < m; i++)
                    b[j] += x[i, j];
            }

            cycle = new List<Point>();
            cycle.Add(new Point(2, 2));
            cycle.Add(new Point(4, 2));
            cycle.Add(new Point(4, 0));
            cycle.Add(new Point(2, 0));
            cycle.Add(new Point(2, 3));
            cycle.Add(new Point(2, 0));
            cycle.Add(new Point(2, 2));

            CToGrid();
            UpdateGrid();
        }

        private void CToGrid()
        {
            for (int i = 0; i < c.GetLength(0); i++)
                for (int j = 0; j < c.GetLength(1); j++)
                    dataGridView1[j, i].Value = c[i, j];
        }

        Point tmp = new Point(-1,-1);
        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex < 0) || (e.RowIndex < 0))
                return;

            if ((e.ColumnIndex < n) && (e.RowIndex < m))
            {
                StringFormat sfc = new StringFormat();
                StringFormat sfx = new StringFormat();

                sfc.Alignment = StringAlignment.Far;
                sfc.LineAlignment = StringAlignment.Near;

                sfx.Alignment = StringAlignment.Near;
                sfx.LineAlignment = StringAlignment.Far;

                e.PaintBackground(e.CellBounds, true);

                e.Paint(e.CellBounds,
                    DataGridViewPaintParts.All ^
                    DataGridViewPaintParts.ContentForeground);

                RectangleF recfBounds = new RectangleF(e.CellBounds.X, e.CellBounds.Y,
                    e.CellBounds.Width, e.CellBounds.Height);

                e.Graphics.DrawString(
                    c[e.RowIndex, e.ColumnIndex].ToString("Wrong"),
                    e.CellStyle.Font,
                    Brushes.Black,
                    recfBounds,
                    sfc);

                e.Graphics.DrawString(
                    x[e.RowIndex, e.ColumnIndex].ToString("Wrong"),
                    e.CellStyle.Font,
                    Brushes.Black,
                    recfBounds,
                    sfx);

                if (cycle != null)
                {
                    tmp.X = e.ColumnIndex;
                    tmp.Y = e.RowIndex;
                    int i = cycle.IndexOf(tmp);
                    if (i > 0) 
                    {
                        
                    }
                }

                e.Handled = true;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                c[e.RowIndex, e.ColumnIndex] =
                    Fraction.Parse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
            }
            catch (FormatException eF)
            {
                MessageBox.Show(eF.Message, "Ошибка ввода", MessageBoxButtons.OK);
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        /// <summary>
        /// Для записи значений в ячейки, которые отрисовываются стандартным методом
        /// </summary>
        private void UpdateGrid()
        {
            for (int i = 0; i < m; i++)
            {
                dataGridView1[n, i].Value = a[i].ToString();

                if (u == null)
                    dataGridView1.Rows[i].HeaderCell.Value =
                        "A" + (i + 1).ToString();
                else
                    dataGridView1.Rows[i].HeaderCell.Value =
                        "A" + (i + 1).ToString() + ", u=" + u[i].ToString();
            }

            for (int j= 0; j < n; j++)
            {
                dataGridView1[j, m].Value = b[j].ToString();

                if (v == null)
                    dataGridView1.Columns[j].HeaderText =
                        "B" + (j + 1).ToString();
                else
                    dataGridView1.Columns[j].HeaderText =
                        "B" + (j + 1).ToString() + ", v=" + v[j].ToString();
            }

            //dataGridView1[n + 1, 0].ReadOnly = true;
            //dataGridView1[n, 0].ReadOnly = true;
        }

        private void GridMyResize()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.RowTemplate.Height = 60;
            int colWidth = dataGridView1.RowTemplate.Height + dataGridView1.RowTemplate.Height / 2;

            for (int j = 0; j < n; j++)
            {
                dataGridView1.Columns.Add("", "B" + (j + 1).ToString());
                dataGridView1.Columns[j].Width = colWidth; 
            }
            dataGridView1.Columns.Add("", "Σa");

            dataGridView1.Rows.Add(m+1);
            for (int i = 0; i < m; i++)
                dataGridView1.Rows[i].HeaderCell.Value = "A" + (i + 1).ToString();
            dataGridView1.Rows[m].HeaderCell.Value = "Σb";

            //dataGridView1.AutoResizeColumns();
        }

        #region IForm1 Members

        public void LoadData(string FileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress, false);
            a = (Fraction[])formatter.Deserialize(zipStream);
            b = (Fraction[])formatter.Deserialize(zipStream);
            c = (Fraction[,])formatter.Deserialize(zipStream);

            zipStream.Close();
            stream.Close();

            m = a.Length;
            n = b.Length;

            if (c.GetLength(0) != m || c.GetLength(1) != n)
                throw new SerializationException("Wrong matrix C dimensions in file");

            GridMyResize();
            UpdateGrid();

            IsNewDocument = false;
        }

        public void SaveData(string FileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            GZipStream zipStream = new GZipStream(stream, CompressionMode.Compress, false);
            formatter.Serialize(zipStream, a);
            formatter.Serialize(zipStream, b);
            formatter.Serialize(zipStream, c);
            zipStream.Close();
        }

        #endregion
    }
}