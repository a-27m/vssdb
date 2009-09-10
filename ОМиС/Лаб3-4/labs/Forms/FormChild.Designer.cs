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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridAnalysis = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridDataSet = new System.Windows.Forms.DataGridView();
            this.dataSetComboWidth = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataSetContextRemoveRow = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetContextRemoveColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetContextRemoveCell = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetContextClear = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripShowData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripShowAnal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripShowText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnalysis)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDataSet)).BeginInit();
            this.dataSetComboWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer2.Size = new System.Drawing.Size(484, 133);
            this.splitContainer2.SplitterDistance = 70;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 4;
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
            this.dataGridAnalysis.Size = new System.Drawing.Size(484, 70);
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
            this.textBox1.Size = new System.Drawing.Size(484, 60);
            this.textBox1.TabIndex = 0;
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
            this.splitContainer1.Panel1MinSize = 3;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 3;
            this.splitContainer1.Size = new System.Drawing.Size(484, 355);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.DoubleClick += new System.EventHandler(this.splitContainer1_DoubleClick);
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
            this.dataGridDataSet.Size = new System.Drawing.Size(484, 216);
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
            this.dataSetComboWidth.Size = new System.Drawing.Size(174, 92);
            // 
            // dataSetContextRemoveRow
            // 
            this.dataSetContextRemoveRow.Name = "dataSetContextRemoveRow";
            this.dataSetContextRemoveRow.Size = new System.Drawing.Size(173, 22);
            this.dataSetContextRemoveRow.Text = "Удалить строку";
            this.dataSetContextRemoveRow.Click += new System.EventHandler(this.dataSetContextRemoveRow_Click);
            // 
            // dataSetContextRemoveColumn
            // 
            this.dataSetContextRemoveColumn.Name = "dataSetContextRemoveColumn";
            this.dataSetContextRemoveColumn.Size = new System.Drawing.Size(173, 22);
            this.dataSetContextRemoveColumn.Text = "Удалить столбец";
            this.dataSetContextRemoveColumn.Click += new System.EventHandler(this.dataSetContextRemoveColumn_Click);
            // 
            // dataSetContextRemoveCell
            // 
            this.dataSetContextRemoveCell.Name = "dataSetContextRemoveCell";
            this.dataSetContextRemoveCell.Size = new System.Drawing.Size(173, 22);
            this.dataSetContextRemoveCell.Text = "Удалить ячейки";
            this.dataSetContextRemoveCell.ToolTipText = "Удалить выделенные ячейки со сдвигом влево";
            this.dataSetContextRemoveCell.Visible = false;
            // 
            // dataSetContextClear
            // 
            this.dataSetContextClear.Name = "dataSetContextClear";
            this.dataSetContextClear.Size = new System.Drawing.Size(173, 22);
            this.dataSetContextClear.Text = "Очистить";
            this.dataSetContextClear.Visible = false;
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Checked = true;
            this.viewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripShowData,
            this.toolStripSeparator1,
            this.toolStripShowAnal,
            this.toolStripShowText});
            this.viewToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // toolStripShowData
            // 
            this.toolStripShowData.Checked = true;
            this.toolStripShowData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripShowData.Name = "toolStripShowData";
            this.toolStripShowData.Size = new System.Drawing.Size(184, 22);
            this.toolStripShowData.Text = "Исходные данные";
            this.toolStripShowData.Click += new System.EventHandler(this.toolStripShowData_Click);
            // 
            // toolStripShowAnal
            // 
            this.toolStripShowAnal.Checked = true;
            this.toolStripShowAnal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripShowAnal.Name = "toolStripShowAnal";
            this.toolStripShowAnal.Size = new System.Drawing.Size(184, 22);
            this.toolStripShowAnal.Text = "Таблица обработки";
            this.toolStripShowAnal.Click += new System.EventHandler(this.toolStripShowAnal_Click);
            // 
            // toolStripShowText
            // 
            this.toolStripShowText.Checked = true;
            this.toolStripShowText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripShowText.Name = "toolStripShowText";
            this.toolStripShowText.Size = new System.Drawing.Size(184, 22);
            this.toolStripShowText.Text = "Текст обработки";
            this.toolStripShowText.Click += new System.EventHandler(this.toolStripShowText_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // FormChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 355);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormChild";
            this.Text = "Document";
            this.Shown += new System.EventHandler(this.FormChld_Shown);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAnalysis)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDataSet)).EndInit();
            this.dataSetComboWidth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripShowAnal;
        private System.Windows.Forms.ToolStripMenuItem toolStripShowText;
        private System.Windows.Forms.ToolStripMenuItem toolStripShowData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}