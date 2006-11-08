namespace ServerApp
{
	partial class FormServer
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
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.buttonOptions = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabEmails = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.listEmails = new System.Windows.Forms.ListBox();
			this.buttonTab1Load = new System.Windows.Forms.Button();
			this.openFileDialogEmails = new System.Windows.Forms.OpenFileDialog();
			this.tabMessages = new System.Windows.Forms.TabPage();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.listMessages = new System.Windows.Forms.ListBox();
			this.buttonTabMsgEdit = new System.Windows.Forms.Button();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabEmails.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabMessages.SuspendLayout();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(13, 16);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 11;
			this.buttonStart.Text = "Start all";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.StartAll_Click);
			// 
			// buttonReset
			// 
			this.buttonReset.Location = new System.Drawing.Point(94, 16);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(115, 23);
			this.buttonReset.TabIndex = 12;
			this.buttonReset.Text = "Reset done tasks";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.ClearStates_Click);
			// 
			// buttonOptions
			// 
			this.buttonOptions.Location = new System.Drawing.Point(215, 16);
			this.buttonOptions.Name = "buttonOptions";
			this.buttonOptions.Size = new System.Drawing.Size(75, 23);
			this.buttonOptions.TabIndex = 13;
			this.buttonOptions.Text = "Options";
			this.buttonOptions.UseVisualStyleBackColor = true;
			this.buttonOptions.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.buttonStart);
			this.splitContainer1.Panel1.Controls.Add(this.buttonOptions);
			this.splitContainer1.Panel1.Controls.Add(this.buttonReset);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Size = new System.Drawing.Size(339, 407);
			this.splitContainer1.SplitterDistance = 51;
			this.splitContainer1.TabIndex = 14;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabEmails);
			this.tabControl1.Controls.Add(this.tabMessages);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(339, 352);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabEmails
			// 
			this.tabEmails.Controls.Add(this.splitContainer2);
			this.tabEmails.Location = new System.Drawing.Point(4, 22);
			this.tabEmails.Name = "tabEmails";
			this.tabEmails.Padding = new System.Windows.Forms.Padding(3);
			this.tabEmails.Size = new System.Drawing.Size(331, 326);
			this.tabEmails.TabIndex = 0;
			this.tabEmails.Text = "E-mails";
			this.tabEmails.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.listEmails);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.buttonTab1Load);
			this.splitContainer2.Size = new System.Drawing.Size(325, 320);
			this.splitContainer2.SplitterDistance = 240;
			this.splitContainer2.TabIndex = 2;
			// 
			// listEmails
			// 
			this.listEmails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listEmails.FormattingEnabled = true;
			this.listEmails.IntegralHeight = false;
			this.listEmails.Location = new System.Drawing.Point(0, 0);
			this.listEmails.Name = "listEmails";
			this.listEmails.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.listEmails.Size = new System.Drawing.Size(240, 320);
			this.listEmails.TabIndex = 1;
			// 
			// buttonTab1Load
			// 
			this.buttonTab1Load.Location = new System.Drawing.Point(3, 3);
			this.buttonTab1Load.Name = "buttonTab1Load";
			this.buttonTab1Load.Size = new System.Drawing.Size(75, 23);
			this.buttonTab1Load.TabIndex = 0;
			this.buttonTab1Load.Text = "Load…";
			this.buttonTab1Load.UseVisualStyleBackColor = true;
			this.buttonTab1Load.Click += new System.EventHandler(this.buttonTab1Load_Click);
			// 
			// openFileDialogEmails
			// 
			this.openFileDialogEmails.DefaultExt = "txt";
			this.openFileDialogEmails.FileName = "base";
			this.openFileDialogEmails.Filter = "Text files (*.txt)|*.txt|CSV - files (*.csv)|*.csv|All files (*.*)|*.*";
			this.openFileDialogEmails.ShowReadOnly = true;
			this.openFileDialogEmails.SupportMultiDottedExtensions = true;
			this.openFileDialogEmails.Title = "Select files containing e-mails list";
			// 
			// tabMessages
			// 
			this.tabMessages.Controls.Add(this.splitContainer3);
			this.tabMessages.Location = new System.Drawing.Point(4, 22);
			this.tabMessages.Name = "tabMessages";
			this.tabMessages.Padding = new System.Windows.Forms.Padding(3);
			this.tabMessages.Size = new System.Drawing.Size(331, 326);
			this.tabMessages.TabIndex = 1;
			this.tabMessages.Text = "Messages";
			this.tabMessages.UseVisualStyleBackColor = true;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(3, 3);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.listMessages);
			// 
			// 
			// 
			this.splitContainer3.Panel2.Controls.Add(this.buttonTabMsgEdit);
			this.splitContainer3.Size = new System.Drawing.Size(325, 320);
			this.splitContainer3.SplitterDistance = 240;
			this.splitContainer3.TabIndex = 3;
			// 
			// listMessages
			// 
			this.listMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listMessages.FormattingEnabled = true;
			this.listMessages.IntegralHeight = false;
			this.listMessages.Location = new System.Drawing.Point(0, 0);
			this.listMessages.Name = "listMessages";
			this.listMessages.Size = new System.Drawing.Size(240, 320);
			this.listMessages.TabIndex = 1;
			// 
			// buttonTabMsgEdit
			// 
			this.buttonTabMsgEdit.Location = new System.Drawing.Point(3, 3);
			this.buttonTabMsgEdit.Name = "buttonTabMsgEdit";
			this.buttonTabMsgEdit.Size = new System.Drawing.Size(75, 23);
			this.buttonTabMsgEdit.TabIndex = 0;
			this.buttonTabMsgEdit.Text = "Edit…";
			this.buttonTabMsgEdit.UseVisualStyleBackColor = true;
			this.buttonTabMsgEdit.Click += new System.EventHandler(this.buttonTabMsgEdit_Click);
			// 
			// FormServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 407);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "FormServer";
			this.Text = "Server";
			this.Load += new System.EventHandler(this.FormServer_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabEmails.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.tabMessages.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.Button buttonOptions;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabEmails;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListBox listEmails;
		private System.Windows.Forms.Button buttonTab1Load;
		private System.Windows.Forms.OpenFileDialog openFileDialogEmails;
		private System.Windows.Forms.TabPage tabMessages;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.ListBox listMessages;
		private System.Windows.Forms.Button buttonTabMsgEdit;

	}
}

