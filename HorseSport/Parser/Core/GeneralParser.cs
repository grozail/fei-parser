using ClosedXML.Excel;
using HorseSport.Parser.Core.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HorseSport.Parser.Core {
	static class GeneralParser {
		public static void Parse(string filePath) {
			using (var workbook = new XLWorkbook(filePath)) {
				var youngSheets = workbook.Worksheets.Where(sheet => sheet.Name.Contains("yo")).ToList();
				if (youngSheets.Count > 0) {
					YoungParser.Parse(workbook);
				}
				else {
					var test = workbook.Worksheets.Where(sheet => sheet.Name.Contains("1")).First()
								.RowsUsed(r => r.Cell("A").GetString().Trim('\r', '\n', ' ').Length > 1).First()
								.Cell("A").GetString();
					if (test.ToLower().Contains("collective")) {
						UsualParser.Parse(workbook);
					}
					else {
						FreestyleParser.Parse(workbook);
					}

				}
			}
		}
	}
}
