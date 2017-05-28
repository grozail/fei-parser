using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark.Result {
	class FreestyleResult : XMLConvertable {

		private TechnicalResult _technicalResult;
		private ArtisticResult _artisticResult;
		private string _artisticPercent;
		private string _position;
		private string _technicalPercent;

		internal TechnicalResult TechnicalResult {
			get {
				return _technicalResult;
			}

			set {
				_technicalResult = value;
			}
		}

		internal ArtisticResult ArtisticResult {
			get {
				return _artisticResult;
			}

			set {
				_artisticResult = value;
			}
		}

		public string ArtisticPercent {
			get {
				return _artisticPercent;
			}

			set {
				_artisticPercent = value;
			}
		}

		public string Position {
			get {
				return _position;
			}

			set {
				_position = value;
			}
		}

		public string TechnicalPercent {
			get {
				return _technicalPercent;
			}

			set {
				_technicalPercent = value;
			}
		}

		public FreestyleResult(TechnicalResult technicalResult, ArtisticResult artisticResult, string artisticPercent, string position, string technicalPercent) {
			TechnicalResult = technicalResult;
			ArtisticResult = artisticResult;
			ArtisticPercent = artisticPercent;
			Position = position;
			TechnicalPercent = technicalPercent;
		}

		public XElement ToXML() {
			return new XElement("Result",
					new XAttribute("ArtisticPercent", ArtisticPercent),
					new XAttribute("Position", Position),
					new XAttribute("TechnicalPercent", TechnicalPercent),
						TechnicalResult.ToXML(),
						ArtisticResult.ToXML());
		}
	}
}
