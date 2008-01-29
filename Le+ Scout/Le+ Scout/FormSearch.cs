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
                (int)dataGridView1["id",dataGridView1.SelectedRows[0]].Value;
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