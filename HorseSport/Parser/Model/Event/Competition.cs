using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event {
	class Competition : XMLConvertable {

		private List<Participation> _participations;

		internal List<Participation> Participations {
			get {
				return _participations;
			}

			set {
				_participations = value;
			}
		}

		public Competition() {
			Participations = new List<Participation>();
		}

		public XElement ToXML() {
			return new XElement("Competition", new XElement("ParticipationList", Participations.Select(p => p.ToXML())));
		}
	}
}
