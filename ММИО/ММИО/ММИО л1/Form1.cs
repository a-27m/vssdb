﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DekartGraphic;
using SimplexMethod;
using Fractions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;

namespace ММИО_л1
{
    public partial class Form1 : Form
    {
        protected bool IsNewDocument = true;
        Fraction[][] A;
        Fraction[] B, C;
        short[] S;

        private int n, m;
        FormSTables formTables;

        public Form1()
        {
            InitializeComponent();
        }

        public void LoadData(string FileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress, false);
            A = (Fraction[][])formatter.Deserialize(zipStream);
            B = (Fraction[])formatter.Deserialize(zipStream);
            C = (Fraction[])formatter.Deserialize(zipStream);
            S = (short[])formatter.Deserialize(zipStream);

            zipStream.Close();

            n = A[0].Length;
            m = B.GetLength(0);

            if (C.Length != n || S.Length != m || A.Length != m)
                throw new SerializationException("Bad file format");

            GridMyResize(n, m);
            UpdateGrid();

            IsNewDocument = false;
        }

        public void SaveData(string FileName)
        {
            try
            {
                DowndateGrid();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка в данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                return;
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            GZipStream zipStream = new GZipStream(stream, CompressionMode.Compress, false);
            formatter.Serialize(zipStream, A);
            formatter.Serialize(zipStream, B);
            formatter.Serialize(zipStream, C);
            formatter.Serialize(zipStream, S);
            zipStream.Close();
        }

        private void UpdateGrid()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    dataGridView1[j, i + 1].Value = A[i][j].ToString();

                dataGridView1[n + 1, i + 1].Value = B[i].ToString();

                dataGridView1[n, i + 1].Value = SignCol.Items[S[i] + 1];
            }

            for (int j = 0; j < n; j++)
                dataGridView1[j, 0].Value = C[j].ToString();

            dataGridView1.AutoResizeColumns();
        }
        private void DowndateGrid()
        {
            A = new Fraction[m][];
            B = new Fraction[m];
            C = new Fraction[n];
            S = new short[m];

            try
            {
                for (int i = 0; i < m; i++)
                {
                    A[i] = new Fraction[n];
                    for (int j = 0; j < n; j++)
                        A[i][j] = Fraction.Parse(dataGridView1[j, i + 1].Value.ToString());

                    B[i] = Fraction.Parse(dataGridView1[n + 1, i + 1].Value.ToString());

                    S[i] = (short)(SignCol.Items.IndexOf(dataGridView1[n, i + 1].Value) - 1);
                }

                for (int j = 0; j < n; j++)
                    C[j] = Fraction.Parse(dataGridView1[j, 0].Value.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка в данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                throw exc;
            }
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

            for (int i = 0; i < vars; i++)
            {
                col = new DataGridViewColumn(CoefCol0.CellTemplate);
                col.HeaderText = "x" + (i + 1).ToString();
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
                n = fad.N;
                m = fad.M;
                GridMyResize(n, m);
                dataGridView1.Select();
            }
        }

        void solver_DebugNewSimplexTable(int[] basis, Fraction[] c, Fraction[,] table)
        {
            if (formTables == null)
                formTables = new FormSTables();
            formTables.AddTable(basis, c, table);
            formTables.Show();
        }

        private void оптимизироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DowndateGrid();
            }
            catch
            {
                return;
            }

            Fraction F;
            Fraction[] solution;
            SimplexSolver solver = new SimplexSolver();

            solver.DebugNewSimplexTable += new DebugSimplexTableHandler(solver_DebugNewSimplexTable);
            formTables = null;

            for (int i = 0; i < m; i++)
                solver.AddLimtation(A[i], S[i], B[i]);
            solver.SetTargetFunctionCoefficients(C);
            
            // решаем
            solution = solver.Solve();

            F = 0;
            for (int i = 0; i < C.Length; i++)
                F += C[i] * solution[i];

            formTables.AddLine("Решение (max):", solution);
            formTables.AddLine("Значение Fmax:", new Fraction[] { F });

            // переделываем под минимизацию
            for (int i = 0; i < C.Length; i++)
                C[i]=-C[i];
            solver.SetTargetFunctionCoefficients(C);

            formTables.ResetIterationCounter();

            // снова решаем
            solution = solver.Solve();

            F = 0;
            for (int i = 0; i < C.Length; i++)
                F -= C[i] * solution[i];

            formTables.AddLine("Решение (min):", solution);
            formTables.AddLine("Значение Fmin:", new Fraction[] { F });
        }

        private void выделитьБазисМатрицыAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DowndateGrid();
            }
            catch
            {
                return;
            }

            int maxJ = 0;
            for (int i = 0; i < A.Length; i++)
                if (A[i].Length > maxJ)
                    maxJ = A[i].Length;
            Fraction[,] a = new Fraction[A.Length, maxJ];
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A[i].Length; j++)
                    a[i, j] = A[i][j];


            if (formTables == null)
                formTables = new FormSTables();

            formTables.AddTable(a);
            for (uint i = 0; i < (a.GetLength(0) < a.GetLength(1) ? a.GetLength(0) : a.GetLength(1)); i++)
            {
                SimplexSolver.GGaussProcess(ref a, i, i);
                formTables.AddTable(a);
            }

            formTables.Show();

        }

        private void графическийМетодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DowndateGrid();
            }
            catch
            {
                return;
            }

            DekartForm df = new DekartForm(100,100, 100,100);
            df.AddPolygon(Color.Black, DrawModes.DrawLines, new PointF(0,0), new PointF(1,1));
            df.Text = this.Text + " - графическое решение";
            df.Show();
            df.Update2();
        }
    }
}