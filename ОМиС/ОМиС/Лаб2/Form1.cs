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
        public Form1()
        {
            InitializeComponent();
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
            this.Size = textBox.Size + new Size(10 + button.Width,0);
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
                this.ClientRectangle.Width-1, this.ClientRectangle.Height-1);
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
            fp = new FormPopup(this);
            fp.Show();
            fp.FormClosed += new FormClosedEventHandler(fp_FormClosed);
            base.OnLinkClicked(e);
        }

        void fp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Value = fp.Text;
        }
    }
}