namespace NeuroGenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tbtMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbnTrainBackProp = new System.Windows.Forms.ToolStripMenuItem();
            this.tbnTrainNeuroNetwork = new System.Windows.Forms.ToolStripMenuItem();
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
            this.buttonClear = new System.Windows.Forms.Button();
            this.chkDigitizedView = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelCounter = new System.Windows.Forms.Label();
            this.labelNetError = new System.Windows.Forms.Label();
            this.labelEpoch = new System.Windows.Forms.Label();
            this.labelSure = new System.Windows.Forms.Label();
            this.backgroundWorkerTrain = new System.ComponentModel.BackgroundWorker();
            this.txtA = new System.Windows.Forms.TextBox();
            this.numGridN = new System.Windows.Forms.NumericUpDown();
            this.txtBias = new System.Windows.Forms.TextBox();
            this.txtEta = new System.Windows.Forms.TextBox();
            this.bnApplyEta = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGridN)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(664, 267);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(20, 17);
            label2.TabIndex = 18;
            label2.Text = "a:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(647, 297);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 17);
            label3.TabIndex = 18;
            label3.Text = "bias:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(652, 326);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(32, 17);
            label4.TabIndex = 18;
            label4.Text = "eta:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(424, 311);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(22, 17);
            label5.TabIndex = 19;
            label5.Text = "N:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(16, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(399, 369);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
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
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(767, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Visible = false;
            // 
            // tbtMode
            // 
            this.tbtMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtMode.Name = "tbtMode";
            this.tbtMode.Size = new System.Drawing.Size(113, 24);
            this.tbtMode.Text = "Learning mode";
            this.tbtMode.Visible = false;
            this.tbtMode.Click += new System.EventHandler(this.tbtMode_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbnTrainBackProp,
            this.tbnTrainNeuroNetwork});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(55, 24);
            this.toolStripButton1.Text = "Train";
            // 
            // tbnTrainBackProp
            // 
            this.tbnTrainBackProp.Name = "tbnTrainBackProp";
            this.tbnTrainBackProp.Size = new System.Drawing.Size(196, 24);
            this.tbnTrainBackProp.Text = "Back propagation";
            this.tbnTrainBackProp.Click += new System.EventHandler(this.tbnTrainBackProp_Click);
            // 
            // tbnTrainNeuroNetwork
            // 
            this.tbnTrainNeuroNetwork.Name = "tbnTrainNeuroNetwork";
            this.tbnTrainNeuroNetwork.Size = new System.Drawing.Size(196, 24);
            this.tbnTrainNeuroNetwork.Text = "Neuro network";
            this.tbnTrainNeuroNetwork.Click += new System.EventHandler(this.tbnTrainNeuroNetwork_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.comboBox1.Location = new System.Drawing.Point(424, 54);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 32);
            this.comboBox1.TabIndex = 2;
            // 
            // bnAdd
            // 
            this.bnAdd.Location = new System.Drawing.Point(424, 95);
            this.bnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.Size = new System.Drawing.Size(96, 48);
            this.bnAdd.TabIndex = 4;
            this.bnAdd.Text = "Add sample";
            this.bnAdd.UseVisualStyleBackColor = true;
            this.bnAdd.Click += new System.EventHandler(this.bnAdd_Click);
            // 
            // bnRecognize
            // 
            this.bnRecognize.Location = new System.Drawing.Point(648, 140);
            this.bnRecognize.Margin = new System.Windows.Forms.Padding(4);
            this.bnRecognize.Name = "bnRecognize";
            this.bnRecognize.Size = new System.Drawing.Size(100, 54);
            this.bnRecognize.TabIndex = 7;
            this.bnRecognize.Text = "Recognize";
            this.bnRecognize.UseVisualStyleBackColor = true;
            this.bnRecognize.Click += new System.EventHandler(this.bnRecognize_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.BackColor = System.Drawing.SystemColors.Info;
            this.txtAnswer.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAnswer.Location = new System.Drawing.Point(648, 54);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.ReadOnly = true;
            this.txtAnswer.Size = new System.Drawing.Size(99, 78);
            this.txtAnswer.TabIndex = 8;
            this.txtAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 415);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(767, 16);
            this.progressBar1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
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
            this.toolStrip2.Location = new System.Drawing.Point(424, 146);
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
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(424, 356);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(96, 48);
            this.buttonClear.TabIndex = 12;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // chkDigitizedView
            // 
            this.chkDigitizedView.AutoSize = true;
            this.chkDigitizedView.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkDigitizedView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkDigitizedView.Location = new System.Drawing.Point(541, 353);
            this.chkDigitizedView.Margin = new System.Windows.Forms.Padding(4);
            this.chkDigitizedView.Name = "chkDigitizedView";
            this.chkDigitizedView.Size = new System.Drawing.Size(66, 52);
            this.chkDigitizedView.TabIndex = 13;
            this.chkDigitizedView.Text = "Digitized\r\nview";
            this.chkDigitizedView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDigitizedView.UseVisualStyleBackColor = false;
            this.chkDigitizedView.CheckedChanged += new System.EventHandler(this.bnDigitizedView_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.trn";
            this.saveFileDialog1.Filter = "OCR Trainer|*.trn|All files|*.*";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "OCR Trainer|*.trn|All files|*.*";
            // 
            // labelCounter
            // 
            this.labelCounter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCounter.Location = new System.Drawing.Point(424, 177);
            this.labelCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(96, 28);
            this.labelCounter.TabIndex = 14;
            this.labelCounter.Text = "0 / 0";
            this.labelCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNetError
            // 
            this.labelNetError.AutoEllipsis = true;
            this.labelNetError.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNetError.Location = new System.Drawing.Point(424, 231);
            this.labelNetError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNetError.Name = "labelNetError";
            this.labelNetError.Size = new System.Drawing.Size(343, 28);
            this.labelNetError.TabIndex = 15;
            this.labelNetError.Text = "Net error: infinity";
            // 
            // labelEpoch
            // 
            this.labelEpoch.AutoEllipsis = true;
            this.labelEpoch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEpoch.Location = new System.Drawing.Point(451, 260);
            this.labelEpoch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEpoch.Name = "labelEpoch";
            this.labelEpoch.Size = new System.Drawing.Size(316, 28);
            this.labelEpoch.TabIndex = 15;
            this.labelEpoch.Text = "Epoch: 0";
            // 
            // labelSure
            // 
            this.labelSure.AutoSize = true;
            this.labelSure.Location = new System.Drawing.Point(644, 31);
            this.labelSure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSure.Name = "labelSure";
            this.labelSure.Size = new System.Drawing.Size(78, 17);
            this.labelSure.TabIndex = 10;
            this.labelSure.Text = "(Sureness)";
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
            this.txtA.Location = new System.Drawing.Point(693, 263);
            this.txtA.Margin = new System.Windows.Forms.Padding(4);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(53, 22);
            this.txtA.TabIndex = 16;
            this.txtA.Text = "1";
            // 
            // numGridN
            // 
            this.numGridN.Location = new System.Drawing.Point(455, 309);
            this.numGridN.Margin = new System.Windows.Forms.Padding(4);
            this.numGridN.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numGridN.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numGridN.Name = "numGridN";
            this.numGridN.Size = new System.Drawing.Size(55, 22);
            this.numGridN.TabIndex = 17;
            this.numGridN.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numGridN.ValueChanged += new System.EventHandler(this.numGridN_ValueChanged);
            // 
            // txtBias
            // 
            this.txtBias.Location = new System.Drawing.Point(693, 293);
            this.txtBias.Margin = new System.Windows.Forms.Padding(4);
            this.txtBias.Name = "txtBias";
            this.txtBias.Size = new System.Drawing.Size(53, 22);
            this.txtBias.TabIndex = 16;
            this.txtBias.Text = "1";
            // 
            // txtEta
            // 
            this.txtEta.Location = new System.Drawing.Point(693, 322);
            this.txtEta.Margin = new System.Windows.Forms.Padding(4);
            this.txtEta.Name = "txtEta";
            this.txtEta.Size = new System.Drawing.Size(53, 22);
            this.txtEta.TabIndex = 16;
            this.txtEta.Text = "1";
            // 
            // bnApplyEta
            // 
            this.bnApplyEta.Location = new System.Drawing.Point(711, 351);
            this.bnApplyEta.Margin = new System.Windows.Forms.Padding(0);
            this.bnApplyEta.Name = "bnApplyEta";
            this.bnApplyEta.Size = new System.Drawing.Size(37, 28);
            this.bnApplyEta.TabIndex = 20;
            this.bnApplyEta.Text = "ok";
            this.bnApplyEta.UseVisualStyleBackColor = true;
            this.bnApplyEta.Click += new System.EventHandler(this.bnApplyEta_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 431);
            this.Controls.Add(this.bnApplyEta);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.txtEta);
            this.Controls.Add(this.txtBias);
            this.Controls.Add(this.numGridN);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.labelEpoch);
            this.Controls.Add(this.labelNetError);
            this.Controls.Add(this.labelCounter);
            this.Controls.Add(this.chkDigitizedView);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.labelSure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.bnRecognize);
            this.Controls.Add(this.bnAdd);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Hand-written character reconition";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGridN)).EndInit();
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
        private System.Windows.Forms.Button buttonClear;
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
        private System.Windows.Forms.NumericUpDown numGridN;
        private System.Windows.Forms.TextBox txtBias;
        private System.Windows.Forms.TextBox txtEta;
        private System.Windows.Forms.Button bnApplyEta;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem tbnTrainBackProp;
        private System.Windows.Forms.ToolStripMenuItem tbnTrainNeuroNetwork;
    }
}

