using HorseSport.Parser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HorseSport.Data {
	static class InfoManager {
		private static List<EventInfo> infoList;

		internal static List<EventInfo> Data {
			get {
				return infoList;
			}

			set {
				infoList = value;
			}
		}

		public static void LoadData(string fileName) {
			Data = new List<EventInfo>();
			using (StreamReader reader = new StreamReader(fileName)) {
				reader.ReadLine();
				string line;
				while ((line = reader.ReadLine()) != null) {
					EventInfo ei = new EventInfo();
					var values = line.Split(',');
					var it = values.GetEnumerator();
					it.MoveNext();
					ei.ShowID = (string)it.Current;
					it.MoveNext();
					ei.ShowStartDate = ((string)it.Current).Split(' ')[0];
					it.MoveNext();
					ei.ShowEndDate = ((string)it.Current).Split(' ')[0];
					it.MoveNext();
					ei.VenueName = (string)it.Current;
					it.MoveNext();
					ei.VenueName += ", " + (string)it.Current;
					it.MoveNext();
					ei.VenueCountry = (string)it.Current;
					it.MoveNext();
					ei.EventID = (string)it.Current;
					it.MoveNext();
					ei.EventCode = (string)it.Current;
					it.MoveNext();
					ei.NF = (string)it.Current;
					it.MoveNext();
					ei.EventStartDate = ((string)it.Current).Split(' ')[0];
					it.MoveNext();
					ei.EventEndDate = ((string)it.Current).Split(' ')[0];
					it.MoveNext();
					ei.CompetitionID = (string)it.Current;
					it.MoveNext();
					ei.ScheduleCompetitionNR = (string)it.Current;
					it.MoveNext();
					ei.Rule = (string)it.Current;
					it.MoveNext();
					ei.CompetitionName = (string)it.Current;
					Data.Add(ei);
				}
			}
		}
	}
}
