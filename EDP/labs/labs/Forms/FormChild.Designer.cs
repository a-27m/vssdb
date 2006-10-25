namespace lab1
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
			this.dataGridAnalysis = new System.Windows.Forms.DataGridView();
			this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.randomFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.dataGridDataSet = new System.Windows.Forms.DataGridView();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridAnalysis ) ).BeginInit();
			this.contextMenuStripGrid.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridDataSet ) ).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridAnalysis
			// 
			this.dataGridAnalysis.AllowUserToAddRows = false;
			this.dataGridAnalysis.AllowUserToDeleteRows = false;
			this.dataGridAnalysis.AllowUserToResizeRows = false;
			this.dataGridAnalysis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dataGridAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableLayoutPanel1.SetColumnSpan(this.dataGridAnalysis, 2);
			this.dataGridAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridAnalysis.Location = new System.Drawing.Point(3, 71);
			this.dataGridAnalysis.Name = "dataGridAnalysis";
			this.dataGridAnalysis.RowHeadersWidth = 120;
			this.dataGridAnalysis.Size = new System.Drawing.Size(430, 207);
			this.dataGridAnalysis.TabIndex = 0;
			// 
			// contextMenuStripGrid
			// 
			this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addElementToolStripMenuItem,
            this.removeElementToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.randomFillToolStripMenuItem});
			this.contextMenuStripGrid.Name = "contextMenuStripGrid";
			this.contextMenuStripGrid.Size = new System.Drawing.Size(166, 92);
			// 
			// addElementToolStripMenuItem
			// 
			this.addElementToolStripMenuItem.Name = "addElementToolStripMenuItem";
			this.addElementToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.addElementToolStripMenuItem.Text = "Add Element";
			this.addElementToolStripMenuItem.Click += new System.EventHandler(this.contextMenuAdd_Click);
			// 
			// removeElementToolStripMenuItem
			// 
			this.removeElementToolStripMenuItem.Name = "removeElementToolStripMenuItem";
			this.removeElementToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.removeElementToolStripMenuItem.Text = "Remove Element";
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			// 
			// randomFillToolStripMenuItem
			// 
			this.randomFillToolStripMenuItem.Name = "randomFillToolStripMenuItem";
			this.randomFillToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.randomFillToolStripMenuItem.Text = "Random Fill";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.87085F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.12915F));
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.dataGridAnalysis, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.dataGridDataSet, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.74961F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.56565F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.68474F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 346);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Window;
			this.tableLayoutPanel1.SetColumnSpan(this.textBox1, 2);
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(3, 284);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(430, 59);
			this.textBox1.TabIndex = 1;
			// 
			// dataGridDataSet
			// 
			this.dataGridDataSet.AllowUserToAddRows = false;
			this.dataGridDataSet.AllowUserToDeleteRows = false;
			this.dataGridDataSet.AllowUserToOrderColumns = true;
			this.dataGridDataSet.AllowUserToResizeRows = false;
			this.dataGridDataSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableLayoutPanel1.SetColumnSpan(this.dataGridDataSet, 2);
			this.dataGridDataSet.ContextMenuStrip = this.contextMenuStripGrid;
			this.dataGridDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridDataSet.Location = new System.Drawing.Point(3, 3);
			this.dataGridDataSet.Name = "dataGridDataSet";
			this.dataGridDataSet.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.dataGridDataSet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridDataSet.ShowCellToolTips = false;
			this.dataGridDataSet.ShowEditingIcon = false;
			this.dataGridDataSet.Size = new System.Drawing.Size(430, 62);
			this.dataGridDataSet.TabIndex = 2;
			// 
			// FormChild
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(436, 346);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "FormChild";
			this.Text = "Document1";
			this.Parent = null;
			this.Shown += new System.EventHandler(FormChild_Shown);
			( (System.ComponentModel.ISupportInitialize)( this.dataGridAnalysis ) ).EndInit();
			this.contextMenuStripGrid.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridDataSet ) ).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridAnalysis;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem addElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomFillToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridDataSet;
    }
}

