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
			Mutex mu = new Mutex(false, "ClientApplicationMutex",
				out createdNew);
			if ( !createdNew )
			{
				Application.Exit();
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			FormClient frmClient = new FormClient();
			if ( Environment.CommandLine.ToLower().Contains(@"/hide") )
				Application.Run();
			else
				Application.Run(frmClient);

			//mu.ReleaseMutex();
			mu.Close();
		}
	}
}