using System;
using System.IO;

namespace TVShowRenamer
{
	/// <summary>
	/// Zusammenfassung für Episode.
	/// </summary>
	public class Episode
	{
		private String _filename = "";
		private String _series = "";
		private String _title = "";
		private int _season = 0;
		private int _episode = 0;
		private int[] _episodes = {0};

		private char[] badPathChars = {'/', '\\', ':', '*', '?', '"', '<', '>', '|'};

		public Episode(String fname)
		{
			_filename = fname;
		}

		public String series
		{
			get 
			{
				return _series;
			}
			set 
			{
				_series = value;
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

		public bool needRenaming()
		{
			FileInfo fi = new FileInfo(filename);
			if (modifiedName() == fi.Name.Replace(fi.Extension, ""))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public String modifiedName()
		{
			String str = "";
			str += _series;
			if ( (_season*_episode) > 0)
			{
				str += " - " + _season + "x";
				String[] eps = new String[_episodes.Length];
				for (int i=0; i<eps.Length; i++)
				{
					eps[i] = _episodes[i].ToString();
					if (_episodes[i] < 10)
					{
						eps[i] = "0"+eps[i];
					}
				}
				str += String.Join("-", eps);
			}
			if (_title != null)
			{
				str += " - " + _title;
			}
			foreach (char c in badPathChars)
				str = str.Replace(c, '.');
			return str;
		}

		public new String ToString()
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
