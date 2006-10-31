namespace Lab_04
{
    partial class Form4
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
            if (disposing && (components != null))
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
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.GroupBox groupBox2;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label9;
			this.checkAutoSearch = new System.Windows.Forms.CheckBox();
			this.textE = new System.Windows.Forms.TextBox();
			this.groupFirstApproximation = new System.Windows.Forms.GroupBox();
			this.textP2 = new System.Windows.Forms.TextBox();
			this.textP0 = new System.Windows.Forms.TextBox();
			this.textP1 = new System.Windows.Forms.TextBox();
			this.groupInterval = new System.Windows.Forms.GroupBox();
			this.textX1 = new System.Windows.Forms.TextBox();
			this.textX2 = new System.Windows.Forms.TextBox();
			this.textBoxFx = new System.Windows.Forms.TextBox();
			this.buttonSolve = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.plotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moviesDemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runningWaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rollingStarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.radioStillPt = new System.Windows.Forms.RadioButton();
			this.radioBisection = new System.Windows.Forms.RadioButton();
			this.radioNewtone = new System.Windows.Forms.RadioButton();
			this.radioCutting = new System.Windows.Forms.RadioButton();
			this.radioMuller = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioHord = new System.Windows.Forms.RadioButton();
			this.listRoots = new System.Windows.Forms.ListBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.listY = new System.Windows.Forms.ListBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			label1 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			groupBox2.SuspendLayout();
			this.groupFirstApproximation.SuspendLayout();
			this.groupInterval.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(6, 22);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(19, 13);
			label2.TabIndex = 1;
			label2.Text = "p&0";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(6, 48);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(19, 13);
			label3.TabIndex = 3;
			label3.Text = "p&1";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(6, 74);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(19, 13);
			label4.TabIndex = 5;
			label4.Text = "p&2";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(14, 25);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(21, 13);
			label7.TabIndex = 11;
			label7.Text = "f(x)";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(this.checkAutoSearch);
			groupBox2.Controls.Add(label1);
			groupBox2.Controls.Add(this.textE);
			groupBox2.Controls.Add(this.groupFirstApproximation);
			groupBox2.Controls.Add(this.groupInterval);
			groupBox2.Controls.Add(this.textBoxFx);
			groupBox2.Controls.Add(label7);
			groupBox2.Location = new System.Drawing.Point(187, 31);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(328, 164);
			groupBox2.TabIndex = 7;
			groupBox2.TabStop = false;
			groupBox2.Text = "Параметры";
			// 
			// checkAutoSearch
			// 
			this.checkAutoSearch.AutoSize = true;
			this.checkAutoSearch.Location = new System.Drawing.Point(179, 63);
			this.checkAutoSearch.Name = "checkAutoSearch";
			this.checkAutoSearch.Size = new System.Drawing.Size(143, 17);
			this.checkAutoSearch.TabIndex = 23;
			this.checkAutoSearch.Text = "Автоматический поиск";
			this.checkAutoSearch.UseVisualStyleBackColor = true;
			this.checkAutoSearch.CheckedChanged += new System.EventHandler(this.checkAutoSearch_CheckedChanged);
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Symbol", 10F);
			label1.Location = new System.Drawing.Point(176, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(14, 17);
			label1.TabIndex = 17;
			label1.Text = "&e";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textE
			// 
			this.textE.Location = new System.Drawing.Point(196, 22);
			this.textE.Name = "textE";
			this.textE.Size = new System.Drawing.Size(100, 20);
			this.textE.TabIndex = 18;
			this.textE.Text = "1";
			// 
			// groupFirstApproximation
			// 
			this.groupFirstApproximation.Controls.Add(this.textP2);
			this.groupFirstApproximation.Controls.Add(label2);
			this.groupFirstApproximation.Controls.Add(this.textP0);
			this.groupFirstApproximation.Controls.Add(label3);
			this.groupFirstApproximation.Controls.Add(this.textP1);
			this.groupFirstApproximation.Controls.Add(label4);
			this.groupFirstApproximation.Location = new System.Drawing.Point(8, 55);
			this.groupFirstApproximation.Name = "groupFirstApproximation";
			this.groupFirstApproximation.Size = new System.Drawing.Size(158, 103);
			this.groupFirstApproximation.TabIndex = 15;
			this.groupFirstApproximation.TabStop = false;
			this.groupFirstApproximation.Text = "Начальное приближение";
			// 
			// textP2
			// 
			this.textP2.Location = new System.Drawing.Point(31, 71);
			this.textP2.Name = "textP2";
			this.textP2.Size = new System.Drawing.Size(100, 20);
			this.textP2.TabIndex = 6;
			this.textP2.Text = "0";
			// 
			// textP0
			// 
			this.textP0.Location = new System.Drawing.Point(31, 19);
			this.textP0.Name = "textP0";
			this.textP0.Size = new System.Drawing.Size(100, 20);
			this.textP0.TabIndex = 2;
			this.textP0.Text = "0";
			// 
			// textP1
			// 
			this.textP1.Location = new System.Drawing.Point(31, 45);
			this.textP1.Name = "textP1";
			this.textP1.Size = new System.Drawing.Size(100, 20);
			this.textP1.TabIndex = 4;
			this.textP1.Text = "0";
			// 
			// groupInterval
			// 
			this.groupInterval.Controls.Add(label8);
			this.groupInterval.Controls.Add(this.textX1);
			this.groupInterval.Controls.Add(label9);
			this.groupInterval.Controls.Add(this.textX2);
			this.groupInterval.Location = new System.Drawing.Point(179, 86);
			this.groupInterval.Name = "groupInterval";
			this.groupInterval.Size = new System.Drawing.Size(143, 72);
			this.groupInterval.TabIndex = 21;
			this.groupInterval.TabStop = false;
			this.groupInterval.Text = "Интервал";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(6, 21);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(18, 13);
			label8.TabIndex = 7;
			label8.Text = "x1";
			// 
			// textX1
			// 
			this.textX1.Location = new System.Drawing.Point(25, 18);
			this.textX1.Name = "textX1";
			this.textX1.Size = new System.Drawing.Size(100, 20);
			this.textX1.TabIndex = 8;
			this.textX1.Text = "0";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(6, 46);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(18, 13);
			label9.TabIndex = 9;
			label9.Text = "x2";
			// 
			// textX2
			// 
			this.textX2.Location = new System.Drawing.Point(25, 43);
			this.textX2.Name = "textX2";
			this.textX2.Size = new System.Drawing.Size(100, 20);
			this.textX2.TabIndex = 10;
			this.textX2.Text = "5";
			// 
			// textBoxFx
			// 
			this.textBoxFx.Location = new System.Drawing.Point(39, 22);
			this.textBoxFx.Name = "textBoxFx";
			this.textBoxFx.ReadOnly = true;
			this.textBoxFx.Size = new System.Drawing.Size(100, 20);
			this.textBoxFx.TabIndex = 12;
			this.textBoxFx.Text = "5*sin(x^3) – x";
			// 
			// buttonSolve
			// 
			this.buttonSolve.Location = new System.Drawing.Point(9, 219);
			this.buttonSolve.Name = "buttonSolve";
			this.buttonSolve.Size = new System.Drawing.Size(100, 23);
			this.buttonSolve.TabIndex = 8;
			this.buttonSolve.Text = "&Найти";
			this.buttonSolve.UseVisualStyleBackColor = true;
			this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.plotToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(524, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// plotToolStripMenuItem
			// 
			this.plotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fxToolStripMenuItem,
            this.moviesDemoToolStripMenuItem});
			this.plotToolStripMenuItem.Name = "plotToolStripMenuItem";
			this.plotToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.plotToolStripMenuItem.Text = "&Plot";
			// 
			// fxToolStripMenuItem
			// 
			this.fxToolStripMenuItem.Name = "fxToolStripMenuItem";
			this.fxToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.fxToolStripMenuItem.Text = "&f(x)";
			this.fxToolStripMenuItem.Click += new System.EventHandler(this.fxItem_Click);
			// 
			// moviesDemoToolStripMenuItem
			// 
			this.moviesDemoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runningWaveToolStripMenuItem,
            this.rollingStarToolStripMenuItem});
			this.moviesDemoToolStripMenuItem.Name = "moviesDemoToolStripMenuItem";
			this.moviesDemoToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.moviesDemoToolStripMenuItem.Text = "Movies demo";
			// 
			// runningWaveToolStripMenuItem
			// 
			this.runningWaveToolStripMenuItem.Name = "runningWaveToolStripMenuItem";
			this.runningWaveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.runningWaveToolStripMenuItem.Text = "RunningWave";
			this.runningWaveToolStripMenuItem.Click += new System.EventHandler(this.RunWave_Click);
			// 
			// rollingStarToolStripMenuItem
			// 
			this.rollingStarToolStripMenuItem.Name = "rollingStarToolStripMenuItem";
			this.rollingStarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.rollingStarToolStripMenuItem.Text = "RollingStar";
			this.rollingStarToolStripMenuItem.Click += new System.EventHandler(this.RollStar_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			this.toolsToolStripMenuItem.Visible = false;
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
			// radioStillPt
			// 
			this.radioStillPt.AutoSize = true;
			this.radioStillPt.Location = new System.Drawing.Point(6, 19);
			this.radioStillPt.Name = "radioStillPt";
			this.radioStillPt.Size = new System.Drawing.Size(124, 17);
			this.radioStillPt.TabIndex = 1;
			this.radioStillPt.TabStop = true;
			this.radioStillPt.Text = "неподвижной &точки";
			this.radioStillPt.UseVisualStyleBackColor = true;
			this.radioStillPt.CheckedChanged += new System.EventHandler(this.radioStillPt_CheckedChanged);
			// 
			// radioBisection
			// 
			this.radioBisection.AutoSize = true;
			this.radioBisection.Location = new System.Drawing.Point(6, 43);
			this.radioBisection.Name = "radioBisection";
			this.radioBisection.Size = new System.Drawing.Size(131, 17);
			this.radioBisection.TabIndex = 2;
			this.radioBisection.TabStop = true;
			this.radioBisection.Text = "&бисекции (Больцано)";
			this.radioBisection.UseVisualStyleBackColor = true;
			this.radioBisection.CheckedChanged += new System.EventHandler(this.radioBisection_CheckedChanged);
			// 
			// radioNewtone
			// 
			this.radioNewtone.AutoSize = true;
			this.radioNewtone.Location = new System.Drawing.Point(6, 67);
			this.radioNewtone.Name = "radioNewtone";
			this.radioNewtone.Size = new System.Drawing.Size(158, 17);
			this.radioNewtone.TabIndex = 3;
			this.radioNewtone.TabStop = true;
			this.radioNewtone.Text = "касательных (&Ньютона-Р.)";
			this.radioNewtone.UseVisualStyleBackColor = true;
			this.radioNewtone.CheckedChanged += new System.EventHandler(this.radioNewtone_CheckedChanged);
			// 
			// radioCutting
			// 
			this.radioCutting.AutoSize = true;
			this.radioCutting.Location = new System.Drawing.Point(6, 91);
			this.radioCutting.Name = "radioCutting";
			this.radioCutting.Size = new System.Drawing.Size(68, 17);
			this.radioCutting.TabIndex = 4;
			this.radioCutting.TabStop = true;
			this.radioCutting.Text = "&секущих";
			this.radioCutting.UseVisualStyleBackColor = true;
			this.radioCutting.CheckedChanged += new System.EventHandler(this.radioCutting_CheckedChanged);
			// 
			// radioMuller
			// 
			this.radioMuller.AutoSize = true;
			this.radioMuller.Location = new System.Drawing.Point(6, 137);
			this.radioMuller.Name = "radioMuller";
			this.radioMuller.Size = new System.Drawing.Size(72, 17);
			this.radioMuller.TabIndex = 5;
			this.radioMuller.TabStop = true;
			this.radioMuller.Text = "&Мюллера";
			this.radioMuller.UseVisualStyleBackColor = true;
			this.radioMuller.CheckedChanged += new System.EventHandler(this.radioMuller_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioHord);
			this.groupBox1.Controls.Add(this.radioStillPt);
			this.groupBox1.Controls.Add(this.radioMuller);
			this.groupBox1.Controls.Add(this.radioBisection);
			this.groupBox1.Controls.Add(this.radioCutting);
			this.groupBox1.Controls.Add(this.radioNewtone);
			this.groupBox1.Location = new System.Drawing.Point(9, 31);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(172, 164);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Метод";
			// 
			// radioHord
			// 
			this.radioHord.AutoSize = true;
			this.radioHord.Location = new System.Drawing.Point(6, 114);
			this.radioHord.Name = "radioHord";
			this.radioHord.Size = new System.Drawing.Size(48, 17);
			this.radioHord.TabIndex = 6;
			this.radioHord.TabStop = true;
			this.radioHord.Text = "&хорд";
			this.radioHord.UseVisualStyleBackColor = true;
			this.radioHord.CheckedChanged += new System.EventHandler(this.radioHord_CheckedChanged);
			// 
			// listRoots
			// 
			this.listRoots.FormattingEnabled = true;
			this.listRoots.IntegralHeight = false;
			this.listRoots.Location = new System.Drawing.Point(6, 19);
			this.listRoots.Name = "listRoots";
			this.listRoots.ScrollAlwaysVisible = true;
			this.listRoots.Size = new System.Drawing.Size(243, 127);
			this.listRoots.TabIndex = 18;
			this.listRoots.SelectedIndexChanged += new System.EventHandler(this.ListsSync);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.listY);
			this.groupBox5.Controls.Add(this.listRoots);
			this.groupBox5.Location = new System.Drawing.Point(9, 248);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(506, 151);
			this.groupBox5.TabIndex = 19;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Корни";
			// 
			// listY
			// 
			this.listY.FormattingEnabled = true;
			this.listY.IntegralHeight = false;
			this.listY.Location = new System.Drawing.Point(255, 20);
			this.listY.Name = "listY";
			this.listY.ScrollAlwaysVisible = true;
			this.listY.Size = new System.Drawing.Size(245, 126);
			this.listY.TabIndex = 19;
			this.listY.SelectedIndexChanged += new System.EventHandler(this.ListsSync);
			// 
			// errorProvider1
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// Form4
			// 
			this.AcceptButton = this.buttonSolve;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 411);
			this.Controls.Add(this.buttonSolve);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form4";
			this.Text = "Roots 2000";
			this.Load += new System.EventHandler(this.Form4_Load);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			this.groupFirstApproximation.ResumeLayout(false);
			this.groupFirstApproximation.PerformLayout();
			this.groupInterval.ResumeLayout(false);
			this.groupInterval.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rollingStarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runningWaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem plotToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moviesDemoToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioStillPt;
        private System.Windows.Forms.RadioButton radioBisection;
        private System.Windows.Forms.RadioButton radioNewtone;
        private System.Windows.Forms.RadioButton radioCutting;
        private System.Windows.Forms.RadioButton radioMuller;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonSolve;
		private System.Windows.Forms.TextBox textP0;
		private System.Windows.Forms.TextBox textP1;
		private System.Windows.Forms.TextBox textP2;
		private System.Windows.Forms.TextBox textBoxFx;
		private System.Windows.Forms.TextBox textE;
		private System.Windows.Forms.RadioButton radioHord;
		private System.Windows.Forms.ListBox listRoots;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.TextBox textX1;
		private System.Windows.Forms.TextBox textX2;
		private System.Windows.Forms.ListBox listY;
		private System.Windows.Forms.CheckBox checkAutoSearch;
		private System.Windows.Forms.GroupBox groupInterval;
		private System.Windows.Forms.GroupBox groupFirstApproximation;
    }
}

