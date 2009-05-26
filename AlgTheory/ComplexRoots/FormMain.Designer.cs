namespace ComplexRoots
{
    partial class FormMain
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
            System.Windows.Forms.Label label7;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxMaxN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupInterval = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textY1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textY2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textX1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textX2 = new System.Windows.Forms.TextBox();
            this.textE = new System.Windows.Forms.TextBox();
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
            label7 = new System.Windows.Forms.Label();
            groupBox2.SuspendLayout();
            this.groupInterval.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(this.textBoxMaxN);
            groupBox2.Controls.Add(this.label6);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(this.groupInterval);
            groupBox2.Controls.Add(this.textE);
            groupBox2.Location = new System.Drawing.Point(131, 48);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(369, 172);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Параметры";
            // 
            // textBoxMaxN
            // 
            this.textBoxMaxN.Location = new System.Drawing.Point(85, 66);
            this.textBoxMaxN.Name = "textBoxMaxN";
            this.textBoxMaxN.Size = new System.Drawing.Size(81, 20);
            this.textBoxMaxN.TabIndex = 23;
            this.textBoxMaxN.Text = "35";
            this.textBoxMaxN.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Огр. шагов";
            this.label6.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Symbol", 10F);
            label1.Location = new System.Drawing.Point(65, 39);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(14, 17);
            label1.TabIndex = 17;
            label1.Text = "&e";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupInterval
            // 
            this.groupInterval.Controls.Add(this.groupBox1);
            this.groupInterval.Controls.Add(this.groupBox3);
            this.groupInterval.Location = new System.Drawing.Point(182, 19);
            this.groupInterval.Name = "groupInterval";
            this.groupInterval.Size = new System.Drawing.Size(176, 138);
            this.groupInterval.TabIndex = 21;
            this.groupInterval.TabStop = false;
            this.groupInterval.Text = "Интервал";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textY1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textY2);
            this.groupBox1.Location = new System.Drawing.Point(6, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 51);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Y";
            // 
            // textY1
            // 
            this.textY1.Location = new System.Drawing.Point(6, 19);
            this.textY1.Name = "textY1";
            this.textY1.Size = new System.Drawing.Size(60, 20);
            this.textY1.TabIndex = 1;
            this.textY1.Text = "-2";
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
            // textY2
            // 
            this.textY2.Location = new System.Drawing.Point(98, 19);
            this.textY2.Name = "textY2";
            this.textY2.Size = new System.Drawing.Size(60, 20);
            this.textY2.TabIndex = 1;
            this.textY2.Text = "2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textX1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textX2);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(164, 51);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "X";
            // 
            // textX1
            // 
            this.textX1.Location = new System.Drawing.Point(6, 19);
            this.textX1.Name = "textX1";
            this.textX1.Size = new System.Drawing.Size(60, 20);
            this.textX1.TabIndex = 1;
            this.textX1.Text = "-2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "...";
            // 
            // textX2
            // 
            this.textX2.Location = new System.Drawing.Point(98, 19);
            this.textX2.Name = "textX2";
            this.textX2.Size = new System.Drawing.Size(60, 20);
            this.textX2.TabIndex = 1;
            this.textX2.Text = "2";
            // 
            // textE
            // 
            this.textE.Location = new System.Drawing.Point(85, 38);
            this.textE.Name = "textE";
            this.textE.Size = new System.Drawing.Size(81, 20);
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
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(401, 12);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.errorProvider.SetIconAlignment(this.dataGridView1, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(113, 342);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "a[i]";
            this.Column2.Name = "Column2";
            this.Column2.Width = 40;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listY);
            this.groupBox5.Controls.Add(this.listRoots);
            this.groupBox5.Location = new System.Drawing.Point(134, 226);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(366, 132);
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
            this.listY.Location = new System.Drawing.Point(179, 16);
            this.listY.Name = "listY";
            this.listY.Size = new System.Drawing.Size(184, 113);
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
            this.listRoots.Size = new System.Drawing.Size(170, 113);
            this.listRoots.TabIndex = 18;
            this.listRoots.SelectedIndexChanged += new System.EventHandler(this.ListsSync);
            // 
            // FormMain
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 366);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxFx);
            this.Controls.Add(label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Теория алгоритмов, лаб. 4";
            this.Load += new System.EventHandler(this.Form1_Load);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            this.groupInterval.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textE;
        private System.Windows.Forms.GroupBox groupInterval;
        private System.Windows.Forms.TextBox textBoxFx;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox listY;
        private System.Windows.Forms.ListBox listRoots;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textY1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textY2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textX1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textX2;
        private System.Windows.Forms.TextBox textBoxMaxN;
        private System.Windows.Forms.Label label6;

    }
}

