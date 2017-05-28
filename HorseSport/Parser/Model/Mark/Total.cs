using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark {
	class Total : XMLConvertable {
		private string _score;

		public string Score {
			get {
				return _score;
			}

			set {
				_score = value;
			}
		}

		public Total(string score) {
			Score = score;
		}

		public XElement ToXML() {
			return new XElement("Total", new XAttribute("Score", Score));
		}
	}
}
