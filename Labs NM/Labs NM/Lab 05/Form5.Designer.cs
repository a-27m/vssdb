namespace Lab_05
{
	partial class Form5
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.GroupBox groupBox2;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label label7;
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textE = new System.Windows.Forms.TextBox();
			this.groupFirstApproximation = new System.Windows.Forms.GroupBox();
			this.checkPick = new System.Windows.Forms.CheckBox();
			this.textX0 = new System.Windows.Forms.TextBox();
			this.textY0 = new System.Windows.Forms.TextBox();
			this.groupInterval = new System.Windows.Forms.GroupBox();
			this.textX1 = new System.Windows.Forms.TextBox();
			this.textX2 = new System.Windows.Forms.TextBox();
			this.textBoxFx = new System.Windows.Forms.TextBox();
			this.buttonSolve = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.listY = new System.Windows.Forms.ListBox();
			this.listRoots = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkSpeedUp = new System.Windows.Forms.CheckBox();
			this.radioStillPt = new System.Windows.Forms.RadioButton();
			this.radioNewtone = new System.Windows.Forms.RadioButton();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			groupBox2 = new System.Windows.Forms.GroupBox();
			label4 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			groupBox2.SuspendLayout();
			this.groupFirstApproximation.SuspendLayout();
			this.groupInterval.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(this.textBox1);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(label1);
			groupBox2.Controls.Add(this.textE);
			groupBox2.Controls.Add(this.groupFirstApproximation);
			groupBox2.Controls.Add(this.groupInterval);
			groupBox2.Controls.Add(this.textBoxFx);
			groupBox2.Controls.Add(label7);
			groupBox2.Location = new System.Drawing.Point(173, 12);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(346, 207);
			groupBox2.TabIndex = 8;
			groupBox2.TabStop = false;
			groupBox2.Text = "Параметры";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(75, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 23;
			this.textBox1.Text = "sqrt(y+7)*cos(y) – x";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(34, 51);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(35, 13);
			label4.TabIndex = 22;
			label4.Text = "f2(x,y)";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Symbol", 10F);
			label1.Location = new System.Drawing.Point(202, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(14, 17);
			label1.TabIndex = 17;
			label1.Text = "&e";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textE
			// 
			this.textE.Location = new System.Drawing.Point(222, 22);
			this.textE.Name = "textE";
			this.textE.Size = new System.Drawing.Size(100, 20);
			this.textE.TabIndex = 18;
			this.textE.Text = "1";
			// 
			// groupFirstApproximation
			// 
			this.groupFirstApproximation.Controls.Add(this.checkPick);
			this.groupFirstApproximation.Controls.Add(label2);
			this.groupFirstApproximation.Controls.Add(this.textX0);
			this.groupFirstApproximation.Controls.Add(label3);
			this.groupFirstApproximation.Controls.Add(this.textY0);
			this.groupFirstApproximation.Location = new System.Drawing.Point(17, 86);
			this.groupFirstApproximation.Name = "groupFirstApproximation";
			this.groupFirstApproximation.Size = new System.Drawing.Size(158, 108);
			this.groupFirstApproximation.TabIndex = 15;
			this.groupFirstApproximation.TabStop = false;
			this.groupFirstApproximation.Text = "Начальное приближение";
			// 
			// checkPick
			// 
			this.checkPick.AutoSize = true;
			this.checkPick.Location = new System.Drawing.Point(16, 85);
			this.checkPick.Name = "checkPick";
			this.checkPick.Size = new System.Drawing.Size(115, 17);
			this.checkPick.TabIndex = 5;
			this.checkPick.Text = "Pick up graphically";
			this.checkPick.UseVisualStyleBackColor = true;
			this.checkPick.CheckedChanged += new System.EventHandler(this.checkPick_CheckedChanged);
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(6, 22);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(18, 13);
			label2.TabIndex = 1;
			label2.Text = "x0";
			// 
			// textX0
			// 
			this.textX0.Location = new System.Drawing.Point(31, 19);
			this.textX0.Name = "textX0";
			this.textX0.Size = new System.Drawing.Size(100, 20);
			this.textX0.TabIndex = 2;
			this.textX0.Text = "0";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(6, 48);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(18, 13);
			label3.TabIndex = 3;
			label3.Text = "y0";
			// 
			// textY0
			// 
			this.textY0.Location = new System.Drawing.Point(31, 45);
			this.textY0.Name = "textY0";
			this.textY0.Size = new System.Drawing.Size(100, 20);
			this.textY0.TabIndex = 4;
			this.textY0.Text = "0";
			// 
			// groupInterval
			// 
			this.groupInterval.Controls.Add(label8);
			this.groupInterval.Controls.Add(this.textX1);
			this.groupInterval.Controls.Add(label9);
			this.groupInterval.Controls.Add(this.textX2);
			this.groupInterval.Location = new System.Drawing.Point(197, 86);
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
			this.textBoxFx.Location = new System.Drawing.Point(75, 22);
			this.textBoxFx.Name = "textBoxFx";
			this.textBoxFx.ReadOnly = true;
			this.textBoxFx.Size = new System.Drawing.Size(100, 20);
			this.textBoxFx.TabIndex = 12;
			this.textBoxFx.Text = "x^3 – 2sin(x) – y";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(34, 25);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(35, 13);
			label7.TabIndex = 11;
			label7.Text = "f1(x,y)";
			// 
			// buttonSolve
			// 
			this.buttonSolve.Location = new System.Drawing.Point(18, 177);
			this.buttonSolve.Name = "buttonSolve";
			this.buttonSolve.Size = new System.Drawing.Size(100, 23);
			this.buttonSolve.TabIndex = 20;
			this.buttonSolve.Text = "&Найти";
			this.buttonSolve.UseVisualStyleBackColor = true;
			this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.listY);
			this.groupBox5.Controls.Add(this.listRoots);
			this.groupBox5.Location = new System.Drawing.Point(12, 225);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(506, 151);
			this.groupBox5.TabIndex = 21;
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
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkSpeedUp);
			this.groupBox1.Controls.Add(this.radioStillPt);
			this.groupBox1.Controls.Add(this.radioNewtone);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(155, 120);
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Метод";
			// 
			// checkSpeedUp
			// 
			this.checkSpeedUp.AutoSize = true;
			this.checkSpeedUp.Location = new System.Drawing.Point(24, 42);
			this.checkSpeedUp.Name = "checkSpeedUp";
			this.checkSpeedUp.Size = new System.Drawing.Size(72, 17);
			this.checkSpeedUp.TabIndex = 23;
			this.checkSpeedUp.Text = "Speed up";
			this.checkSpeedUp.UseVisualStyleBackColor = true;
			// 
			// radioStillPt
			// 
			this.radioStillPt.AutoSize = true;
			this.radioStillPt.Checked = true;
			this.radioStillPt.Location = new System.Drawing.Point(6, 19);
			this.radioStillPt.Name = "radioStillPt";
			this.radioStillPt.Size = new System.Drawing.Size(124, 17);
			this.radioStillPt.TabIndex = 1;
			this.radioStillPt.TabStop = true;
			this.radioStillPt.Text = "неподвижной &точки";
			this.radioStillPt.UseVisualStyleBackColor = true;
			this.radioStillPt.CheckedChanged += new System.EventHandler(this.radioStillPt_CheckedChanged);
			// 
			// radioNewtone
			// 
			this.radioNewtone.AutoSize = true;
			this.radioNewtone.Location = new System.Drawing.Point(6, 75);
			this.radioNewtone.Name = "radioNewtone";
			this.radioNewtone.Size = new System.Drawing.Size(70, 17);
			this.radioNewtone.TabIndex = 3;
			this.radioNewtone.TabStop = true;
			this.radioNewtone.Text = "&Ньютона";
			this.radioNewtone.UseVisualStyleBackColor = true;
			this.radioNewtone.CheckedChanged += new System.EventHandler(this.radioNewtone_CheckedChanged);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// Form5
			// 
			this.AcceptButton = this.buttonSolve;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(531, 388);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonSolve);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(groupBox2);
			this.MaximizeBox = false;
			this.Name = "Form5";
			this.Text = "NMLW#5@11";
			this.Load += new System.EventHandler(this.Form5_Load);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			this.groupFirstApproximation.ResumeLayout(false);
			this.groupFirstApproximation.PerformLayout();
			this.groupInterval.ResumeLayout(false);
			this.groupInterval.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textE;
		private System.Windows.Forms.GroupBox groupFirstApproximation;
		private System.Windows.Forms.TextBox textX0;
		private System.Windows.Forms.TextBox textY0;
		private System.Windows.Forms.GroupBox groupInterval;
		private System.Windows.Forms.TextBox textX1;
		private System.Windows.Forms.TextBox textX2;
		private System.Windows.Forms.TextBox textBoxFx;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button buttonSolve;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ListBox listY;
		private System.Windows.Forms.ListBox listRoots;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioStillPt;
		private System.Windows.Forms.RadioButton radioNewtone;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.CheckBox checkPick;
		private System.Windows.Forms.CheckBox checkSpeedUp;
	}
}

