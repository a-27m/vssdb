namespace Fractal
{
    partial class Form1
    {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBoxColor = new System.Windows.Forms.GroupBox();
            this.radioRnd = new System.Windows.Forms.RadioButton();
            this.radioMono = new System.Windows.Forms.RadioButton();
            this.radioGeo = new System.Windows.Forms.RadioButton();
            this.textBoxNorm = new System.Windows.Forms.TextBox();
            this.textBoxMaxN = new System.Windows.Forms.TextBox();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxQ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGridN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxY1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxY2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxX1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxX2 = new System.Windows.Forms.TextBox();
            this.buttonRender = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonClickClick = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxColor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(613, 455);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(613, 20);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(26, 15);
            this.toolStripLabel1.Text = "Idle";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.buttonRender);
            this.panel1.Controls.Add(this.buttonCalculate);
            this.panel1.Controls.Add(this.buttonClickClick);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 429);
            this.panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBoxColor);
            this.groupBox3.Controls.Add(this.textBoxNorm);
            this.groupBox3.Controls.Add(this.textBoxMaxN);
            this.groupBox3.Controls.Add(this.textBoxP);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxQ);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxGridN);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(10, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(164, 246);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры";
            // 
            // groupBoxColor
            // 
            this.groupBoxColor.Controls.Add(this.radioRnd);
            this.groupBoxColor.Controls.Add(this.radioMono);
            this.groupBoxColor.Controls.Add(this.radioGeo);
            this.groupBoxColor.Location = new System.Drawing.Point(6, 150);
            this.groupBoxColor.Name = "groupBoxColor";
            this.groupBoxColor.Size = new System.Drawing.Size(152, 90);
            this.groupBoxColor.TabIndex = 3;
            this.groupBoxColor.TabStop = false;
            this.groupBoxColor.Text = "Цветность";
            // 
            // radioRnd
            // 
            this.radioRnd.AutoSize = true;
            this.radioRnd.Location = new System.Drawing.Point(6, 65);
            this.radioRnd.Name = "radioRnd";
            this.radioRnd.Size = new System.Drawing.Size(79, 17);
            this.radioRnd.TabIndex = 2;
            this.radioRnd.Text = "случайный";
            this.radioRnd.UseVisualStyleBackColor = true;
            this.radioRnd.CheckedChanged += new System.EventHandler(this.radioGeo_CheckedChanged);
            // 
            // radioMono
            // 
            this.radioMono.AutoSize = true;
            this.radioMono.Location = new System.Drawing.Point(6, 42);
            this.radioMono.Name = "radioMono";
            this.radioMono.Size = new System.Drawing.Size(96, 17);
            this.radioMono.TabIndex = 1;
            this.radioMono.Text = "монохромный";
            this.radioMono.UseVisualStyleBackColor = true;
            this.radioMono.CheckedChanged += new System.EventHandler(this.radioGeo_CheckedChanged);
            // 
            // radioGeo
            // 
            this.radioGeo.AutoSize = true;
            this.radioGeo.Checked = true;
            this.radioGeo.Location = new System.Drawing.Point(6, 19);
            this.radioGeo.Name = "radioGeo";
            this.radioGeo.Size = new System.Drawing.Size(60, 17);
            this.radioGeo.TabIndex = 0;
            this.radioGeo.TabStop = true;
            this.radioGeo.Text = "спектр";
            this.radioGeo.UseVisualStyleBackColor = true;
            this.radioGeo.CheckedChanged += new System.EventHandler(this.radioGeo_CheckedChanged);
            // 
            // textBoxNorm
            // 
            this.textBoxNorm.Location = new System.Drawing.Point(6, 87);
            this.textBoxNorm.Name = "textBoxNorm";
            this.textBoxNorm.Size = new System.Drawing.Size(60, 20);
            this.textBoxNorm.TabIndex = 1;
            this.textBoxNorm.Text = "4";
            // 
            // textBoxMaxN
            // 
            this.textBoxMaxN.Location = new System.Drawing.Point(72, 87);
            this.textBoxMaxN.Name = "textBoxMaxN";
            this.textBoxMaxN.Size = new System.Drawing.Size(60, 20);
            this.textBoxMaxN.TabIndex = 1;
            this.textBoxMaxN.Text = "35";
            // 
            // textBoxP
            // 
            this.textBoxP.Location = new System.Drawing.Point(6, 38);
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.Size = new System.Drawing.Size(60, 20);
            this.textBoxP.TabIndex = 1;
            this.textBoxP.Text = "0.35";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Огр. шагов";
            // 
            // textBoxQ
            // 
            this.textBoxQ.Location = new System.Drawing.Point(72, 38);
            this.textBoxQ.Name = "textBoxQ";
            this.textBoxQ.Size = new System.Drawing.Size(60, 20);
            this.textBoxQ.TabIndex = 1;
            this.textBoxQ.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Q";
            // 
            // textBoxGridN
            // 
            this.textBoxGridN.Location = new System.Drawing.Point(59, 123);
            this.textBoxGridN.Name = "textBoxGridN";
            this.textBoxGridN.Size = new System.Drawing.Size(73, 20);
            this.textBoxGridN.TabIndex = 1;
            this.textBoxGridN.Text = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "| z |";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Сетка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "P";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxY1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxY2);
            this.groupBox2.Location = new System.Drawing.Point(10, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 51);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Y";
            // 
            // textBoxY1
            // 
            this.textBoxY1.Location = new System.Drawing.Point(6, 19);
            this.textBoxY1.Name = "textBoxY1";
            this.textBoxY1.Size = new System.Drawing.Size(60, 20);
            this.textBoxY1.TabIndex = 1;
            this.textBoxY1.Text = "-2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "...";
            // 
            // textBoxY2
            // 
            this.textBoxY2.Location = new System.Drawing.Point(98, 19);
            this.textBoxY2.Name = "textBoxY2";
            this.textBoxY2.Size = new System.Drawing.Size(60, 20);
            this.textBoxY2.TabIndex = 1;
            this.textBoxY2.Text = "2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxX1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxX2);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 51);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "X";
            // 
            // textBoxX1
            // 
            this.textBoxX1.Location = new System.Drawing.Point(6, 19);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(60, 20);
            this.textBoxX1.TabIndex = 1;
            this.textBoxX1.Text = "-2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "...";
            // 
            // textBoxX2
            // 
            this.textBoxX2.Location = new System.Drawing.Point(98, 19);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(60, 20);
            this.textBoxX2.TabIndex = 1;
            this.textBoxX2.Text = "2";
            // 
            // buttonRender
            // 
            this.buttonRender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRender.Location = new System.Drawing.Point(93, 389);
            this.buttonRender.Name = "buttonRender";
            this.buttonRender.Size = new System.Drawing.Size(75, 23);
            this.buttonRender.TabIndex = 0;
            this.buttonRender.Text = "Отобразить";
            this.buttonRender.UseVisualStyleBackColor = true;
            this.buttonRender.Click += new System.EventHandler(this.buttonRender_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalculate.Location = new System.Drawing.Point(16, 389);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 0;
            this.buttonCalculate.Text = "Рассчитать\\";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonClickClick
            // 
            this.buttonClickClick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClickClick.Location = new System.Drawing.Point(10, 376);
            this.buttonClickClick.Name = "buttonClickClick";
            this.buttonClickClick.Size = new System.Drawing.Size(164, 48);
            this.buttonClickClick.TabIndex = 4;
            this.buttonClickClick.UseVisualStyleBackColor = true;
            this.buttonClickClick.Click += new System.EventHandler(this.buttonClickClick_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(190, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(420, 429);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 455);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Julia fractal";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBoxColor.ResumeLayout(false);
            this.groupBoxColor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxP;
        private System.Windows.Forms.TextBox textBoxQ;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxY1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxY2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxX2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGridN;
        private System.Windows.Forms.Button buttonRender;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxNorm;
        private System.Windows.Forms.TextBox textBoxMaxN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel1;
        private System.Windows.Forms.GroupBox groupBoxColor;
        private System.Windows.Forms.RadioButton radioRnd;
        private System.Windows.Forms.RadioButton radioMono;
        private System.Windows.Forms.RadioButton radioGeo;
        private System.Windows.Forms.Button buttonClickClick;
    }
}

