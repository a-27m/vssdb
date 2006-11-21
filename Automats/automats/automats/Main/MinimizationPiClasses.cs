using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace automats.Main
{
    public partial class MinimizationPiClasses : Form
    {
        public void AddLine(string item)
        {
            listBox1.Items.Add(item);
        }

        public MinimizationPiClasses(Form container)
        {
            InitializeComponent();
            MdiParent = container;
            Clear();
        }

        public void Clear()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("-= Sequence of pi-classes:  =-");
        }
    }
}