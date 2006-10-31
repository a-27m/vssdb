namespace Lab_03
{
	partial class FormIntgr
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBull = new System.Windows.Forms.RadioButton();
            this.textBox6Bull = new System.Windows.Forms.TextBox();
            this.radioRomberg = new System.Windows.Forms.RadioButton();
            this.textBox5Romberg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEval = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioGauss3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBox4Gauss3 = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.radioGauss2 = new System.Windows.Forms.RadioButton();
            this.radioSimpson = new System.Windows.Forms.RadioButton();
            this.radioTrapezium = new System.Windows.Forms.RadioButton();
            this.textBox3Gauss2 = new System.Windows.Forms.TextBox();
            this.textBox2Simp = new System.Windows.Forms.TextBox();
            this.textBox1Trap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
            this.textBox6BullDelta = new System.Windows.Forms.TextBox();
            this.textBox5RombergDelta = new System.Windows.Forms.TextBox();
            this.textBox4Gauss3Delta = new System.Windows.Forms.TextBox();
            this.textBox3Gauss2Delta = new System.Windows.Forms.TextBox();
            this.textBox2SimpDelta = new System.Windows.Forms.TextBox();
            this.textBox1TrapDelta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox6BullDelta);
            this.groupBox1.Controls.Add(this.textBox5RombergDelta);
            this.groupBox1.Controls.Add(this.textBox4Gauss3Delta);
            this.groupBox1.Controls.Add(this.textBox3Gauss2Delta);
            this.groupBox1.Controls.Add(this.textBox2SimpDelta);
            this.groupBox1.Controls.Add(this.textBox1TrapDelta);
            this.groupBox1.Controls.Add(this.radioBull);
            this.groupBox1.Controls.Add(this.textBox6Bull);
            this.groupBox1.Controls.Add(this.radioRomberg);
            this.groupBox1.Controls.Add(this.textBox5Romberg);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonEval);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radioGauss3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxB);
            this.groupBox1.Controls.Add(this.textBox4Gauss3);
            this.groupBox1.Controls.Add(this.textBoxA);
            this.groupBox1.Controls.Add(this.radioGauss2);
            this.groupBox1.Controls.Add(this.radioSimpson);
            this.groupBox1.Controls.Add(this.radioTrapezium);
            this.groupBox1.Controls.Add(this.textBox3Gauss2);
            this.groupBox1.Controls.Add(this.textBox2Simp);
            this.groupBox1.Controls.Add(this.textBox1Trap);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDownN);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 278);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Integration";
            // 
            // radioBull
            // 
            this.radioBull.AutoSize = true;
            this.radioBull.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBull.Location = new System.Drawing.Point(49, 124);
            this.radioBull.Name = "radioBull";
            this.radioBull.Size = new System.Drawing.Size(42, 17);
            this.radioBull.TabIndex = 15;
            this.radioBull.Text = "Bull";
            this.radioBull.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioBull.UseVisualStyleBackColor = true;
            this.radioBull.CheckedChanged += new System.EventHandler(this.buttonEval_Click);
            // 
            // textBox6Bull
            // 
            this.textBox6Bull.Location = new System.Drawing.Point(97, 123);
            this.textBox6Bull.Name = "textBox6Bull";
            this.textBox6Bull.Size = new System.Drawing.Size(100, 20);
            this.textBox6Bull.TabIndex = 14;
            // 
            // radioRomberg
            // 
            this.radioRomberg.AutoSize = true;
            this.radioRomberg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioRomberg.Location = new System.Drawing.Point(23, 202);
            this.radioRomberg.Name = "radioRomberg";
            this.radioRomberg.Size = new System.Drawing.Size(68, 17);
            this.radioRomberg.TabIndex = 13;
            this.radioRomberg.Text = "Romberg";
            this.radioRomberg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioRomberg.UseVisualStyleBackColor = true;
            this.radioRomberg.CheckedChanged += new System.EventHandler(this.buttonEval_Click);
            // 
            // textBox5Romberg
            // 
            this.textBox5Romberg.Location = new System.Drawing.Point(97, 201);
            this.textBox5Romberg.Name = "textBox5Romberg";
            this.textBox5Romberg.Size = new System.Drawing.Size(100, 20);
            this.textBox5Romberg.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Method:";
            // 
            // buttonEval
            // 
            this.buttonEval.Location = new System.Drawing.Point(108, 238);
            this.buttonEval.Name = "buttonEval";
            this.buttonEval.Size = new System.Drawing.Size(97, 28);
            this.buttonEval.TabIndex = 2;
            this.buttonEval.Text = "Evaluate";
            this.buttonEval.UseVisualStyleBackColor = true;
            this.buttonEval.Click += new System.EventHandler(this.buttonEval_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "b:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioGauss3
            // 
            this.radioGauss3.AutoSize = true;
            this.radioGauss3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioGauss3.Location = new System.Drawing.Point(10, 176);
            this.radioGauss3.Name = "radioGauss3";
            this.radioGauss3.Size = new System.Drawing.Size(81, 17);
            this.radioGauss3.TabIndex = 10;
            this.radioGauss3.Text = "Gauss 3 pts";
            this.radioGauss3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioGauss3.UseVisualStyleBackColor = true;
            this.radioGauss3.CheckedChanged += new System.EventHandler(this.buttonEval_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "a:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(130, 23);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(62, 20);
            this.textBoxB.TabIndex = 9;
            this.textBoxB.Text = "3";
            this.textBoxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox4Gauss3
            // 
            this.textBox4Gauss3.Location = new System.Drawing.Point(97, 175);
            this.textBox4Gauss3.Name = "textBox4Gauss3";
            this.textBox4Gauss3.Size = new System.Drawing.Size(100, 20);
            this.textBox4Gauss3.TabIndex = 9;
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(41, 23);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(62, 20);
            this.textBoxA.TabIndex = 8;
            this.textBoxA.Text = "1";
            this.textBoxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radioGauss2
            // 
            this.radioGauss2.AutoSize = true;
            this.radioGauss2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioGauss2.Location = new System.Drawing.Point(10, 150);
            this.radioGauss2.Name = "radioGauss2";
            this.radioGauss2.Size = new System.Drawing.Size(81, 17);
            this.radioGauss2.TabIndex = 8;
            this.radioGauss2.Text = "Gauss 2 pts";
            this.radioGauss2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioGauss2.UseVisualStyleBackColor = true;
            this.radioGauss2.CheckedChanged += new System.EventHandler(this.buttonEval_Click);
            // 
            // radioSimpson
            // 
            this.radioSimpson.AutoSize = true;
            this.radioSimpson.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioSimpson.Location = new System.Drawing.Point(26, 98);
            this.radioSimpson.Name = "radioSimpson";
            this.radioSimpson.Size = new System.Drawing.Size(65, 17);
            this.radioSimpson.TabIndex = 7;
            this.radioSimpson.Text = "Simpson";
            this.radioSimpson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioSimpson.UseVisualStyleBackColor = true;
            this.radioSimpson.CheckedChanged += new System.EventHandler(this.buttonEval_Click);
            // 
            // radioTrapezium
            // 
            this.radioTrapezium.AutoSize = true;
            this.radioTrapezium.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioTrapezium.Location = new System.Drawing.Point(17, 72);
            this.radioTrapezium.Name = "radioTrapezium";
            this.radioTrapezium.Size = new System.Drawing.Size(74, 17);
            this.radioTrapezium.TabIndex = 6;
            this.radioTrapezium.Text = "Trapezium";
            this.radioTrapezium.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioTrapezium.UseVisualStyleBackColor = true;
            this.radioTrapezium.CheckedChanged += new System.EventHandler(this.buttonEval_Click);
            // 
            // textBox3Gauss2
            // 
            this.textBox3Gauss2.Location = new System.Drawing.Point(97, 149);
            this.textBox3Gauss2.Name = "textBox3Gauss2";
            this.textBox3Gauss2.Size = new System.Drawing.Size(100, 20);
            this.textBox3Gauss2.TabIndex = 5;
            // 
            // textBox2Simp
            // 
            this.textBox2Simp.Location = new System.Drawing.Point(97, 97);
            this.textBox2Simp.Name = "textBox2Simp";
            this.textBox2Simp.Size = new System.Drawing.Size(100, 20);
            this.textBox2Simp.TabIndex = 4;
            // 
            // textBox1Trap
            // 
            this.textBox1Trap.Location = new System.Drawing.Point(97, 71);
            this.textBox1Trap.Name = "textBox1Trap";
            this.textBox1Trap.Size = new System.Drawing.Size(100, 20);
            this.textBox1Trap.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "n:";
            // 
            // numericUpDownN
            // 
            this.numericUpDownN.Location = new System.Drawing.Point(232, 24);
            this.numericUpDownN.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownN.Name = "numericUpDownN";
            this.numericUpDownN.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownN.TabIndex = 0;
            this.numericUpDownN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownN.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDownN.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // textBox6BullDelta
            // 
            this.textBox6BullDelta.Location = new System.Drawing.Point(203, 123);
            this.textBox6BullDelta.Name = "textBox6BullDelta";
            this.textBox6BullDelta.Size = new System.Drawing.Size(100, 20);
            this.textBox6BullDelta.TabIndex = 21;
            // 
            // textBox5RombergDelta
            // 
            this.textBox5RombergDelta.Location = new System.Drawing.Point(203, 201);
            this.textBox5RombergDelta.Name = "textBox5RombergDelta";
            this.textBox5RombergDelta.Size = new System.Drawing.Size(100, 20);
            this.textBox5RombergDelta.TabIndex = 20;
            // 
            // textBox4Gauss3Delta
            // 
            this.textBox4Gauss3Delta.Location = new System.Drawing.Point(203, 175);
            this.textBox4Gauss3Delta.Name = "textBox4Gauss3Delta";
            this.textBox4Gauss3Delta.Size = new System.Drawing.Size(100, 20);
            this.textBox4Gauss3Delta.TabIndex = 19;
            // 
            // textBox3Gauss2Delta
            // 
            this.textBox3Gauss2Delta.Location = new System.Drawing.Point(203, 149);
            this.textBox3Gauss2Delta.Name = "textBox3Gauss2Delta";
            this.textBox3Gauss2Delta.Size = new System.Drawing.Size(100, 20);
            this.textBox3Gauss2Delta.TabIndex = 18;
            // 
            // textBox2SimpDelta
            // 
            this.textBox2SimpDelta.Location = new System.Drawing.Point(203, 97);
            this.textBox2SimpDelta.Name = "textBox2SimpDelta";
            this.textBox2SimpDelta.Size = new System.Drawing.Size(100, 20);
            this.textBox2SimpDelta.TabIndex = 17;
            // 
            // textBox1TrapDelta
            // 
            this.textBox1TrapDelta.Location = new System.Drawing.Point(203, 71);
            this.textBox1TrapDelta.Name = "textBox1TrapDelta";
            this.textBox1TrapDelta.Size = new System.Drawing.Size(100, 20);
            this.textBox1TrapDelta.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Delta";
            // 
            // FormIntgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 304);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormIntgr";
            this.Text = "Specify bounds and press evaluate";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4Gauss3;
		private System.Windows.Forms.TextBox textBox3Gauss2;
		private System.Windows.Forms.TextBox textBox2Simp;
		private System.Windows.Forms.TextBox textBox1Trap;
		private System.Windows.Forms.Button buttonEval;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDownN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxB;
		private System.Windows.Forms.TextBox textBoxA;
		private System.Windows.Forms.RadioButton radioGauss3;
		private System.Windows.Forms.RadioButton radioGauss2;
		private System.Windows.Forms.RadioButton radioSimpson;
		private System.Windows.Forms.RadioButton radioTrapezium;
        private System.Windows.Forms.RadioButton radioRomberg;
        private System.Windows.Forms.TextBox textBox5Romberg;
        private System.Windows.Forms.RadioButton radioBull;
        private System.Windows.Forms.TextBox textBox6Bull;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6BullDelta;
        private System.Windows.Forms.TextBox textBox5RombergDelta;
        private System.Windows.Forms.TextBox textBox4Gauss3Delta;
        private System.Windows.Forms.TextBox textBox3Gauss2Delta;
        private System.Windows.Forms.TextBox textBox2SimpDelta;
        private System.Windows.Forms.TextBox textBox1TrapDelta;
	}
}