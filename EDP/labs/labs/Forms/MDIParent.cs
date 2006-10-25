using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using lab1.Forms;

namespace lab1
{
    public partial class mdiParent : Form
    {
        private int childFormNumber = 1;
        protected int selectedA = -1, selectedB = -1, delSel = -1;

        public mdiParent()
        {
            InitializeComponent();
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
            Родила();
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
                Родила();
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
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
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
                activeChild.AddRow("Сортир.", sortedData);
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
                    asym.ToString() + ";");

                #endregion

            }
        }

        private void buttonCorelation_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count != 2)
            {
                MessageBox.Show("Необходимо указать две выборки.",
                    "Мало данных");
                return;
            }

            FormChild formChild0, formChild1;

            formChild0 = (FormChild)MdiChildren[listBox1.SelectedIndices[0]];
            formChild1 = (FormChild)MdiChildren[listBox1.SelectedIndices[1]];
            if ((formChild0 is FormChild) && (formChild1 is FormChild))
            {
                double[] data0 = formChild0.Data;
                double[] data1 = formChild1.Data;

                double correl =
                     StatisticsProcessor.Correlation(data0, data1);

                string reportik;

                if (double.IsNaN(correl))
                    reportik = "Выборки равны.";
                else
                    reportik = "Корреляция выборок: " + correl.ToString() + ";";

                formChild0.PrintLine(reportik);
                formChild1.PrintLine(reportik);
                MessageBox.Show(reportik, "Коэффициент корреляции");
            }
        }

        private void buttonDrawPoints_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is FormChild)
            {
                FormChild activeChild = ActiveMdiChild as FormChild;

                FormDiagram fDiag =
                    new FormDiagram(lab1.Classes.Diagram.KindOfDiagram.Polygon,
                    activeChild.Data);
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
                    new FormDiagram(lab1.Classes.Diagram.KindOfDiagram.LeftArrows,
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
                    new FormDiagram(lab1.Classes.Diagram.KindOfDiagram.Histogram,
                    activeChild.Data);
                fDiag.Size = new Size(400, 300);

                fDiag.Show();
            }
        }

        public void Родила()
        {
            listBox1.Items.Clear();

            for (int i = 0; i < MdiChildren.Length; i++)
                listBox1.Items.Add(MdiChildren[i].Text);

            listBox1.SelectedIndex = Array.IndexOf(MdiChildren, ActiveMdiChild);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndices.Count > 2)
            {
                //listBox1.SetSelected(delSel, false);
                listBox1.SelectedIndices.Clear();
            }
        }


    }
}
