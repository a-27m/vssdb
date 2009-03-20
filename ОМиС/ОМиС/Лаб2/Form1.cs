using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Лаб2
{
    public partial class Form1 : Form
    {
        public class ScaleParams
        {
            private float m_S0;
            public float S0
            {
                get
                {
                    return m_S0;
                }
                set
                {
                    m_S0 = value;
                }
            }

            private float m_S1;
            public float S1
            {
                get
                {
                    return m_S1;
                }
                set
                {
                    m_S1 = value;
                }
            }

            private uint m_n = 100;
            public uint N
            {
                get
                {
                    return m_n;
                }
                set
                {
                    m_n = value;
                }
            }

            public float Unit
            {
                get
                {
                    return (S1 - S0) / N;
                }
            }

            private string m_unitsName;
            public string UnitsName
            {
                get
                {
                    return m_unitsName;
                }
                set
                {
                    m_unitsName = value;
                }
            }

            /// <summary>
            /// Converts value in scale sp1 to the value in the scale sp2
            /// </summary>
            /// <param name="value">Value in the scale sp1</param>
            /// <param name="sp1">Source scale</param>
            /// <param name="sp2">Destination scale</param>
            /// <returns>Value in the scale sp2</returns>
            public static float Translate(float value, ScaleParams sp1, ScaleParams sp2)
            {
                return (value - sp1.S0) * sp2.Unit / sp1.Unit + sp2.S0;
            }
        }

        ScaleParams scale1, scale2;
        MyBar myBar1, myBar2;

        public class MyBar
        {
            private int x;
            private int y;
            public int w;
            public int h;
            private float pos;
            private Form1.ScaleParams scale;

            public Form1.ScaleParams Scale
            {
                get { return scale; }
                set { scale = value; }
            }
            private Form1.ScaleParams scale0;
            private Form1.ScaleParams scaleG;

            StringFormat strFormat;

            public MyBar()
            {
                strFormat = new StringFormat(StringFormatFlags.DirectionVertical);
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;

                scale0 = new ScaleParams();
                scale0.S0 = 0;
                scale0.S1 = 1;

                scaleG = new ScaleParams();

                // to del
                pos = 0.5f;
            }

            public Point Location
            {
                get
                {
                    return new Point(x, y);
                }
                set
                {
                    x = value.X;
                    y = value.Y;
                }
            }

            public Rectangle BoundRect
            {
                get
                {
                    return new Rectangle(x, y, w, h);
                }
                set
                {
                    x = value.X;
                    y = value.Y;
                    w = value.Width;
                    h = value.Height;
                }
            }

            public float Value
            {
                get 
                {
                    return ScaleParams.Translate(pos, scale0, scale);
                }
                set
                {
                    pos = ScaleParams.Translate(value, scale, scale0);
                }
            }

            public void Click(Point where)
            {
                pos = (float)where.X / (float)w;
            }

            public void Draw(Graphics g)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                scaleG.S0 = x;
                scaleG.S1 = x + w;

                int strokeSize = 2;
                int midY = y + h / 3;

                g.DrawLine(Pens.Black, x, midY, x + w, midY);

                for (float ix = x; ix <= x + w + 1; ix += w / 20f)
                {
                    g.DrawLine(Pens.Black, ix, midY - strokeSize, ix, midY + strokeSize);
                    g.DrawString(
                        (ScaleParams.Translate((ix - x) / w, scale0, scale))
                        .ToString("F2"),
                        new Font("Arial", 8f),
                        Brushes.Black,
                        ix, midY + strokeSize + 1,
                        strFormat);
                }

                float currX = ScaleParams.Translate(pos, scale0, scaleG);
                g.DrawLine(Pens.Red,
                    currX - 2 * strokeSize, midY - 15,
                    currX, midY);

                g.DrawLine(Pens.Red,
                    currX + 2 * strokeSize, midY - 15,
                    currX, midY);

                g.DrawLine(Pens.Red,
                    currX - 2 * strokeSize, midY - 15,
                    currX + 2 * strokeSize, midY - 15);

            }
        }

        public Form1()
        {
            InitializeComponent();
            scale1 = new ScaleParams();
            scale2 = new ScaleParams();
            linkLabelMy0.DataBindings.Add("Value", scale1, "S0");
            linkLabelMy1.DataBindings.Add("Value", scale1, "S1");
            linkLabelMy2.DataBindings.Add("Value", scale1, "N");
            linkLabelMy3.DataBindings.Add("Value", scale1, "UnitsName");

            linkLabelMy7.DataBindings.Add("Value", scale2, "S0");
            linkLabelMy6.DataBindings.Add("Value", scale2, "S1");
            linkLabelMy5.DataBindings.Add("Value", scale2, "N");
            linkLabelMy4.DataBindings.Add("Value", scale2, "UnitsName");

            Point p;
            myBar1 = new MyBar();
            p = panel1.Location;
            p.Offset(panel1.Width + 10, 0);
            myBar1.Location = p;
            myBar1.h = panel1.Height;
            myBar1.w = this.Width - panel1.Width - 40;

            myBar2 = new MyBar();
            p = panel2.Location;
            p.Offset(panel2.Width + 10, 0);
            myBar2.Location = p;
            myBar2.h = panel2.Height;
            myBar2.w = this.Width - panel2.Width - 40;

            myBar1.Scale = scale1;
            myBar2.Scale = scale2;
        }

        private void linkLabel1_TextChanged(object sender, EventArgs e)
        {
            LinkLabelMy label = (LinkLabelMy)sender;
            errorProvider1.SetError(label, "");
        }

        //private void trackBars_ValueChanged(object sender, EventArgs e)
        //{
        ////    (sender as TrackBar).Value;
        ////    float value = ScaleParams.Translate(
        ////    if (sender == trackBar1)
        ////    {

        ////    }

        //    //textBox1.Text = trackBar1.Va

        //}

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float old_value = (float)trackBar1.Value / trackBar1.Maximum * (scale1.S1 - scale1.S0) + scale1.S0;

            textBox1.Text = old_value.ToString();

            float value = ScaleParams.Translate(old_value, scale1, scale2);

            textBox2.Text = value.ToString();

            try
            {
                trackBar2.Value = (int)((value - scale2.S0) / (scale2.S1 - scale2.S0) * trackBar2.Maximum);
            }
            catch (ArgumentOutOfRangeException)
            {
                trackBar2.Value = value > scale2.S1 ?
                    trackBar2.Maximum : trackBar2.Minimum;
            }

            statusLabel1.Text = string.Format("{0} {1} = {2} {3}",
                old_value, scale1.UnitsName, value, scale2.UnitsName);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            float old_value = (float)trackBar2.Value / trackBar2.Maximum * (scale2.S1 - scale2.S0) + scale2.S0;

            textBox2.Text = old_value.ToString();

            float value = ScaleParams.Translate(old_value, scale2, scale1);

            textBox1.Text = value.ToString();

            try
            {
                trackBar1.Value = (int)((value - scale1.S0) / (scale1.S1 - scale1.S0) * trackBar1.Maximum);
            }
            catch (ArgumentOutOfRangeException)
            {
                trackBar1.Value = value > scale1.S1 ?
                    trackBar1.Maximum : trackBar1.Minimum;
            }

            statusLabel1.Text = string.Format("{0} {1} = {2} {3}",
                old_value, scale2.UnitsName, value, scale1.UnitsName);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float old_value;

                if (!float.TryParse(textBox1.Text, out old_value))
                {
                    statusLabel1.Text = "Float number format error at the 1st scale!";
                    return;
                }

                float value = ScaleParams.Translate(old_value, scale1, scale2);

                try
                {
                   myBar2.Value = value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    myBar2.Value = value > scale2.S1 ? scale2.S1 : scale2.S0;
                }
                try
                {
                    myBar1.Value = old_value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    myBar1.Value = old_value > scale1.S1 ? scale1.S1 : scale1.S0;
                }


                textBox2.Text = value.ToString();

                statusLabel1.Text = string.Format("{0} {1} = {2} {3}",
    old_value, scale1.UnitsName, value, scale2.UnitsName);

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                float old_value;

                if (!float.TryParse(textBox2.Text, out old_value))
                {
                    statusLabel1.Text = "Float number format error at the 1st scale!";
                    return;
                }

                float value = ScaleParams.Translate(old_value, scale2, scale1);

                try
                {
                    myBar1.Value = value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    myBar1.Value = value > scale1.S1 ? scale1.S1 : scale1.S0;
                }
                try
                {
                    myBar2.Value = old_value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    myBar2.Value = old_value > scale2.S1 ? scale2.S1 : scale2.S0;
                }

                textBox1.Text = value.ToString();

                statusLabel1.Text = string.Format("{0} {1} = {2} {3}",
    old_value, scale2.UnitsName, value, scale1.UnitsName);

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            myBar1.Draw(e.Graphics);
            myBar2.Draw(e.Graphics);
        }

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            MyBar myBar, myBarOther;

            ScaleParams sc1, sc2;
            TextBox tx1, tx2;

            if (myBar1.BoundRect.Contains(e.X, e.Y))
            {
                myBar = myBar1;
                myBarOther = myBar2;
                sc1 = scale1;
                sc2 = scale2;
                tx1 = textBox1;
                tx2 = textBox2;
            }
            else
            {
                if (myBar2.BoundRect.Contains(e.X, e.Y))
                {
                    myBar = myBar2;
                    myBarOther = myBar1;
                    sc1 = scale2;
                    sc2 = scale1;
                    tx1 = textBox2;
                    tx2 = textBox1;
                }
                else return;
            }

            int x = e.X - myBar.Location.X;
            int y = e.Y - myBar.Location.Y;
            myBar.Click(new Point(x, y));

            #region

            float value = ScaleParams.Translate(myBar.Value, sc1, sc2);

            tx1.Text = myBar.Value.ToString();
            tx2.Text = value.ToString();

            try
            {
                myBarOther.Value = value;
            }
            catch (ArgumentOutOfRangeException)
            {
                myBarOther.Value = value > scale2.S1 ? sc2.S1 : sc2.S0;
            }

            statusLabel1.Text = string.Format("{0} {1} = {2} {3}",
                myBar.Value, sc1.UnitsName, value, sc2.UnitsName);
            #endregion

            Refresh();
        }
    }

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
}