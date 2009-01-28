// *******************************************************************************
//  Title:			Parser.cs
//  Description:	Parses the folder for valid movie files and checks them
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MediaRenamer;
using MediaRenamer.Common;

namespace MovieRenamer
{
	/// <summary>
	/// Zusammenfassung für MovieParser.
	/// </summary>
	public class Parser
	{
		private String moviesPath = "";

		public Parser(String path)
		{
			if (!path.EndsWith(@"\")) path += @"\";
			moviesPath = path;
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

        public event ListMovieHandler ListMovie;
        protected virtual void OnListMovie(Movie m)
        {
            ListMovieHandler handler = ListMovie;
            if (handler != null)
            {
                handler(m);
            }
        }

		private bool isVideo(String name)
		{
			name = name.ToLower();
			if (name.EndsWith(".avi")) return true;
			if (name.EndsWith(".divx")) return true;
			if (name.EndsWith(".mov")) return true;
			if (name.EndsWith(".mkv")) return true;
			if (name.EndsWith(".mpg")) return true;
			if (name.EndsWith(".ogm")) return true;
			return false;
		}

		private void scanFolder(String folder)
		{
			String[] elements;
			elements = Directory.GetFileSystemEntries(folder);
			for (int i=0; i<elements.Length; i++)
			{
				//if (isVideo(elements[i]))
				{
					FileAttributes fAttr = File.GetAttributes(elements[i]);
					if ( (fAttr | FileAttributes.ReadOnly) 
						== fAttr)
					{
						//MessageBox.Show("File is write protected: \n"+elements[i]);
					}
					else
					{
						Movie movie = Movie.parseFile(elements[i], moviesPath);
                        if (movie.needRenaming())
                        {
                            OnListMovie(movie);
                        }
					}
				}
                OnScanProgress(i, elements.Length-1);
			}
            OnScanProgress(0, 0);
		}

		public void startScan()
		{
			if (moviesPath == "")
				return;
			scanFolder(moviesPath);
		}
	}
}
