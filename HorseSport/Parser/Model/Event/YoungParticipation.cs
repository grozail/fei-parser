using HorseSport.Parser.Model.Mark.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event {
	class YoungParticipation : Participation {
		protected List< Assessment > _assessments;

		internal List<Assessment> Assessments {
			get {
				return _assessments;
			}

			set {
				_assessments = value;
			}
		}

		public override XElement ToXML() {
			var elem = base.ToXML();
			if (Assessments.Count > 0) {
				var container = new XElement("Program",
									new XElement("TestDetails",
										new XElement("Assessments", Assessments.Select(a => a.ToXML()))));
				elem.Add(container, Total.ToXML());
			}
			return elem;
		}
	}
}
