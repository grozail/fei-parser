using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark.Result {
	class UsualResult : XMLConvertable {
		private string _percent;
		private string _position;

		public UsualResult(string percent, string position) {
			Percent = percent;
			Position = position;
		}

		public string Percent {
			get {
				return _percent;
			}

			set {
				_percent = value;
			}
		}

		public string Position {
			get {
				return _position;
			}

			set {
				_position = value;
			}
		}

		public XElement ToXML() {
			return new XElement("Result", new XAttribute("Percent", Percent), new XAttribute("Position", Position));
		}
	}
}
