using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientApp.Properties;
using System.Configuration;
using System.IO;

namespace ClientApp
{
	public partial class FormOptions : Form
	{
		Settings appSettings = new Settings();
		bool textDbPassword_Changed = false;

		public FormOptions()
		{
			InitializeComponent();
		}

		private void FormOptions_Load(object sender, EventArgs e)
		{
			textUdpInPort.Text = appSettings.RobotPort.ToString();

			textCacheDepth.Text = appSettings.MaxLettersCache.ToString();
			textDoze.Text = appSettings.LettersDoze.ToString();
			textErrors.Text = appSettings.ErrorsBeforeSwitchSmtp.ToString();

			textDbHost.Text = appSettings.DbHost;
			textDbName.Text = appSettings.DbName;
			textDbUser.Text = appSettings.DbUser;
			textDbPassword.Text = "********";

			textDbPassword_Changed = false;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			errorProvider.Clear();

			try { appSettings.RobotPort = int.Parse(textUdpInPort.Text); }
			catch ( FormatException )
			{ errorProvider.SetError(textUdpInPort, "Bad port number"); return; }

			try { appSettings.LettersDoze = int.Parse(textDoze.Text); }
			catch ( FormatException )
			{ errorProvider.SetError(textDoze, "Bad integer number"); return; }

			try { appSettings.MaxLettersCache = int.Parse(textCacheDepth.Text); }
			catch ( FormatException )
			{ errorProvider.SetError(textCacheDepth, "Bad integer number"); return; }

			try { appSettings.ErrorsBeforeSwitchSmtp = int.Parse(textErrors.Text); }
			catch ( FormatException )
			{ errorProvider.SetError(textErrors, "Bad integer number"); return; }
			if ( appSettings.ErrorsBeforeSwitchSmtp < 1 )
			{ errorProvider.SetError(textErrors, "Number is too small"); return; }

			appSettings["DbHost"] = textDbHost.Text;
			appSettings["DbName"] = textDbName.Text;
			appSettings["DbUser"] = textDbUser.Text;
			if ( textDbPassword_Changed )
				appSettings["DbPassword"] = textDbPassword.Text;

			appSettings.Save();
			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			// Settings changes are discarded 'cause are not saved
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void textDbPassword_TextChanged(object sender, EventArgs e)
		{
			textDbPassword_Changed = true;
		}
	}
}