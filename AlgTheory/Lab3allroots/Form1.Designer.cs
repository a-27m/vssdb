namespace Root1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textE = new System.Windows.Forms.TextBox();
            this.groupFirstApproximation = new System.Windows.Forms.GroupBox();
            this.textP0 = new System.Windows.Forms.TextBox();
            this.groupInterval = new System.Windows.Forms.GroupBox();
            this.textX1 = new System.Windows.Forms.TextBox();
            this.textX2 = new System.Windows.Forms.TextBox();
            this.textBoxFx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listY = new System.Windows.Forms.ListBox();
            this.listRoots = new System.Windows.Forms.ListBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            groupBox2.SuspendLayout();
            this.groupFirstApproximation.SuspendLayout();
            this.groupInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(this.textE);
            groupBox2.Controls.Add(this.groupFirstApproximation);
            groupBox2.Controls.Add(this.groupInterval);
            groupBox2.Controls.Add(this.textBoxFx);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new System.Drawing.Point(131, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(332, 130);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Параметры";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Symbol", 10F);
            label1.Location = new System.Drawing.Point(202, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(14, 17);
            label1.TabIndex = 17;
            label1.Text = "&e";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textE
            // 
            this.textE.Location = new System.Drawing.Point(222, 22);
            this.textE.Name = "textE";
            this.textE.Size = new System.Drawing.Size(100, 20);
            this.textE.TabIndex = 18;
            this.textE.Text = "1";
            // 
            // groupFirstApproximation
            // 
            this.groupFirstApproximation.Controls.Add(label2);
            this.groupFirstApproximation.Controls.Add(this.textP0);
            this.groupFirstApproximation.Location = new System.Drawing.Point(8, 66);
            this.groupFirstApproximation.Name = "groupFirstApproximation";
            this.groupFirstApproximation.Size = new System.Drawing.Size(158, 54);
            this.groupFirstApproximation.TabIndex = 15;
            this.groupFirstApproximation.TabStop = false;
            this.groupFirstApproximation.Text = "Начальное приближение";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(19, 13);
            label2.TabIndex = 1;
            label2.Text = "p&0";
            // 
            // textP0
            // 
            this.textP0.Location = new System.Drawing.Point(31, 19);
            this.textP0.Name = "textP0";
            this.textP0.Size = new System.Drawing.Size(100, 20);
            this.textP0.TabIndex = 2;
            this.textP0.Text = "0";
            // 
            // groupInterval
            // 
            this.groupInterval.Controls.Add(label8);
            this.groupInterval.Controls.Add(this.textX1);
            this.groupInterval.Controls.Add(label9);
            this.groupInterval.Controls.Add(this.textX2);
            this.groupInterval.Location = new System.Drawing.Point(179, 48);
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
            this.textX1.Text = "0";
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
            // textBoxFx
            // 
            this.textBoxFx.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFx.Location = new System.Drawing.Point(37, 21);
            this.textBoxFx.Name = "textBoxFx";
            this.textBoxFx.ReadOnly = true;
            this.textBoxFx.Size = new System.Drawing.Size(157, 20);
            this.textBoxFx.TabIndex = 12;
            this.textBoxFx.Text = "n/a";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(12, 25);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(21, 13);
            label7.TabIndex = 11;
            label7.Text = "f(x)";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(419, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "На поиски";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.errorProvider.SetIconAlignment(this.dataGridView1, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(113, 194);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "a[i]";
            this.Column2.Name = "Column2";
            this.Column2.Width = 20;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listY);
            this.groupBox5.Controls.Add(this.listRoots);
            this.groupBox5.Location = new System.Drawing.Point(12, 212);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(506, 151);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Корни";
            // 
            // listY
            // 
            this.listY.FormattingEnabled = true;
            this.listY.IntegralHeight = false;
            this.listY.Location = new System.Drawing.Point(255, 20);
            this.listY.Name = "listY";
            this.listY.ScrollAlwaysVisible = true;
            this.listY.Size = new System.Drawing.Size(245, 126);
            this.listY.TabIndex = 19;
            // 
            // listRoots
            // 
            this.listRoots.FormattingEnabled = true;
            this.listRoots.IntegralHeight = false;
            this.listRoots.Location = new System.Drawing.Point(6, 19);
            this.listRoots.Name = "listRoots";
            this.listRoots.ScrollAlwaysVisible = true;
            this.listRoots.Size = new System.Drawing.Size(243, 127);
            this.listRoots.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 372);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(groupBox2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Теория алгоритмов, лаб. 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            this.groupFirstApproximation.ResumeLayout(false);
            this.groupFirstApproximation.PerformLayout();
            this.groupInterval.ResumeLayout(false);
            this.groupInterval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;

    }
}

