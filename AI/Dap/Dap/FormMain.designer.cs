namespace Dap
{
    partial class FormMain
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tbtMode = new System.Windows.Forms.ToolStripButton();
            this.tbnTrain = new System.Windows.Forms.ToolStripButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bnAdd = new System.Windows.Forms.Button();
            this.bnRecognize = new System.Windows.Forms.Button();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.bnPrev = new System.Windows.Forms.ToolStripButton();
            this.bnNext = new System.Windows.Forms.ToolStripButton();
            this.bnRemove = new System.Windows.Forms.ToolStripButton();
            this.buttonClearA = new System.Windows.Forms.Button();
            this.chkDigitizedView = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelCounter = new System.Windows.Forms.Label();
            this.labelNetError = new System.Windows.Forms.Label();
            this.labelEpoch = new System.Windows.Forms.Label();
            this.labelSure = new System.Windows.Forms.Label();
            this.backgroundWorkerTrain = new System.ComponentModel.BackgroundWorker();
            this.txtA = new System.Windows.Forms.TextBox();
            this.numGridNa = new System.Windows.Forms.NumericUpDown();
            this.txtBias = new System.Windows.Forms.TextBox();
            this.txtEta = new System.Windows.Forms.TextBox();
            this.bnApplyEta = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bnRecognizeB = new System.Windows.Forms.Button();
            this.bnClearB = new System.Windows.Forms.Button();
            this.numGridNb = new System.Windows.Forms.NumericUpDown();
            this.labelRound = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGridNa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGridNb)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(464, 426);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(16, 14);
            label2.TabIndex = 18;
            label2.Text = "a:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(451, 452);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(30, 14);
            label3.TabIndex = 18;
            label3.Text = "bias:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(455, 478);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(25, 14);
            label4.TabIndex = 18;
            label4.Text = "eta:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(42, 459);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(17, 14);
            label5.TabIndex = 19;
            label5.Text = "N:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(463, 382);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(17, 14);
            label6.TabIndex = 19;
            label6.Text = "N:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 323);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.copyToolStripButton,
            this.tbtMode,
            this.tbnTrain});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(651, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Visible = false;
            // 
            // tbtMode
            // 
            this.tbtMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtMode.Name = "tbtMode";
            this.tbtMode.Size = new System.Drawing.Size(81, 22);
            this.tbtMode.Text = "Learning mode";
            this.tbtMode.Visible = false;
            this.tbtMode.Click += new System.EventHandler(this.tbtMode_Click);
            // 
            // tbnTrain
            // 
            this.tbnTrain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbnTrain.Image = ((System.Drawing.Image)(resources.GetObject("tbnTrain.Image")));
            this.tbnTrain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnTrain.Name = "tbnTrain";
            this.tbnTrain.Size = new System.Drawing.Size(47, 22);
            this.tbnTrain.Text = "Train...";
            this.tbnTrain.Click += new System.EventHandler(this.tbnTrain_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.comboBox1.Location = new System.Drawing.Point(305, 571);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 27);
            this.comboBox1.TabIndex = 2;
            // 
            // bnAdd
            // 
            this.bnAdd.Location = new System.Drawing.Point(288, 423);
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.Size = new System.Drawing.Size(72, 42);
            this.bnAdd.TabIndex = 4;
            this.bnAdd.Text = "Add pair";
            this.bnAdd.UseVisualStyleBackColor = true;
            this.bnAdd.Click += new System.EventHandler(this.bnAdd_Click);
            // 
            // bnRecognize
            // 
            this.bnRecognize.Location = new System.Drawing.Point(237, 360);
            this.bnRecognize.Name = "bnRecognize";
            this.bnRecognize.Size = new System.Drawing.Size(75, 47);
            this.bnRecognize.TabIndex = 7;
            this.bnRecognize.Text = "Recognize";
            this.bnRecognize.UseVisualStyleBackColor = true;
            this.bnRecognize.Click += new System.EventHandler(this.bnRecognizeA_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.BackColor = System.Drawing.SystemColors.Info;
            this.txtAnswer.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAnswer.Location = new System.Drawing.Point(201, 538);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.ReadOnly = true;
            this.txtAnswer.Size = new System.Drawing.Size(75, 64);
            this.txtAnswer.TabIndex = 8;
            this.txtAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAnswer.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 542);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(651, 14);
            this.progressBar1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 554);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Char";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bnPrev,
            this.bnNext,
            this.bnRemove});
            this.toolStrip2.Location = new System.Drawing.Point(288, 468);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(72, 25);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // bnPrev
            // 
            this.bnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnPrev.Image = ((System.Drawing.Image)(resources.GetObject("bnPrev.Image")));
            this.bnPrev.Name = "bnPrev";
            this.bnPrev.RightToLeftAutoMirrorImage = true;
            this.bnPrev.Size = new System.Drawing.Size(23, 22);
            this.bnPrev.Text = "Move previous";
            this.bnPrev.Click += new System.EventHandler(this.bnPrev_Click);
            // 
            // bnNext
            // 
            this.bnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnNext.Image = ((System.Drawing.Image)(resources.GetObject("bnNext.Image")));
            this.bnNext.Name = "bnNext";
            this.bnNext.RightToLeftAutoMirrorImage = true;
            this.bnNext.Size = new System.Drawing.Size(23, 22);
            this.bnNext.Text = "Move next";
            this.bnNext.Click += new System.EventHandler(this.bnNext_Click);
            // 
            // bnRemove
            // 
            this.bnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bnRemove.Image = ((System.Drawing.Image)(resources.GetObject("bnRemove.Image")));
            this.bnRemove.Name = "bnRemove";
            this.bnRemove.RightToLeftAutoMirrorImage = true;
            this.bnRemove.Size = new System.Drawing.Size(23, 22);
            this.bnRemove.Text = "Delete";
            this.bnRemove.Click += new System.EventHandler(this.bnRemove_Click);
            // 
            // buttonClearA
            // 
            this.buttonClearA.Location = new System.Drawing.Point(12, 360);
            this.buttonClearA.Name = "buttonClearA";
            this.buttonClearA.Size = new System.Drawing.Size(72, 42);
            this.buttonClearA.TabIndex = 12;
            this.buttonClearA.Text = "Clear A";
            this.buttonClearA.UseVisualStyleBackColor = true;
            this.buttonClearA.Click += new System.EventHandler(this.buttonClearA_Click);
            // 
            // chkDigitizedView
            // 
            this.chkDigitizedView.AutoSize = true;
            this.chkDigitizedView.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkDigitizedView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDigitizedView.Location = new System.Drawing.Point(126, 457);
            this.chkDigitizedView.Name = "chkDigitizedView";
            this.chkDigitizedView.Size = new System.Drawing.Size(51, 44);
            this.chkDigitizedView.TabIndex = 13;
            this.chkDigitizedView.Text = "Digitized\r\nview";
            this.chkDigitizedView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDigitizedView.UseVisualStyleBackColor = false;
            this.chkDigitizedView.CheckedChanged += new System.EventHandler(this.bnDigitizedView_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.trn5";
            this.saveFileDialog1.FileName = "untitled";
            this.saveFileDialog1.Filter = "BAM Pairs|*.trn5|All files|*.*";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "untitled";
            this.openFileDialog1.Filter = "BAM Pairs|*.trn5|All files|*.*";
            // 
            // labelCounter
            // 
            this.labelCounter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCounter.Location = new System.Drawing.Point(288, 495);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(72, 25);
            this.labelCounter.TabIndex = 14;
            this.labelCounter.Text = "0 / 0";
            this.labelCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNetError
            // 
            this.labelNetError.AutoEllipsis = true;
            this.labelNetError.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNetError.Location = new System.Drawing.Point(416, 571);
            this.labelNetError.Name = "labelNetError";
            this.labelNetError.Size = new System.Drawing.Size(257, 25);
            this.labelNetError.TabIndex = 15;
            this.labelNetError.Text = "Net error: infinity";
            // 
            // labelEpoch
            // 
            this.labelEpoch.AutoEllipsis = true;
            this.labelEpoch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEpoch.Location = new System.Drawing.Point(436, 596);
            this.labelEpoch.Name = "labelEpoch";
            this.labelEpoch.Size = new System.Drawing.Size(237, 25);
            this.labelEpoch.TabIndex = 15;
            this.labelEpoch.Text = "Epoch: 0";
            // 
            // labelSure
            // 
            this.labelSure.AutoSize = true;
            this.labelSure.Location = new System.Drawing.Point(198, 521);
            this.labelSure.Name = "labelSure";
            this.labelSure.Size = new System.Drawing.Size(62, 14);
            this.labelSure.TabIndex = 10;
            this.labelSure.Text = "(Sureness)";
            this.labelSure.Visible = false;
            // 
            // backgroundWorkerTrain
            // 
            this.backgroundWorkerTrain.WorkerReportsProgress = true;
            this.backgroundWorkerTrain.WorkerSupportsCancellation = true;
            this.backgroundWorkerTrain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorkerTrain.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorkerTrain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTrain_RunWorkerCompleted);
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(486, 423);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(41, 20);
            this.txtA.TabIndex = 16;
            this.txtA.Text = "1";
            // 
            // numGridNa
            // 
            this.numGridNa.Location = new System.Drawing.Point(65, 457);
            this.numGridNa.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numGridNa.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numGridNa.Name = "numGridNa";
            this.numGridNa.Size = new System.Drawing.Size(41, 20);
            this.numGridNa.TabIndex = 17;
            this.numGridNa.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numGridNa.ValueChanged += new System.EventHandler(this.numGridNa_ValueChanged);
            // 
            // txtBias
            // 
            this.txtBias.Location = new System.Drawing.Point(486, 449);
            this.txtBias.Name = "txtBias";
            this.txtBias.Size = new System.Drawing.Size(41, 20);
            this.txtBias.TabIndex = 16;
            this.txtBias.Text = "1";
            // 
            // txtEta
            // 
            this.txtEta.Location = new System.Drawing.Point(486, 475);
            this.txtEta.Name = "txtEta";
            this.txtEta.Size = new System.Drawing.Size(41, 20);
            this.txtEta.TabIndex = 16;
            this.txtEta.Text = "1";
            // 
            // bnApplyEta
            // 
            this.bnApplyEta.Location = new System.Drawing.Point(499, 500);
            this.bnApplyEta.Margin = new System.Windows.Forms.Padding(0);
            this.bnApplyEta.Name = "bnApplyEta";
            this.bnApplyEta.Size = new System.Drawing.Size(28, 25);
            this.bnApplyEta.TabIndex = 20;
            this.bnApplyEta.Text = "ok";
            this.bnApplyEta.UseVisualStyleBackColor = true;
            this.bnApplyEta.Click += new System.EventHandler(this.bnApplyEta_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(337, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 323);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // bnRecognizeB
            // 
            this.bnRecognizeB.Location = new System.Drawing.Point(562, 360);
            this.bnRecognizeB.Name = "bnRecognizeB";
            this.bnRecognizeB.Size = new System.Drawing.Size(75, 47);
            this.bnRecognizeB.TabIndex = 7;
            this.bnRecognizeB.Text = "Recognize";
            this.bnRecognizeB.UseVisualStyleBackColor = true;
            this.bnRecognizeB.Click += new System.EventHandler(this.bnRecognizeB_Click);
            // 
            // bnClearB
            // 
            this.bnClearB.Location = new System.Drawing.Point(337, 360);
            this.bnClearB.Name = "bnClearB";
            this.bnClearB.Size = new System.Drawing.Size(72, 42);
            this.bnClearB.TabIndex = 12;
            this.bnClearB.Text = "Clear B";
            this.bnClearB.UseVisualStyleBackColor = true;
            this.bnClearB.Click += new System.EventHandler(this.bnClearB_Click);
            // 
            // numGridNb
            // 
            this.numGridNb.Location = new System.Drawing.Point(486, 380);
            this.numGridNb.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numGridNb.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numGridNb.Name = "numGridNb";
            this.numGridNb.Size = new System.Drawing.Size(41, 20);
            this.numGridNb.TabIndex = 17;
            this.numGridNb.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numGridNb.ValueChanged += new System.EventHandler(this.numGridNb_ValueChanged);
            // 
            // labelRound
            // 
            this.labelRound.AutoSize = true;
            this.labelRound.Location = new System.Drawing.Point(27, 505);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(38, 14);
            this.labelRound.TabIndex = 21;
            this.labelRound.Text = "Ready";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 556);
            this.Controls.Add(this.labelRound);
            this.Controls.Add(this.bnApplyEta);
            this.Controls.Add(label6);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.txtEta);
            this.Controls.Add(this.txtBias);
            this.Controls.Add(this.numGridNb);
            this.Controls.Add(this.numGridNa);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.labelEpoch);
            this.Controls.Add(this.labelNetError);
            this.Controls.Add(this.labelCounter);
            this.Controls.Add(this.chkDigitizedView);
            this.Controls.Add(this.bnClearB);
            this.Controls.Add(this.buttonClearA);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.labelSure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.bnRecognizeB);
            this.Controls.Add(this.bnRecognize);
            this.Controls.Add(this.bnAdd);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "л5: BAM (ДАП)";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGridNa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGridNb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.ToolStripButton tbtMode;
        private System.Windows.Forms.Button bnRecognize;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton bnPrev;
        private System.Windows.Forms.ToolStripButton bnNext;
        private System.Windows.Forms.ToolStripButton tbnTrain;
        private System.Windows.Forms.Button buttonClearA;
        private System.Windows.Forms.CheckBox chkDigitizedView;
        private System.Windows.Forms.ToolStripButton bnRemove;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelCounter;
        private System.Windows.Forms.Label labelNetError;
        private System.Windows.Forms.Label labelEpoch;
        private System.Windows.Forms.Label labelSure;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTrain;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.NumericUpDown numGridNa;
        private System.Windows.Forms.TextBox txtBias;
        private System.Windows.Forms.TextBox txtEta;
        private System.Windows.Forms.Button bnApplyEta;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button bnRecognizeB;
        private System.Windows.Forms.Button bnClearB;
        private System.Windows.Forms.NumericUpDown numGridNb;
        private System.Windows.Forms.Label labelRound;
    }
}

