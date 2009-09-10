using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab1
{
    public partial class FormAskLawSelection : Form
    {
        public bool Ravn, Expon, Norm;

        public FormAskLawSelection()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Ravn = checkBoxRavnom.Checked;
            Expon = checkBoxExponential.Checked;
            Norm = checkBoxNormal.Checked;
            this.Close();
        }

        private void FormAskLawSelection_Load(object sender, EventArgs e)
        {
            checkBoxRavnom.Checked = Ravn;
            checkBoxExponential.Checked = Expon;
            checkBoxNormal.Checked = Norm;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled =
                checkBoxRavnom.Checked ||
                checkBoxExponential.Checked ||
                checkBoxNormal.Checked;
        }
    }
}