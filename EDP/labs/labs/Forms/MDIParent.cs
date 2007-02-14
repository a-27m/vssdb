using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using lab1.Forms;
using DataProc;

namespace lab1
{
    public partial class mdiParent : Form
    {
        private int childFormNumber = 1;

        public mdiParent()
        {
            InitializeComponent();
            toolStripMain.Location = lab1.Properties.Settings.Default.toolStripMainLoc;
            toolStripStandart.Location = lab1.Properties.Settings.Default.toolStripStandartLoc;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            FormChild childForm = new FormChild(new double[] { 0.0 });
            // Make it a child of this MDI form before showing it.
            childForm.Text = "Выборка " + childFormNumber++;
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                List<double> dataCollection = new List<double>();
                string FileName = openFileDialog.FileName;
                StreamReader f1 = new StreamReader(FileName);
                while (!f1.EndOfStream)
                {
                    string s1 = f1.ReadLine();
                    string[] strs = s1.Split(new char[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    try
                    {
                        foreach (string strVal in strs)
                        {
                            dataCollection.Add(double.Parse(strVal));
                        }
                    }
                    catch (FormatException exception)
                    {
                        MessageBox.Show("Wrong double number in file "
                            + FileName + ".");
                        f1.Close();
                        throw exception;
                    }
                }
                f1.Close();

                FormChild childForm = new FormChild(dataCollection.ToArray());
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                childForm.Text = FileName;
                childForm.Show();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //throw new Exception("Not implemented yet!");

            if (ActiveMdiChild is FormChild)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    FormChild activeChild = ActiveMdiChild as FormChild;
                    string result = ";";

                    double[] data = activeChild.Data;
                    foreach (double d in data)
                    {
                        result += d.ToString() + ';';
                    }

                    string FileName = saveFileDialog.FileName;
                    StreamWriter f = new StreamWriter(FileName, false);
                    f.WriteLine(result);
                    f.Close();
                }
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStandart.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;
                double[] sortedData = activeChild.Data;
                Array.Sort<double>(sortedData);
                activeChild.AddRow("Сортировка", sortedData);
                
                DialogResult dlgResult = MessageBox.Show("Отдельно?","Создать новую упорядоченную выборку?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dlgResult == DialogResult.Yes)
                {
                    FormChild formChild = new FormChild(sortedData);
                    formChild.MdiParent = this;
                    formChild.Text = string.Format("{0} ~ Упорядоченная", ActiveMdiChild.Text, childFormNumber++);
                    formChild.Show();
                }
            }
        }

        private void buttonGroup_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;
                int[] counts;
                double[] values;
                StatisticsProcessor.Groups(activeChild.Data,
                    out counts, out values);
                activeChild.AddRow(new char[] { '•' });
                activeChild.AddRow("Эл-тов в группе", counts);
                activeChild.AddRow("Значения", values);
            }
        }

        private void buttonRange_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;
                double[] ranges =
                    StatisticsProcessor.RangesOf(activeChild.Data);
                activeChild.AddRow(new char[] { '•' });
                activeChild.AddRow("Ранги", ranges);
            }
        }

        private void buttonIntervalRow_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;
                double[] lefts, rights;
                int[] counts;
                StatisticsProcessor.ToIntervals(activeChild.Data,
                    out lefts, out rights, out counts);

                activeChild.AddRow(new char[] { '•' });

                int len = counts.Length;
                string[] heads = new string[len];
                for (int i = 0; i < len - 1; i++)
                {
                    heads[i] = "[" + lefts[i].ToString()
                    + "; " + rights[i].ToString() + ")";
                }
                heads[len - 1] = "[" + lefts[len - 1].ToString()
                + "; " + rights[len - 1].ToString() + "]";

                activeChild.AddRow("Интервалы", heads);
                activeChild.AddRow("Кол-во эл-тов", counts);

            }

        }

        private void buttonNumCharacteristics_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;

                #region Среднее

                double srednee =
                    StatisticsProcessor.Srednee(activeChild.Data);
                activeChild.PrintLine("Выборочное среднее: " +
                    srednee.ToString() + ";");

                #endregion

                #region Дисперсия

                double sigma2 =
                    StatisticsProcessor.Dispersion(activeChild.Data);
                activeChild.PrintLine("Дисперсия: " +
                    sigma2.ToString() + " (с.к.о.: " +
                    Math.Sqrt(sigma2).ToString() + ");");

                #endregion

                #region Эксцесс

                double excess =
                    StatisticsProcessor.Excess(activeChild.Data);
                activeChild.PrintLine("Эксцесс: " +
                    excess.ToString() + ";");

                #endregion

                #region Асимметрия

                double asym =
                    StatisticsProcessor.Asymetry(activeChild.Data);
                activeChild.PrintLine("Асимметрия: " +
                    asym.ToString() + ";", true);

                #endregion

            }
        }

        private void buttonCorelation_Click(object sender, EventArgs e)
        {
            FormAskDocuments form = new FormAskDocuments(this);
            if (form.ShowDialog() != DialogResult.OK)
                return;
            if (form.forms.Length != 2)
            {
                MessageBox.Show("Необходимо указать две выборки.",
                    "Ошибка");
                return;
            }

            double correl;
            try
            {
                correl = StatisticsProcessor.Correlation(
                    form.forms[0].Data, form.forms[1].Data);
            }
            catch (ArithmeticException exc)
            {
                MessageBox.Show(exc.Message, "Ошибка вычисления корреляции!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string reportik;
            if (double.IsNaN(correl))
                reportik = "Выборки равны.";
            else
                reportik = string.Format("Корреляция выборок: {0};", correl);

            form.forms[0].PrintLine(reportik);
            form.forms[1].PrintLine(reportik);
            MessageBox.Show(reportik, "Коэффициент корреляции",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonDrawPoints_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;

                FormDiagram fDiag =
                    new FormDiagram(DataProc.Diagram.KindOfDiagram.Polygon,
                    activeChild.Data);
                fDiag.Size = new Size(400, 300);

                fDiag.Show();
            }
        }

        private void buttonDrawSorted_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;

                double[] sortedData = activeChild.Data;
                Array.Sort<double>(sortedData);

                FormDiagram fDiag =
                    new FormDiagram(DataProc.Diagram.KindOfDiagram.Polygon,
                    sortedData);
                fDiag.Size = new Size(400, 300);

                fDiag.Show();
            }
        }

        private void buttonDrawEmpFn_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;

                double[] means =
                    StatisticsProcessor.EmpVals(activeChild.Data);

                FormDiagram fDiag =
                    new FormDiagram(DataProc.Diagram.KindOfDiagram.LeftArrows,
                    means);
                fDiag.Size = new Size(400, 300);

                fDiag.Show();
            }
        }

        private void buttonDrawHistogram_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;

                FormDiagram fDiag =
                    new FormDiagram(DataProc.Diagram.KindOfDiagram.Histogram,
                    activeChild.Data);
                fDiag.Size = new Size(400, 300);

                fDiag.Show();
            }
        }

        private void toolRavnomZn_Click(object sender, EventArgs e)
        {
            FormAskZnSelection fAskParams = new FormAskZnSelection();
            if (fAskParams.ShowDialog() != DialogResult.OK)
                return;

            FormChild childForm = new FormChild(
                StatisticsProcessor.GenerateRavnom(
                fAskParams.a, fAskParams.b, fAskParams.n));

            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Text = "Равномерный " + childFormNumber.ToString();
            childFormNumber++;
            childForm.Show();
        }

        private void toolExpZn_Click(object sender, EventArgs e)
        {
            FormAskExpParams fAskParams = new FormAskExpParams();
            if (fAskParams.ShowDialog() != DialogResult.OK)
                return;

            FormChild childForm = new FormChild(
                StatisticsProcessor.GenerateExponential(
                fAskParams.λ, fAskParams.n));

            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Text = "Показательный " + childFormNumber.ToString();
            childFormNumber++;
            childForm.Show();
        }

        private void toolNormZn_Click(object sender, EventArgs e)
        {
            FormAskNormalParams fAskParams = new FormAskNormalParams();
            if (fAskParams.ShowDialog() != DialogResult.OK)
                return;

            FormChild childForm = new FormChild(
               StatisticsProcessor.GenerateNormal(
                    fAskParams.a, fAskParams.σ, fAskParams.n));

            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Text = "Нормальный " + childFormNumber.ToString();
            childFormNumber++;
            childForm.Show();
        }

        private void buttonCheckRndSeries_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeMdiChild = ActiveMdiChild as FormChild;

                char[] signs;
                double mediana;
                int v, t;

                bool res = StatisticsProcessor.CheckRndSeries(activeMdiChild.Data, out signs, out mediana, out v, out t);

                activeMdiChild.PrintLine("Выборка " + (res ? "" : "не") + "случайна, α=0,05. " + string.Format(
                    "Медиана: {0}, серий: {1}, длина длинной: {2}", mediana, v, t), true);

                activeMdiChild.AddRow("Знаки", signs);
            }
        }

        private void buttonCheckRndUpDownSeries_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeMdiChild = ActiveMdiChild as FormChild;

                char[] signs;
                int v, t;

                bool res = StatisticsProcessor.CheckRndUpDownSeries(activeMdiChild.Data, out signs, out v, out t);

                activeMdiChild.PrintLine("Выборка " + (res ? "" : "не") + "случайна, α=0,05. " + string.Format(
                    "Серий: {0}, длина длинной: {1}", v, t), true);

                activeMdiChild.AddRow("Знаки", signs);
            }
        }

        private void buttonCheckOutstanding(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeMdiChild = ActiveMdiChild as FormChild;
                double[] clearData;
                double[] worthless = StatisticsProcessor.CheckOutstanding(activeMdiChild.Data, out clearData, 0.05f);

                if (worthless != null)
                {
                    if (worthless.Length > 1)
                        activeMdiChild.PrintLine("Обнаружены резковыделяющиеся значения.", true);
                    else
                        activeMdiChild.PrintLine("Обнаружено резковыделяющееся значение: " + worthless[0].ToString(), true);

                    activeMdiChild.AddRow("Резковыделяющиеся значения:", worthless);

                    DialogResult dlgResult = MessageBox.Show("Отдельно?",
                        "Выделить значимые элементы в новую выборку?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dlgResult == DialogResult.Yes)
                    {
                        FormChild formChild = new FormChild(clearData);
                        formChild.MdiParent = this;
                        formChild.Text = string.Format("{0} ~ {1}", activeMdiChild.Text, childFormNumber++);
                        formChild.Show();
                    }
                }
                else
                {
                    activeMdiChild.PrintLine("Выборка не засорена резковыделяющимися значениями.", true);
                }
            }
        }

        private void buttonCheckZn_Click(object sender, EventArgs e)
        {
            FormAskLawSelection fAsk = new FormAskLawSelection();
            if (fAsk.ShowDialog() != DialogResult.OK)
                return;

            if (ActiveMdiChild is FormChild)
            {
                FormChild activeMdiChild = ActiveMdiChild as FormChild;

                try
                {
                    if (fAsk.Ravn)
                    {
                        fAsk.Ravn = StatisticsProcessor.CheckZn(activeMdiChild.Data, StatisticsProcessor.Zakon.Ravnom, 0.05);
                        activeMdiChild.PrintLine("Выборка " + (fAsk.Ravn ? "" : "не ") + "соответствует модели равномерного распределения (α=0,05).");
                    }
                }
                catch (ExceptionTableValuesGet exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    if (fAsk.Expon)
                    {
                        fAsk.Expon = StatisticsProcessor.CheckZn(activeMdiChild.Data, StatisticsProcessor.Zakon.Exponential, 0.05);
                        activeMdiChild.PrintLine("Выборка " + (fAsk.Expon ? "" : "не ") + "соответствует модели показательного распределения (α=0,05).");
                    }
                }
                catch (ExceptionTableValuesGet exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    if (fAsk.Norm)
                    {
                        fAsk.Norm = StatisticsProcessor.CheckZn(activeMdiChild.Data, StatisticsProcessor.Zakon.Normal, 0.05);
                        activeMdiChild.PrintLine("Выборка " + (fAsk.Norm ? "" : "не ") + "соответствует модели нормального распределения (α=0,05).");
                    }
                }
                catch (ExceptionTableValuesGet exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                activeMdiChild.PrintLine("Проверка выполнена с помощью критерия согласия Пирсона.", true);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOptions form = new FormOptions();
            form.ShowDialog();
        }

        private void mdiParent_FormClosed(object sender, FormClosedEventArgs e)
        {
            lab1.Properties.Settings.Default.toolStripMainLoc = toolStripMain.Location;
            lab1.Properties.Settings.Default.toolStripStandartLoc = toolStripStandart.Location;
            lab1.Properties.Settings.Default.Save();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            (ActiveMdiChild as FormChild).UpdateGrid();
        }
    }
}