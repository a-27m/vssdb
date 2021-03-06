using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using lab1.Forms;
using DataProc;
using DekartGraphic;

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
            childForm.Text = "Данные " + childFormNumber++;
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
                List<double[]> dataCollection = new List<double[]>();
                string FileName = openFileDialog.FileName;
                bool success = false;
                StreamReader f1 = null;
                while (!success)
                {
                    try
                    {
                        f1 = new StreamReader(FileName);
                        success = true;
                    }
                    catch (IOException/* exc*/)
                    {
                        if (MessageBox.Show("Произошла ошибка во время чтения файла " + FileName, "Ошибка чтения",
                                            MessageBoxButtons.RetryCancel,
                                            MessageBoxIcon.Error,
                                            MessageBoxDefaultButton.Button1) == DialogResult.Retry) continue;
                        else return;
                        //exc.Message
                    }
                }
                while (!f1.EndOfStream)
                {
                    string s1 = f1.ReadLine();
                    string[] strs = s1.Split(new char[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    List<double> dataLine = new List<double>();
                    try
                    {
                        foreach (string strVal in strs)
                        {
                            dataLine.Add(double.Parse(strVal));
                        }
                    }
                    catch (FormatException exception)
                    {
                        MessageBox.Show("Wrong double number in file "
                            + FileName + ".");
                        f1.Close();
                        throw exception;
                    }
                    dataCollection.Add(dataLine.ToArray());
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
            if (ActiveMdiChild is FormChild)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    FormChild activeChild = ActiveMdiChild as FormChild;
                    double[][] data = activeChild.DataAsMatrix;

                    string FileName = saveFileDialog.FileName;
                    StreamWriter f = new StreamWriter(FileName, false);

                    foreach (double[] row in data)
                    {
                        string result = ";";

                        foreach (double d in row)
                            result += d.ToString() + ';';

                        f.WriteLine(result);
                    }
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
                double[] sortedData = activeChild.DataAsRow;
                Array.Sort<double>(sortedData);
                activeChild.AddRow("Сортировка", sortedData);

                DialogResult dlgResult = MessageBox.Show("Отдельно?", "Создать новую упорядоченную выборку?",
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
                StatisticsProcessor.Groups(activeChild.DataAsRow,
                    out counts, out values);
                activeChild.AddRow("Эл-тов в группе", counts);
                activeChild.AddRow("Значения", values);
                activeChild.AddRow(null, new char[] { '•' });
            }
        }
        private void buttonRange_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;
                Array ranges =
                    StatisticsProcessor.RangesOf(activeChild.DataAsMatrix);
                activeChild.AddTable("Ранги", null, ranges);
            }
        }
        private void buttonIntervalRow_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;
                double[] lefts, rights;
                int[] counts;
                StatisticsProcessor.ToIntervals(activeChild.DataAsRow,
                    out lefts, out rights, out counts);


                int len = counts.Length;
                uint digits = lab1.Properties.Settings.Default.ShownDigits;

                string[] heads = new string[len];
                for (int i = 0; i < len - 1; i++)
                {
                    heads[i] = string.Format("[{0}; {1})",
                        Math.Round(lefts[i], (int)digits),
                        Math.Round(rights[i], (int)digits));
                }

                heads[len - 1] = string.Format("[{0}; {1}]",
                    Math.Round(lefts[len - 1], (int)digits),
                    Math.Round(rights[len - 1], (int)digits));

                activeChild.AddRow("Интервалы", heads);
                activeChild.AddRow("Кол-во эл-тов", counts);
                activeChild.AddRow(null, new char[] { '•' });
            }

        }
        private void buttonNumCharacteristics_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;

                #region Среднее

                double srednee =
                    StatisticsProcessor.Srednee(activeChild.DataAsRow);
                activeChild.PrintLine("Выборочное среднее: " +
                    srednee.ToString() + ";");

                #endregion

                #region Дисперсия

                double sigma2 =
                    StatisticsProcessor.Dispersion(activeChild.DataAsRow);
                activeChild.PrintLine("Дисперсия: " +
                    sigma2.ToString() + " (с.к.о.: " +
                    Math.Sqrt(sigma2).ToString() + ");");

                #endregion

                #region Эксцесс

                double excess =
                    StatisticsProcessor.Excess(activeChild.DataAsRow);
                activeChild.PrintLine("Эксцесс: " +
                    excess.ToString() + ";");

                #endregion

                #region Асимметрия

                double asym =
                    StatisticsProcessor.Asymetry(activeChild.DataAsRow);
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
                    form.forms[0].DataAsRow, form.forms[1].DataAsRow);
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
                    activeChild.DataAsRow);
                fDiag.Size = new Size(400, 300);

                fDiag.Show();
            }
        }
        private void buttonDrawSorted_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;

                double[] sortedData = activeChild.DataAsRow;
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
                    StatisticsProcessor.EmpVals(activeChild.DataAsRow);

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
                    activeChild.DataAsRow);
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

                bool res = StatisticsProcessor.CheckRndSeries(activeMdiChild.DataAsRow, out signs, out mediana, out v, out t);

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

                bool res = StatisticsProcessor.CheckRndUpDownSeries(activeMdiChild.DataAsRow, out signs, out v, out t);

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
                double[] worthless = StatisticsProcessor.CheckOutstanding(activeMdiChild.DataAsRow, out clearData, 0.05f);

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
                        fAsk.Ravn = StatisticsProcessor.CheckZn(activeMdiChild.DataAsRow, StatisticsProcessor.Zakon.Ravnom, 0.05f);
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
                        fAsk.Expon = StatisticsProcessor.CheckZn(activeMdiChild.DataAsRow, StatisticsProcessor.Zakon.Exponential, 0.05f);
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
                        fAsk.Norm = StatisticsProcessor.CheckZn(activeMdiChild.DataAsRow, StatisticsProcessor.Zakon.Normal, 0.05f);
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
            if (ActiveMdiChild is FormChild) (ActiveMdiChild as FormChild).UpdateGrid();
        }

        #region Factor analysis

        private void buttonFacAnal_R1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeMdiChild = ActiveMdiChild as FormChild;

                bool res = StatisticsProcessor.Analysis_Range_OneFactor_Modifed(activeMdiChild.DataAsMatrix, 0.05f);

                activeMdiChild.PrintLine("Фактор " + (!res ? "" : "не ") + "влияет на отклик, α=0,05. Использована уточненная статистика Краскала-Уолеса.");
            }
        }

        private void buttonFacAnal_R2_Click(object sender, EventArgs e)
        {

        }

        private void buttonFacAnal_D1_Click(object sender, EventArgs e)
        {

        }

        private void buttonFacAnal_D2_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void buttonSysFailConst_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeMdiChild = ActiveMdiChild as FormChild;

                PointF[] pts = new PointF[activeMdiChild.DataAsRow.Length];
                for (int i = 0; i < pts.Length; i++)
                {
                    pts[i].X = i;
                    pts[i].Y = (float)activeMdiChild.DataAsRow[i];
                }

                DekartForm df = new DekartForm(30, 30, 100, 300);
                df.AddPolygon(Color.Green, 2f, DrawModes.DrawLines, pts);
                df.MouseClick += new MouseEventHandler(dfSFConst_MouseClick);
                df.Use_IsVisible = false;
                df.Show();
                df.Update2();
            }
        }

        void dfSFConst_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ActiveMdiChild is FormChild)
                {
                    FormChild activeMdiChild = ActiveMdiChild as FormChild;

                    (sender as Form).Close();

                    int last_i1;
                    last_i1 = (int)(sender as DekartForm).MouseMathLocation.X;
                    //MessageBox.Show(last_i1.ToString());

                    double[] data = activeMdiChild.DataAsRow;
                    double[] data1 = new double[last_i1 + 1];
                    double[] data2 = new double[data.Length - data1.Length];

                    for (int i = 0; i <= last_i1; i++) data1[i] = data[i];
                    for (int i = last_i1+1; i < data.Length; i++) data2[i - (last_i1+1)] = data[i];

                    PointF[] pts = new PointF[data.Length];
                    PointF[] pts0 = new PointF[2];
                    PointF[] pts1 = new PointF[2];
                    PointF[] pts2 = new PointF[2];

                    for (int i = 0; i < pts.Length; i++)
                    {
                        pts[i].X = i;
                        pts[i].Y = (float)data[i];
                    }

                    float m0 = (float)StatisticsProcessor.Srednee(data);
                    float m1 = (float)StatisticsProcessor.Srednee(data1);
                    float m2 = (float)StatisticsProcessor.Srednee(data2);

                    float oneThird = 1f / 3f;
                    pts0[0].X = 0 - oneThird; pts0[0].Y = m0;
                    pts0[1].X = pts.Length - 1 + oneThird; pts0[1].Y = m0;

                    pts1[0].X = 0 - oneThird; pts1[0].Y = m1;
                    pts1[1].X = last_i1 + oneThird; pts1[1].Y = m1;

                    pts2[0].X = last_i1 + 1 - oneThird; pts2[0].Y = m2;
                    pts2[1].X = data.Length - 1 + oneThird; pts2[1].Y = m2;

                    DekartForm df = new DekartForm(30, 30, 100, 150);
                    df.AddPolygon(Color.Green, 3f, DrawModes.DrawPoints, pts);
                    df.AddPolygon(Color.Pink, 2f, DrawModes.DrawLines, pts0);
                    df.AddPolygon(Color.Red, 2f, DrawModes.DrawLines, pts1);
                    df.AddPolygon(Color.Red, 2f, DrawModes.DrawLines, pts2);
                    df.Use_IsVisible = false;
                    df.MouseClick += new MouseEventHandler(dfSFConst_MouseClick);
                    df.Show();
                    df.Update2();
                }
            }
        }


        private void buttonSysFailProgress_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeMdiChild = ActiveMdiChild as FormChild;

                PointF[] pts = new PointF[activeMdiChild.DataAsRow.Length];
                for (int i = 0; i < pts.Length; i++)
                {
                    pts[i].X = i;
                    pts[i].Y = (float)activeMdiChild.DataAsRow[i];
                }

                DekartForm df = new DekartForm(30, 30, 100, 300);
                df.AddPolygon(Color.Green, 2f, DrawModes.DrawLines, pts);
                df.MouseClick += new MouseEventHandler(dfSFProgress_MouseClick);
                df.Use_IsVisible = false;
                df.Show();
                df.Update2();
            }
        }

        void dfSFProgress_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ActiveMdiChild is FormChild)
                {
                    FormChild activeMdiChild = ActiveMdiChild as FormChild;

                    (sender as Form).Close();

                    double[] data = activeMdiChild.DataAsRow;

                    double sx, sy, sx2, sy2, sxy, n;
                    sx = sy = sx2 = sy2 = sxy = 0;
                    n = data.Length;

                    for (int i = 0; i < data.Length; i++)
                    {
                        sx += i;
                        sx2 += i * i;
                        sy += data[i];
                        sy2 += data[i] * data[i];
                        sxy += i * data[i];
                    }

                    double a, b; // y = ax +b

                    a = (n*sxy - sx * sy) / (n*sx2 - sx * sx);
                    b = (sy * sx2 - sx * sxy) / (n*sx2 - sx * sx);

                    PointF[] pts = new PointF[data.Length];
                    PointF[] pts0 = new PointF[data.Length];

                    for (int i = 0; i < pts.Length; i++)
                    {
                        // i => x
                        pts[i].X = pts0[i].X = i;

                        // ax*b => y0, data => y
                        pts[i].Y = (float)data[i];
                        pts0[i].Y = (float)(a*i+b);
                    }

//                    float oneThird = 1f / 3f;

                    DekartForm df = new DekartForm(30, 30, 100, 150);
                    df.AddPolygon(Color.Green, 3f, DrawModes.DrawPoints, pts);
                    df.AddPolygon(Color.Red, 2f, DrawModes.DrawLines, pts0);
                    df.Use_IsVisible = false;
                    df.MouseClick += new MouseEventHandler(dfSFProgress_MouseClick);
                    df.Show();
                    df.Update2();
                }
            }
        }

        DekartForm dform;
        private void buttonSysFailPeriodic_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeMdiChild = ActiveMdiChild as FormChild;

                PointF[] pts = new PointF[activeMdiChild.DataAsRow.Length];
                for (int i = 0; i < pts.Length; i++)
                {
                    pts[i].X = i;
                    pts[i].Y = (float)activeMdiChild.DataAsRow[i];
                }

                dform = new DekartForm(30, 30, 100, 300);
                ToolStripButton tsb = new ToolStripButton("Рассчет");
                tsb.Click +=new EventHandler(dfSFPriodic_dfClosed);
                dform.toolStrip1.Items.Add(tsb);
                dform.AddPolygon(Color.Blue, 2f, DrawModes.DrawPoints, pts);
                dform.MouseClick += new MouseEventHandler(dfSFPeriodic_MouseClick);
                //dform.FormClosed += new FormClosedEventHandler(dfSFPriodic_dfClosed);
                dform.Use_IsVisible = false;
                dform.Show();
                dform.Update2();
            }
        }

        List<int> clickSentinels = null;
        List<int> grIds = null;
        void dfSFPeriodic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ActiveMdiChild is FormChild)
                {
                    if (clickSentinels == null)
                        clickSentinels = new List<int>(100);

                    DekartForm df = (sender as DekartForm);
                    int pos = (int)(df.MouseMathLocation.X);

                    if (pos < 0) return;
                    if (pos > (ActiveMdiChild as FormChild).DataAsRow.Length - 2) return;
                    if (clickSentinels.Contains(pos)) return;

                    clickSentinels.Add(pos);


                    PointF[] pts = new PointF[2];
                    pts[0].X = pos + 0.5f;
                    pts[1].X = pos + 0.5f;
                    pts[0].Y = 0.5f;
                    pts[1].Y = -0.5f;

                    df.AddPolygon(Color.Red, DrawModes.DrawLines, pts);
                    df.Use_IsVisible = false;
                    df.Update2();
                }
            }
        }

        void dfSFPriodic_dfClosed(object sender, EventArgs e)
        {
            float oneThird = 1f/3f;

            if (ActiveMdiChild is FormChild)
            {
                FormChild activeMdiChild = ActiveMdiChild as FormChild;

                double[] data = activeMdiChild.DataAsRow;

                DekartForm df = dform;

                PointF[] pts;

                if (!clickSentinels.Contains(data.Length - 1)) clickSentinels.Add(data.Length - 1);
                double[] m = new double[clickSentinels.Count];
                clickSentinels.Sort();

                if (grIds == null)
                    grIds = new List<int>(100);
                else
                {
                    try
                    {
                        for(int i = 0; i < grIds.Count; i++)
                        {
                            df.RemoveGraphic(grIds[i]);

                            for (int l = 0; l < grIds.Count; l++)
                                if (grIds[l] > grIds[i]) grIds[l]--;                            
                        }
                    }
                    catch (ArgumentOutOfRangeException) { }

                    grIds.Clear(); 
                }

                int first = 0;
                for (int i = 0; i < clickSentinels.Count; i++)
                {
                    pts = new PointF[2];
                    for (int k = first; k <= clickSentinels[i]; k++)
                        m[i] += data[k];
                    m[i] /= clickSentinels[i] - first + 1;

                    pts[0].X = first - oneThird;
                    pts[1].X = clickSentinels[i] + oneThird;
                    pts[0].Y = pts[1].Y = (float)m[i];

                    grIds.Add(df.AddPolygon(Color.Red, 2f, DrawModes.DrawLines, pts));

                    first = clickSentinels[i] + 1;                    
                }

                //pts = new PointF[data.Length];
                //for (int i = 0; i < data.Length; i++)
                //{
                //    pts[i].X = i;
                //    pts[i].Y = (float)data[i];
                //}
                //df.AddPolygon(Color.Green, 3f, DrawModes.DrawPoints, pts);

                df.Use_IsVisible = false;
                df.Show();
                df.Update2();
            }
        }
    }
}