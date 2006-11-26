using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace ClientApp
{
	static class Program
	{
				UdpClient udpClient;
		Settings sets = new Settings();

		static DbClient dbClient;
		static List<Letter> messages;
		Thread threadProcess;
		bool dbAvailable = false;

		bool inProcess = false;

		public bool InProcess
		{
			get { return inProcess; }
			set
			{
				if ( inProcess == value )
					return;
				inProcess = value;
				if ( ( inProcess ) && ( dbAvailable ) )
				{
					threadProcess = new Thread(ProcessTask);
					threadProcess.IsBackground = true;
					threadProcess.Name = "ProcessTask thread";
					threadProcess.Start();
				}
				else
				{
					if ( threadProcess != null )
						threadProcess.Abort();
				}
			}
		}

		private void UdpReceived(IAsyncResult iar)
		{
			IPEndPoint remoteIPEndPoint = null;

			byte[] bytes = udpClient.EndReceive(iar, ref remoteIPEndPoint);
			SpamLanguage verb = (SpamLanguage)bytes[0];

			switch ( verb )
			{
			case SpamLanguage.Start:
				if ( bytes.Length >= sizeof(Int32) + 1 )
				{
					sets.RobotId = BitConverter.ToInt32(bytes, 1);
				}
				sets.SpamServerHost = remoteIPEndPoint.Address.ToString();
				sets.SpamServerPort = remoteIPEndPoint.Port;
				sets.Save();

				if ( !InProcess )
					InProcess = true;
				break;

			case SpamLanguage.Stop:
				InProcess = false;
				if ( remoteIPEndPoint.Address.ToString() ==
					sets.SpamServerHost )
					LogAddText("Stopped by server");
				else
					LogAddText("Stopped by robot");

				break;
			default:
				LogAddText("Unsupported command received");
				break;
			}

			udpClient.BeginReceive(UdpReceived, iar);
		}

		private void ProcessTask()
		{
			List<SimpleMailTask> simpleTasks = new List<SimpleMailTask>();

			while ( inProcess )
			{
				// Load emails				
				simpleTasks.Clear();
				foreach ( SimpleMailTask task in
					dbClient.GetTasks(sets.LettersDoze, sets.RobotId) )
				{ simpleTasks.Add(task); }

				if ( simpleTasks.Count == 0 )
				{
					inProcess = false;
					break;
				}

				// Send
				foreach ( SimpleMailTask task in simpleTasks )
				{
					// aquire letter
					Letter letterToSend = Letter.ById(messages, task.MessageID);

					if ( letterToSend == null )
					{
						try
						{ letterToSend = dbClient.GetMessageById(task.MessageID); }
						catch ( Exception exc )
						{
							LogAddText("Getting letter: " + exc.Message);
							break;
						}

						if ( messages.Count == messages.Capacity )
							messages.RemoveAt(messages.Count - 1);

						messages.Add(letterToSend);
					}

					AuthServerInfo tempSmtp = null;
					// try few times to send
					for ( int i = 0; i < sets.ErrorsBeforeSwitchSmtp; i++ )
					{
						// pick smtp
						try { tempSmtp = dbClient.GetAnySmtp(); }
						catch ( Exception e )
						{
							LogAddText("Attempt #" + ( i + 1 ).ToString() +
								". Unable to pick up a SMTP server! " + e.Message);
							Thread.Sleep(1500);
							continue;
						}

						if ( SendMail(task.Address, letterToSend, tempSmtp, task.TaskId) )
						{ LogAddText("Message sent."); break; } // exit from `for` loop
						else
						{
							LogAddText("Attempt #" + ( i + 1 ).ToString() +
										". SMTP server "+tempSmtp.Host+
										" failed to send mail. Task ID = "+task.TaskId.ToString());
						}
					}
				}

				if ( !inProcess )
					break;
			}

			LogAddText("All done. (No more tasks in database " + sets.DbName + ")");
		}

		protected bool SendMail(MailAddress targetEmail,
			Letter letter, AuthServerInfo smtpServer, int TaskId)
		{
			MailAddress from;
			MailMessage msg = null;

			if ( smtpServer.FromName != null )
				from = new MailAddress(smtpServer.FromAddr, smtpServer.FromName);
			else
				from = new MailAddress(smtpServer.FromAddr);

			msg = new MailMessage(from, targetEmail);

			msg.Body = letter.Body;
			msg.IsBodyHtml = letter.IsHtml;
			msg.Subject = letter.Subject;

			SmtpClient sc;
			sc = new SmtpClient(smtpServer.Host, smtpServer.Port);
			NetworkCredential nc = new NetworkCredential(
				smtpServer.Login, smtpServer.Password);
			sc.Credentials = nc;
			sc.EnableSsl = smtpServer.UseSSL;

			try { sc.Send(msg); }
			catch ( Exception exc )
			{
				LogAddText("Sending failed: " + exc.Message);

				string Query =
	@"UPDATE emails
SET State=NULL
WHERE Id=" + TaskId.ToString();

				dbClient.SendQuery(Query);
				return false;
			}

			string sqlUpdateQueryTemplate =
@"UPDATE emails
SET State=" + DbClient.TokenDone(sets.RobotId) + @"
WHERE Id=" + TaskId.ToString();

			dbClient.SendQuery(sqlUpdateQueryTemplate);

			string DoneMessage = "Task with id = " + TaskId.ToString() +
				" is done";

			LogAddText(DoneMessage);
			return true;
		}

		/// <summary>
		/// Sends command to the Settings.SpamServerHost:Settings.SpamServerPort
		/// </summary>
		private void Say(SpamLanguage cmd)
		{
			Say(sets.SpamServerHost, sets.SpamServerPort, cmd);
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

		private void buttonKnock_Click(object sender, EventArgs e)
		{
			FormKnock fKnock = new FormKnock();
			fKnock.serverInfo = new ServerInfo(sets.SpamServerHost, sets.SpamServerPort);

			if ( fKnock.ShowDialog() == DialogResult.OK )
			{
				Say(fKnock.serverInfo.Host,
					fKnock.serverInfo.Port,
					SpamLanguage.KnockKnock);
			}
		}

		private void bnOptions_Click(object sender, EventArgs e)
		{
			FormOptions fOpts = new FormOptions();
			fOpts.Show();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			bool createdNew;
			Mutex mu = new Mutex(false, "ClientApplicationMutex",
				out createdNew);
			if ( !createdNew )
			{
				Application.Exit();
				return;
			}


			try
			{
				udpClient = new UdpClient(sets.RobotPort, AddressFamily.InterNetwork);
				udpClient.BeginReceive(UdpReceived, new object());
			}
			catch ( SocketException exc )
			{
				MessageBox.Show("Cannot create UDP socket",
					"Port: " + sets.SpamServerPort.ToString() +
					Environment.NewLine + exc.Message +
					Environment.NewLine + "Server cannot control us",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}


			dbClient = new DbClient(sets.DbHost, sets.DbUser, sets.DbPassword, sets.DbName);

			try { dbClient.OpenConnection(); }
			catch ( Exception e )
			{
				MessageBox.Show(e.Message, "Cannot connect to database");
			}

			if ( !dbClient.IsConnectionOpened )
			{
				MessageBox.Show("Database functions will be disabled for this session due to the connection problems.", sets.DbName + " is not available");
				dbAvailable = false;
			}
			else { dbAvailable = true; }

			if ( messages == null )
				messages = new List<Letter>(sets.MaxLettersCache);

			Application.Run();

			mu.Close();
		}
	}
}