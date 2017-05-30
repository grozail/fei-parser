using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event {
	class Competition : XMLConvertable {
		private string _sourceFileName;
		private List<Participation> _participations;

		public string SourceFileName {
			get {
				return _sourceFileName;
			}

			set {
				_sourceFileName = value;
			}
		}

		internal List<Participation> Participations {
			get {
				return _participations;
			}

			set {
				_participations = value;
			}
		}

		public Competition(string fileName) {
			SourceFileName = fileName;
			Participations = new List<Participation>();
		}

		public XElement ToXML() {
			return new XElement("Competition", new XElement("ParticipationList", Participations.Select(p => p.ToXML())));
		}
	}
}
