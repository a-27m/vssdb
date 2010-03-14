namespace cglr3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonDraw = new System.Windows.Forms.ToolStripButton();
            this.buttonBreak = new System.Windows.Forms.ToolStripButton();
            this.buttonClear = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonResultAsInput = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(696, 518);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDraw,
            this.buttonBreak,
            this.buttonClear,
            this.buttonResultAsInput});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(696, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonDraw
            // 
            this.buttonDraw.Image = ((System.Drawing.Image)(resources.GetObject("buttonDraw.Image")));
            this.buttonDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(52, 22);
            this.buttonDraw.Text = "Draw";
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // buttonBreak
            // 
            this.buttonBreak.Image = ((System.Drawing.Image)(resources.GetObject("buttonBreak.Image")));
            this.buttonBreak.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBreak.Name = "buttonBreak";
            this.buttonBreak.Size = new System.Drawing.Size(54, 22);
            this.buttonBreak.Text = "Break";
            this.buttonBreak.Click += new System.EventHandler(this.buttonBreak_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Image = ((System.Drawing.Image)(resources.GetObject("buttonClear.Image")));
            this.buttonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(52, 22);
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonResultAsInput
            // 
            this.buttonResultAsInput.Image = ((System.Drawing.Image)(resources.GetObject("buttonResultAsInput.Image")));
            this.buttonResultAsInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonResultAsInput.Name = "buttonResultAsInput";
            this.buttonResultAsInput.Size = new System.Drawing.Size(124, 22);
            this.buttonResultAsInput.Text = "Use current as input";
            this.buttonResultAsInput.Click += new System.EventHandler(this.buttonResultAsInput_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 518);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "cglr3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonDraw;
        private System.Windows.Forms.ToolStripButton buttonBreak;
        private System.Windows.Forms.ToolStripButton buttonClear;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton buttonResultAsInput;
    }
}

