using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Data {
	static class CompetitionManager {
		private static XElement _juryNode;

		public static XElement JuryNode {
			get {
				return _juryNode;
			}

			set {
				_juryNode = value;
			}
		}
	}
}
