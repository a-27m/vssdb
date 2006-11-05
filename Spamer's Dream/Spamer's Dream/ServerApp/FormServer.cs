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

		//List<Robot> listRobot = null;
		//List<Letter> listLetter = null;

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

		//private void PopulateMessages()
		//{
		//    MySqlDataReader sqlReader =
		//        dbClient.GetQueryReader(selectMessagesQuery);

		//    listLetter = new List<Letter>();
		//    while ( sqlReader.Read() )
		//    {
		//        int Id = sqlReader.GetInt32(0);
		//        string Subject = sqlReader.GetString(1);
		//        string Body = sqlReader.GetString(2);
		//        bool IsHtml = sqlReader.GetBoolean(3);
		//        listLetter.Add(new Letter(Id, Subject, Body, IsHtml));
		//    }

		//    sqlReader.Close();
		//    FillListMessages();
		//}

		//private void PopulateRobots()
		//{
		//    MySqlDataReader sqlReader =
		//        dbClient.GetQueryReader(selectRobotsQuery);

		//    Robot robot = new Robot();
		//    listRobot = new List<Robot>();
		//    while ( sqlReader.Read() )
		//    {
		//        // IP, HumanName, SmtpID
		//        robot.IP = sqlReader.GetString(0);
		//        robot.Name = sqlReader.GetString(1);
		//        robot.SmtpId = sqlReader.GetInt32(2);
		//        listRobot.Add(robot);
		//    }

		//    sqlReader.Close();

		//    for ( int i = 0; i < listRobot.Count; i++ )
		//    {
		//        Robot tmpRobot = listRobot[i];
		//        tmpRobot.SmtpServer =
		//            dbClient.GetSmtpServerById(tmpRobot.SmtpId);
		//        listRobot[i] = tmpRobot;
		//    }

		//    FillListRobots();
		//}

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

		//private void FillListMessages()
		//{
		//    listBoxMessages.Items.Clear();
		//    foreach ( Letter letter in listLetter )
		//    {
		//        string item = "";
		//        item += "#" + letter.Id.ToString()
		//            + " ";
		//        item += letter.Subject == null ? "<no subject>" :
		//            "'" + letter.Subject + "'";
		//        item += ", as ";
		//        item += letter.IsHtml ? "HTML" : "text";

		//        listBoxMessages.Items.Add(item);
		//    }
		//}

		//private void FillListRobots()
		//{
		//    listBoxRobots.Items.Clear();

		//    if ( listRobot == null )
		//    {
		//        listBoxRobots.Items.Add("<no robots in database>");
		//        return;
		//    }

		//    foreach ( Robot robot in listRobot )
		//    {
		//        string item = "";
		//        item += robot.IP + " \"";
		//        item += robot.Name + "\"; SMTP: ";
		//        item += robot.SmtpServer.Host + ":";
		//        item += robot.SmtpServer.Port.ToString() + ", ";
		//        item += robot.SmtpServer.Username + ":";
		//        item += robot.SmtpServer.Password + ", ";
		//        item += robot.SmtpServer.UseSSL ? "using SSL" : "not using SSL";

		//        listBoxRobots.Items.Add(item);
		//    }
		//}

		#region Events handlers

		private void FormServer_Load(object sender, EventArgs e)
		{
			//if ( DbAvailable )
			//{
			//    tabControl.SelectedTab = tabControl.TabPages["tabMessages"];
			//    PopulateMessages();
			//}
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormOptions fOpts = new FormOptions();
			fOpts.Show();
		}

		//private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//    switch ( tabControl.SelectedIndex )
		//    {
		//    case 0: // emails
		//        //if ( DbAvailable )
		//        //    PopulateEmails();
		//        break;
		//    case 1: // messages
		//        if ( DbAvailable )
		//            PopulateMessages();
		//        break;
		//    case 2: // robots
		//        if ( DbAvailable )
		//            PopulateRobots();
		//        break;
		//    case 3: // common

		//        break;
		//    default:
		//        break;
		//    }
		//}

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
			if ( DbAvailable ){				
			int ra = dbClient.SendQuery(
@"UPDATE emails
SET State=NULL");

			MessageBox.Show("Rows affected: " + ra,
				"Cleanup");}
				else
					MessageBox.Show("Database is not connected");
		}
	}
}