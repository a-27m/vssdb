﻿namespace Lab_5___SysEqu__Fractal_2_
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label3;
            this.groupFirstApproximation = new System.Windows.Forms.GroupBox();
            this.textP0 = new System.Windows.Forms.TextBox();
            this.groupInterval = new System.Windows.Forms.GroupBox();
            this.textX1 = new System.Windows.Forms.TextBox();
            this.textX2 = new System.Windows.Forms.TextBox();
            this.textE = new System.Windows.Forms.TextBox();
            this.textBoxFx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listY = new System.Windows.Forms.ListBox();
            this.listRoots = new System.Windows.Forms.ListBox();
            this.textH = new System.Windows.Forms.TextBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox2.SuspendLayout();
            this.groupFirstApproximation.SuspendLayout();
            this.groupInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(this.textH);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(this.groupFirstApproximation);
            groupBox2.Controls.Add(this.groupInterval);
            groupBox2.Controls.Add(this.textE);
            groupBox2.Location = new System.Drawing.Point(131, 48);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(369, 140);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Параметры";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Symbol", 10F);
            label1.Location = new System.Drawing.Point(31, 85);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(14, 17);
            label1.TabIndex = 17;
            label1.Text = "&e";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupFirstApproximation
            // 
            this.groupFirstApproximation.Controls.Add(label2);
            this.groupFirstApproximation.Controls.Add(this.textP0);
            this.groupFirstApproximation.Location = new System.Drawing.Point(12, 24);
            this.groupFirstApproximation.Name = "groupFirstApproximation";
            this.groupFirstApproximation.Size = new System.Drawing.Size(158, 54);
            this.groupFirstApproximation.TabIndex = 15;
            this.groupFirstApproximation.TabStop = false;
            this.groupFirstApproximation.Text = "Начальное приближение";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(19, 24);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(19, 13);
            label2.TabIndex = 1;
            label2.Text = "p&0";
            // 
            // textP0
            // 
            this.textP0.Location = new System.Drawing.Point(44, 21);
            this.textP0.Name = "textP0";
            this.textP0.Size = new System.Drawing.Size(95, 20);
            this.textP0.TabIndex = 2;
            this.textP0.Text = "0";
            // 
            // groupInterval
            // 
            this.groupInterval.Controls.Add(label8);
            this.groupInterval.Controls.Add(this.textX1);
            this.groupInterval.Controls.Add(label9);
            this.groupInterval.Controls.Add(this.textX2);
            this.groupInterval.Location = new System.Drawing.Point(215, 19);
            this.groupInterval.Name = "groupInterval";
            this.groupInterval.Size = new System.Drawing.Size(143, 72);
            this.groupInterval.TabIndex = 21;
            this.groupInterval.TabStop = false;
            this.groupInterval.Text = "Интервал";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 21);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(18, 13);
            label8.TabIndex = 7;
            label8.Text = "x1";
            // 
            // textX1
            // 
            this.textX1.Location = new System.Drawing.Point(25, 18);
            this.textX1.Name = "textX1";
            this.textX1.Size = new System.Drawing.Size(100, 20);
            this.textX1.TabIndex = 8;
            this.textX1.Text = "-5";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(6, 46);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(18, 13);
            label9.TabIndex = 9;
            label9.Text = "x2";
            // 
            // textX2
            // 
            this.textX2.Location = new System.Drawing.Point(25, 43);
            this.textX2.Name = "textX2";
            this.textX2.Size = new System.Drawing.Size(100, 20);
            this.textX2.TabIndex = 10;
            this.textX2.Text = "5";
            // 
            // textE
            // 
            this.textE.Location = new System.Drawing.Point(51, 84);
            this.textE.Name = "textE";
            this.textE.Size = new System.Drawing.Size(100, 20);
            this.textE.TabIndex = 18;
            this.textE.Text = "1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(131, 21);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(30, 13);
            label7.TabIndex = 11;
            label7.Text = "f(x) =";
            // 
            // textBoxFx
            // 
            this.textBoxFx.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFx.Location = new System.Drawing.Point(165, 17);
            this.textBoxFx.Name = "textBoxFx";
            this.textBoxFx.ReadOnly = true;
            this.textBoxFx.Size = new System.Drawing.Size(230, 22);
            this.textBoxFx.TabIndex = 12;
            this.textBoxFx.Text = "n/a";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(398, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "На &поиски";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Column2
            // 
            this.Column2.Name = "Column2";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listY);
            this.groupBox5.Controls.Add(this.listRoots);
            this.groupBox5.Location = new System.Drawing.Point(131, 194);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(369, 144);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Корни";
            // 
            // listY
            // 
            this.listY.BackColor = System.Drawing.SystemColors.Control;
            this.listY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listY.Dock = System.Windows.Forms.DockStyle.Right;
            this.listY.FormattingEnabled = true;
            this.listY.IntegralHeight = false;
            this.listY.Location = new System.Drawing.Point(182, 16);
            this.listY.Name = "listY";
            this.listY.Size = new System.Drawing.Size(184, 125);
            this.listY.TabIndex = 19;
            this.listY.SelectedIndexChanged += new System.EventHandler(this.ListsSync);
            // 
            // listRoots
            // 
            this.listRoots.BackColor = System.Drawing.SystemColors.Control;
            this.listRoots.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listRoots.Dock = System.Windows.Forms.DockStyle.Left;
            this.listRoots.FormattingEnabled = true;
            this.listRoots.IntegralHeight = false;
            this.listRoots.Location = new System.Drawing.Point(3, 16);
            this.listRoots.Name = "listRoots";
            this.listRoots.Size = new System.Drawing.Size(180, 125);
            this.listRoots.TabIndex = 18;
            this.listRoots.SelectedIndexChanged += new System.EventHandler(this.ListsSync);
            // 
            // textH
            // 
            this.textH.Location = new System.Drawing.Point(51, 110);
            this.textH.Name = "textH";
            this.textH.Size = new System.Drawing.Size(100, 20);
            this.textH.TabIndex = 22;
            this.textH.Text = "1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.Location = new System.Drawing.Point(31, 111);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(13, 13);
            label3.TabIndex = 23;
            label3.Text = "&h";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 350);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxFx);
            this.Controls.Add(label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Теория алгоритмов, лаб. 4";
            this.Load += new System.EventHandler(this.Form1_Load);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            this.groupFirstApproximation.ResumeLayout(false);
            this.groupFirstApproximation.PerformLayout();
            this.groupInterval.ResumeLayout(false);
            this.groupInterval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textE;
        private System.Windows.Forms.GroupBox groupFirstApproximation;
        private System.Windows.Forms.TextBox textP0;
        private System.Windows.Forms.GroupBox groupInterval;
        private System.Windows.Forms.TextBox textX1;
        private System.Windows.Forms.TextBox textX2;
        private System.Windows.Forms.TextBox textBoxFx;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox listY;
        private System.Windows.Forms.ListBox listRoots;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox textH;

    }
}

