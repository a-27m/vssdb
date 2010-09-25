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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Panel panel1;
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.colChar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonHuffman = new System.Windows.Forms.Button();
            this.buttonOptimal = new System.Windows.Forms.Button();
            this.buttonAlphabCodes = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMsg.Location = new System.Drawing.Point(43, 3);
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(419, 54);
            this.textBoxMsg.TabIndex = 0;
            this.textBoxMsg.Text = "this is some sample message.";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 14);
            label1.TabIndex = 3;
            label1.Text = "Text:";
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChar,
            this.colProbability,
            this.colCode});
            tableLayoutPanel1.SetColumnSpan(this.dgv1, 4);
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(3, 63);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(671, 222);
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
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            tableLayoutPanel1.Controls.Add(this.dgv1, 0, 1);
            tableLayoutPanel1.Controls.Add(this.textBoxMsg, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 2, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            tableLayoutPanel1.Size = new System.Drawing.Size(677, 310);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(this.label2, 4);
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(671, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ready";
            // 
            // panel1
            // 
            tableLayoutPanel1.SetColumnSpan(panel1, 2);
            panel1.Controls.Add(this.buttonHuffman);
            panel1.Controls.Add(this.buttonOptimal);
            panel1.Controls.Add(this.buttonAlphabCodes);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(468, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(206, 54);
            panel1.TabIndex = 7;
            // 
            // buttonHuffman
            // 
            this.buttonHuffman.Location = new System.Drawing.Point(0, 7);
            this.buttonHuffman.Name = "buttonHuffman";
            this.buttonHuffman.Size = new System.Drawing.Size(63, 41);
            this.buttonHuffman.TabIndex = 0;
            this.buttonHuffman.Text = "Huffman codes";
            this.buttonHuffman.UseVisualStyleBackColor = true;
            this.buttonHuffman.Click += new System.EventHandler(this.buttonHuffman_Click);
            // 
            // buttonOptimal
            // 
            this.buttonOptimal.Location = new System.Drawing.Point(138, 7);
            this.buttonOptimal.Name = "buttonOptimal";
            this.buttonOptimal.Size = new System.Drawing.Size(63, 41);
            this.buttonOptimal.TabIndex = 2;
            this.buttonOptimal.Text = "Optimal codes";
            this.buttonOptimal.UseVisualStyleBackColor = true;
            this.buttonOptimal.Click += new System.EventHandler(this.buttonOptimal_Click);
            // 
            // buttonAlphabCodes
            // 
            this.buttonAlphabCodes.Location = new System.Drawing.Point(69, 7);
            this.buttonAlphabCodes.Name = "buttonAlphabCodes";
            this.buttonAlphabCodes.Size = new System.Drawing.Size(63, 41);
            this.buttonAlphabCodes.TabIndex = 1;
            this.buttonAlphabCodes.Text = "Alphab. codes";
            this.buttonAlphabCodes.UseVisualStyleBackColor = true;
            this.buttonAlphabCodes.Click += new System.EventHandler(this.buttonAlphabCodes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 310);
            this.Controls.Add(tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Cryptography, labs 1-3";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProbability;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonHuffman;
        private System.Windows.Forms.Button buttonOptimal;
        private System.Windows.Forms.Button buttonAlphabCodes;
    }
}

