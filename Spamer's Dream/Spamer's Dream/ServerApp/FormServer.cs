using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ServerApp.Properties;
using CommonTypes;

namespace ServerApp
{

	public partial class FormServer : Form
	{
		#region const strings

		public const string selectMessagesQuery =
@"SELECT Id,Subject,Body,IsHtml FROM messages";

		public const string selectRobotsQuery =
@"SELECT
	IP,Name,SmtpID
FROM
	robots
WHERE
	(IP <> '0.0.0.0') AND
	(IP <> '255.255.255.255')";

		#endregion

		UdpClient udpClient;
		static DbClient dbClient;
		bool DbAvailable = false;
		Settings sets = new Settings();

		bool textMsgIDChanged = false;
		bool smtpDataChanged = false;

		public FormServer()
		{
			InitializeComponent();

			#region Open UDP client
			try
			{
				udpClient = new UdpClient(sets.ServerPort);
				udpClient.BeginReceive(Priem, new object());
			}
			catch ( SocketException exc )
			{
				MessageBox.Show("Cannot open UDP socket.\r\n" +
					"Port: " + sets.RobotUdpPort.ToString() + "\r\n" +
					exc.Message);
				return;
			}
			#endregion

			dbClient = new DbClient(sets.DbHost, sets.DbUser, sets.DbPassword, sets.DbName);

			try { dbClient.OpenConnection(); }
			catch ( Exception e )
			{
				MessageBox.Show(e.Message, "Cannot connect to database");
			}

			if ( !dbClient.IsConnectionOpened )
			{
				MessageBox.Show("Database functions will be disabled for this session due to the connection problems.", sets.DbName + " is not available");
				DbAvailable = false;
			}
			else { DbAvailable = true; }
		}

		#region UDP Interface

		private delegate void VoidDelegate();

		void Priem(IAsyncResult iar)
		{
			IPEndPoint remoteIPEndPoint = null;

			byte[] bytes = udpClient.EndReceive(iar, ref remoteIPEndPoint);

			SpamLanguage verb = (SpamLanguage)bytes[0];

			switch ( verb )
			{
			case SpamLanguage.KnockKnock:
				if ( DbAvailable )
				{
					string ipStr = remoteIPEndPoint.Address.ToString();
					dbClient.AddRobot(ipStr);
				}
				break;

			default:
				Thread messageThread = new Thread(new ThreadStart(delegate()
				{
					MessageBox.Show("Incorrect command received");
				}));
				messageThread.Start();
				break;
			}

			udpClient.BeginReceive(Priem, iar);
		}

		private void Say(string Host, int Port, SpamLanguage cmd)
		{
			Say(Host, Port, cmd, new byte[0]);
		}
		private void Say(string Host, int Port,
			SpamLanguage cmd, byte[] attachment)
		{
			byte[] dgrm = new byte[attachment.Length + 1];

			dgrm[0] = (byte)cmd;
			for ( int i = 0; i < attachment.Length; i++ )
			{
				dgrm[i + 1] = attachment[i];
			}

			UdpClient uclient = null;

			try
			{
				uclient = new UdpClient(Host, Port);
				uclient.Send(dgrm, dgrm.Length);

			}
			catch ( SocketException sexc )
			{
				MessageBox.Show(sexc.Message);
			}
			finally { if ( uclient != null ) uclient.Close(); }
		}

		#endregion

		private void SendStartToAll()
		{
			int robotPort = sets.RobotUdpPort;

			foreach ( Robot robot in dbClient.GetRobotsHosts() )
			{
				try
				{
					Say(robot.IP, robotPort,
						SpamLanguage.Start, BitConverter.GetBytes(robot.Id));
				}
				catch ( Exception exc )
				{
					MessageBox.Show(exc.Message);
					continue;
				}
			}
		}
		private void SendStopToAll()
		{
			int robotPort = sets.RobotUdpPort;

			foreach ( Robot robot in dbClient.GetRobotsHosts() )
			{
				try
				{
					Say(robot.IP, robotPort,
						SpamLanguage.Stop);
				}
				catch ( Exception exc )
				{
					MessageBox.Show(exc.Message);
					continue;
				}
			}
		}

		#region Events handlers

		private void FormServer_Load(object sender, EventArgs e)
		{
			if ( DbAvailable )
				tabControl1_SelectedIndexChanged(sender, e);
			listMessages.ValueMember = "Id";
		}
		private void FormServer_Shown(object sender, EventArgs e)
		{
			double msec = 600;
			double steps = 30;
			for ( double i = this.Opacity; i <= 1.0; i += 1.0 / steps )
			{
				this.Opacity = i;
				Application.DoEvents();
				Thread.Sleep((int)( Math.Ceiling(msec / steps) ));
			}
		}
		private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
		{
			double msec = 5;
			double steps = 40;
			for ( double i = this.Opacity; i >= 0; i -= 1.0 / steps )
			{
				this.Opacity = i;
				//Application.DoEvents();
				Thread.Sleep((int)( Math.Ceiling(msec / steps) ));
			}
		}

		private void buttonOptions_Click(object sender, EventArgs e)
		{
			FormOptions fOpts = new FormOptions();
			fOpts.Show();
		}

		private void ClearStates_Click(object sender, EventArgs e)
		{
			if ( DbAvailable )
			{
				int ra = dbClient.SendQuery(
	@"UPDATE emails
SET State=NULL");

				MessageBox.Show("Rows affected: " + ra,
					"Cleanup");
			}
			else
				MessageBox.Show("Database is not connected");
		}

		private void emptyEmailsMenuItem_Click(object sender, EventArgs e)
		{
			if ( !DbAvailable )
				MessageBox.Show("Database is not connected");

			if ( ( MessageBox.Show(
				"You are about to delete all the target e-mall addresses" +
				Environment.NewLine +
				"from current database '" + sets.DbName + "'. New e-mails can be" +
				Environment.NewLine +
				"added later with \"Load...\" button on the \"Emails\" tab",
				"Delete all e-mail addresses from database?",
				MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK ) &&

				( MessageBox.Show(
				"This operation cannot be undone!",
				"Confirm delete operation",
				MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK ) )

				dbClient.ClearEmails();

		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dbClient.CloseConnection();
			this.DialogResult = DialogResult.OK;
			Application.Exit();
		}

		private void buttonStartAll_Click(object sender, EventArgs e)
		{
			if ( DbAvailable )
				SendStartToAll();
			else
				MessageBox.Show("Database is not connected");
		}
		private void buttonStop_Click(object sender, EventArgs e)
		{
			if ( DbAvailable )
				SendStopToAll();
			else
				MessageBox.Show("Database is not connected");
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ( !DbAvailable )
			{
				foreach ( Control ctrl in tabControl1.SelectedTab.Controls )
					ctrl.Enabled = false;
				MessageBox.Show("Database is not connected");
				return;
			}

			switch ( tabControl1.SelectedTab.Name )
			{
			case "tabEmails":
				this.MinimumSize = new System.Drawing.Size(this.MinimumSize.Width, 270);
				listEmails.DataSource = 
					dbClient.GetEmailsList(!tabEmails_checkPendingOnly.Checked);
				break;
			case "tabMessages":
				this.MinimumSize = new System.Drawing.Size(this.MinimumSize.Width, 240);
				listMessages.DataSource = dbClient.GetMessagesList();
				break;
			case "tabSmtps":
				this.MinimumSize = new System.Drawing.Size(this.MinimumSize.Width, 400);
				listSmtps.DataSource = dbClient.GetSmtpsList();
				break;
			case "tabRobots":
				this.MinimumSize = new System.Drawing.Size(this.MinimumSize.Width, 225);
				listRobots.DataSource = dbClient.GetRobotsList();
				break;
			}
		}

		private void tabEmails_listEmails_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ( listEmails.SelectedItems.Count < 1 )
			{
				textMsgID.Clear();
				return;
			}
			// check whether msgids differs for selection
			SimpleMailTask prevTask = listEmails.SelectedItems[0] as SimpleMailTask;

			bool MsgIdVaries = false;

			foreach ( Object selItem in listEmails.SelectedItems )
			{
				SimpleMailTask task = selItem as SimpleMailTask;
				if ( task.MessageID != prevTask.MessageID )
				{
					MsgIdVaries = true;
					break;
				}
				prevTask = task;
			}

			if ( !MsgIdVaries )
			{
				SimpleMailTask task = listEmails.SelectedValue as SimpleMailTask;
				textMsgID.Text = task.MessageID.ToString();
			}
			else
			{
				textMsgID.Clear();
			}

			textMsgIDChanged = false;
		}
		private void tabEmails_buttonLoad_Click(object sender, EventArgs e)
		{
			if ( openFileDialogEmails.ShowDialog() == DialogResult.OK )
			{
				string fileName = openFileDialogEmails.FileName;
				//foreach ( string fileName in openFileDialogEmails.FileNames )
				//{
				FileInfo fileInfo = new FileInfo(fileName);
				StreamReader fReader = new StreamReader(fileName, Encoding.GetEncoding(1251));

				char[] delims;
				switch ( fileInfo.Extension )
				{
				case ".csv":
					delims = new char[] { ';' };
					break;
				//case "txt":  // *.txt falls into this branch also
				default:
					delims = new char[] { '|' };
					break;
				}

				int lineNo = 0;
				while ( !fReader.EndOfStream )
				{
					string line = fReader.ReadLine();
					lineNo++;

					// split line into email and maybe name
					string[] tmp = line.Split(delims, StringSplitOptions.RemoveEmptyEntries);
					if ( tmp.Length < 1 )
					{
						MessageBox.Show("Input file was in bad format at line " + lineNo.ToString(), "Bad file format",
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						fReader.Close();
						return;
					}
					if ( tmp.Length == 1 )
						dbClient.AddEmail(tmp[0]);
					if ( tmp.Length == 2 )
						dbClient.AddEmail(tmp[0], tmp[1]);
					uint fakeVar;
					if ( ( tmp.Length == 3 ) &&
						( uint.TryParse(tmp[2], out fakeVar) ) )
						dbClient.AddEmail(tmp[0], tmp[1], tmp[2]);
				}
				//}

				tabControl1_SelectedIndexChanged(sender, e);
			}
		}
		private void tabEmails_textMsgID_TextChanged(object sender, EventArgs e)
		{
			textMsgIDChanged = true;
		}
		private void tabEmails_buttonSet_Click(object sender, EventArgs e)
		{
			if ( !textMsgIDChanged )
				return;

			int newId = 0;
			errorProvider.Clear();
			errorProvider.SetIconAlignment(textMsgID, ErrorIconAlignment.MiddleLeft);
			try { newId = int.Parse(textMsgID.Text); }
			catch ( FormatException )
			{
				errorProvider.SetError(textMsgID,
					"Wrong message id, please enter integer number.");
				return;
			}

			foreach ( object selItem in listEmails.SelectedItems )
			{
				SimpleMailTask task = selItem as SimpleMailTask;
				task.MessageID = newId;
				dbClient.UpdateTask(task.TaskId, task);
			}

			int[] currentSelection = new int[listEmails.SelectedIndices.Count];
			listEmails.SelectedIndices.CopyTo(currentSelection, 0);

			tabControl1_SelectedIndexChanged(sender, e);

			listEmails.SelectedIndexChanged -=
				tabEmails_listEmails_SelectedIndexChanged;
			listEmails.ClearSelected();
			foreach ( int selIndex in currentSelection )
				listEmails.SetSelected(selIndex, true);
			listEmails.SelectedIndexChanged +=
				tabEmails_listEmails_SelectedIndexChanged;

			textMsgIDChanged = false;
		}
		private void tabEmails_textMsgID_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ( e.KeyChar == (char)( Keys.Enter ) )
			{
				tabEmails_buttonSet_Click(sender, e);
			}
		}
		private void tabEmails_checkPendingOnly_CheckedChanged(object sender, EventArgs e)
		{
			listEmails.DataSource =
				dbClient.GetEmailsList(!tabEmails_checkPendingOnly.Checked);
		}

		private void tabMsg_buttonEdit_Click(object sender, EventArgs e)
		{
			if ( listMessages.SelectedItems.Count == 0 )
				return;

			Letter letter;
			letter = listMessages.SelectedValue as Letter;
			letter = dbClient.GetMessageById(letter.Id);

			FormLetter fLetter = new FormLetter();
			fLetter.letter = letter;
			if ( fLetter.ShowDialog() == DialogResult.OK )
				letter = fLetter.letter;
			else
				return;

			dbClient.UpdateMessage(letter.Id, letter);
			listMessages.DataSource = dbClient.GetMessagesList();
		}
		private void tabMsg_buttonAddLetter_Click(object sender, EventArgs e)
		{
			Letter letter;
			FormLetter fLetter = new FormLetter();
			if ( fLetter.ShowDialog() == DialogResult.OK )
			{
				letter = fLetter.letter;
				dbClient.AddLetter(letter);

				listMessages.DataSource = dbClient.GetMessagesList();
			}
		}
		private void tabMsg_listMessages_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			tabMsg_buttonPreview_Click(sender, e);
		}
		private void tabMsg_buttonRemove_Click(object sender, EventArgs e)
		{
			if ( listMessages.SelectedItems.Count == 0 )
				return;

			Letter letter;
			if ( MessageBox.Show("Delete selected letter" +
				( listMessages.SelectedItems.Count > 1 ? "s?" : "?" ),
				"Confirm remove operation",
				 MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
				 == DialogResult.OK )
			{
				int countRemoved = 0;
				foreach ( Object selectedItem in listMessages.SelectedItems )
				{
					letter = selectedItem as Letter;
					letter = dbClient.GetMessageById(letter.Id);

					countRemoved +=
					   dbClient.DeleteLetter(letter.Id);

				}
				MessageBox.Show("Deleted " + countRemoved.ToString() + " letters",
					"Successfully removed",
					MessageBoxButtons.OK, MessageBoxIcon.Information);

				listMessages.DataSource = dbClient.GetMessagesList();
			}
		}
		private void tabMsg_buttonPreview_Click(object sender, EventArgs e)
		{
			if ( listMessages.SelectedItems.Count == 0 )
				return;

			Letter letter;
			letter = listMessages.SelectedValue as Letter;
			letter = dbClient.GetMessageById(letter.Id);

			FormBrowser fBro = new FormBrowser(letter.Body, letter.Subject);
			fBro.Show();
		}

		private void tabSmtps_listSmtps_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ( listEmails.SelectedItems.Count < 1 )
			{
				tabSmtps_ClearSmtpData();
				return;
			}

			// check whether data differs for selection
			AuthServerInfo prevItem = listSmtps.SelectedItems[0] as AuthServerInfo;

			bool dataVaries = false;

			foreach ( Object selItem in listSmtps.SelectedItems )
			{
				AuthServerInfo item = selItem as AuthServerInfo;
				if ( !prevItem.EqualsNoId(item) )
				{
					dataVaries = true;
					break;
				}

				prevItem = item;
			}

			if ( !dataVaries )
			{
				AuthServerInfo asi = listSmtps.SelectedValue as AuthServerInfo;
				tabSmtps_textHost.Text = asi.Host;
				tabSmtps_textPort.Text = asi.Port.ToString();
				tabSmtps_textLogin.Text = asi.Login;
				tabSmtps_textPassword.Text = asi.Password;
				tabSmtps_checkSSL.Checked = asi.UseSSL;
				tabSmtps_textName.Text = asi.FromName;
				tabSmtps_textEmail.Text = asi.FromAddr;
			}
			else
			{
				tabSmtps_ClearSmtpData();
			}

			smtpDataChanged = false;
		}
		private void tabSmtps_ClearSmtpData()
		{
			tabSmtps_textHost.Clear();
			tabSmtps_textPassword.Clear();
			tabSmtps_textPort.Clear();
			tabSmtps_textLogin.Clear();
			tabSmtps_checkSSL.Checked = false;
			tabSmtps_textName.Clear();
			tabSmtps_textEmail.Clear();
			return;
		}
		private void tabSmtps_smtpDataChanged(object sender, EventArgs e)
		{
			smtpDataChanged = true;
		}
		private void tabSmtps_buttonAdd_Click(object sender, EventArgs e)
		{
			AuthServerInfo smtp = _parseSmtpData();
			if ( smtp == null )
				return;

			dbClient.AddSmtp(smtp);
			listSmtps.DataSource = dbClient.GetSmtpsList();
		}
		private void tabSmtps_buttonSet_Click(object sender, EventArgs e)
		{
			if ( !smtpDataChanged )
				return;

			if ( listSmtps.SelectedItems.Count < 1 )
				return;

			AuthServerInfo newSmtp = _parseSmtpData();

			if ( newSmtp == null )
				return;

			foreach ( object selItem in listSmtps.SelectedItems )
			{
				int curId = ( selItem as AuthServerInfo ).Id;
				dbClient.UpdateSmtp(curId, newSmtp);
			}

			// save current selection
			int[] currentSelection = new int[listSmtps.SelectedIndices.Count];
			listSmtps.SelectedIndices.CopyTo(currentSelection, 0);

			// what for we're doint this?
			tabControl1_SelectedIndexChanged(sender, e);

			// suspend SelectedIndexChanged processing
			listSmtps.SelectedIndexChanged -=
				tabSmtps_listSmtps_SelectedIndexChanged;

			// restore previous selection
			listEmails.ClearSelected();
			foreach ( int selIndex in currentSelection )
				listSmtps.SetSelected(selIndex, true);

			// restore SelectedIndexChanged processing
			listSmtps.SelectedIndexChanged +=
				tabSmtps_listSmtps_SelectedIndexChanged;

			smtpDataChanged = false;
		}
		private void tabSmtps_buttonRemove_Click(object sender, EventArgs e)
		{
			if ( listSmtps.SelectedItems.Count == 0 )
				return;

			AuthServerInfo smtp;
			if ( MessageBox.Show("Delete selected server" +
				( listMessages.SelectedItems.Count > 1 ? "s?" : "?" ),
				"Confirm remove operation",
				 MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
				 == DialogResult.OK )
			{
				int countRemoved = 0;
				foreach ( Object selectedItem in listSmtps.SelectedItems )
				{
					smtp = selectedItem as AuthServerInfo;
					smtp = dbClient.GetSmtpServerById(smtp.Id);

					countRemoved +=
					   dbClient.DeleteSmtp(smtp.Id);
				}

				MessageBox.Show("Deleted " + countRemoved.ToString() + " servers",
					"Successfully removed",
					MessageBoxButtons.OK, MessageBoxIcon.Information);

				listSmtps.DataSource = dbClient.GetSmtpsList();
			}
		}
		private AuthServerInfo _parseSmtpData()
		{
			errorProvider.Clear();

			AuthServerInfo smtp = new AuthServerInfo();

			smtp.Host = tabSmtps_textHost.Text;

			try { smtp.Port = int.Parse(tabSmtps_textPort.Text); }
			catch ( FormatException )
			{
				errorProvider.SetError(tabSmtps_textPort, "Bad integer number!");
				return null;
			}

			if ( ( smtp.Port < 1 ) || ( smtp.Port > 65535 ) )
			{
				errorProvider.SetError(tabSmtps_textPort, "Please, specify valid port number (1-65535)");
				return null;
			}

			if ( tabSmtps_textHost.Text == "" )
			{
				errorProvider.SetError(tabSmtps_textHost, "Empty server name");
				return null;
			}

			if ( tabSmtps_textLogin.Text != "" )
			{
				smtp.Login = tabSmtps_textLogin.Text;
				smtp.Password = tabSmtps_textPassword.Text;
			}

			if ( tabSmtps_textName.Text != "" )
			{
				smtp.FromName = tabSmtps_textName.Text;
			}
			if ( tabSmtps_textEmail.Text == "" )
			{
				errorProvider.SetError(tabSmtps_textEmail, "\"From\" e-mail must to present.");
				return null;
			}
			smtp.FromAddr = tabSmtps_textEmail.Text;

			smtp.UseSSL = tabSmtps_checkSSL.Checked;

			return smtp;
		}

		private void tabRobots_buttonAdd_Click(object sender, EventArgs e)
		{
			tabRobots_textIP.Text.Trim();
			errorProvider.Clear();

			string[] str_octets = tabRobots_textIP.Text.Split('.');
			if ( str_octets.Length != 4 )
			{
				errorProvider.SetError(tabRobots_textIP, "Wrong IP address.");
			}

			byte[] octets = new byte[4];
			IPAddress ip;

			try
			{
				for ( int i = 0; i < 4; i++ )
					octets[i] = byte.Parse(str_octets[i]);
			}
			catch
			{
				errorProvider.SetError(tabRobots_textIP, "Wrong IP address format," + Environment.NewLine +
					" please use xxx.xxx.xxx.xxx format.");
				return;
			}

			ip = new IPAddress(octets);

			dbClient.AddRobot(ip.ToString());
			listRobots.DataSource = dbClient.GetRobotsList();
		}
		private void tabRobots_buttonRemove_Click(object sender, EventArgs e)
		{
			if ( listRobots.SelectedItems.Count == 0 )
				return;

			Robot robot;
			if ( MessageBox.Show("Delete selected robot" +
				( listMessages.SelectedItems.Count > 1 ? "s?" : "?" ),
				"Confirm remove operation",
				 MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
				 == DialogResult.OK )
			{
				int countRemoved = 0;
				foreach ( Object selectedItem in listRobots.SelectedItems )
				{
					robot = selectedItem as Robot;
					robot = dbClient.GetRobotById(robot.Id);

					countRemoved +=
					   dbClient.DeleteRobot(robot.Id);
				}

				MessageBox.Show("Deleted " + countRemoved.ToString() +
					" robot" + ( countRemoved > 1 ? "s." : "." ),
					"Successfully removed",
					MessageBoxButtons.OK, MessageBoxIcon.Information);

				listRobots.DataSource = dbClient.GetRobotsList();
			}
		}
		private void tabRobots_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ( listRobots.SelectedItems.Count != 1 )
				return;

			tabRobots_textIP.Text = ( listRobots.SelectedValue as Robot ).IP;
		}

		#endregion
	}
}