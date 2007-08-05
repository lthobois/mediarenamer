using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TVShowRenamer
{
	/// <summary>
	/// Zusammenfassung für OnlineParser.
	/// </summary>
	public class OnlineParser
	{
		private String detailUrl = "http://episodeworld.com/show/{0}/season=all/";
		//private String queryUrl = "http://episodeworld.com/search/{0}";
		private String cache = @"data\{0}.dat";
		public OnlineParser()
		{
			String cacheDir = GetFolderPath(SpecialFolder.ApplicationData)+@"\TVShowRenamer\data\";
			if (!Directory.Exists(cacheDir)) Directory.CreateDirectory(cacheDir);
			cache = cacheDir+"{0}.dat";
			MessageBox.Show(cache);
		}

		private String getSeriesData(String series)
		{
			String seriesCache = String.Format(cache, series);
			String data = null;
			
			if (File.Exists(String.Format(seriesCache, series)))
			{
				DateTime ftime = File.GetCreationTime(String.Format(seriesCache, series));
				if (ftime.AddDays(1) < DateTime.Now)
				{
					File.Delete( String.Format(seriesCache, series) );
				}
			}

			if (!File.Exists(String.Format(seriesCache, series)))
			{
				String seriesEnc = series;
				seriesEnc = seriesEnc.Replace(" - ", " | ");
				seriesEnc = seriesEnc.Replace("-", " ");
				seriesEnc = seriesEnc.Replace(" | ", "_-_");
				seriesEnc = seriesEnc.Replace(" ", "_");
				WebClient cli = new WebClient();
				cli.DownloadFile(String.Format(detailUrl, seriesEnc), seriesCache);
				cli.Dispose();
			}

			if (File.Exists(String.Format(seriesCache, series)))
			{
				StreamReader sreader = File.OpenText(seriesCache);
				data = sreader.ReadToEnd();
				sreader.Close();
			}
			return data;
		}

		public void getEpisodeData(ref Episode ep)
		{
			String data = getSeriesData(ep.series);

			if (data == null) return;

			Match m = null;
			MatchCollection mcol = null;

			Regex img = new Regex(" <img([^>]*)>&nbsp;");
			mcol = img.Matches(data);
			if (mcol.Count > 0)
			{
				for (int i=0; i<mcol.Count; i++)
				{
					data = data.Replace(mcol[i].Groups[0].Captures[0].Value, "");
				}
			}

			if (ep.season > 0 && ep.episodes.Length > 0)
			{
				String seasonCode = ep.season+"x"+((ep.episode<10)?("0"+ep.episode.ToString()):ep.episode.ToString());
				String[] pats = {	"\">Pilot</td><td([^>]*)><a href=\"/episode/([0-9]+)\">([^<]*)</a>",
									"<font color=gray>Pilot</font></td><td([^>]*)><a href=\"/episode/([0-9]+)\"><font color=gray>([^<]*)</font>",
									"\">"+seasonCode+"</td><td([^>]+)><a href=\"/episode/([0-9]+)\">([^<]*)</a>",
									"<font color=gray>"+seasonCode+"</font></td><td([^>]*)><a href=\"/episode/([0-9]+)\"><font color=gray>([^<]*)</font>"
								};

				for (int i=0; i<pats.Length; i++)
				{
					Regex reg = new Regex(pats[i]);
					m = reg.Match(data);
					if (m.Success)
					{
						ep.title = m.Groups[3].Captures[0].Value;
					}
					m = null;
				}
			}
			else if (ep.special)
			{
				return;
			}
			else
			{
				FileInfo fi = new FileInfo(ep.filename);

				String fname = fi.Name;
				Regex brack = new Regex("\\[([0-9A-Za-z-]*)\\]");
				mcol = brack.Matches(fname);
				if (mcol.Count > 0)
				{
					for (int i=0; i<mcol.Count; i++)
					{
							fname = fname.Replace(mcol[i].Groups[0].Captures[0].Value, "");
					}
				}

				Regex epId = new Regex("([0-9]{2,})");
				m = epId.Match(fname);
				int episodeId = 0;
				if (m.Success) 
				{
					episodeId = Int32.Parse(m.Groups[0].Captures[0].Value);
				}

				if (episodeId > 0)
				{
					String pat = "<td([^>]*)>"+episodeId+"&nbsp;</td><td([^>]*)><a href=\"/episode/([0-9]+)\">([0-9]+)x([0-9]+)</td><td([^>]*)><a href=\"/episode/([0-9]+)\">([^<]*)</a>";
					Regex reg = new Regex(pat);
					m = reg.Match(data);
					if (m.Success)
					{
						ep.season = Int32.Parse(m.Groups[4].Captures[0].Value);
						ep.episode = Int32.Parse(m.Groups[5].Captures[0].Value);
						ep.title = m.Groups[8].Captures[0].Value;
					}
				}
				else
				{
					String file = fi.Name;
					file = file.Replace(fi.Extension, "");
					file = file.Replace('.', ' ');
					file = file.Replace('_', ' ');
					file = file.Substring( file.IndexOf(" - ") + 3 );
					ep.title = file;					
				}
			}
			Regex uni = new Regex("&#([0-9]+);");
			mcol = uni.Matches(ep.title);
			if (mcol.Count > 0)
			{
				Regex real = new Regex("\\(([-a-zA-Z0-9.,%:;!?'\"+() ]{5,})\\)");
				m = real.Match(ep.title);
				if (m.Success)
				{
					ep.title = m.Groups[1].Captures[0].Value;
				}
				else
				{
					ep.title = null;
				}
			}
		}
	}
}
