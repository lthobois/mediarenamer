using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaRenamer.Movies;
using MediaRenamer.Common;
using MediaRenamer.Series;
using System.IO;

namespace MediaRenamer
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainForm());
            }
            else
            {
                handleCommandLine(args);
            }
        }

        private static void handleCommandLine(string[] args)
        {
            String command = args[0];
            String filename = args[1];
            if (command.Contains("r"))
            {
                FileInfo fi = new FileInfo(filename.Trim());
                if (Episode.validEpisodeFile(fi.Name))
                {
                    Episode ep = Episode.parseFile(fi.FullName);
                    if (ep.needRenaming())
                    {
                        if (command.Contains("m"))
                        {
                            SeriesLocations locations = new SeriesLocations();
                            String path = locations.getEpisodePath(ep);
                            if (Directory.Exists(path))
                            {
                                ep.renameEpisodeAndMove(path);
                                locations.addSeriesLocation(ep);
                            }
                        }
                        else
                        {
                            ep.renameEpisode();
                        }
                    }
                }
                else
                {
                    Movie movie = Movie.parseFile(fi.FullName, fi.DirectoryName + @"\");
                    if (movie.needRenaming())
                    {
                        if (command.Contains("m"))
                        {
                            if (Settings.GetValueAsBool(SettingKeys.MoveMovies))
                            {
                                String path = Settings.GetValueAsString(SettingKeys.MovieLocation);
                                movie.renameMovieAndMove(path);
                            }
                        }
                        else
                        {
                            movie.renameMovie();
                        }
                    }
                }
            }
        }
    }
}