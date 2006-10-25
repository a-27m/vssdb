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
			System.Windows.Forms.SplitContainer splitContainer1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer));
			System.Windows.Forms.SplitContainer splitContainer2;
			System.Windows.Forms.GroupBox groupBox1;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			this.listBoxMessages = new System.Windows.Forms.ListBox();
			this.buttonMessageAdd = new System.Windows.Forms.Button();
			this.buttonMessageRemove = new System.Windows.Forms.Button();
			this.buttonMessageView = new System.Windows.Forms.Button();
			this.listBoxRobots = new System.Windows.Forms.ListBox();
			this.buttonRobotAdd = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.checkPassHide = new System.Windows.Forms.CheckBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textRobotSmtpHost = new System.Windows.Forms.TextBox();
			this.buttonRobotSmtpDef = new System.Windows.Forms.Button();
			this.buttonRobotSmtpSet = new System.Windows.Forms.Button();
			this.buttonRobotLoad = new System.Windows.Forms.Button();
			this.buttonRobotRemove = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabEmails = new System.Windows.Forms.TabPage();
			this.tabMessages = new System.Windows.Forms.TabPage();
			this.tabRobots = new System.Windows.Forms.TabPage();
			this.tabCommon = new System.Windows.Forms.TabPage();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			splitContainer2 = new System.Windows.Forms.SplitContainer();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			groupBox1.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabMessages.SuspendLayout();
			this.tabRobots.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			splitContainer1.IsSplitterFixed = true;
			splitContainer1.Location = new System.Drawing.Point(3, 3);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(this.listBoxMessages);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(this.buttonMessageAdd);
			splitContainer1.Panel2.Controls.Add(this.buttonMessageRemove);
			splitContainer1.Panel2.Controls.Add(this.buttonMessageView);
			splitContainer1.Size = new System.Drawing.Size(473, 311);
			splitContainer1.SplitterDistance = 379;
			splitContainer1.TabIndex = 0;
			// 
			// listBoxMessages
			// 
			this.listBoxMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxMessages.FormattingEnabled = true;
			this.listBoxMessages.HorizontalScrollbar = true;
			this.listBoxMessages.IntegralHeight = false;
			this.listBoxMessages.Location = new System.Drawing.Point(0, 0);
			this.listBoxMessages.Name = "listBoxMessages";
			this.listBoxMessages.ScrollAlwaysVisible = true;
			this.listBoxMessages.Size = new System.Drawing.Size(379, 311);
			this.listBoxMessages.TabIndex = 0;
			// 
			// buttonMessageAdd
			// 
			this.buttonMessageAdd.Image = ( (System.Drawing.Image)( resources.GetObject("buttonMessageAdd.Image") ) );
			this.buttonMessageAdd.Location = new System.Drawing.Point(8, 17);
			this.buttonMessageAdd.Name = "buttonMessageAdd";
			this.buttonMessageAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonMessageAdd.TabIndex = 0;
			this.buttonMessageAdd.Text = "Add";
			this.buttonMessageAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonMessageAdd.UseVisualStyleBackColor = true;
			// 
			// buttonMessageRemove
			// 
			this.buttonMessageRemove.Image = ( (System.Drawing.Image)( resources.GetObject("buttonMessageRemove.Image") ) );
			this.buttonMessageRemove.Location = new System.Drawing.Point(8, 46);
			this.buttonMessageRemove.Name = "buttonMessageRemove";
			this.buttonMessageRemove.Size = new System.Drawing.Size(75, 23);
			this.buttonMessageRemove.TabIndex = 1;
			this.buttonMessageRemove.Text = "Remove";
			this.buttonMessageRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonMessageRemove.UseVisualStyleBackColor = true;
			// 
			// buttonMessageView
			// 
			this.buttonMessageView.Location = new System.Drawing.Point(8, 86);
			this.buttonMessageView.Name = "buttonMessageView";
			this.buttonMessageView.Size = new System.Drawing.Size(75, 23);
			this.buttonMessageView.TabIndex = 2;
			this.buttonMessageView.Text = "View";
			this.buttonMessageView.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			splitContainer2.IsSplitterFixed = true;
			splitContainer2.Location = new System.Drawing.Point(3, 3);
			splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(this.listBoxRobots);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(this.buttonRobotAdd);
			splitContainer2.Panel2.Controls.Add(groupBox1);
			splitContainer2.Panel2.Controls.Add(this.buttonRobotLoad);
			splitContainer2.Panel2.Controls.Add(this.buttonRobotRemove);
			splitContainer2.Size = new System.Drawing.Size(473, 311);
			splitContainer2.SplitterDistance = 270;
			splitContainer2.TabIndex = 1;
			// 
			// listBoxRobots
			// 
			this.listBoxRobots.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxRobots.FormattingEnabled = true;
			this.listBoxRobots.HorizontalExtent = 20;
			this.listBoxRobots.HorizontalScrollbar = true;
			this.listBoxRobots.IntegralHeight = false;
			this.listBoxRobots.Location = new System.Drawing.Point(0, 0);
			this.listBoxRobots.MultiColumn = true;
			this.listBoxRobots.Name = "listBoxRobots";
			this.listBoxRobots.ScrollAlwaysVisible = true;
			this.listBoxRobots.Size = new System.Drawing.Size(270, 311);
			this.listBoxRobots.TabIndex = 0;
			// 
			// buttonRobotAdd
			// 
			this.buttonRobotAdd.Image = ( (System.Drawing.Image)( resources.GetObject("buttonRobotAdd.Image") ) );
			this.buttonRobotAdd.Location = new System.Drawing.Point(18, 19);
			this.buttonRobotAdd.Name = "buttonRobotAdd";
			this.buttonRobotAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonRobotAdd.TabIndex = 7;
			this.buttonRobotAdd.Text = "Add";
			this.buttonRobotAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRobotAdd.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(this.textBox5);
			groupBox1.Controls.Add(this.checkPassHide);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(this.textBox4);
			groupBox1.Controls.Add(this.textBox3);
			groupBox1.Controls.Add(this.textBox2);
			groupBox1.Controls.Add(this.textRobotSmtpHost);
			groupBox1.Controls.Add(this.buttonRobotSmtpDef);
			groupBox1.Controls.Add(this.buttonRobotSmtpSet);
			groupBox1.Location = new System.Drawing.Point(3, 93);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(191, 213);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "SMTP";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(7, 138);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 13);
			label5.TabIndex = 12;
			label5.Text = "From (name):";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(81, 135);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 11;
			// 
			// checkPassHide
			// 
			this.checkPassHide.AutoSize = true;
			this.checkPassHide.Checked = true;
			this.checkPassHide.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkPassHide.Location = new System.Drawing.Point(89, 112);
			this.checkPassHide.Name = "checkPassHide";
			this.checkPassHide.Size = new System.Drawing.Size(84, 17);
			this.checkPassHide.TabIndex = 10;
			this.checkPassHide.Text = "Show typing";
			this.checkPassHide.UseVisualStyleBackColor = true;
			this.checkPassHide.Visible = false;
			this.checkPassHide.CheckedChanged += new System.EventHandler(this.checkPassHide_CheckedChanged);
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(19, 100);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(56, 13);
			label4.TabIndex = 9;
			label4.Text = "Password:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(39, 74);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(36, 13);
			label3.TabIndex = 8;
			label3.Text = "Login:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(46, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(29, 13);
			label2.TabIndex = 7;
			label2.Text = "Port:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(34, 22);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 13);
			label1.TabIndex = 6;
			label1.Text = "Server:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(81, 97);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 5;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(81, 71);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 4;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(81, 45);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 3;
			// 
			// textRobotSmtpHost
			// 
			this.textRobotSmtpHost.Location = new System.Drawing.Point(81, 19);
			this.textRobotSmtpHost.Name = "textRobotSmtpHost";
			this.textRobotSmtpHost.Size = new System.Drawing.Size(100, 20);
			this.textRobotSmtpHost.TabIndex = 2;
			// 
			// buttonRobotSmtpDef
			// 
			this.buttonRobotSmtpDef.Location = new System.Drawing.Point(98, 184);
			this.buttonRobotSmtpDef.Name = "buttonRobotSmtpDef";
			this.buttonRobotSmtpDef.Size = new System.Drawing.Size(75, 23);
			this.buttonRobotSmtpDef.TabIndex = 1;
			this.buttonRobotSmtpDef.Text = "Default";
			this.buttonRobotSmtpDef.UseVisualStyleBackColor = true;
			// 
			// buttonRobotSmtpSet
			// 
			this.buttonRobotSmtpSet.Location = new System.Drawing.Point(17, 184);
			this.buttonRobotSmtpSet.Name = "buttonRobotSmtpSet";
			this.buttonRobotSmtpSet.Size = new System.Drawing.Size(75, 23);
			this.buttonRobotSmtpSet.TabIndex = 0;
			this.buttonRobotSmtpSet.Text = "Set";
			this.buttonRobotSmtpSet.UseVisualStyleBackColor = true;
			// 
			// buttonRobotLoad
			// 
			this.buttonRobotLoad.Location = new System.Drawing.Point(106, 19);
			this.buttonRobotLoad.Name = "buttonRobotLoad";
			this.buttonRobotLoad.Size = new System.Drawing.Size(75, 23);
			this.buttonRobotLoad.TabIndex = 3;
			this.buttonRobotLoad.Text = "Load ...";
			this.buttonRobotLoad.UseVisualStyleBackColor = true;
			// 
			// buttonRobotRemove
			// 
			this.buttonRobotRemove.Image = ( (System.Drawing.Image)( resources.GetObject("buttonRobotRemove.Image") ) );
			this.buttonRobotRemove.Location = new System.Drawing.Point(18, 48);
			this.buttonRobotRemove.Name = "buttonRobotRemove";
			this.buttonRobotRemove.Size = new System.Drawing.Size(75, 23);
			this.buttonRobotRemove.TabIndex = 4;
			this.buttonRobotRemove.Text = "Remove";
			this.buttonRobotRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRobotRemove.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(487, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Location = new System.Drawing.Point(5, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(111, 25);
			this.toolStrip1.TabIndex = 11;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(487, 343);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(487, 368);
			this.toolStripContainer1.TabIndex = 12;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabEmails);
			this.tabControl.Controls.Add(this.tabMessages);
			this.tabControl.Controls.Add(this.tabRobots);
			this.tabControl.Controls.Add(this.tabCommon);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(487, 343);
			this.tabControl.TabIndex = 0;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabEmails
			// 
			this.tabEmails.Location = new System.Drawing.Point(4, 22);
			this.tabEmails.Name = "tabEmails";
			this.tabEmails.Padding = new System.Windows.Forms.Padding(3);
			this.tabEmails.Size = new System.Drawing.Size(479, 317);
			this.tabEmails.TabIndex = 2;
			this.tabEmails.Text = "Emails";
			this.tabEmails.UseVisualStyleBackColor = true;
			// 
			// tabMessages
			// 
			this.tabMessages.Controls.Add(splitContainer1);
			this.tabMessages.Location = new System.Drawing.Point(4, 22);
			this.tabMessages.Name = "tabMessages";
			this.tabMessages.Padding = new System.Windows.Forms.Padding(3);
			this.tabMessages.Size = new System.Drawing.Size(479, 317);
			this.tabMessages.TabIndex = 0;
			this.tabMessages.Text = "Messages";
			this.tabMessages.UseVisualStyleBackColor = true;
			// 
			// tabRobots
			// 
			this.tabRobots.Controls.Add(splitContainer2);
			this.tabRobots.Location = new System.Drawing.Point(4, 22);
			this.tabRobots.Name = "tabRobots";
			this.tabRobots.Padding = new System.Windows.Forms.Padding(3);
			this.tabRobots.Size = new System.Drawing.Size(479, 317);
			this.tabRobots.TabIndex = 1;
			this.tabRobots.Text = "Robots";
			this.tabRobots.UseVisualStyleBackColor = true;
			// 
			// tabCommon
			// 
			this.tabCommon.Location = new System.Drawing.Point(4, 22);
			this.tabCommon.Name = "tabCommon";
			this.tabCommon.Size = new System.Drawing.Size(479, 317);
			this.tabCommon.TabIndex = 3;
			this.tabCommon.Text = "Common";
			this.tabCommon.UseVisualStyleBackColor = true;
			// 
			// FormServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(487, 392);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "FormServer";
			this.Text = "Server";
			this.Load += new System.EventHandler(this.FormServer_Load);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel2.ResumeLayout(false);
			splitContainer2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabMessages.ResumeLayout(false);
			this.tabRobots.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabMessages;
		private System.Windows.Forms.ListBox listBoxMessages;
		private System.Windows.Forms.Button buttonMessageAdd;
		private System.Windows.Forms.TabPage tabRobots;
		private System.Windows.Forms.TabPage tabEmails;
		private System.Windows.Forms.TabPage tabCommon;
		private System.Windows.Forms.Button buttonMessageView;
		private System.Windows.Forms.Button buttonMessageRemove;
		private System.Windows.Forms.ListBox listBoxRobots;
		private System.Windows.Forms.Button buttonRobotLoad;
		private System.Windows.Forms.Button buttonRobotRemove;
		private System.Windows.Forms.CheckBox checkPassHide;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textRobotSmtpHost;
		private System.Windows.Forms.Button buttonRobotSmtpDef;
		private System.Windows.Forms.Button buttonRobotSmtpSet;
		private System.Windows.Forms.Button buttonRobotAdd;
		private System.Windows.Forms.TextBox textBox5;
	}
}

