using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lab3_Transport;

namespace ММИО_л1
{
    public partial class FormMdiParent : Form
    {
        public FormMdiParent()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 childForm = new Form1();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void newTranspToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 childForm = new Form3();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void FormMdiParent_Shown(object sender, EventArgs e)
        {
            newTranspToolStripMenuItem_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IForm1 iForm;
                Form childForm;
                switch (openFileDialog1.FilterIndex)
                {
                    case 1:
                        iForm = new Form1();
                        break;
                    case 2:
                        iForm = new Form3();
                        break;
                    default:
                        MessageBox.Show("What's that?");
                        return;
                }
                childForm = (Form)iForm;
                childForm.MdiParent = this;
                childForm.WindowState = FormWindowState.Maximized;
                iForm.LoadData(openFileDialog1.FileName);
                childForm.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is Form1)
                saveFileDialog1.FilterIndex = 1;
            else if (ActiveMdiChild is Form3)
                saveFileDialog1.FilterIndex = 2;
            else
                saveFileDialog1.FilterIndex = 3;
            
            if (ActiveMdiChild is IForm1)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    (ActiveMdiChild as IForm1).SaveData(saveFileDialog1.FileName);
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(
                (ActiveMdiChild.Controls["dataGridView1"] as DataGridView).GetClipboardContent(),
                true
                );
        }
    }
}