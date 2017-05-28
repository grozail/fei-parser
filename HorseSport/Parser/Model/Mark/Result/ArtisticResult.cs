using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark.Result {
	class ArtisticResult : XMLConvertable {
		private string _timePenalty;

		public ArtisticResult(string timePenalty) {
			TimePenalty = timePenalty;
		}

		public string TimePenalty {
			get {
				return _timePenalty;
			}

			set {
				_timePenalty = value;
			}
		}

		public XElement ToXML() {
			return new XElement("ArtisticResult", new XAttribute("TimePenalty", TimePenalty));
		}
	}
}
