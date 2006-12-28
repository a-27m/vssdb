namespace Lab1
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
			System.Windows.Forms.GroupBox groupBox1;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			this.listIdentificators = new System.Windows.Forms.ListBox();
			this.listNumbers = new System.Windows.Forms.ListBox();
			this.listSigns = new System.Windows.Forms.ListBox();
			this.buttonProcess = new System.Windows.Forms.Button();
			this.textIn = new System.Windows.Forms.TextBox();
			this.textOut = new System.Windows.Forms.TextBox();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			groupBox1 = new System.Windows.Forms.GroupBox();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			tableLayoutPanel1.SuspendLayout();
			groupBox1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
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
			tableLayoutPanel1.Controls.Add(groupBox1, 1, 3);
			tableLayoutPanel1.Controls.Add(this.buttonProcess, 3, 2);
			tableLayoutPanel1.Controls.Add(this.textIn, 1, 2);
			tableLayoutPanel1.Controls.Add(this.textOut, 1, 5);
			tableLayoutPanel1.Controls.Add(label1, 1, 1);
			tableLayoutPanel1.Controls.Add(label2, 1, 4);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 7;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			tableLayoutPanel1.Size = new System.Drawing.Size(409, 331);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			tableLayoutPanel1.SetColumnSpan(groupBox1, 3);
			groupBox1.Controls.Add(tableLayoutPanel2);
			groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			groupBox1.Location = new System.Drawing.Point(11, 61);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(387, 209);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Группы";
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 5;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			tableLayoutPanel2.Controls.Add(this.listIdentificators, 0, 1);
			tableLayoutPanel2.Controls.Add(this.listNumbers, 2, 1);
			tableLayoutPanel2.Controls.Add(this.listSigns, 4, 1);
			tableLayoutPanel2.Controls.Add(label3, 0, 0);
			tableLayoutPanel2.Controls.Add(label4, 2, 0);
			tableLayoutPanel2.Controls.Add(label5, 4, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 2;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel2.Size = new System.Drawing.Size(381, 190);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// listIdentificators
			// 
			this.listIdentificators.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listIdentificators.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.listIdentificators.FormattingEnabled = true;
			this.listIdentificators.IntegralHeight = false;
			this.listIdentificators.ItemHeight = 14;
			this.listIdentificators.Location = new System.Drawing.Point(3, 23);
			this.listIdentificators.Name = "listIdentificators";
			this.listIdentificators.Size = new System.Drawing.Size(115, 164);
			this.listIdentificators.TabIndex = 0;
			// 
			// listNumbers
			// 
			this.listNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listNumbers.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.listNumbers.FormattingEnabled = true;
			this.listNumbers.IntegralHeight = false;
			this.listNumbers.ItemHeight = 14;
			this.listNumbers.Location = new System.Drawing.Point(132, 23);
			this.listNumbers.Name = "listNumbers";
			this.listNumbers.Size = new System.Drawing.Size(115, 164);
			this.listNumbers.TabIndex = 1;
			// 
			// listSigns
			// 
			this.listSigns.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listSigns.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.listSigns.FormattingEnabled = true;
			this.listSigns.IntegralHeight = false;
			this.listSigns.ItemHeight = 14;
			this.listSigns.Location = new System.Drawing.Point(261, 23);
			this.listSigns.Name = "listSigns";
			this.listSigns.Size = new System.Drawing.Size(117, 164);
			this.listSigns.TabIndex = 2;
			// 
			// label3
			// 
			label3.Dock = System.Windows.Forms.DockStyle.Fill;
			label3.Location = new System.Drawing.Point(3, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(115, 20);
			label3.TabIndex = 3;
			label3.Text = "Идентификаторы";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			label4.Dock = System.Windows.Forms.DockStyle.Fill;
			label4.Location = new System.Drawing.Point(132, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(115, 20);
			label4.TabIndex = 4;
			label4.Text = "Числа";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			label5.Dock = System.Windows.Forms.DockStyle.Fill;
			label5.Location = new System.Drawing.Point(261, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(117, 20);
			label5.TabIndex = 5;
			label5.Text = "Другие";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonProcess
			// 
			this.buttonProcess.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.buttonProcess.Location = new System.Drawing.Point(314, 31);
			this.buttonProcess.Name = "buttonProcess";
			this.buttonProcess.Size = new System.Drawing.Size(84, 24);
			this.buttonProcess.TabIndex = 2;
			this.buttonProcess.Text = "Обработать";
			this.buttonProcess.UseVisualStyleBackColor = true;
			this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
			// 
			// textIn
			// 
			this.textIn.Dock = System.Windows.Forms.DockStyle.Top;
			this.textIn.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.textIn.Location = new System.Drawing.Point(11, 31);
			this.textIn.Name = "textIn";
			this.textIn.Size = new System.Drawing.Size(287, 20);
			this.textIn.TabIndex = 1;
			// 
			// textOut
			// 
			tableLayoutPanel1.SetColumnSpan(this.textOut, 3);
			this.textOut.Dock = System.Windows.Forms.DockStyle.Top;
			this.textOut.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.textOut.Location = new System.Drawing.Point(11, 296);
			this.textOut.Name = "textOut";
			this.textOut.ReadOnly = true;
			this.textOut.Size = new System.Drawing.Size(387, 20);
			this.textOut.TabIndex = 1;
			// 
			// label1
			// 
			label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(11, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(158, 13);
			label1.TabIndex = 3;
			label1.Text = "Входная последовательность";
			// 
			// label2
			// 
			label2.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(11, 280);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(166, 13);
			label2.TabIndex = 4;
			label2.Text = "Выходная последовательность";
			// 
			// FormMain
			// 
			this.AcceptButton = this.buttonProcess;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(409, 331);
			this.Controls.Add(tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(296, 150);
			this.Name = "FormMain";
			this.Text = "ТОПТ: лабораторная 1, \"Транслитерация\"";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			groupBox1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textIn;
		private System.Windows.Forms.Button buttonProcess;
		private System.Windows.Forms.TextBox textOut;
		private System.Windows.Forms.ListBox listIdentificators;
		private System.Windows.Forms.ListBox listNumbers;
		private System.Windows.Forms.ListBox listSigns;
	}
}

