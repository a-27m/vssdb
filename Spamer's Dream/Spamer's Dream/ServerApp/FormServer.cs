using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using ServerApp.Properties;
using CommonTypes;
using System.IO;

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

		void Priem(IAsyncResult iar)
		{
			IPEndPoint remoteIPEndPoint = null;

			byte[] bytes = udpClient.EndReceive(iar, ref remoteIPEndPoint);

			SpamLanguage verb = (SpamLanguage)bytes[0];

			//switch ( verb )
			//{
			//case SpamLanguage.KnockKnock:
			//    AddRobot(remoteIPEndPoint.Address.ToString());
			//    break;
			//default:
			//    MessageBox.Show("Incorrect command received");
			//    break;
			//}

			udpClient.BeginReceive(Priem, iar);
		}

		//        private void AddRobot(string Ip)
		//        {
		//            dbClient.SendQuery(
		//@"INSERT robots
		//SET IP='"+Ip+@"',Email='"+sets.DefaultEmail+"'");
		//        }

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

		#region Events handlers

		private void FormServer_Load(object sender, EventArgs e)
		{
			if ( DbAvailable )
				tabControl1_SelectedIndexChanged(sender, e);
			listMessages.ValueMember = "Id";
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormOptions fOpts = new FormOptions();
			fOpts.Show();
		}

		private void StartAll_Click(object sender, EventArgs e)
		{
			if ( DbAvailable )
				SendStartToAll();
			else
				MessageBox.Show("Database is not connected");
		}

		#endregion

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

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ( DbAvailable )
			{
				switch ( tabControl1.SelectedTab.Name )
				{
				case "tabEmails":
					listEmails.DataSource = dbClient.GetEmailsList();
					break;
				case "tabMessages":
					listMessages.DataSource = dbClient.GetMessagesList();
					break;
				}
			}
			else
			{
				foreach ( Control ctrl in tabControl1.SelectedTab.Controls )
					ctrl.Enabled = false;
				MessageBox.Show("Database is not connected");
			}
		}

		private void buttonTab1Load_Click(object sender, EventArgs e)
		{
			if ( openFileDialogEmails.ShowDialog() == DialogResult.OK )
			{
				string fileName = openFileDialogEmails.FileName;
				//foreach ( string fileName in openFileDialogEmails.FileNames )
				//{
				FileInfo fileInfo = new FileInfo(fileName);
				StreamReader fReader = new StreamReader(fileName);

				char[] delims;
				switch ( fileInfo.Extension )
				{
				case "csv":
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
						MessageBox.Show("Input file was in bad format at line " + lineNo.ToString(), "Bad CSV file format",
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

		private void buttonTabMsgEdit_Click(object sender, EventArgs e)
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
		}

		private void listEmails_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ( listEmails.SelectedItems.Count < 1 ) {
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

		private void textMsgID_TextChanged(object sender, EventArgs e)
		{
			textMsgIDChanged = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if ( !textMsgIDChanged )
				return;

			int newId = 0;
			errorProvider.Clear();
			errorProvider.SetIconAlignment(textMsgID, ErrorIconAlignment.MiddleLeft);
			try { newId = int.Parse(textMsgID.Text); }
			catch ( FormatException )
			{
				errorProvider.SetError(textMsgID, "Wrong message id, please enter integer number.");
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

			listEmails.SelectedIndexChanged -= listEmails_SelectedIndexChanged;
			listEmails.ClearSelected();
			foreach(int selIndex in currentSelection)
				listEmails.SetSelected(selIndex, true);
			listEmails.SelectedIndexChanged += listEmails_SelectedIndexChanged;
		}
	}
}