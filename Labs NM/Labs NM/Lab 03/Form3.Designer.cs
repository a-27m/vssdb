namespace Lab_03
{
    partial class Form3
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
            System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_f = new System.Windows.Forms.ToolStripMenuItem();
            this.derivatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_df = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_d2f = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_d3f = new System.Windows.Forms.ToolStripMenuItem();
            this.integrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxReuse = new System.Windows.Forms.CheckBox();
            drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawToolStripMenuItem
            // 
            drawToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            drawToolStripMenuItem.Checked = true;
            drawToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            drawToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            drawToolStripMenuItem.Enabled = false;
            drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            drawToolStripMenuItem.ShowShortcutKeys = false;
            drawToolStripMenuItem.Size = new System.Drawing.Size(23, 20);
            drawToolStripMenuItem.Text = "|";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            toolStripMenuItem1.Checked = true;
            toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripMenuItem1.Enabled = false;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.ShowShortcutKeys = false;
            toolStripMenuItem1.Size = new System.Drawing.Size(23, 20);
            toolStripMenuItem1.Text = "|";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            toolStripMenuItem1,
            this.tool_f,
            this.derivatesToolStripMenuItem,
            this.integrationToolStripMenuItem,
            drawToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(320, 24);
            this.menuStrip1.TabIndex = 1;
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // tool_f
            // 
            this.tool_f.Name = "tool_f";
            this.tool_f.Size = new System.Drawing.Size(37, 20);
            this.tool_f.Text = "f(&x)";
            this.tool_f.Click += new System.EventHandler(this.tool_f_Click);
            // 
            // derivatesToolStripMenuItem
            // 
            this.derivatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_df,
            this.tool_d2f,
            this.tool_d3f});
            this.derivatesToolStripMenuItem.Name = "derivatesToolStripMenuItem";
            this.derivatesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.derivatesToolStripMenuItem.Text = "&Derivates";
            // 
            // tool_df
            // 
            this.tool_df.Name = "tool_df";
            this.tool_df.Size = new System.Drawing.Size(152, 22);
            this.tool_df.Text = "df(x)/dx";
            this.tool_df.Click += new System.EventHandler(this.tool_df_Click);
            // 
            // tool_d2f
            // 
            this.tool_d2f.Name = "tool_d2f";
            this.tool_d2f.Size = new System.Drawing.Size(152, 22);
            this.tool_d2f.Text = "d²f(x)/dx²";
            this.tool_d2f.Click += new System.EventHandler(this.tool_d2f_Click);
            // 
            // tool_d3f
            // 
            this.tool_d3f.Name = "tool_d3f";
            this.tool_d3f.Size = new System.Drawing.Size(152, 22);
            this.tool_d3f.Text = "d³f(x)/dx³";
            this.tool_d3f.Click += new System.EventHandler(this.tool_d3f_Click);
            // 
            // integrationToolStripMenuItem
            // 
            this.integrationToolStripMenuItem.Name = "integrationToolStripMenuItem";
            this.integrationToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.integrationToolStripMenuItem.Text = "Integration...";
            this.integrationToolStripMenuItem.Click += new System.EventHandler(this.integrationToolStripMenuItem_Click);
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem6,
            this.toolStripMenuItem9});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(65, 20);
            this.toolStripMenuItem2.Text = "&Derivates";
            this.toolStripMenuItem2.Visible = false;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem3.Text = "df(x)/dx";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItem4.Text = "o(h^2)";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItem5.Text = "o(h^4)";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem6.Text = "d²f(x)/dx²";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItem7.Text = "o(h^2)";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItem8.Text = "o(h^4)";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10});
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem9.Text = "d³f(x)/dx³";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItem10.Text = "o(h^2)";
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(31, 36);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(62, 20);
            this.textBoxA.TabIndex = 2;
            this.textBoxA.Text = "0";
            this.textBoxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(121, 36);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(62, 20);
            this.textBoxB.TabIndex = 3;
            this.textBoxB.Text = "5";
            this.textBoxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "a:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "b:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxReuse
            // 
            this.checkBoxReuse.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.checkBoxReuse.AutoSize = true;
            this.checkBoxReuse.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBoxReuse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxReuse.Location = new System.Drawing.Point(149, 76);
            this.checkBoxReuse.Name = "checkBoxReuse";
            this.checkBoxReuse.Size = new System.Drawing.Size(159, 18);
            this.checkBoxReuse.TabIndex = 6;
            this.checkBoxReuse.Text = "Reuse last graphic window";
            this.checkBoxReuse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 106);
            this.Controls.Add(this.checkBoxReuse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.95;
            this.Text = "NML3v11(SP041s)";
            this.TopMost = true;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tool_f;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem derivatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tool_df;
        private System.Windows.Forms.ToolStripMenuItem tool_d2f;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.ToolStripMenuItem tool_d3f;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxReuse;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
		private System.Windows.Forms.ToolStripMenuItem integrationToolStripMenuItem;


    }
}

