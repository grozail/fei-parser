using HorseSport.Parser.Model.Mark.Container;
using HorseSport.Parser.Model.Mark.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event {
	class UsualParticipation : Participation {
		protected List<Exercise> _exercises;
		protected List<CollectiveMark> _collectiveMarks;
		protected List<UsualResult> _usualResults;

		internal List<Exercise> Exercises {
			get {
				return _exercises;
			}

			set {
				_exercises = value;
			}
		}

		internal List<CollectiveMark> CollectiveMarks {
			get {
				return _collectiveMarks;
			}

			set {
				_collectiveMarks = value;
			}
		}

		internal List<UsualResult> UsualResults {
			get {
				return _usualResults;
			}

			set {
				_usualResults = value;
			}
		}

		public UsualParticipation() {
			Exercises = new List<Exercise>();
			CollectiveMarks = new List<CollectiveMark>();
			UsualResults = new List<UsualResult>();
		}

		public override XElement ToXML() {
			var elem = base.ToXML();
			if (Exercises.Count > 0) {
				var container = new XElement("Program",
									new XElement("TestDetails",
										new XElement("Exercises", Exercises.Select(e => e.ToXML())),
										new XElement("Collective", CollectiveMarks.Select(c => c.ToXML()))),
									new XElement("TestResults", UsualResults.Select(u => u.ToXML())));
				elem.Add(container, Total.ToXML());
			}
			return elem;
		}
	}
}
