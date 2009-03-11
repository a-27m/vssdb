using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using DekartGraphic;
using Fractions;
using SimplexMethod;
using System.Xml;
using System.Xml.Serialization;

namespace mmio1
{
    public partial class FormTaskOne : Form
    {
        protected bool IsNewDocument = true;
        Fraction[][] A;
        Fraction[] B, C;
        short[] S;

        private int n, m;
        FormSTables formTables;
        DekartForm df;

        public FormTaskOne()
        {
            InitializeComponent();

            if (this.IsNewDocument)
            {
                FormAskDim fad = new FormAskDim();

                if (fad.ShowDialog() != DialogResult.OK)
                    Close();

                n = fad.N;
                m = fad.M;
                GridMyResize(n, m);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (this.IsNewDocument)
            {
                FormAskDim fad = new FormAskDim();
                if (fad.ShowDialog() != DialogResult.OK)
                    Close();
                n = fad.N;
                m = fad.M;
                GridMyResize(n, m);
                //dataGridView1.Select();
            }
        }

        #region Load/Save
        [Serializable()]
        public struct TaskData
        {
            public Fraction[][] A;
            public Fraction[] B, C;
            public short[] S;
        };

        public void LoadData(string FileName)
        {
            XmlSerializer serial = new XmlSerializer(typeof(TaskData));

            Stream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            TaskData td = (TaskData)serial.Deserialize(stream);
            stream.Close(); 
            
            A = td.A;
            B = td.B;
            C = td.C;
            S = td.S;

            n = A[0].Length;
            m = B.GetLength(0);

            if (C.Length != n || S.Length != m || A.Length != m)
                throw new Exception("Bad file format");

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
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            XmlSerializer serial = new XmlSerializer(typeof(TaskData));

            Stream stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);

            TaskData td = new TaskData();
            td.A = A;
            td.B = B;
            td.C = C;
            td.S = S;

            serial.Serialize(stream, td);

            stream.Close();
        }
        #endregion

        string[] SignStrs = new string[3] { "<", "=", ">" };

        private void UpdateGrid()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    dataGridView1[j, i + 1] = A[i][j].ToString();

                dataGridView1[n + 1, i + 1] = B[i].ToString();

                dataGridView1[n, i + 1] = SignStrs[S[i] + 1];
            }

            for (int j = 0; j < n; j++)
                dataGridView1[j, 0] = C[j].ToString();

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
                        A[i][j] = Fraction.Parse(dataGridView1[j, i + 1].ToString());

                    B[i] = Fraction.Parse(dataGridView1[n + 1, i + 1].ToString());

                    S[i] = (short)(Array.IndexOf<string>(SignStrs, (string)dataGridView1[n, i + 1]) - 1);
                }

                for (int j = 0; j < n; j++)
                    C[j] = Fraction.Parse(dataGridView1[j, 0].ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка в данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                throw exc;
            }
        }

        private void GridMyResize(int vars, int conds)
        {
            dataGridView1.ClearColumns();
            dataGridView1.ClearRows();

            for (int i = 0; i < vars; i++)
            {
                dataGridView1.AddColumn("x" + (i + 1).ToString());
                //dataGridView1.SetColumnHeaderText(i, );                
            }

            dataGridView1.AddColumn("#");

            dataGridView1.AddColumn("b"); 

            dataGridView1.AddRow("");
            dataGridView1.SetRowHeaderText(0, "F = ");

            for (int i = 1; i <= conds; i++)
            {
                dataGridView1.AddRow("(" + i.ToString() + ")");
            }

            //dataGridView1.AutoResizeColumns();
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

            solver.DebugNewSimplexTable += new SimplexSolver.DebugSimplexTableHandler(solver_DebugNewSimplexTable);
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
                C[i] = -C[i];
            solver.SetTargetFunctionCoefficients(C);

            formTables.ResetIterationCounter();

            // снова решаем
            solution = solver.Solve();

            F = 0;
            for (int i = 0; i < C.Length; i++)
                F -= C[i] * solution[i];

            formTables.AddLine("Решение (min):", solution);
            formTables.AddLine("Значение Fmin:", new Fraction[] { F });

            formTables.UpdateGrid();
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
            //dataGridView1[2, 2] = new Fraction(21 / 24);
            //return;

            try
            {
                DowndateGrid();
            }
            catch
            {
                MessageBox.Show("Input error!");
                return;
            }

            if (df != null)
                df.RemoveAllGraphics();

            richTextBox1.Text = "";

            GraphicSolver solver = new GraphicSolver();
            solver.DebugPolygon += new GraphicSolver.DebugPolygonEventHandler(solver_DebugPolygonEvent);
            solver.DebugMaxMinPts += new GraphicSolver.DebugMaxMinEventHandler(solver_DebugMaxMin);
            solver.DebugMaxSolution += new GraphicSolver.DebugExtremumEventHandler(solver_DebugMaxSolution);
            solver.DebugMinSolution += new GraphicSolver.DebugExtremumEventHandler(solver_DebugMinSolution);
            solver.DebugGaussProcessMatrix += new GraphicSolver.DebugGaussProcessMatrixHandler(solver_DebugGaussProcessMatrix);

            for (int i = 0; i < A.Length; i++)
                solver.AddLimtation(A[i], S[i], B[i]);
            solver.SetTargetFunctionCoefficients(C);

            //solver_DebugGaussProcessMatrix((Fraction[,])A);
            formTables = new FormSTables();

            try
            {
                solver.Solve();
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            #region specialno dlya djema))) podrobnosti

            richTextBox1.Text += " ---===== Детали ====--- " + "\r\n";
            for (int i = 0; i < m; i++)
            {
                richTextBox1.Text += string.Format(
                       " x{0} = {1}·x1 {2} {3}·x2 {4} {5}", // x3 = 4/5·x1 + 1/2·x2 - 7/5
                       i + 1, // 0
                       -solver.A[i, 1], // 1
                       Math.Sign(-solver.A[i, 2]) < 0 ? "" : "+", // 2
                       -solver.A[i, 2], // 3
                       Math.Sign(solver.A[i, 0]) < 0 ? "" : "+", // 4
                       solver.A[i, 0] // 5
                       ) + "\r\n";
            }

            // F(x1,x2) = c1x1 + c2x2 + d
            richTextBox1.Text += string.Format(
                " F = {0}·x1 {1} {2}·x2 {3} {4}", // e.g.: F = 4/5·x1 + 1/2·x2 - 7/5
                       solver.C1, // 0
                       Math.Sign(solver.C2) < 0 ? "" : "+", // 1
                       solver.C2, // 2
                       Math.Sign(solver.D) < 0 ? "" : "+", // 3
                       solver.D // 4
                ) + "\r\n";

            #endregion

            formTables.UpdateGrid();
        }

        void solver_DebugNewSimplexTable(int[] basisJ, Fraction[] c, Fraction[,] table)
        {
            if (formTables == null)
                formTables = new FormSTables();
            formTables.AddTable(basisJ, c, table);
            formTables.Show();
        }

        void solver_DebugGaussProcessMatrix(Fraction[,] matrix)
        {
            if (formTables == null)
                formTables = new FormSTables();

            formTables.AddTable(matrix);
            formTables.Show();
        }

        void solver_DebugMinSolution(Fraction[] coordinates)
        {
            Fraction value = 0;
            for (int i = 0; i < coordinates.Length; i++)
                value += coordinates[i] * C[i];

            richTextBox1.Text += "Minimum: F= " + value.ToString() + " ≈ " + value.Value.ToString("f3");
            richTextBox1.Text += "\r\n";
            for (int i = 0; i < coordinates.Length - 1; i++)
                richTextBox1.Text += string.Format(" x{0} = {1},", i + 1, coordinates[i]);
            richTextBox1.Text += string.Format(" x{0} = {1}.", coordinates.Length, coordinates[coordinates.Length - 1]);
            richTextBox1.Text += "\r\n" + "\r\n";

            //splitContainer1.Panel2Collapsed = false;
        }

        void solver_DebugMaxSolution(Fraction[] coordinates)
        {
            Fraction value = 0;
            for (int i = 0; i < coordinates.Length; i++)
                value += coordinates[i] * C[i];

            richTextBox1.Text += "Maximum: F= " + value.ToString() + " ≈ " + value.Value.ToString("f3");
            richTextBox1.Text += "\r\n";
            for (int i = 0; i < coordinates.Length - 1; i++)
                richTextBox1.Text += string.Format(" x{0} = {1},", i + 1, coordinates[i]);
            richTextBox1.Text += string.Format(" x{0} = {1}.", coordinates.Length, coordinates[coordinates.Length - 1]);
            richTextBox1.Text += "\r\n" + "\r\n";

            //splitContainer1.Panel2Collapsed = false;
        }

        void solver_DebugMaxMin(FractionPoint max, FractionPoint min, Fraction f_tan)
        {
            if (df == null)
            {
                df = new DekartForm(100, 100, 100, 100);
                df.Text = "max & min";
            }

            // n
            df.AddPolygon(Color.Black, DrawModes.DrawLines,
                new PointF(1000, f_tan * 1000),
                new PointF(-1000, -f_tan * 1000));

            int id1 = df.AddPolygon(Color.Orange, DrawModes.DrawLines,
                   new PointF(1000 + max.X, -1 / f_tan * 1000 + max.Y),
                   new PointF(-1000 + max.X, 1 / f_tan * 1000 + max.Y));
            int id2 = df.AddPolygon(Color.CornflowerBlue, DrawModes.DrawLines,
                new PointF(1000 + min.X, -1 / f_tan * 1000 + min.Y),
                new PointF(-1000 + min.X, 1 / f_tan * 1000 + min.Y));

            df.Update2();

            df.AddPolygon(Color.Orange, 3f, DrawModes.DrawPoints, new PointF(max.X, max.Y));
            df.AddPolygon(Color.CornflowerBlue, 3f, DrawModes.DrawPoints, new PointF(min.X, min.Y));

            df.Show();
            df.Update2();
        }

        void solver_DebugPolygonEvent(FractionPoint[] polygon)
        {
            PointF[] pts = new PointF[polygon.Length];
            for (int i = 0; i < polygon.Length; i++)
                pts[i] = new PointF((float)polygon[i].X.Value, (float)polygon[i].Y.Value);

            if (df == null)
            {
                df = new DekartForm(75, 75, 50, 100);
                df.Text = this.Text + " - графическое решение";
                df.Closed += new EventHandler(delegate(object sender, EventArgs e)
                {
                    df = null;
                });
                //df.WindowState = FormWindowState.Maximized;
            }
            //df.RemoveAllGraphics();
            df.AddPolygon(Color.Black, DrawModes.DrawFilledPolygon, pts);
            df.Show();
            df.Update2();
        }

        private void menuItemBack_Click(object sender, EventArgs e)
        {
            //Close();
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            SaveData(saveFileDialog1.FileName);
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            LoadData(openFileDialog1.FileName);
        }
    }
}