using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CrissCross
{
    public partial class Form1 : Form
    {
        Pen penZero, penCross;

        public struct Board
        {
            int _00, _01, _02;
            int _10, _11, _12;
            int _20, _21, _22;

            public int this[int r, int c]
            {
                get
                {
                    switch (r * 10 + c)
                    {
                        case 0:
                            return _00;
                        case 1:
                            return _01;
                        case 2:
                            return _02;
                        case 10:
                            return _10;
                        case 11:
                            return _11;
                        case 12:
                            return _12;
                        case 20:
                            return _20;
                        case 21:
                            return _21;
                        case 22:
                            return _22;
                    }

                    throw new ArgumentOutOfRangeException();
                }
                set
                {
                    switch (r * 10 + c)
                    {
                        case 0:
                            _00 = value;
                            break;
                        case 1:
                            _01 = value;
                            break;
                        case 2:
                            _02 = value;
                            break;
                        case 10:
                            _10 = value;
                            break;
                        case 11:
                            _11 = value;
                            break;
                        case 12:
                            _12 = value;
                            break;
                        case 20:
                            _20 = value;
                            break;
                        case 21:
                            _21 = value;
                            break;
                        case 22:
                            _22 = value;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public class Situation
        {
            public Board Board;
            public GameStates State;
            public Situation Parent;

            public Situation(Board board, Situation parent)
            {
                Board = board;
                Parent = parent;
            }
        }

        public enum GameStates { Win, Draw, Loose, Intermediate }

        internal Board board;

        List<Situation> open, closed;
        
        public Form1()
        {
            InitializeComponent();

            penZero = new Pen(Color.Red, 3f);
            penCross = new Pen(Color.Blue, 3f);

            //board[1, 1] = 1;

            open = new List<Situation>();
            closed = new List<Situation>();
        }

        private void ClickSqr(int r, int c, MouseButtons mb)
        {
            board[r, c] = mb == MouseButtons.Left ? 1 : -1;
            
            pictureBox1.Refresh();

            int[] l = OpenLines(board);
            Text = string.Format("X:{0} N:{1} O:{2}", l[2], l[1], l[0]);
        }
        
        #region I/O
		
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int w = pictureBox1.Width / 3;
            int h = pictureBox1.Height / 3;

            int r = e.X / w;
            int c = e.Y / h;

            if (r >= 0 && r <= 3 &&
                c >= 0 && c <= 3) ClickSqr(r, c, e.Button);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int w1 = pictureBox1.Width / 3;
            int h1 = pictureBox1.Height / 3;
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;

            e.Graphics.DrawLine(Pens.Black, w1, 0, w1, h);
            e.Graphics.DrawLine(Pens.Black, 2*w1, 0, 2*w1, h);

            e.Graphics.DrawLine(Pens.Black, 0, h1, w, h1);
            e.Graphics.DrawLine(Pens.Black, 0, 2*h1, w, 2*h1);

            //if (board != null)
                DrawBoard(e.Graphics, w, h, w1, h1);
        }

        private void DrawBoard(Graphics g, int w, int h, int w1, int h1)
        {
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (board[r, c] == 1)
                        DrawCross(g, r, c, w1, h1);
                    else if (board[r, c] == -1)
                        DrawZero(g, r, c, w1, h1);
        }

        private void DrawCross(Graphics g, int r, int c, int w1, int h1)
        {
            Rectangle rc = new Rectangle(r*w1, c*h1, w1, h1);
            rc.Inflate(-6, -6);

            g.DrawLine(penCross, rc.Left, rc.Top, rc.Right, rc.Bottom);
            g.DrawLine(penCross, rc.Right, rc.Top, rc.Left, rc.Bottom);
        }

        private void DrawZero(Graphics g, int r, int c, int w1, int h1)
        {
            Rectangle rc = new Rectangle(r*w1, c*h1, w1, h1);
            rc.Inflate(-6, -6);

            g.DrawEllipse(penZero, rc);
        }        

        #endregion

        private int L(Board b)
        {
            int[] l = OpenLines(b);
            return l[2] - l[0];
        }

        private int[] OpenLines(Board b)
        {
            int[] lines = new int[3];

            int sumR, smoR, sumC, smoC; // summa and sum of modules
            int sumD1, smoD1, sumD2, smoD2; // summa and sum of modules
            int sign;

            sumD1 = 0;
            smoD1 = 0;
            sumD2 = 0;
            smoD2 = 0;

            for (int r = 0; r < 3; r++)
            {
                sumR = 0;
                smoR = 0;
                sumC = 0;
                smoC = 0;

                sumD1 += board[r, r];
                smoD1 += Math.Abs(board[r, r]);

                sumD2 += board[r, 2-r];
                smoD2 += Math.Abs(board[r, 2-r]);

                for (int c = 0; c < 3; c++)
                {
                    sumC += board[r, c];
                    smoC += Math.Abs(board[r, c]);
                    sumR += board[c, r];
                    smoR += Math.Abs(board[c, r]);
                }

                sign = Math.Sign(sumC);
                if (Math.Abs(sumC) == smoC) lines[sign + 1]++;
                sign = Math.Sign(sumR);
                if (Math.Abs(sumR) == smoR) lines[sign + 1]++;
            }

            sign = Math.Sign(sumD1);
            if (Math.Abs(sumD1) == smoD1) lines[sign + 1]++;
            sign = Math.Sign(sumD2);
            if (Math.Abs(sumD2) == smoD2) lines[sign + 1]++;
            
            return lines;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            open.Clear();
            closed.Clear();

            open.Add(new Situation(board, null));

            // step 3
            Situation n = open[0];
            UpdateState(n);
            closed.Add(n);

        }

        private void UpdateState(Situation n)
        {
            //TODO find out if game is finished
            throw new NotImplementedException();
        }
    }
}
