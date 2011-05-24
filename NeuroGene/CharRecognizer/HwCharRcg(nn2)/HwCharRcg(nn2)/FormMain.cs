using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NeuroGenes.Genetic;

namespace NeuroGenes
{
    public partial class FormMain : Form
    {
        [Serializable()]
        public class RawSample
        {
            public Int32 index;
            public Bitmap bitmap;
            public Char letter;

            public static double[] BitmapToInputs(Bitmap bmp, int nx, int ny)
            {
                // TODO check nx ny bounds

                double[] pixs = new double[nx * ny];

                // lets summarize brightnesses by squares
                int dx = bmp.Width / nx + 1;
                int dy = bmp.Height / ny + 1;
                for (int ix = 0; ix < bmp.Width; ix++)
                {
                    int shiftX = (ix / dx) * nx;
                    for (int iy = 0; iy < bmp.Height; iy++)
                    {
                        int shiftY = iy / dy;

                        pixs[shiftX + shiftY] += bmp.GetPixel(ix, iy).GetBrightness();
                        //if (bmp.GetPixel(ix, iy).GetBrightness() > 0)
                        //{
                        //    pixs[shiftX + shiftY] = 1.0;
                        //    iy = (shiftY + 1) * dy - 1;
                        //    continue;
                        //}
                    }
                }

                // than normalize brightnesses back
                double norm = dx * dy;
                //double norm = pixs.max;

                for (int i = 0; i < nx * ny; i++)
                    pixs[i] /= norm;

                return pixs;
            }

            public double[] BitmapToInputs(int nx, int ny)
            {
                return RawSample.BitmapToInputs(this.bitmap, nx, ny);
            }
        }

        int nx, ny;

        public string chars
        {
            get
            {
                string result = "";
                foreach (RawSample sam in rawSamples)
                {
                    if (result.IndexOf(sam.letter) < 0)
                        result += sam.letter;
                }

                return result;
            }
        }

        List<RawSample> rawSamples;
        int rawSamplesIndex = 0;

        CharRecognizerNetwork charNet;

        double[] digitized;

        Bitmap bmp;

        Color picBackColor;
        Pen penHand;

        bool showDigitized;
        
        Population<BaseDoubleSpecies<CharRecognSpecies>> population;

        public FormMain()
        {
            InitializeComponent();

            showDigitized = chkDigitizedView.Checked;

            nx = 10;
            ny = 10;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format24bppRgb);
            penHand = new Pen(Color.White, 6f);
            penHand.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            penHand.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            picBackColor = Color.Black;

            rawSamples = new List<RawSample>();

//            BindingSource bs = new BindingSource(rawSamples, "");
//            bindingNavigator1.BindingSource = bs;


            digitized = null;

            charNet = new CharRecognizerNetwork();

            txtA.Text = charNet.const_a.ToString();
            txtBias.Text = charNet.bias.ToString();
            txtEta.Text = charNet.const_Eta.ToString();
            numGridN.Value = nx;
        }


        // 'ch' should be contained in 'chars' 
        //public double[] CharToOutputs(char ch, int outsLen)
        //{
        //    int index = chars.IndexOf(ch);

        //    if (index < 0)
        //    {
        //        throw null;
        //        return null; 
        //    }

        //    string bits = Convert.ToString(index, 2);

        //    if (bits.Length > outsLen)
        //    {
        //        throw null;
        //        return null;
        //    }
                        
        //    double[] y = new double[outsLen];

        //    for (int i = 0; i < bits.Length; i++)
        //    {
        //        y[i] = bits[(bits.Length - 1) - i] == '1' ? 1f : 0f;
        //    }

        //    return y;
        //}

        //public char OutputsToChar(double[] y)//, int outsLen)
        //{
        //    int n = y.Length;

        //    int twoRaised = 1; // == 2^0
        //    int sum = 0;
        //    for (int i = 0; i < n; i++)
        //    {
        //        sum += y[i] < double.Epsilon ? twoRaised : 0;
        //        twoRaised <<= 1;
        //    }

        //    return chars[sum];
        //}


        private int CookSamples(out double[][] xCookedSamples, out double[][] yCookedSamples)
        {
            int P = rawSamples.Count;

            xCookedSamples = new double[P][];
            yCookedSamples = new double[P][];

            int i = 0;
            string lockChars = chars;

            foreach (RawSample rs in rawSamples)
            {
                xCookedSamples[i] = rs.BitmapToInputs(nx, ny);

                yCookedSamples[i] = new double[lockChars.Length];
                yCookedSamples[i].Initialize();
                yCookedSamples[i][lockChars.IndexOf(rs.letter)] = 1.0;

                i++;
            }

            return P;
        }

        #region pictureBox1 operation

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseXPrev = e.X;
            mouseYPrev = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawLine(penHand, mouseXPrev, mouseYPrev, e.X, e.Y);
                g.Dispose();

                mouseXPrev = e.X;
                mouseYPrev = e.Y;
            }

            pictureBox1.Refresh();
        }

        int mouseXPrev, mouseYPrev;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawLine(penHand, mouseXPrev, mouseYPrev, e.X, e.Y);
                g.Dispose();

                mouseXPrev = e.X;
                mouseYPrev = e.Y;
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (showDigitized)
            {
                SolidBrush br = (SolidBrush)Brushes.White;
                int dx = pictureBox1.Width / nx;
                int dy = pictureBox1.Height/ ny;

                if (digitized == null) digitized = RawSample.BitmapToInputs(bmp, nx, ny);

                try
                {
                    e.Graphics.DrawImageUnscaled(bmp, 0, 0);
                }
                catch { }

                for (int i = 0; i < nx; i++)
                    for (int j = 0; j < ny; j++)
                    {
                        int brightness = (int) (digitized[i * nx + j] * 254.0);
                        br.Color = Color.FromArgb(brightness, 255, 255, 255); // brightness, brightness, brightness
                        e.Graphics.FillRectangle(br, i * dx, j * dy, dx, dy);
                    }
            }
            else
            {
                try
                {
                    e.Graphics.DrawImageUnscaled(bmp, 0, 0);
                }
                catch { }
            }
        }
        #endregion

        private void ClearField()
        {
            bmp = (Bitmap)bmp.Clone();
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(picBackColor);
            g.Dispose();
            digitized = null;
            pictureBox1.Refresh();
        }

        #region buttons
        private void bnAdd_Click(object sender, EventArgs e)
        {
            // TODO check if sample is valid

            // create new element of the samples list
            RawSample rs = new RawSample();
            rs.bitmap = (Bitmap)bmp.Clone();
            rs.index = rawSamples.Count;
            rs.letter = comboBox1.Text[0];
            rawSamples.Add(rs);
            rawSamplesIndex = rawSamples.Count - 1;

            comboRefresh();
            labelCounter.Text = string.Format("{0} / {1}", rawSamplesIndex + 1, rawSamples.Count);

            ClearField();
        }

        private void comboRefresh()
        {
            comboBox1.Items.Clear();
            foreach (char c in chars.ToCharArray())
                comboBox1.Items.Add(c);
        }

        static double minChromosomeValue = 0;
        static double maxChromosomeValue = 1e5;

        Interval[] GetIntervals(int numberChromosomes)
        {
            Interval[] ints = new Interval[numberChromosomes];
            for(int i = 0; i < numberChromosomes; i++)
            {
                ints[i] = new Interval(minChromosomeValue, maxChromosomeValue);
            }

            return ints;
        }

        private void tbnTrainNeuroNetwork_Click(object sender, EventArgs e)
        {
            int numChrom = 1;/* TODO equals net weights count */
            population = new Population<BaseDoubleSpecies<CharRecognSpecies>>();
            CharRecognSpecies.Intervals = GetIntervals(numChrom);
            population.Add(
            //population.BestFunc
    /*Обучение
	1. Случайная популяция
	2. Для каждой особи вычисление ошибки (== fitness) на наборе примеров
	3. Отбор особей
	4. Скрещивание, мутации
	5. Если Поколение или Ошибка --> перейти на п. 7
	6. Перейти на п. 2
	7. Конец. Каждая особь-сеть обучена. Ответ - лучшая в популяции.
    */

        }

        private void tbnTrainBackProp_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerTrain.IsBusy)
            {
                tbnTrainBackProp.Text = "Cancelling...";
                backgroundWorkerTrain.CancelAsync();
                return;
            }

            double.TryParse(txtA.Text, out charNet.const_a);
            txtA.Text = charNet.const_a.ToString();

            double.TryParse(txtBias.Text, out charNet.bias);
            txtBias.Text = charNet.bias.ToString();

            double.TryParse(txtEta.Text, out charNet.const_Eta);
            txtEta.Text = charNet.const_Eta.ToString();

            progressBar1.Maximum = charNet.MaxEpoch;
            progressBar1.Value = 0;

            int inputs = nx * ny;
            int outputs = chars.Length;

            int[] NeuronCounts = { inputs, (inputs + outputs) / 2, outputs };


            charNet.AllocateNetwork(inputs, NeuronCounts); // inputs may not match the number of neurons in the 1st layer 

            charNet.FillSmallRandom(5e-2);

            CookSamples(out xCookedSamples, out yCookedSamples);

            // Train();
            tbnTrainBackProp.Text = "Cancel";
            backgroundWorkerTrain.RunWorkerAsync();
        }

        double reportError = 0.0;
        int reportEpoc = 0;
        
        double[][] xCookedSamples;
        double[][] yCookedSamples;

        private void bnRecognize_Click(object sender, EventArgs e)
        {
            double[] task = RawSample.BitmapToInputs(bmp, nx, ny);

            double[] result = charNet.FeedForward(task);

            char[] ans = chars.ToCharArray();
            Array.Sort(result, ans);

            txtAnswer.Text = ans[ans.Length - 1].ToString();
            labelSure.Text = (result[ans.Length - 1]*100).ToString("F5")+"%";
            //Debug.Print(result.ToString());
        }

        private void bnDigitizedView_Click(object sender, EventArgs e)
        {
            showDigitized = !showDigitized;
            chkDigitizedView.Checked = showDigitized;

            pictureBox1.Refresh();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearField();
        } 

        private void tbtMode_Click(object sender, EventArgs e)
        {

        }

        private void bnPrev_Click(object sender, EventArgs e)
        {
            if (rawSamples.Count < 1) return;

            if (--rawSamplesIndex < 0) rawSamplesIndex = 0;

            try
            {
                bmp = (rawSamples[rawSamplesIndex] as RawSample).bitmap;

            }
            catch
            {}

            digitized = null;
            pictureBox1.Refresh();

            comboBox1.Text = rawSamples[rawSamplesIndex].letter.ToString();           

            labelCounter.Text = string.Format("{0} / {1}", rawSamplesIndex+1, rawSamples.Count);
        }

        private void bnNext_Click(object sender, EventArgs e)
        {
            if (rawSamples.Count < 1) return;

            if (++rawSamplesIndex >= rawSamples.Count) rawSamplesIndex = rawSamples.Count-1;
        
            try
            {
                bmp = rawSamples[rawSamplesIndex].bitmap;
            }
            catch
            { }

            digitized = null;
            pictureBox1.Refresh();

            comboBox1.Text = rawSamples[rawSamplesIndex].letter.ToString();

            labelCounter.Text = string.Format("{0} / {1}", rawSamplesIndex + 1, rawSamples.Count);
        }

        private void bnRemove_Click(object sender, EventArgs e)
        {
            if (rawSamples.Count < 1) return;

            rawSamples.RemoveAt(rawSamplesIndex);

            int i = 0;
            foreach (RawSample rs in rawSamples)
                rs.index = i++;

            //rawSamplesIndex--;

            comboRefresh();
            labelCounter.Text = string.Format("{0} / {1}", rawSamplesIndex + 1, rawSamples.Count);
            pictureBox1.Refresh();
        }
        #endregion

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (Stream stream = File.Open(saveFileDialog1.FileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, rawSamples);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("The set was NOT saved.",
                    "I/O Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }            
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            
            try
            {
                using (Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    rawSamples = (List<RawSample>)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("The file could not be read.",
                    "I/O Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            rawSamplesIndex = 0;

            try { bmp = rawSamples[0].bitmap; }
            catch { }

            pictureBox1.Refresh(); 
            comboRefresh();
            labelCounter.Text = string.Format("{0} / {1}", rawSamplesIndex + 1, rawSamples.Count);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            charNet.Train(xCookedSamples, yCookedSamples);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            labelNetError.Text = "Net error: " + reportError.ToString("F10");
            labelEpoch.Text = string.Format("Epoch: {0}", reportEpoc);
        }

        private void backgroundWorkerTrain_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            tbnTrainBackProp.Text = "Train";
            labelNetError.Text = "Net error: " + reportError.ToString("F10");
            labelEpoch.Text = string.Format("Epoch: {0} - done.", reportEpoc);
        }

        private void numGridN_ValueChanged(object sender, EventArgs e)
        {
            nx = ny = (int)numGridN.Value;
            digitized = null;
        }

        private void bnApplyEta_Click(object sender, EventArgs e)
        {
            double.TryParse(txtEta.Text, out charNet.const_Eta);
            txtEta.Text = charNet.const_Eta.ToString();
        }

    }
}
