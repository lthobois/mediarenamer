using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace MediaRenamer.Movies {
    class OnlineParserIMDB: OnlineParserBase {

        public static String parserName = "IMDB.com";

        override public void getMovieData(ref Movie movie) {
            String data = loadMovieData(ref movie);

            if (data == null) return;

            String pat = "<A HREF=\"/title/tt([0-9]*)/\">([^<]*)</A>";
            Regex reg = new Regex(pat);
            MatchCollection mcol = null;
            mcol = reg.Matches(data);
            List<movieData> movieNames = new List<movieData>();
            if (mcol.Count == 1) {
                if (mcol[0].Groups[2].Captures[0].Value.IndexOf("(VG)") < 0) {
                    movieNames.Add(parseMovie(mcol[0].Groups[2].Captures[0].Value));
                    String[] alternates = findAlternatives(data, mcol[0].Groups[0].Captures[0].Value);
                    foreach (String alt in alternates) {
                        movieNames.Add(parseMovie(alt));
                    }
                }
            }
            else if (mcol.Count > 1) {
                foreach (Match m in mcol) {
                    if (m.Groups[2].Captures[0].Value.IndexOf("(VG)") > 0) continue;

                    movieNames.Add(parseMovie(m.Groups[2].Captures[0].Value));

                    String[] alternates = findAlternatives(data, m.Groups[0].Captures[0].Value);
                    foreach (String alt in alternates) {
                        movieNames.Add(parseMovie(alt));
                    }
                }
            }

            movieData selectedMovie = this.chooseMovie(movie, movieNames);
            setMovieTitle(ref movie, selectedMovie);
        }

        private movieData parseMovie(String movieName) {
            movieData md = new movieData();
            md.Name = movieName;
            String pat = @"\(([0-9]{4})(|[^)]*)\)";
            Regex reg = new Regex(pat);
            Match m = null;
            m = reg.Match(md.Name);
            if (m.Success) {
                int pos = md.Name.IndexOf(m.Groups[0].Captures[0].Value);
                md.Name = md.Name.Substring(0, pos);
                md.Name = md.Name.Trim();
                pos = md.Name.LastIndexOf(",");
                if (pos > 0) {
                    String ending = md.Name.Substring(pos);
                    if (movePrefix.IndexOf(ending) != -1) {
                        md.Name = md.Name.Substring(pos + 1) + " " + md.Name.Substring(0, pos);
                    }
                }
                md.Name = md.Name.Trim();
                md.Year = Int32.Parse(m.Groups[1].Captures[0].Value);
            }

            return md;
        }

        string requestImdbPost(string uri, string parameters) {
            // parameters: name1=value1&name2=value2	
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            //string ProxyString = 
            //   System.Configuration.ConfigurationManager.AppSettings
            //   [GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            webRequest.UserAgent = "Mozilla/5.0";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(parameters);
            Stream os = null;
            try { // send the Post
                webRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex) {
                MessageBox.Show(ex.Message, "HttpPost: Request error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if (os != null) {
                    os.Close();
                }
            }

            try { // get the response
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null) { return null; }
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex) {
                MessageBox.Show(ex.Message, "HttpPost: Response error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private String loadMovieData(ref Movie movie) {
            String movieName = movie.title;
            if (movie.year > 0) {
                movieName += " (" + movie.year.ToString() + ")";
            }
            movieName = movieName.Replace(" &", "");
            movieName = movieName.Replace(" And", "");
            movieName = movieName.Replace(" and", "");
            movieCache = String.Format(baseCache, movie.title, movie.year);
            String data = null;

            if (!File.Exists(String.Format(movieCache, movieName))) {
                //Log.Add( i18n.t("oparse_search", movieName) );
                String movieEnc = movieName;
                movieEnc = movieEnc.Replace("-", "+");
                movieEnc = movieEnc.Replace(" ", "+");

                String param = "tv=on&ep=off&words=" + movieEnc;
                if (movie.year > 0) {
                    param += "&year=" + movie.year;
                }
                data = requestImdbPost("http://us.imdb.com/List", param);
                StreamWriter swr = new StreamWriter(movieCache, false);
                swr.Write(data);
                swr.Close();
            }

            if (File.Exists(String.Format(movieCache, movieName))) {
                StreamReader sreader = new StreamReader(movieCache, System.Text.Encoding.Default, true);
                data = sreader.ReadToEnd();
                sreader.Close();
            }
            return data;
        }

        private string[] findAlternatives(String data, String p) {
            String[] result = new String[0];
            String aka = data.Substring(data.IndexOf(p));
            aka = aka.Substring(0, aka.IndexOf("</LI>"));
            string split = "...aka";
            while (aka.IndexOf(split) > 0) {
                String akName = aka.Substring(aka.IndexOf(split) + split.Length);
                akName = akName.Substring(0, akName.IndexOf(")") + 1);
                aka = aka.Replace(split + akName, "");
                akName = akName.Trim();
                Array.Resize<String>(ref result, result.Length + 1);
                result[result.Length - 1] = akName;
            }
            return result;
        }
    }
}
