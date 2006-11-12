using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace ServerApp
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
			Mutex mu = new Mutex(false, "ServerApplicationMutex",
				out createdNew);
			if ( !createdNew )
			{
				MessageBox.Show("Another copy of the Server Application is already running!");
				Application.Exit();
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormServer());

			mu.ReleaseMutex();
			mu.Close();
		}
	}
}