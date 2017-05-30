using HorseSport.Parser.Model.Event.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HorseSport.Data {
	static class AppState {
		private static Description _description;
		internal static Description Description {
			get {
				return _description;
			}

			set {
				_description = value;
			}
		}
	}
}
