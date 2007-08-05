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
            if (savedFormat != String.Empty)
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
				renameFormat = Parser.eregi_replace("<title:([^>]*)>", "\\1", renameFormat);
			}
			else
			{
				renameFormat = renameFormat.Replace("<title>", "");
				renameFormat = Parser.eregi_replace("<title:([^>]*)>", "", renameFormat);
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
                try
                {
                    fi.MoveTo(fi.DirectoryName + @"\" + modifiedName());
                }
                catch
                {
                    //Log.Add("Could not rename: " + fi.Name);
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
