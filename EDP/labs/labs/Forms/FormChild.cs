using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataProc;

namespace lab1.Forms
{
    public partial class FormChild : Form
    {
        protected double[][] dataSet;

        public double[] DataAsRow
        {
            get
            {
                return dataSet[0].Clone() as double[];
            }
            set
            {
                if (dataSet == null)
                    dataSet = new double[1][];
                dataSet[0] = value.Clone() as double[];
                if (this.Visible)
                    UpdateGrid();
            }
        }
        public double[][] DataAsMatrix
        {
            get
            {
                return dataSet.Clone() as double[][];
            }
            set
            {
                dataSet = value.Clone() as double[][];
                if (this.Visible)
                    UpdateGrid();
            }
        }

        List<GridsRow> rows = null;
        int maxGridRowLen = 0;
        protected bool changed = false;

        public FormChild()
        {
            InitializeComponent();
        }
        public FormChild(double[] data)
        {
            InitializeComponent();
            DataAsRow = data;
        }
        public FormChild(double[][] data)
        {
            InitializeComponent();
            dataSet = data;
        }

        private void FormChld_Shown(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        public void AddRow(string Title, Array data)
        {
            if (rows == null)
                rows = new List<GridsRow>();

            GridsRow grRow;
            grRow.Title = Title == null ? "•" : Title;
            grRow.Content = data;

            rows.Add(grRow);
            UpdateGrid();
        }
        public void AddTable(string Header, string[] RowTitles, Array data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (!(data.GetValue(0) is Array))
            {
                AddRow(Header, data);
                return;
            }

            if (rows == null)
                rows = new List<GridsRow>();

            int _need_header = (Header == null ? 0 : 1);

            GridsRow[] grRows = new GridsRow[data.GetLength(0) + _need_header];
            if (_need_header == 1)
            {
                grRows[0].Title = "";
                grRows[0].Content = new string[] { Header };
                rows.Add(grRows[0]);
            }

            bool hasTitles = false;

            if (RowTitles != null)
                if (RowTitles.Length == data.GetLength(0))
                    hasTitles = true;

            for (int i = _need_header; i < data.GetLength(0) + _need_header; i++)
            {
                grRows[i].Title = hasTitles ? RowTitles[i] : "•";
                grRows[i].Content = (Array)data.GetValue(i - _need_header);
                rows.Add(grRows[i]);
            }

            UpdateGrid();
        }

        public void PrintLine(string str)
        {
            PrintLine(str, false);
        }
        public void PrintLine(string str, bool InsertDivAfter)
        {
            textBox1.Text += str + "\r\n";
            if (InsertDivAfter)
                textBox1.Text += "———\r\n";
        }

        public void ClearLines()
        {
            textBox1.Clear();
        }

        public void UpdateGrid()
        {
            uint digits = lab1.Properties.Settings.Default.ShownDigits;

            if (dataSet != null)
            {
                dataGridDataSet.SuspendLayout();
                dataGridDataSet.Rows.Clear();
                dataGridDataSet.Columns.Clear();

                DataGridViewRow[] dgvr = new DataGridViewRow[dataSet.GetLength(0)];
                maxGridRowLen = 0;
                for (int i = 0; i < dataSet.GetLength(0); i++)
                {
                    dgvr[i] = new DataGridViewRow();
                    dgvr[i].CreateCells(dataGridDataSet);
                    dgvr[i].SetValues(dataSet[i]);
                    if (dataSet[i].GetLength(0) > maxGridRowLen)
                        maxGridRowLen = dataSet[i].GetLength(0);
                }
                for (int i = 0; i < maxGridRowLen; i++)
                    dataGridDataSet.Columns.Add("column" + i.ToString(),
                        (i + 1).ToString());

                dataGridDataSet.Rows.AddRange(dgvr);

                dataGridDataSet.Rows[0].HeaderCell.Value = "Данные";

                for (int i = 0; i < dataSet.GetLength(0); i++)
                    for (int j = 0; j < dataSet[i].GetLength(0); j++)
                        dataGridDataSet[j, i].Value = Math.Round(dataSet[i][j], (int)digits);

                AddEmptyColumn();

                dataGridDataSet.AutoResizeColumns();
                dataGridDataSet.AutoResizeRows();
                dataGridDataSet.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);
                dataGridDataSet.ResumeLayout(false);
            }

            if ((rows == null)
                || (rows.Count == 0)
                || (dataGridAnalysis == null)
                )
                return;

            dataGridAnalysis.SuspendLayout();
            dataGridAnalysis.Rows.Clear();
            dataGridAnalysis.Columns.Clear();

            rows.ForEach(FindMax);

            for (int i = 0; i < maxGridRowLen; i++)
                dataGridAnalysis.Columns.Add("column" + i.ToString(),
                    (i + 1).ToString());

            dataGridAnalysis.Rows.Add(rows.Count);

            for (int j = 0; j < rows.Count; j++)
            {
                dataGridAnalysis.Rows[j].HeaderCell.Value =
                    rows[j].Title;

                Array tmp = rows[j].Content;

                for (int i = 0; i < tmp.Length; i++)
                {
                    if (tmp.GetValue(i) is double ||
                        tmp.GetValue(i) is float)
                        dataGridAnalysis[i, j].Value =
                            Math.Round((double)(tmp.GetValue(i)), (int)digits);
                    else
                        dataGridAnalysis[i, j].Value = tmp.GetValue(i);
                }
            }

            dataGridAnalysis.AutoResizeColumns();
            dataGridAnalysis.AutoResizeRows();
            dataGridAnalysis.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridAnalysis.ResumeLayout(false);
        }

        private void AddEmptyColumn()
        {
            dataGridDataSet.Columns.Add(new DataGridViewColumn(
                dataGridDataSet.Columns.GetLastColumn(
                DataGridViewElementStates.None,
                DataGridViewElementStates.None).CellTemplate));
        }

        private void FindMax(GridsRow gr)
        {
            if (gr.Content.Length > maxGridRowLen)
                maxGridRowLen = gr.Content.Length;
        }

        private void dataSetContextComboSizeChanged(object sender, EventArgs e)
        {
            dataSetSetSize.Text = string.Format("Новый размер: {0}x{1}", dataSetComboWidth.Text, dataSetComboHeigth.Text);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridDataSet_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridDataSet_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridDataSet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double value;
            DataGridViewCell ourCell = dataGridDataSet[e.ColumnIndex, e.RowIndex];
            try
            {
                value = double.Parse(ourCell.Value as String);
            }
            catch
            {
                ourCell.ErrorText = "Неправильный формат числа!";
                return;
            }
            
                int rowsCountOld = dataSet.GetLength(0);
                if (rowsCountOld < e.RowIndex + 1)
                {
                    Array.Resize<double[]>(ref dataSet, e.RowIndex + 1);

                    for (int i = rowsCountOld; i < dataSet.GetLength(0); dataSet[i++] = new double[1])
                        ;
                }

            if (dataSet[e.RowIndex].GetLength(0) < e.ColumnIndex+1)
                Array.Resize<double>(ref dataSet[e.RowIndex], e.ColumnIndex+1);
            
            dataSet[e.RowIndex][e.ColumnIndex] = value;

            dataGridDataSet.AutoResizeColumns();
        }
    }

    struct GridsRow
    {
        public string Title;
        public Array Content;

        public GridsRow(string Title, Array Content)
        {
            this.Content = Content;
            this.Title = Title;
        }
    }
}