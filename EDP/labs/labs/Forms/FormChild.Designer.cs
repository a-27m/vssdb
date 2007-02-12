namespace lab1.Forms
{
    partial class FormChild
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridDataSet = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridAnalysis = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDataSet)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnalysis)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridDataSet);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 30;
            this.splitContainer1.Size = new System.Drawing.Size(484, 355);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(484, 80);
            this.textBox1.TabIndex = 0;
            // 
            // dataGridDataSet
            // 
            this.dataGridDataSet.AllowUserToAddRows = false;
            this.dataGridDataSet.AllowUserToDeleteRows = false;
            this.dataGridDataSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDataSet.Location = new System.Drawing.Point(0, 0);
            this.dataGridDataSet.Name = "dataGridDataSet";
            this.dataGridDataSet.ReadOnly = true;
            this.dataGridDataSet.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridDataSet.Size = new System.Drawing.Size(484, 122);
            this.dataGridDataSet.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridAnalysis);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.textBox1);
            this.splitContainer2.Panel2MinSize = 30;
            this.splitContainer2.Size = new System.Drawing.Size(484, 227);
            this.splitContainer2.SplitterDistance = 141;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 4;
            // 
            // dataGridAnalysis
            // 
            this.dataGridAnalysis.AllowUserToAddRows = false;
            this.dataGridAnalysis.AllowUserToDeleteRows = false;
            this.dataGridAnalysis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAnalysis.Location = new System.Drawing.Point(0, 0);
            this.dataGridAnalysis.Name = "dataGridAnalysis";
            this.dataGridAnalysis.ReadOnly = true;
            this.dataGridAnalysis.RowHeadersWidth = 160;
            this.dataGridAnalysis.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridAnalysis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridAnalysis.ShowCellToolTips = false;
            this.dataGridAnalysis.ShowEditingIcon = false;
            this.dataGridAnalysis.Size = new System.Drawing.Size(484, 141);
            this.dataGridAnalysis.TabIndex = 0;
            // 
            // FormChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 355);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormChild";
            this.Text = "Document";
            this.Shown += new System.EventHandler(this.FormChld_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDataSet)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnalysis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridDataSet;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridAnalysis;
    }
}