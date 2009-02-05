using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mmio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuItemNewTask1_Click(object sender, EventArgs e)
        {
            FormTaskOne fto = new FormTaskOne();
            fto.Show();
        }
    }
}