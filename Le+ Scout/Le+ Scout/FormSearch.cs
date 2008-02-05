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
            dgvData.AutoGenerateColumns = true;
            this.FormClosing += new FormClosingEventHandler(FormSearch_FormClosing);
        }

        void FormSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dgvData.SelectedRows.Count > 1)
                e.Cancel = true;
        }

        public DataGridView DataGridView1
        {
            get
            {
                return dgvData;
            }
        }

        public int SelectedId
        {
            get
            {
                return (int)dgvData["id", dgvData.SelectedRows[0].Index].Value;
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