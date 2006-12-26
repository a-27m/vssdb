namespace Lab2
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
			if ( disposing && ( components != null ) )
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.GroupBox groupBox1;
            this.buttonProcess = new System.Windows.Forms.Button();
            this.textIn = new System.Windows.Forms.TextBox();
            this.textOut = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Step = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RCh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.Controls.Add(this.buttonProcess, 3, 2);
            tableLayoutPanel1.Controls.Add(this.textIn, 1, 2);
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 1, 3);
            tableLayoutPanel1.Controls.Add(this.textOut, 1, 4);
            tableLayoutPanel1.Controls.Add(groupBox1, 1, 5);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.Size = new System.Drawing.Size(451, 426);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcess.Location = new System.Drawing.Point(356, 31);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(84, 24);
            this.buttonProcess.TabIndex = 1;
            this.buttonProcess.Text = "Обработать";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // textIn
            // 
            this.textIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.textIn.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIn.Location = new System.Drawing.Point(11, 31);
            this.textIn.Name = "textIn";
            this.textIn.Size = new System.Drawing.Size(329, 20);
            this.textIn.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(158, 13);
            label1.TabIndex = 3;
            label1.Text = "Входная последовательность";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 65);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(115, 13);
            label2.TabIndex = 4;
            label2.Text = "Числовая константа:";
            // 
            // textOut
            // 
            tableLayoutPanel1.SetColumnSpan(this.textOut, 3);
            this.textOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.textOut.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOut.Location = new System.Drawing.Point(11, 81);
            this.textOut.Name = "textOut";
            this.textOut.ReadOnly = true;
            this.textOut.Size = new System.Drawing.Size(429, 20);
            this.textOut.TabIndex = 2;
            // 
            // groupBox1
            // 
            tableLayoutPanel1.SetColumnSpan(groupBox1, 3);
            groupBox1.Controls.Add(this.dataGridView1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(11, 111);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(429, 304);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Регистры";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Step,
            this.Symbol,
            this.RCh,
            this.RP,
            this.RS,
            this.RZ,
            this.State});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(423, 285);
            this.dataGridView1.TabIndex = 0;
            // 
            // Step
            // 
            this.Step.HeaderText = "Шаг";
            this.Step.Name = "Step";
            this.Step.ReadOnly = true;
            this.Step.Width = 50;
            // 
            // Symbol
            // 
            this.Symbol.HeaderText = "Символ";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            this.Symbol.Width = 69;
            // 
            // RCh
            // 
            this.RCh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RCh.HeaderText = "РЧ";
            this.RCh.Name = "RCh";
            this.RCh.ReadOnly = true;
            this.RCh.Width = 45;
            // 
            // RP
            // 
            this.RP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RP.HeaderText = "РП";
            this.RP.Name = "RP";
            this.RP.ReadOnly = true;
            this.RP.Width = 45;
            // 
            // RS
            // 
            this.RS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RS.HeaderText = "РС";
            this.RS.Name = "RS";
            this.RS.ReadOnly = true;
            this.RS.Width = 44;
            // 
            // RZ
            // 
            this.RZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.RZ.HeaderText = "РЗ";
            this.RZ.Name = "RZ";
            this.RZ.ReadOnly = true;
            this.RZ.Width = 44;
            // 
            // State
            // 
            this.State.HeaderText = "Состояние";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 84;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonProcess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 426);
            this.Controls.Add(tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(296, 150);
            this.Name = "FormMain";
            this.Text = "ТОПТ: лаб. 2, \"Обработка числовых констант\"";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textIn;
		private System.Windows.Forms.Button buttonProcess;
		private System.Windows.Forms.TextBox textOut;
		private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Step;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RCh;
        private System.Windows.Forms.DataGridViewTextBoxColumn RP;
        private System.Windows.Forms.DataGridViewTextBoxColumn RS;
        private System.Windows.Forms.DataGridViewTextBoxColumn RZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
	}
}

