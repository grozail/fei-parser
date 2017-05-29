using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Living {
	class Judge : XMLConvertable {
		private string _FEIID;
		private string _familyName;
		private string _firstName;
		private string _NF;
		private string _officialStatus;
		private string _position;

		public Judge(string feiid, string nf, string firstName, string familyName, string officialStatus, string position) {
			FEIID = feiid;
			NF = nf;
			FirstName = firstName;
			FamilyName = familyName;
			OfficialStatus = officialStatus;
			Position = position;
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

		public string NF {
			get {
				return _NF;
			}

			set {
				_NF = value;
			}
		}

		public string OfficialStatus {
			get {
				return _officialStatus;
			}

			set {
				_officialStatus = value;
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

		public override int GetHashCode() {
			return FEIID.GetHashCode();
		}

		public XElement ToXML() {
			throw new NotImplementedException();
		}

		public object[] AsDataView() {
			return new object[]{ FEIID, FamilyName, FirstName, NF, OfficialStatus, Position, false};
		}
	}
}
