using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonTypes;
using System.Net.Mail;

namespace ClientApp
{
	public partial class FormKnock : Form
	{
		public ServerInfo serverInfo;
		public MailAddress mailAddress;

		bool changed=false;
		bool Changed
		{
			get { return changed; }
		}

		public FormKnock()
		{
			InitializeComponent();

			textServerIP.TextChanged += new EventHandler(formFieldChanged);
			textServerPort.TextChanged += new EventHandler(formFieldChanged);
			textEmail.TextChanged += new EventHandler(formFieldChanged);
			textName.TextChanged += new EventHandler(formFieldChanged);
		}

		void formFieldChanged(object sender, EventArgs e)
		{
			changed = true;
		}

		private void buttonKnock_Click(object sender, EventArgs e)
		{
			errorProvider.Clear();

			string host = textServerIP.Text;
			int port = 0;

			try { port = int.Parse(textServerPort.Text); }
			catch ( FormatException )
			{
				errorProvider.SetError(textServerPort, "Bad integer number!");
				return;
			}
			if ( ( port < 1 ) || ( port > 65535 ) )
			{
				errorProvider.SetError(textServerPort, "Please, specify valid port number (1-65535)");
				return;
			}

			serverInfo = new ServerInfo(host, port);


			try { mailAddress = new MailAddress(textEmail.Text); }
			catch ( FormatException )
			{
				errorProvider.SetError(textEmail, "Bad e-mail. Use the user@example.com format please.");
				return;
			}
			if ( textName.Text != "" )
				mailAddress = new MailAddress(textEmail.Text, textName.Text);

			this.DialogResult = DialogResult.OK;
			this.Close();

		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void FormKnock_Load(object sender, EventArgs e)
		{
			if ( serverInfo != null )
			{
				if ( serverInfo.Host != null )
				{
					textServerIP.Text = serverInfo.Host;
				}
				if ( serverInfo.Port != 0 )
				{
					textServerPort.Text = serverInfo.Port.ToString();
				}
			}
			if ( mailAddress != null )
			{
				textEmail.Text = mailAddress.Address;

				if ( mailAddress.DisplayName != "" )
				{
					textName.Text = mailAddress.DisplayName;
				}
			}

			changed = false;
		}
	}
}