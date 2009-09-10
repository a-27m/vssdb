using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MetroLab3
{
    public partial class FormHowmuch : Form
    {
        int n;

        public int N { get { return n; } }

        public FormHowmuch()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (!int.TryParse(txtN.Text, out n))
            {
                errorProvider1.SetError(txtN, "Допускаются только положительные целые числа");
                return; 
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}