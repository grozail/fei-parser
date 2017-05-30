using HorseSport.Parser.Model.Event.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event {
	class Competition : XMLConvertable {
		private string _sourceFileName;
		private List<Participation> _participations;
		private string _FEIID;
		private string _name;
		private string _rule;
		private string _scheduleCompetitionNr;
		private string _team;
		private Description _description;
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

		public string Rule {
			get {
				return _rule;
			}

			set {
				_rule = value;
			}
		}

		public string ScheduleCompetitionNr {
			get {
				return _scheduleCompetitionNr;
			}

			set {
				_scheduleCompetitionNr = value;
			}
		}

		public string Team {
			get {
				return _team;
			}

			set {
				_team = value;
			}
		}

		internal Description Description {
			get {
				return _description;
			}

			set {
				_description = value;
			}
		}

		public Competition(string fileName) {
			SourceFileName = fileName;
			Participations = new List<Participation>();
			FEIID = "TEST";
			Name = "TEST";
			Rule = "TEST";
			ScheduleCompetitionNr = "TEST";
			Team = "false";
		}

		public XElement ToXML() {
			return new XElement("Competition",
					new XAttribute("FEIID", FEIID),
					new XAttribute("Name", Name),
					new XAttribute("Rule", Rule),
					new XAttribute("ScheduleCompetitionNr", ScheduleCompetitionNr),
					new XAttribute("Team", Team),
						Description.ToXML(),
						new XElement("ParticipationList", Participations.Select(p => p.ToXML())));
		}
	}
}
