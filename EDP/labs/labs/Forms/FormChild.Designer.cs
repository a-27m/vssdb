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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.SplitContainer splitContainer1;
            System.Windows.Forms.SplitContainer splitContainer2;
            this.dataGridDataSet = new System.Windows.Forms.DataGridView();
            this.dataGridAnalysis = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataSetComboWidth = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.dataSetComboHeigth = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataSetSetSize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dataSetContextRemoveRow = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetContextRemoveColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDataSet)).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnalysis)).BeginInit();
            this.dataSetComboWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(this.dataGridDataSet);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Panel2MinSize = 30;
            splitContainer1.Size = new System.Drawing.Size(484, 355);
            splitContainer1.SplitterDistance = 122;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 3;
            // 
            // dataGridDataSet
            // 
            this.dataGridDataSet.AllowUserToResizeRows = false;
            this.dataGridDataSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridDataSet.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDataSet.ContextMenuStrip = this.dataSetComboWidth;
            this.dataGridDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDataSet.Location = new System.Drawing.Point(0, 0);
            this.dataGridDataSet.Name = "dataGridDataSet";
            this.dataGridDataSet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDataSet.Size = new System.Drawing.Size(484, 122);
            this.dataGridDataSet.TabIndex = 0;
            this.dataGridDataSet.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridDataSet_UserAddedRow);
            this.dataGridDataSet.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridDataSet_UserDeletedRow);
            this.dataGridDataSet.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDataSet_CellEndEdit);
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(this.dataGridAnalysis);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(this.textBox1);
            splitContainer2.Panel2MinSize = 30;
            splitContainer2.Size = new System.Drawing.Size(484, 227);
            splitContainer2.SplitterDistance = 141;
            splitContainer2.SplitterWidth = 6;
            splitContainer2.TabIndex = 4;
            // 
            // dataGridAnalysis
            // 
            this.dataGridAnalysis.AllowUserToAddRows = false;
            this.dataGridAnalysis.AllowUserToDeleteRows = false;
            this.dataGridAnalysis.AllowUserToResizeRows = false;
            this.dataGridAnalysis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAnalysis.Location = new System.Drawing.Point(0, 0);
            this.dataGridAnalysis.Name = "dataGridAnalysis";
            this.dataGridAnalysis.ReadOnly = true;
            this.dataGridAnalysis.RowHeadersWidth = 160;
            this.dataGridAnalysis.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridAnalysis.ShowCellToolTips = false;
            this.dataGridAnalysis.ShowEditingIcon = false;
            this.dataGridAnalysis.Size = new System.Drawing.Size(484, 141);
            this.dataGridAnalysis.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(484, 80);
            this.textBox1.TabIndex = 0;
            // 
            // dataSetComboWidth
            // 
            this.dataSetComboWidth.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.toolStripComboBox1,
            this.dataSetComboHeigth,
            this.toolStripSeparator1,
            this.dataSetSetSize,
            this.toolStripSeparator3,
            this.dataSetContextRemoveRow,
            this.dataSetContextRemoveColumn});
            this.dataSetComboWidth.Name = "dataSetComboWidth";
            this.dataSetComboWidth.Size = new System.Drawing.Size(182, 138);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 21);
            this.toolStripComboBox1.TextUpdate += new System.EventHandler(this.dataSetContextComboSizeChanged);
            // 
            // dataSetComboHeigth
            // 
            this.dataSetComboHeigth.Name = "dataSetComboHeigth";
            this.dataSetComboHeigth.Size = new System.Drawing.Size(121, 21);
            this.dataSetComboHeigth.TextUpdate += new System.EventHandler(this.dataSetContextComboSizeChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // dataSetSetSize
            // 
            this.dataSetSetSize.Name = "dataSetSetSize";
            this.dataSetSetSize.Size = new System.Drawing.Size(181, 22);
            this.dataSetSetSize.Text = "toolStripMenuItem1";
            this.dataSetSetSize.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // dataSetContextRemoveRow
            // 
            this.dataSetContextRemoveRow.Name = "dataSetContextRemoveRow";
            this.dataSetContextRemoveRow.Size = new System.Drawing.Size(181, 22);
            this.dataSetContextRemoveRow.Text = "Удалить строку";
            // 
            // dataSetContextRemoveColumn
            // 
            this.dataSetContextRemoveColumn.Name = "dataSetContextRemoveColumn";
            this.dataSetContextRemoveColumn.Size = new System.Drawing.Size(181, 22);
            this.dataSetContextRemoveColumn.Text = "Удалить столбец";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 125;
            this.errorProvider1.ContainerControl = this;
            // 
            // FormChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 355);
            this.Controls.Add(splitContainer1);
            this.Name = "FormChild";
            this.Text = "Document";
            this.Shown += new System.EventHandler(this.FormChld_Shown);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDataSet)).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnalysis)).EndInit();
            this.dataSetComboWidth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridDataSet;
        private System.Windows.Forms.DataGridView dataGridAnalysis;
        private System.Windows.Forms.ContextMenuStrip dataSetComboWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripComboBox dataSetComboHeigth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dataSetSetSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem dataSetContextRemoveRow;
        private System.Windows.Forms.ToolStripMenuItem dataSetContextRemoveColumn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}