namespace mmio1
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
            this.dataGridView1 = new MobGridView();
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
            //!! this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIteration,
            this.colRowIndex,
            this.colBasis,
            this.colCBasis,
            this.colA0});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            //this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(544, 314);
            this.dataGridView1.TabIndex = 0;
            // 
            // colIteration
            // 
            this.colIteration.HeaderText = "Итерация";
            this.colIteration.Name = "colIteration";
            this.colIteration.ReadOnly = true;
            this.colIteration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colIteration.Width = 81;
            // 
            // colRowIndex
            // 
            this.colRowIndex.HeaderText = "i";
            this.colRowIndex.Name = "colRowIndex";
            this.colRowIndex.ReadOnly = true;
            this.colRowIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRowIndex.Width = 15;
            // 
            // colBasis
            // 
            this.colBasis.HeaderText = "Базис";
            this.colBasis.Name = "colBasis";
            this.colBasis.ReadOnly = true;
            this.colBasis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBasis.Width = 44;
            // 
            // colCBasis
            // 
            this.colCBasis.HeaderText = "Сб";
            this.colCBasis.Name = "colCBasis";
            this.colCBasis.ReadOnly = true;
            this.colCBasis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCBasis.Width = 26;
            // 
            // colA0
            // 
            this.colA0.HeaderText = "A0";
            this.colA0.Name = "colA0";
            this.colA0.ReadOnly = true;
            this.colA0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colA0.Width = 26;
            // 
            // FormSTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 314);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSTables";
            this.Text = "Отчет";
            this.Shown += new System.EventHandler(this.FormSTables_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSTables_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MobGridView dataGridView1;
    }
}