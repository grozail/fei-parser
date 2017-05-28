using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event.Properties {
	class Complement : XMLConvertable {
		private string _IsWNominated;

		public string IsWNominated {
			get {
				return _IsWNominated;
			}

			set {
				_IsWNominated = value;
			}
		}

		public Complement(string isWNominated) {
			IsWNominated = isWNominated;
		}

		public XElement ToXML() {
			return new XElement("Complement", new XAttribute("IsWNominated", IsWNominated));
		}
	}
}
