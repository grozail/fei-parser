using HorseSport.Parser.Model.Mark.Container;
using HorseSport.Parser.Model.Mark.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event {
	class FreestyleParticipation : Participation {
		protected List<TechnicalMark> _technicalMarks;
		protected List<ArtisticMark> _artisticMarks;
		protected List<FreestyleResult> _freestyleResults;

		internal List<TechnicalMark> TechnicalMarks {
			get {
				return _technicalMarks;
			}

			set {
				_technicalMarks = value;
			}
		}

		internal List<ArtisticMark> ArtisticMarks {
			get {
				return _artisticMarks;
			}

			set {
				_artisticMarks = value;
			}
		}

		internal List<FreestyleResult> FreestyleResults {
			get {
				return _freestyleResults;
			}

			set {
				_freestyleResults = value;
			}
		}

		public FreestyleParticipation() {
			TechnicalMarks = new List<TechnicalMark>();
			ArtisticMarks = new List<ArtisticMark>();
			FreestyleResults = new List<FreestyleResult>();
		}

		public override XElement ToXML() {
			var elem = base.ToXML();
			if (TechnicalMarks.Count > 0) {
				var container = new XElement("FreestyleProgram",
									new XElement("FreestyleTestDetails",
										new XElement("TechnicalMarks", TechnicalMarks.Select(tm => tm.ToXML())),
										new XElement("ArtisticMarks", ArtisticMarks.Select(am => am.ToXML()))),
									new XElement("FreestyleTestResults", FreestyleResults.Select(fr => fr.ToXML())));
				elem.Add(container, Total.ToXML());
			}
			return elem;
		}
	}
}
