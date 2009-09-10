namespace lab1
{
    partial class FormAskLawSelection
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxNormal = new System.Windows.Forms.CheckBox();
            this.checkBoxExponential = new System.Windows.Forms.CheckBox();
            this.checkBoxRavnom = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(27, 151);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxNormal);
            this.groupBox1.Controls.Add(this.checkBoxExponential);
            this.groupBox1.Controls.Add(this.checkBoxRavnom);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Модели распределения";
            // 
            // checkBoxNormal
            // 
            this.checkBoxNormal.AutoSize = true;
            this.checkBoxNormal.Checked = true;
            this.checkBoxNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNormal.Location = new System.Drawing.Point(25, 76);
            this.checkBoxNormal.Name = "checkBoxNormal";
            this.checkBoxNormal.Size = new System.Drawing.Size(125, 17);
            this.checkBoxNormal.TabIndex = 2;
            this.checkBoxNormal.Text = "Нормальный закон";
            this.checkBoxNormal.UseVisualStyleBackColor = true;
            this.checkBoxNormal.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxExponential
            // 
            this.checkBoxExponential.AutoSize = true;
            this.checkBoxExponential.Checked = true;
            this.checkBoxExponential.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExponential.Location = new System.Drawing.Point(25, 53);
            this.checkBoxExponential.Name = "checkBoxExponential";
            this.checkBoxExponential.Size = new System.Drawing.Size(140, 17);
            this.checkBoxExponential.TabIndex = 1;
            this.checkBoxExponential.Text = "Показательный закон";
            this.checkBoxExponential.UseVisualStyleBackColor = true;
            this.checkBoxExponential.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxRavnom
            // 
            this.checkBoxRavnom.AutoSize = true;
            this.checkBoxRavnom.Checked = true;
            this.checkBoxRavnom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRavnom.Location = new System.Drawing.Point(25, 30);
            this.checkBoxRavnom.Name = "checkBoxRavnom";
            this.checkBoxRavnom.Size = new System.Drawing.Size(130, 17);
            this.checkBoxRavnom.TabIndex = 0;
            this.checkBoxRavnom.Text = "Равномерный закон";
            this.checkBoxRavnom.UseVisualStyleBackColor = true;
            this.checkBoxRavnom.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(114, 151);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormAskLawSelection
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(216, 188);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAskLawSelection";
            this.ShowInTaskbar = false;
            this.Text = "Выберите";
            this.Load += new System.EventHandler(this.FormAskLawSelection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxNormal;
        private System.Windows.Forms.CheckBox checkBoxExponential;
        private System.Windows.Forms.CheckBox checkBoxRavnom;
    }
}