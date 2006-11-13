using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace ClientApp
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			bool createdNew;
			Mutex mu = new Mutex(false,"ClientApplicationMutex",
				out createdNew);
			if ( !createdNew )
			{
				MessageBox.Show("Another copy of the Client Application is already running!");
				Application.Exit();
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			FormClient frmClient = new FormClient();
			if ( Environment.CommandLine
				.ToLower()
				.Contains(@"/hide") )
			{
				Application.Run();
			}
			Application.Run(frmClient);

			//mu.ReleaseMutex();
			mu.Close();
		}
	}
}