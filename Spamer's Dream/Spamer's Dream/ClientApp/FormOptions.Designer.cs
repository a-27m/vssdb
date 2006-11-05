namespace ClientApp
{
	partial class FormOptions
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
			System.Windows.Forms.Label label1;
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.textUdpInPort = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.textDbHost = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textDbUser = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textDbPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textDbName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textCacheDepth = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textDoze = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(5, 19);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(98, 13);
			label1.TabIndex = 2;
			label1.Text = "Incoming (server\'s):";
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(303, 146);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 0;
			this.buttonOk.Text = "&OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(303, 175);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Can&cel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// textUdpInPort
			// 
			this.textUdpInPort.Location = new System.Drawing.Point(9, 35);
			this.textUdpInPort.Name = "textUdpInPort";
			this.textUdpInPort.Size = new System.Drawing.Size(100, 20);
			this.textUdpInPort.TabIndex = 3;
			this.textUdpInPort.Text = "?";
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkRate = 150;
			this.errorProvider.ContainerControl = this;
			// 
			// textDbHost
			// 
			this.textDbHost.Location = new System.Drawing.Point(9, 32);
			this.textDbHost.Name = "textDbHost";
			this.textDbHost.Size = new System.Drawing.Size(100, 20);
			this.textDbHost.TabIndex = 5;
			this.textDbHost.Text = "?";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Host";
			// 
			// textDbUser
			// 
			this.textDbUser.Location = new System.Drawing.Point(9, 81);
			this.textDbUser.Name = "textDbUser";
			this.textDbUser.Size = new System.Drawing.Size(100, 20);
			this.textDbUser.TabIndex = 7;
			this.textDbUser.Text = "?";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Username";
			// 
			// textDbPassword
			// 
			this.textDbPassword.Location = new System.Drawing.Point(117, 81);
			this.textDbPassword.Name = "textDbPassword";
			this.textDbPassword.Size = new System.Drawing.Size(100, 20);
			this.textDbPassword.TabIndex = 9;
			this.textDbPassword.UseSystemPasswordChar = true;
			this.textDbPassword.TextChanged += new System.EventHandler(this.textDbPassword_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(112, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Password";
			// 
			// textDbName
			// 
			this.textDbName.Location = new System.Drawing.Point(117, 32);
			this.textDbName.Name = "textDbName";
			this.textDbName.Size = new System.Drawing.Size(100, 20);
			this.textDbName.TabIndex = 11;
			this.textDbName.Text = "?";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(114, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "DB name";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textDbPassword);
			this.groupBox1.Controls.Add(this.textDbName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textDbHost);
			this.groupBox1.Controls.Add(this.textDbUser);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(226, 114);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "MySQL server";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(label1);
			this.groupBox2.Controls.Add(this.textUdpInPort);
			this.groupBox2.Location = new System.Drawing.Point(12, 132);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(121, 69);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "UDP ports";
			// 
			// textCacheDepth
			// 
			this.textCacheDepth.Location = new System.Drawing.Point(266, 44);
			this.textCacheDepth.Name = "textCacheDepth";
			this.textCacheDepth.Size = new System.Drawing.Size(123, 20);
			this.textCacheDepth.TabIndex = 16;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(263, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Messages cache\'s depth:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(263, 77);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "Tasks at once:";
			// 
			// textDoze
			// 
			this.textDoze.Location = new System.Drawing.Point(266, 93);
			this.textDoze.Name = "textDoze";
			this.textDoze.Size = new System.Drawing.Size(123, 20);
			this.textDoze.TabIndex = 18;
			// 
			// FormOptions
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(401, 213);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textDoze);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textCacheDepth);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormOptions";
			this.ShowInTaskbar = false;
			this.Text = "Options";
			this.Load += new System.EventHandler(this.FormOptions_Load);
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textUdpInPort;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.TextBox textDbName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textDbPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textDbUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textDbHost;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textCacheDepth;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textDoze;
	}
}