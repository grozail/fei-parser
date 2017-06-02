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
using NLog;

namespace HorseSport.Parser.Core.Specific {
	abstract class FreestyleParser : NotYoungParser {
		private static Logger logger = LogManager.GetCurrentClassLogger();
		public static Competition Parse(XLWorkbook workbook, string fileName) {
			var competition = new Competition(fileName);
			ExtractStartInfo<FreestyleParticipation>(workbook.Worksheet("Start List (2)"));
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
						var participation = entry.Value as FreestyleParticipation;
						if (participation.Position.Status.Equals("R")) {
							//key = column; value = position
							Dictionary<string, string> markCols = sheet.Row(9).CellsUsed(c => c.GetString().Trim(trimChars).Length == 1).
								ToDictionary(c => c.Address.ColumnLetter, c => c.GetString().Trim(trimChars));
							Dictionary<string, double> posTechnicalScore = new Dictionary<string, double>();
							Dictionary<string, double> posArtisticScore = new Dictionary<string, double>();
							markCols.ForEach(e => { posTechnicalScore.Add(e.Value, 0); posArtisticScore.Add(e.Value, 0); });
							var mistakesTechRow = sheet.RowsUsed(r => r.Cell("C").GetString().Trim(trimChars).ToLower().Contains("(number of mistakes)")).First();
							int upperBound = mistakesTechRow.RowNumber();
							var mistakesTimeRow = sheet.RowsUsed(r => r.Cell("C").GetString().Trim(trimChars).ToLower().Contains("time penalty")).First();
							int lowerBound = mistakesTimeRow.RowNumber();
							int currentMark = 1;
							using (var techRows = sheet.RowsUsed(r => r.RowNumber() > 9 && r.RowNumber() < upperBound)) {
								ExtractTechnicalMarks(techRows, participation, markCols, posTechnicalScore, ref currentMark);
							}
							using (var artRows = sheet.RowsUsed(r => r.RowNumber() > upperBound && r.RowNumber() < lowerBound)) {
								ExtractArtisticMarks(artRows, participation, markCols, posArtisticScore, ref currentMark);
							}

							ExamineMistakes(mistakesTechRow, mistakesTimeRow, participation, markCols, logger);

							ExtractFreestyleResults(markCols, participation, posArtisticScore, posTechnicalScore);
						}
					}
				});
			});
		}

		private static void ExtractFreestyleResults(
				Dictionary<string, string> markCols,
				FreestyleParticipation participation,
				Dictionary<string, double> posArtisticScore,
				Dictionary<string, double> posTechnicalScore) {
			double total = 0;
			markCols.ForEach(e => {
				participation.FreestyleResults.Add(new FreestyleResult(
					new TechnicalResult("0.00"),
					new ArtisticResult("false"),
					string.Format(nfi, "{0:0.000}", posArtisticScore[e.Value] / 2),
					e.Value,
					string.Format(nfi, "{0:0.000}", posTechnicalScore[e.Value] / 2)));
				total += (posArtisticScore[e.Value] + posTechnicalScore[e.Value]) / 2;
			});
			participation.Total = new Total(string.Format(nfi, "{0:0.000}", total / 5 / 2));
		}

		private static void ExtractArtisticMarks(
				IXLRows artRows,
				FreestyleParticipation participation,
				Dictionary<string, string> markCols,
				Dictionary<string, double> posArtisticScore,
				ref int currentMark) {
			int number = currentMark;
			artRows.ForEach(r => {
				var am = new ArtisticMark(number.ToString());
				markCols.ForEach(entry => {
					double score = TryGetScore(r, entry, participation, logger);
					am.Marks.Add(new Mark(entry.Value, string.Format(nfi, "{0:0.0}", score)));
					posArtisticScore[entry.Value] += score;
				});
				participation.ArtisticMarks.Add(am);
				++number;
			});
			currentMark = number;
		}

		private static void ExtractTechnicalMarks(IXLRows techRows,
				FreestyleParticipation participation,
				Dictionary<string, string> markCols,
				Dictionary<string, double> posTechnicalScore,
				ref int currentMark) {
			int number = currentMark;
			techRows.ForEach(r => {
				var tm = new TechnicalMark(number.ToString());
				markCols.ForEach(entry => {
					double score = TryGetScore(r, entry, participation, logger);
					tm.Marks.Add(new Mark(entry.Value, string.Format(nfi, "{0:0.0}", score)));
					posTechnicalScore[entry.Value] += score;
				});
				participation.TechnicalMarks.Add(tm);
				++number;
			});
			currentMark = number;
		}
	}
}
