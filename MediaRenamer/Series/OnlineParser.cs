// *******************************************************************************
//  Title:			OnlineParser.cs
//  Description:	Parses episodeworld.com for episode information
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.Win32;
using MediaRenamer;
using MediaRenamer.Common;
using System.Windows.Forms;

namespace TVShowRenamer
{
	/// <summary>
	/// Zusammenfassung für OnlineParser.
	/// </summary>
	public class OnlineParser
	{
		//																		id season year language
		private String detailUrl = "http://www.episodeworld.com/tools/mediarenamer/{0}/{1}/{2}/{3}/strict";
		//																		name season
		private String queryUrl = "http://www.episodeworld.com/tools/mediarenamer/{0}/{1}/";
		private String cache = @"data\{0}_{1}.dat";
		public OnlineParser()
		{
			String cacheDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\TVShowRenamer\data\";
			if (!Directory.Exists(cacheDir)) Directory.CreateDirectory(cacheDir);
			cache = cacheDir+"{0}_{1}.dat";
		}

		private XmlDocument getSeriesData(ref Episode ep)
		{
			String seriesCache = String.Format(cache, ep.series, ep.season);
			String searchCache = String.Format(cache, "searchTemp", "X");

			WebClient cli = new WebClient();
			XmlDocument xml = new XmlDocument();
			RegistryKey key = null;
			String showID = null;
			String showLang = null;
			int showYear = 0;

			key = Registry.CurrentUser.OpenSubKey(@"Software\MediaRenamer\Series\"+ep.series);
			// Check for forwarding key if the series has already be found by ep.altSeries
			if (key != null)
			{
				String forward = (String)key.GetValue("");
				if (forward != null)
				{
					key.Close();
					ep.series = ep.altSeries;
					return getSeriesData(ref ep);
				}
			}
			// Retreive series information if available in registry
			if (key != null)
			{
				showID = (String)key.GetValue("id");
				showYear = (int)key.GetValue("year");
				showLang = (String)key.GetValue("language");
				ep.language = showLang;
				key.Close();
			}

			// Check if cache is outdated
			if (File.Exists(seriesCache))
			{
				DateTime dt = File.GetLastWriteTime(seriesCache);
				if (DateTime.Now.Subtract(dt).TotalDays > 3)
				{
					// Log.Add( i18n.t( "oparse_older", ep.series) );
					File.Delete(seriesCache);

					cli.DownloadFile( String.Format(detailUrl, showID, ep.season, showYear, showLang), 
						seriesCache);
				}
				if (File.Exists(seriesCache))
				{
					xml.Load( seriesCache );
				}
			}

			if (xml != null)
			{
				if (!xml.HasChildNodes)
				{
					File.Delete(seriesCache);
				}
				else if (!xml.DocumentElement.HasAttribute("name"))
				{
					File.Delete(seriesCache);
				}
			}
			
			if (!File.Exists(seriesCache))
			{
				//Log.Add("Get new file");
					
				if (showID != null && showYear > 0)
				{
					//Log.Add("ID available");
					cli.DownloadFile( String.Format(detailUrl, showID, ep.season, showYear, showLang), 
						seriesCache);
					xml.Load( seriesCache );
				}
				else
				{
					//Log.Add("search series");
					cli.DownloadFile(String.Format(queryUrl, ep.series, ep.season), searchCache);

					xml.Load( searchCache );
					// Shows found on episodeworld.com
					if ( (xml.DocumentElement.ChildNodes.Count > 0) &&
						(xml.DocumentElement.Name == "search") )
					{
						Form showDlg = new SelectShow();
						showDlg.Text = i18n.t( "showdlg_title", ep.series);
						XmlNodeList nodes = xml.GetElementsByTagName("found");
						foreach ( XmlNode node in nodes)
						{
							showClass sc = new showClass();
							sc.showID = node.Attributes["id"].Value;
							sc.showName = node.Attributes["name"].Value;
							sc.showYear = Int32.Parse(node.Attributes["year"].Value);
							sc.showSeason = ep.season;
							(showDlg as SelectShow).addShow( sc );
						}
						if (ep.series != ep.altSeries)
						{
							cli.DownloadFile(String.Format(queryUrl, ep.altSeries, ep.season), searchCache);
							nodes = xml.GetElementsByTagName("found");
							foreach ( XmlNode node in nodes)
							{
								showClass sc = new showClass();
								sc.showID = node.Attributes["id"].Value;
								sc.showName = node.Attributes["name"].Value;
								sc.showYear = Int32.Parse(node.Attributes["year"].Value);
								sc.showSeason = ep.season;
								(showDlg as SelectShow).addShow( sc );
							}
						}

						if (showDlg.ShowDialog() == DialogResult.OK)
						{
							cli.DownloadFile(
								String.Format(detailUrl, 
								(showDlg as SelectShow).selectedShow.showID, 
								ep.season, 
								(showDlg as SelectShow).selectedShow.showYear, 
								showLang)
								, seriesCache);
							xml.Load( seriesCache );
						}
						else
						{
							return null;
						}
					}
					else if ( xml.DocumentElement.Name == "series")
					{
						// Found series directly.
						FileInfo fi = new FileInfo(searchCache);
						fi.MoveTo(seriesCache);
						xml.Load( seriesCache );
					}
					else
					{
						// No series with the name found. Possibly file is not in a series folder. 
						// Try alternative Series name based on filename.

						if (ep.series == ep.altSeries)
						{
							// Already tried alternative series. Nothing to find.
							Log.Add( i18n.t("oparse_notfound", ep.series) );
							xml = null;
						}
						else
						{
							key = Registry.CurrentUser.OpenSubKey(@"Software\MediaRenamer\Series", true);
							RegistryKey skey = key.CreateSubKey(ep.series);
							skey.SetValue("", ".forward");
							skey.Close();
							key.Close();
							// Try alternative series name
							ep.series = ep.altSeries;
							xml = getSeriesData(ref ep);
						}
					}						
				}
			}

			if (cli != null) 
				cli.Dispose();

			if (xml != null)
			{
				if (xml.DocumentElement.Attributes.Count > 1)
				{
					key = Registry.CurrentUser.OpenSubKey(@"Software\MediaRenamer\Series", true);
					RegistryKey skey = key.OpenSubKey(ep.series);
					if (skey == null)
					{
						skey = key.CreateSubKey(ep.series);
						skey.SetValue("id", xml.DocumentElement.Attributes["id"].Value);
						skey.SetValue("name", xml.DocumentElement.Attributes["name"].Value);
						skey.SetValue("year", Int32.Parse(xml.DocumentElement.Attributes["year"].Value));
						skey.SetValue("language", xml.DocumentElement.Attributes["defaultlanguage"].Value);
						showLang = xml.DocumentElement.Attributes["defaultlanguage"].Value;
						ep.language = showLang;
					}
					skey.Close();
					key.Close();
				}
			}
			if (ep.language == null || ep.language == "") ep.language = "english";
			
			return xml;
		}

		public void getEpisodeData(ref Episode ep)
		{
			XmlDocument xml = null;
			try
			{
				xml = getSeriesData(ref ep);

				if (xml == null) return;
				if (!xml.HasChildNodes) return;

				MatchCollection mcol = null;
				Match m = null;

				if (xml.DocumentElement.HasAttribute("name"))
				{
					ep.series = xml.DocumentElement.Attributes["name"].Value;
				}

				if ((ep.season+ep.episode) > 0)
				{
					XmlNodeList nodes = xml.GetElementsByTagName("episode");
					if (nodes.Count > 0)
					{
						foreach (XmlNode node in nodes)
						{
							if ( (node.Attributes["season"].Value == ep.season.ToString()) &&
								 (node.Attributes["episode"].Value == ep.episode.ToString()) &&
								 (node.Attributes["language"].Value == ep.language.ToString())
								)
							{
								ep.title = node.Attributes["title"].Value;
								break;
							}
						}
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

					String file = fi.Name;
					file = file.Replace(fi.Extension, "");
					file = file.Replace('.', ' ');
					file = file.Replace('_', ' ');
					file = file.Substring( file.IndexOf(" - ") + 3 );
					ep.title = file;					
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
				}
			}
			catch (Exception E)
			{
				Log.Add("getEpisodeData(): "+ep.series+"\n"+ep.season+"x"+ep.episode+"\n"+ep.title+"\n\n"+E.Message+"\n"+E.StackTrace+"\n"+E.Source);
			}
		}
	}
}
