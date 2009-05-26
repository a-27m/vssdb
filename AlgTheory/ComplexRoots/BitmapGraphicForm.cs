using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fractal
{
    public partial class BitmapGraphicForm : Form
    {
        int dw, dh;

        public BitmapGraphicForm(PointF mathLeftBottomCorner, PointF mathRightTopCorner)
        {
            InitializeComponent();

            mathLeftBottom = mathLeftBottomCorner;
            mathRightTop = mathRightTopCorner;

            dw = this.Width - pictureBox1.Width;
            dh = this.Height - pictureBox1.Height;
        }

        public int PictureWidth
        {
            get
            {
                //return pictureBox1.Width; 
                return this.Width - dw;
            }
            set
            {
                this.Width = value + dw;
                this.tableLayoutPanel1.PerformLayout();
                this.PerformLayout();
            }
        }

        public int PictureHeight
        {
            get
            {
                //return pictureBox1.Height; 
                return this.Height - dh;
            }
            set
            {
                this.Height = value + dh;
                this.tableLayoutPanel1.PerformLayout();
                this.PerformLayout();
            }
        }

        float minX, maxX, minY, maxY;

        public PointF mathLeftBottom
        {
            get
            {
                return new PointF(minX, minY);
            }
            set
            {
                minX = value.X;
                minY = value.Y;
            }
        }
        public PointF mathRightTop
        {
            get
            {
                return new PointF(maxX, maxY);
            }
            set
            {
                maxX = value.X;
                maxY = value.Y;
            }
        }

        public event EventHandler ZoomEvent;
        public event EventHandler ResizeEvent;

        private Bitmap bitmap;

        public void SetBitmap(Bitmap bmp)
        {
            bitmap = bmp;

            pictureBox1.Image = bitmap;
            pictureBox1.Size = bitmap.Size;
            pictureBox1.Invalidate();
        }

        int gridN = 3;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //int w = pictureBox1.Width;
            //int h = pictureBox1.Height;
            int w = Width - dw;
            int h = Height - dh;

            for (int x = 0; x < w; x += w / gridN)
                g.DrawLine(Pens.Gray, x, 0, x, h);
            for (int y = 0; y < h; y += h / gridN)
                g.DrawLine(Pens.Gray, 0, y, w, y);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //int CellX = pictureBox1.Width / gridN;
            //int CellY = pictureBox1.Height / gridN;
            int CellX = (Width - dw) / gridN;
            int CellY = (Height - dh) / gridN;

            float mathLenX, mathLenY;
            mathLenX = (maxX - minX);
            mathLenY = (maxY - minY);


            if (e.Button == MouseButtons.Left)
            {
                // ... сколько целых кусочков по отношению к длине пикчербокса
                minX += (float)((int)(e.X / CellX)) / gridN * (maxX - minX);
                maxX = minX + mathLenX / gridN;

                minY += (gridN-1 - (float)((int)(e.Y / CellY))) / gridN * (maxY - minY);
                maxY = minY + mathLenY / gridN;
            }

            if (e.Button == MouseButtons.Right)
            {
                minX -= mathLenX / gridN;
                maxX += mathLenX / gridN;

                minY -= mathLenY / gridN;
                maxY += mathLenY / gridN;
            }

            if (ZoomEvent != null)
                ZoomEvent(this, e);
        }

        private void textBoxGridN_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                if (!int.TryParse(textBoxGridN.Text, out gridN))
                    textBoxGridN.Text = gridN.ToString();
        }

        private void textBoxGridN_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxGridN.Text, out gridN))
                textBoxGridN.Text = gridN.ToString();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel1.Text = string.Format("Координаты: ({0}, {1})",
                ((float)e.X / pictureBox1.Width * (maxX - minX) + minX).ToString("F4"),
                ((1 - (float)e.Y / pictureBox1.Height) * (maxY - minY) + minY).ToString("F4")
                );
        }

        private void BitmapGraphicForm_ResizeEnd(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (ResizeEvent != null)
                    ResizeEvent(this, e);
            }
        }
    }
}
