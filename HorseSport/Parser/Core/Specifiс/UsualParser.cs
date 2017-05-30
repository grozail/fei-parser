using ClosedXML.Excel;
using HorseSport.Parser.Core.Util;
using HorseSport.Parser.Model.Event;
using HorseSport.Parser.Model.Mark;
using HorseSport.Parser.Model.Mark.Container;
using HorseSport.Parser.Model.Mark.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Core.Specific {
	abstract class UsualParser : NotYoungParser {

		public static Competition Parse(XLWorkbook workbook, string fileName) {
			var competition = new Competition(fileName);
			ExtractStartInfo<UsualParticipation>(workbook.Worksheet("Start List (2)"));
			ExtractResultsInfo(workbook.Worksheet("Results (2)"));
			TryExtractMarks(workbook);
			var participationList = mapIdPart.ToList();
			participationList.Sort(delegate (KeyValuePair<string, Participation> k1, KeyValuePair<string, Participation> k2) {
				if (int.Parse(k1.Value.Position.Rank) < int.Parse(k2.Value.Position.Rank))
					return -1;
				else if (int.Parse(k1.Value.Position.Rank) == int.Parse(k2.Value.Position.Rank))
					return 0;
				else
					return 1;
			});
			participationList.ForEach(k => competition.Participations.Add(k.Value));
			return competition;
		}

		private static void TryExtractMarks(XLWorkbook workbook) {
			workbook.Worksheets.ForEach(sheet => {
				mapStartPart.ForEach(entry => {
					if (entry.Key.Equals(sheet.Name.Trim(trimChars))) {
						var participation = entry.Value as UsualParticipation;
						if (participation.Position.Status.Equals("R")) {
							// key = column; value = position
							Dictionary<string, string> markCols = sheet.Row(9).CellsUsed(c => c.GetString().Trim(trimChars).Length == 1).
								ToDictionary(c => c.Address.ColumnLetter, c => c.GetString().Trim(trimChars));
							Dictionary<string, double> posScore = new Dictionary<string, double>();
							markCols.ForEach(e => posScore.Add(e.Value, 0));
							int upperBound = sheet.RowsUsed(r => r.Cell(PIVOT_COL).GetString().Length > 1).First().RowNumber();
							using (var exRows = sheet.RowsUsed(r => r.RowNumber() > 9 && r.RowNumber() < upperBound)) {
								ExtractExercises(exRows, participation, markCols, posScore);
							}
							using (var colRows = sheet.RowsUsed(r => r.RowNumber() >= upperBound && r.Cell(NUMBER_COL).Value.GetType() == typeof(double))) {
								ExtractCollectiveMarks(colRows, participation, markCols, posScore);
							}
							//FUCK MICROSOFT, JUST FUCK IT FOR NEXT CODE
							ExtractUsualResults(posScore, participation);
						}
					}
				});
			});
		}

		private static void ExtractUsualResults(Dictionary<string, double> posScore, UsualParticipation participation) {
			double total = 0;
			posScore.ForEach(e => {
				total += e.Value;
				participation.UsualResults.Add(new UsualResult(string.Format(nfi, "{0:0.000}", e.Value / 3.7), e.Key));
			});
			participation.Total = new Total(string.Format(nfi, "{0:0.000}", total / 3.7 / 5));
		}

		private static void ExtractExercises(
				IXLRows exRows,
				UsualParticipation participation,
				Dictionary<string, string> markCols,
				Dictionary<string, double> posScore) {
			exRows.ForEach(r => {
				var ex = new Exercise(r.Cell(NUMBER_COL).GetString().Trim(trimChars));
				markCols.ForEach(e => {
					double score = r.Cell(e.Key).GetDouble() * r.Cell(COEF_COL).GetValue<int>();
					ex.Marks.Add(new Mark(e.Value, string.Format(nfi, "{0:0.0}", score)));
					posScore[e.Value] += score;
				});
				participation.Exercises.Add(ex);
			});
		}

		private static void ExtractCollectiveMarks(
				IXLRows colRows,
				UsualParticipation participation,
				Dictionary<string, string> markCols,
				Dictionary<string, double> posScore) {
			colRows.ForEach(r => {
				var cm = new CollectiveMark(r.Cell(NUMBER_COL).GetString().Trim(trimChars));
				markCols.ForEach(e => {
					double score = r.Cell(e.Key).GetDouble() * r.Cell(COEF_COL).GetValue<int>();
					cm.Marks.Add(new Mark(e.Value, string.Format(nfi, "{0:0.0}", score)));
					posScore[e.Value] += score;
				});
				participation.CollectiveMarks.Add(cm);
			});
		}
	}
}
