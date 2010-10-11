using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
//using System.Diagnostics;

namespace lab1
{
    public partial class FormTree : Form
    {
        public List<string> codes = null;
        Point[] pts;
        bool[] isCode;

        float mx = 30;
        float my = 30;

        public FormTree()
        {
            InitializeComponent();
            codes = new List<string>();
        }

        public void UpdateCodes()
        {
            listBoxCodes.Items.Clear();
            listBoxCodes.Items.AddRange(codes.ToArray());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBoxCodes.Items.Add(textBox1.Text);
            codes.Add(textBox1.Text);

            textBox1.SelectAll();

            buttonBuild_Click(sender, e);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (int index in listBoxCodes.SelectedIndices)
            {
                codes.Remove((string)listBoxCodes.Items[index]);
            }

            UpdateCodes();

            buttonBuild_Click(sender, e);
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            buttonBuild.ImageIndex = -1;
            toolTip1.RemoveAll();

            pts = new Point[codes.Count * 1000];
            isCode = new bool[codes.Count * 1000];

            int count = 0;
            foreach (string code in codes)
            {
                for (int i = 0; i < code.Length; i++)
                {
                    int Bi = -1;
                    string prefix = code.Substring(0, i + 1);

                    try
                    {
                        Bi = BFromString(prefix, (int)numericUpDown1.Value);
                    }
                    catch(ArgumentException ae)
                    {
                        //MessageBox.Show(ae.Message, "Invalid code or base");
                        //imageList1.Draw(this.CreateGraphics(), listBox1.Bounds.Left, listBox1.Bounds.Bottom + 3, 0);
                        buttonBuild.ImageIndex = 0;
                        toolTip1.SetToolTip(buttonBuild, "Invalid code or base");
                        toolTip1.SetToolTip(listBoxCodes, "Invalid code or base");
                        //buttonBuild.
                    }

                    pts[count] = new Point(prefix.Length, Bi);
                    isCode[count] = false;
                    
                    //Debug.Print("Code: {0}, B(i):{1}", prefix, BFromString(prefix, (int)numericUpDown1.Value));
                    
                    count++;
                }
                isCode[count-1] = true;
            }

            Array.Resize<Point>(ref pts, count);

            pictureBox1.Refresh();
        }


        protected const string SYMBOLS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <returns>Value of number Code presented in NumberBase number base</returns>
        public static int BFromString(string code, int NumberBase)
        {
            if (NumberBase > 10) code = code.ToUpper();

            int n = code.Length;
            int value = 0;
            for (int i = 0; i < n; i++)
            {
                int index = SYMBOLS.IndexOf(code[i]);
                if (index == -1) throw new ArgumentOutOfRangeException("code", "Invalid digit at "+ i.ToString());
                if (index >= NumberBase) throw new ArgumentOutOfRangeException("base", "Invalid base at " + i.ToString());
                value += index * (int)Math.Pow(NumberBase, i);
            }

            return value;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pts == null) return;
            if (pts.Length < 1) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            int ox = 30;// pictureBox1.Width / 2;
            int oy = pictureBox1.Height - 30;
            Pen pen = new Pen(Color.Black, 0f);
            Pen penGrid = new Pen(Color.LightBlue, 0f);
            SolidBrush brushBlack = new SolidBrush(Color.Black);
            SolidBrush brushWhite = new SolidBrush(Color.White);

            g.Transform = new System.Drawing.Drawing2D.Matrix(mx, 0, 0, -my, ox, oy);

            DrawMarkup(g, ox, oy, penGrid, brushBlack);

            Point prevPt = Point.Empty;

            float r = 4f;
            for (int i = 0; i < pts.Length; i++)
            {
                int x = pts[i].X;
                int y = pts[i].Y;

                RectangleF ellipseRect = new RectangleF(x - r/mx, y - r/my, 2 * r/mx, 2 * r/my);

                g.DrawLine(pen, prevPt, pts[i]);
                g.DrawEllipse(pen, ellipseRect);

                if (isCode[i])
                {
                    g.FillEllipse(brushBlack, ellipseRect);
                    prevPt = Point.Empty;
                }
                else
                {
                    prevPt = pts[i];
                }
            }
        }

        private void DrawMarkup(Graphics g, int ox, int oy, Pen penGrid, SolidBrush brushBlack)
        {
            float max_x, max_y;
            max_x = (pictureBox1.Width - ox) / mx;
            max_y = (oy) / my;

            int stepX, stepY;
            stepX = (int)(30f / mx);
            stepY = (int)(40f / my);
            if (stepX < 1) stepX = 1;
            if (stepY < 1) stepY = 1;

            /*
             * в 10 пикс должна ложиться цифра. это бывает 
             * когда масштаб мх больше 10. если меньше - то 
             * прыгать надо через два, пока цифра в 10 пикс
             * не перестанет укладываться в 20 и т. д.
             */

            // grid
            for (int x = 0; x <= max_x; x+=stepX)
            {
                g.DrawLine(penGrid, x, -1, x, max_y + 1);
            }
            for (int y = 0; y <= max_y; y+=stepY)
            {
                g.DrawLine(penGrid, -1, y, max_x + 1, y);
            }

            Matrix m = g.Transform;
            g.ResetTransform();
            // axes
            penGrid.Width = 2f;
            penGrid.Color = Color.Black;
            g.DrawLine(penGrid, ox, 0, ox, pictureBox1.Height);
            g.DrawLine(penGrid, 0, oy, pictureBox1.Width, oy);

            // numbers
            for (int x = 0; x <= max_x; x+=stepX)
            {
                g.DrawString(x.ToString(), new Font("Arial", 10), brushBlack, x * mx + ox, oy + 5);
            }
            for (int y = stepY; y <= max_y; y+=stepY)
            {
                g.DrawString(y.ToString(), new Font("Arial", 10), brushBlack, ox - 25, -y * my + oy);
            }
            g.Transform = m;
        }

        int mouseDownX, mouseDownY;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownX = e.X; mouseDownY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            float factor;
            int dx = e.X - mouseDownX;
            int dy = e.Y - mouseDownY;

            float w = System.Windows.Forms.Screen.GetWorkingArea(pictureBox1).Width;
            factor = 1 - Math.Abs(dx / w);
            if (Math.Sign(dx) > 0)
                mx = mx / factor;
            else
                mx = mx * factor;

            float h = System.Windows.Forms.Screen.GetWorkingArea(pictureBox1).Height;
            factor = 1 - Math.Abs(dy / h);
            if (Math.Sign(dy) < 0)
                my = my / factor;
            else
                my = my * factor;

            if (mx < 1e-2f) mx = 1e-2f;
            if (my < 1e-2f) my = 1e-2f;

            pictureBox1.Refresh();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.buttonAdd_Click(sender, e);
            }
        }
    }
}
