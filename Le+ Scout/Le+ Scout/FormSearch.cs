using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Le__Scout
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            this.FormClosing += new FormClosingEventHandler(FormSearch_FormClosing);
        }

        void FormSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
                e.Cancel = true;
        }

        public DataGridView DataGridView1
        {
            get
            {
                return dataGridView1;
            }
        }

        public int SelectedId
        {
            get
            {
                return (int)dataGridView1["id", dataGridView1.SelectedRows[0].Index].Value;
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}