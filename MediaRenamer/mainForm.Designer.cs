namespace MediaRenamer
{
    partial class mainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSeries = new System.Windows.Forms.TabPage();
            this.tvRenameEpisodes = new System.Windows.Forms.Button();
            this.tvSelNone = new System.Windows.Forms.Button();
            this.tvSelAll = new System.Windows.Forms.Button();
            this.scanSeriesList = new System.Windows.Forms.ListView();
            this.headSeries = new System.Windows.Forms.ColumnHeader();
            this.headSeason = new System.Windows.Forms.ColumnHeader();
            this.headEpisode = new System.Windows.Forms.ColumnHeader();
            this.headTitle = new System.Windows.Forms.ColumnHeader();
            this.headFilename = new System.Windows.Forms.ColumnHeader();
            this.headNewname = new System.Windows.Forms.ColumnHeader();
            this.contextRename = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextOptionRename = new System.Windows.Forms.ToolStripMenuItem();
            this.groupSeries = new System.Windows.Forms.GroupBox();
            this.btnSeriesBrowse = new System.Windows.Forms.Button();
            this.scanSeriesProgressbar = new System.Windows.Forms.ProgressBar();
            this.btnSeriesScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.seriesScanPath = new System.Windows.Forms.ComboBox();
            this.tabMovies = new System.Windows.Forms.TabPage();
            this.movieRename = new System.Windows.Forms.Button();
            this.movieSelNone = new System.Windows.Forms.Button();
            this.movieSelAll = new System.Windows.Forms.Button();
            this.scanMovieList = new System.Windows.Forms.ListView();
            this.headMovie = new System.Windows.Forms.ColumnHeader();
            this.headYear = new System.Windows.Forms.ColumnHeader();
            this.headMoviefile = new System.Windows.Forms.ColumnHeader();
            this.headNewfile = new System.Windows.Forms.ColumnHeader();
            this.groupMovies = new System.Windows.Forms.GroupBox();
            this.btnPathMovies = new System.Windows.Forms.Button();
            this.scanMovieProgressbar = new System.Windows.Forms.ProgressBar();
            this.btnMovieScan = new System.Windows.Forms.Button();
            this.moviePathLabel = new System.Windows.Forms.Label();
            this.movieScanPath = new System.Windows.Forms.ComboBox();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.optionGroupOthers = new System.Windows.Forms.GroupBox();
            this.optionDropTarget = new System.Windows.Forms.CheckBox();
            this.label_langUI = new System.Windows.Forms.Label();
            this.option_langUI = new System.Windows.Forms.ComboBox();
            this.optionSysTray = new System.Windows.Forms.CheckBox();
            this.optionStartMinimized = new System.Windows.Forms.CheckBox();
            this.optionGroupMovies = new System.Windows.Forms.GroupBox();
            this.btnMovePath = new System.Windows.Forms.Button();
            this.option_movieTargetLocation = new System.Windows.Forms.TextBox();
            this.option_moveMovies = new System.Windows.Forms.CheckBox();
            this.option_movieFormat = new System.Windows.Forms.TextBox();
            this.contextProposals = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelMovieOutpu = new System.Windows.Forms.Label();
            this.optionGroupSeries = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTVSource = new System.Windows.Forms.Label();
            this.option_seriesFormat = new System.Windows.Forms.TextBox();
            this.labelTVOutput = new System.Windows.Forms.Label();
            this.tabWatch = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_watchType = new System.Windows.Forms.Label();
            this.label_watchPath = new System.Windows.Forms.Label();
            this.addWatchType = new System.Windows.Forms.ComboBox();
            this.addWatchFolder = new System.Windows.Forms.Button();
            this.addWatchPath = new System.Windows.Forms.TextBox();
            this.watchedFolders = new System.Windows.Forms.ListBox();
            this.runWatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopWatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSelectedWatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.sysTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sysTrayOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.displayDropTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sysTrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnAppAbout = new System.Windows.Forms.Button();
            this.optionSeriesParser = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tabSeries.SuspendLayout();
            this.contextRename.SuspendLayout();
            this.groupSeries.SuspendLayout();
            this.tabMovies.SuspendLayout();
            this.groupMovies.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.optionGroupOthers.SuspendLayout();
            this.optionGroupMovies.SuspendLayout();
            this.optionGroupSeries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.sysTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSeries);
            this.tabControl.Controls.Add(this.tabMovies);
            this.tabControl.Controls.Add(this.tabOptions);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(714, 429);
            this.tabControl.TabIndex = 3;
            // 
            // tabSeries
            // 
            this.tabSeries.Controls.Add(this.tvRenameEpisodes);
            this.tabSeries.Controls.Add(this.tvSelNone);
            this.tabSeries.Controls.Add(this.tvSelAll);
            this.tabSeries.Controls.Add(this.scanSeriesList);
            this.tabSeries.Controls.Add(this.groupSeries);
            this.tabSeries.Location = new System.Drawing.Point(4, 22);
            this.tabSeries.Name = "tabSeries";
            this.tabSeries.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeries.Size = new System.Drawing.Size(706, 403);
            this.tabSeries.TabIndex = 0;
            this.tabSeries.Text = "TV Series";
            this.tabSeries.UseVisualStyleBackColor = true;
            // 
            // tvRenameEpisodes
            // 
            this.tvRenameEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tvRenameEpisodes.Location = new System.Drawing.Point(554, 372);
            this.tvRenameEpisodes.Name = "tvRenameEpisodes";
            this.tvRenameEpisodes.Size = new System.Drawing.Size(144, 23);
            this.tvRenameEpisodes.TabIndex = 6;
            this.tvRenameEpisodes.Text = "rename selected episodes";
            this.tvRenameEpisodes.UseVisualStyleBackColor = true;
            this.tvRenameEpisodes.Click += new System.EventHandler(this.tvRenameEpisodes_Click);
            // 
            // tvSelNone
            // 
            this.tvSelNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tvSelNone.Location = new System.Drawing.Point(88, 372);
            this.tvSelNone.Name = "tvSelNone";
            this.tvSelNone.Size = new System.Drawing.Size(75, 23);
            this.tvSelNone.TabIndex = 5;
            this.tvSelNone.Text = "select none";
            this.tvSelNone.UseVisualStyleBackColor = true;
            this.tvSelNone.Click += new System.EventHandler(this.tvSelNone_Click);
            // 
            // tvSelAll
            // 
            this.tvSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tvSelAll.Location = new System.Drawing.Point(7, 372);
            this.tvSelAll.Name = "tvSelAll";
            this.tvSelAll.Size = new System.Drawing.Size(75, 23);
            this.tvSelAll.TabIndex = 4;
            this.tvSelAll.Text = "select all";
            this.tvSelAll.UseVisualStyleBackColor = true;
            this.tvSelAll.Click += new System.EventHandler(this.tvSelAll_Click);
            // 
            // scanSeriesList
            // 
            this.scanSeriesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scanSeriesList.CheckBoxes = true;
            this.scanSeriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headSeries,
            this.headSeason,
            this.headEpisode,
            this.headTitle,
            this.headFilename,
            this.headNewname});
            this.scanSeriesList.ContextMenuStrip = this.contextRename;
            this.scanSeriesList.FullRowSelect = true;
            this.scanSeriesList.Location = new System.Drawing.Point(7, 95);
            this.scanSeriesList.Name = "scanSeriesList";
            this.scanSeriesList.ShowGroups = false;
            this.scanSeriesList.Size = new System.Drawing.Size(691, 271);
            this.scanSeriesList.TabIndex = 3;
            this.scanSeriesList.UseCompatibleStateImageBehavior = false;
            this.scanSeriesList.View = System.Windows.Forms.View.Details;
            // 
            // headSeries
            // 
            this.headSeries.Text = "Series";
            this.headSeries.Width = 150;
            // 
            // headSeason
            // 
            this.headSeason.Text = "Season";
            this.headSeason.Width = 50;
            // 
            // headEpisode
            // 
            this.headEpisode.Text = "Episode";
            this.headEpisode.Width = 50;
            // 
            // headTitle
            // 
            this.headTitle.Text = "Title";
            this.headTitle.Width = 220;
            // 
            // headFilename
            // 
            this.headFilename.Text = "Filename";
            this.headFilename.Width = 180;
            // 
            // headNewname
            // 
            this.headNewname.Text = "New Filename";
            this.headNewname.Width = 180;
            // 
            // contextRename
            // 
            this.contextRename.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextOptionRename});
            this.contextRename.Name = "contextRename";
            this.contextRename.Size = new System.Drawing.Size(172, 26);
            this.contextRename.Opening += new System.ComponentModel.CancelEventHandler(this.contextRename_Opening);
            // 
            // contextOptionRename
            // 
            this.contextOptionRename.Name = "contextOptionRename";
            this.contextOptionRename.Size = new System.Drawing.Size(171, 22);
            this.contextOptionRename.Text = "rename episode(s)";
            this.contextOptionRename.Click += new System.EventHandler(this.contextOptionRename_Click);
            // 
            // groupSeries
            // 
            this.groupSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSeries.Controls.Add(this.btnSeriesBrowse);
            this.groupSeries.Controls.Add(this.scanSeriesProgressbar);
            this.groupSeries.Controls.Add(this.btnSeriesScan);
            this.groupSeries.Controls.Add(this.label1);
            this.groupSeries.Controls.Add(this.seriesScanPath);
            this.groupSeries.Location = new System.Drawing.Point(7, 7);
            this.groupSeries.Name = "groupSeries";
            this.groupSeries.Size = new System.Drawing.Size(691, 82);
            this.groupSeries.TabIndex = 0;
            this.groupSeries.TabStop = false;
            this.groupSeries.Text = "TV Series scan mode";
            // 
            // btnSeriesBrowse
            // 
            this.btnSeriesBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeriesBrowse.Location = new System.Drawing.Point(577, 30);
            this.btnSeriesBrowse.Name = "btnSeriesBrowse";
            this.btnSeriesBrowse.Size = new System.Drawing.Size(27, 23);
            this.btnSeriesBrowse.TabIndex = 6;
            this.btnSeriesBrowse.Text = "...";
            this.btnSeriesBrowse.UseVisualStyleBackColor = true;
            this.btnSeriesBrowse.Click += new System.EventHandler(this.btnSeriesBrowse_Click);
            // 
            // scanSeriesProgressbar
            // 
            this.scanSeriesProgressbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scanSeriesProgressbar.Location = new System.Drawing.Point(10, 59);
            this.scanSeriesProgressbar.Maximum = 0;
            this.scanSeriesProgressbar.Name = "scanSeriesProgressbar";
            this.scanSeriesProgressbar.Size = new System.Drawing.Size(675, 11);
            this.scanSeriesProgressbar.TabIndex = 5;
            // 
            // btnSeriesScan
            // 
            this.btnSeriesScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeriesScan.Enabled = false;
            this.btnSeriesScan.Location = new System.Drawing.Point(610, 30);
            this.btnSeriesScan.Name = "btnSeriesScan";
            this.btnSeriesScan.Size = new System.Drawing.Size(75, 23);
            this.btnSeriesScan.TabIndex = 4;
            this.btnSeriesScan.Text = "Start scan";
            this.btnSeriesScan.UseVisualStyleBackColor = true;
            this.btnSeriesScan.Click += new System.EventHandler(this.btnSeriesScan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Scan movies in folder:";
            // 
            // seriesScanPath
            // 
            this.seriesScanPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.seriesScanPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.seriesScanPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.seriesScanPath.FormattingEnabled = true;
            this.seriesScanPath.Location = new System.Drawing.Point(10, 32);
            this.seriesScanPath.Name = "seriesScanPath";
            this.seriesScanPath.Size = new System.Drawing.Size(561, 21);
            this.seriesScanPath.TabIndex = 0;
            this.seriesScanPath.SelectedIndexChanged += new System.EventHandler(this.seriesScanPath_TextUpdate);
            this.seriesScanPath.Leave += new System.EventHandler(this.seriesScanPath_Leave);
            this.seriesScanPath.TextChanged += new System.EventHandler(this.seriesScanPath_TextChanged);
            // 
            // tabMovies
            // 
            this.tabMovies.Controls.Add(this.movieRename);
            this.tabMovies.Controls.Add(this.movieSelNone);
            this.tabMovies.Controls.Add(this.movieSelAll);
            this.tabMovies.Controls.Add(this.scanMovieList);
            this.tabMovies.Controls.Add(this.groupMovies);
            this.tabMovies.Location = new System.Drawing.Point(4, 22);
            this.tabMovies.Name = "tabMovies";
            this.tabMovies.Padding = new System.Windows.Forms.Padding(3);
            this.tabMovies.Size = new System.Drawing.Size(706, 403);
            this.tabMovies.TabIndex = 1;
            this.tabMovies.Text = "Movies";
            this.tabMovies.UseVisualStyleBackColor = true;
            // 
            // movieRename
            // 
            this.movieRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.movieRename.Location = new System.Drawing.Point(554, 372);
            this.movieRename.Name = "movieRename";
            this.movieRename.Size = new System.Drawing.Size(144, 23);
            this.movieRename.TabIndex = 9;
            this.movieRename.Text = "rename selected movies";
            this.movieRename.UseVisualStyleBackColor = true;
            this.movieRename.Click += new System.EventHandler(this.movieRename_Click);
            // 
            // movieSelNone
            // 
            this.movieSelNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.movieSelNone.Location = new System.Drawing.Point(87, 372);
            this.movieSelNone.Name = "movieSelNone";
            this.movieSelNone.Size = new System.Drawing.Size(75, 23);
            this.movieSelNone.TabIndex = 8;
            this.movieSelNone.Text = "select none";
            this.movieSelNone.UseVisualStyleBackColor = true;
            this.movieSelNone.Click += new System.EventHandler(this.movieSelNone_Click);
            // 
            // movieSelAll
            // 
            this.movieSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.movieSelAll.Location = new System.Drawing.Point(6, 372);
            this.movieSelAll.Name = "movieSelAll";
            this.movieSelAll.Size = new System.Drawing.Size(75, 23);
            this.movieSelAll.TabIndex = 7;
            this.movieSelAll.Text = "select all";
            this.movieSelAll.UseVisualStyleBackColor = true;
            this.movieSelAll.Click += new System.EventHandler(this.movieSelAll_Click);
            // 
            // scanMovieList
            // 
            this.scanMovieList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scanMovieList.CheckBoxes = true;
            this.scanMovieList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headMovie,
            this.headYear,
            this.headMoviefile,
            this.headNewfile});
            this.scanMovieList.ContextMenuStrip = this.contextRename;
            this.scanMovieList.FullRowSelect = true;
            this.scanMovieList.Location = new System.Drawing.Point(7, 96);
            this.scanMovieList.Name = "scanMovieList";
            this.scanMovieList.Size = new System.Drawing.Size(691, 266);
            this.scanMovieList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.scanMovieList.TabIndex = 2;
            this.scanMovieList.UseCompatibleStateImageBehavior = false;
            this.scanMovieList.View = System.Windows.Forms.View.Details;
            // 
            // headMovie
            // 
            this.headMovie.Text = "Movie";
            this.headMovie.Width = 120;
            // 
            // headYear
            // 
            this.headYear.Text = "Year";
            this.headYear.Width = 40;
            // 
            // headMoviefile
            // 
            this.headMoviefile.Text = "Filename";
            this.headMoviefile.Width = 180;
            // 
            // headNewfile
            // 
            this.headNewfile.Text = "New Filename";
            this.headNewfile.Width = 180;
            // 
            // groupMovies
            // 
            this.groupMovies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupMovies.Controls.Add(this.btnPathMovies);
            this.groupMovies.Controls.Add(this.scanMovieProgressbar);
            this.groupMovies.Controls.Add(this.btnMovieScan);
            this.groupMovies.Controls.Add(this.moviePathLabel);
            this.groupMovies.Controls.Add(this.movieScanPath);
            this.groupMovies.Location = new System.Drawing.Point(7, 7);
            this.groupMovies.Name = "groupMovies";
            this.groupMovies.Size = new System.Drawing.Size(691, 82);
            this.groupMovies.TabIndex = 1;
            this.groupMovies.TabStop = false;
            this.groupMovies.Text = "Movie scan mode";
            // 
            // btnPathMovies
            // 
            this.btnPathMovies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPathMovies.Location = new System.Drawing.Point(577, 30);
            this.btnPathMovies.Name = "btnPathMovies";
            this.btnPathMovies.Size = new System.Drawing.Size(27, 23);
            this.btnPathMovies.TabIndex = 5;
            this.btnPathMovies.Text = "...";
            this.btnPathMovies.UseVisualStyleBackColor = true;
            this.btnPathMovies.Click += new System.EventHandler(this.btnPathMovies_Click);
            // 
            // scanMovieProgressbar
            // 
            this.scanMovieProgressbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scanMovieProgressbar.Location = new System.Drawing.Point(10, 59);
            this.scanMovieProgressbar.Maximum = 0;
            this.scanMovieProgressbar.Name = "scanMovieProgressbar";
            this.scanMovieProgressbar.Size = new System.Drawing.Size(675, 11);
            this.scanMovieProgressbar.TabIndex = 4;
            // 
            // btnMovieScan
            // 
            this.btnMovieScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMovieScan.Enabled = false;
            this.btnMovieScan.Location = new System.Drawing.Point(610, 30);
            this.btnMovieScan.Name = "btnMovieScan";
            this.btnMovieScan.Size = new System.Drawing.Size(75, 23);
            this.btnMovieScan.TabIndex = 3;
            this.btnMovieScan.Text = "Start scan";
            this.btnMovieScan.UseVisualStyleBackColor = true;
            this.btnMovieScan.Click += new System.EventHandler(this.btnMovieScan_Click);
            // 
            // moviePathLabel
            // 
            this.moviePathLabel.AutoSize = true;
            this.moviePathLabel.Location = new System.Drawing.Point(7, 16);
            this.moviePathLabel.Name = "moviePathLabel";
            this.moviePathLabel.Size = new System.Drawing.Size(111, 13);
            this.moviePathLabel.TabIndex = 2;
            this.moviePathLabel.Text = "Scan movies in folder:";
            // 
            // movieScanPath
            // 
            this.movieScanPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.movieScanPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.movieScanPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.movieScanPath.FormattingEnabled = true;
            this.movieScanPath.Location = new System.Drawing.Point(10, 32);
            this.movieScanPath.Name = "movieScanPath";
            this.movieScanPath.Size = new System.Drawing.Size(561, 21);
            this.movieScanPath.TabIndex = 1;
            this.movieScanPath.SelectedIndexChanged += new System.EventHandler(this.movieScanPath_TextUpdate);
            this.movieScanPath.Leave += new System.EventHandler(this.movieScanPath_Leave);
            this.movieScanPath.TextUpdate += new System.EventHandler(this.movieScanPath_TextUpdate);
            this.movieScanPath.TextChanged += new System.EventHandler(this.movieScanPath_TextUpdate);
            // 
            // tabOptions
            // 
            this.tabOptions.AutoScroll = true;
            this.tabOptions.Controls.Add(this.optionGroupOthers);
            this.tabOptions.Controls.Add(this.optionGroupMovies);
            this.tabOptions.Controls.Add(this.optionGroupSeries);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(5);
            this.tabOptions.Size = new System.Drawing.Size(706, 403);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // optionGroupOthers
            // 
            this.optionGroupOthers.Controls.Add(this.optionDropTarget);
            this.optionGroupOthers.Controls.Add(this.label_langUI);
            this.optionGroupOthers.Controls.Add(this.option_langUI);
            this.optionGroupOthers.Controls.Add(this.optionSysTray);
            this.optionGroupOthers.Controls.Add(this.optionStartMinimized);
            this.optionGroupOthers.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionGroupOthers.Location = new System.Drawing.Point(5, 221);
            this.optionGroupOthers.Name = "optionGroupOthers";
            this.optionGroupOthers.Size = new System.Drawing.Size(696, 128);
            this.optionGroupOthers.TabIndex = 3;
            this.optionGroupOthers.TabStop = false;
            this.optionGroupOthers.Text = "General Options";
            // 
            // optionDropTarget
            // 
            this.optionDropTarget.AutoSize = true;
            this.optionDropTarget.Location = new System.Drawing.Point(30, 42);
            this.optionDropTarget.Name = "optionDropTarget";
            this.optionDropTarget.Size = new System.Drawing.Size(173, 17);
            this.optionDropTarget.TabIndex = 17;
            this.optionDropTarget.Text = "Display dropTarget on Desktop";
            this.optionDropTarget.UseVisualStyleBackColor = true;
            this.optionDropTarget.CheckedChanged += new System.EventHandler(this.optionDropTarget_CheckedChanged);
            // 
            // label_langUI
            // 
            this.label_langUI.Location = new System.Drawing.Point(5, 86);
            this.label_langUI.Name = "label_langUI";
            this.label_langUI.Size = new System.Drawing.Size(130, 23);
            this.label_langUI.TabIndex = 16;
            this.label_langUI.Text = "UI Language";
            this.label_langUI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // option_langUI
            // 
            this.option_langUI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.option_langUI.FormattingEnabled = true;
            this.option_langUI.Location = new System.Drawing.Point(141, 88);
            this.option_langUI.Name = "option_langUI";
            this.option_langUI.Size = new System.Drawing.Size(229, 21);
            this.option_langUI.TabIndex = 2;
            // 
            // optionSysTray
            // 
            this.optionSysTray.AutoSize = true;
            this.optionSysTray.Location = new System.Drawing.Point(30, 65);
            this.optionSysTray.Name = "optionSysTray";
            this.optionSysTray.Size = new System.Drawing.Size(219, 17);
            this.optionSysTray.TabIndex = 1;
            this.optionSysTray.Text = "Display icon in system tray (next to clock)";
            this.optionSysTray.UseVisualStyleBackColor = true;
            this.optionSysTray.CheckedChanged += new System.EventHandler(this.optionSysTray_CheckedChanged);
            // 
            // optionStartMinimized
            // 
            this.optionStartMinimized.AutoSize = true;
            this.optionStartMinimized.Location = new System.Drawing.Point(30, 19);
            this.optionStartMinimized.Name = "optionStartMinimized";
            this.optionStartMinimized.Size = new System.Drawing.Size(150, 17);
            this.optionStartMinimized.TabIndex = 0;
            this.optionStartMinimized.Text = "Start application minimized";
            this.optionStartMinimized.UseVisualStyleBackColor = true;
            this.optionStartMinimized.CheckedChanged += new System.EventHandler(this.optionStartMinimized_CheckedChanged);
            // 
            // optionGroupMovies
            // 
            this.optionGroupMovies.AutoSize = true;
            this.optionGroupMovies.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.optionGroupMovies.Controls.Add(this.btnMovePath);
            this.optionGroupMovies.Controls.Add(this.option_movieTargetLocation);
            this.optionGroupMovies.Controls.Add(this.option_moveMovies);
            this.optionGroupMovies.Controls.Add(this.option_movieFormat);
            this.optionGroupMovies.Controls.Add(this.labelMovieOutpu);
            this.optionGroupMovies.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionGroupMovies.Location = new System.Drawing.Point(5, 137);
            this.optionGroupMovies.Name = "optionGroupMovies";
            this.optionGroupMovies.Size = new System.Drawing.Size(696, 84);
            this.optionGroupMovies.TabIndex = 2;
            this.optionGroupMovies.TabStop = false;
            this.optionGroupMovies.Text = "Movie Options";
            // 
            // btnMovePath
            // 
            this.btnMovePath.Location = new System.Drawing.Point(578, 42);
            this.btnMovePath.Name = "btnMovePath";
            this.btnMovePath.Size = new System.Drawing.Size(29, 23);
            this.btnMovePath.TabIndex = 20;
            this.btnMovePath.Text = "...";
            this.btnMovePath.UseVisualStyleBackColor = true;
            this.btnMovePath.Click += new System.EventHandler(this.btnMovePath_Click);
            // 
            // option_movieTargetLocation
            // 
            this.option_movieTargetLocation.Location = new System.Drawing.Point(300, 44);
            this.option_movieTargetLocation.Name = "option_movieTargetLocation";
            this.option_movieTargetLocation.Size = new System.Drawing.Size(272, 20);
            this.option_movieTargetLocation.TabIndex = 19;
            this.option_movieTargetLocation.TextChanged += new System.EventHandler(this.option_movieTargetLocation_TextChanged);
            // 
            // option_moveMovies
            // 
            this.option_moveMovies.AutoSize = true;
            this.option_moveMovies.Location = new System.Drawing.Point(142, 46);
            this.option_moveMovies.Name = "option_moveMovies";
            this.option_moveMovies.Size = new System.Drawing.Size(152, 17);
            this.option_moveMovies.TabIndex = 18;
            this.option_moveMovies.Text = "Move Movies to the folder:";
            this.option_moveMovies.UseVisualStyleBackColor = true;
            this.option_moveMovies.CheckedChanged += new System.EventHandler(this.option_moveMovies_CheckedChanged);
            // 
            // option_movieFormat
            // 
            this.option_movieFormat.AutoCompleteCustomSource.AddRange(new string[] {
            "<moviename> (<year><disk:,CD><disk><lang:,><lang>)"});
            this.option_movieFormat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.option_movieFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.option_movieFormat.ContextMenuStrip = this.contextProposals;
            this.option_movieFormat.Location = new System.Drawing.Point(142, 18);
            this.option_movieFormat.Name = "option_movieFormat";
            this.option_movieFormat.Size = new System.Drawing.Size(465, 20);
            this.option_movieFormat.TabIndex = 17;
            this.option_movieFormat.Text = "<moviename> (<year><disk:,CD><disk><lang:,><lang>)";
            this.option_movieFormat.Leave += new System.EventHandler(this.option_movieFormat_Leave);
            this.option_movieFormat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.option_movieFormat_MouseDown);
            // 
            // contextProposals
            // 
            this.contextProposals.Name = "contextProposals";
            this.contextProposals.Size = new System.Drawing.Size(61, 4);
            this.contextProposals.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextProposals_ItemClicked);
            this.contextProposals.Opening += new System.ComponentModel.CancelEventHandler(this.contextProposals_Opening);
            // 
            // labelMovieOutpu
            // 
            this.labelMovieOutpu.Location = new System.Drawing.Point(6, 16);
            this.labelMovieOutpu.Name = "labelMovieOutpu";
            this.labelMovieOutpu.Size = new System.Drawing.Size(130, 23);
            this.labelMovieOutpu.TabIndex = 15;
            this.labelMovieOutpu.Text = "Output Format:";
            this.labelMovieOutpu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // optionGroupSeries
            // 
            this.optionGroupSeries.AutoSize = true;
            this.optionGroupSeries.Controls.Add(this.optionSeriesParser);
            this.optionGroupSeries.Controls.Add(this.pictureBox1);
            this.optionGroupSeries.Controls.Add(this.labelTVSource);
            this.optionGroupSeries.Controls.Add(this.option_seriesFormat);
            this.optionGroupSeries.Controls.Add(this.labelTVOutput);
            this.optionGroupSeries.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionGroupSeries.Location = new System.Drawing.Point(5, 5);
            this.optionGroupSeries.Name = "optionGroupSeries";
            this.optionGroupSeries.Size = new System.Drawing.Size(696, 132);
            this.optionGroupSeries.TabIndex = 1;
            this.optionGroupSeries.TabStop = false;
            this.optionGroupSeries.Text = "TV Series Options";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MediaRenamer.Properties.Resources.EPW_Logo_168;
            this.pictureBox1.InitialImage = global::MediaRenamer.Properties.Resources.EPW_Logo_168;
            this.pictureBox1.Location = new System.Drawing.Point(143, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelTVSource
            // 
            this.labelTVSource.Location = new System.Drawing.Point(6, 39);
            this.labelTVSource.Name = "labelTVSource";
            this.labelTVSource.Size = new System.Drawing.Size(130, 23);
            this.labelTVSource.TabIndex = 14;
            this.labelTVSource.Text = "Online Datasource:";
            this.labelTVSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // option_seriesFormat
            // 
            this.option_seriesFormat.AutoCompleteCustomSource.AddRange(new string[] {
            "<series> - <season>x<episode2><title: - ><title>",
            "<series> - s<season2>e<episod2><title: - ><title>",
            "<series> <season>x<episode2><title: - ><title>",
            "<series> s<season2>e<episode2><title: - ><title>",
            "<season>x<episode2><title: - ><title>",
            "s<season2>e<episode2><title: - ><title>"});
            this.option_seriesFormat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.option_seriesFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.option_seriesFormat.ContextMenuStrip = this.contextProposals;
            this.option_seriesFormat.Location = new System.Drawing.Point(142, 16);
            this.option_seriesFormat.Name = "option_seriesFormat";
            this.option_seriesFormat.Size = new System.Drawing.Size(465, 20);
            this.option_seriesFormat.TabIndex = 13;
            this.option_seriesFormat.Text = "<series> - <season>x<episode2><title: - ><title>";
            this.option_seriesFormat.Leave += new System.EventHandler(this.option_seriesFormat_Leave);
            this.option_seriesFormat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.option_seriesFormat_MouseDown);
            // 
            // labelTVOutput
            // 
            this.labelTVOutput.Location = new System.Drawing.Point(6, 16);
            this.labelTVOutput.Name = "labelTVOutput";
            this.labelTVOutput.Size = new System.Drawing.Size(130, 23);
            this.labelTVOutput.TabIndex = 12;
            this.labelTVOutput.Text = "Output Format:";
            this.labelTVOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabWatch
            // 
            this.tabWatch.Location = new System.Drawing.Point(0, 0);
            this.tabWatch.Name = "tabWatch";
            this.tabWatch.Size = new System.Drawing.Size(200, 100);
            this.tabWatch.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label_watchType
            // 
            this.label_watchType.Location = new System.Drawing.Point(0, 0);
            this.label_watchType.Name = "label_watchType";
            this.label_watchType.Size = new System.Drawing.Size(100, 23);
            this.label_watchType.TabIndex = 0;
            // 
            // label_watchPath
            // 
            this.label_watchPath.Location = new System.Drawing.Point(0, 0);
            this.label_watchPath.Name = "label_watchPath";
            this.label_watchPath.Size = new System.Drawing.Size(100, 23);
            this.label_watchPath.TabIndex = 0;
            // 
            // addWatchType
            // 
            this.addWatchType.Location = new System.Drawing.Point(0, 0);
            this.addWatchType.Name = "addWatchType";
            this.addWatchType.Size = new System.Drawing.Size(121, 21);
            this.addWatchType.TabIndex = 0;
            // 
            // addWatchFolder
            // 
            this.addWatchFolder.Location = new System.Drawing.Point(0, 0);
            this.addWatchFolder.Name = "addWatchFolder";
            this.addWatchFolder.Size = new System.Drawing.Size(75, 23);
            this.addWatchFolder.TabIndex = 0;
            // 
            // addWatchPath
            // 
            this.addWatchPath.Location = new System.Drawing.Point(0, 0);
            this.addWatchPath.Name = "addWatchPath";
            this.addWatchPath.Size = new System.Drawing.Size(100, 20);
            this.addWatchPath.TabIndex = 0;
            // 
            // watchedFolders
            // 
            this.watchedFolders.Location = new System.Drawing.Point(0, 0);
            this.watchedFolders.Name = "watchedFolders";
            this.watchedFolders.Size = new System.Drawing.Size(120, 95);
            this.watchedFolders.TabIndex = 0;
            // 
            // runWatcherToolStripMenuItem
            // 
            this.runWatcherToolStripMenuItem.Name = "runWatcherToolStripMenuItem";
            this.runWatcherToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // stopWatcherToolStripMenuItem
            // 
            this.stopWatcherToolStripMenuItem.Name = "stopWatcherToolStripMenuItem";
            this.stopWatcherToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // deleteSelectedWatcherToolStripMenuItem
            // 
            this.deleteSelectedWatcherToolStripMenuItem.Name = "deleteSelectedWatcherToolStripMenuItem";
            this.deleteSelectedWatcherToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.sysTrayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MediaRenamer";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // sysTrayMenu
            // 
            this.sysTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysTrayOpen,
            this.displayDropTargetToolStripMenuItem,
            this.toolStripSeparator1,
            this.sysTrayExit});
            this.sysTrayMenu.Name = "sysTrayMenu";
            this.sysTrayMenu.Size = new System.Drawing.Size(176, 76);
            // 
            // sysTrayOpen
            // 
            this.sysTrayOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.sysTrayOpen.Name = "sysTrayOpen";
            this.sysTrayOpen.Size = new System.Drawing.Size(175, 22);
            this.sysTrayOpen.Text = "Show Application";
            this.sysTrayOpen.Click += new System.EventHandler(this.sysTrayOpen_Click);
            // 
            // displayDropTargetToolStripMenuItem
            // 
            this.displayDropTargetToolStripMenuItem.Name = "displayDropTargetToolStripMenuItem";
            this.displayDropTargetToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.displayDropTargetToolStripMenuItem.Text = "Display DropTarget";
            this.displayDropTargetToolStripMenuItem.Click += new System.EventHandler(this.displayDropTargetToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // sysTrayExit
            // 
            this.sysTrayExit.Name = "sysTrayExit";
            this.sysTrayExit.Size = new System.Drawing.Size(175, 22);
            this.sysTrayExit.Text = "Exit";
            this.sysTrayExit.Click += new System.EventHandler(this.sysTrayExit_Click);
            // 
            // btnAppAbout
            // 
            this.btnAppAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAppAbout.Location = new System.Drawing.Point(666, 0);
            this.btnAppAbout.Name = "btnAppAbout";
            this.btnAppAbout.Size = new System.Drawing.Size(47, 20);
            this.btnAppAbout.TabIndex = 4;
            this.btnAppAbout.Text = "About";
            this.btnAppAbout.UseVisualStyleBackColor = true;
            this.btnAppAbout.Click += new System.EventHandler(this.btnAppAbout_Click);
            // 
            // optionSeriesParser
            // 
            this.optionSeriesParser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optionSeriesParser.FormattingEnabled = true;
            this.optionSeriesParser.Location = new System.Drawing.Point(143, 43);
            this.optionSeriesParser.Name = "optionSeriesParser";
            this.optionSeriesParser.Size = new System.Drawing.Size(227, 21);
            this.optionSeriesParser.TabIndex = 17;
            this.optionSeriesParser.SelectedIndexChanged += new System.EventHandler(this.optionSeriesParser_SelectedIndexChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 429);
            this.Controls.Add(this.btnAppAbout);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(730, 465);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaRenamer";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.SizeChanged += new System.EventHandler(this.mainForm_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabSeries.ResumeLayout(false);
            this.contextRename.ResumeLayout(false);
            this.groupSeries.ResumeLayout(false);
            this.groupSeries.PerformLayout();
            this.tabMovies.ResumeLayout(false);
            this.groupMovies.ResumeLayout(false);
            this.groupMovies.PerformLayout();
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.optionGroupOthers.ResumeLayout(false);
            this.optionGroupOthers.PerformLayout();
            this.optionGroupMovies.ResumeLayout(false);
            this.optionGroupMovies.PerformLayout();
            this.optionGroupSeries.ResumeLayout(false);
            this.optionGroupSeries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.sysTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSeries;
        private System.Windows.Forms.TabPage tabMovies;
        private System.Windows.Forms.TabPage tabWatch;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox optionGroupSeries;
        private System.Windows.Forms.TextBox option_seriesFormat;
        private System.Windows.Forms.Label labelTVOutput;
        private System.Windows.Forms.ContextMenuStrip contextProposals;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTVSource;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ListBox watchedFolders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addWatchFolder;
        private System.Windows.Forms.TextBox addWatchPath;
        private System.Windows.Forms.Label label_watchType;
        private System.Windows.Forms.Label label_watchPath;
        private System.Windows.Forms.ComboBox addWatchType;
        private System.Windows.Forms.GroupBox groupMovies;
        private System.Windows.Forms.ComboBox movieScanPath;
        private System.Windows.Forms.ProgressBar scanMovieProgressbar;
        private System.Windows.Forms.Button btnMovieScan;
        private System.Windows.Forms.Label moviePathLabel;
        private System.Windows.Forms.GroupBox groupSeries;
        private System.Windows.Forms.ComboBox seriesScanPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeriesScan;
        private System.Windows.Forms.ProgressBar scanSeriesProgressbar;
        private System.Windows.Forms.ContextMenuStrip contextRename;
        private System.Windows.Forms.ToolStripMenuItem contextOptionRename;
        private System.Windows.Forms.GroupBox optionGroupMovies;
        private System.Windows.Forms.TextBox option_movieFormat;
        private System.Windows.Forms.Label labelMovieOutpu;
        private System.Windows.Forms.GroupBox optionGroupOthers;
        private System.Windows.Forms.CheckBox optionStartMinimized;
        private System.Windows.Forms.CheckBox optionSysTray;
        private System.Windows.Forms.ContextMenuStrip sysTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem sysTrayExit;
        private System.Windows.Forms.ToolStripMenuItem sysTrayOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label_langUI;
        private System.Windows.Forms.ComboBox option_langUI;
        private System.Windows.Forms.ListView scanSeriesList;
        private System.Windows.Forms.ColumnHeader headFilename;
        private System.Windows.Forms.ColumnHeader headSeries;
        private System.Windows.Forms.ColumnHeader headSeason;
        private System.Windows.Forms.ColumnHeader headEpisode;
        private System.Windows.Forms.ColumnHeader headTitle;
        private System.Windows.Forms.ColumnHeader headNewname;
        private System.Windows.Forms.ListView scanMovieList;
        private System.Windows.Forms.ColumnHeader headMovie;
        private System.Windows.Forms.ColumnHeader headYear;
        private System.Windows.Forms.ColumnHeader headMoviefile;
        private System.Windows.Forms.ColumnHeader headNewfile;
        private System.Windows.Forms.ToolStripMenuItem runWatcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopWatcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedWatcherToolStripMenuItem;
        private System.Windows.Forms.Button tvRenameEpisodes;
        private System.Windows.Forms.Button tvSelNone;
        private System.Windows.Forms.Button tvSelAll;
        private System.Windows.Forms.Button movieRename;
        private System.Windows.Forms.Button movieSelNone;
        private System.Windows.Forms.Button movieSelAll;
        private System.Windows.Forms.Button btnSeriesBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnPathMovies;
        private System.Windows.Forms.ToolStripMenuItem displayDropTargetToolStripMenuItem;
        private System.Windows.Forms.CheckBox optionDropTarget;
        private System.Windows.Forms.CheckBox option_moveMovies;
        private System.Windows.Forms.Button btnMovePath;
        private System.Windows.Forms.TextBox option_movieTargetLocation;
        private System.Windows.Forms.Button btnAppAbout;
        private System.Windows.Forms.ComboBox optionSeriesParser;
    }
}

