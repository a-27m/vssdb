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
			System.Windows.Forms.SplitContainer splitContainer1;
			System.Windows.Forms.GroupBox groupBox1;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.SplitContainer splitContainer4;
			System.Windows.Forms.Label label14;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer));
			this.listSmtps = new System.Windows.Forms.ListBox();
			this.tabSmtps_buttonRemove = new System.Windows.Forms.Button();
			this.tabSmtps_buttonAdd = new System.Windows.Forms.Button();
			this.tabSmtps_buttonSet = new System.Windows.Forms.Button();
			this.tabSmtps_textName = new System.Windows.Forms.TextBox();
			this.tabSmtps_textEmail = new System.Windows.Forms.TextBox();
			this.tabSmtps_checkSSL = new System.Windows.Forms.CheckBox();
			this.tabSmtps_textHost = new System.Windows.Forms.TextBox();
			this.tabSmtps_textLogin = new System.Windows.Forms.TextBox();
			this.tabSmtps_textPassword = new System.Windows.Forms.TextBox();
			this.tabSmtps_textPort = new System.Windows.Forms.TextBox();
			this.listRobots = new System.Windows.Forms.ListBox();
			this.tabRobots_buttonRemove = new System.Windows.Forms.Button();
			this.tabRobots_buttonAdd = new System.Windows.Forms.Button();
			this.openFileDialogEmails = new System.Windows.Forms.OpenFileDialog();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.textMsgID = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.emptyEmailsDatabseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetDoneTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabEmails = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.listEmails = new System.Windows.Forms.ListBox();
			this.buttonSetId = new System.Windows.Forms.Button();
			this.buttonTab1Load = new System.Windows.Forms.Button();
			this.tabMessages = new System.Windows.Forms.TabPage();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.listMessages = new System.Windows.Forms.ListBox();
			this.tabMsg_buttonRemove = new System.Windows.Forms.Button();
			this.buttonAddLetter = new System.Windows.Forms.Button();
			this.buttonPreview = new System.Windows.Forms.Button();
			this.buttonTabMsgEdit = new System.Windows.Forms.Button();
			this.tabSmtps = new System.Windows.Forms.TabPage();
			this.tabRobots = new System.Windows.Forms.TabPage();
			this.tabRobots_textIP = new System.Windows.Forms.TextBox();
			this.tabEmails_checkPendingOnly = new System.Windows.Forms.CheckBox();
			label1 = new System.Windows.Forms.Label();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			splitContainer4 = new System.Windows.Forms.SplitContainer();
			label14 = new System.Windows.Forms.Label();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			groupBox1.SuspendLayout();
			splitContainer4.Panel1.SuspendLayout();
			splitContainer4.Panel2.SuspendLayout();
			splitContainer4.SuspendLayout();
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
			this.tabSmtps.SuspendLayout();
			this.tabRobots.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(7, 47);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(67, 13);
			label1.TabIndex = 1;
			label1.Text = "Message ID:";
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			splitContainer1.IsSplitterFixed = true;
			splitContainer1.Location = new System.Drawing.Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(this.listSmtps);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(this.tabSmtps_buttonRemove);
			splitContainer1.Panel2.Controls.Add(this.tabSmtps_buttonAdd);
			splitContainer1.Panel2.Controls.Add(this.tabSmtps_buttonSet);
			splitContainer1.Panel2.Controls.Add(groupBox1);
			splitContainer1.Size = new System.Drawing.Size(469, 318);
			splitContainer1.SplitterDistance = 245;
			splitContainer1.TabIndex = 0;
			// 
			// listSmtps
			// 
			this.listSmtps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listSmtps.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 204 ) ));
			this.listSmtps.FormattingEnabled = true;
			this.listSmtps.IntegralHeight = false;
			this.listSmtps.ItemHeight = 16;
			this.listSmtps.Location = new System.Drawing.Point(0, 0);
			this.listSmtps.Name = "listSmtps";
			this.listSmtps.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listSmtps.Size = new System.Drawing.Size(245, 318);
			this.listSmtps.TabIndex = 0;
			this.listSmtps.SelectedIndexChanged += new System.EventHandler(this.tabSmtps_listSmtps_SelectedIndexChanged);
			// 
			// tabSmtps_buttonRemove
			// 
			this.tabSmtps_buttonRemove.Location = new System.Drawing.Point(49, 285);
			this.tabSmtps_buttonRemove.Name = "tabSmtps_buttonRemove";
			this.tabSmtps_buttonRemove.Size = new System.Drawing.Size(122, 23);
			this.tabSmtps_buttonRemove.TabIndex = 3;
			this.tabSmtps_buttonRemove.Text = "Remove selected";
			this.tabSmtps_buttonRemove.UseVisualStyleBackColor = true;
			this.tabSmtps_buttonRemove.Click += new System.EventHandler(this.tabSmtps_buttonRemove_Click);
			// 
			// tabSmtps_buttonAdd
			// 
			this.tabSmtps_buttonAdd.Location = new System.Drawing.Point(32, 245);
			this.tabSmtps_buttonAdd.Name = "tabSmtps_buttonAdd";
			this.tabSmtps_buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.tabSmtps_buttonAdd.TabIndex = 1;
			this.tabSmtps_buttonAdd.Text = "Add";
			this.tabSmtps_buttonAdd.UseVisualStyleBackColor = true;
			this.tabSmtps_buttonAdd.Click += new System.EventHandler(this.tabSmtps_buttonAdd_Click);
			// 
			// tabSmtps_buttonSet
			// 
			this.tabSmtps_buttonSet.Location = new System.Drawing.Point(113, 245);
			this.tabSmtps_buttonSet.Name = "tabSmtps_buttonSet";
			this.tabSmtps_buttonSet.Size = new System.Drawing.Size(75, 23);
			this.tabSmtps_buttonSet.TabIndex = 2;
			this.tabSmtps_buttonSet.Text = "Set";
			this.tabSmtps_buttonSet.UseVisualStyleBackColor = true;
			this.tabSmtps_buttonSet.Click += new System.EventHandler(this.tabSmtps_buttonSet_Click);
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(this.tabSmtps_textName);
			groupBox1.Controls.Add(this.tabSmtps_textEmail);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(this.tabSmtps_checkSSL);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(this.tabSmtps_textHost);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(this.tabSmtps_textLogin);
			groupBox1.Controls.Add(this.tabSmtps_textPassword);
			groupBox1.Controls.Add(this.tabSmtps_textPort);
			groupBox1.Controls.Add(label3);
			groupBox1.Location = new System.Drawing.Point(7, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(207, 236);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "SMTP data";
			groupBox1.TextChanged += new System.EventHandler(this.tabSmtps_smtpDataChanged);
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(6, 204);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(73, 13);
			label7.TabIndex = 17;
			label7.Text = "\"From\" e-mail:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(6, 178);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(72, 13);
			label8.TabIndex = 16;
			label8.Text = "\"From\" name:";
			// 
			// tabSmtps_textName
			// 
			this.tabSmtps_textName.Location = new System.Drawing.Point(84, 175);
			this.tabSmtps_textName.Name = "tabSmtps_textName";
			this.tabSmtps_textName.Size = new System.Drawing.Size(100, 20);
			this.tabSmtps_textName.TabIndex = 5;
			// 
			// tabSmtps_textEmail
			// 
			this.tabSmtps_textEmail.Location = new System.Drawing.Point(84, 201);
			this.tabSmtps_textEmail.Name = "tabSmtps_textEmail";
			this.tabSmtps_textEmail.Size = new System.Drawing.Size(100, 20);
			this.tabSmtps_textEmail.TabIndex = 6;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(6, 146);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(66, 13);
			label6.TabIndex = 13;
			label6.Text = "Enable SSL:";
			// 
			// tabSmtps_checkSSL
			// 
			this.tabSmtps_checkSSL.AutoSize = true;
			this.tabSmtps_checkSSL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tabSmtps_checkSSL.Location = new System.Drawing.Point(84, 146);
			this.tabSmtps_checkSSL.Name = "tabSmtps_checkSSL";
			this.tabSmtps_checkSSL.Size = new System.Drawing.Size(15, 14);
			this.tabSmtps_checkSSL.TabIndex = 4;
			this.tabSmtps_checkSSL.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(6, 114);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(56, 13);
			label5.TabIndex = 11;
			label5.Text = "Password:";
			// 
			// tabSmtps_textHost
			// 
			this.tabSmtps_textHost.Location = new System.Drawing.Point(84, 22);
			this.tabSmtps_textHost.Name = "tabSmtps_textHost";
			this.tabSmtps_textHost.Size = new System.Drawing.Size(100, 20);
			this.tabSmtps_textHost.TabIndex = 0;
			this.tabSmtps_textHost.TextChanged += new System.EventHandler(this.tabSmtps_smtpDataChanged);
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(6, 88);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(36, 13);
			label4.TabIndex = 10;
			label4.Text = "Login:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(6, 25);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(72, 13);
			label2.TabIndex = 2;
			label2.Text = "SMTP server:";
			// 
			// tabSmtps_textLogin
			// 
			this.tabSmtps_textLogin.Location = new System.Drawing.Point(84, 85);
			this.tabSmtps_textLogin.Name = "tabSmtps_textLogin";
			this.tabSmtps_textLogin.Size = new System.Drawing.Size(100, 20);
			this.tabSmtps_textLogin.TabIndex = 2;
			this.tabSmtps_textLogin.TextChanged += new System.EventHandler(this.tabSmtps_smtpDataChanged);
			// 
			// tabSmtps_textPassword
			// 
			this.tabSmtps_textPassword.Location = new System.Drawing.Point(84, 111);
			this.tabSmtps_textPassword.Name = "tabSmtps_textPassword";
			this.tabSmtps_textPassword.Size = new System.Drawing.Size(100, 20);
			this.tabSmtps_textPassword.TabIndex = 3;
			this.tabSmtps_textPassword.TextChanged += new System.EventHandler(this.tabSmtps_smtpDataChanged);
			// 
			// tabSmtps_textPort
			// 
			this.tabSmtps_textPort.Location = new System.Drawing.Point(84, 48);
			this.tabSmtps_textPort.Name = "tabSmtps_textPort";
			this.tabSmtps_textPort.Size = new System.Drawing.Size(100, 20);
			this.tabSmtps_textPort.TabIndex = 1;
			this.tabSmtps_textPort.TextChanged += new System.EventHandler(this.tabSmtps_smtpDataChanged);
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(6, 51);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 13);
			label3.TabIndex = 3;
			label3.Text = "Port:";
			// 
			// splitContainer4
			// 
			splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			splitContainer4.IsSplitterFixed = true;
			splitContainer4.Location = new System.Drawing.Point(3, 3);
			splitContainer4.Name = "splitContainer4";
			// 
			// splitContainer4.Panel1
			// 
			splitContainer4.Panel1.Controls.Add(this.listRobots);
			// 
			// splitContainer4.Panel2
			// 
			splitContainer4.Panel2.Controls.Add(this.tabRobots_textIP);
			splitContainer4.Panel2.Controls.Add(label14);
			splitContainer4.Panel2.Controls.Add(this.tabRobots_buttonRemove);
			splitContainer4.Panel2.Controls.Add(this.tabRobots_buttonAdd);
			splitContainer4.Size = new System.Drawing.Size(463, 312);
			splitContainer4.SplitterDistance = 315;
			splitContainer4.TabIndex = 1;
			// 
			// listRobots
			// 
			this.listRobots.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listRobots.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F);
			this.listRobots.FormattingEnabled = true;
			this.listRobots.IntegralHeight = false;
			this.listRobots.ItemHeight = 16;
			this.listRobots.Location = new System.Drawing.Point(0, 0);
			this.listRobots.Name = "listRobots";
			this.listRobots.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listRobots.Size = new System.Drawing.Size(315, 312);
			this.listRobots.TabIndex = 0;
			this.listRobots.SelectedIndexChanged += new System.EventHandler(this.tabRobots_SelectedIndexChanged);
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(18, 21);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(60, 13);
			label14.TabIndex = 2;
			label14.Text = "IP address:";
			// 
			// tabRobots_buttonRemove
			// 
			this.tabRobots_buttonRemove.Location = new System.Drawing.Point(21, 105);
			this.tabRobots_buttonRemove.Name = "tabRobots_buttonRemove";
			this.tabRobots_buttonRemove.Size = new System.Drawing.Size(75, 23);
			this.tabRobots_buttonRemove.TabIndex = 2;
			this.tabRobots_buttonRemove.Text = "Remove";
			this.tabRobots_buttonRemove.UseVisualStyleBackColor = true;
			this.tabRobots_buttonRemove.Click += new System.EventHandler(this.tabRobots_buttonRemove_Click);
			// 
			// tabRobots_buttonAdd
			// 
			this.tabRobots_buttonAdd.Location = new System.Drawing.Point(21, 76);
			this.tabRobots_buttonAdd.Name = "tabRobots_buttonAdd";
			this.tabRobots_buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.tabRobots_buttonAdd.TabIndex = 1;
			this.tabRobots_buttonAdd.Text = "Add";
			this.tabRobots_buttonAdd.UseVisualStyleBackColor = true;
			this.tabRobots_buttonAdd.Click += new System.EventHandler(this.tabRobots_buttonAdd_Click);
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
			this.errorProvider.ContainerControl = this;
			// 
			// textMsgID
			// 
			this.errorProvider.SetIconAlignment(this.textMsgID, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.textMsgID.Location = new System.Drawing.Point(10, 63);
			this.textMsgID.Name = "textMsgID";
			this.textMsgID.Size = new System.Drawing.Size(75, 20);
			this.textMsgID.TabIndex = 2;
			this.textMsgID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tabEmails_textMsgID_KeyPress);
			this.textMsgID.TextChanged += new System.EventHandler(this.tabEmails_textMsgID_TextChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(477, 24);
			this.menuStrip1.TabIndex = 15;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// actionToolStripMenuItem
			// 
			this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startAllToolStripMenuItem,
            this.stopAllToolStripMenuItem,
            this.serviceToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
			this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.actionToolStripMenuItem.Text = "&Actions";
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
			// serviceToolStripMenuItem
			// 
			this.serviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyEmailsDatabseToolStripMenuItem,
            this.resetDoneTasksToolStripMenuItem});
			this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
			this.serviceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.serviceToolStripMenuItem.Text = "Se&rvice";
			// 
			// emptyEmailsDatabseToolStripMenuItem
			// 
			this.emptyEmailsDatabseToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon;
			this.emptyEmailsDatabseToolStripMenuItem.Name = "emptyEmailsDatabseToolStripMenuItem";
			this.emptyEmailsDatabseToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.emptyEmailsDatabseToolStripMenuItem.Text = "Empty e-mails database";
			this.emptyEmailsDatabseToolStripMenuItem.Click += new System.EventHandler(this.emptyEmailsMenuItem_Click);
			// 
			// resetDoneTasksToolStripMenuItem
			// 
			this.resetDoneTasksToolStripMenuItem.Name = "resetDoneTasksToolStripMenuItem";
			this.resetDoneTasksToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.resetDoneTasksToolStripMenuItem.Text = "Reset tasks";
			this.resetDoneTasksToolStripMenuItem.Click += new System.EventHandler(this.ClearStates_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
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
			this.helpToolStripMenuItem.Visible = false;
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabEmails);
			this.tabControl1.Controls.Add(this.tabMessages);
			this.tabControl1.Controls.Add(this.tabSmtps);
			this.tabControl1.Controls.Add(this.tabRobots);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(477, 211);
			this.tabControl1.TabIndex = 16;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabEmails
			// 
			this.tabEmails.Controls.Add(this.splitContainer2);
			this.tabEmails.Location = new System.Drawing.Point(4, 22);
			this.tabEmails.Name = "tabEmails";
			this.tabEmails.Padding = new System.Windows.Forms.Padding(3);
			this.tabEmails.Size = new System.Drawing.Size(469, 185);
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
			this.splitContainer2.Panel2.Controls.Add(this.tabEmails_checkPendingOnly);
			this.splitContainer2.Panel2.Controls.Add(this.textMsgID);
			this.splitContainer2.Panel2.Controls.Add(label1);
			this.splitContainer2.Panel2.Controls.Add(this.buttonSetId);
			this.splitContainer2.Panel2.Controls.Add(this.buttonTab1Load);
			this.splitContainer2.Size = new System.Drawing.Size(463, 179);
			this.splitContainer2.SplitterDistance = 341;
			this.splitContainer2.TabIndex = 2;
			// 
			// listEmails
			// 
			this.listEmails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listEmails.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 204 ) ));
			this.listEmails.FormattingEnabled = true;
			this.listEmails.IntegralHeight = false;
			this.listEmails.ItemHeight = 16;
			this.listEmails.Location = new System.Drawing.Point(0, 0);
			this.listEmails.Name = "listEmails";
			this.listEmails.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listEmails.Size = new System.Drawing.Size(341, 179);
			this.listEmails.TabIndex = 0;
			this.listEmails.SelectedIndexChanged += new System.EventHandler(this.tabEmails_listEmails_SelectedIndexChanged);
			// 
			// buttonSetId
			// 
			this.buttonSetId.Location = new System.Drawing.Point(10, 88);
			this.buttonSetId.Name = "buttonSetId";
			this.buttonSetId.Size = new System.Drawing.Size(75, 23);
			this.buttonSetId.TabIndex = 3;
			this.buttonSetId.Text = "Set";
			this.buttonSetId.UseVisualStyleBackColor = true;
			this.buttonSetId.Click += new System.EventHandler(this.tabEmails_buttonSet_Click);
			// 
			// buttonTab1Load
			// 
			this.buttonTab1Load.Location = new System.Drawing.Point(10, 140);
			this.buttonTab1Load.Name = "buttonTab1Load";
			this.buttonTab1Load.Size = new System.Drawing.Size(75, 23);
			this.buttonTab1Load.TabIndex = 0;
			this.buttonTab1Load.Text = "Load...";
			this.buttonTab1Load.UseVisualStyleBackColor = true;
			this.buttonTab1Load.Click += new System.EventHandler(this.tabEmails_buttonLoad_Click);
			// 
			// tabMessages
			// 
			this.tabMessages.Controls.Add(this.splitContainer3);
			this.tabMessages.Location = new System.Drawing.Point(4, 22);
			this.tabMessages.Name = "tabMessages";
			this.tabMessages.Padding = new System.Windows.Forms.Padding(3);
			this.tabMessages.Size = new System.Drawing.Size(469, 318);
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
			this.splitContainer3.Panel2.Controls.Add(this.tabMsg_buttonRemove);
			this.splitContainer3.Panel2.Controls.Add(this.buttonAddLetter);
			this.splitContainer3.Panel2.Controls.Add(this.buttonPreview);
			this.splitContainer3.Panel2.Controls.Add(this.buttonTabMsgEdit);
			this.splitContainer3.Size = new System.Drawing.Size(463, 312);
			this.splitContainer3.SplitterDistance = 364;
			this.splitContainer3.TabIndex = 3;
			// 
			// listMessages
			// 
			this.listMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listMessages.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 204 ) ));
			this.listMessages.FormattingEnabled = true;
			this.listMessages.IntegralHeight = false;
			this.listMessages.ItemHeight = 16;
			this.listMessages.Location = new System.Drawing.Point(0, 0);
			this.listMessages.Name = "listMessages";
			this.listMessages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listMessages.Size = new System.Drawing.Size(364, 312);
			this.listMessages.TabIndex = 0;
			this.listMessages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabMsg_listMessages_MouseDoubleClick);
			// 
			// tabMsg_buttonRemove
			// 
			this.tabMsg_buttonRemove.Location = new System.Drawing.Point(10, 123);
			this.tabMsg_buttonRemove.Name = "tabMsg_buttonRemove";
			this.tabMsg_buttonRemove.Size = new System.Drawing.Size(75, 23);
			this.tabMsg_buttonRemove.TabIndex = 3;
			this.tabMsg_buttonRemove.Text = "Remove";
			this.tabMsg_buttonRemove.UseVisualStyleBackColor = true;
			this.tabMsg_buttonRemove.Click += new System.EventHandler(this.tabMsg_buttonRemove_Click);
			// 
			// buttonAddLetter
			// 
			this.buttonAddLetter.Location = new System.Drawing.Point(10, 17);
			this.buttonAddLetter.Name = "buttonAddLetter";
			this.buttonAddLetter.Size = new System.Drawing.Size(75, 23);
			this.buttonAddLetter.TabIndex = 0;
			this.buttonAddLetter.Text = "Add...";
			this.buttonAddLetter.UseVisualStyleBackColor = true;
			this.buttonAddLetter.Click += new System.EventHandler(this.tabMsg_buttonAddLetter_Click);
			// 
			// buttonPreview
			// 
			this.buttonPreview.Location = new System.Drawing.Point(10, 83);
			this.buttonPreview.Name = "buttonPreview";
			this.buttonPreview.Size = new System.Drawing.Size(75, 23);
			this.buttonPreview.TabIndex = 2;
			this.buttonPreview.Text = "Preview";
			this.buttonPreview.UseVisualStyleBackColor = true;
			this.buttonPreview.Click += new System.EventHandler(this.tabMsg_buttonPreview_Click);
			// 
			// buttonTabMsgEdit
			// 
			this.buttonTabMsgEdit.Location = new System.Drawing.Point(10, 50);
			this.buttonTabMsgEdit.Name = "buttonTabMsgEdit";
			this.buttonTabMsgEdit.Size = new System.Drawing.Size(75, 23);
			this.buttonTabMsgEdit.TabIndex = 1;
			this.buttonTabMsgEdit.Text = "Edit...";
			this.buttonTabMsgEdit.UseVisualStyleBackColor = true;
			this.buttonTabMsgEdit.Click += new System.EventHandler(this.tabMsg_buttonEdit_Click);
			// 
			// tabSmtps
			// 
			this.tabSmtps.Controls.Add(splitContainer1);
			this.tabSmtps.Location = new System.Drawing.Point(4, 22);
			this.tabSmtps.Name = "tabSmtps";
			this.tabSmtps.Size = new System.Drawing.Size(469, 318);
			this.tabSmtps.TabIndex = 2;
			this.tabSmtps.Text = "SMTP servers";
			this.tabSmtps.UseVisualStyleBackColor = true;
			// 
			// tabRobots
			// 
			this.tabRobots.Controls.Add(splitContainer4);
			this.tabRobots.Location = new System.Drawing.Point(4, 22);
			this.tabRobots.Name = "tabRobots";
			this.tabRobots.Padding = new System.Windows.Forms.Padding(3);
			this.tabRobots.Size = new System.Drawing.Size(469, 318);
			this.tabRobots.TabIndex = 3;
			this.tabRobots.Text = "Robots (clients)";
			this.tabRobots.UseVisualStyleBackColor = true;
			// 
			// tabRobots_textIP
			// 
			this.tabRobots_textIP.Location = new System.Drawing.Point(21, 37);
			this.tabRobots_textIP.Name = "tabRobots_textIP";
			this.tabRobots_textIP.Size = new System.Drawing.Size(100, 20);
			this.tabRobots_textIP.TabIndex = 3;
			// 
			// tabEmails_checkPendingOnly
			// 
			this.tabEmails_checkPendingOnly.AutoSize = true;
			this.tabEmails_checkPendingOnly.Location = new System.Drawing.Point(10, 14);
			this.tabEmails_checkPendingOnly.Name = "tabEmails_checkPendingOnly";
			this.tabEmails_checkPendingOnly.Size = new System.Drawing.Size(87, 17);
			this.tabEmails_checkPendingOnly.TabIndex = 4;
			this.tabEmails_checkPendingOnly.Text = "Pending only";
			this.tabEmails_checkPendingOnly.UseVisualStyleBackColor = true;
			this.tabEmails_checkPendingOnly.CheckedChanged += new System.EventHandler(this.tabEmails_checkPendingOnly_CheckedChanged);
			// 
			// FormServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(477, 235);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(308, 83);
			this.Name = "FormServer";
			this.Opacity = 0;
			this.Text = "Server";
			this.Shown += new System.EventHandler(this.FormServer_Shown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
			this.Load += new System.EventHandler(this.FormServer_Load);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			splitContainer4.Panel1.ResumeLayout(false);
			splitContainer4.Panel2.ResumeLayout(false);
			splitContainer4.Panel2.PerformLayout();
			splitContainer4.ResumeLayout(false);
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
			this.tabSmtps.ResumeLayout(false);
			this.tabRobots.ResumeLayout(false);
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
		private System.Windows.Forms.Button buttonSetId;
		private System.Windows.Forms.Button buttonTab1Load;
		private System.Windows.Forms.TabPage tabMessages;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.ListBox listMessages;
		private System.Windows.Forms.Button buttonTabMsgEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Button buttonPreview;
		private System.Windows.Forms.Button buttonAddLetter;
		private System.Windows.Forms.Button tabMsg_buttonRemove;
		private System.Windows.Forms.TabPage tabSmtps;
		private System.Windows.Forms.ListBox listSmtps;
		private System.Windows.Forms.TextBox tabSmtps_textHost;
		private System.Windows.Forms.TextBox tabSmtps_textLogin;
		private System.Windows.Forms.TextBox tabSmtps_textPassword;
		private System.Windows.Forms.TextBox tabSmtps_textPort;
		private System.Windows.Forms.CheckBox tabSmtps_checkSSL;
		private System.Windows.Forms.Button tabSmtps_buttonSet;
		private System.Windows.Forms.Button tabSmtps_buttonRemove;
		private System.Windows.Forms.Button tabSmtps_buttonAdd;
		private System.Windows.Forms.TabPage tabRobots;
		private System.Windows.Forms.TextBox tabSmtps_textName;
		private System.Windows.Forms.TextBox tabSmtps_textEmail;
		private System.Windows.Forms.ListBox listRobots;
		private System.Windows.Forms.Button tabRobots_buttonRemove;
		private System.Windows.Forms.Button tabRobots_buttonAdd;
		private System.Windows.Forms.TextBox tabRobots_textIP;
		private System.Windows.Forms.CheckBox tabEmails_checkPendingOnly;

	}
}

