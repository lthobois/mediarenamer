using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Reflection;

using MediaRenamer.Common;
using MediaRenamer.Movies;
using MediaRenamer.Series;

namespace MediaRenamer
{
    public partial class mainForm : Form
    {
        public static mainForm instance = null;
        public static Form dialogOwner = null;
        public RenameDrop dropform = new RenameDrop();

        public mainForm()
        {
            InitializeComponent();

            mainForm.instance = this;
            mainForm.dialogOwner = this;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\MediaRenamer");
            key.Close();

            this.Text = Application.ProductName + " v" + Application.ProductVersion;

            notifyIcon.Visible = Settings.GetValueAsBool(SettingKeys.SysTrayIcon);
            optionSysTray.Checked = Settings.GetValueAsBool(SettingKeys.SysTrayIcon);
            this.ShowInTaskbar = !Settings.GetValueAsBool(SettingKeys.SysTrayIcon);

            optionStartMinimized.Checked = Settings.GetValueAsBool(SettingKeys.StartMinimized);
            if (Settings.GetValueAsBool(SettingKeys.StartMinimized))
            {
                if (Settings.GetValueAsBool(SettingKeys.SysTrayIcon))
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.Visible = !Settings.GetValueAsBool(SettingKeys.StartMinimized);
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }

            option_moveMovies.Checked = Settings.GetValueAsBool(SettingKeys.MoveMovies);
            option_movieTargetLocation.Text = Settings.GetValueAsString(SettingKeys.MovieLocation);

            displayDropTarget(Settings.GetValueAsBool(SettingKeys.DisplayDropTarget));
            optionDropTarget.Checked = Settings.GetValueAsBool(SettingKeys.DisplayDropTarget);

            String movieFmt = Settings.GetValueAsString(SettingKeys.MovieFormat);
            if (movieFmt != String.Empty)
            {
                option_movieFormat.Text = movieFmt;
            }

            String seriesFmt = Settings.GetValueAsString(SettingKeys.SeriesFormat);
            if (seriesFmt != String.Empty)
            {
                option_seriesFormat.Text = seriesFmt;
            }

            Object[] items = null;
            items = Settings.GetValueAsObject<Object[]>(SettingKeys.MoviePaths);
            if (items != null)
            {
                movieScanPath.Items.AddRange(items);
            }
            items = Settings.GetValueAsObject<Object[]>(SettingKeys.SeriesPaths);
            if (items != null)
            {
                seriesScanPath.Items.AddRange(items);
            }

            String uiLang = Settings.GetValueAsString(SettingKeys.UILanguage);
            i18nLang ui18nLang = new i18nLang("en", "english");
            option_langUI.Items.Add(ui18nLang);
            option_langUI.SelectedItem = ui18nLang;

            if (VistaGlass.IsGlassSupported())
            {
                VistaGlass.Margins marg = new VistaGlass.Margins();
                //marg.Top = panelTop.Height;
                //marg.Left = panelTop.Width;

                //panelTop.BackColor = Color.Black;
                VistaGlass.ExtendGlassFrame(this.Handle, ref marg);
            }

        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.GetValueAsBool(SettingKeys.SysTrayIcon))
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }

        private void contextProposals_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip cms = (sender as ContextMenuStrip);
            if (option_seriesFormat.Focused)
            {
                cms.Items.Clear();
                cms.Items.Add("<series>");
                cms.Items.Add("<season>");
                cms.Items.Add("<season2>");
                cms.Items.Add("<episode>");
                cms.Items.Add("<episode2>");
                cms.Items.Add("<title: >");
                cms.Items.Add("<title>");
            }
            if (option_movieFormat.Focused)
            {
                cms.Items.Clear();
                cms.Items.Add("<moviename>");
                cms.Items.Add("<year: >");
                cms.Items.Add("<year>");
                cms.Items.Add("<disk: >");
                cms.Items.Add("<disk>");
                cms.Items.Add("<lang: >");
                cms.Items.Add("<lang>");
            }
        }

        private void contextProposals_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip cms = (sender as ContextMenuStrip);
            if (option_seriesFormat.Focused)
            {
                option_seriesFormat.SelectedText = e.ClickedItem.Text;
            }
            if (option_movieFormat.Focused)
            {
                option_movieFormat.SelectedText = e.ClickedItem.Text;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            option_tvSourceEPW.Select();
        }

        private bool validPath(String path)
        {
            if (path == String.Empty)
            {
                MessageBox.Show("Please select a folder!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Directory.Exists(path))
            {
                MessageBox.Show("The selected folder does not exist!\nPlease choose a different one.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnMovieScan_Click(object sender, EventArgs e)
        {
            if (!validPath(movieScanPath.Text)) return;
            storeMoviePath(movieScanPath.Text);

            scanMovieList.Items.Clear();
            Cursor = Cursors.WaitCursor;

            MediaRenamer.Movies.Parser mparse = new MediaRenamer.Movies.Parser(movieScanPath.Text);
            mparse.ScanProgress += new ScanProgressHandler(movie_ScanProgress);
            mparse.ListMovie += new ListMovieHandler(movie_ListMovie);
            mparse.startScan();

            Cursor = Cursors.Default;
        }

        private void storeMoviePath(string p)
        {
            if (movieScanPath.Items.IndexOf(p) == -1)
            {
                movieScanPath.Items.Insert(0, p);
                Object[] items = new Object[movieScanPath.Items.Count];
                movieScanPath.Items.CopyTo(items, 0);
                Settings.SetValue(SettingKeys.MoviePaths, items);
            }
        }

        void movie_ListMovie(Movie m)
        {
            ListViewItem node = scanMovieList.Items.Add(m.title);
            node.SubItems.Add(m.year.ToString());
            FileInfo fi = new FileInfo(m.filename);
            node.SubItems.Add(fi.Name);
            node.SubItems.Add(m.modifiedName());
            node.Tag = m;
        }

        void movie_ScanProgress(int pos, int max)
        {
            if (scanMovieProgressbar.Maximum == 0)
            {
                //Log.Add(i18n.t("scan_count", max));
                Log.Add(String.Format("{0} files found.", max));
            }
            if (pos == 0 && max == 0)
            {
                //Log.Add(i18n.t("scan_complete"));
                Log.Add("Scan successfully completed!");
            }
            scanMovieProgressbar.Maximum = max;
            scanMovieProgressbar.Value = pos;
        }

        private void btnSeriesScan_Click(object sender, EventArgs e)
        {
            if (!validPath(seriesScanPath.Text)) return;
            storeSeriesPath(seriesScanPath.Text);

            scanSeriesList.Items.Clear();
            Cursor = Cursors.WaitCursor;

            MediaRenamer.Series.Parser tparse = new MediaRenamer.Series.Parser(seriesScanPath.Text);
            tparse.ScanProgress += new ScanProgressHandler(series_ScanProgress);
            tparse.ListEpisode += new ListEpisodeHandler(series_ListEpisode);
            tparse.startScan();

            Cursor = Cursors.Default;
        }

        private void storeSeriesPath(string p)
        {
            if (seriesScanPath.Items.IndexOf(p) == -1)
            {
                seriesScanPath.Items.Insert(0, p);

                Object[] items = new Object[seriesScanPath.Items.Count];
                seriesScanPath.Items.CopyTo(items, 0);
                Settings.SetValue(SettingKeys.SeriesPaths, items);
            }
        }

        void series_ListEpisode(Episode ep)
        {
            ListViewItem node = scanSeriesList.Items.Add(ep.series);
            node.SubItems.Add(ep.season.ToString());
            String episodes = "";
            for (int i = 0; i < ep.episodes.Length; i++)
            {
                episodes += ep.episodes[i].ToString();
                if (i < (ep.episodes.Length - 1))
                {
                    episodes += ", ";
                }
            }
            node.SubItems.Add(episodes);
            node.SubItems.Add(ep.title);
            FileInfo fi = new FileInfo(ep.filename);
            node.SubItems.Add(fi.Name);
            node.SubItems.Add(ep.modifiedName());
            node.Tag = ep;
        }

        void series_ScanProgress(int pos, int max)
        {
            if (scanSeriesProgressbar.Maximum == 0)
            {
                //Log.Add(i18n.t("scan_count", max));
                Log.Add(String.Format("{0} files found.", max));
            }
            if (pos == 0 && max == 0)
            {
                //Log.Add(i18n.t("scan_complete"));
                Log.Add("Scan successfully completed!");
            }
            scanSeriesProgressbar.Maximum = max;
            scanSeriesProgressbar.Value = pos;
        }

        private void contextOptionRename_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabSeries)
            {
                renameSelectedSeries();
            }
            if (tabControl.SelectedTab == tabMovies)
            {
                renameSelectedMovies();
            }
        }

        private void contextRename_Opening(object sender, CancelEventArgs e)
        {
            if (tabControl.SelectedTab == tabSeries)
            {
                contextOptionRename.Enabled = (scanSeriesList.CheckedItems.Count > 0);
                //contextOptionRename.Text = i18n.t("context_rename_series");
                contextOptionRename.Text = "Rename selected Episodes";
            }
            if (tabControl.SelectedTab == tabMovies)
            {
                contextOptionRename.Enabled = (scanMovieList.CheckedItems.Count > 0);
                //contextOptionRename.Text = i18n.t("context_rename_movies");
                contextOptionRename.Text = "Rename selected Movies";
            }

        }

        private void renameSelectedMovies()
        {
            if (scanMovieList.CheckedItems.Count > 0)
            {
                Movie m;
                for (int i = scanMovieList.CheckedItems.Count - 1; i >= 0; i--)
                {
                    m = (Movie)scanMovieList.CheckedItems[i].Tag;
                    m.renameMovie();
                    scanMovieList.CheckedItems[i].Remove();
                }
            }
        }

        private void renameSelectedSeries()
        {
            if (scanSeriesList.CheckedItems.Count > 0)
            {
                Episode ep;
                for (int i = scanSeriesList.CheckedItems.Count - 1; i >= 0; i--)
                {
                    ep = (Episode)scanSeriesList.CheckedItems[i].Tag;
                    ep.renameEpisode();
                    scanSeriesList.CheckedItems[i].Remove();
                }
            }
        }

        private void scanMovieList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                renameSelectedMovies();
            }
        }

        private void scanSeriesList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                renameSelectedSeries();
            }
        }

        private void option_movieFormat_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!option_movieFormat.Focused)
                    option_movieFormat.Focus();
            }
        }

        private void option_seriesFormat_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!option_seriesFormat.Focused)
                    option_seriesFormat.Focus();
            }
        }


        private void sysTrayExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }

        private void sysTrayOpen_Click(object sender, EventArgs e)
        {
            this.Show();

            // Move window to foreground
            this.TopMost = true;
            this.TopMost = false;
        }

        private void optionSysTray_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SetValue(SettingKeys.SysTrayIcon, optionSysTray.Checked);
            notifyIcon.Visible = optionSysTray.Checked;
            this.ShowInTaskbar = !optionSysTray.Checked;
        }

        private void option_seriesFormat_Leave(object sender, EventArgs e)
        {
            Settings.SetValue(SettingKeys.SeriesFormat, option_seriesFormat.Text);
        }

        private void option_movieFormat_Leave(object sender, EventArgs e)
        {
            Settings.SetValue(SettingKeys.MovieFormat, option_movieFormat.Text);
        }

        private void seriesScanPath_TextUpdate(object sender, EventArgs e)
        {
            btnMovieScan.Enabled = Directory.Exists(seriesScanPath.Text);
        }

        private void movieScanPath_TextUpdate(object sender, EventArgs e)
        {
            btnSeriesScan.Enabled = Directory.Exists(movieScanPath.Text);
        }

        private void tvSelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < scanSeriesList.Items.Count; i++)
            {
                scanSeriesList.Items[i].Checked = true;
            }
        }

        private void tvSelNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < scanSeriesList.Items.Count; i++)
            {
                scanSeriesList.Items[i].Checked = false;
            }
        }

        private void tvRenameEpisodes_Click(object sender, EventArgs e)
        {
            renameSelectedSeries();
        }

        private void movieSelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < scanMovieList.Items.Count; i++)
            {
                scanMovieList.Items[i].Checked = true;
            }
        }

        private void movieSelNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < scanMovieList.Items.Count; i++)
            {
                scanMovieList.Items[i].Checked = false;
            }
        }

        private void movieRename_Click(object sender, EventArgs e)
        {
            renameSelectedMovies();
        }

        private void btnSeriesBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                String path = folderBrowserDialog.SelectedPath;
                if (!path.EndsWith(@"\")) {
                    path += @"\";
                }
                seriesScanPath.Text = path;
            }
        }

        private void btnPathMovies_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                String path = folderBrowserDialog.SelectedPath;
                if (!path.EndsWith(@"\"))
                {
                    path += @"\";
                }
                movieScanPath.Text = path;
            }
        }

        private void displayDropTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayDropTarget(!dropform.Visible);
        }

        private void displayDropTarget(bool visible)
        {
            Int32 dropPadding = 20;
            if (visible)
            {
                dropform.Show();
                mainForm.dialogOwner = dropform;
            }
            else
            {
                dropform.Hide();
                mainForm.dialogOwner = this;
            }
            dropform.Left = Screen.PrimaryScreen.WorkingArea.Width - dropform.Width - dropPadding;
            dropform.Top = Screen.PrimaryScreen.WorkingArea.Height - dropform.Height - dropPadding;
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            if (Settings.GetValueAsBool(SettingKeys.SysTrayIcon))
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Hide();
                }
            }
        }

        private void optionDropTarget_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SetValue(SettingKeys.DisplayDropTarget, optionDropTarget.Checked);
            displayDropTarget(optionDropTarget.Checked);
        }

        private void btnMenu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            Point[] points = new Point[3];
            points[0] = new Point(e.ClipRectangle.Right - 12, e.ClipRectangle.Top + (e.ClipRectangle.Height / 2) - 1);
            points[1] = new Point(e.ClipRectangle.Right - 7, e.ClipRectangle.Top + (e.ClipRectangle.Height / 2) - 1);
            points[2] = new Point(e.ClipRectangle.Right - 10, e.ClipRectangle.Top + (e.ClipRectangle.Height / 2) + 2);
            g.FillPolygon(Brushes.Black, points);
        }

        private void btnMovePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            browse.Description = "Select folder where renamed movies should be moved to:";
            if (browse.ShowDialog() == DialogResult.OK)
            {
                option_movieTargetLocation.Text = browse.SelectedPath;
                Settings.SetValue(SettingKeys.MovieLocation, option_movieTargetLocation.Text);
            }
        }

        private void optionStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SetValue(SettingKeys.StartMinimized, optionStartMinimized.Checked);
        }

        private void option_moveMovies_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SetValue(SettingKeys.MoveMovies, option_moveMovies.Checked);
        }

        private void option_movieTargetLocation_TextChanged(object sender, EventArgs e)
        {
            Settings.SetValue(SettingKeys.MovieLocation, option_movieTargetLocation.Text);
        }

        private void seriesScanPath_Leave(object sender, EventArgs e)
        {
            if (!seriesScanPath.Text.EndsWith(@"\"))
                seriesScanPath.Text += @"\";
            btnSeriesScan.Enabled = Directory.Exists(seriesScanPath.Text);
            if (!Directory.Exists(seriesScanPath.Text))
            {
                seriesScanPath.Items.Remove(seriesScanPath.SelectedItem);
                if (seriesScanPath.Items.Count > 0)
                {
                    seriesScanPath.SelectedIndex = 0;
                }
            }
        }

        private void movieScanPath_Leave(object sender, EventArgs e)
        {
            if (!movieScanPath.Text.EndsWith(@"\"))
                movieScanPath.Text += @"\";

            btnMovieScan.Enabled = Directory.Exists(movieScanPath.Text);
            if (!Directory.Exists(movieScanPath.Text))
            {
                movieScanPath.Items.Remove(movieScanPath.SelectedItem);
                if (movieScanPath.Items.Count > 0)
                {
                    movieScanPath.SelectedIndex = 0;
                }
            }
        }

        private void seriesScanPath_TextChanged(object sender, EventArgs e)
        {
            btnSeriesScan.Enabled = Directory.Exists(seriesScanPath.Text);
        }
    }
}