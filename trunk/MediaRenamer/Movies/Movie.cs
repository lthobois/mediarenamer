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

namespace MediaRenamer.Movies
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
        public static String[] words = { "XVID", "widescreen", "AC3", "SVCD", "VCD",
									 "DVDRIP", "DVDSCR", "DVD",
									 "HDTV", "PDTV", "VTV", "EFNET",
									 "EDTV", "DIVX", "PROPER", "tvrip" };

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
                String modifiedFilename = fi.DirectoryName + @"\" + modifiedName();
                if (!File.Exists(modifiedFilename))
                {
                    fi.MoveTo(modifiedFilename);
                    _filename = modifiedFilename;
                }
                else
                {
                    MessageBox.Show("A file with the same name already exists. \nYou cannot rename the file " + fi.Name, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void renameMovieAndMove(String targetFolder)
        {
            if (needRenaming())
            {
                FileInfo fi = new FileInfo(filename);
                String modifiedFilename = targetFolder + @"\" + modifiedName();
                if (!File.Exists(modifiedFilename))
                {
                    fi.MoveTo(modifiedFilename);
                    _filename = modifiedFilename;
                }
                else
                {
                    MessageBox.Show("A file with the same name already exists. \nYou cannot rename the file " + fi.Name, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

		public String modifiedName()
		{
            String renameFormat = "<moviename> (<year><disk:,CD><disk><lang:,><lang>)";
            String savedFormat = Settings.GetValueAsString(SettingKeys.MovieFormat);
            if (savedFormat != "" && savedFormat != String.Empty && savedFormat != null)
                renameFormat = savedFormat;


			renameFormat = renameFormat.Replace("<moviename>", _title);
			if (_year > 0)
			{
				renameFormat = renameFormat.Replace("<year>", _year.ToString());
				renameFormat = Movie.eregi_replace("<year:([^>]*)>", "\\1", renameFormat);
			}
			else
			{
				renameFormat = renameFormat.Replace("<year>", "");
                renameFormat = Movie.eregi_replace("<year:([^>]*)>", "", renameFormat);
			}
			if (_disk > 0)
			{
				renameFormat = renameFormat.Replace("<disk>", _disk.ToString());
				renameFormat = renameFormat.Replace("<disk2>", _disk.ToString("00"));
                renameFormat = Movie.eregi_replace("<disk:([^>]*)>", "\\1", renameFormat);
			}
			else
			{
				renameFormat = renameFormat.Replace("<disk>", "");
				renameFormat = renameFormat.Replace("<disk2>", "");
                renameFormat = Movie.eregi_replace("<disk:([^>]*)>", "", renameFormat);
			}
			if (_language.Length > 0)
			{
				renameFormat = renameFormat.Replace("<lang>", _language);
                renameFormat = Movie.eregi_replace("<lang:([^>]*)>", "\\1", renameFormat);
			}
			else
			{
				renameFormat = renameFormat.Replace("<lang>", "");
                renameFormat = Movie.eregi_replace("<lang:([^>]*)>", "", renameFormat);
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
			/*int idx = _filename.IndexOf(@"\", baseDir.Length);
			if (idx > 0)
			{
				str += _filename.Substring(idx);
			}
			else
			{
				FileInfo fi = new FileInfo(_filename);
				str += fi.Extension;
			}*/
			return str;
		}

        public static Movie parseFile(String file, String moviesPath)
        {
            Movie movie = new Movie(file);
            movie.baseDir = moviesPath;
            Regex reg = null;
            Match m = null;
            MatchCollection mcol = null;

            try
            {
                String name = file;
                name = name.Remove(0, moviesPath.Length);
                if (name.IndexOf(@"\") > 0)
                {
                    name = name.Substring(0, name.IndexOf(@"\"));
                }

                String[] getDisk = { "cd([0-9]+)", "cd ([0-9]+)", "part ([0-9]+)", "part([0-9]+)", "disk([0-9]+)" };
                foreach (String pat in getDisk)
                {
                    reg = new Regex(pat, RegexOptions.IgnoreCase);
                    m = null;
                    m = reg.Match(name);
                    if (m.Success)
                    {
                        movie.disk = Int32.Parse(m.Groups[1].Captures[0].Value);
                        name = name.Replace(m.Groups[0].Captures[0].Value, "");
                        break;
                    }
                }

                if (Directory.Exists(file))
                {
                    name = eregi_replace("-([a-zA-Z0-9!]*)", "", name);
                }
                else if (File.Exists(file))
                {
                    FileInfo fi = new FileInfo(name);
                    name = eregi_replace("-([a-zA-Z0-9!]*)" + fi.Extension, "", name);
                    if (fi.Extension.Length > 0)
                    {
                        name = name.Replace(fi.Extension, "");
                    }
                }

                reg = new Regex("([0-9]{4})");
                mcol = null;
                mcol = reg.Matches(name);
                if (mcol.Count > 0)
                {
                    m = mcol[mcol.Count - 1];
                    movie.year = Int32.Parse(m.Groups[1].Captures[0].Value);
                }

                if (name.IndexOf("[") > 0) name = name.Substring(0, name.IndexOf("["));
                if (name.IndexOf("[") > 0) name = name.Substring(0, name.IndexOf("["));
                if (name.IndexOf("(") > 0) name = name.Substring(0, name.IndexOf("("));
                if (name.IndexOf(")") > 0) name = name.Substring(0, name.IndexOf(")"));

                name = name.Replace("[", " ");
                name = name.Replace("]", " ");
                name = name.Replace("(", " ");
                name = name.Replace(")", " ");

                reg = new Regex("([0-9]{1})\\.([0-9]{1})");
                m = null;
                m = reg.Match(name);
                if (m.Success)
                {
                    name = name.Replace(m.Groups[0].Captures[0].Value,
                                         m.Groups[1].Captures[0].Value + "|" + m.Groups[2].Captures[0].Value);
                }

                //name = name.Replace(".", " ");
                name = eregi_replace("([^.]{1})([.]{1})([^.]{2})", "\\1 \\3", name);
                name = eregi_replace("([^.]{2})([.]{1})([^.]{1})", "\\1 \\3", name);
                name = name.Replace("|", ".");
                //name = name.Replace(",", " ");
                name = name.Replace("_", " ");
                name = name.Replace("- ", " ");

                int wordstart = name.Length;
                foreach (String word in words)
                {
                    int wpos = name.ToLower().IndexOf(word.ToLower());
                    if (wpos != -1 && wpos < wordstart)
                    {
                        wordstart = wpos;
                    }
                }
                name = name.Substring(0, wordstart);

                String getLan = name.ToLower();
                if (
                    getLan.IndexOf("german") > 0 ||
                    getLan.IndexOf("deutsch") > 0
                    )
                {
                    movie.language = "german";
                }

                int start = -1;
                int end = -1;
                while (name.IndexOf("[") > 0)
                {
                    start = name.IndexOf("[");
                    end = name.IndexOf("]", start);
                    if (start > 0 && end > start)
                    {
                        name = name.Remove(start, end - start);
                    }
                }
                name = eregi_replace(@"\(([^)]*)\)", " ", name);
                name = eregi_replace("(cd)([0-9]+)", " ", name);
                name = eregi_replace("(part)([0-9]+)", " ", name);
                //name = eregi_replace("([0-9]{4})", " ", name);
                name = eregi_replace("([0-9]{1,})of([0-9]{1,})", " ", name);
                name = eregi_replace("www.([a-zA-Z0-9]+).([a-zA-Z]{2,3})", " ", name);

                /*
                for (int i=name.Length-2; i>0; i--)
                {
                    if (Char.IsLower(name[i]) && Char.IsUpper(name[i+1]))
                    {
                        name = name.Insert(i+1, " ");
                        continue;
                    }
                }
                */

                if (movie.year > 0)
                {
                    if (name.LastIndexOf(movie.year.ToString()) > 0)
                    {
                        name = name.Substring(0, name.LastIndexOf(movie.year.ToString()) - 1);
                    }
                }

                while (name.IndexOf("  ") > 0)
                {
                    name = name.Replace("  ", " ");
                }
                name = name.Trim();
                movie.title = name;

                OnlineParser oparse = new OnlineParser();
                oparse.getMovieData(ref movie);
            }
            catch (Exception E)
            {
                Log.Add("ParseFile: " + E.Message);
            }
            return movie;
        }

        private static String eregi_replace(String pat, String newStr, String input)
        {
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.None);
            MatchCollection mcol = null;
            String newStrFmt = null;
            mcol = reg.Matches(input);
            if (mcol.Count > 0)
            {
                foreach (Match m in mcol)
                {
                    newStrFmt = newStr;
                    for (int i = 0; i < m.Groups.Count; i++)
                    {
                        newStrFmt = newStrFmt.Replace("\\" + i, m.Groups[i].Captures[0].Value);
                    }
                    input = input.Replace(m.Groups[0].Captures[0].Value, newStrFmt);
                }
            }
            return input;
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
