﻿using ClosedXML.Excel;
using HorseSport.Parser.Model.Event;
using HorseSport.Parser.Model.Event.Properties;
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
	}
}