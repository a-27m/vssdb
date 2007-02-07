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
        double speed = -1;


        public Form1()
        {
            InitializeComponent();
            grPath = new GraphicsPath();
            datetimeStart = new DateTime();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //PrintInfo(e.Graphics);
        }

        private void PrintInfo()
        {
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            ////e.Graphics.DrawPath(Pens.Black, grPath);
            //Font font = new Font(FontFamily.GenericSansSerif, 16f);

            //if (IsInAction)
            //{
            //    TimeSpan ts = DateTime.Now.Subtract(datetimeStart);
            //    g.DrawString(
            //        string.Format("{0:F2} точек; {1:F2} секунд.", GetPathLength(), ts.TotalSeconds),
            //        font,
            //        Brushes.Black,
            //        new PointF(0, 0));
            //}
            //else
            //{
            //    g.DrawString(
            //        string.Format("Зарегистрирована скорость: {0:F3} точек в секунду.", speed),
            //        font,
            //        Brushes.Black,
            //        new PointF(0, 0));
            //}

            if (IsInAction)
            {
                TimeSpan ts = DateTime.Now.Subtract(datetimeStart);
                stripLabel1.Text =
                    string.Format("{0:F2} точек; {1:F2} секунд.", GetPathLength(), ts.TotalSeconds);
            }
            else
            {
                stripLabel1.Text =
                    string.Format("Зарегистрирована скорость: {0:F3} точек в секунду.", speed);
            }

        }

        private int mx = 0, my = 0;
        private bool IsInAction;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsInAction)
            {
                grPath.Reset();
                mx = e.X;
                my = e.Y;
                return;
            }
            else
            {
                if (grPath.PointCount < 1)
                    grPath.StartFigure();

                grPath.AddLine(mx, my, e.X, e.Y);
                Graphics g = CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawLine(Pens.Black, mx, my, e.X, e.Y);
                PrintInfo();

                //Size sz = new Size(Math.Abs(mx - e.X)+4, Math.Abs(my - e.Y)+4);
                //Point pt = new Point((mx < e.X) ? mx-2 : e.X-2, (my < e.Y) ? my-2: e.Y-2);
                //this.Invalidate(new Rectangle(pt, sz));

                mx = e.X;
                my = e.Y;
            }
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
                    datetimeStart = DateTime.Now;
                }
                else
                {
                    speed = GetPathLength() / DateTime.Now.Subtract(datetimeStart).TotalSeconds;
                    Refresh();
                }

            }

            if (e.Button == MouseButtons.Right)
            {
                IsInAction = false;
                Refresh();
            }
        }

        protected double GetPathLength()
        {
            double len = 0;
            for (int i = 1; i < grPath.PointCount; i++)
            {
                PointF p1 = grPath.PathPoints[i - 1];
                PointF p2 = grPath.PathPoints[i];
                len += Math.Sqrt(
                    (p2.X - p1.X) * (p2.X - p1.X) +
                    (p2.Y - p1.Y) * (p2.Y - p1.Y));
            }
            return len;
        }
    }
}