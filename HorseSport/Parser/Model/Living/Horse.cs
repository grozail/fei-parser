using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Living {
	class Horse : XMLConvertable {
		private string _FEIID;
		private string _name;

		public Horse(string feiid, string name) {
			FEIID = feiid;
			Name = name;
		}

		public string FEIID {
			get {
				return _FEIID;
			}

			set {
				_FEIID = value;
			}
		}

		public string Name {
			get {
				return _name;
			}

			set {
				_name = value;
			}
		}

		public override int GetHashCode() {
			return FEIID.GetHashCode();
		}

		public XElement ToXML() {
			return new XElement("Horse",
						new XAttribute("FEIID", FEIID),
						new XAttribute("Name", Name));
		}
	}
}
