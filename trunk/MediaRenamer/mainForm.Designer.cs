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
            this.btnMoviesBrowse = new System.Windows.Forms.Button();
            this.scanMovieProgressbar = new System.Windows.Forms.ProgressBar();
            this.btnMovieScan = new System.Windows.Forms.Button();
            this.moviePathLabel = new System.Windows.Forms.Label();
            this.movieScanPath = new System.Windows.Forms.ComboBox();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.optionGroupOthers = new System.Windows.Forms.GroupBox();
            this.optionDropTarget = new System.Windows.Forms.CheckBox();
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
            this.optionSeriesParser = new System.Windows.Forms.ComboBox();
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
            this.sysTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sysTrayOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.displayDropTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sysTrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAppAbout = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
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
            this.sysTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.AccessibleDescription = null;
            this.tabControl.AccessibleName = null;
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.BackgroundImage = null;
            this.tabControl.Controls.Add(this.tabSeries);
            this.tabControl.Controls.Add(this.tabMovies);
            this.tabControl.Controls.Add(this.tabOptions);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.toolTip.SetToolTip(this.tabControl, resources.GetString("tabControl.ToolTip"));
            // 
            // tabSeries
            // 
            this.tabSeries.AccessibleDescription = null;
            this.tabSeries.AccessibleName = null;
            resources.ApplyResources(this.tabSeries, "tabSeries");
            this.tabSeries.BackgroundImage = null;
            this.tabSeries.Controls.Add(this.tvRenameEpisodes);
            this.tabSeries.Controls.Add(this.tvSelNone);
            this.tabSeries.Controls.Add(this.tvSelAll);
            this.tabSeries.Controls.Add(this.scanSeriesList);
            this.tabSeries.Controls.Add(this.groupSeries);
            this.tabSeries.Font = null;
            this.tabSeries.Name = "tabSeries";
            this.toolTip.SetToolTip(this.tabSeries, resources.GetString("tabSeries.ToolTip"));
            this.tabSeries.UseVisualStyleBackColor = true;
            // 
            // tvRenameEpisodes
            // 
            this.tvRenameEpisodes.AccessibleDescription = null;
            this.tvRenameEpisodes.AccessibleName = null;
            resources.ApplyResources(this.tvRenameEpisodes, "tvRenameEpisodes");
            this.tvRenameEpisodes.BackgroundImage = null;
            this.tvRenameEpisodes.Font = null;
            this.tvRenameEpisodes.Name = "tvRenameEpisodes";
            this.toolTip.SetToolTip(this.tvRenameEpisodes, resources.GetString("tvRenameEpisodes.ToolTip"));
            this.tvRenameEpisodes.UseVisualStyleBackColor = true;
            this.tvRenameEpisodes.Click += new System.EventHandler(this.tvRenameEpisodes_Click);
            // 
            // tvSelNone
            // 
            this.tvSelNone.AccessibleDescription = null;
            this.tvSelNone.AccessibleName = null;
            resources.ApplyResources(this.tvSelNone, "tvSelNone");
            this.tvSelNone.BackgroundImage = null;
            this.tvSelNone.Font = null;
            this.tvSelNone.Name = "tvSelNone";
            this.toolTip.SetToolTip(this.tvSelNone, resources.GetString("tvSelNone.ToolTip"));
            this.tvSelNone.UseVisualStyleBackColor = true;
            this.tvSelNone.Click += new System.EventHandler(this.tvSelNone_Click);
            // 
            // tvSelAll
            // 
            this.tvSelAll.AccessibleDescription = null;
            this.tvSelAll.AccessibleName = null;
            resources.ApplyResources(this.tvSelAll, "tvSelAll");
            this.tvSelAll.BackgroundImage = null;
            this.tvSelAll.Font = null;
            this.tvSelAll.Name = "tvSelAll";
            this.toolTip.SetToolTip(this.tvSelAll, resources.GetString("tvSelAll.ToolTip"));
            this.tvSelAll.UseVisualStyleBackColor = true;
            this.tvSelAll.Click += new System.EventHandler(this.tvSelAll_Click);
            // 
            // scanSeriesList
            // 
            this.scanSeriesList.AccessibleDescription = null;
            this.scanSeriesList.AccessibleName = null;
            resources.ApplyResources(this.scanSeriesList, "scanSeriesList");
            this.scanSeriesList.BackgroundImage = null;
            this.scanSeriesList.CheckBoxes = true;
            this.scanSeriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headSeries,
            this.headSeason,
            this.headEpisode,
            this.headTitle,
            this.headFilename,
            this.headNewname});
            this.scanSeriesList.ContextMenuStrip = this.contextRename;
            this.scanSeriesList.Font = null;
            this.scanSeriesList.FullRowSelect = true;
            this.scanSeriesList.Name = "scanSeriesList";
            this.scanSeriesList.ShowGroups = false;
            this.toolTip.SetToolTip(this.scanSeriesList, resources.GetString("scanSeriesList.ToolTip"));
            this.scanSeriesList.UseCompatibleStateImageBehavior = false;
            this.scanSeriesList.View = System.Windows.Forms.View.Details;
            // 
            // headSeries
            // 
            resources.ApplyResources(this.headSeries, "headSeries");
            // 
            // headSeason
            // 
            resources.ApplyResources(this.headSeason, "headSeason");
            // 
            // headEpisode
            // 
            resources.ApplyResources(this.headEpisode, "headEpisode");
            // 
            // headTitle
            // 
            resources.ApplyResources(this.headTitle, "headTitle");
            // 
            // headFilename
            // 
            resources.ApplyResources(this.headFilename, "headFilename");
            // 
            // headNewname
            // 
            resources.ApplyResources(this.headNewname, "headNewname");
            // 
            // contextRename
            // 
            this.contextRename.AccessibleDescription = null;
            this.contextRename.AccessibleName = null;
            resources.ApplyResources(this.contextRename, "contextRename");
            this.contextRename.BackgroundImage = null;
            this.contextRename.Font = null;
            this.contextRename.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextOptionRename});
            this.contextRename.Name = "contextRename";
            this.toolTip.SetToolTip(this.contextRename, resources.GetString("contextRename.ToolTip"));
            this.contextRename.Opening += new System.ComponentModel.CancelEventHandler(this.contextRename_Opening);
            // 
            // contextOptionRename
            // 
            this.contextOptionRename.AccessibleDescription = null;
            this.contextOptionRename.AccessibleName = null;
            resources.ApplyResources(this.contextOptionRename, "contextOptionRename");
            this.contextOptionRename.BackgroundImage = null;
            this.contextOptionRename.Name = "contextOptionRename";
            this.contextOptionRename.ShortcutKeyDisplayString = null;
            this.contextOptionRename.Click += new System.EventHandler(this.contextOptionRename_Click);
            // 
            // groupSeries
            // 
            this.groupSeries.AccessibleDescription = null;
            this.groupSeries.AccessibleName = null;
            resources.ApplyResources(this.groupSeries, "groupSeries");
            this.groupSeries.BackgroundImage = null;
            this.groupSeries.Controls.Add(this.btnSeriesBrowse);
            this.groupSeries.Controls.Add(this.scanSeriesProgressbar);
            this.groupSeries.Controls.Add(this.btnSeriesScan);
            this.groupSeries.Controls.Add(this.label1);
            this.groupSeries.Controls.Add(this.seriesScanPath);
            this.groupSeries.Font = null;
            this.groupSeries.Name = "groupSeries";
            this.groupSeries.TabStop = false;
            this.toolTip.SetToolTip(this.groupSeries, resources.GetString("groupSeries.ToolTip"));
            // 
            // btnSeriesBrowse
            // 
            this.btnSeriesBrowse.AccessibleDescription = null;
            this.btnSeriesBrowse.AccessibleName = null;
            resources.ApplyResources(this.btnSeriesBrowse, "btnSeriesBrowse");
            this.btnSeriesBrowse.BackgroundImage = null;
            this.btnSeriesBrowse.Font = null;
            this.btnSeriesBrowse.Name = "btnSeriesBrowse";
            this.toolTip.SetToolTip(this.btnSeriesBrowse, resources.GetString("btnSeriesBrowse.ToolTip"));
            this.btnSeriesBrowse.UseVisualStyleBackColor = true;
            this.btnSeriesBrowse.Click += new System.EventHandler(this.btnSeriesBrowse_Click);
            // 
            // scanSeriesProgressbar
            // 
            this.scanSeriesProgressbar.AccessibleDescription = null;
            this.scanSeriesProgressbar.AccessibleName = null;
            resources.ApplyResources(this.scanSeriesProgressbar, "scanSeriesProgressbar");
            this.scanSeriesProgressbar.BackgroundImage = null;
            this.scanSeriesProgressbar.Font = null;
            this.scanSeriesProgressbar.Maximum = 0;
            this.scanSeriesProgressbar.Name = "scanSeriesProgressbar";
            this.toolTip.SetToolTip(this.scanSeriesProgressbar, resources.GetString("scanSeriesProgressbar.ToolTip"));
            // 
            // btnSeriesScan
            // 
            this.btnSeriesScan.AccessibleDescription = null;
            this.btnSeriesScan.AccessibleName = null;
            resources.ApplyResources(this.btnSeriesScan, "btnSeriesScan");
            this.btnSeriesScan.BackgroundImage = null;
            this.btnSeriesScan.Font = null;
            this.btnSeriesScan.Name = "btnSeriesScan";
            this.toolTip.SetToolTip(this.btnSeriesScan, resources.GetString("btnSeriesScan.ToolTip"));
            this.btnSeriesScan.UseVisualStyleBackColor = true;
            this.btnSeriesScan.Click += new System.EventHandler(this.btnSeriesScan_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // seriesScanPath
            // 
            this.seriesScanPath.AccessibleDescription = null;
            this.seriesScanPath.AccessibleName = null;
            resources.ApplyResources(this.seriesScanPath, "seriesScanPath");
            this.seriesScanPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.seriesScanPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.seriesScanPath.BackgroundImage = null;
            this.seriesScanPath.Font = null;
            this.seriesScanPath.FormattingEnabled = true;
            this.seriesScanPath.Name = "seriesScanPath";
            this.toolTip.SetToolTip(this.seriesScanPath, resources.GetString("seriesScanPath.ToolTip"));
            this.seriesScanPath.SelectedIndexChanged += new System.EventHandler(this.seriesScanPath_TextUpdate);
            this.seriesScanPath.Leave += new System.EventHandler(this.seriesScanPath_Leave);
            this.seriesScanPath.TextChanged += new System.EventHandler(this.seriesScanPath_TextChanged);
            // 
            // tabMovies
            // 
            this.tabMovies.AccessibleDescription = null;
            this.tabMovies.AccessibleName = null;
            resources.ApplyResources(this.tabMovies, "tabMovies");
            this.tabMovies.BackgroundImage = null;
            this.tabMovies.Controls.Add(this.movieRename);
            this.tabMovies.Controls.Add(this.movieSelNone);
            this.tabMovies.Controls.Add(this.movieSelAll);
            this.tabMovies.Controls.Add(this.scanMovieList);
            this.tabMovies.Controls.Add(this.groupMovies);
            this.tabMovies.Font = null;
            this.tabMovies.Name = "tabMovies";
            this.toolTip.SetToolTip(this.tabMovies, resources.GetString("tabMovies.ToolTip"));
            this.tabMovies.UseVisualStyleBackColor = true;
            // 
            // movieRename
            // 
            this.movieRename.AccessibleDescription = null;
            this.movieRename.AccessibleName = null;
            resources.ApplyResources(this.movieRename, "movieRename");
            this.movieRename.BackgroundImage = null;
            this.movieRename.Font = null;
            this.movieRename.Name = "movieRename";
            this.toolTip.SetToolTip(this.movieRename, resources.GetString("movieRename.ToolTip"));
            this.movieRename.UseVisualStyleBackColor = true;
            this.movieRename.Click += new System.EventHandler(this.movieRename_Click);
            // 
            // movieSelNone
            // 
            this.movieSelNone.AccessibleDescription = null;
            this.movieSelNone.AccessibleName = null;
            resources.ApplyResources(this.movieSelNone, "movieSelNone");
            this.movieSelNone.BackgroundImage = null;
            this.movieSelNone.Font = null;
            this.movieSelNone.Name = "movieSelNone";
            this.toolTip.SetToolTip(this.movieSelNone, resources.GetString("movieSelNone.ToolTip"));
            this.movieSelNone.UseVisualStyleBackColor = true;
            this.movieSelNone.Click += new System.EventHandler(this.movieSelNone_Click);
            // 
            // movieSelAll
            // 
            this.movieSelAll.AccessibleDescription = null;
            this.movieSelAll.AccessibleName = null;
            resources.ApplyResources(this.movieSelAll, "movieSelAll");
            this.movieSelAll.BackgroundImage = null;
            this.movieSelAll.Font = null;
            this.movieSelAll.Name = "movieSelAll";
            this.toolTip.SetToolTip(this.movieSelAll, resources.GetString("movieSelAll.ToolTip"));
            this.movieSelAll.UseVisualStyleBackColor = true;
            this.movieSelAll.Click += new System.EventHandler(this.movieSelAll_Click);
            // 
            // scanMovieList
            // 
            this.scanMovieList.AccessibleDescription = null;
            this.scanMovieList.AccessibleName = null;
            resources.ApplyResources(this.scanMovieList, "scanMovieList");
            this.scanMovieList.BackgroundImage = null;
            this.scanMovieList.CheckBoxes = true;
            this.scanMovieList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headMovie,
            this.headYear,
            this.headMoviefile,
            this.headNewfile});
            this.scanMovieList.ContextMenuStrip = this.contextRename;
            this.scanMovieList.Font = null;
            this.scanMovieList.FullRowSelect = true;
            this.scanMovieList.Name = "scanMovieList";
            this.scanMovieList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.toolTip.SetToolTip(this.scanMovieList, resources.GetString("scanMovieList.ToolTip"));
            this.scanMovieList.UseCompatibleStateImageBehavior = false;
            this.scanMovieList.View = System.Windows.Forms.View.Details;
            // 
            // headMovie
            // 
            resources.ApplyResources(this.headMovie, "headMovie");
            // 
            // headYear
            // 
            resources.ApplyResources(this.headYear, "headYear");
            // 
            // headMoviefile
            // 
            resources.ApplyResources(this.headMoviefile, "headMoviefile");
            // 
            // headNewfile
            // 
            resources.ApplyResources(this.headNewfile, "headNewfile");
            // 
            // groupMovies
            // 
            this.groupMovies.AccessibleDescription = null;
            this.groupMovies.AccessibleName = null;
            resources.ApplyResources(this.groupMovies, "groupMovies");
            this.groupMovies.BackgroundImage = null;
            this.groupMovies.Controls.Add(this.btnMoviesBrowse);
            this.groupMovies.Controls.Add(this.scanMovieProgressbar);
            this.groupMovies.Controls.Add(this.btnMovieScan);
            this.groupMovies.Controls.Add(this.moviePathLabel);
            this.groupMovies.Controls.Add(this.movieScanPath);
            this.groupMovies.Font = null;
            this.groupMovies.Name = "groupMovies";
            this.groupMovies.TabStop = false;
            this.toolTip.SetToolTip(this.groupMovies, resources.GetString("groupMovies.ToolTip"));
            // 
            // btnMoviesBrowse
            // 
            this.btnMoviesBrowse.AccessibleDescription = null;
            this.btnMoviesBrowse.AccessibleName = null;
            resources.ApplyResources(this.btnMoviesBrowse, "btnMoviesBrowse");
            this.btnMoviesBrowse.BackgroundImage = null;
            this.btnMoviesBrowse.Font = null;
            this.btnMoviesBrowse.Name = "btnMoviesBrowse";
            this.toolTip.SetToolTip(this.btnMoviesBrowse, resources.GetString("btnMoviesBrowse.ToolTip"));
            this.btnMoviesBrowse.UseVisualStyleBackColor = true;
            this.btnMoviesBrowse.Click += new System.EventHandler(this.btnPathMovies_Click);
            // 
            // scanMovieProgressbar
            // 
            this.scanMovieProgressbar.AccessibleDescription = null;
            this.scanMovieProgressbar.AccessibleName = null;
            resources.ApplyResources(this.scanMovieProgressbar, "scanMovieProgressbar");
            this.scanMovieProgressbar.BackgroundImage = null;
            this.scanMovieProgressbar.Font = null;
            this.scanMovieProgressbar.Maximum = 0;
            this.scanMovieProgressbar.Name = "scanMovieProgressbar";
            this.toolTip.SetToolTip(this.scanMovieProgressbar, resources.GetString("scanMovieProgressbar.ToolTip"));
            // 
            // btnMovieScan
            // 
            this.btnMovieScan.AccessibleDescription = null;
            this.btnMovieScan.AccessibleName = null;
            resources.ApplyResources(this.btnMovieScan, "btnMovieScan");
            this.btnMovieScan.BackgroundImage = null;
            this.btnMovieScan.Font = null;
            this.btnMovieScan.Name = "btnMovieScan";
            this.toolTip.SetToolTip(this.btnMovieScan, resources.GetString("btnMovieScan.ToolTip"));
            this.btnMovieScan.UseVisualStyleBackColor = true;
            this.btnMovieScan.Click += new System.EventHandler(this.btnMovieScan_Click);
            // 
            // moviePathLabel
            // 
            this.moviePathLabel.AccessibleDescription = null;
            this.moviePathLabel.AccessibleName = null;
            resources.ApplyResources(this.moviePathLabel, "moviePathLabel");
            this.moviePathLabel.Font = null;
            this.moviePathLabel.Name = "moviePathLabel";
            this.toolTip.SetToolTip(this.moviePathLabel, resources.GetString("moviePathLabel.ToolTip"));
            // 
            // movieScanPath
            // 
            this.movieScanPath.AccessibleDescription = null;
            this.movieScanPath.AccessibleName = null;
            resources.ApplyResources(this.movieScanPath, "movieScanPath");
            this.movieScanPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.movieScanPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.movieScanPath.BackgroundImage = null;
            this.movieScanPath.Font = null;
            this.movieScanPath.FormattingEnabled = true;
            this.movieScanPath.Name = "movieScanPath";
            this.toolTip.SetToolTip(this.movieScanPath, resources.GetString("movieScanPath.ToolTip"));
            this.movieScanPath.SelectedIndexChanged += new System.EventHandler(this.movieScanPath_TextUpdate);
            this.movieScanPath.Leave += new System.EventHandler(this.movieScanPath_Leave);
            this.movieScanPath.TextUpdate += new System.EventHandler(this.movieScanPath_TextUpdate);
            this.movieScanPath.TextChanged += new System.EventHandler(this.movieScanPath_TextUpdate);
            // 
            // tabOptions
            // 
            this.tabOptions.AccessibleDescription = null;
            this.tabOptions.AccessibleName = null;
            resources.ApplyResources(this.tabOptions, "tabOptions");
            this.tabOptions.BackgroundImage = null;
            this.tabOptions.Controls.Add(this.optionGroupOthers);
            this.tabOptions.Controls.Add(this.optionGroupMovies);
            this.tabOptions.Controls.Add(this.optionGroupSeries);
            this.tabOptions.Font = null;
            this.tabOptions.Name = "tabOptions";
            this.toolTip.SetToolTip(this.tabOptions, resources.GetString("tabOptions.ToolTip"));
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // optionGroupOthers
            // 
            this.optionGroupOthers.AccessibleDescription = null;
            this.optionGroupOthers.AccessibleName = null;
            resources.ApplyResources(this.optionGroupOthers, "optionGroupOthers");
            this.optionGroupOthers.BackgroundImage = null;
            this.optionGroupOthers.Controls.Add(this.optionDropTarget);
            this.optionGroupOthers.Controls.Add(this.optionSysTray);
            this.optionGroupOthers.Controls.Add(this.optionStartMinimized);
            this.optionGroupOthers.Font = null;
            this.optionGroupOthers.Name = "optionGroupOthers";
            this.optionGroupOthers.TabStop = false;
            this.toolTip.SetToolTip(this.optionGroupOthers, resources.GetString("optionGroupOthers.ToolTip"));
            // 
            // optionDropTarget
            // 
            this.optionDropTarget.AccessibleDescription = null;
            this.optionDropTarget.AccessibleName = null;
            resources.ApplyResources(this.optionDropTarget, "optionDropTarget");
            this.optionDropTarget.BackgroundImage = null;
            this.optionDropTarget.Font = null;
            this.optionDropTarget.Name = "optionDropTarget";
            this.toolTip.SetToolTip(this.optionDropTarget, resources.GetString("optionDropTarget.ToolTip"));
            this.optionDropTarget.UseVisualStyleBackColor = true;
            this.optionDropTarget.CheckedChanged += new System.EventHandler(this.optionDropTarget_CheckedChanged);
            // 
            // optionSysTray
            // 
            this.optionSysTray.AccessibleDescription = null;
            this.optionSysTray.AccessibleName = null;
            resources.ApplyResources(this.optionSysTray, "optionSysTray");
            this.optionSysTray.BackgroundImage = null;
            this.optionSysTray.Font = null;
            this.optionSysTray.Name = "optionSysTray";
            this.toolTip.SetToolTip(this.optionSysTray, resources.GetString("optionSysTray.ToolTip"));
            this.optionSysTray.UseVisualStyleBackColor = true;
            this.optionSysTray.CheckedChanged += new System.EventHandler(this.optionSysTray_CheckedChanged);
            // 
            // optionStartMinimized
            // 
            this.optionStartMinimized.AccessibleDescription = null;
            this.optionStartMinimized.AccessibleName = null;
            resources.ApplyResources(this.optionStartMinimized, "optionStartMinimized");
            this.optionStartMinimized.BackgroundImage = null;
            this.optionStartMinimized.Font = null;
            this.optionStartMinimized.Name = "optionStartMinimized";
            this.toolTip.SetToolTip(this.optionStartMinimized, resources.GetString("optionStartMinimized.ToolTip"));
            this.optionStartMinimized.UseVisualStyleBackColor = true;
            this.optionStartMinimized.CheckedChanged += new System.EventHandler(this.optionStartMinimized_CheckedChanged);
            // 
            // optionGroupMovies
            // 
            this.optionGroupMovies.AccessibleDescription = null;
            this.optionGroupMovies.AccessibleName = null;
            resources.ApplyResources(this.optionGroupMovies, "optionGroupMovies");
            this.optionGroupMovies.BackgroundImage = null;
            this.optionGroupMovies.Controls.Add(this.btnMovePath);
            this.optionGroupMovies.Controls.Add(this.option_movieTargetLocation);
            this.optionGroupMovies.Controls.Add(this.option_moveMovies);
            this.optionGroupMovies.Controls.Add(this.option_movieFormat);
            this.optionGroupMovies.Controls.Add(this.labelMovieOutpu);
            this.optionGroupMovies.Font = null;
            this.optionGroupMovies.Name = "optionGroupMovies";
            this.optionGroupMovies.TabStop = false;
            this.toolTip.SetToolTip(this.optionGroupMovies, resources.GetString("optionGroupMovies.ToolTip"));
            // 
            // btnMovePath
            // 
            this.btnMovePath.AccessibleDescription = null;
            this.btnMovePath.AccessibleName = null;
            resources.ApplyResources(this.btnMovePath, "btnMovePath");
            this.btnMovePath.BackgroundImage = null;
            this.btnMovePath.Font = null;
            this.btnMovePath.Name = "btnMovePath";
            this.toolTip.SetToolTip(this.btnMovePath, resources.GetString("btnMovePath.ToolTip"));
            this.btnMovePath.UseVisualStyleBackColor = true;
            this.btnMovePath.Click += new System.EventHandler(this.btnMovePath_Click);
            // 
            // option_movieTargetLocation
            // 
            this.option_movieTargetLocation.AccessibleDescription = null;
            this.option_movieTargetLocation.AccessibleName = null;
            resources.ApplyResources(this.option_movieTargetLocation, "option_movieTargetLocation");
            this.option_movieTargetLocation.BackgroundImage = null;
            this.option_movieTargetLocation.Font = null;
            this.option_movieTargetLocation.Name = "option_movieTargetLocation";
            this.toolTip.SetToolTip(this.option_movieTargetLocation, resources.GetString("option_movieTargetLocation.ToolTip"));
            this.option_movieTargetLocation.TextChanged += new System.EventHandler(this.option_movieTargetLocation_TextChanged);
            // 
            // option_moveMovies
            // 
            this.option_moveMovies.AccessibleDescription = null;
            this.option_moveMovies.AccessibleName = null;
            resources.ApplyResources(this.option_moveMovies, "option_moveMovies");
            this.option_moveMovies.BackgroundImage = null;
            this.option_moveMovies.Font = null;
            this.option_moveMovies.Name = "option_moveMovies";
            this.toolTip.SetToolTip(this.option_moveMovies, resources.GetString("option_moveMovies.ToolTip"));
            this.option_moveMovies.UseVisualStyleBackColor = true;
            this.option_moveMovies.CheckedChanged += new System.EventHandler(this.option_moveMovies_CheckedChanged);
            // 
            // option_movieFormat
            // 
            this.option_movieFormat.AccessibleDescription = null;
            this.option_movieFormat.AccessibleName = null;
            resources.ApplyResources(this.option_movieFormat, "option_movieFormat");
            this.option_movieFormat.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("option_movieFormat.AutoCompleteCustomSource")});
            this.option_movieFormat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.option_movieFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.option_movieFormat.BackgroundImage = null;
            this.option_movieFormat.ContextMenuStrip = this.contextProposals;
            this.option_movieFormat.Font = null;
            this.option_movieFormat.Name = "option_movieFormat";
            this.toolTip.SetToolTip(this.option_movieFormat, resources.GetString("option_movieFormat.ToolTip"));
            this.option_movieFormat.Leave += new System.EventHandler(this.option_movieFormat_Leave);
            this.option_movieFormat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.option_movieFormat_MouseDown);
            // 
            // contextProposals
            // 
            this.contextProposals.AccessibleDescription = null;
            this.contextProposals.AccessibleName = null;
            resources.ApplyResources(this.contextProposals, "contextProposals");
            this.contextProposals.BackgroundImage = null;
            this.contextProposals.Font = null;
            this.contextProposals.Name = "contextProposals";
            this.toolTip.SetToolTip(this.contextProposals, resources.GetString("contextProposals.ToolTip"));
            this.contextProposals.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextProposals_ItemClicked);
            this.contextProposals.Opening += new System.ComponentModel.CancelEventHandler(this.contextProposals_Opening);
            // 
            // labelMovieOutpu
            // 
            this.labelMovieOutpu.AccessibleDescription = null;
            this.labelMovieOutpu.AccessibleName = null;
            resources.ApplyResources(this.labelMovieOutpu, "labelMovieOutpu");
            this.labelMovieOutpu.Font = null;
            this.labelMovieOutpu.Name = "labelMovieOutpu";
            this.toolTip.SetToolTip(this.labelMovieOutpu, resources.GetString("labelMovieOutpu.ToolTip"));
            // 
            // optionGroupSeries
            // 
            this.optionGroupSeries.AccessibleDescription = null;
            this.optionGroupSeries.AccessibleName = null;
            resources.ApplyResources(this.optionGroupSeries, "optionGroupSeries");
            this.optionGroupSeries.BackgroundImage = null;
            this.optionGroupSeries.Controls.Add(this.optionSeriesParser);
            this.optionGroupSeries.Controls.Add(this.labelTVSource);
            this.optionGroupSeries.Controls.Add(this.option_seriesFormat);
            this.optionGroupSeries.Controls.Add(this.labelTVOutput);
            this.optionGroupSeries.Font = null;
            this.optionGroupSeries.Name = "optionGroupSeries";
            this.optionGroupSeries.TabStop = false;
            this.toolTip.SetToolTip(this.optionGroupSeries, resources.GetString("optionGroupSeries.ToolTip"));
            // 
            // optionSeriesParser
            // 
            this.optionSeriesParser.AccessibleDescription = null;
            this.optionSeriesParser.AccessibleName = null;
            resources.ApplyResources(this.optionSeriesParser, "optionSeriesParser");
            this.optionSeriesParser.BackgroundImage = null;
            this.optionSeriesParser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optionSeriesParser.Font = null;
            this.optionSeriesParser.FormattingEnabled = true;
            this.optionSeriesParser.Name = "optionSeriesParser";
            this.toolTip.SetToolTip(this.optionSeriesParser, resources.GetString("optionSeriesParser.ToolTip"));
            this.optionSeriesParser.SelectedIndexChanged += new System.EventHandler(this.optionSeriesParser_SelectedIndexChanged);
            // 
            // labelTVSource
            // 
            this.labelTVSource.AccessibleDescription = null;
            this.labelTVSource.AccessibleName = null;
            resources.ApplyResources(this.labelTVSource, "labelTVSource");
            this.labelTVSource.Font = null;
            this.labelTVSource.Name = "labelTVSource";
            this.toolTip.SetToolTip(this.labelTVSource, resources.GetString("labelTVSource.ToolTip"));
            // 
            // option_seriesFormat
            // 
            this.option_seriesFormat.AccessibleDescription = null;
            this.option_seriesFormat.AccessibleName = null;
            resources.ApplyResources(this.option_seriesFormat, "option_seriesFormat");
            this.option_seriesFormat.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("option_seriesFormat.AutoCompleteCustomSource"),
            resources.GetString("option_seriesFormat.AutoCompleteCustomSource1"),
            resources.GetString("option_seriesFormat.AutoCompleteCustomSource2"),
            resources.GetString("option_seriesFormat.AutoCompleteCustomSource3"),
            resources.GetString("option_seriesFormat.AutoCompleteCustomSource4"),
            resources.GetString("option_seriesFormat.AutoCompleteCustomSource5")});
            this.option_seriesFormat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.option_seriesFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.option_seriesFormat.BackgroundImage = null;
            this.option_seriesFormat.ContextMenuStrip = this.contextProposals;
            this.option_seriesFormat.Font = null;
            this.option_seriesFormat.Name = "option_seriesFormat";
            this.toolTip.SetToolTip(this.option_seriesFormat, resources.GetString("option_seriesFormat.ToolTip"));
            this.option_seriesFormat.Leave += new System.EventHandler(this.option_seriesFormat_Leave);
            this.option_seriesFormat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.option_seriesFormat_MouseDown);
            // 
            // labelTVOutput
            // 
            this.labelTVOutput.AccessibleDescription = null;
            this.labelTVOutput.AccessibleName = null;
            resources.ApplyResources(this.labelTVOutput, "labelTVOutput");
            this.labelTVOutput.Font = null;
            this.labelTVOutput.Name = "labelTVOutput";
            this.toolTip.SetToolTip(this.labelTVOutput, resources.GetString("labelTVOutput.ToolTip"));
            // 
            // tabWatch
            // 
            this.tabWatch.AccessibleDescription = null;
            this.tabWatch.AccessibleName = null;
            resources.ApplyResources(this.tabWatch, "tabWatch");
            this.tabWatch.BackgroundImage = null;
            this.tabWatch.Font = null;
            this.tabWatch.Name = "tabWatch";
            this.toolTip.SetToolTip(this.tabWatch, resources.GetString("tabWatch.ToolTip"));
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // label_watchType
            // 
            this.label_watchType.AccessibleDescription = null;
            this.label_watchType.AccessibleName = null;
            resources.ApplyResources(this.label_watchType, "label_watchType");
            this.label_watchType.Font = null;
            this.label_watchType.Name = "label_watchType";
            this.toolTip.SetToolTip(this.label_watchType, resources.GetString("label_watchType.ToolTip"));
            // 
            // label_watchPath
            // 
            this.label_watchPath.AccessibleDescription = null;
            this.label_watchPath.AccessibleName = null;
            resources.ApplyResources(this.label_watchPath, "label_watchPath");
            this.label_watchPath.Font = null;
            this.label_watchPath.Name = "label_watchPath";
            this.toolTip.SetToolTip(this.label_watchPath, resources.GetString("label_watchPath.ToolTip"));
            // 
            // addWatchType
            // 
            this.addWatchType.AccessibleDescription = null;
            this.addWatchType.AccessibleName = null;
            resources.ApplyResources(this.addWatchType, "addWatchType");
            this.addWatchType.BackgroundImage = null;
            this.addWatchType.Font = null;
            this.addWatchType.Name = "addWatchType";
            this.toolTip.SetToolTip(this.addWatchType, resources.GetString("addWatchType.ToolTip"));
            // 
            // addWatchFolder
            // 
            this.addWatchFolder.AccessibleDescription = null;
            this.addWatchFolder.AccessibleName = null;
            resources.ApplyResources(this.addWatchFolder, "addWatchFolder");
            this.addWatchFolder.BackgroundImage = null;
            this.addWatchFolder.Font = null;
            this.addWatchFolder.Name = "addWatchFolder";
            this.toolTip.SetToolTip(this.addWatchFolder, resources.GetString("addWatchFolder.ToolTip"));
            // 
            // addWatchPath
            // 
            this.addWatchPath.AccessibleDescription = null;
            this.addWatchPath.AccessibleName = null;
            resources.ApplyResources(this.addWatchPath, "addWatchPath");
            this.addWatchPath.BackgroundImage = null;
            this.addWatchPath.Font = null;
            this.addWatchPath.Name = "addWatchPath";
            this.toolTip.SetToolTip(this.addWatchPath, resources.GetString("addWatchPath.ToolTip"));
            // 
            // watchedFolders
            // 
            this.watchedFolders.AccessibleDescription = null;
            this.watchedFolders.AccessibleName = null;
            resources.ApplyResources(this.watchedFolders, "watchedFolders");
            this.watchedFolders.BackgroundImage = null;
            this.watchedFolders.Font = null;
            this.watchedFolders.Name = "watchedFolders";
            this.toolTip.SetToolTip(this.watchedFolders, resources.GetString("watchedFolders.ToolTip"));
            // 
            // runWatcherToolStripMenuItem
            // 
            this.runWatcherToolStripMenuItem.AccessibleDescription = null;
            this.runWatcherToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.runWatcherToolStripMenuItem, "runWatcherToolStripMenuItem");
            this.runWatcherToolStripMenuItem.BackgroundImage = null;
            this.runWatcherToolStripMenuItem.Name = "runWatcherToolStripMenuItem";
            this.runWatcherToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // stopWatcherToolStripMenuItem
            // 
            this.stopWatcherToolStripMenuItem.AccessibleDescription = null;
            this.stopWatcherToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.stopWatcherToolStripMenuItem, "stopWatcherToolStripMenuItem");
            this.stopWatcherToolStripMenuItem.BackgroundImage = null;
            this.stopWatcherToolStripMenuItem.Name = "stopWatcherToolStripMenuItem";
            this.stopWatcherToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AccessibleDescription = null;
            this.toolStripSeparator2.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // deleteSelectedWatcherToolStripMenuItem
            // 
            this.deleteSelectedWatcherToolStripMenuItem.AccessibleDescription = null;
            this.deleteSelectedWatcherToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.deleteSelectedWatcherToolStripMenuItem, "deleteSelectedWatcherToolStripMenuItem");
            this.deleteSelectedWatcherToolStripMenuItem.BackgroundImage = null;
            this.deleteSelectedWatcherToolStripMenuItem.Name = "deleteSelectedWatcherToolStripMenuItem";
            this.deleteSelectedWatcherToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // sysTrayMenu
            // 
            this.sysTrayMenu.AccessibleDescription = null;
            this.sysTrayMenu.AccessibleName = null;
            resources.ApplyResources(this.sysTrayMenu, "sysTrayMenu");
            this.sysTrayMenu.BackgroundImage = null;
            this.sysTrayMenu.Font = null;
            this.sysTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysTrayOpen,
            this.displayDropTargetToolStripMenuItem,
            this.toolStripSeparator1,
            this.sysTrayExit});
            this.sysTrayMenu.Name = "sysTrayMenu";
            this.toolTip.SetToolTip(this.sysTrayMenu, resources.GetString("sysTrayMenu.ToolTip"));
            // 
            // sysTrayOpen
            // 
            this.sysTrayOpen.AccessibleDescription = null;
            this.sysTrayOpen.AccessibleName = null;
            resources.ApplyResources(this.sysTrayOpen, "sysTrayOpen");
            this.sysTrayOpen.BackgroundImage = null;
            this.sysTrayOpen.Name = "sysTrayOpen";
            this.sysTrayOpen.ShortcutKeyDisplayString = null;
            this.sysTrayOpen.Click += new System.EventHandler(this.sysTrayOpen_Click);
            // 
            // displayDropTargetToolStripMenuItem
            // 
            this.displayDropTargetToolStripMenuItem.AccessibleDescription = null;
            this.displayDropTargetToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.displayDropTargetToolStripMenuItem, "displayDropTargetToolStripMenuItem");
            this.displayDropTargetToolStripMenuItem.BackgroundImage = null;
            this.displayDropTargetToolStripMenuItem.Name = "displayDropTargetToolStripMenuItem";
            this.displayDropTargetToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.displayDropTargetToolStripMenuItem.Click += new System.EventHandler(this.displayDropTargetToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // sysTrayExit
            // 
            this.sysTrayExit.AccessibleDescription = null;
            this.sysTrayExit.AccessibleName = null;
            resources.ApplyResources(this.sysTrayExit, "sysTrayExit");
            this.sysTrayExit.BackgroundImage = null;
            this.sysTrayExit.Name = "sysTrayExit";
            this.sysTrayExit.ShortcutKeyDisplayString = null;
            this.sysTrayExit.Click += new System.EventHandler(this.sysTrayExit_Click);
            // 
            // btnAppAbout
            // 
            this.btnAppAbout.AccessibleDescription = null;
            this.btnAppAbout.AccessibleName = null;
            resources.ApplyResources(this.btnAppAbout, "btnAppAbout");
            this.btnAppAbout.BackgroundImage = null;
            this.btnAppAbout.Font = null;
            this.btnAppAbout.Name = "btnAppAbout";
            this.toolTip.SetToolTip(this.btnAppAbout, resources.GetString("btnAppAbout.ToolTip"));
            this.btnAppAbout.UseVisualStyleBackColor = true;
            this.btnAppAbout.Click += new System.EventHandler(this.btnAppAbout_Click);
            // 
            // notifyIcon
            // 
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.ContextMenuStrip = this.sysTrayMenu;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // mainForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.btnAppAbout);
            this.Controls.Add(this.tabControl);
            this.Font = null;
            this.Name = "mainForm";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
        private System.Windows.Forms.Button btnMoviesBrowse;
        private System.Windows.Forms.ToolStripMenuItem displayDropTargetToolStripMenuItem;
        private System.Windows.Forms.CheckBox optionDropTarget;
        private System.Windows.Forms.CheckBox option_moveMovies;
        private System.Windows.Forms.Button btnMovePath;
        private System.Windows.Forms.TextBox option_movieTargetLocation;
        private System.Windows.Forms.Button btnAppAbout;
        private System.Windows.Forms.ComboBox optionSeriesParser;
    }
}

