namespace lab1
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
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.colChar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxMsg.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMsg.Location = new System.Drawing.Point(43, 3);
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(393, 25);
            this.textBoxMsg.TabIndex = 0;
            this.textBoxMsg.Text = "this is some sample message.";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Text";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChar,
            this.colProbability,
            this.colCode});
            this.tableLayoutPanel1.SetColumnSpan(this.dgv1, 4);
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(3, 33);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(569, 235);
            this.dgv1.TabIndex = 5;
            // 
            // colChar
            // 
            this.colChar.Frozen = true;
            this.colChar.HeaderText = "Char";
            this.colChar.Name = "colChar";
            this.colChar.ReadOnly = true;
            // 
            // colProbability
            // 
            this.colProbability.Frozen = true;
            this.colProbability.HeaderText = "Probability";
            this.colProbability.Name = "colProbability";
            this.colProbability.ReadOnly = true;
            // 
            // colCode
            // 
            this.colCode.Frozen = true;
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 250;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.Controls.Add(this.dgv1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMsg, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(575, 291);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 4);
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(569, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ready";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(511, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "Start 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 291);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Lab1 Huffman";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProbability;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}

