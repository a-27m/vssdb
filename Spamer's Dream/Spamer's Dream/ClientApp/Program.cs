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
			try
			{ Application.Run(new FormClient()); }
			catch ( Exception e )
			{
				MessageBox.Show(e.Message, "General system error");
			}
		}
	}
}