using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark.Container {
	class ArtisticMark : MarkContainer {
		public ArtisticMark(string number) : base(number) { }
		public ArtisticMark(string number, List<Mark> marks) : base(number, marks) { }
		public override XElement ToXML() {
			return new XElement("ArtisticMark", new XAttribute("Number", Number), base.ToXML());
		}
	}
}
