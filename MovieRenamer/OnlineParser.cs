// *******************************************************************************
//  Title:			OnlineParser.cs
//  Description:	Parses IMDB for the correct movie name
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MediaRenamer;

namespace MovieRenamer
{
	/// <summary>
	/// Zusammenfassung für OnlineParser.
	/// </summary>
	public class OnlineParser
	{
		private String cache = @"data\{0}.html";
		private String moveEnding = ", A, An, The, Le";

		public OnlineParser()
		{
			String cacheDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\MovieRenamer\data\";
			if (!Directory.Exists(cacheDir)) Directory.CreateDirectory(cacheDir);
			cache = cacheDir+"{0}.html";
		}

		string requestImdbPost(string uri, string parameters)
		{ 
			// parameters: name1=value1&name2=value2	
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create (uri);
			//string ProxyString = 
			//   System.Configuration.ConfigurationManager.AppSettings
			//   [GetConfigKey("proxy")];
			//webRequest.Proxy = new WebProxy (ProxyString, true);
			//Commenting out above required change to App.Config
			webRequest.ContentType = "application/x-www-form-urlencoded";
			webRequest.Method = "POST";
			webRequest.UserAgent = "Mozilla/5.0";
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes (parameters);
			Stream os = null;
			try
			{ // send the Post
				webRequest.ContentLength = bytes.Length;   //Count bytes to send
				os = webRequest.GetRequestStream();
				os.Write (bytes, 0, bytes.Length);         //Send it
			}
			catch (WebException ex)
			{
				MessageBox.Show ( ex.Message, "HttpPost: Request error", 
					MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
			finally
			{
				if (os != null)
				{
					os.Close();
				}
			}
 
			try
			{ // get the response
				WebResponse webResponse = webRequest.GetResponse();
				if (webResponse == null) 
				{ return null; }
				StreamReader sr = new StreamReader (webResponse.GetResponseStream());
				return sr.ReadToEnd ().Trim ();
			}
			catch (WebException ex)
			{
				MessageBox.Show ( ex.Message, "HttpPost: Response error", 
					MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
			return null;
		}

		private String loadMovieData(ref Movie movie)
		{
			String movieName = movie.title;
			if (movie.year > 0)
			{
				movieName += " ("+movie.year.ToString()+")";
			}
			movieName = movieName.Replace(" &", "");
			movieName = movieName.Replace(" And", "");
			movieName = movieName.Replace(" and", "");
			String movieCache = String.Format(cache, movieName);
			String data = null;
			
			if (!File.Exists(String.Format(movieCache, movieName)))
			{
				Log.Add( i18n.t("oparse_search", movieName) );
				String movieEnc = movieName;
				movieEnc = movieEnc.Replace("-", "+");
				movieEnc = movieEnc.Replace(" ", "+");

				String param = "tv=on&ep=off&words="+movieEnc;
				if (movie.year > 0)
				{
					param += "&year="+movie.year;
				}
				data = requestImdbPost("http://us.imdb.com/List", param);
				StreamWriter swr = new StreamWriter( movieCache, false );
				swr.Write( data );
				swr.Close();
			}

			if (File.Exists(String.Format(movieCache, movieName)))
			{
				StreamReader sreader = new StreamReader(movieCache, System.Text.Encoding.Default, true);
				data = sreader.ReadToEnd();
				sreader.Close();
			}
			return data;
		}

		private void setMovieTitle(ref Movie movie, String title)
		{
			movie.title = title;
			movie.title = movie.title.Replace("IMDb - ", "");
			movie.title = movie.title.Replace("IMDb:", "");

			String pat = @"\(([0-9]{4})(|[^)]*)\)";
			Regex reg = new Regex(pat);
			Match m = null;
			m = reg.Match(movie.title);
			if (m.Success)
			{
				int pos = movie.title.IndexOf(m.Groups[0].Captures[0].Value);
				movie.title = movie.title.Substring( 0 , pos);
				pos = movie.title.LastIndexOf(",");
				if (pos > 0)
				{
					String ending = movie.title.Substring(pos);
					if (moveEnding.IndexOf(ending) != -1)
					{
						movie.title = movie.title.Substring(pos+1)+" "+movie.title.Substring(0, pos);
					}
				}
				movie.year = Int32.Parse(m.Groups[1].Captures[0].Value);
			}
		}

		public void getMovieData(ref Movie movie)
		{
			String data = loadMovieData(ref movie);

			if (data == null) return;

			String movieName = movie.title;
			if (movie.year > 0)
			{
				movieName += " ("+movie.year.ToString()+")";
			}

			String pat = "<A HREF=\"/title/tt([0-9]*)/\">([^<]*)</A>";
			Regex reg = new Regex(pat);
			MatchCollection mcol = null;
			mcol = reg.Matches(data);
			if (mcol.Count == 1)
			{
				setMovieTitle(ref movie, mcol[0].Groups[2].Captures[0].Value);
			}
			else if (mcol.Count > 1)
			{
				bool foundMatch = false;
				int counter = 0;
				foreach (Match m in mcol)
				{
					if (m.Groups[2].Captures[0].Value.IndexOf("(VG)") > 0) continue;
					counter++;
					setMovieTitle(ref movie, m.Groups[2].Captures[0].Value);

					if (movie.compareTitles(movieName))
					{
						foundMatch = true;
						break;
					}
				}
				if (counter == 1) foundMatch = true;
				if (!foundMatch)
				{
					Form movieDlg = new SelectMovie();
					movieDlg.Text = i18n.t( "moviedlg_title", movieName);
					
					foreach (Match m in mcol)
					{
						String mName = m.Groups[2].Captures[0].Value.ToString();
						if (mName.IndexOf("(VG)") == -1)
						{
							(movieDlg as SelectMovie).addMovie( m.Groups[2].Captures[0].Value.ToString() );
							counter++;
						}
					}
					
					if (movieDlg.ShowDialog() == DialogResult.OK)
					{
						setMovieTitle(ref movie, (movieDlg as SelectMovie).selectedMovie);
					}
					movieDlg.Dispose();
				}
			}
		}
	}
}
