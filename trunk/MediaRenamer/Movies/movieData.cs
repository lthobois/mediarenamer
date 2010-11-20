using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MediaRenamer.Movies {
    public class movieData {
        private String _name;
        public int Year = 0;

        public String Name {
            get {
                return _name;
            }
            set {
                String val = value;
                val = val.Trim();
                val = System.Web.HttpUtility.HtmlDecode(val);
                val = val.Replace("\"", "");
                val = val.Replace("&quot;", "");
                val = val.Replace("&amp;", "&");
                val = val.Replace("(V)", "");
                val = val.Replace("  ", " ");
                _name = val;
            }
        }

        public override String ToString() {
            return String.Format("{0} ({1})", Name, Year);
        }
    }
}
