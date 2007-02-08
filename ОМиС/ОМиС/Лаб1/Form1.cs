using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Лаб1
{
    public partial class Form1 : Form
    {
        GraphicsPath grPath;
        DateTime datetimeStart;
        Timer timerForStrip;
        Pen pen;
        double speed = -1;
        double PathLength = 0;

        public Form1()
        {
            InitializeComponent();
            Bounds = Screen.PrimaryScreen.Bounds;

            //this.Opacity = 1;
            grPath = new GraphicsPath();
            datetimeStart = new DateTime();
            timerForStrip = new Timer();
            timerForStrip.Interval = 100;
            timerForStrip.Tick += new EventHandler(timerForStrip_Tick);

            pen = new Pen(Brushes.Black, 3f);
            pen.StartCap = pen.EndCap = LineCap.RoundAnchor;
        }

        void timerForStrip_Tick(object sender, EventArgs e)
        {
            if (IsInAction)
                PrintInfo();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);

            int grStepX = 20;
            int grStepY = 20;
            Pen pen = new Pen(Brushes.SteelBlue, 1f);

            for (int x = 0; x < this.Width; x += grStepX)
                e.Graphics.DrawLine(pen, x, 0, x, this.Height);

            for (int y = 0; y < this.Height; y += grStepY)
                e.Graphics.DrawLine(pen, 0, y, this.Width, y);

            grStepX = 100;
            grStepY = 100;
            pen.Width = 2f;

            for (int x = 0; x < this.Width; x += grStepX)
                e.Graphics.DrawLine(pen, x, 0, x, this.Height);

            for (int y = 0; y < this.Height; y += grStepY)
                e.Graphics.DrawLine(pen,0, y, this.Width, y);

            pen.Dispose();
        }

        private void PrintInfo()
        {
            if (IsInAction)
            {
                TimeSpan ts = DateTime.Now.Subtract(datetimeStart);
                stripLabel1.Text =
                    string.Format("{0:F2} точек; {1:F2} секунд. (~{2:F2} т/с)", 
                    PathLength, ts.TotalSeconds, PathLength / ts.TotalSeconds);
            }
            else
            {
                stripLabel1.Text =
                    string.Format("Зарегистрирована скорость: {1:F2}т/{2:F2}с = {0:F3} точек в секунду.",
                    speed, PathLength, PathLength / speed);

                Graphics g = CreateGraphics();
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawPath(pen, grPath);
                g.Dispose();
            }
        }

        private int mx = 0, my = 0;
        private bool IsInAction;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (!IsInAction)
            {
                grPath.Reset();
            }
            else
            {
                if (grPath.PointCount < 1)
                    grPath.StartFigure();

                double deltaLen = Math.Sqrt((e.X - mx) * (e.X - mx) + (e.Y - my) * (e.Y - my));
                PathLength += deltaLen;

                PrintInfo();

                grPath.AddLine(mx, my, e.X, e.Y);

                Graphics g = CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawLine(Pens.Black, mx, my, e.X, e.Y);
            }

            mx = e.X;
            my = e.Y;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            mx = e.X;
            my = e.Y;

            if (e.Button == MouseButtons.Left)
            {
                IsInAction = !IsInAction;
                if (IsInAction)
                {
                    grPath.Reset();
                    PathLength = 0;
                    datetimeStart = DateTime.Now;
                    Refresh();
                }
                else
                {
                    speed = PathLength / DateTime.Now.Subtract(datetimeStart).TotalSeconds;
                    PrintInfo();
                }
                timerForStrip.Enabled = IsInAction;
            }

            if (e.Button == MouseButtons.Right)
            {
                IsInAction = false;
                Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Point WhereExit()
        {
            return new Point(
                   this.ClientRectangle.Width - button1.Size.Width,
                   0/*this.ClientRectangle.Height - 20 - button1.Size.Height*/);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            button1.Location = WhereExit();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            button1.Location = WhereExit();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        //protected double GetPathLength()
        //{
        //    double len = 0;
        //    for (int i = 1; i < grPath.PointCount; i++)
        //    {
        //        PointF p1 = grPath.PathPoints[i - 1];
        //        PointF p2 = grPath.PathPoints[i];
        //        len += Math.Sqrt(
        //            (p2.X - p1.X) * (p2.X - p1.X) +
        //            (p2.Y - p1.Y) * (p2.Y - p1.Y));
        //    }
        //    return len;
        //}
    }
}