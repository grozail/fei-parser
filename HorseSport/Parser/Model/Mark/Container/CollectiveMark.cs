using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark.Container {
	class CollectiveMark : MarkContainer {

		public CollectiveMark(string number) : base(number) { }

		public CollectiveMark(string number, List<Mark> marks) : base(number, marks) { }

		public override XElement ToXML() {
			return new XElement("CollectiveMark", new XAttribute("Number", Number), base.ToXML());
		}
	}
}
