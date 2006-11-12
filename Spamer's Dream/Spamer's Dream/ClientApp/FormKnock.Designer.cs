namespace ClientApp
{
	partial class FormKnock
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
			System.Windows.Forms.GroupBox groupBox1;
			this.textServerPort = new System.Windows.Forms.TextBox();
			this.textServerIP = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonKnock = new System.Windows.Forms.Button();
			this.textName = new System.Windows.Forms.TextBox();
			this.textEmail = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(this.buttonCancel);
			groupBox1.Controls.Add(this.textName);
			groupBox1.Controls.Add(this.textEmail);
			groupBox1.Controls.Add(this.label3);
			groupBox1.Controls.Add(this.label4);
			groupBox1.Controls.Add(this.textServerPort);
			groupBox1.Controls.Add(this.textServerIP);
			groupBox1.Controls.Add(this.label2);
			groupBox1.Controls.Add(this.label1);
			groupBox1.Controls.Add(this.buttonKnock);
			groupBox1.Location = new System.Drawing.Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(222, 205);
			groupBox1.TabIndex = 9;
			groupBox1.TabStop = false;
			groupBox1.Text = "Knock-knock";
			// 
			// textServerPort
			// 
			this.textServerPort.Location = new System.Drawing.Point(86, 51);
			this.textServerPort.Name = "textServerPort";
			this.textServerPort.Size = new System.Drawing.Size(100, 20);
			this.textServerPort.TabIndex = 4;
			// 
			// textServerIP
			// 
			this.textServerIP.Location = new System.Drawing.Point(86, 25);
			this.textServerIP.Name = "textServerIP";
			this.textServerIP.Size = new System.Drawing.Size(100, 20);
			this.textServerIP.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Server port*:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Server IP*:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// buttonKnock
			// 
			this.buttonKnock.Location = new System.Drawing.Point(30, 164);
			this.buttonKnock.Name = "buttonKnock";
			this.buttonKnock.Size = new System.Drawing.Size(75, 23);
			this.buttonKnock.TabIndex = 0;
			this.buttonKnock.Text = "&Register";
			this.buttonKnock.UseVisualStyleBackColor = true;
			this.buttonKnock.Click += new System.EventHandler(this.buttonKnock_Click);
			// 
			// textName
			// 
			this.textName.Location = new System.Drawing.Point(86, 113);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(100, 20);
			this.textName.TabIndex = 8;
			// 
			// textEmail
			// 
			this.textEmail.Location = new System.Drawing.Point(86, 87);
			this.textEmail.Name = "textEmail";
			this.textEmail.Size = new System.Drawing.Size(100, 20);
			this.textEmail.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "\"From\" name:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 20);
			this.label4.TabIndex = 5;
			this.label4.Text = "\"From\" e-mail:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(118, 164);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkRate = 125;
			this.errorProvider.ContainerControl = this;
			// 
			// FormKnock
			// 
			this.AcceptButton = this.buttonKnock;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(247, 229);
			this.Controls.Add(groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormKnock";
			this.ShowInTaskbar = false;
			this.Text = "Registration form";
			this.Load += new System.EventHandler(this.FormKnock_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.errorProvider ) ).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textServerPort;
		private System.Windows.Forms.TextBox textServerIP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonKnock;
		private System.Windows.Forms.TextBox textName;
		private System.Windows.Forms.TextBox textEmail;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ErrorProvider errorProvider;
	}
}