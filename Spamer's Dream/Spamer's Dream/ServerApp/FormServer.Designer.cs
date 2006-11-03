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
			System.Windows.Forms.SplitContainer splitContainer2;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.GroupBox groupBox1;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer));
			this.listBoxRobots = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.buttonRobotSmtpDef = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textRobotSmtpHost = new System.Windows.Forms.TextBox();
			this.buttonRobotSmtpSet = new System.Windows.Forms.Button();
			this.listBoxMessages = new System.Windows.Forms.ListBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStart = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabEmails = new System.Windows.Forms.TabPage();
			this.tabMessages = new System.Windows.Forms.TabPage();
			this.dataGridMessages = new System.Windows.Forms.DataGridView();
			this.tabRobots = new System.Windows.Forms.TabPage();
			this.tabCommon = new System.Windows.Forms.TabPage();
			splitContainer2 = new System.Windows.Forms.SplitContainer();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabMessages.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridMessages ) ).BeginInit();
			this.tabRobots.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			splitContainer2.Location = new System.Drawing.Point(3, 3);
			splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(this.listBoxRobots);
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(this.groupBox2);
			splitContainer2.Panel2.Controls.Add(groupBox1);
			splitContainer2.Panel2.Controls.Add(this.buttonRobotSmtpSet);
			splitContainer2.Size = new System.Drawing.Size(460, 303);
			splitContainer2.SplitterDistance = 258;
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
			this.listBoxRobots.Size = new System.Drawing.Size(258, 303);
			this.listBoxRobots.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(label6);
			this.groupBox2.Controls.Add(this.textBox5);
			this.groupBox2.Controls.Add(label5);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(190, 79);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "IP, name (optional)";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(80, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 13;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(54, 22);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(20, 13);
			label6.TabIndex = 14;
			label6.Text = "IP:";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(80, 45);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 11;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(6, 48);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(68, 13);
			label5.TabIndex = 12;
			label5.Text = "From (name):";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(this.textBox4);
			groupBox1.Controls.Add(this.textBox3);
			groupBox1.Controls.Add(this.buttonRobotSmtpDef);
			groupBox1.Controls.Add(this.textBox2);
			groupBox1.Controls.Add(this.textRobotSmtpHost);
			groupBox1.Location = new System.Drawing.Point(3, 88);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(190, 166);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "SMTP";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(18, 100);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(56, 13);
			label4.TabIndex = 9;
			label4.Text = "Password:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(38, 74);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(36, 13);
			label3.TabIndex = 8;
			label3.Text = "Login:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(45, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(29, 13);
			label2.TabIndex = 7;
			label2.Text = "Port:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(33, 22);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 13);
			label1.TabIndex = 6;
			label1.Text = "Server:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(80, 97);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 5;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(80, 71);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 4;
			// 
			// buttonRobotSmtpDef
			// 
			this.buttonRobotSmtpDef.Location = new System.Drawing.Point(52, 132);
			this.buttonRobotSmtpDef.Name = "buttonRobotSmtpDef";
			this.buttonRobotSmtpDef.Size = new System.Drawing.Size(75, 23);
			this.buttonRobotSmtpDef.TabIndex = 1;
			this.buttonRobotSmtpDef.Text = "Default";
			this.buttonRobotSmtpDef.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(80, 45);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 3;
			// 
			// textRobotSmtpHost
			// 
			this.textRobotSmtpHost.BackColor = System.Drawing.SystemColors.Window;
			this.textRobotSmtpHost.Location = new System.Drawing.Point(80, 19);
			this.textRobotSmtpHost.Name = "textRobotSmtpHost";
			this.textRobotSmtpHost.Size = new System.Drawing.Size(100, 20);
			this.textRobotSmtpHost.TabIndex = 2;
			// 
			// buttonRobotSmtpSet
			// 
			this.buttonRobotSmtpSet.Location = new System.Drawing.Point(62, 270);
			this.buttonRobotSmtpSet.Name = "buttonRobotSmtpSet";
			this.buttonRobotSmtpSet.Size = new System.Drawing.Size(75, 23);
			this.buttonRobotSmtpSet.TabIndex = 0;
			this.buttonRobotSmtpSet.Text = "Set";
			this.buttonRobotSmtpSet.UseVisualStyleBackColor = true;
			// 
			// listBoxMessages
			// 
			this.listBoxMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxMessages.FormattingEnabled = true;
			this.listBoxMessages.HorizontalScrollbar = true;
			this.listBoxMessages.IntegralHeight = false;
			this.listBoxMessages.Location = new System.Drawing.Point(3, 3);
			this.listBoxMessages.Name = "listBoxMessages";
			this.listBoxMessages.ScrollAlwaysVisible = true;
			this.listBoxMessages.Size = new System.Drawing.Size(460, 303);
			this.listBoxMessages.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStart});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(474, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem1
			// 
			this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
			this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
			this.fileToolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem1.Text = "&File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject("openToolStripMenuItem.Image") ) );
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O ) ) );
			this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.openToolStripMenuItem.Text = "&Open";
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(148, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ( (System.Drawing.Image)( resources.GetObject("saveToolStripMenuItem.Image") ) );
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S ) ) );
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
			// 
			// exitToolStripMenuItem1
			// 
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
			this.exitToolStripMenuItem1.Text = "E&xit";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// customizeToolStripMenuItem
			// 
			this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
			this.customizeToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.customizeToolStripMenuItem.Text = "&Customize";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// contentsToolStripMenuItem
			// 
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.contentsToolStripMenuItem.Text = "&Contents";
			// 
			// indexToolStripMenuItem
			// 
			this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			this.indexToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.indexToolStripMenuItem.Text = "&Index";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.searchToolStripMenuItem.Text = "&Search";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			// 
			// toolStart
			// 
			this.toolStart.Name = "toolStart";
			this.toolStart.Size = new System.Drawing.Size(43, 20);
			this.toolStart.Text = "Start";
			this.toolStart.Click += new System.EventHandler(this.buttonSend_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
			this.toolStrip1.Location = new System.Drawing.Point(3, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(191, 25);
			this.toolStrip1.TabIndex = 11;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButton1.Image") ) );
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(46, 22);
			this.toolStripButton1.Text = "Add";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButton2.Image") ) );
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(66, 22);
			this.toolStripButton2.Text = "Remove";
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton3.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButton3.Image") ) );
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(34, 22);
			this.toolStripButton3.Text = "Load";
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton4.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButton4.Image") ) );
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(33, 22);
			this.toolStripButton4.Text = "View";
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(474, 335);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(474, 360);
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
			this.tabControl.Size = new System.Drawing.Size(474, 335);
			this.tabControl.TabIndex = 0;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabEmails
			// 
			this.tabEmails.Location = new System.Drawing.Point(4, 22);
			this.tabEmails.Name = "tabEmails";
			this.tabEmails.Padding = new System.Windows.Forms.Padding(3);
			this.tabEmails.Size = new System.Drawing.Size(466, 309);
			this.tabEmails.TabIndex = 2;
			this.tabEmails.Text = "Emails";
			this.tabEmails.UseVisualStyleBackColor = true;
			// 
			// tabMessages
			// 
			this.tabMessages.Controls.Add(this.dataGridMessages);
			this.tabMessages.Controls.Add(this.listBoxMessages);
			this.tabMessages.Location = new System.Drawing.Point(4, 22);
			this.tabMessages.Name = "tabMessages";
			this.tabMessages.Padding = new System.Windows.Forms.Padding(3);
			this.tabMessages.Size = new System.Drawing.Size(466, 309);
			this.tabMessages.TabIndex = 0;
			this.tabMessages.Text = "Messages";
			this.tabMessages.UseVisualStyleBackColor = true;
			// 
			// dataGridMessages
			// 
			this.dataGridMessages.AllowUserToAddRows = false;
			this.dataGridMessages.AllowUserToDeleteRows = false;
			this.dataGridMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridMessages.Location = new System.Drawing.Point(3, 3);
			this.dataGridMessages.Name = "dataGridMessages";
			this.dataGridMessages.Size = new System.Drawing.Size(460, 303);
			this.dataGridMessages.TabIndex = 2;
			this.dataGridMessages.Visible = false;
			// 
			// tabRobots
			// 
			this.tabRobots.Controls.Add(splitContainer2);
			this.tabRobots.Location = new System.Drawing.Point(4, 22);
			this.tabRobots.Name = "tabRobots";
			this.tabRobots.Padding = new System.Windows.Forms.Padding(3);
			this.tabRobots.Size = new System.Drawing.Size(466, 309);
			this.tabRobots.TabIndex = 1;
			this.tabRobots.Text = "Robots";
			this.tabRobots.UseVisualStyleBackColor = true;
			// 
			// tabCommon
			// 
			this.tabCommon.Location = new System.Drawing.Point(4, 22);
			this.tabCommon.Name = "tabCommon";
			this.tabCommon.Size = new System.Drawing.Size(466, 309);
			this.tabCommon.TabIndex = 3;
			this.tabCommon.Text = "Common";
			this.tabCommon.UseVisualStyleBackColor = true;
			// 
			// FormServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(474, 384);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "FormServer";
			this.Text = "Server";
			this.Load += new System.EventHandler(this.FormServer_Load);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel2.ResumeLayout(false);
			splitContainer2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabMessages.ResumeLayout(false);
			( (System.ComponentModel.ISupportInitialize)( this.dataGridMessages ) ).EndInit();
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
		private System.Windows.Forms.TabPage tabRobots;
		private System.Windows.Forms.TabPage tabEmails;
		private System.Windows.Forms.TabPage tabCommon;
		private System.Windows.Forms.ListBox listBoxRobots;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textRobotSmtpHost;
		private System.Windows.Forms.Button buttonRobotSmtpDef;
		private System.Windows.Forms.Button buttonRobotSmtpSet;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.DataGridView dataGridMessages;
		private System.Windows.Forms.ToolStripMenuItem toolStart;
	}
}

