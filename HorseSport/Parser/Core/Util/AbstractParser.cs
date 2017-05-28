using ClosedXML.Excel;
using HorseSport.Parser.Model.Event;
using HorseSport.Parser.Model.Event.Properties;
using HorseSport.Parser.Model.Living;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HorseSport.Parser.Core.Util {
	abstract class AbstractParser {
		protected static string PIVOT_COL = "A";

		protected static char[] trimChars = {' ', '\r', '\n'};
		protected static Regex firstName = Globals.INSTANCE.AthleteFirstNameRegex;
		protected static Regex familyName = Globals.INSTANCE.AthleteFamilyNameRegex;
		protected static NumberFormatInfo nfi = Globals.INSTANCE.NumberFormat;

		private static string RIDER_NAME_COL = "C";
		private static string RIDER_ID_COL = "D";
		private static string RIDER_NF_COL = "E";
		protected static Athlete ExtractAthleteFromRow(IXLRow row) {
			var riderNames = row.Cell(RIDER_NAME_COL).GetString().Split('\n')[0];   // selecting all before \n and using regex
			var matchFamily = familyName.Match(riderNames);
			var matchFirst = firstName.Match(riderNames);
			var riderFEIID = row.Cell(RIDER_ID_COL).GetString();
			var riderNF = row.Cell(RIDER_NF_COL).GetString();
			return new Athlete(riderFEIID, riderNF, matchFirst.Value.Trim(trimChars), matchFamily.Value.Trim(trimChars));
		}

		private static string HORSE_NAME_COL = "F";
		private static string HORSE_ID_COL = "G";
		protected static Horse ExtractHorseFromRow(IXLRow row) {
			var horseName = row.Cell(HORSE_NAME_COL).GetString().Split('\n')[0].Trim(trimChars);
			var horseFEIID = row.Cell(HORSE_ID_COL).GetString();
			return new Horse(horseFEIID, horseName);
		}

		private static string PRIZE_MONEY_COL = "I";
		protected static void TryExtractPrizeMoney(IXLRow row, Participation participation) {
			if (row.Cell(PRIZE_MONEY_COL).Value.GetType() != typeof(string)) {
				participation.PrizeMoney = new PrizeMoney(string.Format(nfi, "{0:0.00}", row.Cell(PRIZE_MONEY_COL).GetDouble()));
			}
		}

		protected static void ExtractPosition(IXLRow row, Participation participation, int estimatedPosition) {
			if (row.Cell(PIVOT_COL).Value.GetType() != typeof(string)) {
				participation.Position = new Position(estimatedPosition.ToString(), "R");
			}
			else {
				participation.Position = new Position(estimatedPosition.ToString(), row.Cell(PIVOT_COL).GetString());
			}
		}
	}
}
