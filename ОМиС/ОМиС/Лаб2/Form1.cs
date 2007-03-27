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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          //  linkLabel1.DefaultText;
        }
    }

    public class FormPopup : Form
    {
        TextBox textBox = null;
        GroupBox grBox = null;
        Button button = null;

        public FormPopup(LinkLabel linklabel)
        {
            grBox = new GroupBox();
            textBox = new TextBox();
            button = new Button();

            grBox.SuspendLayout();

            textBox.Name = "textBox";
            textBox.Size = new Size(100, 50);
            textBox.Location = new Point(8, 11);
            textBox.Text = linklabel.Text;

            button.Name = "button";
            button.Size = new Size(textBox.Size.Height, textBox.Size.Height);
            button.Font = new Font("Symbol", 6f);
            button.Location = new Point(
                textBox.Location.X + textBox.Size.Width + 4,
                textBox.Location.Y);
            button.TextAlign = ContentAlignment.TopCenter;
            button.Text = "®";

            grBox.Controls.Add(textBox);
            grBox.Controls.Add(button);
            grBox.Dock = DockStyle.Fill;

            this.Controls.Add(textBox);
            this.Controls.Add(button);
            this.Controls.Add(grBox);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Location = linklabel.Parent.PointToScreen(linklabel.Location) + linklabel.Size;
            this.Size = textBox.Size + new Size(16 + 6 + button.Width, 16);
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;

            grBox.ResumeLayout(false);
            grBox.PerformLayout();

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
    }

    public class LinkLabelMy : LinkLabel
    {
        FormPopup fp=null;

        string m_value= "";
       public  string Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;
            }
        }

        protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
        {
        fp = new FormPopup(this);
            fp.Show();
            fp.FormClosed += new FormClosedEventHandler(fp_FormClosed);
            base.OnLinkClicked(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            string str = Text;
            Text += " " + Value;
            base.OnPaint(e);
            Text = str;
        }

        void fp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Value = fp.Text;
            this.AutoSize = true;
            this.Size = this.PreferredSize;
        }

    }
}