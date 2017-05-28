using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event.Properties {
	class PrizeMoney : XMLConvertable {
		private string _value;

		public string Value {
			get {
				return _value;
			}

			set {
				_value = value;
			}
		}

		public PrizeMoney(string value) {
			Value = value;
		}

		public XElement ToXML() {
			return new XElement("PrizeMoney",
						new XAttribute("Value", Value));
		}
	}
}
