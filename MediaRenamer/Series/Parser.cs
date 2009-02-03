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
using MediaRenamer.Common;

namespace MediaRenamer.Series {
    /// <summary>
    /// Parser Class for TVShows
    /// </summary>
    public class Parser {
        private String seriesPath = "";

        // Valid extensions
        public static String[] extension = { ".avi", ".mkv", ".mpg", ".mpeg", ".mov", ".wmv",
										 ".rpm", ".ogm", ".srt", ".sub", ".mp4", ".divx" };

        public Parser(String path) {
            if (!path.EndsWith(@"\")) path += @"\";
            seriesPath = path;
        }

        public event ScanProgressHandler ScanProgress;
        protected virtual void OnScanProgress(int pos, int max) {
            ScanProgressHandler handler = ScanProgress;
            if (handler != null) {
                handler.Invoke(pos, max);
            }
        }

        public event ListEpisodeHandler ListEpisode;
        protected virtual void OnListEpisode(Episode ep) {
            ListEpisodeHandler handler = ListEpisode;
            if (handler != null) {
                handler.Invoke(ep);
            }
        }

        public event ScanDone ScanDone;
        protected virtual void OnScanDone() {
            ScanDone handler = ScanDone;
            if (handler != null) {
                handler.Invoke();
            }
        }

        /// <summary>
        /// Checks for valid extensions
        /// </summary>
        /// <param name="name">filename</param>
        /// <returns></returns>
        private bool isValidExt(String name) {
            name = name.ToLower();
            foreach (String ext in extension) {
                if (name.EndsWith(ext)) return true;
            }
            return false;
        }

        /// <summary>
        /// Scan folder. Will be called recursively to find alle episodes
        /// </summary>
        /// <param name="folder">folder to scan</param>
        private void scanFolder(String folder) {
            SeriesLocations locations = new SeriesLocations();

            String[] elements;
            // First, let's scan the files ...
            elements = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            //Log.Add(elements.Length + " Elements total");
            for (int i = 0; i < elements.Length; i++) {
                if (isValidExt(elements[i])) {
                    FileAttributes fAttr = File.GetAttributes(elements[i]);
                    if ((fAttr | FileAttributes.ReadOnly)
                        == fAttr) {
                        //MessageBox.Show("File is write protected: \n"+elements[i]);
                    }
                    else {
                        Episode ep = Episode.parseFile(elements[i]);
                        if (ep == null) continue;
                        if (!ep.special && ep.needRenaming()) {
                            OnListEpisode(ep);
                        }
                        else {
                            locations.addSeriesLocation(ep);
                        }
                    }
                }
                OnScanProgress(i, elements.Length - 1);
            }
            locations.saveLocations();
            OnScanDone();
        }

        /// <summary>
        /// Executes the actual scan
        /// </summary>
        public void startScan() {
            if (seriesPath == "")
                return;
            scanFolder(seriesPath);
        }

    }
}
