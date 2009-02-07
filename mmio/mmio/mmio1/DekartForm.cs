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

        //BufferedGraphics grBuf;
        //BufferedGraphicsContext grCntxt;

        public bool Use_IsVisible = true;

        public class Zoom
        {
            public const float zoomStepFactor = 1.25f;
            protected const float max_zoom_x = 40000f;
            protected const float max_zoom_y = 40000f;
            protected const float min_zoom_x = float.Epsilon;
            protected const float min_zoom_y = float.Epsilon;

            protected float zoom_x, zoom_y;

            public float X
            {
                get { return zoom_x; }
                set
                {
                    if ((value < max_zoom_x) &&
                        (value > min_zoom_x))
                        zoom_x = value;
                }
            }

            public float Y
            {
                get { return zoom_y; }
                set
                {
                    if ((value < max_zoom_y) &&
                        (value > min_zoom_y))
                        zoom_y = value;
                }
            }

            public float XY
            {
                set { X = Y = value; }
            }

            public Zoom()
            { zoom_x = 1f; zoom_y = 1f; }

            public Zoom(float X, float Y)
            { zoom_x = X; zoom_y = Y; }

            public void ZoomIn()
            {
                X *= zoomStepFactor;
                Y *= zoomStepFactor;
            }

            public void ZoomOut()
            {
                X /= zoomStepFactor;
                Y /= zoomStepFactor;
            }
        }
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

            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint
                | ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, false);

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
            grCntxt = BufferedGraphicsManager.Current;
            grCntxt.MaximumBuffer = this.toolStripContainer1.ContentPanel.Size + new Size(1, 1);

            grBuf = grCntxt.Allocate(this.toolStripContainer1.ContentPanel.CreateGraphics(),
                this.toolStripContainer1.ContentPanel.ClientRectangle);

            //grCntxt.MaximumBuffer = Size + new Size(1, 1);

            //grBuf = grCntxt.Allocate(CreateGraphics(),
            //	ClientRectangle);

            grBuf.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            grBuf.Graphics.Clear(BackColor);
        }

        private void DekartForm_Resize(object sender, EventArgs e)
        {
            BufferedGraphics grOld = grBuf;
            InitGrafixBuffer();

            if (grOld != null)
            {
                grOld.Dispose();
                grOld = null;
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

        private void DrawAllGraphicsToTheBuffer()
        {
            grBuf.Graphics.Transform = new Matrix(zoom.X, 0f, 0f, -zoom.Y, ox, oy);
            if (grs != null)
            {
                grs[0].Draw(grBuf.Graphics);

                OnCoordinateSystemDrawn(grBuf.Graphics);

                foreach (MathGraphic gr in grs.GetRange(1, grs.Count - 1))
                {
                    gr.Use_IsVisible = Use_IsVisible;
                    gr.DrawGraphic(grBuf.Graphics);
                }

                PrintCurrentZoom();
            }
        }

        protected virtual void OnCoordinateSystemDrawn(Graphics graphics)
        {
            Rectangle rect = new Rectangle();
            rect.Location = new Point((int)graphics.ClipBounds.Location.X,
                (int)graphics.ClipBounds.Location.Y);
            rect.Size = new Size((int)graphics.ClipBounds.Size.Width,
                (int)graphics.ClipBounds.Size.Height);


            if (this.CoodrinateSystemDrawn != null)
                CoodrinateSystemDrawn(this, new PaintEventArgs(graphics, rect));
        }

        private void PrintCurrentZoom()
        {
            if (Visible)
                toolComboBoxZoom.Text = string.Format("{0:0.###}", zoom.X);
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
            DrawAllGraphicsToTheBuffer();
            Render();
            //Refresh();
        }

        private void Render()
        {
            Graphics g = this.toolStripContainer1.ContentPanel.CreateGraphics();
            grBuf.Render(g);
        }

        private void Render(Graphics g)
        {
            grBuf.Render(g);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Render(e.Graphics);
        }


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

        private void shiftLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ox -= 10;
            grBuf.Graphics.Transform = new Matrix(zoom.X, 0, 0, -zoom.Y, ox, oy);
            Update2();
        }

        private void shiftRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ox += 10;
            grBuf.Graphics.Transform = new Matrix(zoom.X, 0, 0, -zoom.Y, ox, oy);
            Update2();
        }

        private void shiftUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oy -= 10;
            grBuf.Graphics.Transform = new Matrix(zoom.X, 0, 0, -zoom.Y, ox, oy);
            Update2();
        }

        private void shiftDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oy += 10;
            grBuf.Graphics.Transform = new Matrix(zoom.X, 0, 0, -zoom.Y, ox, oy);
            Update2();
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

        private void DekartForm_MouseClick(object sender, MouseEventArgs e)
        {
        }
    }
}