namespace ailab2
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbBFS = new System.Windows.Forms.RadioButton();
            this.rbHS = new System.Windows.Forms.RadioButton();
            this.rbDFS = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDist = new System.Windows.Forms.RadioButton();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxV0 = new System.Windows.Forms.TextBox();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.переборВШиринуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переборВГлубинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.упорядоченныйПоискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxFinish = new System.Windows.Forms.CheckBox();
            this.checkBoxStart = new System.Windows.Forms.CheckBox();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.textBoxC = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(562, 382);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxV0);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxLog);
            this.splitContainer1.Panel1.Controls.Add(this.buttonFind);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxFinish);
            this.splitContainer1.Panel1.Controls.Add(this.checkBoxStart);
            this.splitContainer1.Panel1.Controls.Add(this.buttonZoomIn);
            this.splitContainer1.Panel1.Controls.Add(this.buttonZoomOut);
            this.splitContainer1.Panel1.Controls.Add(this.buttonApply);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxN);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxH);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxC);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxB);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxA);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(880, 495);
            this.splitContainer1.SplitterDistance = 109;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbBFS);
            this.groupBox2.Controls.Add(this.rbHS);
            this.groupBox2.Controls.Add(this.rbDFS);
            this.groupBox2.Location = new System.Drawing.Point(617, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(113, 87);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // rbBFS
            // 
            this.rbBFS.AutoSize = true;
            this.rbBFS.Checked = true;
            this.rbBFS.Location = new System.Drawing.Point(15, 14);
            this.rbBFS.Name = "rbBFS";
            this.rbBFS.Size = new System.Drawing.Size(80, 17);
            this.rbBFS.TabIndex = 0;
            this.rbBFS.TabStop = true;
            this.rbBFS.Text = "breadth-first";
            this.rbBFS.UseVisualStyleBackColor = true;
            this.rbBFS.CheckedChanged += new System.EventHandler(this.rbBFS_CheckedChanged);
            // 
            // rbHS
            // 
            this.rbHS.AutoSize = true;
            this.rbHS.Location = new System.Drawing.Point(15, 60);
            this.rbHS.Name = "rbHS";
            this.rbHS.Size = new System.Drawing.Size(72, 17);
            this.rbHS.TabIndex = 0;
            this.rbHS.Text = "heuristical";
            this.rbHS.UseVisualStyleBackColor = true;
            this.rbHS.CheckedChanged += new System.EventHandler(this.rbHS_CheckedChanged);
            // 
            // rbDFS
            // 
            this.rbDFS.AutoSize = true;
            this.rbDFS.Location = new System.Drawing.Point(15, 37);
            this.rbDFS.Name = "rbDFS";
            this.rbDFS.Size = new System.Drawing.Size(77, 17);
            this.rbDFS.TabIndex = 0;
            this.rbDFS.Text = "deapth-first";
            this.rbDFS.UseVisualStyleBackColor = true;
            this.rbDFS.CheckedChanged += new System.EventHandler(this.rbDFS_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDist);
            this.groupBox1.Controls.Add(this.rbTime);
            this.groupBox1.Location = new System.Drawing.Point(736, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 78);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optimization";
            // 
            // rbDist
            // 
            this.rbDist.AutoSize = true;
            this.rbDist.Checked = true;
            this.rbDist.Location = new System.Drawing.Point(19, 24);
            this.rbDist.Name = "rbDist";
            this.rbDist.Size = new System.Drawing.Size(79, 17);
            this.rbDist.TabIndex = 0;
            this.rbDist.TabStop = true;
            this.rbDist.Text = "by distance";
            this.rbDist.UseVisualStyleBackColor = true;
            this.rbDist.CheckedChanged += new System.EventHandler(this.rbDist_CheckedChanged);
            // 
            // rbTime
            // 
            this.rbTime.AutoSize = true;
            this.rbTime.Location = new System.Drawing.Point(19, 47);
            this.rbTime.Name = "rbTime";
            this.rbTime.Size = new System.Drawing.Size(58, 17);
            this.rbTime.TabIndex = 0;
            this.rbTime.Text = "by time";
            this.rbTime.UseVisualStyleBackColor = true;
            this.rbTime.CheckedChanged += new System.EventHandler(this.rbTime_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(536, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "v0";
            // 
            // textBoxV0
            // 
            this.errorProvider.SetIconAlignment(this.textBoxV0, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.textBoxV0.Location = new System.Drawing.Point(539, 27);
            this.textBoxV0.Name = "textBoxV0";
            this.textBoxV0.Size = new System.Drawing.Size(72, 20);
            this.textBoxV0.TabIndex = 8;
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.AutoSize = true;
            this.checkBoxLog.Checked = true;
            this.checkBoxLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLog.Location = new System.Drawing.Point(509, 72);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(65, 17);
            this.checkBoxLog.TabIndex = 7;
            this.checkBoxLog.Text = "Verbose";
            this.checkBoxLog.UseVisualStyleBackColor = true;
            // 
            // buttonFind
            // 
            this.buttonFind.ContextMenuStrip = this.contextMenuStrip1;
            this.buttonFind.Location = new System.Drawing.Point(264, 68);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 6;
            this.buttonFind.Text = "Find!";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переборВШиринуToolStripMenuItem,
            this.переборВГлубинуToolStripMenuItem,
            this.упорядоченныйПоискToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 70);
            // 
            // переборВШиринуToolStripMenuItem
            // 
            this.переборВШиринуToolStripMenuItem.Name = "переборВШиринуToolStripMenuItem";
            this.переборВШиринуToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.переборВШиринуToolStripMenuItem.Text = "Перебор в ширину";
            // 
            // переборВГлубинуToolStripMenuItem
            // 
            this.переборВГлубинуToolStripMenuItem.Name = "переборВГлубинуToolStripMenuItem";
            this.переборВГлубинуToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.переборВГлубинуToolStripMenuItem.Text = "Перебор в глубину";
            // 
            // упорядоченныйПоискToolStripMenuItem
            // 
            this.упорядоченныйПоискToolStripMenuItem.Name = "упорядоченныйПоискToolStripMenuItem";
            this.упорядоченныйПоискToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.упорядоченныйПоискToolStripMenuItem.Text = "Упорядоченный поиск";
            // 
            // checkBoxFinish
            // 
            this.checkBoxFinish.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxFinish.AutoSize = true;
            this.checkBoxFinish.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBoxFinish.Location = new System.Drawing.Point(165, 68);
            this.checkBoxFinish.Name = "checkBoxFinish";
            this.checkBoxFinish.Size = new System.Drawing.Size(60, 23);
            this.checkBoxFinish.TabIndex = 5;
            this.checkBoxFinish.Text = "Set finish";
            this.checkBoxFinish.UseVisualStyleBackColor = true;
            this.checkBoxFinish.CheckedChanged += new System.EventHandler(this.checkBoxFinish_CheckedChanged);
            // 
            // checkBoxStart
            // 
            this.checkBoxStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxStart.AutoSize = true;
            this.checkBoxStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBoxStart.Location = new System.Drawing.Point(103, 68);
            this.checkBoxStart.Name = "checkBoxStart";
            this.checkBoxStart.Size = new System.Drawing.Size(56, 23);
            this.checkBoxStart.TabIndex = 5;
            this.checkBoxStart.Text = "Set start";
            this.checkBoxStart.UseVisualStyleBackColor = true;
            this.checkBoxStart.CheckedChanged += new System.EventHandler(this.checkBoxStart_CheckedChanged);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Location = new System.Drawing.Point(46, 68);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(27, 23);
            this.buttonZoomIn.TabIndex = 3;
            this.buttonZoomIn.Text = "+";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Location = new System.Drawing.Point(13, 68);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(27, 23);
            this.buttonZoomOut.TabIndex = 3;
            this.buttonZoomOut.Text = "–";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(393, 68);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(84, 23);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(433, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "h";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "c";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "b";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "a";
            // 
            // textBoxN
            // 
            this.errorProvider.SetIconAlignment(this.textBoxN, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.textBoxN.Location = new System.Drawing.Point(436, 27);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(72, 20);
            this.textBoxN.TabIndex = 0;
            this.textBoxN.Text = "5";
            // 
            // textBoxH
            // 
            this.errorProvider.SetIconAlignment(this.textBoxH, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.textBoxH.Location = new System.Drawing.Point(330, 27);
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.Size = new System.Drawing.Size(72, 20);
            this.textBoxH.TabIndex = 0;
            // 
            // textBoxC
            // 
            this.errorProvider.SetIconAlignment(this.textBoxC, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.textBoxC.Location = new System.Drawing.Point(224, 27);
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.Size = new System.Drawing.Size(72, 20);
            this.textBoxC.TabIndex = 0;
            // 
            // textBoxB
            // 
            this.errorProvider.SetIconAlignment(this.textBoxB, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.textBoxB.Location = new System.Drawing.Point(118, 27);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(72, 20);
            this.textBoxB.TabIndex = 0;
            // 
            // textBoxA
            // 
            this.errorProvider.SetIconAlignment(this.textBoxA, System.Windows.Forms.ErrorIconAlignment.BottomRight);
            this.textBoxA.Location = new System.Drawing.Point(12, 27);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(72, 20);
            this.textBoxA.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.textBoxLog);
            this.splitContainer2.Size = new System.Drawing.Size(880, 382);
            this.splitContainer2.SplitterDistance = 562;
            this.splitContainer2.TabIndex = 1;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(314, 382);
            this.textBoxLog.TabIndex = 0;
            this.textBoxLog.WordWrap = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 495);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "AI: lab2 (Hill)";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxH;
        private System.Windows.Forms.TextBox textBoxC;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox checkBoxStart;
        private System.Windows.Forms.CheckBox checkBoxFinish;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem переборВШиринуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переборВГлубинуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem упорядоченныйПоискToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.CheckBox checkBoxLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxV0;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDist;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbBFS;
        private System.Windows.Forms.RadioButton rbDFS;
        private System.Windows.Forms.RadioButton rbHS;
    }
}

