using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark {
	class Mark : XMLConvertable {
		private string _position;
		private string _total;

		public Mark(string position, string total) {
			Position = position;
			Total = total;
		}

		public string Position {
			get {
				return _position;
			}

			set {
				_position = value;
			}
		}

		public string Total {
			get {
				return _total;
			}

			set {
				_total = value;
			}
		}

		public XElement ToXML() {
			return new XElement("Mark", new XAttribute("Position", Position), new XAttribute("Total", Total));
		}
	}
}
