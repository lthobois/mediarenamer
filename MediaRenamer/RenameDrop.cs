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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MediaRenamer.Common;
using MediaRenamer.Movies;
using MediaRenamer.Series;
using System.Reflection;
using System.IO;

namespace MediaRenamer
{
    public partial class RenameDrop : Form
    {
        VistaGlass.Margins marg;

        public RenameDrop()
        {
            InitializeComponent();

            this.ControlBox = false;
            this.Text = string.Empty;

            if (VistaGlass.IsGlassSupported())
            {
                this.BackColor = Color.Black;
                marg.Top = -1;
                VistaGlass.ExtendGlassFrame(this.Handle, ref marg);
            }
        }

        // make windows do the work for us by lieing to it about where the user clicked
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x84 // if this is a click
                && m.Result.ToInt32() == 1 // ...and it is on the client
                )
            {
                m.Result = new IntPtr(2); // lie and say they clicked on the title bar
            }
        }

        private void RenameDrop_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void RenameDrop_DragDrop(object sender, DragEventArgs e)
        {
            // transfer the filenames to a string array
            // (yes, everything to the left of the "=" can be put in the 
            // foreach loop in place of "files", but this is easier to understand.)
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // loop through the string array, adding each filename to the ListBox
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file.Trim());
                if (Episode.validEpisodeFile(fi.Name))
                {
                    Episode ep = Episode.parseFile(fi.FullName);
                    if (ep.needRenaming())
                    {
                        SeriesLocations locations = new SeriesLocations();
                        String path = locations.getEpisodePath(ep);
                        if (Directory.Exists(path))
                        {
                            ep.renameEpisodeAndMove(path);
                            locations.addSeriesLocation(ep);
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
                        if (Settings.GetValueAsBool(SettingKeys.MoveMovies))
                        {
                            String path = Settings.GetValueAsString(SettingKeys.MovieLocation);
                            movie.renameMovieAndMove(path);
                        }
                        else
                        {
                            movie.renameMovie();
                        }
                    }
                }
            }
        }

        private void RenameDrop_Paint(object sender, PaintEventArgs e)
        {
            Image img = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("MediaRenamer.Resources.dropTarget.png"));
            RectangleF pos = new RectangleF(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
            e.Graphics.DrawImage(img, pos);
        }

        private void RenameDrop_Resize(object sender, EventArgs e)
        {
            this.Width = 64;
            this.Height = 64;
        }
    }
}
