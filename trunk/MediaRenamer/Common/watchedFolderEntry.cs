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
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

using MediaRenamer.Movies;
using MediaRenamer.Series;

namespace MediaRenamer.Common
{
    enum WatchFolderEntryType { SERIES, MOVIES };

    class WatchedFolderEntry
    {
        private String path;
        private WatchFolderEntryType type;
        private DateTime lastchange;
        private Thread folderWatchThreadSize;
        private FileSystemWatcher fileSystemWatcherSize;
        private Thread folderWatchThreadName;
        private FileSystemWatcher fileSystemWatcherName;
        private DateTime lastModifyMsg;
        private bool isRunning = false;

        public WatchedFolderEntry()
        {
            lastModifyMsg = DateTime.MinValue;
        }

        ~WatchedFolderEntry()
        {
            if (isRunning)
            {
                folderWatchThreadName.Abort();
                folderWatchThreadSize.Abort();
            }
        }

        #region get/set Methods

        public String watchPath
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public WatchFolderEntryType watchType
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public DateTime lastChanged
        {
            get
            {
                return lastchange;
            }
            set
            {
                lastchange = value;
            }
        }

        public bool threadRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                if (!value)
                {
                    stopThread();
                }
                else
                {
                    runThread();
                }
            }
        }
        #endregion

        public void runThread()
        {
            if (isRunning) return;

            if (!Directory.Exists(path)) return;

            fileSystemWatcherSize = new FileSystemWatcher();
            fileSystemWatcherSize.WatchFolderPath = path;
            fileSystemWatcherSize.WatchSubfolders = true;
            fileSystemWatcherSize.WatchForChange = FileNotifyChange.Size;
            fileSystemWatcherSize.Change += new FileSystemChangeHandler(this.fileSystemWatcher_Change);
            folderWatchThreadSize = new Thread(new ThreadStart(fileSystemWatcherSize.Run));
            folderWatchThreadSize.IsBackground = true;
            folderWatchThreadSize.Start();

            fileSystemWatcherName = new FileSystemWatcher();
            fileSystemWatcherName.WatchFolderPath = path;
            fileSystemWatcherName.WatchSubfolders = true;
            fileSystemWatcherName.WatchForChange = FileNotifyChange.FileName | FileNotifyChange.DirName;
            fileSystemWatcherName.Change += new FileSystemChangeHandler(this.fileSystemWatcher_Change);
            folderWatchThreadName = new Thread(new ThreadStart(fileSystemWatcherName.Run));
            folderWatchThreadName.IsBackground = true;
            folderWatchThreadName.Start();

            isRunning = true;

        }

        public void fileSystemWatcher_Change()
        {
            if (lastModifyMsg.AddMinutes(3) < DateTime.Now)
            {
                lastModifyMsg = DateTime.Now;
                Log.Add(path+": change detected");
            }
            lastchange = DateTime.Now;
            // Let's not jump to conclusions
            Thread.Sleep(5000);

            switch (type)
            {
                case WatchFolderEntryType.MOVIES:
                    MediaRenamer.Movies.Parser mparse = new MediaRenamer.Movies.Parser(path);
                    mparse.ListMovie += new ListMovieHandler(watchedFolder_newMovie);
                    mparse.startScan();
                    break;
                case WatchFolderEntryType.SERIES:
                    MediaRenamer.Series.Parser tparse = new MediaRenamer.Series.Parser(path);
                    tparse.ListEpisode += new ListEpisodeHandler(watchedFolder_newEpisode);
                    tparse.startScan();
                    break;
            }
        }

        void watchedFolder_newEpisode(Episode ep)
        {
            ep.renameEpisode();
        }

        void watchedFolder_newMovie(Movie m)
        {
            m.renameMovie();
        }

        public void stopThread()
        {
            if (!isRunning) return;

            if (folderWatchThreadSize.IsAlive)
            {
                folderWatchThreadSize.Abort();
            }
            if (folderWatchThreadName.IsAlive)
            {
                folderWatchThreadName.Abort();
            }

            isRunning = false;
        }
    }
}
