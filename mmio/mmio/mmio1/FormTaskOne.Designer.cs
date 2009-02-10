namespace mmio1
{
    partial class FormTaskOne
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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemSlvGraph = new System.Windows.Forms.MenuItem();
            this.menuItemSlvBasic = new System.Windows.Forms.MenuItem();
            this.menuItemSlvOptimize = new System.Windows.Forms.MenuItem();
            this.menuItemBack = new System.Windows.Forms.MenuItem();
            this.dataGridView1 = new mmio1.MobGridView();
            this.richTextBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItemBack);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItemSlvGraph);
            this.menuItem1.MenuItems.Add(this.menuItemSlvBasic);
            this.menuItem1.MenuItems.Add(this.menuItemSlvOptimize);
            this.menuItem1.Text = "Решить";
            // 
            // menuItemSlvGraph
            // 
            this.menuItemSlvGraph.Text = "Графический";
            this.menuItemSlvGraph.Click += new System.EventHandler(this.графическийМетодToolStripMenuItem_Click);
            // 
            // menuItemSlvBasic
            // 
            this.menuItemSlvBasic.Text = "Базис матрицы";
            this.menuItemSlvBasic.Click += new System.EventHandler(this.выделитьБазисМатрицыAToolStripMenuItem_Click);
            // 
            // menuItemSlvOptimize
            // 
            this.menuItemSlvOptimize.Text = "Оптимизировать";
            this.menuItemSlvOptimize.Click += new System.EventHandler(this.оптимизироватьToolStripMenuItem_Click);
            // 
            // menuItemBack
            // 
            this.menuItemBack.Text = "Назад";
            this.menuItemBack.Click += new System.EventHandler(this.menuItemBack_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackColor = System.Drawing.Color.LightBlue;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 268);
            this.dataGridView1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 21);
            this.richTextBox1.TabIndex = 0;
            // 
            // FormTaskOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.dataGridView1);
            this.Menu = this.mainMenu1;
            this.Name = "FormTaskOne";
            this.Text = "Задача 1";
            this.ResumeLayout(false);

        }

        #endregion

        private MobGridView dataGridView1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemSlvGraph;
        private System.Windows.Forms.MenuItem menuItemSlvBasic;
        private System.Windows.Forms.MenuItem menuItemSlvOptimize;
        private System.Windows.Forms.MenuItem menuItemBack;
        private System.Windows.Forms.TextBox richTextBox1;
    }
}