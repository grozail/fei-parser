using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark.Container {
	class Exercise : MarkContainer {

		public Exercise(string number) : base(number) { }

		public Exercise(string number, List<Mark> marks) : base(number, marks) { }

		public override XElement ToXML() {
			return new XElement("Exercise", new XAttribute("Number", Number), base.ToXML());
		}
	}
}
