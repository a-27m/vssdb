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
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCash = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxReceiptNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceroznDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.chetab = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.resche = new System.Data.DataTable();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ïðîäàæèToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.íîâûé×ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çàâåðøèòüÏðîäàæóToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propDBConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chetab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resche)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(4, 37);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(66, 13);
            label7.TabIndex = 10;
            label7.Text = "Íàëè÷íûìè";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(25, 13);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(41, 13);
            label5.TabIndex = 8;
            label5.Text = "Ñóììà";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(29, 63);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(37, 13);
            label6.TabIndex = 13;
            label6.Text = "Ñäà÷à";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = global::Le__Scout.Properties.Settings.Default.BackColor;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(this.dgv1, 0, 2);
            tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(this.linkLabel1, 0, 0);
            tableLayoutPanel1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Le__Scout.Properties.Settings.Default, "BackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            tableLayoutPanel1.Size = new System.Drawing.Size(578, 470);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(label6);
            this.panel3.Controls.Add(label5);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBoxCash);
            this.panel3.Controls.Add(label7);
            this.panel3.Location = new System.Drawing.Point(3, 376);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 90);
            this.panel3.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(72, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 19);
            this.label8.TabIndex = 12;
            this.label8.Text = "0";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "0";
            // 
            // textBoxCash
            // 
            this.textBoxCash.Font = global::Le__Scout.Properties.Settings.Default.NumbersFont;
            this.textBoxCash.Location = new System.Drawing.Point(76, 31);
            this.textBoxCash.Name = "textBoxCash";
            this.textBoxCash.Size = new System.Drawing.Size(100, 25);
            this.textBoxCash.TabIndex = 11;
            this.textBoxCash.TextChanged += new System.EventHandler(this.textBoxCash_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = global::Le__Scout.Properties.Settings.Default.BackColor;
            tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.textBoxReceiptNumber);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxCode);
            this.panel1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Le__Scout.Properties.Settings.Default, "BackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 47);
            this.panel1.TabIndex = 9;
            // 
            // textBoxReceiptNumber
            // 
            this.textBoxReceiptNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReceiptNumber.BackColor = global::Le__Scout.Properties.Settings.Default.BackColor;
            this.textBoxReceiptNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxReceiptNumber.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Le__Scout.Properties.Settings.Default, "BackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxReceiptNumber.Font = global::Le__Scout.Properties.Settings.Default.NumbersFont;
            this.textBoxReceiptNumber.Location = new System.Drawing.Point(469, 16);
            this.textBoxReceiptNumber.Name = "textBoxReceiptNumber";
            this.textBoxReceiptNumber.ReadOnly = true;
            this.textBoxReceiptNumber.Size = new System.Drawing.Size(100, 18);
            this.textBoxReceiptNumber.TabIndex = 13;
            this.textBoxReceiptNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Íîìåð ÷åêà";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Êîä";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Font = global::Le__Scout.Properties.Settings.Default.NumbersFont;
            this.textBoxCode.Location = new System.Drawing.Point(6, 16);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(107, 25);
            this.textBoxCode.TabIndex = 8;
            this.textBoxCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCode_KeyPress);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.AutoGenerateColumns = false;
            this.dgv1.BackgroundColor = global::Le__Scout.Properties.Settings.Default.BackColor;
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.priceroznDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn});
            tableLayoutPanel1.SetColumnSpan(this.dgv1, 2);
            this.dgv1.DataBindings.Add(new System.Windows.Forms.Binding("BackgroundColor", global::Le__Scout.Properties.Settings.Default, "BackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dgv1.DataMember = "chetab";
            this.dgv1.DataSource = this.dataSet1;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(3, 75);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgv1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv1.Size = new System.Drawing.Size(572, 295);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellValidated);
            this.dgv1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.countEndChanging_KeyPress);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Êîä òîâàðà";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Íàçâàíèå";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // priceroznDataGridViewTextBoxColumn
            // 
            this.priceroznDataGridViewTextBoxColumn.DataPropertyName = "price_rozn";
            this.priceroznDataGridViewTextBoxColumn.HeaderText = "Öåíà (ðîçí)";
            this.priceroznDataGridViewTextBoxColumn.Name = "priceroznDataGridViewTextBoxColumn";
            this.priceroznDataGridViewTextBoxColumn.Width = 120;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Êîëè÷åñòâî";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
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
            this.chetab.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.chetab.TableName = "chetab";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "id";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "code";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "name";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "price_rozn";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "count";
            // 
            // resche
            // 
            this.resche.TableName = "resche";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ïðîäàæèToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(0, 20);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(245, 20);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MenuDeactivate += new System.EventHandler(this.menuStrip1_MenuDeactivate);
            // 
            // ïðîäàæèToolStripMenuItem
            // 
            this.ïðîäàæèToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.íîâûé×ToolStripMenuItem,
            this.çàâåðøèòüÏðîäàæóToolStripMenuItem});
            this.ïðîäàæèToolStripMenuItem.Name = "ïðîäàæèToolStripMenuItem";
            this.ïðîäàæèToolStripMenuItem.Size = new System.Drawing.Size(65, 16);
            this.ïðîäàæèToolStripMenuItem.Text = "Ïðîäàæè";
            // 
            // íîâûé×ToolStripMenuItem
            // 
            this.íîâûé×ToolStripMenuItem.Name = "íîâûé×ToolStripMenuItem";
            this.íîâûé×ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.íîâûé×ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.íîâûé×ToolStripMenuItem.Text = "Íîâàÿ ïðîäàæà";
            this.íîâûé×ToolStripMenuItem.Click += new System.EventHandler(this.newReceipt_Click);
            // 
            // çàâåðøèòüÏðîäàæóToolStripMenuItem
            // 
            this.çàâåðøèòüÏðîäàæóToolStripMenuItem.Name = "çàâåðøèòüÏðîäàæóToolStripMenuItem";
            this.çàâåðøèòüÏðîäàæóToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.çàâåðøèòüÏðîäàæóToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.çàâåðøèòüÏðîäàæóToolStripMenuItem.Text = "Çàâåðøèòü ïðîäàæó";
            this.çàâåðøèòüÏðîäàæóToolStripMenuItem.Click += new System.EventHandler(this.complete_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(95, 16);
            this.connectToolStripMenuItem.Text = "Ïîäêëþ÷èòüñÿ";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propDBConnectToolStripMenuItem,
            this.showLogToolStripMenuItem});
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(73, 16);
            this.propertiesToolStripMenuItem.Text = "Íàñòðîéêè";
            // 
            // propDBConnectToolStripMenuItem
            // 
            this.propDBConnectToolStripMenuItem.Name = "propDBConnectToolStripMenuItem";
            this.propDBConnectToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.propDBConnectToolStripMenuItem.Text = "Ñîåäèíåíèå ñ ÁÄ";
            this.propDBConnectToolStripMenuItem.Click += new System.EventHandler(this.propDBConnectToolStripMenuItem_Click);
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.Checked = global::Le__Scout.Properties.Settings.Default.ShowLog;
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.showLogToolStripMenuItem.Text = "Ïîêàçûâàòü ëîã (îò÷åò)";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(248, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(45, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ìåíþ...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 470);
            this.Controls.Add(tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(340, 280);
            this.Name = "Form1";
            this.Text = global::Le__Scout.Properties.Settings.Default.MainTitleText;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chetab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resche)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propDBConnectToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable chetab;
        private System.Data.DataTable resche;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.TextBox textBoxReceiptNumber;
        private System.Windows.Forms.TextBox textBoxCash;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ïðîäàæèToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem íîâûé×ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çàâåðøèòüÏðîäàæóToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceroznDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel3;
    }
}

