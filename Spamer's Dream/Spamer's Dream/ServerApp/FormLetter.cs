using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ServerApp
{
	public partial class FormLetter : Form
	{
		public Letter letter;

		public FormLetter()
		{
			InitializeComponent();
		}

		private void buttonLoad_Click(object sender, EventArgs e)
		{
			if ( openFileDialog.ShowDialog() == DialogResult.OK )
			{
				StreamReader f = new StreamReader(openFileDialog.FileName);
				textBody.Text = f.ReadToEnd();
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.letter.Subject = textSubject.Text;
			this.letter.Body = textBody.Text;
			this.letter.IsHtml = ( checkIsHtml ? 1 : 0 );
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.letter = null;
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}