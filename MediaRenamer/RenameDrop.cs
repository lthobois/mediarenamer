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
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using MediaRenamer.Common;
using MediaRenamer.Movies;
using MediaRenamer.Series;

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
                if ((e.KeyState & 8) == 8) {
                    e.Effect = DragDropEffects.Copy;
                }
                else if ((e.KeyState & 4) == 4) {
                    e.Effect = DragDropEffects.Move;
                }
                else {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void RenameDrop_DragDrop(object sender, DragEventArgs e)
        {
            // transfer the filenames to a string array
            // (yes, everything to the left of the "=" can be put in the 
            // foreach loop in place of "files", but this is easier to understand.)
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // loop through the string array, adding each filename to the ListBox
            foreach (string file in files) {
                renameObject tmp = new renameObject(file);
                if ((e.KeyState & 8) == 8) {
                    tmp.copyFile = true;
                }
                tmp.progress = attachProgressBar();
                tmp.progress.MouseHover += new EventHandler(tmp.progressHover);
                tmp.RenameDone += new RenameDone(onRenameDone);

                Thread renameThread = new Thread(new ThreadStart(tmp.rename));
                renameThread.Start();
            }
        }

        private ProgressBar attachProgressBar() {
            ProgressBar progress = new ProgressBar();
            progress.Size = new Size(this.ClientRectangle.Width, 10);
            progress.Location = new Point(0, this.ClientRectangle.Height + 3);
            this.setSize(this.Height + progress.Height);
            progress.Maximum = 1000;
            progress.Value = 5;
            progress.Style = ProgressBarStyle.Marquee;
            progressLayout.Controls.Add(progress);
            return progress;
        }

        void onRenameDone(renameObject ren) {
            if (this.InvokeRequired) {
                this.Invoke(new RenameDone(onRenameDone), ren);
                return;
            }
            progressLayout.Controls.Remove(ren.progress);
            this.setSize(this.Height - ren.progress.Height);
            ren.progress.Dispose();
            ren.progress = null;
        }

        private void RenameDrop_Paint(object sender, PaintEventArgs e)
        {
            Image img = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("MediaRenamer.Resources.dropTarget.png"));
            RectangleF pos = new RectangleF(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Width);
            e.Graphics.DrawImage(img, pos);
        }

        private void RenameDrop_Resize(object sender, EventArgs e)
        {
        }

        private void setSize(int _h) {
            this.Location = new Point(this.Location.X, this.Location.Y - (_h - this.Size.Height));
            this.Size = new Size(64, _h);
            progressLayout.Height = this.Size.Height - 64;
            progressLayout.Location = new Point(0, this.ClientRectangle.Width);
        }
    }
}
