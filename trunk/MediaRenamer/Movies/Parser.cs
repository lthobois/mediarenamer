/**
 * Copyright 2009 Benjamin Schirmer
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MediaRenamer;
using MediaRenamer.Common;

namespace MediaRenamer.Movies
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

        public event ScanDone ScanDone;
        protected virtual void OnScanDone()
        {
            ScanDone handler = ScanDone;
            if (handler != null)
            {
                handler.Invoke();
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
            OnScanDone();
		}

		public void startScan()
		{
			if (moviesPath == "")
				return;
			scanFolder(moviesPath);
		}
	}
}
