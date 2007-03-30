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
     public   class ScaleParams
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

            private int m_n;
            public int N
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
                return (value * sp1.Unit + (sp2.S0 - sp1.S0)) / sp2.Unit;
            }
        }

        ScaleParams scale1, scale2;

        public Form1()
        {
            InitializeComponent();
            scale1 = new ScaleParams();
            scale2 = new ScaleParams();
            linkLabelMy0.DataBindings.Add("Value", scale1, "S0", true, DataSourceUpdateMode.OnPropertyChanged);
            linkLabelMy1.DataBindings.Add("Value", scale1, "S1", true, DataSourceUpdateMode.OnPropertyChanged);
            linkLabelMy2.DataBindings.Add("Value", scale1, "N", true, DataSourceUpdateMode.OnPropertyChanged);
            linkLabelMy3.DataBindings.Add("Value", scale1, "UnitsName", true, DataSourceUpdateMode.OnPropertyChanged);

            linkLabelMy7.DataBindings.Add("Value", scale2, "S0", true, DataSourceUpdateMode.OnPropertyChanged);
            linkLabelMy6.DataBindings.Add("Value", scale2, "S1", true, DataSourceUpdateMode.OnPropertyChanged);
            linkLabelMy5.DataBindings.Add("Value", scale2, "N", true, DataSourceUpdateMode.OnPropertyChanged);
            linkLabelMy4.DataBindings.Add("Value", scale2, "UnitsName", true, DataSourceUpdateMode.OnPropertyChanged);
        }


        private void linkLabel1_TextChanged(object sender, EventArgs e)
        {
            LinkLabelMy label = (LinkLabelMy)sender;
            errorProvider1.SetError(label, "");
        }

        //private void trackBars_ValueChanged(object sender, EventArgs e)
        //{


        //    (sender as TrackBar).Value+;
        //    float value = ScaleParams.Translate(
        //    if (sender == trackBar1)
        //    {

        //    }
        //}

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float old_value = (float)trackBar1.Value/trackBar1.Maximum * (scale1.S1 - scale1.S0) + scale1.S0;

            textBox1.Text = old_value.ToString();

            float value = ScaleParams.Translate(old_value, scale1, scale2);
            trackBar2.Value = (int)((value - scale2.S0) / (scale2.S1 - scale2.S0)*trackBar2.Maximum);

            statusLabel1.Text = string.Format("{0} {1} = {2} {3}",
                old_value, scale1.UnitsName, value, scale2.UnitsName);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            float old_value = (float)trackBar2.Value/trackBar2.Maximum * (scale2.S1 - scale2.S0) + scale2.S0;

            textBox2.Text = old_value.ToString();

            float value = ScaleParams.Translate(old_value, scale2, scale1);
            trackBar1.Value = (int)((value - scale1.S0) / (scale1.S1 - scale1.S0)*trackBar1.Maximum);

            statusLabel1.Text = string.Format("{0} {1} = {2} {3}",
                old_value, scale2.UnitsName, value, scale1.UnitsName);
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
            this.Value = fp.Text;
        }
    }
}