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
using System.Collections;
using System.Collections.Generic;

namespace MediaRenamer.Series
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

        private Hashtable seriesList;

        public OnlineParser()
        {
            String cacheDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + Application.ProductName + @"\series\";
            if (!Directory.Exists(cacheDir)) Directory.CreateDirectory(cacheDir);
            cache = cacheDir + "{0}_{1}.dat";

            Object table = Settings.GetValueAsObject<Hashtable>(SettingKeys.SeriesData);
            if (table != null)
            {
                seriesList = (Hashtable)table;
            }
            else
            {
                seriesList = new Hashtable();
            }
        }

        private XmlDocument getSeriesData(ref Episode ep)
        {
            String searchCache = String.Format(cache, "searchTemp", "X");

            WebClient cli = new WebClient();
            XmlDocument xml = new XmlDocument();

            showClass show = new showClass();
            show.ID = ep.series;
            show.Season = ep.season;
            show.Lang = ep.language;
            show.Name = ep.series;

            if (seriesList.ContainsKey(ep.series))
            {
                show = (showClass)seriesList[ep.series];
            }
            else if (seriesList.ContainsKey(ep.altSeries))
            {
                show = (showClass)seriesList[ep.altSeries];
            }

            String seriesHash = MD5.createHash(show.ID);
            String seriesCache = String.Format(cache, seriesHash, ep.season);

            if (!File.Exists(seriesCache))
            {
                if (show.ID != null && show.Year > 0)
                {
                    //I know which series - just download it
                    cli.DownloadFile(String.Format(detailUrl, show.ID, ep.season, show.Year, show.Lang),
                        seriesCache);
                    xml.Load(seriesCache);
                }
                else
                {
                    // Search for series
                    cli.DownloadFile(String.Format(queryUrl, ep.series, ep.season), searchCache);
                    xml.Load(searchCache);

                    List<showClass> shows = new List<showClass>();
                    XmlNodeList nodes;
                    // Shows found on episodeworld.com
                    if ((xml.DocumentElement.ChildNodes.Count > 0) &&
                        (xml.DocumentElement.Name == "search"))
                    {
                        nodes = xml.GetElementsByTagName("found");
                        foreach (XmlNode node in nodes)
                        {
                            showClass sc = new showClass();
                            sc.ID = node.Attributes["id"].Value;
                            sc.Name = node.Attributes["name"].Value;
                            sc.Year = Int32.Parse(node.Attributes["year"].Value);
                            sc.Season = ep.season;
                            shows.Add(sc);
                        }

                        // Check altSeries list as well
                        cli.DownloadFile(String.Format(queryUrl, ep.altSeries, ep.season), searchCache);
                        xml.Load(searchCache);

                        if ((xml.DocumentElement.ChildNodes.Count > 0) &&
                        (xml.DocumentElement.Name == "search"))
                        {
                            nodes = xml.GetElementsByTagName("found");
                            foreach (XmlNode node in nodes)
                            {
                                showClass sc = new showClass();
                                sc.ID = node.Attributes["id"].Value;
                                sc.Name = node.Attributes["name"].Value;
                                sc.Year = Int32.Parse(node.Attributes["year"].Value);
                                sc.Season = ep.season;
                                shows.Add(sc);
                            }
                        }
                    }
                    else if (xml.DocumentElement.Name == "series")
                    {
                        // Found series directly.
                        FileInfo fi = new FileInfo(searchCache);
                        fi.MoveTo(seriesCache);
                    }
                    else
                    {
                        show = this.chooseSeries(ep, shows);
                        if (show != null)
                        {
                            cli.DownloadFile(
                                String.Format(detailUrl, show.ID, ep.season, show.Year, show.Lang), seriesCache
                                );
                        }
                    }
                }
            }

            // Check if cache is outdated
            if (File.Exists(seriesCache))
            {
                DateTime dt = File.GetLastWriteTime(seriesCache);
                if (DateTime.Now.Subtract(dt).TotalDays > 3)
                {
                    // Log.Add( i18n.t( "oparse_older", ep.series) );
                    File.Delete(seriesCache);
                    cli.DownloadFile(String.Format(detailUrl, show.ID, ep.season, show.Year, show.Lang),
                        seriesCache);
                }
                if (File.Exists(seriesCache))
                {
                    xml.Load(seriesCache);
                }

                if (xml.DocumentElement.Attributes.Count > 1)
                {
                    show.ID = xml.DocumentElement.Attributes["id"].Value;
                    show.Name = xml.DocumentElement.Attributes["name"].Value;
                    show.Year = Int32.Parse(xml.DocumentElement.Attributes["year"].Value);
                    show.Lang = xml.DocumentElement.Attributes["defaultlanguage"].Value;
                    ep.language = show.Lang;
                    if (!seriesList.ContainsKey(ep.series))
                    {
                        seriesList.Add(ep.series, show);
                        Settings.SetValue(SettingKeys.SeriesData, seriesList);
                    }
                }
            }

            cli.Dispose();

            if (ep.language == null || ep.language == "")
                ep.language = "english";

            return xml;
        }

        private showClass chooseSeries(Episode ep, List<showClass> shows)
        {
            if (shows.Count == 0) return null;
            if (shows.Count == 1)
            {
                return shows[0];
            }
            SelectShow showDlg = new SelectShow();

            //showDlg.Text = i18n.t( "showdlg_title", ep.series);
            showDlg.Text = String.Format("Select series for {0}", ep.series);
            showDlg.setEpisodeData(ep);
            foreach (showClass show in shows)
            {
                showDlg.addShow(show);
            }

            if (showDlg.ShowDialog() == DialogResult.OK)
            {
                return showDlg.selectedShow;
            }
            else
            {
                return null;
            }

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

                if ((ep.season + ep.episode) > 0)
                {
                    XmlNodeList nodes = xml.GetElementsByTagName("episode");
                    if (nodes.Count > 0)
                    {
                        foreach (XmlNode node in nodes)
                        {
                            if ((node.Attributes["season"].Value == ep.season.ToString()) &&
                                 (node.Attributes["episode"].Value == ep.episode.ToString()) &&
                                 (node.Attributes["language"].Value == ep.language.ToString()) &&
                                 (node.Attributes["special"].Value == "false")
                                )
                            {
                                ep.title = node.Attributes["title"].Value;
                                if (ep.episodes.Length > 1)
                                {
                                    if (ep.title.EndsWith(")"))
                                    {
                                        ep.title = ep.title.Substring(0, ep.title.LastIndexOf("("));
                                    }
                                }
                                ep.title = ep.title.Replace(".i.", "");
                                if (ep.title.IndexOf("aka") > 0)
                                {
                                    ep.title = Eregi.replace("\\(aka([^)]*)\\)", "", ep.title);
                                }
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
                    this.renameGeneric(ref ep);
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
                Log.Add("getEpisodeData(): " + ep.series + "\n" + ep.season + "x" + ep.episode + "\n" + ep.title + "\n\n" + E.Message + "\n" + E.StackTrace + "\n" + E.Source);
            }
        }

        private void renameGeneric(ref Episode ep)
        {
            FileInfo fi = new FileInfo(ep.filename);

            String fname = fi.Name;
            Regex brack = new Regex("\\[([0-9A-Za-z-]*)\\]");
            MatchCollection mcol = brack.Matches(fname);
            if (mcol.Count > 0)
            {
                for (int i = 0; i < mcol.Count; i++)
                {
                    fname = fname.Replace(mcol[i].Groups[0].Captures[0].Value, "");
                }
            }

            Regex epId = new Regex("([0-9]{2,})");
            Match m = epId.Match(fname);
            int episodeId = 0;
            if (m.Success)
            {
                episodeId = Int32.Parse(m.Groups[0].Captures[0].Value);
            }

            String file = fi.Name;
            file = file.Replace(fi.Extension, "");
            file = file.Replace('.', ' ');
            file = file.Replace('_', ' ');
            file = file.Substring(file.IndexOf(" - ") + 3);
            ep.title = file;
        }


    }
}
