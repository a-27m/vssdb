namespace Le__Scout
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propDBConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new System.Data.DataSet();
            this.chetab = new System.Data.DataTable();
            this.resche = new System.Data.DataTable();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxHowmuch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonComplete = new System.Windows.Forms.Button();
            this.buttonNewReceipt = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chetab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resche)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.connectToolStripMenuItem.Text = "Подключиться";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propDBConnectToolStripMenuItem});
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.propertiesToolStripMenuItem.Text = "Настройки";
            // 
            // propDBConnectToolStripMenuItem
            // 
            this.propDBConnectToolStripMenuItem.Name = "propDBConnectToolStripMenuItem";
            this.propDBConnectToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.propDBConnectToolStripMenuItem.Text = "Соединение с БД";
            this.propDBConnectToolStripMenuItem.Click += new System.EventHandler(this.propDBConnectToolStripMenuItem_Click);
            // 
            // textBoxDebug
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxDebug, 2);
            this.textBoxDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDebug.Location = new System.Drawing.Point(3, 237);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDebug.Size = new System.Drawing.Size(722, 174);
            this.textBoxDebug.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.21053F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxDebug, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgv1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(728, 414);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.AutoGenerateColumns = false;
            this.dgv1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.DataMember = "chetab";
            this.dgv1.DataSource = this.dataSet1;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(3, 3);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgv1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv1.Size = new System.Drawing.Size(607, 167);
            this.dgv1.TabIndex = 2;
            this.dgv1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.countEndChanging_KeyPress);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.chetab,
            this.resche});
            // 
            // chetab
            // 
            this.chetab.TableName = "chetab";
            // 
            // resche
            // 
            this.resche.TableName = "resche";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxHowmuch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonComplete);
            this.panel1.Controls.Add(this.buttonNewReceipt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 55);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Количество";
            // 
            // textBoxHowmuch
            // 
            this.textBoxHowmuch.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHowmuch.Location = new System.Drawing.Point(456, 26);
            this.textBoxHowmuch.Name = "textBoxHowmuch";
            this.textBoxHowmuch.Size = new System.Drawing.Size(107, 26);
            this.textBoxHowmuch.TabIndex = 10;
            this.textBoxHowmuch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxHowmuch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.countEndChanging_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Код";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(291, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(107, 26);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(660, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // buttonComplete
            // 
            this.buttonComplete.Location = new System.Drawing.Point(129, 17);
            this.buttonComplete.Name = "buttonComplete";
            this.buttonComplete.Size = new System.Drawing.Size(107, 23);
            this.buttonComplete.TabIndex = 6;
            this.buttonComplete.Text = "completeReceipt";
            this.buttonComplete.UseVisualStyleBackColor = true;
            this.buttonComplete.Click += new System.EventHandler(this.buttonComplete_Click);
            // 
            // buttonNewReceipt
            // 
            this.buttonNewReceipt.Location = new System.Drawing.Point(21, 17);
            this.buttonNewReceipt.Name = "buttonNewReceipt";
            this.buttonNewReceipt.Size = new System.Drawing.Size(90, 23);
            this.buttonNewReceipt.TabIndex = 5;
            this.buttonNewReceipt.Text = "newReceipt";
            this.buttonNewReceipt.UseVisualStyleBackColor = true;
            this.buttonNewReceipt.Click += new System.EventHandler(this.buttonNewReceipt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 438);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = global::Le__Scout.Properties.Settings.Default.MainTitleText;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chetab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resche)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propDBConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable chetab;
        private System.Windows.Forms.Button buttonNewReceipt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonComplete;
        private System.Data.DataTable resche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxHowmuch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

