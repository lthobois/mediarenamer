using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MediaRenamer.Series;
using MediaRenamer.Movies;

namespace MediaRenamer.Common {
    public class renameObject {
        private String _filename;

        public renameObject(String file) {
            _filename = file;
        }

        public void rename() {
            FileInfo fi = new FileInfo(_filename.Trim());
            if (Episode.validEpisodeFile(fi.Name)) {
                Episode ep = Episode.parseFile(fi.FullName);
                if (ep.needRenaming()) {
                    SeriesLocations locations = new SeriesLocations();
                    String path = locations.getEpisodePath(ep);
                    if (Directory.Exists(path)) {
                        ep.renameEpisodeAndMove(path);
                        locations.addSeriesLocation(ep);
                    }
                    else {
                        ep.renameEpisode();
                    }
                }
            }
            else {
                Movie movie = Movie.parseFile(fi.FullName, fi.DirectoryName + @"\");
                if (movie.needRenaming()) {
                    if (Settings.GetValueAsBool(SettingKeys.MoveMovies)) {
                        String path = Settings.GetValueAsString(SettingKeys.MovieLocation);
                        movie.renameMovieAndMove(path);
                    }
                    else {
                        movie.renameMovie();
                    }
                }
            }
        }
    }
}
