using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ExtendingTerminalAutomat eta;

        private void Form1_Load(object sender, EventArgs e)
        {
            eta = new ExtendingTerminalAutomat();
            eta.Add("���");
            eta.Add("���");
        }
    }
}