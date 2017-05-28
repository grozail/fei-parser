using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HorseSport.Parser.Model {
	interface XMLConvertable {
		XElement ToXML();
	}
}
