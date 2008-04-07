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

        Point[] cycle;

        int n, m;
        Solver s;
        SolidBrush fntBrush = null;

        protected bool IsNewDocument = true;

        public Form3()
        {
            InitializeComponent();
            dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
        }

        private void RandomizeTask()
        {
            Random rnd = new Random();
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = (Fraction)rnd.Next(20);
                }

            Fraction s = new Fraction();

            for (int i = 0; i < m; i++)
            {
                a[i] = (Fraction)rnd.Next(n * 50) + 10;
                s += a[i];

            }
            for (int j = 0; j < n; j++)
            {
                b[j] = (Fraction)rnd.Next(m * 50) + 10;
                s -= b[j];
            }
            if (s < 0)
                a[m - 1] -= s;
            if (s > 0)
                b[n - 1] += s;

            CToGrid();
            UpdateGrid();
        }

        private void CToGrid()
        {
            for (int i = 0; i < c.GetLength(0); i++)
                for (int j = 0; j < c.GetLength(1); j++)
                    dataGridView1[j, i].Value = c[i, j];
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

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                RectangleF recfBounds = new RectangleF(e.CellBounds.X, e.CellBounds.Y,
                    e.CellBounds.Width, e.CellBounds.Height);

                Fraction val;
                StringFormat sf;

                if (fntBrush == null)
                    fntBrush = new SolidBrush(Color.Black);

                if (dataGridView1[e.ColumnIndex, e.RowIndex].Selected)
                    fntBrush.Color = dataGridView1.DefaultCellStyle.SelectionForeColor;
                else 
                    fntBrush.Color = dataGridView1.DefaultCellStyle.ForeColor;

                val = c[e.RowIndex, e.ColumnIndex];
                sf = sfc;
                if (val != null)
                    e.Graphics.DrawString(
                        val.ToString("Wrong"),
                        e.CellStyle.Font,
                        fntBrush,
                        recfBounds,
                        sf);

                val = x[e.RowIndex, e.ColumnIndex];
                sf = sfx;
                if (val != null)
                    e.Graphics.DrawString(
                            val.ToString("Wrong"),
                            e.CellStyle.Font,
                            fntBrush,
                            recfBounds,
                            sf);


                try
                {
                    if (x[e.RowIndex, e.ColumnIndex] == null)
                    {
                        val = u[e.RowIndex] + v[e.ColumnIndex] - c[e.RowIndex, e.ColumnIndex];
                        sf = sfx;
                        if (val > 0)
                        {
                            e.Graphics.DrawString(
                                   val.ToString("Wrong"),
                                   e.CellStyle.Font,
                                   Brushes.CornflowerBlue,
                                   recfBounds,
                                   sf);
                            Rectangle recfBox = new Rectangle(
                                e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height / 2,
                                e.CellBounds.Width / 3, e.CellBounds.Height / 2);
                            e.Graphics.DrawRectangle(Pens.CornflowerBlue, recfBox);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    e.Handled = true;
                }
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
            Pen ellPen = new Pen(Color.DarkSlateGray, 2 * r);

            Font signFont = new Font(FontFamily.GenericSerif, 12f, FontStyle.Bold);

            if (cycle != null)
                if (cycle.Length > 2)
                {
                    Point firstPt = cycle[0];
                    PointF pt1;
                    PointF pt2;

                    Rectangle bnds1;
                    bnds1 = dataGridView1.GetCellDisplayRectangle(
                        cycle[0].Y,
                        cycle[0].X,
                        false);
                    pt2 = new PointF(
                        (bnds1.Left + bnds1.Right) / 2f,
                        (bnds1.Top + bnds1.Bottom) / 2f);

                    for (int i = 1; i < cycle.Length; i++)
                    {
                        bnds1 = dataGridView1.GetCellDisplayRectangle(
                            cycle[i].Y,
                            cycle[i].X,
                            false);
                        pt1 = new PointF(
                            (bnds1.Left + bnds1.Right) / 2f,
                            (bnds1.Top + bnds1.Bottom) / 2f);

                        g.DrawLine(linePen, pt1, pt2);
                        //g.FillEllipse(Brushes.White, pt1.X - r, ptTo.Y - r, 2 * r, 2 * r);
                        g.DrawEllipse(ellPen, pt1.X - r, pt1.Y - r, 2 * r, 2 * r);
                        g.DrawString(
                            ((i & 1) == 1) ? "-" : "+",
                            signFont,
                            Brushes.Black,
                            pt1.X, pt1.Y,
                            sfs);

                        pt2 = pt1;
                    }
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

            if (s != null)
                s.MkPotentials(out u, out v);
            UpdateGrid();
            dataGridView1.Refresh();
        }

        /// <summary>
        /// Для записи значений в ячейки, которые отрисовываются стандартным методом
        /// </summary>
        private void UpdateGrid()
        {
            for (int i = 0; i < m; i++)
            {
                dataGridView1[n, i].Value = a[i];              

                if (u == null)
                    dataGridView1.Rows[i].HeaderCell.Value =
                        "A" + (i + 1).ToString();
                else
                    dataGridView1.Rows[i].HeaderCell.Value =
                        "A" + (i + 1).ToString() + ", u=" + u[i].ToString();
            }

            for (int j = 0; j < n; j++)
            {
                dataGridView1[j, m].Value = b[j];

                if (v == null)
                    dataGridView1.Columns[j].HeaderText =
                        "B" + (j + 1).ToString();
                else
                    dataGridView1.Columns[j].HeaderText =
                        "B" + (j + 1).ToString() + ", v=" + v[j].ToString();
            }

            dataGridView1[n, m].ReadOnly = true;
        }

        private void GridMyResize()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.RowTemplate.Height = 40;
            int colWidth = dataGridView1.RowTemplate.Height + dataGridView1.RowTemplate.Height / 2;

            for (int j = 0; j < n; j++)
            {
                dataGridView1.Columns.Add("", "B" + (j + 1).ToString());
                dataGridView1.Columns[j].Width = colWidth;
            }
            dataGridView1.Columns.Add("", "Σa");

            dataGridView1.Rows.Add(m + 1);
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

            x = new Fraction[m, n];

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
            if (s == null)
            {
                s = new Solver(c, a, b);
                x = s.x = s.NWCorner();
                s.MkPotentials(out u, out v);
            }

            try
            {
                s.MkPotentials(out u, out v);
                if (!s.FindDelta(out i, out j))
                    throw new Exception("No more chanses to improve the plan");
                s.MkCycle(i, j);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                cycle = s.Cycle;

                Text = "F = " + s.CalcF();

                UpdateGrid();
                dataGridView1.Refresh();
            }
        }

        private void act2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                s.Traverse();
                s.MkPotentials(out u, out v);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            cycle = null;

            Text = "F = " + s.CalcF();

            UpdateGrid();
            dataGridView1.Refresh();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, j;
            if (s == null)
            {
                s = new Solver(c, a, b);
                x = s.x = s.NWCorner();
            }

            Exception exception = new Exception("No more chanses to improve the plan");

            try
            {
                while (true)
                {
                    s.MkPotentials(out u, out v);
                    if (!s.FindDelta(out i, out j))
                        throw exception;
                    s.MkCycle(i, j);
                    s.Traverse();
                }
            }
            catch (Exception exc)
            {
                if (exception != exc)
                    MessageBox.Show(exception.Message);
            }
            finally
            {
                cycle = null;

                Text = "F = " + s.CalcF();

                UpdateGrid();
                dataGridView1.Refresh();
            }
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            if (this.IsNewDocument)
            {
                FormAskDim fad = new FormAskDim();
                if (fad.ShowDialog(this) != DialogResult.OK)
                    Close();
                n = fad.N;
                m = fad.M;

                x = new Fraction[m, n];
                c = new Fraction[m, n];
                a = new Fraction[m];
                b = new Fraction[n];

                GridMyResize();
                dataGridView1.Select();
            }
        }

        private void randomizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsNewDocument)
            {

            }
            s = null;
            RandomizeTask();
        }
    }
}