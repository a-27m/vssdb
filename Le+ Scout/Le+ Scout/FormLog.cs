using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Le__Scout
{
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();
        }

        public void Print(string text)
        {
            box.Text +=  string.Format("[{0}] {1}{2}",
                DateTime.Now.ToString("HH:MM:ss.fff"), // 0
                text, // 1
                Environment.NewLine); // 2
        }

    }
}