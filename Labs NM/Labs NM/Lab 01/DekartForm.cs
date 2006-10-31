using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;

namespace DekartGraphic
{
    public partial class DekartForm : Form
    {
        List<MathGraphic> grs;

        BufferedGraphics grBuf;
        BufferedGraphicsContext grCntxt;

        protected float zoom_x, zoom_y, ox, oy;

        public void Zoom(float ZoomFactor)
        {
            if (ZoomFactor > float.Epsilon)
                zoom_x = zoom_y = ZoomFactor;
            Refresh();
        }

        public void Zoom(float ZoomFactorX, float ZoomFactorY)
        {
            if ((ZoomFactorX > float.Epsilon)
                && (ZoomFactorY > float.Epsilon))
            {
                zoom_x = ZoomFactorX;
                zoom_y = ZoomFactorY;
                Refresh();
            }
        }

        /// <summary>
        /// Returns ID of added grapgic
        /// </summary>
        /// <param name="f">Real function of DoubleFunction</param>
        /// <param name="x1">Left tabulation bound</param>
        /// <param name="x2">Right tabulation bound</param>
        /// <param name="drawMode">Weather to join nodes with lines</param>
        /// <returns></returns>
        public int AddGraphic(DoubleFunction f, float x1, float x2, DrawModes drawMode,
            Color penColor)
        {
            if (grs == null) grs = new List<MathGraphic>(100);
            MathGraphic newGraphic = new MathGraphic(f);
            newGraphic.LeftBound = x1;
            newGraphic.RightBound = x2;
            newGraphic.Step = 0.01f;
            newGraphic.DrawMode = drawMode;
            newGraphic.PenColor = penColor;

            newGraphic.Tabulate();

            grs.Add(newGraphic);

            return grs.IndexOf(newGraphic);
        }
        /// <summary>
        /// Removes graphic from drawing list
        /// </summary>
        /// <param name="ID">ID returned by AddGraphic method</param>
        public void RemoveGraphic(int ID)
        {
            grs.RemoveAt(ID);
            //throw new Exception("Method RemoveGraphic is not implemented yet.");
        }
        /// <summary>
        /// Constructs new Form for MathGraphics
        /// </summary>
        /// <param name="zoomX">Pixels per one unit on axis X</param>
        /// <param name="zoomY">Pixels per one unit on axis Y</param>
        /// <param name="Ox">X-coordinate of Oxy</param>
        /// <param name="Oy">Y-coordinate of Oxy</param>
        public DekartForm(float zoomX, float zoomY, int Ox, int Oy)
        {
            zoom_x = zoomX; zoom_y = zoomY;
            ox = Ox; oy = Oy;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, false);

            InitializeComponent();

            InitGrafixBuffer();

            //grs[i] = new MathGraphic(fs[i]);
            //grs[i].DrawMode = DrawModes.DrawLines;
            //grs[i].LeftBound = leftX;
            //grs[i].RightBound = rightX;
            //grs[i].Step = 0.01f;
            //grs[i].Tabulate();
        }

        private void InitGrafixBuffer()
        {
            grCntxt = BufferedGraphicsManager.Current;

            grCntxt.MaximumBuffer = new Size(pictureBox1.Width + 1,
                pictureBox1.Height + 1);

            grBuf = grCntxt.Allocate(pictureBox1.CreateGraphics(),
                pictureBox1.ClientRectangle);

            grBuf.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            grBuf.Graphics.Clear(BackColor);
        }

        private void DekartForm_Resize(object sender, EventArgs e)
        {
            BufferedGraphics grOld = grBuf;
            InitGrafixBuffer();

            if (grOld != null)
            {
                grOld.Render(grBuf.Graphics);
                grOld.Dispose();
                grOld = null;
            }

            Show2();
        }

        public void Show2()
        {
            grBuf.Graphics.Transform = new Matrix(zoom_x, 0f, 0f, -zoom_y, ox, oy);
            if (grs != null)
            {
                grs[0].DrawCoordinateSystem(grBuf.Graphics);

                foreach (MathGraphic gr in grs)
                {
                    gr.DrawGraphic(grBuf.Graphics);//, new Pen(Brushes.Red, 0f)
                }
                toolStripComboBox1.Text = string.Format("{0:0.###}", zoom_x);
            }
            Refresh();
            if (!Visible)
                Show(Parent);
        }

        private void DekartForm_Paint(object sender, PaintEventArgs e)
        {
            grBuf.Render(e.Graphics);
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoom_x *= 1.25f;
            zoom_y *= 1.25f;
            //zoom_x += 1f;
            //zoom_y += 1f;
            Show2();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoom_x /= 1.25f;
            zoom_y /= 1.25f;
            //zoom_x -= 1f;
            //zoom_y -= 1f;
            Show2();
        }

        private void toolStripComboBox1_Click(object sender, System.EventArgs e)
        {
            float new_zoom;
            if (float.TryParse(toolStripComboBox1.Text, out new_zoom))
            {
                if (new_zoom > float.Epsilon)
                {
                    zoom_x = zoom_y = new_zoom;
                    Show2();
                }
            }
        }

        private void shiftLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ox -= 10;
            grBuf.Graphics.Transform = new Matrix(zoom_x, 0, 0, -zoom_y, ox, oy);
            Show2();
        }

        private void shiftRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ox += 10;
            grBuf.Graphics.Transform = new Matrix(zoom_x, 0, 0, -zoom_y, ox, oy);
            Show2();
        }

        private void shiftUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oy -= 10;
            grBuf.Graphics.Transform = new Matrix(zoom_x, 0, 0, -zoom_y, ox, oy);
            Show2();
        }

        private void shiftDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oy += 10;
            grBuf.Graphics.Transform = new Matrix(zoom_x, 0, 0, -zoom_y, ox, oy);
            Show2();
        }

        private int mouseX0 = 0, mouseY0 = 0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseX0 = e.X;
                mouseY0 = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ox += (e.X - mouseX0);
                mouseX0 = e.X;
                oy += (e.Y - mouseY0);
                mouseY0 = e.Y;
                Show2();
            }

            toolStripStatusLabel2.Text = string.Format(
                "({0:0.00;-0.00}, {1:0.00;-0.00})",
                (e.X - ox) / zoom_x,
                (e.Y - oy) / -zoom_y);
        }

        private void toolStripButtonCenter_Click(object sender, EventArgs e)
        {
            ox = pictureBox1.Width / 2;
            oy = pictureBox1.Height / 2;
            Show2();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ImageCodecInfo[] myCodecs;
            myCodecs = ImageCodecInfo.GetImageEncoders();

            StringBuilder myFilter = new StringBuilder("");
            foreach(ImageCodecInfo icf in myCodecs)
            {
                myFilter.Append("|"+icf.CodecName +
                    "|" + icf.FilenameExtension.Split(new char[] { ';' })[0]);
            }
            myFilter.Remove(0, 1);
            saveFileDialog1.Filter = myFilter.ToString();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height,
                    grBuf.Graphics);
                Graphics tempGr = Graphics.FromImage(bmp);

                grBuf.Render(tempGr);
                
                bmp.Save(saveFileDialog1.FileName, 
                    new ImageFormat(myCodecs[saveFileDialog1.FilterIndex-1].FormatID));
            }
        }
    }

    public class FormReport : Form
    {
        public ListBox listBox1;
        private Timer timer1, timer2;
        int secsLeft;

        public FormReport()
        {
            timer1 = new Timer();
            timer2 = new Timer();

            this.SuspendLayout();
            this.Text = "Rendering report window, self closing in 5 sec.";
            this.Size = new Size(200, 300);
            listBox1 = new ListBox();
            listBox1.Sorted = false;
            this.Controls.Add(listBox1);
            listBox1.Dock = DockStyle.Fill;
            this.ResumeLayout(false);
            this.PerformLayout();

            Shown += new EventHandler(FormReport_Shown);
            KeyDown += new KeyEventHandler(FormReport_KeyDown);
            listBox1.GotFocus += new EventHandler(listBox1_GotFocus);
        }

        void listBox1_GotFocus(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;

            Text = "Rendering report window.";
        }

        void FormReport_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;

            Text = "Rendering report window.";
        }

        void FormReport_Shown(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            timer1.Enabled = true;

            timer2.Interval = 1000;
            timer2.Enabled = true;

            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Tick += new EventHandler(timer2_Tick);
            secsLeft = 5;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            this.Text = "Rendering report window, self closing in " +
                (--secsLeft).ToString() + " sec.";
        }


    }

}