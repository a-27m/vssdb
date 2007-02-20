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
            this.dataSetComboWidth = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataSetContextRemoveRow = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetContextRemoveColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetContextRemoveCell = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetContextClear = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridAnalysis = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDataSet)).BeginInit();
            this.dataSetComboWidth.SuspendLayout();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnalysis)).BeginInit();
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
            splitContainer1.SplitterDistance = 131;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 3;
            // 
            // dataGridDataSet
            // 
            this.dataGridDataSet.AllowUserToAddRows = false;
            this.dataGridDataSet.AllowUserToResizeRows = false;
            this.dataGridDataSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridDataSet.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDataSet.ContextMenuStrip = this.dataSetComboWidth;
            this.dataGridDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDataSet.Location = new System.Drawing.Point(0, 0);
            this.dataGridDataSet.Name = "dataGridDataSet";
            this.dataGridDataSet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridDataSet.Size = new System.Drawing.Size(484, 131);
            this.dataGridDataSet.TabIndex = 0;
            this.dataGridDataSet.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridDataSet_UserDeletedRow);
            this.dataGridDataSet.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDataSet_CellEndEdit);
            this.dataGridDataSet.SelectionChanged += new System.EventHandler(this.dataGridDataSet_SelectionChanged);
            // 
            // dataSetComboWidth
            // 
            this.dataSetComboWidth.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataSetContextRemoveRow,
            this.dataSetContextRemoveColumn,
            this.dataSetContextRemoveCell,
            this.dataSetContextClear});
            this.dataSetComboWidth.Name = "dataSetComboWidth";
            this.dataSetComboWidth.Size = new System.Drawing.Size(174, 114);
            this.dataSetComboWidth.Opened += new System.EventHandler(this.dataSetComboWidth_Opened);
            // 
            // dataSetContextRemoveRow
            // 
            this.dataSetContextRemoveRow.Name = "dataSetContextRemoveRow";
            this.dataSetContextRemoveRow.Size = new System.Drawing.Size(173, 22);
            this.dataSetContextRemoveRow.Text = "”далить строку";
            this.dataSetContextRemoveRow.Click += new System.EventHandler(this.dataSetContextRemoveRow_Click);
            // 
            // dataSetContextRemoveColumn
            // 
            this.dataSetContextRemoveColumn.Name = "dataSetContextRemoveColumn";
            this.dataSetContextRemoveColumn.Size = new System.Drawing.Size(173, 22);
            this.dataSetContextRemoveColumn.Text = "”далить столбец";
            this.dataSetContextRemoveColumn.Visible = false;
            // 
            // dataSetContextRemoveCell
            // 
            this.dataSetContextRemoveCell.Name = "dataSetContextRemoveCell";
            this.dataSetContextRemoveCell.Size = new System.Drawing.Size(173, 22);
            this.dataSetContextRemoveCell.Text = "”далить €чейки";
            this.dataSetContextRemoveCell.ToolTipText = "”далить выделенные €чейки со сдвигом влево";
            this.dataSetContextRemoveCell.Visible = false;
            // 
            // dataSetContextClear
            // 
            this.dataSetContextClear.Name = "dataSetContextClear";
            this.dataSetContextClear.Size = new System.Drawing.Size(173, 22);
            this.dataSetContextClear.Text = "ќчистить";
            this.dataSetContextClear.Visible = false;
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
            splitContainer2.Size = new System.Drawing.Size(484, 218);
            splitContainer2.SplitterDistance = 134;
            splitContainer2.SplitterWidth = 6;
            splitContainer2.TabIndex = 4;
            // 
            // dataGridAnalysis
            // 
            this.dataGridAnalysis.AllowUserToAddRows = false;
            this.dataGridAnalysis.AllowUserToDeleteRows = false;
            this.dataGridAnalysis.AllowUserToResizeRows = false;
            this.dataGridAnalysis.BackgroundColor = System.Drawing.SystemColors.Control;
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
            this.dataGridAnalysis.Size = new System.Drawing.Size(484, 134);
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
            this.textBox1.Size = new System.Drawing.Size(484, 78);
            this.textBox1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 125;
            this.errorProvider1.ContainerControl = this;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(484, 355);
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
            this.dataSetComboWidth.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip dataSetComboWidth;
        private System.Windows.Forms.ToolStripMenuItem dataSetContextRemoveRow;
        private System.Windows.Forms.ToolStripMenuItem dataSetContextRemoveColumn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dataGridDataSet;
        private System.Windows.Forms.DataGridView dataGridAnalysis;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripMenuItem dataSetContextRemoveCell;
        private System.Windows.Forms.ToolStripMenuItem dataSetContextClear;
    }
}