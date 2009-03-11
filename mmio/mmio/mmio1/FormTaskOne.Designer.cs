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
            System.Windows.Forms.TabPage tabPage1;
            System.Windows.Forms.TabPage tabPage2;
            this.richTextBox1 = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemSlvGraph = new System.Windows.Forms.MenuItem();
            this.menuItemSlvBasic = new System.Windows.Forms.MenuItem();
            this.menuItemSlvOptimize = new System.Windows.Forms.MenuItem();
            this.menuItemBack = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dataGridView1 = new mmio1.MobGridView();
            tabPage1 = new System.Windows.Forms.TabPage();
            tabPage2 = new System.Windows.Forms.TabPage();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(this.dataGridView1);
            tabPage1.Location = new System.Drawing.Point(0, 0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new System.Drawing.Size(240, 245);
            tabPage1.Text = "Условия";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(this.richTextBox1);
            tabPage2.Location = new System.Drawing.Point(0, 0);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new System.Drawing.Size(240, 245);
            tabPage2.Text = "Ответ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Multiline = true;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(240, 245);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Hello\r\n123";
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
            this.menuItemBack.MenuItems.Add(this.menuItemOpen);
            this.menuItemBack.MenuItems.Add(this.menuItemSave);
            this.menuItemBack.Text = "Файл";
            this.menuItemBack.Click += new System.EventHandler(this.menuItemBack_Click);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Text = "Открыть...";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Text = "Сохранить...";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "MMIO tasks (*.mmiox)|*.mmiox";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "MMIO tasks (*.mmiox)|*.mmiox";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(tabPage1);
            this.tabControl1.Controls.Add(tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackColor = System.Drawing.Color.SeaShell;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 245);
            this.dataGridView1.TabIndex = 0;
            // 
            // FormTaskOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "FormTaskOne";
            this.Text = "Задача 1";
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
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
        private System.Windows.Forms.MenuItem menuItemOpen;
        private System.Windows.Forms.MenuItem menuItemSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}