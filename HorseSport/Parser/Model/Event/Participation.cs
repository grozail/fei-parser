using HorseSport.Parser.Model.Mark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HorseSport.Parser.Model.Event.Properties;
using HorseSport.Parser.Model.Living;

namespace HorseSport.Parser.Model.Event {
	abstract class Participation : XMLConvertable {
		protected Athlete _athlete;
		protected Horse _horse;
		protected PrizeMoney _prizeMoney;
		protected Complement _complement;
		protected Position _position;
		protected Total _total;
		internal Athlete Athlete {
			get {
				return _athlete;
			}

			set {
				_athlete = value;
			}
		}

		internal Horse Horse {
			get {
				return _horse;
			}

			set {
				_horse = value;
			}
		}

		internal PrizeMoney PrizeMoney {
			get {
				return _prizeMoney;
			}

			set {
				_prizeMoney = value;
			}
		}

		internal Complement Complement {
			get {
				return _complement;
			}

			set {
				_complement = value;
			}
		}

		internal Position Position {
			get {
				return _position;
			}

			set {
				_position = value;
			}
		}

		internal Total Total {
			get {
				return _total;
			}

			set {
				_total = value;
			}
		}

		public virtual XElement ToXML() {
			var elem = new XElement("Participation", Athlete.ToXML(), Horse.ToXML());
			if (PrizeMoney != null) {
				elem.Add(PrizeMoney.ToXML());
			}
			elem.Add(Complement.ToXML());
			elem.Add(Position.ToXML());
			return elem;
		}
	}
}
