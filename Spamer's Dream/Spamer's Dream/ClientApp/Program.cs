using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
		}
	}
}