using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Fractions;
using Lab3_Transport;

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
                    //x[i, j] = (Fraction)(rnd.Next(20) * 10 + 100);
                }

            a = new Fraction[m];
            b = new Fraction[n];
            Fraction s = new Fraction();

            for (int i = 0; i < m; i++)
            {
                a[i] = (Fraction)rnd.Next(400) + 200;
                s += a[i];

            }
            for (int j = 0; j < n - 1; j++)
            {
                b[j] = (Fraction)rnd.Next(300) + 200;
                s -= b[j];
            }
            b[n - 1] = s;

            cycle = new List<Point>();
            cycle.Add(new Point(1, 3));
            cycle.Add(new Point(2, 3));
            cycle.Add(new Point(2, 0));
            cycle.Add(new Point(4, 0));
            cycle.Add(new Point(4, 2));
            cycle.Add(new Point(1, 2));
            cycle.Add(new Point(1, 3));
            cycle = null;

            CToGrid();
            UpdateGrid();
        }

        private void CToGrid()
        {
            for (int i = 0; i < c.GetLength(0); i++)
                for (int j = 0; j < c.GetLength(1); j++)
                    dataGridView1[j, i].Value = c[i, j];
        }

        //Point tmp = new Point(-1,-1);
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

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                RectangleF recfBounds = new RectangleF(e.CellBounds.X, e.CellBounds.Y,
                    e.CellBounds.Width, e.CellBounds.Height);

                Fraction val;
                StringFormat sf;

                val = c[e.RowIndex, e.ColumnIndex];
                sf = sfc;
                if (val != null)
                    e.Graphics.DrawString(
                        val.ToString("Wrong"),
                        e.CellStyle.Font,
                        Brushes.Black,
                        recfBounds,
                        sf);

                val = x[e.RowIndex, e.ColumnIndex];
                sf = sfx;
                if (val != null)
                    e.Graphics.DrawString(
                            val.ToString("Wrong"),
                            e.CellStyle.Font,
                            Brushes.Black,
                            recfBounds,
                            sf);

                e.Handled = true;
            }
        }

        private void DrawCycle(Graphics g)
        {
            StringFormat sfs = new StringFormat();
            sfs.Alignment = StringAlignment.Near;
            sfs.LineAlignment = StringAlignment.Near;

            float r = 1.5f;
            Pen linePen = new Pen(Color.DarkSlateGray, 2f);
            Pen ellPen = new Pen(Color.DarkSlateGray, 2*r);

            Font signFont = new Font(FontFamily.GenericSerif, 12f, FontStyle.Bold);

            List<Point>.Enumerator enumer = cycle.GetEnumerator();
            enumer.MoveNext();
            Point firstPt = enumer.Current;
            PointF pt1;
            PointF pt2;

            Rectangle bnds1;
            bnds1 = dataGridView1.GetCellDisplayRectangle(
                enumer.Current.Y,
                enumer.Current.X,
                false);
            pt2 = new PointF(
                (bnds1.Left + bnds1.Right) / 2f,
                (bnds1.Top + bnds1.Bottom) / 2f);

            int i = 1;
            while (enumer.MoveNext())
            {
                bnds1 = dataGridView1.GetCellDisplayRectangle(
                    enumer.Current.Y,
                    enumer.Current.X,
                    false);
                pt1 = new PointF(
                    (bnds1.Left + bnds1.Right) / 2f,
                    (bnds1.Top + bnds1.Bottom) / 2f);

                g.DrawLine(linePen, pt1, pt2);
                //g.FillEllipse(Brushes.White, pt1.X - r, ptTo.Y - r, 2 * r, 2 * r);
                g.DrawEllipse(ellPen, pt1.X - r, pt1.Y - r, 2 * r, 2 * r);
                g.DrawString(
                    ((i++ & 1) == 1) ? "-" : "+",
                    signFont,
                    Brushes.Black,
                    pt1.X, pt1.Y,
                    sfs);

                pt2 = pt1;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Fraction value;

            try
            {
                value = Fraction.Parse(
                    dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString()
                    );
            }
            catch (FormatException eF)
            {
                MessageBox.Show(eF.Message, "Ошибка ввода", MessageBoxButtons.OK);
                return;
            }
            catch (NullReferenceException)
            {
                return;
            }

            if (e.ColumnIndex == n && e.RowIndex < m)
            {
                a[e.RowIndex] = value;
                UpdateGrid();
                return;
            }

            if (e.RowIndex == m && e.ColumnIndex < n)
            {
                b[e.ColumnIndex] = value;
                UpdateGrid();
                return;
            }

            if (e.RowIndex < m && e.ColumnIndex < n)
            {
                c[e.RowIndex, e.ColumnIndex] =
                    Fraction.Parse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
            }
           // dataGridView1.InvalidateCell(e.ColumnIndex, e.RowIndex);
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

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if (cycle != null)
            {
                DrawCycle(e.Graphics);
            }
        }

        private void act1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, j;
            Solver s = new Solver(c, a, b);
            x = s.x = s.NWCorner();
            cycle = new List<Point>();
            
            s.MkPotentials(out u, out v);
            s.FindDelta(out i, out j);

            try
            {
                s.MkCycle(i, j);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            cycle = s.cycle;

            UpdateGrid();
            dataGridView1.Refresh();
        }
    }
}