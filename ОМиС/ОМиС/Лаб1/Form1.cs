using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Лаб1
{
    public partial class Form1 : Form
    {
        GraphicsPath grPath;
        DateTime datetimeStart;
        Timer timerForStrip;
        Pen penFinalPath;
        double speed;
        double PathLength = 0;
        bool IsInAction;
         int mx = 0, my = 0;

        public Form1()
        {
            InitializeComponent();
            Bounds = Screen.PrimaryScreen.Bounds;

            grPath = new GraphicsPath();
            datetimeStart = new DateTime();

            timerForStrip = new Timer();
            timerForStrip.Interval = 100;
            timerForStrip.Tick += new EventHandler(timerForStrip_Tick);

            penFinalPath = new Pen(Brushes.Black, 3f);
            penFinalPath.StartCap = penFinalPath.EndCap = LineCap.RoundAnchor;
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
                e.Graphics.DrawLine(pen, 0, y, this.Width, y);

            pen.Dispose();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsInAction)
            {
                if (grPath.PointCount < 1)
                    grPath.StartFigure();

                grPath.AddLine(mx, my, e.X, e.Y);
                Graphics g = CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawLine(Pens.Black, mx, my, e.X, e.Y);

                PathLength += Math.Sqrt((e.X - mx) * (e.X - mx) + (e.Y - my) * (e.Y - my));

                PrintInfo();
            }
            else
                grPath.Reset();

            mx = e.X;
            my = e.Y;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            mx = e.X;
            my = e.Y;

            switch (e.Button)
            {
                case MouseButtons.Left:
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
                    break;
                case MouseButtons.Right:
                    IsInAction = false;
                    Refresh();
                    break;
            }

            timerForStrip.Enabled = IsInAction;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            button1.Location = WheresLocatedExit();
        }
        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            button1.Location = WheresLocatedExit();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Point WheresLocatedExit()
        {
            return new Point(
                   this.ClientRectangle.Width - button1.Size.Width,
                   0/*this.ClientRectangle.Height - 20 - button1.Size.Height*/);
        }

        private void timerForStrip_Tick(object sender, EventArgs e)
        {
            if (IsInAction)
                PrintInfo();
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
                g.DrawPath(penFinalPath, grPath);
                g.Dispose();
            }
        }
    }
}