using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CommonTypes
{
	[Serializable]
	public class ServerInfo
	{
		public string Host;
		public int Port;

		public ServerInfo(string host, int port)
		{
			Host = host;
			Port = port;
		}

		public ServerInfo()
		{
			Host = null;
			Port = 0;
		}
	}

	[Serializable]
	public class AuthServerInfo : ServerInfo
	{
		public bool UseSSL = false;

		public string Username;
		public string Password;

		public AuthServerInfo(string host, int port, string username, string password)
			: base(host, port)
		{
			Username = username;
			Password = password;
		}

		public AuthServerInfo(string host, int port, string username, string password, bool UseSsl)
			: base(host, port)
		{
			this.Username = username;
			this.Password = password;
			this.UseSSL = UseSsl;
		}

		public AuthServerInfo()
			: base()
		{
			Username = null;
			Password = null;
		}
	}

	public enum SpamLanguage
	{
		KnockKnock,//c
		Start,//s
		Stop,//s
	}

	public class Letter
	{
		public int Id;
		public string Subject;
		public string Body;
		public bool IsHtml;
		public Letter(int Id, string Subject, string Body, bool IsHtml)
		{
			this.Id = Id;
			this.Subject = Subject;
			this.Body = Body;
			this.IsHtml = IsHtml;
		}

		/// <summary>
		/// Warning: searches with T~O(N^2)
		/// </summary>
		/// <param name="id">Id of requested message</param>
		/// <returns>Requested letter or null if not found</returns>
		public static Letter ById(IEnumerable<Letter> messages, int id)
		{
			IEnumerator<Letter> enumer = messages.GetEnumerator();

			while ( enumer.MoveNext() )
				if ( enumer.Current.Id == id )
					return enumer.Current;
			return null;
		}
	}

	public struct Robot
	{
		public int Id;
		public string Name;
		public int SmtpId;
		public string IP;

		public AuthServerInfo SmtpServer;

		public Robot(string Name, string IP, int SmtpId, AuthServerInfo SmtpServer)
		{
			this.Id = 0;
			this.Name = Name;
			this.IP = IP;
			this.SmtpId = SmtpId;
			this.SmtpServer = SmtpServer;
		}

		public Robot(int Id, string IP)
		{
			this.IP = IP;
			this.Id = Id;
			this.Name = null;
			this.SmtpId = 0;
			this.SmtpServer = null;
		}
	}

	public struct SimpleMailTask
	{
		public MailAddress Address;
		public int MessageID;

		public SimpleMailTask(MailAddress Address, int MessageID)
		{
			this.Address = Address;
			this.MessageID = MessageID;
		}

		public SimpleMailTask(string Address, string DisplayName, int MessageID)
		{
			this.Address = new MailAddress(Address, DisplayName);
			this.MessageID = MessageID;
		}
	}

	public class DbClient
	{
		#region const strings

		public const string selectSmtpByIdQuery =
@"SELECT Host,Port,Login,Password,UseSSL
FROM smtpservers
WHERE Id = ";

		public const string selectValidHostnamesQuery =
@"SELECT Id, IP
FROM robots
WHERE (IP <> '0.0.0.0') AND (IP <> '255.255.255.255')";

		public const string connectionStrFormat =
@"server={0};user id={1}; password={2}; database={3}; pooling=false";

		#endregion

		MySqlConnection sqlConnection;

		string DbHost, DbUser, DbPassword, DbName;

		public DbClient(string DbHost,
			string DbUser, string DbPassword, string DbName)
		{
			this.DbHost = DbHost;
			this.DbUser = DbUser;
			this.DbPassword = DbPassword;
			this.DbName = DbName;
		}

		public bool IsConnectionOpened
		{
			get { return sqlConnection.State == ConnectionState.Open; }
			set
			{
				if ( value )
					OpenConnection();
				else
					sqlConnection.Close();
			}
		}

		public void OpenConnection()
		{
			if ( sqlConnection != null )
				sqlConnection.Close();

			string connectionStr = String.Format(connectionStrFormat,
				DbHost, DbUser, DbPassword, DbName);

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

		public bool TryConnection()
		{
			if ( sqlConnection == null ) { OpenConnection(); }

			while ( sqlConnection.State != ConnectionState.Open )
			{
				DialogResult dRes;
				dRes = MessageBox.Show(
					"Please, check DB server " +
					"availability and settings." +
					Environment.NewLine + Environment.NewLine +
					"Try to connect again?", "Database connection failed",
					MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

				if ( dRes == DialogResult.No )
					return false;

				sqlConnection.Dispose();
				OpenConnection();
			}
			return true;
		}

		public void CloseConnection()
		{
			if ( sqlConnection != null )
				sqlConnection.Close();
		}

		public IEnumerable<SimpleMailTask> LoadEmails(int CountLimit)
		{
			//List<SimpleMailTask> tasks = new List<SimpleMailTask>(CountLimit);

			if ( !TryConnection() )
				throw new Exception("Connection must to be opened first");

			string sqlLockTablesQuery = "LOCK TABLES emails READ;";
			MySqlCommand sqlCmd =
				new MySqlCommand(sqlLockTablesQuery, sqlConnection);

			try { sqlCmd.ExecuteNonQuery(); }

			catch ( MySqlException ex )
			{
				MessageBox.Show(
					String.Format("Query '{1}' failed:{2}{3}",
					sqlLockTablesQuery,
					Environment.NewLine + Environment.NewLine,
					ex.Message));
				yield break;
			}

			string sqlQueryFreeEmails =
@"SELECT Email,Username, MsgID
FROM emails
WHERE ServedBy IS NULL
ORDER BY RAND()
LIMIT " + CountLimit.ToString();

			MySqlDataReader sqlReader = GetQueryReader(sqlQueryFreeEmails);

			if ( sqlReader == null )
			{
				sqlCmd = new MySqlCommand("UNLOCK TABLES;", sqlConnection);

				try { sqlCmd.ExecuteNonQuery(); }

				catch ( MySqlException ex )
				{
					MessageBox.Show(
						String.Format("Query '{1}' failed:{2}{3}",
						sqlLockTablesQuery,
						Environment.NewLine + Environment.NewLine,
						ex.Message));
				}

				yield break;
			}

			while ( sqlReader.Read() )
			{
				yield return new SimpleMailTask(
					sqlReader.GetString(0),// address
					sqlReader.GetString(1),// display name
					sqlReader.GetInt32(2));// msgid
			}

			sqlReader.Close();
			yield break;
		}

		public Letter LoadMessage(int Id)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public MySqlDataReader GetQueryReader(string Query)
		{
			if ( !TryConnection() )
				throw new Exception("Connection must to be opened first");

			MySqlDataReader sqlReader = null;
			MySqlCommand sqlCmd =
			new MySqlCommand(Query, sqlConnection);

			try { sqlReader = sqlCmd.ExecuteReader(); }

			catch ( MySqlException ex )
			{
				MessageBox.Show("Failed read query answer: " +
					Environment.NewLine + ex.Message);
			}
			return sqlReader;
		}

		public IEnumerable<Robot> GetRobotsHosts()
		{
			if ( !TryConnection() )
				yield break;

			MySqlDataReader sqlReader =
				this.GetQueryReader(selectValidHostnamesQuery);

			if ( sqlReader == null )
				yield break;

			while ( sqlReader.Read() )
				yield return new Robot(
					sqlReader.GetInt32(0),// id
					sqlReader.GetString(1));// ip

			if ( sqlReader != null )
				sqlReader.Close();
		}

		public AuthServerInfo GetSmtpServerById(int id)
		{
			AuthServerInfo servInf = new AuthServerInfo();
			MySqlCommand sqlCmd = new MySqlCommand(selectSmtpByIdQuery + id.ToString(),
				sqlConnection);
			MySqlDataReader sqlReader = sqlCmd.ExecuteReader();
			if ( sqlReader.Read() )
			{

				servInf.Host = sqlReader.GetString(0);// Host
				servInf.Port = sqlReader.GetInt32(1);// Port
				servInf.Username = sqlReader.GetString(2);// login
				servInf.Password = sqlReader.GetString(3);// Password
				servInf.UseSSL = sqlReader.GetBoolean(4); // UseSSL
			}
			sqlReader.Close();
			return servInf;
		}

		public AuthServerInfo PickAnySmtp()
		{
			MySqlDataReader sqlReader = GetQueryReader(@"
SELECT * FROM smtpservers ORDER BY RAND() LIMIT 1;");

			if ( sqlReader.Read() )
			{
				return new AuthServerInfo(
					sqlReader.GetString(0),
					sqlReader.GetInt32(1),
					sqlReader.GetString(2),
					sqlReader.GetString(3),
					sqlReader.GetBoolean(4));
			}
			else
				return null;
		}

		public MailAddress RobotAddrById(int Id)
		{
			string name, email;

			MySqlDataReader sqlReader = GetQueryReader(
@"SELECT Email,Name
FROM robots
WHERE Id=" + Id.ToString() + " LIMIT 1;");

			if ( sqlReader.Read() )
			{
				email = sqlReader.GetString(0);

				if ( !sqlReader.IsDBNull(1) )
				{
					name = sqlReader.GetString(1);
					return new MailAddress(email);
				}
				else
				{
					return new MailAddress(email);
				}
			}
			else
				throw new Exception("Robot with ID " + Id.ToString() + 
					" is unknown in database");
		}
	}
}