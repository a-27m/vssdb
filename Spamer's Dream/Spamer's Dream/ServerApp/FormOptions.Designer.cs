namespace ServerApp
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
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textUdpPort = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.textDbHost = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textDbUser = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textDbPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textDbName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(103, 231);
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
			this.buttonCancel.Location = new System.Drawing.Point(244, 231);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Can&cel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "UDP Port";
			// 
			// textUdpPort
			// 
			this.textUdpPort.Location = new System.Drawing.Point(29, 47);
			this.textUdpPort.Name = "textUdpPort";
			this.textUdpPort.Size = new System.Drawing.Size(100, 20);
			this.textUdpPort.TabIndex = 3;
			this.textUdpPort.Text = "?";
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkRate = 150;
			this.errorProvider.ContainerControl = this;
			// 
			// textHost
			// 
			this.textDbHost.Location = new System.Drawing.Point(29, 103);
			this.textDbHost.Name = "textHost";
			this.textDbHost.Size = new System.Drawing.Size(100, 20);
			this.textDbHost.TabIndex = 5;
			this.textDbHost.Text = "?";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "MySQL server";
			// 
			// textUsername
			// 
			this.textDbUser.Location = new System.Drawing.Point(149, 103);
			this.textDbUser.Name = "textUsername";
			this.textDbUser.Size = new System.Drawing.Size(100, 20);
			this.textDbUser.TabIndex = 7;
			this.textDbUser.Text = "?";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(146, 87);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Username";
			// 
			// textPassword
			// 
			this.textDbPassword.Location = new System.Drawing.Point(149, 142);
			this.textDbPassword.Name = "textPassword";
			this.textDbPassword.Size = new System.Drawing.Size(100, 20);
			this.textDbPassword.TabIndex = 9;
			this.textDbPassword.UseSystemPasswordChar = true;
			this.textDbPassword.TextChanged += new System.EventHandler(this.textDbPassword_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(146, 126);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Password";
			// 
			// textDbName
			// 
			this.textDbName.Location = new System.Drawing.Point(29, 142);
			this.textDbName.Name = "textDbName";
			this.textDbName.Size = new System.Drawing.Size(100, 20);
			this.textDbName.TabIndex = 11;
			this.textDbName.Text = "?";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(26, 126);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "DB name";
			// 
			// FormOptions
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(423, 266);
			this.Controls.Add(this.textDbName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textDbPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textDbUser);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textDbHost);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textUdpPort);
			this.Controls.Add(this.label1);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textUdpPort;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.TextBox textDbName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textDbPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textDbUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textDbHost;
		private System.Windows.Forms.Label label2;
	}
}