namespace Lab_02
{
    partial class Form2
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.GroupBox groupBox2;
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.numericN = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approximateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taylorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lagrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newtoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chebyshevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericN)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(16, 13);
            label1.TabIndex = 0;
            label1.Text = "a:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(70, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(16, 13);
            label2.TabIndex = 1;
            label2.Text = "b:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(149, 16);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(16, 13);
            label3.TabIndex = 2;
            label3.Text = "n:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(this.textBoxB);
            groupBox2.Controls.Add(this.textBoxA);
            groupBox2.Controls.Add(this.numericN);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new System.Drawing.Point(12, 27);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(210, 77);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Parameters";
            // 
            // textBoxB
            // 
            this.textBoxB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxB.Location = new System.Drawing.Point(73, 32);
            this.textBoxB.MaxLength = 4;
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(42, 20);
            this.textBoxB.TabIndex = 5;
            this.textBoxB.Text = "2";
            this.textBoxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxA
            // 
            this.textBoxA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxA.Location = new System.Drawing.Point(15, 32);
            this.textBoxA.MaxLength = 4;
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(42, 20);
            this.textBoxA.TabIndex = 4;
            this.textBoxA.Text = "0";
            this.textBoxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericN
            // 
            this.numericN.Location = new System.Drawing.Point(152, 32);
            this.numericN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericN.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericN.Name = "numericN";
            this.numericN.Size = new System.Drawing.Size(42, 20);
            this.numericN.TabIndex = 3;
            this.numericN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericN.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.showFxToolStripMenuItem,
            this.approximateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(235, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // showFxToolStripMenuItem
            // 
            this.showFxToolStripMenuItem.Name = "showFxToolStripMenuItem";
            this.showFxToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.showFxToolStripMenuItem.Text = "Show f(x)";
            this.showFxToolStripMenuItem.Click += new System.EventHandler(this.buttonTask1_Click);
            // 
            // approximateToolStripMenuItem
            // 
            this.approximateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taylorToolStripMenuItem,
            this.toolStripSeparator1,
            this.lagrangeToolStripMenuItem,
            this.newtoneToolStripMenuItem,
            this.chebyshevToolStripMenuItem,
            this.splinesToolStripMenuItem});
            this.approximateToolStripMenuItem.Name = "approximateToolStripMenuItem";
            this.approximateToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.approximateToolStripMenuItem.Text = "Approximate";
            // 
            // taylorToolStripMenuItem
            // 
            this.taylorToolStripMenuItem.Name = "taylorToolStripMenuItem";
            this.taylorToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.taylorToolStripMenuItem.Text = "Taylor";
            this.taylorToolStripMenuItem.Click += new System.EventHandler(this.buttonTaylor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // lagrangeToolStripMenuItem
            // 
            this.lagrangeToolStripMenuItem.Name = "lagrangeToolStripMenuItem";
            this.lagrangeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.lagrangeToolStripMenuItem.Text = "Lagrange";
            this.lagrangeToolStripMenuItem.Click += new System.EventHandler(this.buttonLagr_Click);
            // 
            // newtoneToolStripMenuItem
            // 
            this.newtoneToolStripMenuItem.Name = "newtoneToolStripMenuItem";
            this.newtoneToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.newtoneToolStripMenuItem.Text = "Newtone";
            this.newtoneToolStripMenuItem.Click += new System.EventHandler(this.buttonNewtone_Click);
            // 
            // chebyshevToolStripMenuItem
            // 
            this.chebyshevToolStripMenuItem.Name = "chebyshevToolStripMenuItem";
            this.chebyshevToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.chebyshevToolStripMenuItem.Text = "Chebyshev";
            this.chebyshevToolStripMenuItem.Click += new System.EventHandler(this.buttonChe_Click);
            // 
            // splinesToolStripMenuItem
            // 
            this.splinesToolStripMenuItem.Name = "splinesToolStripMenuItem";
            this.splinesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.splinesToolStripMenuItem.Text = "Splines";
            this.splinesToolStripMenuItem.Click += new System.EventHandler(this.buttonSplines_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(235, 119);
            this.Controls.Add(groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "l.2, var. 11";
            this.TopMost = true;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericN)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem approximateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taylorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lagrangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newtoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chebyshevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splinesToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericN;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

    }
}

