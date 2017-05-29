using HorseSport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NLog;

namespace HorseSport {
	static class Program {

		private static Logger logger = LogManager.GetCurrentClassLogger();
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			logger.Info("SESSION STARTED");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
			logger.Info("SESSION ENDED");
		}
	}
}
