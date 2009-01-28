// *******************************************************************************
//  Title:			Episode.cs
//  Description:	Episode Class
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.IO;
using System.Threading;
using MediaRenamer;
using MediaRenamer.Common;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TVShowRenamer
{
	/// <summary>
	/// Episode class
	/// </summary>
	public class Episode
	{
		private String _filename = "";
		private String _series = "";
		private String _title = "";
		private String _altSeries = "";
		private String _language = "";
		public int year = 0;
		private int _season = 0;
		private int _episode = 0;
		private int[] _episodes = {0};

        // This are the regular Expressions to find season and episode number
        public static String[] regEx = {	
									@"([0-9]+)x([0-9]+)-([0-9]+)",
                                    @"s([0-9]+)e([0-9]+)-e([0-9]+)",
									@"s([0-9]+)e([0-9]+)e([0-9]+)",
									@"s([0-9]+)e([0-9]+)",
                                    @"s([0-9]+)ep([0-9]+)",
									@"s([0-9]+) e([0-9]+)",
									@"([0-9]+)x([0-9]+)"
								 };
		private char[] badPathChars = {'/', '\\', ':', '*', '?', '"', '<', '>', '|'};

		public Episode(String fname)
		{
			_filename = fname;
		}

		# region get/set methods

		public String series
		{
			get 
			{
				return _series;
			}
			set 
			{
				foreach (char c in badPathChars)
					value = value.Replace(c, '.');
				_series = value;
			}
		}

		public String altSeries
		{
			get 
			{
				return _altSeries;
			}
			set 
			{
				foreach (char c in badPathChars)
					value = value.Replace(c, '.');
				_altSeries = value;
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

		public String title
		{
			get 
			{
				return _title;
			}
			set 
			{
				foreach (char c in badPathChars)
					value = value.Replace(c, '.');
				value = value.Trim();
				_title = value;
			}
		}

		public int season
		{
			get 
			{
				return _season;
			}
			set 
			{
				_season = value;
			}
		}

		public int episode
		{
			get 
			{
				return _episode;
			}
			set 
			{
				_episode = value;
				if (_episodes[0] == 0)
					_episodes[0] = value;
			}
		}

		public int[] episodes
		{
			get 
			{
				return _episodes;
			}
			set 
			{
				_episodes = value;
			}
		}

		public bool special
		{
			get
			{
				bool isSpecial = false;
				if (_filename.ToLower().IndexOf(@"\special") > 0) isSpecial = true;
				if (_filename.ToLower().IndexOf(@"\extra") > 0) isSpecial = true;
				if (_filename.ToLower().IndexOf(@"\bonus") > 0) isSpecial = true;
				return isSpecial;
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

        /// <summary>
        /// Parses a filename for episode information
        /// </summary>
        /// <param name="file">complete filename</param>
        /// <returns>filled Episode class</returns>
        public static Episode parseFile(String file)
        {
            Episode ep = new Episode(file);
            FileInfo fi = new FileInfo(file);
            try
            {
                String dir = "";
                dir = fi.Directory.FullName;
                while (true)
                {
                    if (dir == null) break;
                    DirectoryInfo di = new DirectoryInfo(dir);
                    // Skip those folders since they probably contain no episodes but extras/bonus material
                    if ((di.Name.ToLower().IndexOf("season") != 0) &&
                        (di.Name.ToLower().IndexOf("series") != 0) &&
                        (di.Name.ToLower().IndexOf("extra") != 0) &&
                        (di.Name.ToLower().IndexOf("special") != 0) &&
                        (di.Name.ToLower().IndexOf("bonus") != 0) &&
                        (di.Name.ToLower().IndexOf("dvd") != 0)
                        )
                    {
                        ep.series = di.Name;
                        Regex reg = new Regex("([0-9]{4})");
                        Match m = null;
                        m = reg.Match(ep.series);
                        if (m.Success)
                        {
                            int year = Int32.Parse(m.Groups[1].Captures[0].Value);
                            if (year <= DateTime.Now.Year)
                            {
                                ep.year = year;
                                ep.series = ep.series.Replace(m.Groups[1].Captures[0].Value, "");
                            }
                        }
                        ep.series = ep.series.Replace("()", "");
                        break;
                    }
                    else
                    {
                        dir = di.Parent.FullName;
                    }
                }

                String title = "";
                String series = "";
                String name = fi.Name;
                bool matched = false;
                // Scan for season and episode
                String[] regExp = Episode.regEx;
                foreach (String pat in regExp)
                {
                    Regex reg = new Regex(pat);
                    Match m = null;
                    m = reg.Match(name.ToLower());
                    if (m.Success)
                    {
                        ep.season = Int32.Parse(m.Groups[1].Captures[0].Value);
                        ep.episode = Int32.Parse(m.Groups[2].Captures[0].Value);
                        int[] eps = new int[m.Groups.Count - 2];
                        for (int i = 0; i < eps.Length; i++)
                        {
                            eps[i] = Int32.Parse(m.Groups[i + 2].Captures[0].Value);
                        }
                        ep.episodes = eps;

                        series = name.Substring(0, name.ToLower().IndexOf(m.Value) - 1);
                        //series = series.Replace(".", " ");
                        series = Eregi.replace("([a-zA-Z]{1})([0-9]{1})", "\\1 \\2", series);
                        series = Eregi.replace("([0-9]{1})([a-zA-Z]{1})", "\\1 \\2", series);
                        series = Eregi.replace("([a-zA-Z]{2})\\.([a-zA-Z]{1})", "\\1 \\2", series);
                        series = Eregi.replace("([a-zA-Z]{1})\\.([a-zA-Z]{2})", "\\1 \\2", series);
                        series = series.Replace("_", " ");
                        series = series.Replace("  ", " ");
                        series = series.Replace(" - ", " ");
                        series = series.Replace(" -", " ");
                        series = series.Replace("[", "");
                        series = series.Replace("]", "");
                        series = series.Replace("(", "");
                        series = series.Replace(")", "");
                        series = series.Trim();
                        ep.altSeries = ep.series;
                        ep.series = series;
                        if (ep.series == "") ep.series = ep.altSeries;

                        title = name.Substring(name.ToLower().IndexOf(m.Value) + m.Value.Length);
                        title = title.Replace(" - ", "");
                        title = title.Trim();
                        title = title.Substring(0, title.LastIndexOf("."));
                        ep.title = title;

                        // find title using online parser
                        OnlineParser oParse = new OnlineParser();
                        oParse.getEpisodeData(ref ep);

                        matched = true;

                        break;
                    }
                }
                // no matching data found. try to find title of episode anyway
                if (!matched)
                {
                    ep.season = 0;
                    ep.episode = 0;
                    if (file.IndexOf("-") > 0)
                    {
                        title = file.Substring(file.IndexOf("-") + 1);
                        title = title.Trim();
                        title = title.Substring(0, title.LastIndexOf("."));
                        ep.title = title;
                    }
                }
            }
            catch (Exception E)
            {
                Log.Add("ParseFile(" + ep.filename + "): " + E.Message);
            }

            return ep;
        }

        /// <summary>
        /// Verify movie name is a TV episode
        /// If it has a season and episode numbers its possibly an episode.
        /// </summary>
        /// <param name="file">filename</param>
        /// <returns>true if valid, false if invalid</returns>
        public static bool validEpisodeFile(String file)
        {
            String[] regEx2 = Episode.regEx;
            FileInfo fi = new FileInfo(file);
            foreach (String pat in regEx2)
            {
                Regex reg = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = null;
                m = reg.Match(fi.Name);
                if (m.Success)
                {
                    return true;
                }
            }
            return false;
        }

		/// <summary>
		/// Checks if the episode needs renaming or already matches the filename
		/// </summary>
		/// <returns>true if needs renaming, false if not</returns>
		public bool needRenaming()
		{
			FileInfo fi = new FileInfo(filename);
			if (modifiedName() == fi.Name)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// retreive new name of the episode
		/// </summary>
		/// <returns></returns>
		public String modifiedName()
		{
			String renameFormat = "<series> - <season>x<episode2> - <title>";
            String savedFormat = Settings.GetValueAsString(SettingKeys.SeriesFormat);
            if (savedFormat != null)
                renameFormat = savedFormat;

			String[] eps1 = new String[_episodes.Length];
			for (int i=0; i<eps1.Length; i++)
			{
				eps1[i] = _episodes[i].ToString();
				if (_episodes[i] < 10)
				{
					eps1[i] = eps1[i];
				}
			}
			String episodes1 = String.Join("-", eps1);

			String[] eps2 = new String[_episodes.Length];
			for (int i=0; i<eps2.Length; i++)
			{
				eps2[i] = _episodes[i].ToString();
				if (_episodes[i] < 10)
				{
					eps2[i] = "0"+eps2[i];
				}
			}
			String episodes2 = String.Join("-", eps2);

			String season2 = _season.ToString();
			if (_season < 10) season2 = "0"+season2;

			renameFormat = renameFormat.Replace("<series>", _series);
			renameFormat = renameFormat.Replace("<season>", _season.ToString());
			renameFormat = renameFormat.Replace("<season2>", season2);
			renameFormat = renameFormat.Replace("<episode>", episodes1);
			renameFormat = renameFormat.Replace("<episode2>", episodes2);
			if (_title.Length > 0)
			{
				renameFormat = renameFormat.Replace("<title>", _title);
				renameFormat = Eregi.replace("<title:([^>]*)>", "\\1", renameFormat);
			}
			else
			{
				renameFormat = renameFormat.Replace("<title>", "");
                renameFormat = Eregi.replace("<title:([^>]*)>", "", renameFormat);
			}
            FileInfo fi = new FileInfo(filename);
            renameFormat += fi.Extension;
			return renameFormat;
		}

        public void renameEpisode()
        {
            if (needRenaming())
            {
                FileInfo fi = new FileInfo(filename);
                String modifiedFilename = fi.DirectoryName + @"\" + modifiedName();
                if (!File.Exists(modifiedFilename) ||
                    modifiedFilename.ToLower() == filename.ToLower())
                {
                    fi.MoveTo(modifiedFilename);
                }
                else
                {
                    MessageBox.Show("A file with the same name already exists. \nYou cannot rename the file " + fi.Name, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

		public override String ToString()
		{
			String str = "";
			if (special)
			{
				str += "SPECIAL: ";
			}
			str += modifiedName();
			str += " ("+_filename+")";
			return str;
		}
	}
}
