using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HorseSport.Parser {
	class Globals {
		private static Globals _INSTANCE = new Globals();
		private NumberFormatInfo _numberFormat;
		private Regex _athleteFamilyNameRegex;
		private Regex _athleteFirstNameRegex;

		internal static Globals INSTANCE {
			get {
				if (_INSTANCE == null) {
					_INSTANCE = new Globals();
				}
				return _INSTANCE;
			}
		}

		public NumberFormatInfo NumberFormat {
			get {
				return _numberFormat;
			}

			set {
				_numberFormat = value;
			}
		}

		public Regex AthleteFamilyNameRegex {
			get {
				return _athleteFamilyNameRegex;
			}

			set {
				_athleteFamilyNameRegex = value;
			}
		}

		public Regex AthleteFirstNameRegex {
			get {
				return _athleteFirstNameRegex;
			}

			set {
				_athleteFirstNameRegex = value;
			}
		}

		private Globals() {
			NumberFormat = new NumberFormatInfo();
			NumberFormat.NumberDecimalSeparator = ".";
			AthleteFirstNameRegex = new Regex("[A-Z][a-z-].*");
			AthleteFamilyNameRegex = new Regex("[A-Z][-]?.*[A-Z][ ,]");
		}
	}
}
