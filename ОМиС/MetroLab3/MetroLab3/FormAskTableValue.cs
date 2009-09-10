using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MetroLab3
{
    public partial class FormAskTableValue : Form
    {
        public float Value;

        public FormAskTableValue(string Prompt)
        {
            InitializeComponent();
            labelPrompt.Text = Prompt;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            try
            {
                Value = float.Parse(textBoxValue.Text);
            }
            catch (FormatException)
            {
                errorProvider1.SetError(this, "”кажите действительное число.");
                return;
            }
            Close();
        }
    }
}