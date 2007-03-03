using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ММИО_л1
{
    public partial class FormAskDim : Form
    {
        int n = 0, m = 0;

        public int N
        {
            get
            {
                return n;
            }
        }
        public int M
        {
            get
            {
                return m;
            }
        }

        public FormAskDim()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            m = (int)numericUpDownM.Value;
            n = (int)numericUpDownN.Value;
            Close();
        }
    }
}