using HorseSport.Parser.Model.Living;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event.Properties {
	class Description : XMLConvertable {
		private Prizes _prizes;
		private List<Judge> _jury;
		internal Prizes Prizes {
			get {
				return _prizes;
			}

			set {
				_prizes = value;
			}
		}

		internal List<Judge> Jury {
			get {
				return _jury;
			}

			set {
				_jury = value;
			}
		}

		public Description() {
			Jury = new List<Judge>();
		}

		public XElement ToXML() {
			var elem = new XElement("Description");
			if (Prizes != null) {
				elem.Add(Prizes.ToXML());
			}
			elem.Add(new XElement("Jury", Jury.Select(j => j.ToXML())));
			return elem;
		}
	}
}
