using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XmlSample
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.Run(new frmMain());
			}
			catch (ArgumentException ex)
			{
				System.Diagnostics.Trace.WriteLine(ex.Message);
			}
		}
	}
}