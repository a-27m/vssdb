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
        private RawDataSet dataSet;

        public double[] Data
        {
            get
            {
                return dataSet.Data.Clone() as double[];
            }
            set
            {
                dataSet = new RawDataSet(value);
                if (Visible)
                    UpdateGrid();
            }
        }

        List<GridsRow> rows = null;
        int maxGridRowLen = 0;
        protected bool changed = false;

        public FormChild(double[] data)
        {
            InitializeComponent();
            Data = data;
        }
        public FormChild()
        {
            InitializeComponent();
        }

        private void FormChld_Shown(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        public void AddRow(Array data)
        {
            AddRow("•", data);
        }

        public void AddRow(string Title, Array data)
        {
            if (rows == null)
                rows = new List<GridsRow>();

            GridsRow grRow;
            grRow.Title = Title;
            grRow.Content = data;

            rows.Add(grRow);
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

            dataGridDataSet.SuspendLayout();
            if ((dataSet.Length > 0)
                && (dataGridDataSet != null))
            {
                dataGridDataSet.Rows.Clear();
                dataGridDataSet.Columns.Clear();

                for (int i = 0; i < dataSet.Length; i++)
                    dataGridDataSet.Columns.Add("column" + i.ToString(),
                        (i + 1).ToString());

                dataGridDataSet.Rows.Add(1);
                dataGridDataSet.Rows[0].HeaderCell.Value = "Âûáîðêà";

                for (int i = 0; i < dataSet.Length; i++)
                    dataGridDataSet[i, 0].Value = Math.Round(dataSet[i],(int)digits);

                dataGridDataSet.AutoResizeColumns();
                dataGridDataSet.AutoResizeRows();
            }
            dataGridDataSet.ResumeLayout(false);

            dataGridAnalysis.SuspendLayout();
            if ((rows == null)
                || (rows.Count == 0)
                || (dataGridAnalysis == null)
                )
                return;

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

            dataGridAnalysis.ResumeLayout(false);
        }

        void FindMax(GridsRow gr)
        {
            if (gr.Content.Length > maxGridRowLen)
                maxGridRowLen = gr.Content.Length;
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