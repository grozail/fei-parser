using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark.Result {
	class TechnicalResult : XMLConvertable {
		private string _penaltiesPoints;

		public TechnicalResult(string penaltiesPoints) {
			PenaltiesPoints = penaltiesPoints;
		}

		public string PenaltiesPoints {
			get {
				return _penaltiesPoints;
			}

			set {
				_penaltiesPoints = value;
			}
		}

		public XElement ToXML() {
			return new XElement("TechnicalResult", new XAttribute("PenaltiesPoints", PenaltiesPoints));
		}
	}
}
