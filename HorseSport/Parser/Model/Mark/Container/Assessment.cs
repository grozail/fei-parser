using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark.Container {
	class Assessment : MarkContainer {
		public Assessment(string number, List<Mark> marks) : base(number, marks) { }
		public override XElement ToXML() {
			return new XElement("Assessment", new XAttribute("Number", Number), base.ToXML());
		}
	}
}
