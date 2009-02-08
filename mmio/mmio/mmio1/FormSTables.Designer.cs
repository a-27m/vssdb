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
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            //!! this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            //this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //this.colIteration,
            //this.colRowIndex,
            //this.colBasis,
            //this.colCBasis,
            //this.colA0});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            //this.dataGridView1.ReadOnly = true;
            //this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(544, 314);
            this.dataGridView1.TabIndex = 0;
            //// 
            //// colIteration
            //this.colIteration.HeaderText = "Итерация";
            //this.colIteration.Width = 81;
            //// colRowIndex
            //this.colRowIndex.HeaderText = "i";
            //this.colRowIndex.Width = 15;
            //// colBasis
            //this.colBasis.HeaderText = "Базис";
            //this.colBasis.Width = 44;
            //// colCBasis
            //this.colCBasis.HeaderText = "Сб";
            //this.colCBasis.Width = 26;
            //// colA0
            //this.colA0.HeaderText = "A0";
            //this.colA0.Width = 26;

            // 
            // FormSTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(544, 314);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSTables";
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.FormSTables_Shown);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormSTables_FormClosing);
            this.ResumeLayout(false);
        }

        #endregion

        private MobGridView dataGridView1;
    }
}