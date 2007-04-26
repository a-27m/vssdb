using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

using DekartGraphic;

namespace Root1
{
    public partial class Form1 : Form
    {
        List<MathGraphic> mgs;
        Matrix matrix;

        class coefs
        {
            protected double _a, _b, _c;

            public double c
            {
                get
                {
                    return _c;
                }
                set
                {
                    _c = value;
                }
            }

            public double b
            {
                get
                {
                    return _b;
                }
                set
                {
                    _b = value;
                }
            }

            public double a
            {
                get
                {
                    return _a;
                }
                set
                {
                    _a = value;
                }
            }
        }
        coefs p;

        double fxy0(double x, double y)
        {            
            return p.a * x * x + p.b * y * y * y + p.c * x * y * y + x * x * x * x * x * x * x;
        }
        double fxy1(double x, double y)
        {
            return x * x * x + y * y * y - x * y;
        }
        double fxy2(double x, double y)
        {
            return x * x * x + y * y * y + x * x + 1.01 * y * y - 0.15;
        }

        public Form1()
        {
            InitializeComponent();
            matrix = new Matrix(300, 0f, 0f, -300, 200, 200);
            mgs = new List<MathGraphic>();

            p = new coefs();
            p.a = 5;
            p.b = 1;
            p.c = 5;

            fxy = fxy0;

            radioButton0.Enabled = true;

            linkLabel1.DataBindings.Add("Value", p, "a");
            linkLabelMy1.DataBindings.Add("Value", p, "b");
            linkLabelMy2.DataBindings.Add("Value", p, "c");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (mgs != null)
            {
                if (mgs.Count < 1)
                    return;

                Invalidate();

                List<MathGraphic>.Enumerator i = mgs.GetEnumerator();
                i.MoveNext();

                e.Graphics.Transform = matrix;
                //i.Current.DrawCoordinateSystem(e.Graphics);
                i.Current.Draw(e.Graphics);

                while (i.MoveNext())
                    i.Current.DrawGraphic(e.Graphics);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            PointF[] pts = new PointF[] { new PointF(e.X, e.Y) };
            Matrix tmp = matrix.Clone();
            tmp.Invert();
            tmp.TransformPoints(pts);
            Text = string.Format("{0}, {1}", pts[0].X, pts[0].Y);
        }

        double[] Iteration(DoubleFunction f, double a, double b, double h)
        {
            List<double> roots = new List<double>();
            int lastSign = Math.Sign(f(a));

            for (double x = a; x <= b; x += h)
            {
                int sign = Math.Sign(f(x));
                if (sign == 0)
                    sign = lastSign;
                if (sign != lastSign)
                {
                    roots.Add(x);
                    //OnRootFound(x);
                }
                lastSign = sign;
            }

            return roots.ToArray();
        }

        delegate double DoubleFunctionXY(double x, double y);

        double fy0(double x)
        {
            return fxy(x, y);
        }
        double fx0(double y)
        {
            return fxy(x, y);
        }

        double x, y;
        DoubleFunctionXY fxy;

        private void button1_Click(object sender, EventArgs e)
        {
            DekartForm df = new DekartForm(30, 30, 200, 200);

            List<PointF> pts = new List<PointF>();

            double x1 = -3;
            double x2 = 3;
            double hx = 0.005;

            double y1 = -3;
            double y2 = 3;
            double hy = 0.005;

            for (y = y1; y < y2; y += hy)
            {
                double[] rootX = Iteration(fy0, x1, x2, hx);

                for (int i = 0; i < rootX.Length; i++)
                    pts.Add(new PointF((float)rootX[i], (float)y));
            }

            for (x = x1; x < x2; x += hx)
            {
                double[] rootY = Iteration(fx0, y1, y2, hy);

                for (int i = 0; i < rootY.Length; i++)
                    pts.Add(new PointF((float)x, (float)rootY[i]));
            }


            df.AddPolygon(Color.Gray, DrawModes.DrawPoints, pts.ToArray());
            df.Show();
            df.Update2();
        }

        #region linklabel

        public class FormPopup : Form
        {
            TextBox textBox = null;
            Button button = null;

            public FormPopup(LinkLabelMy linklabel)
            {
                textBox = new TextBox();
                button = new Button();

                textBox.Name = "textBox";
                textBox.Size = new Size(100, 50);
                textBox.Location = new Point(4, 7);
                textBox.Text = linklabel.Value;

                button.Name = "button";
                button.Size = new Size(textBox.Size.Height, textBox.Size.Height);
                button.Font = new Font("Symbol", 6f);
                button.Location = new Point(
                    textBox.Location.X + textBox.Size.Width + 2,
                    textBox.Location.Y);
                button.TextAlign = ContentAlignment.TopCenter;
                button.Text = "®";

                this.Controls.Add(textBox);
                this.Controls.Add(button);
                this.FormBorderStyle = FormBorderStyle.None;
                this.Location = linklabel.Parent.PointToScreen(linklabel.Location) + linklabel.Size;
                this.Size = textBox.Size + new Size(10 + button.Width, 0);
                this.ShowInTaskbar = false;
                this.StartPosition = FormStartPosition.Manual;

                textBox.Select();

                textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
                button.Click += new EventHandler(button_Click);
                this.Deactivate += new EventHandler(FormPopup_Deactivate);
            }

            void textBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Enter)
                    button_Click(sender, e);
                if (e.KeyChar == (char)Keys.Escape)
                    FormPopup_Deactivate(sender, e);
            }
            void FormPopup_Deactivate(object sender, EventArgs e)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            void button_Click(object sender, EventArgs e)
            {
                DialogResult = DialogResult.OK;
                this.Text = textBox.Text;
                this.Close();
            }

            public override string Text
            {
                get
                {
                    if (textBox == null)
                        return null;
                    return textBox.Text;
                }
                set
                {
                    textBox.Text = value;
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.DrawRectangle(Pens.SlateBlue,
                    this.ClientRectangle.X, this.ClientRectangle.Y,
                    this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
            }
        }

        public class LinkLabelMy : LinkLabel
        {
            FormPopup fp = null;

            string m_caption;
            public string Caption
            {
                get
                {
                    return m_caption;
                }
                set
                {
                    m_caption = value;
                    Text = Caption + " " + value;
                }
            }

            string m_value = "";
            public string Value
            {
                get
                {
                    return m_value;
                }
                set
                {
                    m_value = value;
                    Text = Caption + " " + value;
                }
            }

            protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
            {
                base.OnLinkClicked(e);

                fp = new FormPopup(this);
                fp.Show();
                fp.FormClosed += new FormClosedEventHandler(fp_FormClosed);
            }

            void fp_FormClosed(object sender, FormClosedEventArgs e)
            {
                this.m_value = fp.Text;
                foreach (Binding binding in this.DataBindings)
                {
                    binding.WriteValue();
                    binding.ReadValue();
                }
            }
        }

        #endregion

        private void radioButton0_CheckedChanged(object sender, EventArgs e)
        {
            fxy = fxy0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fxy = fxy1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            fxy = fxy2;
        }



    }
}