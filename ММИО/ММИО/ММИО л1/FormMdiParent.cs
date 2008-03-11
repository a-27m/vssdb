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

        private void FormMdiParent_Shown(object sender, EventArgs e)
        {
            //newToolStripMenuItem_Click(sender, e);
            Form3 childForm = new Form3();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
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
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    (ActiveMdiChild as Form1).SaveData(saveFileDialog1.FileName);
                }
            }
        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}