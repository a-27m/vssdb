namespace ММИО_л1
{
    partial class FormSTables
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colIteration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRowIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBasis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCBasis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colA0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIteration,
            this.colRowIndex,
            this.colBasis,
            this.colCBasis,
            this.colA0});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(544, 314);
            this.dataGridView1.TabIndex = 0;
            // 
            // colIteration
            // 
            this.colIteration.HeaderText = "Итерация";
            this.colIteration.Name = "colIteration";
            this.colIteration.ReadOnly = true;
            this.colIteration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colIteration.Width = 60;
            // 
            // colRowIndex
            // 
            this.colRowIndex.HeaderText = "i";
            this.colRowIndex.Name = "colRowIndex";
            this.colRowIndex.ReadOnly = true;
            this.colRowIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRowIndex.Width = 20;
            // 
            // colBasis
            // 
            this.colBasis.HeaderText = "Базис";
            this.colBasis.Name = "colBasis";
            this.colBasis.ReadOnly = true;
            this.colBasis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBasis.Width = 40;
            // 
            // colCBasis
            // 
            this.colCBasis.HeaderText = "Сб";
            this.colCBasis.Name = "colCBasis";
            this.colCBasis.ReadOnly = true;
            this.colCBasis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCBasis.Width = 30;
            // 
            // colA0
            // 
            this.colA0.HeaderText = "A";
            this.colA0.Name = "colA0";
            this.colA0.ReadOnly = true;
            this.colA0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colA0.Width = 30;
            // 
            // FormSTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 314);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSTables";
            this.Text = "Отчет";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIteration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBasis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCBasis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colA0;
    }
}