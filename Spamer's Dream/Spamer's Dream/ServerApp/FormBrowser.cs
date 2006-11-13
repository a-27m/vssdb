using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ServerApp
{
	public partial class FormBrowser : Form
	{
		public FormBrowser(string pageSource)
		{
			InitializeComponent();
			webBrowser1.DocumentText = pageSource;
		}
		public FormBrowser(string pageSource, string title)
		{
			InitializeComponent();
			webBrowser1.DocumentText = pageSource;
			webBrowser1.Document.Encoding = "windows-1251";
			if ( !String.IsNullOrEmpty(title) )
				this.Text += ": '" + title + "'";
		}

		~FormBrowser()
		{
			if ( webBrowser1 != null )
				webBrowser1.Dispose();
		}
	}
}