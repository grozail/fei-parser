using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model.Mark.Container {
	abstract class MarkContainer : XMLConvertable {

		private string _number;
		private List<Mark> _marks;
		public string Number {
			get {
				return _number;
			}

			set {
				_number = value;
			}
		}

		internal List<Mark> Marks {
			get {
				return _marks;
			}

			set {
				_marks = value;
			}
		}

		protected MarkContainer(string number, List<Mark> marks) {
			Number = number;
			Marks = marks;
		}

		protected MarkContainer(string number) {
			Number = number;
			Marks = new List<Mark>();
		}

		public void AddMark(Mark mark) {
			Marks.Add(mark);
		}

		public virtual XElement ToXML() {
			return new XElement("Marks", Marks.Select(m => m.ToXML()));
		}
	}
}
