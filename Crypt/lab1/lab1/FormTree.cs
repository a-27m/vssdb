using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab1
{
    public partial class FormTree : Form
    {
        public List<string> codes = null;
        Point[] pts;

        public FormTree()
        {
            InitializeComponent();
        }

        public void UpdateCodes()
        {
            if (codes != null)
                listBox1.Items.AddRange(codes.ToArray());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            codes.Add(textBox1.Text);

            textBox1.SelectAll();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            codes.Clear();
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            pts = new Point[codes.Count];

            int count = 0;
            foreach (string code in codes)
            {
                for (int i = 0; i < code.Length; i++)
                {
                    string prefix = code.Substring(0, i + 1);
                    pts[count++] = new Point(prefix.Length, BFromString(prefix, (int)numericUpDown1.Value));
                }
            }

            pictureBox1.Refresh();
        }


        protected const string SYMBOLS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static int BFromString(string code, int NumberBase)
        {
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

            for (int i = 0; i < pts.Length; i++)
            {
                int x = pts[i].X;
                int y = pts[i].Y;
                int r = 2;
                g.DrawEllipse(Pens.Black, x - r, y - r, 2 * r, 2 * r);
            }
        }

    }
}
