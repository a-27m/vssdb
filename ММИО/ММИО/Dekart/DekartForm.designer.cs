namespace DekartGraphic
{
    partial class DekartForm
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
			System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DekartForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonPlus = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonMinus = new System.Windows.Forms.ToolStripButton();
			this.toolComboBoxZoom = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonLeft = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonRight = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonUp = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonDown = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonCenter = new System.Windows.Forms.ToolStripButton();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1.SuspendLayout();
			this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripStatusLabel1
			// 
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
			toolStripStatusLabel1.Text = "Current point:";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPlus,
            this.toolStripButtonMinus,
            this.toolComboBoxZoom});
			this.toolStrip1.Location = new System.Drawing.Point(131, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(180, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButtonPlus
			// 
			this.toolStripButtonPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonPlus.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButtonPlus.Image") ) );
			this.toolStripButtonPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonPlus.Name = "toolStripButtonPlus";
			this.toolStripButtonPlus.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonPlus.Text = "toolStripButton1";
			this.toolStripButtonPlus.ToolTipText = "Increases zoom";
			this.toolStripButtonPlus.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
			// 
			// toolStripButtonMinus
			// 
			this.toolStripButtonMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonMinus.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButtonMinus.Image") ) );
			this.toolStripButtonMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonMinus.Name = "toolStripButtonMinus";
			this.toolStripButtonMinus.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonMinus.Text = "toolStripButton1";
			this.toolStripButtonMinus.ToolTipText = "Decreases zoom";
			this.toolStripButtonMinus.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
			// 
			// toolComboBoxZoom
			// 
			this.toolComboBoxZoom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.toolComboBoxZoom.Items.AddRange(new object[] {
            "150",
            "100",
            "75",
            "50",
            "25",
            "10",
            "5",
            "2",
            "1"});
			this.toolComboBoxZoom.Name = "toolComboBoxZoom";
			this.toolComboBoxZoom.Size = new System.Drawing.Size(120, 25);
			this.toolComboBoxZoom.ToolTipText = "Zoom factor";
			this.toolComboBoxZoom.Leave += new System.EventHandler(this.toolStripComboBoxLeave_Click);
			this.toolComboBoxZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBox1_KeyPress);
			this.toolComboBoxZoom.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(406, 305);
			this.toolStripContainer1.ContentPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.toolStripContainer1.ContentPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.toolStripContainer1.ContentPanel.Resize += new System.EventHandler(this.DekartForm_Resize);
			this.toolStripContainer1.ContentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			this.toolStripContainer1.ContentPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// toolStripContainer1.LeftToolStripPanel
			// 
			this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip2);
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(432, 352);
			this.toolStripContainer1.TabIndex = 2;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip3);
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			this.toolStripContainer1.ClientSizeChanged += new System.EventHandler(this.DekartForm_Resize);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel1,
            this.toolStripStatusLabel2});
			this.statusStrip1.Location = new System.Drawing.Point(0, 0);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(432, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel2.Text = " ";
			// 
			// toolStrip2
			// 
			this.toolStrip2.AllowItemReorder = true;
			this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLeft,
            this.toolStripButtonRight,
            this.toolStripButtonUp,
            this.toolStripButtonDown,
            this.toolStripButtonCenter});
			this.toolStrip2.Location = new System.Drawing.Point(0, 3);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(26, 123);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// toolStripButtonLeft
			// 
			this.toolStripButtonLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonLeft.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButtonLeft.Image") ) );
			this.toolStripButtonLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonLeft.Name = "toolStripButtonLeft";
			this.toolStripButtonLeft.Size = new System.Drawing.Size(24, 20);
			this.toolStripButtonLeft.Text = "Left";
			this.toolStripButtonLeft.ToolTipText = "Shifts view to the left";
			this.toolStripButtonLeft.Click += new System.EventHandler(this.shiftRightToolStripMenuItem_Click);
			// 
			// toolStripButtonRight
			// 
			this.toolStripButtonRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonRight.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButtonRight.Image") ) );
			this.toolStripButtonRight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonRight.Name = "toolStripButtonRight";
			this.toolStripButtonRight.Size = new System.Drawing.Size(24, 20);
			this.toolStripButtonRight.Text = "Right";
			this.toolStripButtonRight.ToolTipText = "Shifts view to the right";
			this.toolStripButtonRight.Click += new System.EventHandler(this.shiftLeftToolStripMenuItem_Click);
			// 
			// toolStripButtonUp
			// 
			this.toolStripButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonUp.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButtonUp.Image") ) );
			this.toolStripButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonUp.Name = "toolStripButtonUp";
			this.toolStripButtonUp.Size = new System.Drawing.Size(24, 20);
			this.toolStripButtonUp.Text = "Up";
			this.toolStripButtonUp.ToolTipText = "Shifts view up";
			this.toolStripButtonUp.Click += new System.EventHandler(this.shiftDownToolStripMenuItem_Click);
			// 
			// toolStripButtonDown
			// 
			this.toolStripButtonDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonDown.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButtonDown.Image") ) );
			this.toolStripButtonDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonDown.Name = "toolStripButtonDown";
			this.toolStripButtonDown.Size = new System.Drawing.Size(24, 20);
			this.toolStripButtonDown.Text = "Down";
			this.toolStripButtonDown.ToolTipText = "Shifts view down";
			this.toolStripButtonDown.Click += new System.EventHandler(this.shiftUpToolStripMenuItem_Click);
			// 
			// toolStripButtonCenter
			// 
			this.toolStripButtonCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonCenter.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButtonCenter.Image") ) );
			this.toolStripButtonCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonCenter.Name = "toolStripButtonCenter";
			this.toolStripButtonCenter.Size = new System.Drawing.Size(24, 17);
			this.toolStripButtonCenter.Text = "\"0\"";
			this.toolStripButtonCenter.ToolTipText = "Center coordinate system in window";
			this.toolStripButtonCenter.Click += new System.EventHandler(this.toolStripButtonCenter_Click);
			// 
			// toolStrip3
			// 
			this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.toolStrip3.Location = new System.Drawing.Point(3, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(128, 25);
			this.toolStrip3.TabIndex = 1;
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = ( (System.Drawing.Image)( resources.GetObject("toolStripButton1.Image") ) );
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(116, 22);
			this.toolStripButton1.Text = "Save a snapshot…";
			this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton1.ToolTipText = "Saves current image to the file";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButtonSave_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "All files|*.*";
			this.saveFileDialog1.Title = "Save the snap";
			// 
			// DekartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 352);
			this.Controls.Add(this.toolStripContainer1);
			this.Name = "DekartForm";
			this.Text = "Graphic";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DekartForm_MouseClick);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlus;
        private System.Windows.Forms.ToolStripButton toolStripButtonMinus;
        private System.Windows.Forms.ToolStripComboBox toolComboBoxZoom;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonRight;
        private System.Windows.Forms.ToolStripButton toolStripButtonUp;
        private System.Windows.Forms.ToolStripButton toolStripButtonDown;
        private System.Windows.Forms.ToolStripButton toolStripButtonCenter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}