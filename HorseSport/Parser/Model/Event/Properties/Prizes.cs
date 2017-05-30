using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Event.Properties {
	class Prizes : XMLConvertable {

		private string _currency;

		public string Currency {
			get {
				return _currency;
			}

			set {
				_currency = value;
			}
		}

		public Prizes(string currency) {
			Currency = currency;
		}

		public XElement ToXML() {
			return new XElement("Prizes", new XAttribute("Currency", Currency));
		}
	}
}
