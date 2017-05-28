using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event.Properties {
	class Position : XMLConvertable {
		private string _Rank;
		private string _Status;

		public string Rank {
			get {
				return _Rank;
			}

			set {
				_Rank = value;
			}
		}

		public string Status {
			get {
				return _Status;
			}

			set {
				_Status = value;
			}
		}

		public Position(string rank, string status) {
			Rank = rank;
			Status = status;
		}

		public XElement ToXML() {
			return new XElement("Position", new XAttribute("Rank", Rank), new XAttribute("Status", Status));
		}
	}
}
