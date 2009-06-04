using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab_7_Fourier
{
    public partial class Form1 : Form
    {
        float[] X, A;
        bool fReady = false;
        //ai = 2*X*Xi/n
        //Xi = Cos(i*Pi*t/T)
        float[] cosX(int i)
        {
            float[] v = new float[(int)n];
            for (int k = 0; k < n; k++) v[k] = (float)Math.Cos(i * Math.PI * (x1 + k * dT + dT / 2f) / (x2 - x1));
            return v;
        }
        
        void Fourier()
        {
            if (X == null) return;

            A = new float[(int)n];
         
            A[0] = vMult(X, cosX(0)) / n;

            for (int i = 1; i < n; i++)
                A[i] = vMult(X, cosX(i)) * 2f / n;

            fReady = true;
        }

        float vMult(float[] a, float[] b)
        { 
            float s = 0;
            for (int i = 0; i < a.Length; i++)
                s += a[i] * b[i];

            return s;
        }

        float mx { get { return (pictureBox1.Width - 2 * marg) / (x2 - x1); } }
        float my { get { return (pictureBox1.Height - 2 * marg) / (y2 - y1); } }

        float ox, oy;
        int marg;
        int dw;
        float x1, x2;
        float y1, y2;

        float n { get { return (float)numericUpDown1.Value; } }
        float dT { get { return (x2 - x1) / n; } }
        float dY { get { return (y2 - y1) / n; } }

        Rectangle rectBox;//initialized on first resize before initshow
        Pen penBox, penGrid, penF;
        Font fontBox;
        Brush fontBrush, brushDot;
        StringFormat strFromatBoxX, strFromatBoxY;

        public Form1()
        {
            InitializeComponent();

            //mx = my = 20f;
            //ox = pictureBox1.Width / 2f;
            //oy = pictureBox1.Height / 2f;
            marg = 40;
            dw = 3;

            x1 = 0f;
            x2 = 4f;
            y1 = 0f;
            y2 = 5f;

            penBox = new Pen(Color.Black, 2f);
            penF = new Pen(Color.Green, 1f);
            penGrid = new Pen(Color.Gray, 0f);
            brushDot = new SolidBrush(Color.Red);
            fontBox = new Font("Arial", 10f);
            fontBrush = Brushes.Black;

            strFromatBoxX = new StringFormat(StringFormatFlags.NoWrap);
            strFromatBoxX.Alignment = StringAlignment.Center; // far is to the right
            strFromatBoxX.LineAlignment = StringAlignment.Near; // under the line

            strFromatBoxY = new StringFormat(StringFormatFlags.NoWrap);
            strFromatBoxY.Alignment = StringAlignment.Far; // to the right
            strFromatBoxY.LineAlignment = StringAlignment.Center; // on the line
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Transform = new Matrix(mx, 0, 0, -my, ox, oy);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            DrawAxes(e.Graphics);
            DrawHarmonics(e.Graphics);
            DrawXNodes(e.Graphics);

        }

        private void DrawXNodes(Graphics g)
        {
            if (X == null) return;

            for (int i = 0; i < n; i++)
            {
                g.FillEllipse(brushDot, TrX(x1 + i * dT+ dT / 2f) - dw, TrY(X[i]) - dw, 2*dw, 2*dw);
            }
        }

        private void DrawHarmonics(Graphics g)
        {
            if (!fReady) return;

            float x, y;
            x = TrX(x1);
            y = TrY(f(x1));

            for (float t = x1; t < x2; t += dT / 100f)
            {
                //g.DrawEllipse(penF, TrX(t) - 1, TrY(f(t)) - 1, 2, 2);
                g.DrawLine(penF, TrX(t), TrY(f(t)), x, y);
                x = TrX(t);
                y = TrY(f(t));
            }
        }

        public float TrX(float x) { return x * mx + marg + ox; }
        public float TrY(float y) { return -y * my + pictureBox1.Height - marg + oy; }

        private void DrawAxes(Graphics g)
        {
            for (float x = x1; x < x2 + dT / 2f; x += dT)
            {
                g.DrawLine(penGrid, TrX(x), TrY(y1), TrX(x), TrY(y2));
                g.DrawString(x.ToString("F2"), fontBox, fontBrush, TrX(x), pictureBox1.Bottom - marg, strFromatBoxX);
            }
            for (float y = y1; y < y2 + dY / 2f; y += dY)
            {
                g.DrawLine(penGrid, TrX(x1), TrY(y), TrX(x2), TrY(y));
                g.DrawString(y.ToString("F2"), fontBox, fontBrush, marg, TrY(y), strFromatBoxY);
            }

            g.DrawRectangle(penBox,
                0 + marg,
                0 + marg,
                pictureBox1.Width - 2 * marg,
                pictureBox1.Height - 2 * marg);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            rectBox = new Rectangle(new Point(0, 0),
                    pictureBox1.Size);
            //rectBox.Inflate(marg, marg);

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //return;
            //if (e.Button == MouseButtons.Left)
            //{
            //    int i = (int)Math.Round((e.X - ox - marg) / mx / dT);
            //    Text += "i" + i.ToString();
            //    if (X == null) X = new float[(int)n];

            //    if (i >= X.Length) return;

            //    X[i] = -(e.Y - oy + marg - rectBox.Height) / my;
            //    Text += "X"+X[i].ToString("F1");

            //    Fourier();

            //    pictureBox1.Refresh();
            //}
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            X = null;
            fReady = false;

            pictureBox1.Refresh();
        }

        float f(float t)
        {
            float s = 0;
            for (int i = 0; i < n; i++)
                s += (float)(A[i] * Math.Cos(i * Math.PI * t / (x2 - x1)));

            return s;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Fourier();

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int i = (int)Math.Round((e.X - ox - marg) / mx / dT - 0.5f);
                Text += "i" + i.ToString();
                if (X == null) X = new float[(int)n];

                if (i < 0 || i >= X.Length) return;

                X[i] = -(e.Y - oy + marg - pictureBox1.Height) / my;
                Text += "X" + X[i].ToString("F1");

                Fourier();

                pictureBox1.Refresh();
            }
        }
    }
}
