using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HorseSport.Parser.Model {
	// ShowID,ShowStartDate,ShowEndDate,VenueName,VenueCountry,EventID,EventCode,NF,EventStartDate,EventEndDate,
	// CompetitionID,ScheduleCompetitionNR,Rule,CompetitionName
	class EventInfo {
		private string _showID;
		private string _showStartDate;
		private string _showEndDate;
		private string _venueName;
		private string _venueCountry;
		private string _eventID;
		private string _eventCode;
		private string _NF;
		private string _eventStartDate;
		private string _eventEndDate;
		private string _competitionID;
		private string _scheduleCompetitionNR;
		private string _rule;
		private string _competitionName;

		public string ShowID {
			get {
				return _showID;
			}

			set {
				_showID = value;
			}
		}

		public string ShowStartDate {
			get {
				return _showStartDate;
			}

			set {
				_showStartDate = value;
			}
		}

		public string ShowEndDate {
			get {
				return _showEndDate;
			}

			set {
				_showEndDate = value;
			}
		}

		public string VenueName {
			get {
				return _venueName;
			}

			set {
				_venueName = value;
			}
		}

		public string VenueCountry {
			get {
				return _venueCountry;
			}

			set {
				_venueCountry = value;
			}
		}

		public string EventID {
			get {
				return _eventID;
			}

			set {
				_eventID = value;
			}
		}

		public string EventCode {
			get {
				return _eventCode;
			}

			set {
				_eventCode = value;
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

		public string EventStartDate {
			get {
				return _eventStartDate;
			}

			set {
				_eventStartDate = value;
			}
		}

		public string EventEndDate {
			get {
				return _eventEndDate;
			}

			set {
				_eventEndDate = value;
			}
		}

		public string CompetitionID {
			get {
				return _competitionID;
			}

			set {
				_competitionID = value;
			}
		}

		public string ScheduleCompetitionNR {
			get {
				return _scheduleCompetitionNR;
			}

			set {
				_scheduleCompetitionNR = value;
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

		public string CompetitionName {
			get {
				return _competitionName;
			}

			set {
				_competitionName = value;
			}
		}
	}
}
