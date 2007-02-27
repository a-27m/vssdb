namespace ММИО_л1
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.CoefCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SignCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.numericUpDownM = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).BeginInit();
			this.groupBox1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.numericUpDownM ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.numericUpDownN ) ).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
			tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new System.Drawing.Size(424, 270);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoefCol0,
            this.SignCol});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(3, 69);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(418, 198);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
			// 
			// CoefCol0
			// 
			this.CoefCol0.HeaderText = "x";
			this.CoefCol0.Name = "CoefCol0";
			this.CoefCol0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.CoefCol0.Visible = false;
			// 
			// SignCol
			// 
			this.SignCol.HeaderText = "Знак";
			this.SignCol.Items.AddRange(new object[] {
            "≤",
            "=",
            "≥"});
			this.SignCol.MaxDropDownItems = 5;
			this.SignCol.Name = "SignCol";
			this.SignCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.SignCol.Visible = false;
			this.SignCol.Width = 50;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom ) ) );
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.numericUpDownM);
			this.groupBox1.Controls.Add(this.numericUpDownN);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(418, 60);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Размерность задачи";
			// 
			// button1
			// 
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(332, 23);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "OK";
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// numericUpDownM
			// 
			this.numericUpDownM.Location = new System.Drawing.Point(262, 26);
			this.numericUpDownM.Name = "numericUpDownM";
			this.numericUpDownM.Size = new System.Drawing.Size(52, 20);
			this.numericUpDownM.TabIndex = 3;
			// 
			// numericUpDownN
			// 
			this.numericUpDownN.Location = new System.Drawing.Point(105, 26);
			this.numericUpDownN.Name = "numericUpDownN";
			this.numericUpDownN.Size = new System.Drawing.Size(52, 20);
			this.numericUpDownN.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(163, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ограничений (m):";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Переменных (n):";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 270);
			this.Controls.Add(tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(432, 150);
			this.Name = "Form1";
			this.Text = "ММИО л1";
			tableLayoutPanel1.ResumeLayout(false);
			( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.numericUpDownM ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.numericUpDownN ) ).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn CoefCol0;
		private System.Windows.Forms.DataGridViewComboBoxColumn SignCol;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numericUpDownM;
		private System.Windows.Forms.NumericUpDown numericUpDownN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
	}
}

