using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DekartGraphic;
using System.Drawing.Drawing2D;

namespace lab7__Catastrophe_
{
    public partial class Form1 : Form
    {
        MathGraphic mgP;
        MathGraphic mgQDotPlus, mgQDotMinus;
        DekartForm.Zoom zoom;
        float ox, oy1, oy2;
        float x1, x2;
        float h;

        public Form1()
        {
            InitializeComponent();
            zoom = new DekartForm.Zoom(30, 30);
            ox = 50;
            oy1 = oy2 = 50;
            x1 = 0f;
            x2 = 20f;
            h = 2e-2f;

            penE = new Pen(Color.Red, 0);
            toolStripButton2.Text = "E mode";
        }

        double E = 0;

        private double P(double q)
        {
            return 0.5 * Math.Cos(q - x2 / 2) * (q - x2 / 2) + q / 2 + 5;
        }

        private double QDotPlus(double q)
        {
            double v = E - P(q);
            return (v >= 0) ? Math.Sqrt(v) : 0;
        }
        //private double QDotMinus(double q)
        //{
        //    return -QDotPlus(q);
        //}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            mgP = new MathGraphic(
                Color.SlateBlue,
                 DrawModes.DrawLines,
                 P, x1, x2, h);
            mgP.CurrentColorSchema = MathGraphic.ColorSchema.BlackAndWhite;

            mgQDotPlus = new MathGraphic(
                Color.SlateGray,
                 DrawModes.DrawLines,
                 QDotPlus, x1, x2, h);
            mgQDotPlus.CurrentColorSchema = MathGraphic.ColorSchema.BlackAndWhite;

            //mgQDotMinus = new MathGraphic(
            //    Color.SlateGray,
            //     DrawModes.DrawLines,
            //     QDotMinus, x1, x2, h);
            //mgQDotMinus.CurrentColorSchema = MathGraphic.ColorSchema.BlackAndWhite;

            Refresh();
        }

        Pen penE;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mgP != null)
            {
                e.Graphics.Transform = new Matrix(zoom.X, 0f, 0f, -zoom.Y, ox, oy1);
                mgP.Draw(e.Graphics, true);
                e.Graphics.DrawLine(penE, x1, (float)E, x2, (float)E);
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (mgQDotPlus != null)
            {
                e.Graphics.Transform = new Matrix(zoom.X, 0f, 0f, -zoom.Y, ox, oy2);
                mgQDotPlus.Draw(e.Graphics, true);
                e.Graphics.ScaleTransform(1, -1);
                mgQDotPlus.DrawGraphic(e.Graphics);
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Refresh();
        }

        int mx, my;
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mx = e.X;
                my = e.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ox += e.X - mx;
                oy1 += e.Y - my;

                Refresh();
            }
            if (e.Button == MouseButtons.Right)
            {
                E = -(e.Y - oy1) / zoom.Y;

                foreach (PointF[] segment in MathGraphic.Tabulate(QDotPlus, x1, x2, h))
                    listik.Add(segment);

                mgQDotPlus.GraphicLayersPoints = listik.ToArray();

                Refresh();
            }

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ox += e.X - mx;
                oy2 += e.Y - my;

                Refresh();
            }
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (toolStripButton2.Checked)
            {
                if (e.Delta > 0)
                    zoom.ZoomIn();
                else
                    zoom.ZoomOut();
            }
            else
            {
                E += 1 * Math.Sign(e.Delta);

                foreach (PointF[] segment in MathGraphic.Tabulate(QDotPlus, x1, x2, h))
                    listik.Add(segment);

                mgQDotPlus.GraphicLayersPoints = listik.ToArray();
            }
            Refresh();
        }

        List<PointF[]> listik = new List<PointF[]>();

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton2.Checked = !toolStripButton2.Checked;
            if (toolStripButton2.Checked)
            {
                toolStripButton2.Text = "Zoom";
            }
            else
            {
                toolStripButton2.Text = "E mode";
            }
        }
    }
}
