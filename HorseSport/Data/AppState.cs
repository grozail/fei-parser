using HorseSport.Parser.Model.Event;
using HorseSport.Parser.Model.Event.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HorseSport.Data {
	static class AppState {
		private static List<Competition> pool;

		internal static List<Competition> Data {
			get {
				return pool;
			}

			set {
				pool = value;
			}
		}

		public static void Init() {
			Data = new List<Competition>();
		}

		public static void AddToPool(Competition competition) {
			Data.Add(competition);
		}
	}
}
