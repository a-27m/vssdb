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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxStart = new System.Windows.Forms.CheckBox();
            this.checkBoxFinish = new System.Windows.Forms.CheckBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.переборВШиринуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переборВГлубинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.упорядоченныйПоискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(526, 387);
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
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(526, 495);
            this.splitContainer1.SplitterDistance = 104;
            this.splitContainer1.TabIndex = 1;
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
            this.buttonApply.Location = new System.Drawing.Point(424, 68);
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // checkBoxStart
            // 
            this.checkBoxStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxStart.AutoSize = true;
            this.checkBoxStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBoxStart.Location = new System.Drawing.Point(134, 68);
            this.checkBoxStart.Name = "checkBoxStart";
            this.checkBoxStart.Size = new System.Drawing.Size(56, 23);
            this.checkBoxStart.TabIndex = 5;
            this.checkBoxStart.Text = "Set start";
            this.checkBoxStart.UseVisualStyleBackColor = true;
            this.checkBoxStart.CheckedChanged += new System.EventHandler(this.checkBoxStart_CheckedChanged);
            // 
            // checkBoxFinish
            // 
            this.checkBoxFinish.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxFinish.AutoSize = true;
            this.checkBoxFinish.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBoxFinish.Location = new System.Drawing.Point(196, 68);
            this.checkBoxFinish.Name = "checkBoxFinish";
            this.checkBoxFinish.Size = new System.Drawing.Size(60, 23);
            this.checkBoxFinish.TabIndex = 5;
            this.checkBoxFinish.Text = "Set finish";
            this.checkBoxFinish.UseVisualStyleBackColor = true;
            this.checkBoxFinish.CheckedChanged += new System.EventHandler(this.checkBoxFinish_CheckedChanged);
            // 
            // buttonFind
            // 
            this.buttonFind.ContextMenuStrip = this.contextMenuStrip1;
            this.buttonFind.Location = new System.Drawing.Point(295, 68);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 70);
            // 
            // переборВШиринуToolStripMenuItem
            // 
            this.переборВШиринуToolStripMenuItem.Name = "переборВШиринуToolStripMenuItem";
            this.переборВШиринуToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.переборВШиринуToolStripMenuItem.Text = "Перебор в ширину";
            // 
            // переборВГлубинуToolStripMenuItem
            // 
            this.переборВГлубинуToolStripMenuItem.Name = "переборВГлубинуToolStripMenuItem";
            this.переборВГлубинуToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.переборВГлубинуToolStripMenuItem.Text = "Перебор в глубину";
            // 
            // упорядоченныйПоискToolStripMenuItem
            // 
            this.упорядоченныйПоискToolStripMenuItem.Name = "упорядоченныйПоискToolStripMenuItem";
            this.упорядоченныйПоискToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.упорядоченныйПоискToolStripMenuItem.Text = "Упорядоченный поиск";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 495);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "AI: lab2 (Hill)";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
    }
}

