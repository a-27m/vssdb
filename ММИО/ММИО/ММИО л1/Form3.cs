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

        int n, m;

        protected bool IsNewDocument = true;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 60;

            n = 5;
            m = 5;

            dataGridView1.Columns.Add("", "B1");
            dataGridView1.Columns.Add("", "B2");
            dataGridView1.Columns.Add("", "B3");
            dataGridView1.Columns.Add("", "B4");
            dataGridView1.Columns.Add("", "B5");
            dataGridView1.Columns.Add("", "SA");

            dataGridView1.Rows.Add(4);

            dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);

            Random rnd = new Random();
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = (Fraction)rnd.Next(20);
                    x[i, j] = (Fraction)(rnd.Next(20) * 10 + 100);
                }

            CToGrid();
        }

        private void CToGrid()
        {
            for (int i = 0; i < c.GetLength(0); i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = "A" + (i + 1).ToString();

                for (int j = 0; j < c.GetLength(1); j++)
                {
                    dataGridView1[j, i].Value = c[i, j];
                }
            }
        }

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
        }

        private void UpdateGrid()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    dataGridView1[j, i + 1].Value = c[i, j].ToString();

                dataGridView1[n + 1, i + 1].Value = a[i].ToString();
            }

            for (int i = 0; i < m; i++)
            {
                dataGridView1[n + 1, i].Value = a[i].ToString();

                if (u == null)
                    dataGridView1.Rows[i].HeaderText =
                            "A" + (i + 1).ToString();
                else
                    dataGridView1.Columns[j].HeaderText =
                        "A" + (i + 1).ToString() + ", u=" + u[i].ToString();
            }

            dataGridView1.AutoResizeColumns();

            //dataGridView1[n + 1, 0].ReadOnly = true;
            //dataGridView1[n, 0].ReadOnly = true;
        }

        private void GridMyResize()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();           

            dataGridView1.RowTemplate.Height = 60;
            
            for (int j = 0; j < n; j++)
                    dataGridView1.Columns.Add("", "B" + (j+1).ToString());
            dataGridView1.Columns.Add("", "Σa");

            dataGridView1.Rows.Add(m+1);
            for (int i = 0; i < m; i++)
                dataGridView1.Rows[i].HeaderCell.Value = "A" + (i + 1).ToString();
            dataGridView1.Rows[m].HeaderCell.Value = "Σb";

            dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);

            dataGridView1.AutoResizeColumns();
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