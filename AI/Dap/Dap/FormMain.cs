using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dap
{
    public partial class FormMain : Form
    {
        [Serializable()]
        public class RawSample
        {
            public Int32 index;
            public Bitmap bitmapA;
            public Bitmap bitmapB;

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

                        if (bmp.GetPixel(ix, iy).GetBrightness() > 0)
                        {
                            pixs[shiftX + shiftY] = 2.0;
                            iy = (shiftY + 1) * dy - 1;
                            continue;
                        }
                    }
                }

                // than normalize brightnesses back
                for (int i = 0; i < nx * ny; )
                    pixs[i++]--;

                return pixs;
            }

            public double[] BitmapAToInputs(int nx, int ny)
            {
                return RawSample.BitmapToInputs(this.bitmapA, nx, ny);
            }
            public double[] BitmapBToInputs(int nx, int ny)
            {
                return RawSample.BitmapToInputs(this.bitmapB, nx, ny);
            }
        }
        
        double[,] w;
        double[] A, B;

        int sqareSideLengthA, sqareSideLengthB;

        List<RawSample> rawSamples;
        int rawSamplesIndex = 0;

        double[][] xCookedSamples;
        double[][] yCookedSamples; 
        
        Random rnd;
        double[] digitizedA;
        double[] digitizedB;

        Bitmap bmpA, bmpB;

        Color picBackColor;
        Pen penHand;

        bool showDigitized;

        public FormMain()
        {
            InitializeComponent();

            showDigitized = chkDigitizedView.Checked;

            sqareSideLengthA = 10;
            sqareSideLengthB = 10;

            bmpA = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format24bppRgb);
            bmpB = new Bitmap(pictureBox2.Width, pictureBox2.Height, PixelFormat.Format24bppRgb);
            penHand = new Pen(Color.White, 6f);
            penHand.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            penHand.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            picBackColor = Color.Black;

            rawSamples = new List<RawSample>();

            rnd = new Random();

            digitizedA = null;
            digitizedB = null;

            numGridNa.Value = sqareSideLengthA;
            numGridNb.Value = sqareSideLengthB;
        }

        /// <exception cref="System.OutOfMemory">System.OutOfMemory: weight matix too huge to fit in memory.</exception>
        public void AllocateNetwork(int nA, int nB)
        {
            w = new double[nA,nB];
            A = new double[nA];
            B = new double[nB];
        }

        private double[] FeedForward(double[] xA)
        {
            //Debug.Assert(w.GetLength(0) == sqareSideLengthA*sqareSideLengthA);
            //Debug.Assert(w.GetLength(1) == sqareSideLengthB*sqareSideLengthB);

            double[] yB = new double[w.GetLength(1)];

            for (int i = 0; i < xA.Length; i++)
            {
                for (int j = 0; j < w.GetLength(1); j++)
                {
                    yB[j] += xA[i] * w[i, j];
                }
            }

            return yB;            
        }

        private double[] FeedBackward(double[] xB)
        {
            //Debug.Assert(w.GetLength(0) == sqareSideLengthA);
            //Debug.Assert(w.GetLength(1) == sqareSideLengthB);

            double[] yA = new double[w.GetLength(0)];

            for (int i = 0; i < xB.Length; i++)
            {
                for (int j = 0; j < w.GetLength(0); j++)
                {
                    yA[j] += xB[i] * w[j, i];
                }
            }

            return yA;
        }

        private int CookSamples(out double[][] xCookedSamples, out double[][] yCookedSamples)
        {
            int P = rawSamples.Count;

            xCookedSamples = new double[P][];
            yCookedSamples = new double[P][];

            int i = 0;

            foreach (RawSample rs in rawSamples)
            {
                xCookedSamples[i] = rs.BitmapAToInputs(sqareSideLengthA, sqareSideLengthA);
                yCookedSamples[i] = rs.BitmapBToInputs(sqareSideLengthB, sqareSideLengthB);

                i++;
            }

            return P;
        }

        private void Train()
        {
            int P = rawSamples.Count;
            int nA = sqareSideLengthA*sqareSideLengthA;
            int nB = sqareSideLengthB*sqareSideLengthB;

            w.Initialize();

            for (int p = 0; p < P; p++)
            {
                for (int i = 0; i < nA; i++)
                    for (int j = 0; j < nB; j++)
                        w[i, j] += xCookedSamples[p][i] * yCookedSamples[p][j];

                if (backgroundWorkerTrain.CancellationPending)
                {
                    w.Initialize();
                    return;
                }
                backgroundWorkerTrain.ReportProgress((int)((float)p / (float)P * 100f));
            }
        }

        #region vv
        double[] vvAdd(double[] a, double[] b)
        {
            if (a == null || b == null) throw new ArgumentNullException();
            int n = a.Length;
            if (b.Length != n) throw new ArgumentException("Sizes do not match");
            double[] c = new double[n];
            for (int i = 0; i < n; i++) c[i] = a[i] + b[i];
            return c;
        }
        /// <summary>
        /// Calculates A - B
        /// </summary>
        double[] vvMinus(double[] a, double[] b)
        {
            if (a == null || b == null) throw new ArgumentNullException();
            int n = a.Length;
            if (b.Length != n) throw new ArgumentException("Sizes do not match");
            double[] c = new double[n];
            for (int i = 0; i < n; i++) c[i] = a[i] - b[i];
            return c;
        }
        double[] vvPairMult(double[] a, double[] b)
        {
            if (a == null || b == null) throw new ArgumentNullException();
            int n = a.Length;
            if (b.Length != n) throw new ArgumentException("Sizes do not match");
            double[] c = new double[n];
            for (int i = 0; i < n; i++) c[i] = a[i] * b[i];
            return c;
        }
        double vvSum(double[] a)
        {
            double s = 0;
            foreach (double z in a) s += z;
            return s;
        }
        
        #endregion

        #region UI
        #region pictureBox1 operation

        int mouseXPrev, mouseYPrev;
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseXPrev = e.X;
            mouseYPrev = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bmpA);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawLine(penHand, mouseXPrev, mouseYPrev, e.X, e.Y);
                g.Dispose();

                mouseXPrev = e.X;
                mouseYPrev = e.Y;
            }

            ((PictureBox)sender).Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bmpA);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawLine(penHand, mouseXPrev, mouseYPrev, e.X, e.Y);
                g.Dispose();

                mouseXPrev = e.X;
                mouseYPrev = e.Y;
            }

            digitizedA = null;
            pictureBox1.Refresh();
        }

        private void pbPaint(PictureBox sender, Bitmap bmp, int n, ref double[] digitized, Graphics g)
        {
            if (showDigitized)
            {
                SolidBrush br = (SolidBrush)Brushes.White;
                int dx = sender.Width / n;
                int dy = sender.Height / n;

                if (digitized == null) digitized = RawSample.BitmapToInputs(bmp, n, n);

                try
                {
                    g.DrawImageUnscaled(bmp, 0, 0);
                }
                catch { }

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        int brightness = (int)(digitized[i * n + j] * 125.0 + 125.0);
                        br.Color = Color.FromArgb(brightness, 255, 255, 255); // brightness, brightness, brightness
                        g.FillRectangle(br, i * dx, j * dy, dx, dy);
                    }
            }
            else
            {
                try
                {
                    g.DrawImageUnscaled(bmp, 0, 0);
                }
                catch { }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pbPaint(sender as PictureBox, bmpA, sqareSideLengthA, ref digitizedA, e.Graphics);                
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseXPrev = e.X;
            mouseYPrev = e.Y;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bmpB);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawLine(penHand, mouseXPrev, mouseYPrev, e.X, e.Y);
                g.Dispose();

                mouseXPrev = e.X;
                mouseYPrev = e.Y;
            }

            ((PictureBox)sender).Refresh();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bmpB);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawLine(penHand, mouseXPrev, mouseYPrev, e.X, e.Y);
                g.Dispose();

                mouseXPrev = e.X;
                mouseYPrev = e.Y;
            }

            digitizedB = null;
            ((PictureBox)sender).Refresh();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            pbPaint(sender as PictureBox, bmpB, sqareSideLengthB, ref digitizedB, e.Graphics);
        }
        #endregion

        private void ClearField(ref Bitmap bmp)
        {
            bmp = (Bitmap)bmp.Clone();
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(picBackColor);
            g.Dispose();
        }

        #region buttons
        private void bnAdd_Click(object sender, EventArgs e)
        {
            // TODO check if sample is valid

            // create new element of the samples list
            RawSample rs = new RawSample();
            rs.index = rawSamples.Count;
            rs.bitmapA = (Bitmap)bmpA.Clone();
            rs.bitmapB = (Bitmap)bmpB.Clone();
            rawSamples.Add(rs);
            rawSamplesIndex = rawSamples.Count - 1;

            //comboRefresh();
            labelCounter.Text = string.Format("{0} / {1}", rawSamplesIndex + 1, rawSamples.Count);

            ClearField(ref bmpA);
            ClearField(ref bmpB);
            digitizedA = null;
            digitizedB = null;

            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }

        private void tbnTrain_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerTrain.IsBusy)
            {
                tbnTrain.Text = "Cancelling...";
                backgroundWorkerTrain.CancelAsync();
                return;
            }

            try
            {
                AllocateNetwork(sqareSideLengthA * sqareSideLengthA, sqareSideLengthB * sqareSideLengthB);
            }
            catch (OutOfMemoryException oome)
            {
                MessageBox.Show(
                    oome.Message + Environment.NewLine + "while trying to allocate " +
                    (Math.Pow(sqareSideLengthA, 2) * Math.Pow(sqareSideLengthB, 2) * sizeof(double) / 1024.0 / 1024.0 / 1024.0).ToString("F1") + " GB",
                    "Network failed allocation",
                     MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            CookSamples(out xCookedSamples, out yCookedSamples);

            // Train();
            tbnTrain.Text = "Cancel";
            backgroundWorkerTrain.RunWorkerAsync();
        }

        private void bnRecognizeA_Click(object sender, EventArgs e)
        {
            double[] task = RawSample.BitmapToInputs(bmpA, sqareSideLengthA, sqareSideLengthA);            
            double[] result;
            result = RecognizeAtoB(task);

            ClearField(ref bmpB);
            digitizedB = result;

            labelRound.Text = string.Format("Stabilized in {0} rounds.", round);
            pictureBox2.Refresh();
        }
        private void bnRecognizeB_Click(object sender, EventArgs e)
        {
            double[] task = RawSample.BitmapToInputs(bmpB, sqareSideLengthB, sqareSideLengthB);
            double[] result;
            result = RecognizeBtoA(task);

            ClearField(ref bmpA);
            digitizedA = result;

            labelRound.Text = string.Format("Stabilized in {0} rounds.", round);
            pictureBox1.Refresh();
        }

        int round = 0;
        private double[] RecognizeAtoB(double[] task)
        {
            double[] result;

            double[] prevResult, prevTask;
            prevTask = new double[w.GetLength(0)];
            prevResult = new double[w.GetLength(1)];

            bool Resonance = false;

            round = 0;
            do
            {
                double[] delta;
                double error = 0;

                result = FeedForward(task);
                BinarizeToPlusMinus(ref result);

                delta = vvMinus(result, prevResult);
                error += vvSum(vvPairMult(delta, delta));

                task = FeedBackward(result);
                BinarizeToPlusMinus(ref task);

                delta = vvMinus(task, prevTask);
                error += vvSum(vvPairMult(delta, delta));

                Resonance = error < sqareSideLengthA * sqareSideLengthB / 25.0;

                Array.Copy(result, prevResult, sqareSideLengthB*sqareSideLengthB);
                Array.Copy(task, prevTask, sqareSideLengthA*sqareSideLengthA);

                round++;
                Debug.Print("Error: {0}", error);
            }
            while (!Resonance && round < 50);
            return result;
        }

        private double[] RecognizeBtoA(double[] task)
        {
            double[] result;

            double[] prevResult, prevTask;
            prevTask = new double[w.GetLength(1)];
            prevResult = new double[w.GetLength(0)];

            bool Resonance = false;

            round = 0;
            do
            {
                double[] delta;
                double error = 0;

                result = FeedBackward(task);
                BinarizeToPlusMinus(ref result);

                delta = vvMinus(result, prevResult);
                error += vvSum(vvPairMult(delta, delta));

                task = FeedForward(result);
                BinarizeToPlusMinus(ref task);

                delta = vvMinus(task, prevTask);
                error += vvSum(vvPairMult(delta, delta));

                Resonance = error < sqareSideLengthA * sqareSideLengthB / 25.0;

                Array.Copy(result, prevResult, sqareSideLengthA*sqareSideLengthA);
                Array.Copy(task, prevTask, sqareSideLengthB*sqareSideLengthB);

                round++;
                Debug.Print("Error: {0}", error);
            }
            while (!Resonance && round < 50);
            return result;
        }

        private void BinarizeToPlusMinus(ref double[] result)
        {
            for (int i = 0; i < result.Length; i++)
                result[i] = result[i] > 0 ? 1 : -1;
                //result[i] = result[i] > 0 ? 1 : (result[i] == 0 ? 0 : -1);
        }
        private void BinarizeToOneZero(ref double[] result)
        {
            for (int i = 0; i < result.Length; i++) result[i] = result[i] > 0 ? 1 : 0;
        }

        private void bnDigitizedView_Click(object sender, EventArgs e)
        {
            showDigitized = !showDigitized;
            chkDigitizedView.Checked = showDigitized;

            pictureBox1.Refresh();
        }

        private void buttonClearA_Click(object sender, EventArgs e)
        {
            ClearField(ref bmpA);
            digitizedA = null;
            pictureBox1.Refresh();
        } 

        private void bnClearB_Click(object sender, EventArgs e)
        {
            ClearField(ref bmpB);
            digitizedB = null;
            pictureBox2.Refresh();
        }

        private void tbtMode_Click(object sender, EventArgs e)
        {

        }

        private void bnPrev_Click(object sender, EventArgs e)
        {
            if (rawSamples.Count < 1) return;

            if (--rawSamplesIndex < 0) rawSamplesIndex = 0;

            bnPrevNextHelper();
        }

        private void bnNext_Click(object sender, EventArgs e)
        {
            if (rawSamples.Count < 1) return;

            if (++rawSamplesIndex >= rawSamples.Count) rawSamplesIndex = rawSamples.Count-1;

            bnPrevNextHelper();
        }

        private void bnPrevNextHelper()
        {
            try
            {
                bmpA = rawSamples[rawSamplesIndex].bitmapA;
                bmpB = rawSamples[rawSamplesIndex].bitmapB;
            }
            catch
            { }

            digitizedA = null;
            digitizedB = null;

            pictureBox1.Refresh();
            pictureBox2.Refresh();

            //comboBox1.Text = rawSamples[rawSamplesIndex].letter.ToString();

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

            labelCounter.Text = string.Format("{0} / {1}", rawSamplesIndex + 1, rawSamples.Count);
            pictureBox1.Refresh();
        }

        private void bnApplyEta_Click(object sender, EventArgs e)
        {
            //double.TryParse(txtEta.Text, out const_Eta);
            //txtEta.Text = const_Eta.ToString();
        }

        private void numGridNa_ValueChanged(object sender, EventArgs e)
        {
            sqareSideLengthA = (int)numGridNa.Value;
            digitizedA = null;
        }

        private void numGridNb_ValueChanged(object sender, EventArgs e)
        {
            sqareSideLengthB = (int)numGridNb.Value;
            digitizedB = null;
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

            try
            {
                bmpA = rawSamples[0].bitmapA;
                bmpB = rawSamples[0].bitmapB;
            }
            catch { }

            digitizedA = null;
            digitizedB = null;

            pictureBox1.Refresh();
            pictureBox2.Refresh(); 
            //comboRefresh();
            labelCounter.Text = string.Format("{0} / {1}", rawSamplesIndex + 1, rawSamples.Count);
        }
        #endregion

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.Train();
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //labelNetError.Text = "Net error: " + reportError.ToString("F10");
            //labelEpoch.Text = string.Format("Epoch: {0}", reportEpoc);
        }

        private void backgroundWorkerTrain_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            tbnTrain.Text = "Train";
            //labelNetError.Text = "Net error: " + reportError.ToString("F10");
            //labelEpoch.Text = string.Format("Epoch: {0} - done.", reportEpoc);
        }
    }
}
