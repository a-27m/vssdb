using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DekartGraphic;
using System.Collections.ObjectModel;

namespace mmio1
{
    public partial class DekartForm : Form
    {
        protected static int windowsCount = 0;

        public event PaintEventHandler CoodrinateSystemDrawn;

        protected List<MathGraphic> grs;

        public ReadOnlyCollection<MathGraphic> MathGraphicList
        {
            get
            {
                return grs.AsReadOnly();
            }
        }

        public int CountGraphics
        {
            get
            {
                if (grs != null)
                    return grs.Count;
                return 0;
            }
        }

        Bitmap bitmap;

        public Zoom zoom;

        protected float ox, oy;


        /// <summary>
        /// Constructs new Form for MathGraphics
        /// </summary>
        /// <param name="zoomX">Pixels per one unit on axis X</param>
        /// <param name="zoomY">Pixels per one unit on axis Y</param>
        /// <param name="Ox">X-coordinate of Oxy</param>
        /// <param name="Oy">Y-coordinate of Oxy</param>
        public DekartForm(float zoomX, float zoomY, int Ox, int Oy)
        {
            windowsCount++;
            zoom = new Zoom(zoomX, zoomY);
            ox = Ox;
            oy = Oy;

            //SetStyle(ControlStyles.AllPaintingInWmPaint
            //    | ControlStyles.UserPaint
            //    | ControlStyles.ResizeRedraw, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, false);

            InitializeComponent();

            //pictureBox1.Visible = false;
            //Paint += new PaintEventHandler(pictureBox1_Paint);
            //Resize += new EventHandler(DekartForm_Resize);

            InitGrafixBuffer();
        }

        ~DekartForm()
        {
            windowsCount--;
        }

        private void InitGrafixBuffer()
        {
        //    grBuf.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        //    grBuf.Graphics.Clear(BackColor);
            bitmap = new Bitmap(Size.Width + 1, Size.Height + 1);
        }

        private void DekartForm_Resize(object sender, EventArgs e)
        {
            Bitmap bmpOld = bitmap;

            InitGrafixBuffer();

            Graphics.FromImage(bitmap).DrawImage(bmpOld, 0, 0);

            if (bmpOld != null)
            {
                bmpOld.Dispose();
                bmpOld = null;
            }

            Update2();
            //Refresh();
        }

        /// <summary>
        /// Returns ID of added grapgic
        /// </summary>
        /// <param name="f">Real function of DoubleFunction</param>
        /// <param name="x1">Left tabulation bound</param>
        /// <param name="x2">Right tabulation bound</param>
        /// <param name="drawMode">Weather join nodes with lines</param>
        /// <returns>Zero-based index (ID) of newly added graphic</returns>
        public int AddGraphic(DoubleFunction f, float x1, float x2,
            DrawModes drawMode, Color penColor)
        {
            if (grs == null)
                grs = new List<MathGraphic>(100);
            MathGraphic newGraphic = new MathGraphic(penColor, drawMode,
                f, x1, x2, 0.01f);

            grs.Add(newGraphic);

            return grs.Count - 1;
        }

        /// <summary>
        /// adds graph of parametrically defined 2D function
        /// </summary>
        /// <param name="f">Real function of DoubleFunction</param>
        /// <param name="drawMode">Whether to join nodes with lines</param>
        /// <returns>Zero-based index (ID) of newly added graphic</returns>
        public int AddGraphic(DoubleFunction fx, DoubleFunction fy, float t1, float t2,
            DrawModes drawMode, Color penColor)
        {
            if (grs == null)
                grs = new List<MathGraphic>(100);
            MathGraphic newGraphic = new MathGraphic(penColor, drawMode,
                fx, fy, t1, t2, 0.01f);

            grs.Add(newGraphic);

            return grs.Count - 1;
        }

        /// <summary>
        /// </summary>
        /// <param name="penWidth">Is zooming with graphics of not zero :(</param>
        public int AddPolygon(Color penColor, float penWidth,
            DrawModes drawMode, params PointF[] pts)
        {
            if (grs == null)
                grs = new List<MathGraphic>(100);

            MathGraphic newGraphic = new MathGraphic(pts);
            newGraphic.DrawingMode = drawMode;
            newGraphic.PenColor = penColor;
            newGraphic.PenWidth = penWidth;

            grs.Add(newGraphic);

            return grs.Count - 1;
        }

        public int AddPolygon(Color penColor,
            DrawModes drawMode, params PointF[] pts)
        {
            return AddPolygon(penColor, 1f, drawMode, pts);
        }

        public void CenterView()
        {
            ox = Width / 2;
            oy = Height / 2;
            Update2();
        }

        private void DrawAllGraphics()
        {
            //grBuf.Graphics.Transform = new Matrix(zoom.X, 0f, 0f, -zoom.Y, ox, oy);

            GTranslator gt = new GTranslator();
            gt.g = Graphics.FromImage(bitmap);
            gt.zoom = zoom;
            gt.Ox = ox;
            gt.Oy = oy;
            
            if (grs != null)
            {
                grs[0].Draw(gt);

                OnCoordinateSystemDrawn(gt.g);

                foreach (MathGraphic gr in grs.GetRange(1, grs.Count - 1))
                {
                    gr.DrawGraphic(gt);
                }

                PrintCurrentZoom();
            }
        }

        protected virtual void OnCoordinateSystemDrawn(Graphics graphics)
        {
            Rectangle rect = new Rectangle();
            rect.Location = new Point((int)graphics.ClipBounds.X,
                (int)graphics.ClipBounds.Y);
            rect.Size = new Size((int)graphics.ClipBounds.Width,
                (int)graphics.ClipBounds.Height);


            if (this.CoodrinateSystemDrawn != null)
                CoodrinateSystemDrawn(this, new PaintEventArgs(graphics, rect));
        }

        private void PrintCurrentZoom()
        {
            //if (Visible)
            //    toolComboBoxZoom.Text = string.Format("{0:0.###}", zoom.X);
        }

        public void RemoveGraphic()
        {
            grs.RemoveAt(grs.Count);
        }

        public void RemoveAllGraphics()
        {
            if (grs != null)
                grs.RemoveAll(ReturnTrue);
        }

        private bool ReturnTrue(MathGraphic mg)
        { return true; }

        /// <summary>
        /// Removes graphic from drawing list
        /// </summary>
        /// <param name="ID">ID returned by AddGraphic method</param>
        public void RemoveGraphic(int ID)
        {
            grs.RemoveAt(ID);
        }

        public void Update2()
        {
            DrawAllGraphics();
            Render();
            //Refresh();
        }

        private void Render()
        {
            Graphics g = this.CreateGraphics();
            g.DrawImage(bitmap, 0, 0);
        }

        private void Render(Graphics g)
        {
            g.DrawImage(bitmap, 0, 0);
        }

        private void DekartForm_Paint(object sender, PaintEventArgs e)
        {
            Render(e.Graphics);
            this.Text += "|";
        }

        /*
        #region toolStrip Methods

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float px = ClientRectangle.Width / 2f;
            float py = ClientRectangle.Height / 2f;

            ox = (ox - px) / zoom.X;
            oy = (oy - py) / zoom.Y;

            zoom.ZoomIn();

            ox = ox * zoom.X + px;
            oy = oy * zoom.Y + py;

            Update2();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float px = ClientRectangle.Width / 2f;
            float py = ClientRectangle.Height / 2f;

            ox = (ox - px) / zoom.X;
            oy = (oy - py) / zoom.Y;

            zoom.ZoomOut();

            ox = ox * zoom.X + px;
            oy = oy * zoom.Y + py;

            Update2();
        }

        private void toolStripComboBoxLeave_Click(object sender, System.EventArgs e)
        {
            toolComboBoxZoom.Text = zoom.X.ToString();
            MessageBox.Show("OH! Yessss!!! Test completed!");
        }

        private void toolStripComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float new_zoom;
                if (float.TryParse(toolComboBoxZoom.Text, out new_zoom))
                {
                    float px = ClientRectangle.Width / 2f;
                    float py = ClientRectangle.Height / 2f;
                    ox = (ox - px) / zoom.X;
                    oy = (oy - py) / zoom.Y;

                    zoom.X = zoom.Y = new_zoom;

                    ox = ox * zoom.X + px;
                    oy = oy * zoom.Y + py;

                    Update2();
                }

                PrintCurrentZoom();

                toolComboBoxZoom.SelectionStart = 0;
                toolComboBoxZoom.SelectionLength =
                    toolComboBoxZoom.Text.Length;
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float new_zoom;
            if (float.TryParse(toolComboBoxZoom.Text, out new_zoom))
            {
                float px = ClientRectangle.Width / 2f;
                float py = ClientRectangle.Height / 2f;
                ox = (ox - px) / zoom.X;
                oy = (oy - py) / zoom.Y;

                zoom.X = zoom.Y = new_zoom;

                ox = ox * zoom.X + px;
                oy = oy * zoom.Y + py;

                Update2();
            }

            PrintCurrentZoom();

            toolComboBoxZoom.SelectionStart = 0;
            toolComboBoxZoom.SelectionLength =

                toolComboBoxZoom.Text.Length;
        }

        private void toolStripButtonCenter_Click(object sender, EventArgs e)
        {
            CenterView();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            ImageCodecInfo[] myCodecs;
            myCodecs = ImageCodecInfo.GetImageEncoders();

            StringBuilder myFilter = new StringBuilder("");
            foreach (ImageCodecInfo icf in myCodecs)
            {
                myFilter.Append("|" + icf.CodecName +
                    "|" + icf.FilenameExtension.Split(new char[] { ';' })[0]);
            }
            myFilter.Remove(0, 1);
            saveFileDialog1.Filter = myFilter.ToString();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(
                    this.toolStripContainer1.ContentPanel.Width,
                    this.toolStripContainer1.ContentPanel.Height,
                    grBuf.Graphics);
                Graphics tempGr = Graphics.FromImage(bmp);

                grBuf.Render(tempGr);

                bmp.Save(saveFileDialog1.FileName,
                    new ImageFormat(myCodecs[saveFileDialog1.FilterIndex - 1].FormatID));
            }
        }

        #endregion
        */
        /*
        #region mouseOverPictureEvents

        private int mouseX0 = 0, mouseY0 = 0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.Cross;
                mouseX0 = e.X;
                mouseY0 = e.Y;
            }
            if (e.Button == MouseButtons.Middle)
            {
                this.Cursor = Cursors.Hand;
                mouseX0 = e.X;
                mouseY0 = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                ox += (e.X - mouseX0);
                mouseX0 = e.X;
                oy += (e.Y - mouseY0);
                mouseY0 = e.Y;
                Update2();
            }

            if (e.Button == MouseButtons.Left)
            {
                Graphics g = toolStripContainer1.ContentPanel.CreateGraphics();
                Render(g);

                Pen temporaryPen = new Pen(Color.Black);
                temporaryPen.DashStyle = DashStyle.Dot;

                g.DrawLine(temporaryPen, mouseX0, mouseY0, e.X, mouseY0);
                g.DrawLine(temporaryPen, mouseX0, mouseY0, mouseX0, e.Y);
                g.DrawLine(temporaryPen, e.X, mouseY0, e.X, e.Y);
                g.DrawLine(temporaryPen, mouseX0, e.Y, e.X, e.Y);

                temporaryPen.Dispose();
                g.Dispose();
            }

            toolStripStatusLabel2.Text = string.Format(
                "({0:0.0000;-0.0000}; {1:0.0000;-0.0000})",
                (e.X - ox) / zoom.X,
                (e.Y - oy) / -zoom.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (e.Button == MouseButtons.Left)
            {
                float dx = mouseX0 - e.X;
                float dy = mouseY0 - e.Y;

                float px = (mouseX0 + e.X) / 2f;
                float py = (mouseY0 + e.Y) / 2f;

                ox = (ox - px) / zoom.X;
                oy = (oy - py) / zoom.Y;

                float factorX = (float)ClientRectangle.Width / Math.Abs(dx);
                float factorY = (float)ClientRectangle.Height / Math.Abs(dy);
                float factor = (factorX < factorY ? factorX : factorY);
                if (factor > float.Epsilon)
                {
                    zoom.X *= factor;
                    zoom.Y *= factor;
                }
                else
                    zoom.ZoomIn();

                ox = ox * zoom.X + ClientRectangle.Width / 2f;
                oy = oy * zoom.Y + ClientRectangle.Height / 2f;

                Update2();
            }
        }

        #endregion
        */
        private void DekartForm_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void DekartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                oy -= 10;
                Update2();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                oy += 10;
                Update2();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                ox -= 10;
                Update2();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                ox += 10;
                Update2();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }
    }
}