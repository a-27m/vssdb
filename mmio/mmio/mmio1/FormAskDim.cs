using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mmio1
{
    public partial class FormAskDim : Form
    {
        public int n
        {
            get
            {
                return numericUpDownN.Value as int;
            }
        }

        public int m
        {
            get
            {
                return numericUpDownM.Value as int;
            }
        }

        public FormAskDim()
        {
            InitializeComponent();
        }

        private void menuItemNext_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void menuItemCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}