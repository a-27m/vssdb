using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab_06
{
	public partial class Form06 : Form
	{
		public Form06()
		{
			InitializeComponent();
			try
			{
				StreamReader rtfFile = new StreamReader("task6.rtf");
				this.richTextBox1.Rtf = rtfFile.ReadToEnd();
				rtfFile.Close();
			}
			catch
			{ }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			for ( int i = 0; i < 10; i++ )
				;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Test");
		}
	}
}