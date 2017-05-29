using ClosedXML.Excel;
using HorseSport.Parser.Core.Util;
using HorseSport.Parser.Model.Event;
using HorseSport.Parser.Model.Event.Properties;
using HorseSport.Parser.Model.Mark;
using HorseSport.Parser.Model.Mark.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Core.Specific {
	abstract class YoungParser : AbstractParser {

		public static List<Competition> Parse(XLWorkbook workbook) {
			// for all young competitions
			var competitionList = new List<Competition>();
			//select results sheet
			foreach (var sheet in workbook.Worksheets.Where(x => x.Name.Contains("yo") && x.Name.Contains("(2)"))) {
				var competition = new Competition();
				//find rows with results
				using (var rowPool = sheet.RowsUsed(r => r.Cell(PIVOT_COL).Value.GetType() == typeof(double) ||
					r.Cell(PIVOT_COL).GetString().Trim(' ').ToUpper().Equals("EL") ||
					r.Cell(PIVOT_COL).GetString().Trim(' ').ToUpper().Equals("WD"))) {
					//parse result rows
					int currentPosition = 1;
					foreach (var row in rowPool) {
						var participation = new YoungParticipation();
						participation.Athlete = ExtractAthleteFromRow(row);
						participation.Horse = ExtractHorseFromRow(row);
						participation.Complement = new Complement("false");
						TryExtractPrizeMoney(row, participation);
						ExtractPosition(row, participation, currentPosition);
						TryExtractAssessments(row, participation);
						competition.Participations.Add(participation);
						++currentPosition;
					}
					competitionList.Add(competition);
				}
			}
			return competitionList;
		}

		private static string TOTAL_SCORE_COL = "P";
		private static Total ExtractTotalScore(IXLRow row) {
			return new Total(string.Format(nfi, "{0:0.0}", row.Cell(TOTAL_SCORE_COL).GetDouble()));
		}


		private static string FIRST_ASSESSMENT_COL = "J";
		private static string SECOND_ASSESSMENT_COL = "K";
		private static string THIRD_ASSESSMENT_COL = "L";
		private static string FOURTH_ASSESSMENT_COL = "M";
		private static string FIFTH_ASSESSMENT_COL = "N";
		private static List<Assessment> ExtractAssessments(IXLRow row) {
			var assessments = new List<Assessment>();

			var marks = new List<Mark>();
			marks.Add(new Mark("C", string.Format(nfi, "{0:0.0}", row.Cell(FIRST_ASSESSMENT_COL).GetDouble())));
			assessments.Add(new Assessment("1", marks));

			marks = new List<Mark>();
			marks.Add(new Mark("C", string.Format(nfi, "{0:0.0}", row.Cell(SECOND_ASSESSMENT_COL).GetDouble())));
			assessments.Add(new Assessment("2", marks));

			marks = new List<Mark>();
			marks.Add(new Mark("C", string.Format(nfi, "{0:0.0}", row.Cell(THIRD_ASSESSMENT_COL).GetDouble())));
			assessments.Add(new Assessment("3", marks));

			marks = new List<Mark>();
			marks.Add(new Mark("C", string.Format(nfi, "{0:0.0}", row.Cell(FOURTH_ASSESSMENT_COL).GetDouble())));
			assessments.Add(new Assessment("4", marks));

			marks = new List<Mark>();
			marks.Add(new Mark("C", string.Format(nfi, "{0:0.0}", row.Cell(FIFTH_ASSESSMENT_COL).GetDouble())));
			assessments.Add(new Assessment("5", marks));

			return assessments;
		}

		private static void TryExtractAssessments(IXLRow row, YoungParticipation participation) {
			if (row.Cell(PIVOT_COL).Value.GetType() != typeof(string)) {
				participation.Assessments = ExtractAssessments(row);
				participation.Total = ExtractTotalScore(row);
			}
		}
	}
}
