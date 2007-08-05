using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TVShowRenamer
{
	/// <summary>
	/// Zusammenfassung für Parser.
	/// </summary>
	public class Parser
	{
		private String seriesPath = "";
		private ListBox output = null;

		private String[] regEx = {	@"([0-9]+)x([0-9]+)-([0-9]+)",
									@"([0-9]+)x([0-9]+)", 
									@"s([0-9]+)e([0-9]+)"
								 };

		public Parser(String path, ListBox o)
		{
			if (!path.EndsWith(@"\")) path += @"\";
			seriesPath = path;
			output = o;
		}

		public Parser()
		{
		}

		private bool isVideo(String name)
		{
			name = name.ToLower();
			if (name.EndsWith(".avi")) return true;
			if (name.EndsWith(".mpg")) return true;
			if (name.EndsWith(".mov")) return true;
			if (name.EndsWith(".mpeg")) return true;
			if (name.EndsWith(".mkv")) return true;
			return false;
		}

		private void scanFolder(String folder)
		{
			String[] elements;
			elements = Directory.GetFiles(folder);
			for (int i=0; i<elements.Length; i++)
			{
				if (isVideo(elements[i]))
				{
					writeEpisode( parseFile(elements[i]) );
				}
			}
			elements = Directory.GetDirectories(folder);
			for (int i=0; i<elements.Length; i++)
			{
				scanFolder(elements[i]);
			}
		}

		public Episode parseFile(String file)
		{
			Episode ep = new Episode(file);

			try
			{
				MessageBox.Show("Initializing "+file+"...");
				if (seriesPath.Length > 0) 
				{
					file = file.Replace(seriesPath, "");
				}
				else
				{
					String series = "Serien";
					file = file.Substring( file.IndexOf(series)+series.Length+1 );
				}
				ep.series = file.Substring(0, file.IndexOf(@"\"));

				MessageBox.Show("Series possibly found");
				String name = file.ToLower();
				String title = "";
				MessageBox.Show("Checking for Episode Name");
				foreach (String pat in regEx)
				{
					Regex reg = new Regex(pat);
					Match m = null;
					m = reg.Match(name);
					if (m.Success)
					{
						MessageBox.Show("Episode format found");
						ep.season = Int32.Parse(m.Groups[1].Captures[0].Value);
						ep.episode = Int32.Parse(m.Groups[2].Captures[0].Value);
						int[] eps = new int[m.Groups.Count-2];
						for (int i=0; i<eps.Length; i++)
						{
							eps[i] = Int32.Parse(m.Groups[i+2].Captures[0].Value);
						}
						ep.episodes = eps;
						MessageBox.Show("Episodes set");
						title = file.Substring( name.IndexOf(m.Value)+m.Value.Length );
						title = title.Replace(" - ", "");
						title = title.Trim();
						title = title.Substring(0, title.LastIndexOf("."));
						ep.title = title;
						break;
					}
				}

				MessageBox.Show("Getting online data");
				OnlineParser oParse = new OnlineParser();
				oParse.getEpisodeData(ref ep);
				MessageBox.Show("ParseFile completed");
			}
			catch (Exception E)
			{
				MessageBox.Show("ParseFile: "+E.Message);
			}

			return ep;
		}

		public static bool validEpisodeFile(String file)
		{
			String[] regEx2 = {	@"([0-9]+)x([0-9]+)-([0-9]+)",
										 @"([0-9]+)x([0-9]+)", 
										 @"s([0-9]+)e([0-9]+)"
									 };

			String series = "Serien";
			file = file.Substring( file.IndexOf(series)+series.Length+1 );

			String name = file.ToLower();
			foreach (String pat in regEx2)
			{
				Regex reg = new Regex(pat);
				Match m = null;
				m = reg.Match(name);
				if (m.Success)
				{
					return true;
				}
			}
			return false;
		}

		private void writeEpisode(Episode ep)
		{
			output.Items.Add(ep);
		}

		public void startScan()
		{
			if (seriesPath == "")
				return;
			scanFolder(seriesPath);
		}

	}
}
