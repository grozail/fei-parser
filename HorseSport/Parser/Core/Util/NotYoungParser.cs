using ClosedXML.Excel;
using HorseSport.Parser.Model.Event;
using HorseSport.Parser.Model.Event.Properties;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HorseSport.Parser.Core.Util {
	abstract class NotYoungParser : AbstractParser {
		protected static Dictionary<string, Participation> mapStartPart;
		protected static Dictionary<string, Participation> mapIdPart;
		protected static string NUMBER_COL = "B";
		protected static string COEF_COL = "D";

		protected static void ExtractStartInfo<T>(IXLWorksheet sheet) where T : Participation, new() {
			using (var rowPool = sheet.RowsUsed(r => r.RowNumber() > 5 &&
				r.Cell(PIVOT_COL).Value.GetType() == typeof(double))) {
				mapStartPart = rowPool.ToDictionary(r => r.Cell(PIVOT_COL).GetString().Trim(trimChars),
					r => (new T() as Participation));
				mapIdPart = rowPool.ToDictionary(r => r.Cell("C").GetString().Trim(trimChars),
					r => mapStartPart[r.Cell(PIVOT_COL).GetString().Trim(trimChars)]);
			}
		}

		protected static void ExtractResultsInfo(IXLWorksheet sheet) {
			using (var rowPool = sheet.RowsUsed(r => r.Cell(PIVOT_COL).Value.GetType() == typeof(double) ||
					r.Cell(PIVOT_COL).GetString().Trim(trimChars).ToUpper().Equals("EL") ||
					r.Cell(PIVOT_COL).GetString().Trim(trimChars).ToUpper().Equals("WD"))) {
				int currentPosition = 1;
				rowPool.ForEach(r => {
					var horseNo = r.Cell("B").GetString().Trim(trimChars);
					var participation = mapIdPart[horseNo];
					participation.Athlete = ExtractAthleteFromRow(r);
					participation.Horse = ExtractHorseFromRow(r);
					participation.Complement = new Complement("false");
					TryExtractPrizeMoney(r, participation);
					ExtractPosition(r, participation, currentPosition);
					++currentPosition;
				});
			}
		}

		protected static double TryGetScore(IXLRow r, KeyValuePair<string, string> entry, Participation participation, Logger logger) {
			double score = 0;
			try {
				score = r.Cell(entry.Key).GetDouble() * r.Cell(COEF_COL).GetDouble();
			}
			catch (Exception e) {
				logger.Warn(e, "\nATHLETE: {0}\nHORSE: {1}\nCELLS:{3}, {4}",
					participation.Athlete.FamilyName, participation.Horse.FEIID, r.Cell(entry.Key).Address, r.Cell(COEF_COL).Address);
			}
			return score;
		}

		protected static void ExamineMistakes(IXLRow r1, IXLRow r2, Participation participation, Dictionary<string, string> markCols, Logger logger) {
			markCols.ForEach(e => {
				if (r1.Cell(e.Key).GetString().Trim(trimChars).Length > 0 ||
					r2.Cell(e.Key).GetString().Trim(trimChars).Length > 0) {
					logger.Warn("\nMISTAKES FOUND, CHECK RESULTS MANUALLY\nATHLETE: {0}\nHORSE: {1}\nCELLS:{3}, {4}",
						participation.Athlete.FamilyName, participation.Horse.FEIID, r1.Cell(e.Key).Address, r2.Cell(e.Key).Address);
				}
			});
		}
	}
}
