using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CommonTypes
{
	#region My primitives
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

		public Letter(int Id, string Subject, bool IsHtml)
		{
			this.Id = Id;
			this.Subject = Subject;
			this.Body = null;
			this.IsHtml = IsHtml;
		}

		public Letter(int Id, bool IsHtml)
		{
			this.Id = Id;
			this.Subject = null;
			this.Body = null;
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

		public override string ToString()
		{
			string asString = "Id: " + Id.ToString();
			if ( Subject != null )
				asString += ", \"" + Subject + "\"";
			asString += ( IsHtml ? ", HTML" : ", text" );

			return asString;
		}
	}

	public struct Robot
	{
		public int Id;
		public MailAddress Address;
		public string IP;
		public int SmtpId;

		public AuthServerInfo SmtpServer;

		//public Robot(string Name, string IP, int SmtpId, AuthServerInfo SmtpServer)
		//{
		//    this.Id = 0;
		//    this.Name = Name;
		//    this.IP = IP;
		//    this.SmtpId = SmtpId;
		//    this.SmtpServer = SmtpServer;
		//}

		public Robot(MailAddress Address, string IP, int SmtpId, AuthServerInfo SmtpServer)
		{
			this.Id = 0;
			this.Address = Address;
			this.IP = IP;
			this.SmtpId = SmtpId;
			this.SmtpServer = SmtpServer;
		}

		public Robot(int Id, string IP)
		{
			this.IP = IP;
			this.Id = Id;
			this.Address = null;
			this.SmtpId = 0;
			this.SmtpServer = null;
		}
	}

	public class SimpleMailTask
	{
		public int TaskId;
		public MailAddress Address;
		public int MessageID;

		public SimpleMailTask(int TaskId, MailAddress Address, int MessageID)
		{
			this.TaskId = TaskId;
			this.Address = Address;
			this.MessageID = MessageID;
		}

		public SimpleMailTask(int TaskId, string Address, string DisplayName, int MessageID)
		{
			this.TaskId = TaskId;
			this.Address = new MailAddress(Address, DisplayName);
			this.MessageID = MessageID;
		}

		public SimpleMailTask(int TaskId, string Address, int MessageID)
		{
			this.TaskId = TaskId;
			this.Address = new MailAddress(Address);
			this.MessageID = MessageID;
		}

		public override string ToString()
		{
			string asString = "";
			if ( ( Address.DisplayName == null ) ||
				( Address.DisplayName == "" ) )
				asString = Address.Address.ToString();
			else
				asString = string.Format("\"{0}\" <{1}>",
					Address.DisplayName, Address.Address);

			asString += ", with message ID: " + MessageID.ToString();

			return asString;
		}
	}

	#endregion

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
			{
				sqlConnection.Close();
				sqlConnection.Dispose();
			}

			string connectionStr = String.Format(connectionStrFormat,
				DbHost, DbUser, DbPassword, DbName);

			sqlConnection = new MySqlConnection(connectionStr);
			sqlConnection.Open();
		}
		public void CloseConnection()
		{
			if ( sqlConnection != null )
				sqlConnection.Close();
		}

		public MySqlDataReader GetQueryReader(string Query)
		{
			if ( !IsConnectionOpened )
				throw new Exception("Connection must to be opened first");

			MySqlDataReader sqlReader = null;
			MySqlCommand sqlCmd =
			new MySqlCommand(Query, sqlConnection);

			try { sqlReader = sqlCmd.ExecuteReader(); }

			catch ( MySqlException ex )
			{
				MessageBox.Show("Failed read query answer: " +
					Environment.NewLine + ex.Message);
				//throw;
			}
			return sqlReader;
		}

		public int SendQuery(string Query)
		{
			if ( !IsConnectionOpened )
				throw new Exception("Connection must to be opened first");

			MySqlCommand sqlCmd =
				new MySqlCommand(Query, sqlConnection);

			int LinesAffected = -1;
			try { LinesAffected = sqlCmd.ExecuteNonQuery(); }

			catch ( MySqlException ex )
			{
				throw new Exception(
					String.Format("Query '{0}' failed:{1}{2}",
					Query,
					Environment.NewLine + Environment.NewLine,
					ex.Message), ex);
				//throw ex;
			}

			return LinesAffected;
		}

		public AuthServerInfo GetAnySmtp()
		{
			MySqlDataReader sqlReader = GetQueryReader(
@"SELECT Host,Port,Login,Password,UseSSL
FROM smtpservers
ORDER BY RAND() LIMIT 1;");

			if ( sqlReader != null )
				if ( sqlReader.Read() )
				{
					AuthServerInfo serverInfo = new AuthServerInfo(
						sqlReader.GetString(0),
						sqlReader.GetInt32(1),
						sqlReader.GetString(2),
						sqlReader.GetString(3),
						sqlReader.GetBoolean(4));

					sqlReader.Close();
					return serverInfo;
				}

			throw new Exception("Failed to aquire SMTP server parameters from database");

		}

		public Robot GetRobotById(int Id)
		{
			string name, email;
			MailAddress mailAddr = null;

			string ip;
			int smtpId;
			Robot robot;

			MySqlDataReader sqlReader = GetQueryReader(
@"SELECT Email,Name,IP,SmtpID
FROM robots
WHERE Id=" + Id.ToString() + " LIMIT 1;");

			if ( sqlReader != null )
				if ( sqlReader.Read() )
				{
					email = sqlReader.GetString(0);

					if ( !sqlReader.IsDBNull(1) )
					{
						name = sqlReader.GetString(1);
						mailAddr = new MailAddress(email, name);
					}
					else
						mailAddr = new MailAddress(email);

					ip = sqlReader.GetString(2);
					smtpId = sqlReader.GetInt32(3);

					sqlReader.Close();

					robot = new Robot(mailAddr, ip, smtpId, null);
					return robot;
				}

			throw new Exception("Robot with ID " + Id.ToString() +
				" is unknown in database " + DbName);
		}
		public MailAddress GetRobotAddrById(int Id)
		{
			string name = null, email = null;
			MailAddress mailAddr = null;

			MySqlDataReader sqlReader = GetQueryReader(
@"SELECT Email,Name
FROM robots
WHERE Id=" + Id.ToString() + " LIMIT 1;");

			if ( sqlReader != null )
				if ( sqlReader.Read() )
				{
					if ( !sqlReader.IsDBNull(0) )
						email = sqlReader.GetString(0);

					if ( !sqlReader.IsDBNull(1) )
						name = sqlReader.GetString(1);
					sqlReader.Close();

					if ( email == null )
					{
						return null;
					}
					else
					{
						if ( name == null )
							mailAddr = new MailAddress(email);
						else
							mailAddr = new MailAddress(email, name);

						return mailAddr;
					}
				}

			throw new Exception("Robot with ID " + Id.ToString() +
				" is unknown in database " + DbName);
		}
		public AuthServerInfo GetSmtpServerById(int id)
		{
			MySqlDataReader sqlReader = GetQueryReader(selectSmtpByIdQuery + id.ToString());
			if ( sqlReader != null )
				if ( sqlReader.Read() )
				{
					AuthServerInfo servInf = new AuthServerInfo();
					servInf.Host = sqlReader.GetString(0);// Host
					servInf.Port = sqlReader.GetInt32(1);// Port
					servInf.Username = sqlReader.GetString(2);// login
					servInf.Password = sqlReader.GetString(3);// Password
					servInf.UseSSL = sqlReader.GetBoolean(4); // UseSSL

					sqlReader.Close();
					return servInf;
				}

			throw new Exception("Smtp server data with id " + id.ToString() + " cannot be found");
		}
		public Letter GetMessageById(int Id)
		{
			string sqlGetMessageById =
@"SELECT Id, Subject, Body, IsHtml
FROM messages
WHERE Id=" + Id.ToString() + " LIMIT 1";

			MySqlDataReader sqlReader = GetQueryReader(sqlGetMessageById);
			if ( sqlReader != null )
				if ( sqlReader.Read() )
				{
					Letter letter = new Letter(
						sqlReader.GetInt32(0),// id
						sqlReader.GetString(1),// subj
						sqlReader.GetString(2),// body
						sqlReader.GetBoolean(3)// ishtml
						);
					sqlReader.Close();
					return letter;
				}

			throw new Exception("Letter not found!");
		}

		public IEnumerable<SimpleMailTask> GetTasks(int CountLimit, int ClientID)
		{
			string sqlQuery;

			if ( !IsConnectionOpened )
				throw new Exception("Connection must to be opened first");

			sqlQuery =
@"UPDATE emails SET State=" + DbClient.TokenSelected(ClientID) + @"
WHERE (State IS NULL)AND(MsgID>0)
ORDER BY RAND() LIMIT " + CountLimit.ToString();

			if ( SendQuery(sqlQuery) < 1 )
				yield break;

			sqlQuery =
@"SELECT Id,Email,Username,MsgID
FROM emails
WHERE State=" + DbClient.TokenSelected(ClientID);

			MySqlDataReader sqlReader = GetQueryReader(sqlQuery);

			if ( sqlReader != null )
			{
				while ( sqlReader.Read() )
				{
					SimpleMailTask task;
					if ( sqlReader.IsDBNull(2) )
						task = new SimpleMailTask(
							sqlReader.GetInt32(0),// id
							sqlReader.GetString(1),// address
							sqlReader.GetInt32(3));// msgid
					else
						task = new SimpleMailTask(
							sqlReader.GetInt32(0),// id
							sqlReader.GetString(1),// address
							sqlReader.GetString(2),// display name
							sqlReader.GetInt32(3));// msgid
					yield return task;
				}

				sqlReader.Close();
			}

			sqlQuery =
@"UPDATE emails
SET State=" + DbClient.TokenTaken(ClientID) + @"
WHERE State=" + DbClient.TokenSelected(ClientID);
			if ( SendQuery(sqlQuery) < 1 )
				yield break;

			yield break;
		}
		public List<SimpleMailTask> GetEmailsList()
		{
			List<SimpleMailTask> list = new List<SimpleMailTask>();
			MySqlDataReader sqlReader = GetQueryReader("select Id,Username,email,MsgId from emails");
			while ( sqlReader.Read() )
			{
				SimpleMailTask task;

				int id = sqlReader.GetInt32(0);
				string username = sqlReader.GetString(1);
				string email = sqlReader.GetString(2);
				int msgid = sqlReader.GetInt32(3);

				if ( sqlReader.IsDBNull(1) )
					task = new SimpleMailTask(id, email, msgid);
				else
					task = new SimpleMailTask(id, email, username, msgid);

				list.Add(task);
			}
			sqlReader.Close();

			return list;
		}
		public List<Letter> GetMessagesList()
		{
			List<Letter> list = new List<Letter>();
			MySqlDataReader sqlReader = GetQueryReader("SELECT Id,Subject,IsHTML FROM messages");
			while ( sqlReader.Read() )
			{
				int id = sqlReader.GetInt32(0);
				string subject = sqlReader.GetString(1);
				bool isHtml = sqlReader.GetBoolean(2);

				Letter letter;

				if ( sqlReader.IsDBNull(1) )
					letter = new Letter(id, isHtml);
				else
					letter = new Letter(id, subject, isHtml);

				list.Add(letter);
			}
			sqlReader.Close();

			return list;
		}
		public IEnumerable<Robot> GetRobotsHosts()
		{
			if ( !IsConnectionOpened )
				throw new Exception("Connection must to be opened first");

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

		/// <returns>single-QUOTED token</returns>
		public static object TokenTaken(int ClientId)
		{
			return "'Taken by " + ClientId.ToString() + "'";
		}
		/// <returns>single-QUOTED token</returns>
		private static string TokenSelected(int ClientId)
		{
			return "'Selected by " + ClientId.ToString() + "'";
		}
		/// <returns>single-QUOTED token</returns>
		public static string TokenDone(int ClientId)
		{
			return "'Done by " + ClientId.ToString() + "'";
		}

		public void UpdateTask(int id, SimpleMailTask task)
		{
			string strFUsername =
				( task.Address.DisplayName != null ) &&
				( task.Address.DisplayName != "" ) ?
				"'{0}'" : "NULL";

			string username = string.Join("\\'",
				task.Address.DisplayName.Split('\''));

			SendQuery(string.Format(
@"UPDATE emails
SET Username=" + strFUsername + @",Email='{1}',MsgID={2}
WHERE Id={3}", username, task.Address.Address, task.MessageID, id));
		}
		public void UpdateMessage(int id, Letter letter)
		{
			string strFSubject =
				( letter.Subject != null ) &&
				( letter.Subject != "" ) ?
				"'{0}'" : "NULL";

			string strFBody =
				( letter.Body != null ) &&
				( letter.Body != "" ) ?
				"'{1}'" : "NULL";

			string subject = string.Join("\\'",
				letter.Subject.Split('\''));

			string body = string.Join("\\'",
				letter.Body.Split('\''));

			SendQuery(string.Format(
@"UPDATE messages
SET Subject=" + strFSubject + ",Body=" + strFBody + @",IsHTML={2}
WHERE Id={3}", subject, body, letter.IsHtml ? 1 : 0, id));

		}

		public void AddEmail(string email)
		{
			SendQuery(string.Format(@"INSERT Emails SET Email='{0}',MsgID=0", email));
		}
		public void AddEmail(string email, string displayName)
		{
			displayName = string.Join("\\'",
				   displayName.Split('\''));

			SendQuery(string.Format(@"INSERT Emails SET Email='{0}',Username='{1}',MsgID=0",
				email, displayName));
		}
		public void AddEmail(string email, string displayName, string MsgId)
		{
			displayName = string.Join("\\'",
				   displayName.Split('\''));

			SendQuery(string.Format(@"INSERT Emails SET Email='{0}',Username='{1}',MsgID={2}",
				email, displayName, MsgId));
		}

		public void AddRobot(string ipStr)
		{
			MySqlDataReader sqlReader =
				GetQueryReader("SELECT * FROM Robots WHERE IP='" + ipStr + "'");

			if ( !sqlReader.Read() )
				SendQuery(string.Format("INSERT Robots SET IP='{0}'", ipStr));

			sqlReader.Close();
		}
		public void AddRobot(string ipStr, MailAddress mailAddress)
		{
			string name = string.Join("\\'",
				mailAddress.DisplayName.Split('\''));

			string query = string.Format(@" Robots SET IP='{0}',Name='{1}',Email='{2}'",
					ipStr, name, mailAddress.Address);

			MySqlDataReader sqlReader =
				GetQueryReader("SELECT * FROM Robots WHERE IP='" + ipStr + "'");

			if ( sqlReader.Read() )
				query = "UPDATE" + query;
			else
				query = "INSERT" + query;
			sqlReader.Close();

			SendQuery(query);
		}

		public void AddLetter(Letter letter)
		{
			string strFSubject =
				( letter.Subject != null ) &&
				( letter.Subject != "" ) ?	"'{0}'" : "NULL";

			string strFBody =
				( letter.Body != null ) &&
				( letter.Body != "" ) ? "'{1}'" : "NULL";

			string subject = string.Join("\\'",
				letter.Subject.Split('\''));

			string body = string.Join("\\'",
				letter.Body.Split('\''));

			SendQuery(string.Format(
@"INSERT Messages
SET Subject=" + strFSubject + ",Body=" + strFBody + @",IsHTML={2}",
			  subject, body, letter.IsHtml ? 1 : 0));
		}

		public int DeleteMessage(int letterId)
		{
			return SendQuery("DELETE FROM messages WHERE Id=" + letterId.ToString() + " LIMIT 1");
		}
	}
}