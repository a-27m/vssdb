namespace ServerApp
{
	partial class FormLetter
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textSubject = new System.Windows.Forms.TextBox();
			this.textBody = new System.Windows.Forms.TextBox();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.checkIsHtml = new System.Windows.Forms.CheckBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left ) ) );
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(15, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(46, 20);
			label1.TabIndex = 0;
			label1.Text = "Subject:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(15, 58);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(34, 13);
			label2.TabIndex = 1;
			label2.Text = "Body:";
			label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
			this.tableLayoutPanel1.Controls.Add(this.textSubject, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBody, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.buttonLoad, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.checkIsHtml, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.buttonOK, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 2, 7);
			this.tableLayoutPanel1.Controls.Add(label2, 1, 3);
			this.tableLayoutPanel1.Controls.Add(label1, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 9;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 306);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// textSubject
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.textSubject, 2);
			this.textSubject.Location = new System.Drawing.Point(15, 31);
			this.textSubject.Name = "textSubject";
			this.textSubject.Size = new System.Drawing.Size(162, 20);
			this.textSubject.TabIndex = 0;
			// 
			// textBody
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.textBody, 2);
			this.textBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBody.Location = new System.Drawing.Point(15, 81);
			this.textBody.Multiline = true;
			this.textBody.Name = "textBody";
			this.textBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBody.Size = new System.Drawing.Size(338, 139);
			this.textBody.TabIndex = 1;
			this.textBody.WordWrap = false;
			// 
			// buttonLoad
			// 
			this.buttonLoad.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.buttonLoad.Location = new System.Drawing.Point(278, 226);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(75, 23);
			this.buttonLoad.TabIndex = 3;
			this.buttonLoad.Text = "Load ...";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// checkIsHtml
			// 
			this.checkIsHtml.AutoSize = true;
			this.checkIsHtml.Checked = true;
			this.checkIsHtml.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkIsHtml.Location = new System.Drawing.Point(15, 226);
			this.checkIsHtml.Name = "checkIsHtml";
			this.checkIsHtml.Size = new System.Drawing.Size(83, 17);
			this.checkIsHtml.TabIndex = 2;
			this.checkIsHtml.Text = "It\'s in HTML";
			this.checkIsHtml.UseVisualStyleBackColor = true;
			this.checkIsHtml.CheckedChanged += new System.EventHandler(this.checkIsHtml_CheckedChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.buttonOK.Location = new System.Drawing.Point(106, 274);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 24);
			this.buttonOK.TabIndex = 4;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left ) ) );
			this.buttonCancel.Location = new System.Drawing.Point(187, 274);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 24);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "HTML files (*.htm; *.html)|*.htm;*.html|Text files (*.txt)|*.txt|All files (*.*)|" +
				"*.*";
			this.openFileDialog.ShowReadOnly = true;
			this.openFileDialog.Title = "Load content";
			// 
			// FormLetter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 306);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(200, 240);
			this.Name = "FormLetter";
			this.Text = "Message";
			this.Load += new System.EventHandler(this.FormLetter_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox textSubject;
		private System.Windows.Forms.TextBox textBody;
		private System.Windows.Forms.CheckBox checkIsHtml;
		private System.Windows.Forms.Button buttonLoad;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}