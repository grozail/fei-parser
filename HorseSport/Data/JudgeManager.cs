using HorseSport.Parser.Model.Living;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using System.Xml.Linq;

namespace HorseSport.Data {
	static class JudgeManager {
		private static string FILE_PATH = "judges.xml";
		private static Dictionary<string, Judge> mapFEIIDtoJudge;
		private static Logger logger = LogManager.GetCurrentClassLogger();

		internal static Dictionary<string, Judge> Data {
			get {
				return mapFEIIDtoJudge;
			}

			set {
				mapFEIIDtoJudge = value;
			}
		}

		public static void LoadData() {
			Data = new Dictionary<string, Judge>();
			try {
				var document = XDocument.Load(FILE_PATH);
				foreach (var el in document.Root.Elements()) {
					try {
						Data.Add(el.Attribute("FEIID").Value, 
							new Judge(
									el.Attribute("FEIID").Value, 
									el.Attribute("NF").Value, 
									el.Attribute("FirstName").Value, 
									el.Attribute("FamilyName").Value, 
									el.Attribute("OfficialStatus").Value, 
									"-1"));
					}
					catch (Exception e) {
						logger.Info(e, "EXCEPTION: occured in JudgeManager while reading data.|CAUSE: Nonunique or null FEIID");
					}	
				}
			}
			catch (Exception e) {
				logger.Info(e, "EXCEPTION: occured in JudgeManager while loading data");
			}
		}
	}
}
