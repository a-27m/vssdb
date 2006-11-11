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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label label1;
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.buttonOptions = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabEmails = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.listEmails = new System.Windows.Forms.ListBox();
			this.textMsgID = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.buttonTab1Load = new System.Windows.Forms.Button();
			this.tabMessages = new System.Windows.Forms.TabPage();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.listMessages = new System.Windows.Forms.ListBox();
			this.buttonTabMsgEdit = new System.Windows.Forms.Button();
			this.openFileDialogEmails = new System.Windows.Forms.OpenFileDialog();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.buttonStop = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
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
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(7, 75);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(67, 13);
			label1.TabIndex = 2;
			label1.Text = "Message ID:";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(13, 16);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 11;
			this.buttonStart.Text = "Start all";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStartAll_Click);
			// 
			// buttonReset
			// 
			this.buttonReset.Location = new System.Drawing.Point(197, 16);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(115, 23);
			this.buttonReset.TabIndex = 12;
			this.buttonReset.Text = "Reset done tasks";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.ClearStates_Click);
			// 
			// buttonOptions
			// 
			this.buttonOptions.Location = new System.Drawing.Point(318, 16);
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
			this.splitContainer1.Panel1.Controls.Add(this.buttonStop);
			this.splitContainer1.Panel1.Controls.Add(this.buttonStart);
			this.splitContainer1.Panel1.Controls.Add(this.buttonOptions);
			this.splitContainer1.Panel1.Controls.Add(this.buttonReset);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Size = new System.Drawing.Size(418, 444);
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
			this.tabControl1.Size = new System.Drawing.Size(418, 389);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabEmails
			// 
			this.tabEmails.Controls.Add(this.splitContainer2);
			this.tabEmails.Location = new System.Drawing.Point(4, 22);
			this.tabEmails.Name = "tabEmails";
			this.tabEmails.Padding = new System.Windows.Forms.Padding(3);
			this.tabEmails.Size = new System.Drawing.Size(410, 363);
			this.tabEmails.TabIndex = 0;
			this.tabEmails.Text = "E-mails";
			this.tabEmails.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.listEmails);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.textMsgID);
			this.splitContainer2.Panel2.Controls.Add(label1);
			this.splitContainer2.Panel2.Controls.Add(this.button1);
			this.splitContainer2.Panel2.Controls.Add(this.buttonTab1Load);
			this.splitContainer2.Size = new System.Drawing.Size(404, 357);
			this.splitContainer2.SplitterDistance = 305;
			this.splitContainer2.TabIndex = 2;
			// 
			// listEmails
			// 
			this.listEmails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listEmails.FormattingEnabled = true;
			this.listEmails.IntegralHeight = false;
			this.listEmails.Location = new System.Drawing.Point(0, 0);
			this.listEmails.Name = "listEmails";
			this.listEmails.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listEmails.Size = new System.Drawing.Size(305, 357);
			this.listEmails.TabIndex = 1;
			this.listEmails.SelectedIndexChanged += new System.EventHandler(this.tabEmails_listEmails_SelectedIndexChanged);
			// 
			// textMsgID
			// 
			this.errorProvider.SetIconAlignment(this.textMsgID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.textMsgID.Location = new System.Drawing.Point(25, 91);
			this.textMsgID.Name = "textMsgID";
			this.textMsgID.Size = new System.Drawing.Size(60, 20);
			this.textMsgID.TabIndex = 3;
			this.textMsgID.TextChanged += new System.EventHandler(this.tabEmails_textMsgID_TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(10, 117);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Set ID";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.tabEmails_buttonSet_Click);
			// 
			// buttonTab1Load
			// 
			this.buttonTab1Load.Location = new System.Drawing.Point(10, 17);
			this.buttonTab1Load.Name = "buttonTab1Load";
			this.buttonTab1Load.Size = new System.Drawing.Size(75, 23);
			this.buttonTab1Load.TabIndex = 0;
			this.buttonTab1Load.Text = "Load…";
			this.buttonTab1Load.UseVisualStyleBackColor = true;
			this.buttonTab1Load.Click += new System.EventHandler(this.tabEmails_buttonLoad_Click);
			// 
			// tabMessages
			// 
			this.tabMessages.Controls.Add(this.splitContainer3);
			this.tabMessages.Location = new System.Drawing.Point(4, 22);
			this.tabMessages.Name = "tabMessages";
			this.tabMessages.Padding = new System.Windows.Forms.Padding(3);
			this.tabMessages.Size = new System.Drawing.Size(410, 363);
			this.tabMessages.TabIndex = 1;
			this.tabMessages.Text = "Messages";
			this.tabMessages.UseVisualStyleBackColor = true;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer3.IsSplitterFixed = true;
			this.splitContainer3.Location = new System.Drawing.Point(3, 3);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.listMessages);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.buttonTabMsgEdit);
			this.splitContainer3.Size = new System.Drawing.Size(404, 357);
			this.splitContainer3.SplitterDistance = 305;
			this.splitContainer3.TabIndex = 3;
			// 
			// listMessages
			// 
			this.listMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listMessages.FormattingEnabled = true;
			this.listMessages.IntegralHeight = false;
			this.listMessages.Location = new System.Drawing.Point(0, 0);
			this.listMessages.Name = "listMessages";
			this.listMessages.Size = new System.Drawing.Size(305, 357);
			this.listMessages.TabIndex = 1;
			// 
			// buttonTabMsgEdit
			// 
			this.buttonTabMsgEdit.Location = new System.Drawing.Point(10, 17);
			this.buttonTabMsgEdit.Name = "buttonTabMsgEdit";
			this.buttonTabMsgEdit.Size = new System.Drawing.Size(75, 23);
			this.buttonTabMsgEdit.TabIndex = 0;
			this.buttonTabMsgEdit.Text = "Edit…";
			this.buttonTabMsgEdit.UseVisualStyleBackColor = true;
			this.buttonTabMsgEdit.Click += new System.EventHandler(this.tabMsg_buttonEdit_Click);
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
			// errorProvider
			// 
			this.errorProvider.BlinkRate = 120;
			this.errorProvider.ContainerControl = this.splitContainer3;
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(94, 16);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 14;
			this.buttonStop.Text = "Stop all";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// FormServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 444);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(308, 83);
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
			this.splitContainer2.Panel2.PerformLayout();
			this.splitContainer2.ResumeLayout(false);
			this.tabMessages.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.ResumeLayout(false);
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).EndInit();
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
		private System.Windows.Forms.TextBox textMsgID;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Button buttonStop;

	}
}

