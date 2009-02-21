using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MediaRenamer.Series;
using MediaRenamer.Movies;
using System.Windows.Forms;
using System.Threading;

namespace MediaRenamer.Common {
    public class renameObject {
        private String _filename;
        public Boolean copyFile = false;

        private ProgressBar _progress = null;
        private ToolTip _tip = null;

        public renameObject(String file) {
            _filename = file;
        }

        public ProgressBar progress {
            get {
                return _progress;
            }
            set {
                _progress = value;
            }
        }

        public event RenameDone RenameDone;
        protected virtual void OnRenameDone() {
            RenameDone handler = RenameDone;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        public void progressHover(object sender, EventArgs e) {
            if (_tip == null) {
                _tip = new ToolTip();
                _tip.SetToolTip(this.progress, (copyFile ? "Copying" : "Moving") + ": " + _filename);
            }
        }

        public void rename() {
            /*Random rand = new Random();
            Thread.Sleep(rand.Next(100, 3000));
            this.OnRenameDone();
            return;*/

            FileInfo fi = new FileInfo(_filename.Trim());
            if (Episode.validEpisodeFile(fi.Name)) {
                Episode ep = Episode.parseFile(fi.FullName);
                if (ep.needRenaming()) {
                    SeriesLocations locations = new SeriesLocations();
                    String path = locations.getEpisodePath(ep);
                    if (Directory.Exists(path)) {
                        ep.renameEpisodeAndMove(path, copyFile);
                        locations.addSeriesLocation(ep);
                    }
                    else {
                        ep.renameEpisode();
                    }
                }
            }
            else {
                Movie movie = Movie.parseFile(fi.FullName);
                if (movie.needRenaming()) {
                    if (Settings.GetValueAsBool(SettingKeys.MoveMovies)) {
                        String path = Settings.GetValueAsString(SettingKeys.MovieLocation);
                        movie.renameMovieAndMove(path, copyFile);
                    }
                    else {
                        movie.renameMovie();
                    }
                }
            }

            if (_tip != null) {
                _tip.Dispose();
            }

            this.OnRenameDone();
        }
    }
}
