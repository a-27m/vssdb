namespace Le__Scout
{
    partial class FormLog
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
            this.box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // box
            // 
            box.Dock = System.Windows.Forms.DockStyle.Fill;
            box.Multiline = true;
            box.ReadOnly = true;
            box.BackColor = System.Drawing.SystemColors.Window;
            box.Name = "box";
            box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            // 
            // FormLog
            // 
            this.Controls.Add(box);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormLog";
            this.Size = new System.Drawing.Size(500, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Отладочные подробности работы";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox box;
    }
}