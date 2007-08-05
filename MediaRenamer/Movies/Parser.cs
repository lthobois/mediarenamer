// *******************************************************************************
//  Title:			Parser.cs
//  Description:	Parses the folder for valid movie files and checks them
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MediaRenamer;
using MediaRenamer.Common;

namespace MovieRenamer
{
	/// <summary>
	/// Zusammenfassung für MovieParser.
	/// </summary>
	public class Parser
	{
		private String moviesPath = "";

		private String[] words = { "XVID", "widescreen", "AC3", "SVCD", "VCD",
									 "DVDRIP", "DVDSCR", "DVD",
									 "HDTV", "PDTV", "VTV", "EFNET",
									 "EDTV", "DIVX", "PROPER", "tvrip",
									 "Director`s", "Directors", "Director", 
									 "Cut", "5.1" };

		public Parser(String path)
		{
			if (!path.EndsWith(@"\")) path += @"\";
			moviesPath = path;
		}

        public event ScanProgressHandler ScanProgress;
        protected virtual void OnScanProgress(int pos, int max)
        {
            ScanProgressHandler handler = ScanProgress;
            if (handler != null)
            {
                handler(pos, max);
            }
        }

        public event ListMovieHandler ListMovie;
        protected virtual void OnListMovie(Movie m)
        {
            ListMovieHandler handler = ListMovie;
            if (handler != null)
            {
                handler(m);
            }
        }

		private bool isVideo(String name)
		{
			name = name.ToLower();
			if (name.EndsWith(".avi")) return true;
			if (name.EndsWith(".divx")) return true;
			if (name.EndsWith(".mov")) return true;
			if (name.EndsWith(".mkv")) return true;
			if (name.EndsWith(".mpg")) return true;
			if (name.EndsWith(".ogm")) return true;
			return false;
		}

		private void scanFolder(String folder)
		{
			String[] elements;
			elements = Directory.GetFileSystemEntries(folder);
			for (int i=0; i<elements.Length; i++)
			{
				//if (isVideo(elements[i]))
				{
					FileAttributes fAttr = File.GetAttributes(elements[i]);
					if ( (fAttr | FileAttributes.ReadOnly) 
						== fAttr)
					{
						//MessageBox.Show("File is write protected: \n"+elements[i]);
					}
					else
					{
						Movie movie = parseFile(elements[i]);
                        if (movie.needRenaming())
                        {
                            OnListMovie(movie);
                        }
					}
				}
                OnScanProgress(i, elements.Length-1);
			}
            OnScanProgress(0, 0);
		}

		public static String eregi_replace(String pat, String newStr, String input)
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
					for (int i=0; i<m.Groups.Count; i++)
					{
						newStrFmt = newStrFmt.Replace("\\"+i, m.Groups[i].Captures[0].Value);
					}
					input = input.Replace(m.Groups[0].Captures[0].Value, newStrFmt);
				}
			}
			return input;
		}

		public Movie parseFile(String file)
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
				if (Directory.Exists(file))
				{
					name = eregi_replace("-([a-zA-Z0-9!]*)", "", name);
				}
				else if (File.Exists(file))
				{
					FileInfo fi = new FileInfo(name);
					name = eregi_replace("-([a-zA-Z0-9!]*)"+fi.Extension, "", name);
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
					movie.year = Int32.Parse( m.Groups[1].Captures[0].Value );
				}

				reg = new Regex("([0-9]{1})\\.([0-9]{1})");
				m = null;
				m = reg.Match(name);
				if (m.Success)
				{
					name = name.Replace( m.Groups[0].Captures[0].Value, 
										 m.Groups[1].Captures[0].Value+"|"+m.Groups[2].Captures[0].Value);
				}
				
				//name = name.Replace(".", " ");
				name = eregi_replace("([^.]{1})([.]{1})([^.]{2})", "\\1 \\3", name);
                name = eregi_replace("([^.]{2})([.]{1})([^.]{1})", "\\1 \\3", name);
				name = name.Replace("|", ".");
				//name = name.Replace(",", " ");
				name = name.Replace("_", " ");
				name = name.Replace("- ", " ");			
				
				String[] getDisk = {"cd([0-9]+)", "cd ([0-9]+)", "part ([0-9]+)", "part([0-9]+)", "disk([0-9]+)"};
				foreach (String pat in getDisk)
				{
					reg = new Regex(pat, RegexOptions.IgnoreCase);
					m = null;
					m = reg.Match(name);
					if (m.Success)
					{
						movie.disk = Int32.Parse( m.Groups[1].Captures[0].Value );
						name = name.Replace(m.Groups[0].Captures[0].Value, "");
						break;
					}
				}
				
				foreach (String word in words)
				{
					name = eregi_replace(word, "", name);
				}
				
				String getLan = name.ToLower();
				if (
					getLan.IndexOf("german") > 0 ||
					getLan.IndexOf("deutsch") > 0
					)
				{
					movie.language = "german";
				}

				int start=-1;
				int end=-1;
				while (name.IndexOf("[") > 0)
				{
					start = name.IndexOf("[");
					end = name.IndexOf("]", start);
					if (start > 0 && end > start)
					{
						name = name.Remove(start, end-start);
					}
				}
				name = eregi_replace(@"\(([^)]*)\)", " ", name);
				name = eregi_replace("(cd)([0-9]+)", " ", name);
				name = eregi_replace("(part)([0-9]+)", " ", name);
				//name = eregi_replace("([0-9]{4})", " ", name);
				name = eregi_replace("([0-9]{1,})of([0-9]{1,})", " ", name);
				name = eregi_replace("www.([a-zA-Z0-9]+).([a-zA-Z]{2,3})", " ", name);
				name = name.Replace("[", " ");
				name = name.Replace("]", " ");
				
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

				/*
				if (movie.year > 0)
				{
					if (name.LastIndexOf(movie.year.ToString()) > 0)
					{
						name = name.Substring(0, name.LastIndexOf(movie.year.ToString())-1 );
					}
				}
				*/
      
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
				Log.Add("ParseFile: "+E.Message);
			}

			return movie;
		}

		public void startScan()
		{
			if (moviesPath == "")
				return;
			scanFolder(moviesPath);
		}
	}
}
