namespace Лаб2
{
    partial class Form1
    {
        public class TextBoxMy : System.Windows.Forms.TextBox
        {
            private System.Windows.Forms.LinkLabel target;
            public System.Windows.Forms.LinkLabel Target
            {
                get
                {
                    return target;
                }
                set
                {
                    if (value != null)
                    {
                        Location = value.Location + value.Size;
                        target = value;
                    }
                }
            }
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabelMy7 = new Лаб2.LinkLabelMy();
            this.linkLabelMy4 = new Лаб2.LinkLabelMy();
            this.linkLabelMy6 = new Лаб2.LinkLabelMy();
            this.linkLabelMy5 = new Лаб2.LinkLabelMy();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabelMy0 = new Лаб2.LinkLabelMy();
            this.linkLabelMy1 = new Лаб2.LinkLabelMy();
            this.linkLabelMy2 = new Лаб2.LinkLabelMy();
            this.linkLabelMy3 = new Лаб2.LinkLabelMy();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar1.LargeChange = 10000;
            this.trackBar1.Location = new System.Drawing.Point(153, 3);
            this.trackBar1.Maximum = 1000000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(374, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar2.LargeChange = 10000;
            this.trackBar2.Location = new System.Drawing.Point(153, 101);
            this.trackBar2.Maximum = 1000000;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(374, 45);
            this.trackBar2.TabIndex = 2;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackBar2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 216);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 196);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(530, 20);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(0, 15);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(290, 152);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 13);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(290, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.linkLabelMy7);
            this.panel2.Controls.Add(this.linkLabelMy4);
            this.panel2.Controls.Add(this.linkLabelMy6);
            this.panel2.Controls.Add(this.linkLabelMy5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 101);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(144, 92);
            this.panel2.TabIndex = 1;
            // 
            // linkLabelMy7
            // 
            this.linkLabelMy7.AutoSize = true;
            this.linkLabelMy7.Caption = "Начало отсчета:";
            this.errorProvider1.SetIconAlignment(this.linkLabelMy7, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.linkLabelMy7.Location = new System.Drawing.Point(19, 12);
            this.linkLabelMy7.Name = "linkLabelMy7";
            this.linkLabelMy7.Size = new System.Drawing.Size(98, 13);
            this.linkLabelMy7.TabIndex = 0;
            this.linkLabelMy7.TabStop = true;
            this.linkLabelMy7.Text = "Начало отсчета: 0";
            this.linkLabelMy7.Value = "0";
            this.linkLabelMy7.TextChanged += new System.EventHandler(this.linkLabel1_TextChanged);
            // 
            // linkLabelMy4
            // 
            this.linkLabelMy4.AutoSize = true;
            this.linkLabelMy4.Caption = "Единицы:";
            this.errorProvider1.SetIconAlignment(this.linkLabelMy4, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.linkLabelMy4.Location = new System.Drawing.Point(19, 75);
            this.linkLabelMy4.Name = "linkLabelMy4";
            this.linkLabelMy4.Size = new System.Drawing.Size(58, 13);
            this.linkLabelMy4.TabIndex = 3;
            this.linkLabelMy4.TabStop = true;
            this.linkLabelMy4.Text = "Единицы: ";
            this.linkLabelMy4.Value = "";
            this.linkLabelMy4.TextChanged += new System.EventHandler(this.linkLabel1_TextChanged);
            // 
            // linkLabelMy6
            // 
            this.linkLabelMy6.AutoSize = true;
            this.linkLabelMy6.Caption = "Конец отсчета:";
            this.errorProvider1.SetIconAlignment(this.linkLabelMy6, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.linkLabelMy6.Location = new System.Drawing.Point(19, 33);
            this.linkLabelMy6.Name = "linkLabelMy6";
            this.linkLabelMy6.Size = new System.Drawing.Size(104, 13);
            this.linkLabelMy6.TabIndex = 1;
            this.linkLabelMy6.TabStop = true;
            this.linkLabelMy6.Text = "Конец отсчета: 100";
            this.linkLabelMy6.Value = "100";
            this.linkLabelMy6.TextChanged += new System.EventHandler(this.linkLabel1_TextChanged);
            // 
            // linkLabelMy5
            // 
            this.linkLabelMy5.AutoSize = true;
            this.linkLabelMy5.Caption = "Делений:";
            this.errorProvider1.SetIconAlignment(this.linkLabelMy5, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.linkLabelMy5.Location = new System.Drawing.Point(19, 54);
            this.linkLabelMy5.Name = "linkLabelMy5";
            this.linkLabelMy5.Size = new System.Drawing.Size(58, 13);
            this.linkLabelMy5.TabIndex = 2;
            this.linkLabelMy5.TabStop = true;
            this.linkLabelMy5.Text = "Делений: ";
            this.linkLabelMy5.Value = "";
            this.linkLabelMy5.TextChanged += new System.EventHandler(this.linkLabel1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.linkLabelMy0);
            this.panel1.Controls.Add(this.linkLabelMy1);
            this.panel1.Controls.Add(this.linkLabelMy2);
            this.panel1.Controls.Add(this.linkLabelMy3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(144, 92);
            this.panel1.TabIndex = 0;
            // 
            // linkLabelMy0
            // 
            this.linkLabelMy0.AutoSize = true;
            this.linkLabelMy0.Caption = "Начало отсчета:";
            this.errorProvider1.SetIconAlignment(this.linkLabelMy0, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.linkLabelMy0.Location = new System.Drawing.Point(19, 12);
            this.linkLabelMy0.Name = "linkLabelMy0";
            this.linkLabelMy0.Size = new System.Drawing.Size(98, 13);
            this.linkLabelMy0.TabIndex = 0;
            this.linkLabelMy0.TabStop = true;
            this.linkLabelMy0.Text = "Начало отсчета: 0";
            this.linkLabelMy0.Value = "0";
            this.linkLabelMy0.TextChanged += new System.EventHandler(this.linkLabel1_TextChanged);
            // 
            // linkLabelMy1
            // 
            this.linkLabelMy1.AutoSize = true;
            this.linkLabelMy1.Caption = "Конец отсчета:";
            this.errorProvider1.SetIconAlignment(this.linkLabelMy1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.linkLabelMy1.Location = new System.Drawing.Point(19, 33);
            this.linkLabelMy1.Name = "linkLabelMy1";
            this.linkLabelMy1.Size = new System.Drawing.Size(104, 13);
            this.linkLabelMy1.TabIndex = 1;
            this.linkLabelMy1.TabStop = true;
            this.linkLabelMy1.Text = "Конец отсчета: 100";
            this.linkLabelMy1.Value = "100";
            this.linkLabelMy1.TextChanged += new System.EventHandler(this.linkLabel1_TextChanged);
            // 
            // linkLabelMy2
            // 
            this.linkLabelMy2.AutoSize = true;
            this.linkLabelMy2.Caption = "Делений:";
            this.errorProvider1.SetIconAlignment(this.linkLabelMy2, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.linkLabelMy2.Location = new System.Drawing.Point(19, 54);
            this.linkLabelMy2.Name = "linkLabelMy2";
            this.linkLabelMy2.Size = new System.Drawing.Size(58, 13);
            this.linkLabelMy2.TabIndex = 2;
            this.linkLabelMy2.TabStop = true;
            this.linkLabelMy2.Text = "Делений: ";
            this.linkLabelMy2.Value = "";
            this.linkLabelMy2.TextChanged += new System.EventHandler(this.linkLabel1_TextChanged);
            // 
            // linkLabelMy3
            // 
            this.linkLabelMy3.AutoSize = true;
            this.linkLabelMy3.Caption = "Единицы:";
            this.errorProvider1.SetIconAlignment(this.linkLabelMy3, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.linkLabelMy3.Location = new System.Drawing.Point(19, 75);
            this.linkLabelMy3.Name = "linkLabelMy3";
            this.linkLabelMy3.Size = new System.Drawing.Size(58, 13);
            this.linkLabelMy3.TabIndex = 3;
            this.linkLabelMy3.TabStop = true;
            this.linkLabelMy3.Text = "Единицы: ";
            this.linkLabelMy3.Value = "";
            this.linkLabelMy3.TextChanged += new System.EventHandler(this.linkLabel1_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 125;
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 216);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(10000, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 250);
            this.Name = "Form1";
            this.Text = "Шкалы";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private LinkLabelMy linkLabelMy4;
        private LinkLabelMy linkLabelMy5;
        private LinkLabelMy linkLabelMy6;
        private LinkLabelMy linkLabelMy7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private LinkLabelMy linkLabelMy0;
        private LinkLabelMy linkLabelMy1;
        private LinkLabelMy linkLabelMy2;
        private LinkLabelMy linkLabelMy3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
    }
}

