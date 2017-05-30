using ClosedXML.Excel;
using HorseSport.Parser.Core.Specific;
using HorseSport.Parser.Model.Event;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HorseSport.Parser.Core {
	static class GeneralParser {
		private static Logger logger = LogManager.GetCurrentClassLogger();
		public static List<Competition> Parse(string filePath) {
			using (var workbook = new XLWorkbook(filePath)) {
				var youngSheets = workbook.Worksheets.Where(sheet => sheet.Name.Contains("yo")).ToList();
				if (youngSheets.Count > 0) {
					logger.Info("YoungParser invoked for {0}", filePath);
					return YoungParser.Parse(workbook, filePath.Substring(filePath.LastIndexOf("\\")));
				}
				else {
					var response = new List<Competition>();
					var test = workbook.Worksheets.Where(sheet => sheet.Name.Contains("1")).First()
										.RowsUsed(r => r.Cell("A").GetString().Trim('\r', '\n', ' ').Length > 1).First()
										.Cell("A").GetString();
					if (test.ToLower().Contains("collective")) {
						logger.Info("UsualParser invoked for {0}", filePath);
						response.Add(UsualParser.Parse(workbook, filePath.Substring(filePath.LastIndexOf("\\"))));
					}
					else {
						logger.Info("FreestyleParser invoked for {0}", filePath);
						response.Add(FreestyleParser.Parse(workbook, filePath.Substring(filePath.LastIndexOf("\\"))));
					}
					return response;
				}
			}
		}
	}
}
