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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer));
			this.openFileDialogEmails = new System.Windows.Forms.OpenFileDialog();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetDoneTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.emptyEmailsDatabseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			label1 = new System.Windows.Forms.Label();
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).BeginInit();
			this.menuStrip1.SuspendLayout();
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
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.iewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(418, 24);
			this.menuStrip1.TabIndex = 15;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// actionToolStripMenuItem
			// 
			this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startAllToolStripMenuItem,
            this.stopAllToolStripMenuItem,
            this.serviceToolStripMenuItem});
			this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
			this.actionToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.actionToolStripMenuItem.Text = "&Action";
			// 
			// startAllToolStripMenuItem
			// 
			this.startAllToolStripMenuItem.Name = "startAllToolStripMenuItem";
			this.startAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.startAllToolStripMenuItem.Text = "&Start all";
			this.startAllToolStripMenuItem.Click += new System.EventHandler(this.buttonStartAll_Click);
			// 
			// stopAllToolStripMenuItem
			// 
			this.stopAllToolStripMenuItem.Name = "stopAllToolStripMenuItem";
			this.stopAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.stopAllToolStripMenuItem.Text = "Sto&p all";
			this.stopAllToolStripMenuItem.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// iewToolStripMenuItem
			// 
			this.iewToolStripMenuItem.Name = "iewToolStripMenuItem";
			this.iewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.iewToolStripMenuItem.Text = "&View";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.buttonOptions_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			// 
			// serviceToolStripMenuItem
			// 
			this.serviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetDoneTasksToolStripMenuItem,
            this.emptyEmailsDatabseToolStripMenuItem});
			this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
			this.serviceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.serviceToolStripMenuItem.Text = "Se&rvice";
			// 
			// resetDoneTasksToolStripMenuItem
			// 
			this.resetDoneTasksToolStripMenuItem.Name = "resetDoneTasksToolStripMenuItem";
			this.resetDoneTasksToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.resetDoneTasksToolStripMenuItem.Text = "Reset done tasks";
			this.resetDoneTasksToolStripMenuItem.Click += new System.EventHandler(this.ClearStates_Click);
			// 
			// emptyEmailsDatabseToolStripMenuItem
			// 
			this.emptyEmailsDatabseToolStripMenuItem.Name = "emptyEmailsDatabseToolStripMenuItem";
			this.emptyEmailsDatabseToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.emptyEmailsDatabseToolStripMenuItem.Text = "Empty e-mails databse";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabEmails);
			this.tabControl1.Controls.Add(this.tabMessages);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(418, 420);
			this.tabControl1.TabIndex = 16;
			// 
			// tabEmails
			// 
			this.tabEmails.Controls.Add(this.splitContainer2);
			this.tabEmails.Location = new System.Drawing.Point(4, 22);
			this.tabEmails.Name = "tabEmails";
			this.tabEmails.Padding = new System.Windows.Forms.Padding(3);
			this.tabEmails.Size = new System.Drawing.Size(410, 394);
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
			this.splitContainer2.Size = new System.Drawing.Size(404, 388);
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
			this.listEmails.Size = new System.Drawing.Size(305, 388);
			this.listEmails.TabIndex = 1;
			// 
			// textMsgID
			// 
			this.errorProvider.SetIconAlignment(this.textMsgID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.textMsgID.Location = new System.Drawing.Point(25, 91);
			this.textMsgID.Name = "textMsgID";
			this.textMsgID.Size = new System.Drawing.Size(60, 20);
			this.textMsgID.TabIndex = 3;
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
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(10, 117);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Set ID";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// buttonTab1Load
			// 
			this.buttonTab1Load.Location = new System.Drawing.Point(10, 17);
			this.buttonTab1Load.Name = "buttonTab1Load";
			this.buttonTab1Load.Size = new System.Drawing.Size(75, 23);
			this.buttonTab1Load.TabIndex = 0;
			this.buttonTab1Load.Text = "Load...";
			this.buttonTab1Load.UseVisualStyleBackColor = true;
			// 
			// tabMessages
			// 
			this.tabMessages.Controls.Add(this.splitContainer3);
			this.tabMessages.Location = new System.Drawing.Point(4, 22);
			this.tabMessages.Name = "tabMessages";
			this.tabMessages.Padding = new System.Windows.Forms.Padding(3);
			this.tabMessages.Size = new System.Drawing.Size(410, 394);
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
			this.splitContainer3.Size = new System.Drawing.Size(404, 388);
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
			this.listMessages.Size = new System.Drawing.Size(305, 388);
			this.listMessages.TabIndex = 1;
			// 
			// buttonTabMsgEdit
			// 
			this.buttonTabMsgEdit.Location = new System.Drawing.Point(10, 17);
			this.buttonTabMsgEdit.Name = "buttonTabMsgEdit";
			this.buttonTabMsgEdit.Size = new System.Drawing.Size(75, 23);
			this.buttonTabMsgEdit.TabIndex = 0;
			this.buttonTabMsgEdit.Text = "Edit...";
			this.buttonTabMsgEdit.UseVisualStyleBackColor = true;
			// 
			// FormServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 444);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(308, 83);
			this.Name = "FormServer";
			this.Opacity = 0;
			this.Text = "Server";
			this.Shown += new System.EventHandler(this.FormServer_Shown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
			this.Load += new System.EventHandler(this.FormServer_Load);
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialogEmails;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetDoneTasksToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem emptyEmailsDatabseToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabEmails;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListBox listEmails;
		private System.Windows.Forms.TextBox textMsgID;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonTab1Load;
		private System.Windows.Forms.TabPage tabMessages;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.ListBox listMessages;
		private System.Windows.Forms.Button buttonTabMsgEdit;

	}
}

