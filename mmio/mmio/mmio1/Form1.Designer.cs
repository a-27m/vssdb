namespace mmio1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemTools = new System.Windows.Forms.MenuItem();
            this.menuItemNew = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemFile);
            this.mainMenu1.MenuItems.Add(this.menuItemTools);
            // 
            // menuItemFile
            // 
            this.menuItemFile.MenuItems.Add(this.menuItemNew);
            this.menuItemFile.MenuItems.Add(this.menuItem2);
            this.menuItemFile.MenuItems.Add(this.menuItem3);
            this.menuItemFile.MenuItems.Add(this.menuItem5);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemTools
            // 
            this.menuItemTools.Text = "&Tools";
            // 
            // menuItemNew
            // 
            this.menuItemNew.MenuItems.Add(this.menuItem1);
            this.menuItemNew.MenuItems.Add(this.menuItem4);
            this.menuItemNew.Text = "New";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Open...";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Save...";
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Задача 1";
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Транспортная задача";
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "Exit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "ММИО: ЛП";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemTools;
        private System.Windows.Forms.MenuItem menuItemNew;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
    }
}

