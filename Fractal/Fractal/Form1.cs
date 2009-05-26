using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBoxP.Text = 0.35.ToString();
            textBoxQ.Text = 0.42.ToString();
        }

        Color[] baseColors = new Color[] { 
                Color.FromArgb(0xFF4A26),
                Color.FromArgb(0xDAFF26),
                Color.FromArgb(0x26FF4A),
                Color.FromArgb(0x26DAFF),
                Color.FromArgb(0x4A26FF),
                Color.FromArgb(0xFF26DA)
            };

        int[,] stepTab;

        int Nx;
        int Ny;
        int maxN;

        float minX, maxX, minY, maxY;

        Color[] preColor;

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            Nx = pictureBox1.Width;
            Ny = pictureBox1.Height;

            minX = float.Parse(textBoxX1.Text);
            maxX = float.Parse(textBoxX2.Text);

            minY = float.Parse(textBoxY1.Text);
            maxY = float.Parse(textBoxY2.Text);

            float D = float.Parse(textBoxNorm.Text);
            D *= D;

            float p = float.Parse(textBoxP.Text);
            float q = float.Parse(textBoxQ.Text);

            maxN = int.Parse(textBoxMaxN.Text);
            gridN = int.Parse(textBoxGridN.Text);

            float h;
            if ((maxX - minX) / Nx > (maxY - minY) / Ny)
                h = (maxX - minX) / Nx;
            else
                h = (maxY - minY) / Ny;

            stepTab = new int[Nx, Ny];

            float x = minX;
            for (int i = 0; i < Nx; i++, x += h)
            {
                float y = minY;
                for (int j = 0; j < Ny; j++, y += h)
                {
                    float xi = x;
                    float yi = y;

                    int n = 0;
                    while (xi * xi + yi * yi < D)
                    {
                        float t = xi * xi - yi * yi + p;
                        yi = 2f * xi * yi + q;
                        xi = t;

                        if (++n >= maxN) break;
                    }

                    stepTab[i, j] = n;
                }
            }

            PrecacheColors();

            toolStripLabel1.Text = "Fractal is now calculated";
        }

        private void PrecacheColors()
        {
            preColor = new Color[maxN + 1];
            Random rnd = new Random(DateTime.Now.Millisecond);

            if (radioMono.Checked)
            {
                preColor[0] = GeoColor(rnd.NextDouble());
                for (int i = 1; i <= maxN; i++)
                    preColor[i] = preColor[0];
            }
            if (radioGeo.Checked)
            {
                for (int i = 0; i <= maxN; i++)
                    preColor[i] = GeoColor((float)i / maxN);
            }
            if (radioRnd.Checked)
            {
                for (int i = 0; i <= maxN; i++)
                    preColor[i] = GeoColor(rnd.NextDouble());
            }
            //int sat = (int)(i * 255f / maxN);
        }

        private Color GeoColor(double p)
        {
            int r, g, b;

            if (p < 1f / 4f)
            {
                r = 0;
                g = (int)(255f * 4f * p);
                b = 255;
                return Color.FromArgb(r, g, b);
            }
            if (p < 2f / 4f)
            {
                r = 0;
                g = 255;
                b = 255 - (int)(255f * 4f * (p - 1f / 4f));
                return Color.FromArgb(r, g, b);
            }
            if (p < 3f / 4f)
            {
                r = (int)(255f * 4f * (p - 2f / 4f));
                g = 255;
                b = 0;
                return Color.FromArgb(r, g, b);
            }
            r = 255;
            g = 255 - (int)(255f * 4f * (p - 3f / 4f));
            b = 0;
            return Color.FromArgb(r, g, b);
        }

        Bitmap bmp;
        private void buttonRender_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Nx, Ny,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            //Graphics.FromImage(bmp).Clear(Color.PaleGreen);
            Color color = Color.White;

            for (int i = 0; i < Nx; i++)
            {
                for (int j = 0; j < Ny; j++)
                {
                    //color = baseColors[stepTab[i, j] % baseColors.Length];                    
                    int sat = (maxN - stepTab[i, j]) * 255 / maxN;

                    color = Color.FromArgb(
                        (preColor[stepTab[i, j]].R + sat) / 2,
                        (preColor[stepTab[i, j]].G + sat) / 2,
                        (preColor[stepTab[i, j]].B + sat) / 2
                        );
                    bmp.SetPixel(i, j, color);
                }
            }
            toolStripLabel1.Text = "Fractal is pre-rendered";

            pictureBox1.Image = bmp;
            pictureBox1.Size = bmp.Size;
            pictureBox1.Invalidate();

        }

        int gridN = 3;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            for (int x = 0; x < w; x += w / gridN)
                g.DrawLine(Pens.Gray, x, 0, x, h);
            for (int y = 0; y < h; y += h / gridN)
                g.DrawLine(Pens.Gray, 0, y, w, y);            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            int CellX = pictureBox1.Width / gridN;
            int CellY = pictureBox1.Height / gridN;
            float mathLenX, mathLenY;
            mathLenX = (maxX - minX);
            mathLenY = (maxY - minY);
            

            if (e.Button == MouseButtons.Left) 
            {
                // ... сколько целых кусочков по отношению к длине пикчербокса
                minX += (float)((int)(e.X / CellX)) / gridN * (maxX - minX);
                maxX = minX + mathLenX / gridN;

                minY += (float)((int)(e.Y / CellY)) / gridN * (maxY - minY);
                maxY = minY + mathLenY / gridN;

                textBoxX1.Text = minX.ToString();
                textBoxX2.Text = maxX.ToString();

                textBoxY1.Text = minY.ToString();
                textBoxY2.Text = maxY.ToString();
            }
            if (e.Button == MouseButtons.Right) 
            {
                // ... сколько целых кусочков по отношению к длине пикчербокса
                minX -= mathLenX / gridN;
                maxX += mathLenX / gridN;

                minY -= mathLenY / gridN;
                maxY += mathLenY / gridN;

                textBoxX1.Text = minX.ToString();
                textBoxX2.Text = maxX.ToString();

                textBoxY1.Text = minY.ToString();
                textBoxY2.Text = maxY.ToString();
            }

            buttonClickClick_Click(sender, e);
        }

        private void buttonClickClick_Click(object sender, EventArgs e)
        {
            buttonCalculate_Click(sender, e);
            buttonRender_Click(sender, e);
        }

        private void radioGeo_CheckedChanged(object sender, EventArgs e)
        {
            PrecacheColors();
        }
    }
}
