using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Living {
	class Athlete : XMLConvertable {
		private string _competingFor;
		private string _FEIID;
		private string _familyName;
		private string _firstName;

		public Athlete(string feiid, string competingFor, string firstName, string familyName) {
			FEIID = feiid;
			CompetingFor = competingFor;
			FirstName = firstName;
			FamilyName = familyName;
		}

		public string CompetingFor {
			get {
				return _competingFor;
			}

			set {
				_competingFor = value;
			}
		}

		public string FEIID {
			get {
				return _FEIID;
			}

			set {
				_FEIID = value;
			}
		}

		public string FamilyName {
			get {
				return _familyName;
			}

			set {
				_familyName = value;
			}
		}

		public string FirstName {
			get {
				return _firstName;
			}

			set {
				_firstName = value;
			}
		}

		public override int GetHashCode() {
			return FEIID.GetHashCode();
		}

		public XElement ToXML() {
			return new XElement("Athlete",
						new XAttribute("CompetingFor", CompetingFor),
						new XAttribute("FEIID", FEIID),
						new XAttribute("FamilyName", FamilyName),
						new XAttribute("FirstName", FirstName));
		}

		public override bool Equals(object obj) {
			if (obj is Athlete) {
				return FEIID.Equals((obj as Athlete).FEIID);
			}
			return false;
		}
	}
}
