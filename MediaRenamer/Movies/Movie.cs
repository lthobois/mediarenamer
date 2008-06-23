// *******************************************************************************
//  Title:			Movie.cs
//  Description:	Movie Class
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MediaRenamer.Common;

namespace MovieRenamer
{
	/// <summary>
	/// Zusammenfassung für Episode.
	/// </summary>
	public class Movie
	{
		public String baseDir = "";
		private String _filename = "";
		private String _title = "";
		private String _language = "";
		private int _disk = 0;
		private int _year = 0;

		private char[] badPathChars = {'/', '\\', ':', '*', '?', '"', '<', '>', '|'};

		public Movie(String fname)
		{
			_filename = fname;
		}

		#region get/set Methods

		public String title
		{
			get 
			{
				return _title;
			}
			set 
			{
				String val = value;
				val = val.Trim();
				Regex reg = new Regex("&#([0-9]+);");
				MatchCollection mcol = null;
				mcol = reg.Matches(val);
				if (mcol.Count > 0)
				{
					foreach (Match m in mcol)
					{
						Char c = (Char)Int32.Parse(m.Groups[1].Captures[0].Value);
						val = val.Replace( 
							m.Groups[0].Captures[0].Value, 
							c.ToString()
							);
					}
				}
				val = val.Replace("\"", "");
				val = val.Replace("&quot;", "");
				val = val.Replace("&amp;", "&");
				val = val.Replace("(V)", "");
				val = val.Replace("  ", " ");
				_title = val;
			}
		}

		public String language
		{
			get 
			{
				return _language;
			}
			set 
			{
				_language = value;
			}
		}

		public int year
		{
			get 
			{
				return _year;
			}
			set 
			{
				_year = value;
			}
		}

		public int disk
		{
			get 
			{
				return _disk;
			}
			set 
			{
				_disk = value;
			}
		}

		public String filename
		{
			get
			{
				return _filename;
			}
		}

		#endregion

		public bool compareTitles(String foundTitle)
		{
			String fTitle = foundTitle;
			String oTitle = _title;

			if (_year > 0)
			{
				oTitle += " ("+_year.ToString()+")";
			}
			foreach (Char c in badPathChars)
			{
				fTitle = fTitle.Replace(c.ToString(), " ");
				oTitle = oTitle.Replace(c.ToString(), " ");
			}
			fTitle = fTitle.Replace('.', ' ');
			oTitle = oTitle.Replace('.', ' ');
			while (fTitle.IndexOf("  ") != -1)
				fTitle = fTitle.Replace("  ", " ");
			while (oTitle.IndexOf("  ") != -1)
				oTitle = oTitle.Replace("  ", " ");
			oTitle.Trim();
			fTitle.Trim();
			return oTitle.Equals(fTitle);
		}

		public bool needRenaming()
		{
			FileInfo fi = new FileInfo(filename);
			String original = fi.Name;
			String modified = modifiedName();
			if (modified.Length-original.Length != 0) return true;
			bool equals = modified.Equals(original);
			return !equals;
		}

        public void renameMovie()
        {
            if (needRenaming())
            {
                FileInfo fi = new FileInfo(filename);
                fi.MoveTo(fi.DirectoryName+@"\"+modifiedName());
            }
        }

		public String modifiedName()
		{
            String renameFormat = "<moviename> (<year><disk:,CD><disk><lang:,><lang>)";
            String savedFormat = Settings.GetValueAsString(SettingKeys.MovieFormat);
            if (savedFormat != null)
                renameFormat = savedFormat;


			renameFormat = renameFormat.Replace("<moviename>", _title);
			if (_year > 0)
			{
				renameFormat = renameFormat.Replace("<year>", _year.ToString());
				renameFormat = Parser.eregi_replace("<year:([^>]*)>", "\\1", renameFormat);
			}
			else
			{
				renameFormat = renameFormat.Replace("<year>", "");
				renameFormat = Parser.eregi_replace("<year:([^>]*)>", "", renameFormat);
			}
			if (_disk > 0)
			{
				renameFormat = renameFormat.Replace("<disk>", _disk.ToString());
				renameFormat = renameFormat.Replace("<disk2>", _disk.ToString("00"));
				renameFormat = Parser.eregi_replace("<disk:([^>]*)>", "\\1", renameFormat);
			}
			else
			{
				renameFormat = renameFormat.Replace("<disk>", "");
				renameFormat = renameFormat.Replace("<disk2>", "");
				renameFormat = Parser.eregi_replace("<disk:([^>]*)>", "", renameFormat);
			}
			if (_language.Length > 0)
			{
				renameFormat = renameFormat.Replace("<lang>", _language);
				renameFormat = Parser.eregi_replace("<lang:([^>]*)>", "\\1", renameFormat);
			}
			else
			{
				renameFormat = renameFormat.Replace("<lang>", "");
				renameFormat = Parser.eregi_replace("<lang:([^>]*)>", "", renameFormat);
			}

			foreach (char c in badPathChars)
				renameFormat = renameFormat.Replace(c, '.');
            FileInfo fi = new FileInfo(filename);
            renameFormat += fi.Extension.ToLower();
			return renameFormat;
		}

		public string modifiedFullName()
		{
			String str = "";
			str += baseDir;
			if (str[str.Length-1] != '\\') str += @"\";
			str += modifiedName();
			int idx = _filename.IndexOf(@"\", baseDir.Length);
			if (idx > 0)
			{
				str += _filename.Substring(idx);
			}
			else
			{
				FileInfo fi = new FileInfo(_filename);
				str += fi.Extension;
			}
			return str;
		}

        public override string ToString()
		{
			string str = "";
			str += modifiedName();
			str += " ("+_filename+")";
			return str;
		}
	}
}
