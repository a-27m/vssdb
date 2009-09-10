using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lab1.Forms;

namespace lab1
{
    public partial class FormAskDocuments : Form
    {
        public FormChild[] forms;
        Form parent;

        public FormAskDocuments(Form MyParent)
        {
            InitializeComponent();
            parent = MyParent;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Form[] children = (parent as mdiParent).MdiChildren;

            forms = new FormChild[checkedListBox1.CheckedIndices.Count];

            int count = 0;
            foreach (int i in checkedListBox1.CheckedIndices)
                forms[count++] = (FormChild)children[i];

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormAskDocuments_Shown(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();

            int count = 1;
            foreach (FormChild child in (parent as mdiParent).MdiChildren)
                checkedListBox1.Items.Add(string.Format("{0}. {1}", count++, child.Text), false);
        }
    }
}