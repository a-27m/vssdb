using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ServerApp.Properties;
using System.Configuration;
using System.IO;

namespace ServerApp
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
			textUdpPort.Text = appSettings.RobotUdpPort.ToString();
			textDbHost.Text = appSettings.DbHost;
			textDbName.Text = appSettings.DbName;
			textDbUser.Text = appSettings.DbUser;
			textDbPassword.Text = "********";
			textDbPassword_Changed = false;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			errorProvider.Clear();

			try { appSettings["UdpPort"] = int.Parse(textUdpPort.Text); }
			catch ( FormatException)
			{ errorProvider.SetError(textUdpPort, "Bad port number"); return; }

			appSettings["DbHost"] = textDbHost.Text;
			appSettings["DbName"] = textDbName.Text;
			appSettings["DbUser"] = textDbUser.Text;
			if (textDbPassword_Changed)
				appSettings["DbPassword"] = textDbPassword.Text;

			appSettings.Save();
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			// Settings are discarded 'cause are not saved
			this.Close();
		}

		private void textDbPassword_TextChanged(object sender, EventArgs e)
		{
			textDbPassword_Changed = true;
		}
	}
}