﻿namespace mmio1
{
    partial class FormSTables
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
            this.dataGridView1 = new mmio1.MobGridView();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoScroll = true;
            this.dataGridView1.BackColor = System.Drawing.Color.SeaShell;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 294);
            this.dataGridView1.TabIndex = 0;
            // 
            // FormSTables
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSTables";
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.FormSTables_Shown);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormSTables_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MobGridView dataGridView1;
    }
}