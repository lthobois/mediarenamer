// *******************************************************************************
//  Title:			Parser.cs
//  Description:	Parses through the folder structure to find episodes and 
//					queries them using the OnlineParser
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MediaRenamer;
using MediaRenamer.Common;

namespace MediaRenamer.Series
{
	/// <summary>
	/// Parser Class for TVShows
	/// </summary>
	public class Parser
	{
		private String seriesPath = "";

		// Valid extensions
		public static String[] extension = { ".avi", ".mkv", ".mpg", ".mpeg", ".mov", ".wmv",
										 ".rpm", ".ogm", ".srt", ".sub", ".mp4", ".divx" };

		public Parser(String path)
		{
			if (!path.EndsWith(@"\")) path += @"\";
			seriesPath = path;
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

        public event ListEpisodeHandler ListEpisode;
        protected virtual void OnListEpisode(Episode m)
        {
            ListEpisodeHandler handler = ListEpisode;
            if (handler != null)
            {
                handler(m);
            }
        }

		/// <summary>
		/// Checks for valid extensions
		/// </summary>
		/// <param name="name">filename</param>
		/// <returns></returns>
		private bool isValidExt(String name)
		{
			name = name.ToLower();
			foreach (String ext in extension)
			{
				if (name.EndsWith(ext)) return true;
			}
			return false;
		}

		/// <summary>
		/// Scan folder. Will be called recursively to find alle episodes
		/// </summary>
		/// <param name="folder">folder to scan</param>
		private void scanFolder(String folder)
		{
            SeriesLocations locations = new SeriesLocations();

			String[] elements;
			// First, let's scan the files ...
			elements = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            //Log.Add(elements.Length + " Elements total");
			for (int i=0; i<elements.Length; i++)
			{
				if (isValidExt(elements[i]))
				{
					FileAttributes fAttr = File.GetAttributes(elements[i]);
					if ( (fAttr | FileAttributes.ReadOnly) 
						== fAttr)
					{
						//MessageBox.Show("File is write protected: \n"+elements[i]);
					}
					else
					{
						Episode ep = parseFile(elements[i]);
						if (ep == null) continue;
                        locations.addSeriesLocation(ep);
						if (!ep.special && ep.needRenaming())
						{
							OnListEpisode( ep );
						}
					}
				}
                OnScanProgress(i, elements.Length - 1);
			}
            locations.saveLocations();
            //OnScanProgress(0, 0);
		}

        /// <summary>
        /// Parses a filename for episode information
        /// </summary>
        /// <param name="file">complete filename</param>
        /// <returns>filled Episode class</returns>
		public Episode parseFile(String file)
		{
            Episode ep = Episode.parseFile(file);
			return ep;
		}

    	/// <summary>
		/// Executes the actual scan
		/// </summary>
		public void startScan()
		{
			if (seriesPath == "")
				return;
			scanFolder(seriesPath);
		}

	}
}
