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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabelMy7 = new Лаб2.LinkLabelMy();
            this.linkLabelMy4 = new Лаб2.LinkLabelMy();
            this.linkLabelMy6 = new Лаб2.LinkLabelMy();
            this.linkLabelMy5 = new Лаб2.LinkLabelMy();
            this.linkLabel1 = new Лаб2.LinkLabelMy();
            this.linkLabelMy1 = new Лаб2.LinkLabelMy();
            this.linkLabelMy2 = new Лаб2.LinkLabelMy();
            this.linkLabelMy3 = new Лаб2.LinkLabelMy();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(128, 3);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(372, 45);
            this.trackBar1.TabIndex = 0;
            // 
            // trackBar2
            // 
            this.trackBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar2.Enabled = false;
            this.trackBar2.Location = new System.Drawing.Point(128, 106);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(372, 45);
            this.trackBar2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.trackBar2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 207);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.linkLabelMy7);
            this.panel2.Controls.Add(this.linkLabelMy4);
            this.panel2.Controls.Add(this.linkLabelMy6);
            this.panel2.Controls.Add(this.linkLabelMy5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 106);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(119, 98);
            this.panel2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(264, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(264, 157);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 13);
            this.textBox2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.linkLabelMy1);
            this.panel1.Controls.Add(this.linkLabelMy2);
            this.panel1.Controls.Add(this.linkLabelMy3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(119, 97);
            this.panel1.TabIndex = 0;
            // 
            // linkLabelMy7
            // 
            this.linkLabelMy7.AutoSize = true;
            this.linkLabelMy7.Caption = "Начало отсчета:";
            this.linkLabelMy7.Location = new System.Drawing.Point(3, 12);
            this.linkLabelMy7.Name = "linkLabelMy7";
            this.linkLabelMy7.Size = new System.Drawing.Size(98, 13);
            this.linkLabelMy7.TabIndex = 7;
            this.linkLabelMy7.TabStop = true;
            this.linkLabelMy7.Text = "Начало отсчета: 0";
            this.linkLabelMy7.Value = "0";
            // 
            // linkLabelMy4
            // 
            this.linkLabelMy4.AutoSize = true;
            this.linkLabelMy4.Caption = "Единицы:";
            this.linkLabelMy4.Location = new System.Drawing.Point(3, 75);
            this.linkLabelMy4.Name = "linkLabelMy4";
            this.linkLabelMy4.Size = new System.Drawing.Size(58, 13);
            this.linkLabelMy4.TabIndex = 10;
            this.linkLabelMy4.TabStop = true;
            this.linkLabelMy4.Text = "Единицы: ";
            this.linkLabelMy4.Value = "";
            // 
            // linkLabelMy6
            // 
            this.linkLabelMy6.AutoSize = true;
            this.linkLabelMy6.Caption = "Конец отсчета:";
            this.linkLabelMy6.Location = new System.Drawing.Point(3, 33);
            this.linkLabelMy6.Name = "linkLabelMy6";
            this.linkLabelMy6.Size = new System.Drawing.Size(104, 13);
            this.linkLabelMy6.TabIndex = 8;
            this.linkLabelMy6.TabStop = true;
            this.linkLabelMy6.Text = "Конец отсчета: 100";
            this.linkLabelMy6.Value = "100";
            // 
            // linkLabelMy5
            // 
            this.linkLabelMy5.AutoSize = true;
            this.linkLabelMy5.Caption = "Делений:";
            this.linkLabelMy5.Location = new System.Drawing.Point(3, 54);
            this.linkLabelMy5.Name = "linkLabelMy5";
            this.linkLabelMy5.Size = new System.Drawing.Size(58, 13);
            this.linkLabelMy5.TabIndex = 9;
            this.linkLabelMy5.TabStop = true;
            this.linkLabelMy5.Text = "Делений: ";
            this.linkLabelMy5.Value = "";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Caption = "Начало отсчета:";
            this.linkLabel1.Location = new System.Drawing.Point(3, 12);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(98, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Начало отсчета: 0";
            this.linkLabel1.Value = "0";
            // 
            // linkLabelMy1
            // 
            this.linkLabelMy1.AutoSize = true;
            this.linkLabelMy1.Caption = "Конец отсчета:";
            this.linkLabelMy1.Location = new System.Drawing.Point(3, 33);
            this.linkLabelMy1.Name = "linkLabelMy1";
            this.linkLabelMy1.Size = new System.Drawing.Size(104, 13);
            this.linkLabelMy1.TabIndex = 4;
            this.linkLabelMy1.TabStop = true;
            this.linkLabelMy1.Text = "Конец отсчета: 100";
            this.linkLabelMy1.Value = "100";
            // 
            // linkLabelMy2
            // 
            this.linkLabelMy2.AutoSize = true;
            this.linkLabelMy2.Caption = "Делений:";
            this.linkLabelMy2.Location = new System.Drawing.Point(3, 54);
            this.linkLabelMy2.Name = "linkLabelMy2";
            this.linkLabelMy2.Size = new System.Drawing.Size(58, 13);
            this.linkLabelMy2.TabIndex = 5;
            this.linkLabelMy2.TabStop = true;
            this.linkLabelMy2.Text = "Делений: ";
            this.linkLabelMy2.Value = "";
            // 
            // linkLabelMy3
            // 
            this.linkLabelMy3.AutoSize = true;
            this.linkLabelMy3.Caption = "Единицы:";
            this.linkLabelMy3.Location = new System.Drawing.Point(3, 75);
            this.linkLabelMy3.Name = "linkLabelMy3";
            this.linkLabelMy3.Size = new System.Drawing.Size(58, 13);
            this.linkLabelMy3.TabIndex = 6;
            this.linkLabelMy3.TabStop = true;
            this.linkLabelMy3.Text = "Единицы: ";
            this.linkLabelMy3.Value = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 207);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Шкалы";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private LinkLabelMy linkLabel1;
        private LinkLabelMy linkLabelMy1;
        private LinkLabelMy linkLabelMy2;
        private LinkLabelMy linkLabelMy3;
    }
}

