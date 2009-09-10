using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace MetroLab3
{
    public partial class Form1 : Form
    {
        #region table
        readonly public static float[] Nju_a0_100 = {
            0f, 0f, 0f, 1.406f, 1.645f, 1.731f,
            1.894f, 1.972f, 2.041f, 2.097f, 2.146f,
            2.190f, 2.229f, 2.264f, 2.297f, 2.326f, 
            2.354f, 2.380f, 2.404f, 2.426f, 2.447f, 
            2.467f, 2.486f, 2.504f, 2.520f, 2.537f };
        readonly public static float[] Nju_a0_050 ={ 
            0f, 0f, 0f, 1.412f, 1.689f, 1.869f,
            1.996f, 2.093f, 2.172f, 2.237f, 2.294f,
            2.383f, 2.387f, 2.426f, 2.461f, 2.493f,
            2.523f, 2.551f, 2.557f, 2.600f, 2.623f, 
            2.644f, 2.664f, 2.683f, 2.701f, 2.717f };
        readonly public static float[] Nju_a0_025 =	{
            0f, 0f, 0f, 1.414f, 1.710f, 1.917f,
            2.067f, 2.182f, 2.273f, 2.349f, 2.414f,
            2.470f, 2.519f, 2.562f, 2.602f, 2.638f,
            2.670f, 2.701f, 2.728f, 2.754f, 2.778f,
            2.801f, 2.823f, 2.843f, 2.862f, 2.880f };
        readonly public static float[] Nju_a0_010 =	{ 
            0f, 0f, 0f, 1.414f, 1.723f, 1.955f,
            2.130f, 2.265f, 2.374f, 2.464f, 2.540f,
            2.606f, 2.663f, 2.714f, 2.759f, 2.808f,
            2.837f, 2.871f, 2.903f, 2.932f, 2.959f,
            2.984f, 3.008f, 3.030f, 3.051f, 3.071f };
        #endregion

        float a = 0.05f;

        List<float[]> dataList;
        List<int> markedList;

        public Form1()
        {
            InitializeComponent();

            markedList = new List<int>();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHowmuch fh = new FormHowmuch();

            if (fh.ShowDialog() == DialogResult.OK)
                ResetData(fh.N);
            else
            {
                dataList = null;
                return;
            }

            анализРезковыделяющихсяToolStripMenuItem.Enabled = true;
            среднееToolStripMenuItem.Enabled = true;
            UpdateGrid();
            Refresh();
        }

        private void ResetData(int N)
        {
            dataList = new List<float[]>();
            dataList.Add(new float[N]);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dataString = "";

                StreamReader fin = new StreamReader(openFileDialog1.FileName);
                if (!fin.EndOfStream)
                {
                    dataString = fin.ReadLine();
                }

                dataString = Replace(dataString, '.',
                    CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
                dataString = Replace(dataString, ',',
                    CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);

                string[] strs =
                    dataString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                float[] data = new float[strs.Length];

                int i;
                try
                {
                    for (i = 0; i < strs.Length; i++)
                        data[i] = float.Parse(strs[i]);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неправильный формат числа в файле:" + Environment.NewLine + openFileDialog1.FileName,
                        "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    dataList = null;
                    return;
                }

                dataList = new List<float[]>();
                dataList.Add(data);

            }
            else
                return;

            анализРезковыделяющихсяToolStripMenuItem.Enabled = true;
            среднееToolStripMenuItem.Enabled = true;
            UpdateGrid();
            Refresh();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataList != null)
                if (dataList[0] != null)
                    if (dataList[0].Length != 0)
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter f = new StreamWriter(saveFileDialog1.FileName);
                            foreach (float el in dataList[0])
                                f.Write(el.ToString() + ";");
                            f.Close();

                            return;
                        }
                        else
                            return;
                    }

            MessageBox.Show("Нечего сохранить: данные отсутствуют", "Отменено",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private string Replace(string dataString, char old, char brand_new)
        {
            StringBuilder result = new StringBuilder(dataString);

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == old)
                    result[i] = brand_new;
            }

            return result.ToString();
        }

        float ox, oy;
        float zx, zy;
        float max;
        float min;

        private void DrawCoords(Graphics g)
        {
            g.Clear(Color.FromArgb(247, 253, 253));
            g.SmoothingMode = SmoothingMode.HighQuality;

            float[] data = dataList[0];

            int n = data.Length;

            max = Max(data);
            min = Min(data);

            float dy = max - min;
            if (dy == 0)
                dy = 1f;

            ox = pictureBox1.Width / n;
            zx = (pictureBox1.Width - ox) / n;

            oy = pictureBox1.Height - 20; // отступ снизу
            zy = (oy - 40) / dy;// отступ сверху

            #region Axes
            Font fnt = new Font("Arial", 8f);
            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;

            for (float x = 0; x < n; x++)
            {
                g.DrawString(string.Format("{0:0}", x + 1), fnt, Brushes.Black,
                   zx * x + ox, oy + 2, strFormat);
                g.DrawLine(new Pen(Color.Gray, 0.0001f),
                    zx * x + ox, oy + 2f,
                    zx * x + ox, oy - 2f);
            }

            strFormat.Alignment = StringAlignment.Far;
            strFormat.LineAlignment = StringAlignment.Center;

            float step = dy / 10f;
            for (float y = min; y <= max + step; y += step)
            {
                float tmpY = -(y - min) * zy + oy;
                g.DrawString(string.Format("{0:0.00}", y), fnt, Brushes.Black,
                  ox - 2, tmpY, strFormat);
                g.DrawLine(new Pen(Color.Gray, 0.0001f), ox + 2f, tmpY, ox - 2f, tmpY);
            }

            g.DrawLine(new Pen(Brushes.Black, 1.5f), ox, oy, n * zx + ox, oy);
            g.DrawLine(new Pen(Brushes.Black, 1.5f), ox, 0, ox, oy);

            #endregion
        }
        private void DrawGraphic(Graphics g, float[] data)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;

            #region Graph
            Brush inner, outer;
            inner = Brushes.Green;
            outer = Brushes.DarkSeaGreen;

            float o1, o2;
            o2 = 6f;
            o1 = o2 / 2f;

            float i1, i2;
            i2 = 3f;
            i1 = i2 / 2f;

            int i;

            float[] values = (float[])data.Clone();

            for (int k = 0; k < values.Length; k++)
                values[k] = -zy * (values[k] - min) + oy;

            for (i = 1; i < data.Length; i++)
            {
                g.DrawLine(new Pen(Color.Black, 0f),
                    (i - 1) * zx + ox, values[i - 1], i * zx + ox, values[i]);
                g.FillEllipse(outer,
                    (i - 1) * zx + ox - o1, values[i - 1] - o1, o2, o2);
                g.FillEllipse(inner,
                    (i - 1) * zx + ox - i1, values[i - 1] - i1, i2, i2);
            }

            g.FillEllipse(outer,
                (i - 1) * zx + ox - o1, values[i - 1] - o1, o2, o2);
            g.FillEllipse(inner,
                (i - 1) * zx + ox - i1, values[i - 1] - i1, i2, i2);

            #endregion
        }
        private void DrawMarkPoint(Graphics g, float[] data, int i)
        {
            float r1, r2;
            r2 = 15f;
            r1 = r2 / 2f;

            Pen marker = Pens.Orange;
            g.DrawEllipse(marker, i * zx + ox - r1, -zy * (data[i] - min) + oy - r1, r2, r2);
        }

        private void UpdateGrid()
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            for (int i = 0; i < dataList[0].Length; i++)
                dgv.Columns.Add("dfsdf", (i + 1).ToString());

            dgv.Rows.Add();

            for (int i = 0; i < dataList[0].Length; i++)
            {
                dgv[i, 0].Value = dataList[0][i];
                if (markedList.Contains(i))
                {
                    dgv[i, 0].Style.BackColor = Color.Orange;//Color.FromArgb(255, 235, 245);
                }
            }

            dgv.AutoResizeColumns();
        }

        private float Min(float[] data)
        {
            int tmp;
            return Min(data, out tmp);
        }
        private float Min(float[] data, out int index)
        {
            float min = data[0];
            index = 0;
            for (int i = 0; i < data.Length; i++)
                if (data[i] < min)
                {
                    min = data[i];
                    index = i;
                }
            return min;
        }
        private float Max(float[] data)
        {
            int tmp;
            return Max(data, out tmp);
        }
        private float Max(float[] data, out int index)
        {
            float max = data[0];
            index = 0;
            for (int i = 0; i < data.Length; i++)
                if (data[i] > max)
                {
                    max = data[i];
                    index = i;
                }
            return max;
        }
        private float Middle(float[] data)
        {
            float middle = 0;

            for (int i = 0; i < data.Length; i++)
                middle += data[i];

            middle /= data.Length;

            return middle;
        }
        private float SredneKvadrOtkl(float[] data)
        {
            float x0 = Middle(dataList[0]);
            float sko = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sko += (data[i] - x0) * (data[i] - x0);
            }
            return (float)Math.Sqrt(sko / (data.Length - 1));
        }
        public static float TableNju(float α, int n)
        {
            if (n >= 3 && n <= 25)
            {
                if (α == 0.01f)
                    return Nju_a0_010[n];
                if (α == 0.025f)
                    return Nju_a0_025[n];
                if (α == 0.05f)
                    return Nju_a0_050[n];
                if (α == 0.1f)
                    return Nju_a0_100[n];
            }

            string prompt = string.Format("Введите значение точки распределения ню для α={0}, n={1}.", α, n);
            FormAskTableValue form = new FormAskTableValue(prompt);
            if (form.ShowDialog() != DialogResult.OK)
            {
                throw new Exception("Ошибка ввода табличного значения.");
            }
            return form.Value;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (dataList != null)
            {
                DrawCoords(e.Graphics);
                foreach (float[] data in dataList)
                    DrawGraphic(e.Graphics, data);
                foreach (int i in markedList)
                    DrawMarkPoint(e.Graphics, dataList[0], i);
            }
        }
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        string oldTextOfCell = "0";
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataList[0][e.ColumnIndex] = float.Parse(dgv[e.ColumnIndex, 0].Value.ToString());

                if (dataList.Count > 1)
                    dataList.RemoveRange(1, dataList.Count - 1);
                AnalReset();
                textBox1.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный формат числа в ячейке #" + (e.ColumnIndex + 1).ToString(), "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv[e.ColumnIndex, e.RowIndex].Value = oldTextOfCell;
                return;
            }

            Refresh();
        }

        private void AnalReset()
        {
            if (markedList.Count > 0)
            {
                markedList.RemoveRange(0, markedList.Count);
                for (int i = 0; i < dgv.Rows[0].Cells.Count; i++)
                    dgv[i, 0].Style = dgv.DefaultCellStyle;
            }
        }
        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldTextOfCell = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void middleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float middle;
            middle = Middle(dataList[0]);

            float[] line = new float[dataList[0].Length];
            for (int i = 0; i < dataList[0].Length; i++)
                line[i] = middle;

            textBox1.Text += "Среднее значение: " + middle.ToString("F3") + Environment.NewLine;
            dataList.Add(line);
            Refresh();
        }
        private void анализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float[] data = (float[])dataList[0].Clone();

            int maxIndex, minIndex;
            bool pollutions;
            int pollCount = 0;

            do
            {
                pollutions = false;
                int n = data.Length;
                float S = SredneKvadrOtkl(data);
                float middle = Middle(data);
                float njuMax = (Max(data, out maxIndex) - middle) / S;
                float njuMin = (middle - Min(data, out minIndex)) / S;

                if (njuMax > TableNju(a, n))
                {
                    pollutions = true;
                    data[maxIndex] = middle;
                    PollutionFound(maxIndex);
                    pollCount++;
                }
                if (njuMin > TableNju(a, n))
                {
                    pollutions = true;
                    data[minIndex] = middle;
                    PollutionFound(minIndex);
                    pollCount++;
                }
            } while (pollutions);

            if (pollCount < 1)
            {
                textBox1.Text += "Грубых погрешностей нет на уровне значимости α=" + a.ToString() + Environment.NewLine;
            }
            else
            {
                UpdateGrid();
                Refresh();
            }
        }

        private void PollutionFound(int index)
        {
            markedList.Add(index);
            textBox1.Text += string.Format("Грубая погрешность: значение {0} в позиции {1}, α={2}",
                dataList[0][index].ToString("F3"), index + 1, a) + Environment.NewLine;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            float[] items = new float[] { 0.1f, 0.05f, 0.025f, 0.01f };
            comboBoxAlpha.Items.AddRange(Array.ConvertAll<float, object>(items, delegate(float x)
            {
                return (object)x;
            }));
            comboBoxAlpha.SelectedIndex = 1;
        }

        private void comboBoxAlpha_TextChanged(object sender, EventArgs e)
        {
            if (!float.TryParse(comboBoxAlpha.Text, out a))
            {
                comboBoxAlpha.Text = a.ToString();
                MessageBox.Show("Неправильный формат числа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                AnalReset();
        }
        private void comboBoxAlpha_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = (float)(comboBoxAlpha.SelectedItem);
            AnalReset();
        }
    }
}