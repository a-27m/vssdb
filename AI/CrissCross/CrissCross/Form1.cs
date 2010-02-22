using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

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

            public GameStates State;
            //public Board Parent;
            public int alpha, beta;
            public int L;
        }

        //public class Situation
        //{
        //    public Board Board;

        //    public Situation(Board board, Situation parent)
        //    {
        //        Board = board;
        //        Parent = parent;
        //    }
        //}

        public enum GameStates { Win, Draw, Loose, Intermediate }

        internal Board board;

        List<Board> open, closed;
        
        public Form1()
        {
            InitializeComponent();

            penZero = new Pen(Color.Red, 3f);
            penCross = new Pen(Color.Blue, 3f);

            //board[1, 1] = 1;

            //open = new List<Situation>();
            //closed = new List<Situation>();
        }

        private void ClickSqr(int r, int c, MouseButtons mb)
        {
            board[r, c] = mb == MouseButtons.Left ? 1 : -1;
            board[r, c] = mb == MouseButtons.Middle ? 0 : board[r, c];

            pictureBox1.Refresh();

            int[] l = OpenLines(board);
            label1.Text = string.Format("X:{0} N:{1} O:{2}", l[2], l[1], l[0]);
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
            return (l[2] - l[0]) * PlayerOne;
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

                sumD1 += b[r, r];
                smoD1 += Math.Abs(b[r, r]);

                sumD2 += b[r, 2-r];
                smoD2 += Math.Abs(b[r, 2-r]);

                for (int c = 0; c < 3; c++)
                {
                    sumC += b[r, c];
                    smoC += Math.Abs(b[r, c]);
                    sumR += b[c, r];
                    smoR += Math.Abs(b[c, r]);
                }

                sign = Math.Sign(sumC);
                if (Math.Abs(sumC) == smoC)
                {
                    if (smoC == 3)
                        lines[sign + 1] += 100;
                    else
                        lines[sign + 1]++;
                }
                
                sign = Math.Sign(sumR);

                if (Math.Abs(sumR) == smoR)
                {
                    if (smoR == 3)
                        lines[sign + 1] += 100;
                    else
                        lines[sign + 1]++;
                }
            }

            sign = Math.Sign(sumD1);
            if (Math.Abs(sumD1) == smoD1)
            {
                if (smoD1 == 3)
                    lines[sign + 1] += 100;
                else
                    lines[sign + 1]++;
            }

            sign = Math.Sign(sumD2);
            if (Math.Abs(sumD2) == smoD2)
            {
                if (smoD2 == 3)
                    lines[sign + 1] += 100;
                else
                    lines[sign + 1]++;
            }
            
            return lines;
        }
        
        int PlayerOne, PlayerTwo;
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (radioAiX.Checked)
            { PlayerOne = 1; PlayerTwo = -1; }
            else
            { PlayerOne = -1; PlayerTwo = 1; }

            bool gameover = IsGameOver();

            int alphaCount = 0, betaCount = 0;

            int maxL = int.MinValue;
            Board bestOr = board;

            List<Board> orList = GetChildren(board, PlayerOne).ToList<Board>();

            #region this block handles possible beta-cut of every turn (when only possible next turn is bad)
            int L_board = L(board);
            bool disableBetaCut = true;
            foreach (Board or in orList) { disableBetaCut &= (L(or) <= L_board); }
            if (disableBetaCut) L_board = int.MinValue;
            #endregion

            List<Board> andList = null;
            foreach (Board or in orList)
            {
                int minL = int.MaxValue;
                Board bestAnd;

                // beta-cutting
                if (L(or) <= L_board)
                {
                    betaCount++;
                    continue;
                }

                andList = GetChildren(or, PlayerTwo).ToList<Board>();
                foreach (Board and in andList)
                {
                    if (L(and) >= L(or))
                    {
                        alphaCount++;
                        continue;
                    }
                    if (L(and) < minL)
                    {
                        minL = L(and);
                        bestAnd = and;
                    }
                }

                if (minL > maxL)
                {
                    maxL = minL;
                    bestOr = or;
                }
            }

            board = bestOr;

            if (orList == null || andList == null)
            {
                textBox1.Text = string.Format(
                    "D <= 1" + Environment.NewLine +
                    "N alpha: {0}" + Environment.NewLine +
                    "N beta: {1}",
                    alphaCount,
                    betaCount
                    );
            }
            else
            {
                int nd = andList.Count * (orList.Count - betaCount) - alphaCount;
                float n = (float)nd / (andList.Count * orList.Count);

                textBox1.Text = string.Format(
                    "N alpha: {0}" + Environment.NewLine +
                    "N beta: {1}" + Environment.NewLine +
                    "ND: {2}" + Environment.NewLine +
                    "n: {3}",
                    alphaCount,
                    betaCount,
                    nd,
                    n.ToString("F2")
                    );
            }
            pictureBox1.Refresh();

            if (!gameover) IsGameOver();

            return;
        }

        private bool IsGameOver()
        {
            label1.Text = string.Format("L:{0}", L(board));

            int[] l = OpenLines(board);

            if (l[0] > 10)
            {
                label1.Text = ("Zeroes win!");
                return true;
            }
            else
                if (l[2] > 10)
                {
                    label1.Text = ("Crosses win!");
                    return true;
                }
                else
                    if (l[0] + l[1] + l[2] == 0)
                    {
                        label1.Text = ("Draw!");
                        return true;
                    }
            return false;
        }

        private IEnumerable<Board> GetChildren(Board board, int PlayerCode)
        {
            Board child;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i,j]==0)
                    {
                        // create a copy
                        child = board;

                        //child.Parent = board;
                        child[i,j] = PlayerCode;
                        child.L = L(child);
                        yield return child;
                    }
                }
            }
            yield break;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            board = new Board();
            pictureBox1.Refresh();
            textBox1.Clear();
            label1.Text = "Ready";
        }

    }
}
