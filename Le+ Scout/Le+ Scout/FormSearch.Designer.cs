namespace Le__Scout
{
    partial class FormSearch
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_rozn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFilter = new System.Windows.Forms.DataGridView();
            this.scode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sprice_rozn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.code,
            this.name,
            this.price_rozn});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(524, 236);
            this.dgvData.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // code
            // 
            this.code.HeaderText = "Код";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // price_rozn
            // 
            this.price_rozn.HeaderText = "Цена (розн)";
            this.price_rozn.Name = "price_rozn";
            this.price_rozn.ReadOnly = true;
            // 
            // dgvFilter
            // 
            this.dgvFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scode,
            this.sname,
            this.sprice_rozn});
            this.dgvFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFilter.Location = new System.Drawing.Point(0, 0);
            this.dgvFilter.Name = "dgvFilter";
            this.dgvFilter.RowHeadersVisible = false;
            this.dgvFilter.ShowEditingIcon = false;
            this.dgvFilter.Size = new System.Drawing.Size(524, 43);
            this.dgvFilter.TabIndex = 1;
            this.dgvFilter.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilter_CellValueChanged);
            // 
            // scode
            // 
            this.scode.HeaderText = "Код";
            this.scode.Name = "scode";
            // 
            // sname
            // 
            this.sname.HeaderText = "Название";
            this.sname.Name = "sname";
            // 
            // sprice_rozn
            // 
            this.sprice_rozn.HeaderText = "Цена";
            this.sprice_rozn.Name = "sprice_rozn";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvData);
            this.splitContainer1.Size = new System.Drawing.Size(524, 291);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.SplitterWidth = 12;
            this.splitContainer1.TabIndex = 2;
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 291);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormSearch";
            this.Text = "Поиск";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSearch_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridView dgvFilter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_rozn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scode;
        private System.Windows.Forms.DataGridViewTextBoxColumn sname;
        private System.Windows.Forms.DataGridViewTextBoxColumn sprice_rozn;
    }
}