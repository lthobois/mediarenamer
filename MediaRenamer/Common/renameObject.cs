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
        public ProgressBar progress = null;

        public renameObject(String file) {
            _filename = file;
        }

        public event RenameDone RenameDone;
        protected virtual void OnRenameDone() {
            RenameDone handler = RenameDone;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        public void progressHover(object sender, EventArgs e) {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.progress, (copyFile?"Copying":"Moving") + ": " + _filename);
            tip.Dispose();
        }

        public void rename() {
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
            this.OnRenameDone();
        }
    }
}
