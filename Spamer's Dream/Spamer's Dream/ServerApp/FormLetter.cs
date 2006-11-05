using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CommonTypes;

namespace ServerApp
{
	public partial class FormLetter : Form
	{
		public Letter letter = null;

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
			this.letter.IsHtml = checkIsHtml.Checked;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void FormLetter_Load(object sender, EventArgs e)
		{
			if ( letter != null )
			{
				textSubject.Text = letter.Subject;
				textBody.Text = letter.Body;
				checkIsHtml.Checked = letter.IsHtml;
			}
		}
	}
}