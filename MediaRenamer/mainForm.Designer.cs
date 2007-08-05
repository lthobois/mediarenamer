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
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoLog = new System.Windows.Forms.ListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSeries = new System.Windows.Forms.TabPage();
            this.scanSeriesList = new System.Windows.Forms.ListBox();
            this.contextRename = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextOptionRename = new System.Windows.Forms.ToolStripMenuItem();
            this.groupSeries = new System.Windows.Forms.GroupBox();
            this.scanSeriesProgressbar = new System.Windows.Forms.ProgressBar();
            this.btnSeriesScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.seriesScanPath = new System.Windows.Forms.ComboBox();
            this.tabMovies = new System.Windows.Forms.TabPage();
            this.scanMovieList = new System.Windows.Forms.ListBox();
            this.groupMovies = new System.Windows.Forms.GroupBox();
            this.scanMovieProgressbar = new System.Windows.Forms.ProgressBar();
            this.btnMovieScan = new System.Windows.Forms.Button();
            this.moviePathLabel = new System.Windows.Forms.Label();
            this.movieScanPath = new System.Windows.Forms.ComboBox();
            this.tabWatch = new System.Windows.Forms.TabPage();
            this.watchThreadRun = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_watchType = new System.Windows.Forms.Label();
            this.label_watchPath = new System.Windows.Forms.Label();
            this.addWatchType = new System.Windows.Forms.ComboBox();
            this.addWatchFolder = new System.Windows.Forms.Button();
            this.addWatchPath = new System.Windows.Forms.TextBox();
            this.watchedFolders = new System.Windows.Forms.ListBox();
            this.watchThreadStop = new System.Windows.Forms.Button();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.optionGroupOthers = new System.Windows.Forms.GroupBox();
            this.optionSysTray = new System.Windows.Forms.CheckBox();
            this.optionWindowsStart = new System.Windows.Forms.CheckBox();
            this.optionGroupMovies = new System.Windows.Forms.GroupBox();
            this.option_movieFormat = new System.Windows.Forms.TextBox();
            this.contextProposals = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelMovieOutpu = new System.Windows.Forms.Label();
            this.optionGroupSeries = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.option_tvSourceEPW = new System.Windows.Forms.RadioButton();
            this.labelTVSource = new System.Windows.Forms.Label();
            this.option_seriesFormat = new System.Windows.Forms.TextBox();
            this.labelTVOutput = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.sysTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sysTrayOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sysTrayExit = new System.Windows.Forms.ToolStripMenuItem();
            this.option_langUI = new System.Windows.Forms.ComboBox();
            this.label_langUI = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSeries.SuspendLayout();
            this.contextRename.SuspendLayout();
            this.groupSeries.SuspendLayout();
            this.tabMovies.SuspendLayout();
            this.groupMovies.SuspendLayout();
            this.tabWatch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.optionGroupOthers.SuspendLayout();
            this.optionGroupMovies.SuspendLayout();
            this.optionGroupSeries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.sysTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.infoLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 429);
            this.panel1.TabIndex = 2;
            // 
            // infoLog
            // 
            this.infoLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoLog.Font = new System.Drawing.Font("Arial", 6.75F);
            this.infoLog.FormattingEnabled = true;
            this.infoLog.ItemHeight = 12;
            this.infoLog.Location = new System.Drawing.Point(0, 341);
            this.infoLog.Name = "infoLog";
            this.infoLog.Size = new System.Drawing.Size(144, 88);
            this.infoLog.TabIndex = 0;
            this.infoLog.SelectedIndexChanged += new System.EventHandler(this.infoLog_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSeries);
            this.tabControl.Controls.Add(this.tabMovies);
            this.tabControl.Controls.Add(this.tabWatch);
            this.tabControl.Controls.Add(this.tabOptions);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(144, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(572, 429);
            this.tabControl.TabIndex = 3;
            // 
            // tabSeries
            // 
            this.tabSeries.Controls.Add(this.scanSeriesList);
            this.tabSeries.Controls.Add(this.groupSeries);
            this.tabSeries.Location = new System.Drawing.Point(4, 22);
            this.tabSeries.Name = "tabSeries";
            this.tabSeries.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeries.Size = new System.Drawing.Size(564, 403);
            this.tabSeries.TabIndex = 0;
            this.tabSeries.Text = "TV Series";
            this.tabSeries.UseVisualStyleBackColor = true;
            // 
            // scanSeriesList
            // 
            this.scanSeriesList.ContextMenuStrip = this.contextRename;
            this.scanSeriesList.FormattingEnabled = true;
            this.scanSeriesList.Location = new System.Drawing.Point(7, 95);
            this.scanSeriesList.Name = "scanSeriesList";
            this.scanSeriesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.scanSeriesList.Size = new System.Drawing.Size(549, 303);
            this.scanSeriesList.TabIndex = 1;
            this.scanSeriesList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.scanSeriesList_KeyUp);
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
            this.groupSeries.Controls.Add(this.scanSeriesProgressbar);
            this.groupSeries.Controls.Add(this.btnSeriesScan);
            this.groupSeries.Controls.Add(this.label1);
            this.groupSeries.Controls.Add(this.seriesScanPath);
            this.groupSeries.Location = new System.Drawing.Point(7, 7);
            this.groupSeries.Name = "groupSeries";
            this.groupSeries.Size = new System.Drawing.Size(549, 82);
            this.groupSeries.TabIndex = 0;
            this.groupSeries.TabStop = false;
            this.groupSeries.Text = "TV Series scan mode";
            // 
            // scanSeriesProgressbar
            // 
            this.scanSeriesProgressbar.Location = new System.Drawing.Point(10, 59);
            this.scanSeriesProgressbar.Maximum = 0;
            this.scanSeriesProgressbar.Name = "scanSeriesProgressbar";
            this.scanSeriesProgressbar.Size = new System.Drawing.Size(452, 11);
            this.scanSeriesProgressbar.TabIndex = 5;
            // 
            // btnSeriesScan
            // 
            this.btnSeriesScan.Enabled = false;
            this.btnSeriesScan.Location = new System.Drawing.Point(468, 30);
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
            this.seriesScanPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.seriesScanPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.seriesScanPath.FormattingEnabled = true;
            this.seriesScanPath.Location = new System.Drawing.Point(10, 32);
            this.seriesScanPath.Name = "seriesScanPath";
            this.seriesScanPath.Size = new System.Drawing.Size(452, 21);
            this.seriesScanPath.TabIndex = 0;
            this.seriesScanPath.SelectedIndexChanged += new System.EventHandler(this.seriesScanPath_TextUpdate);
            this.seriesScanPath.TextUpdate += new System.EventHandler(this.seriesScanPath_TextUpdate);
            // 
            // tabMovies
            // 
            this.tabMovies.Controls.Add(this.scanMovieList);
            this.tabMovies.Controls.Add(this.groupMovies);
            this.tabMovies.Location = new System.Drawing.Point(4, 22);
            this.tabMovies.Name = "tabMovies";
            this.tabMovies.Padding = new System.Windows.Forms.Padding(3);
            this.tabMovies.Size = new System.Drawing.Size(564, 403);
            this.tabMovies.TabIndex = 1;
            this.tabMovies.Text = "Movies";
            this.tabMovies.UseVisualStyleBackColor = true;
            // 
            // scanMovieList
            // 
            this.scanMovieList.ContextMenuStrip = this.contextRename;
            this.scanMovieList.FormattingEnabled = true;
            this.scanMovieList.Location = new System.Drawing.Point(7, 95);
            this.scanMovieList.Name = "scanMovieList";
            this.scanMovieList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.scanMovieList.Size = new System.Drawing.Size(549, 303);
            this.scanMovieList.TabIndex = 2;
            this.scanMovieList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.scanMovieList_KeyUp);
            // 
            // groupMovies
            // 
            this.groupMovies.Controls.Add(this.scanMovieProgressbar);
            this.groupMovies.Controls.Add(this.btnMovieScan);
            this.groupMovies.Controls.Add(this.moviePathLabel);
            this.groupMovies.Controls.Add(this.movieScanPath);
            this.groupMovies.Location = new System.Drawing.Point(7, 7);
            this.groupMovies.Name = "groupMovies";
            this.groupMovies.Size = new System.Drawing.Size(549, 82);
            this.groupMovies.TabIndex = 1;
            this.groupMovies.TabStop = false;
            this.groupMovies.Text = "Movie scan mode";
            // 
            // scanMovieProgressbar
            // 
            this.scanMovieProgressbar.Location = new System.Drawing.Point(10, 59);
            this.scanMovieProgressbar.Maximum = 0;
            this.scanMovieProgressbar.Name = "scanMovieProgressbar";
            this.scanMovieProgressbar.Size = new System.Drawing.Size(452, 11);
            this.scanMovieProgressbar.TabIndex = 4;
            // 
            // btnMovieScan
            // 
            this.btnMovieScan.Enabled = false;
            this.btnMovieScan.Location = new System.Drawing.Point(468, 30);
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
            this.movieScanPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.movieScanPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.movieScanPath.FormattingEnabled = true;
            this.movieScanPath.Location = new System.Drawing.Point(10, 32);
            this.movieScanPath.Name = "movieScanPath";
            this.movieScanPath.Size = new System.Drawing.Size(452, 21);
            this.movieScanPath.TabIndex = 1;
            this.movieScanPath.SelectedIndexChanged += new System.EventHandler(this.movieScanPath_TextUpdate);
            this.movieScanPath.TextUpdate += new System.EventHandler(this.movieScanPath_TextUpdate);
            // 
            // tabWatch
            // 
            this.tabWatch.Controls.Add(this.watchThreadRun);
            this.tabWatch.Controls.Add(this.groupBox1);
            this.tabWatch.Controls.Add(this.watchedFolders);
            this.tabWatch.Controls.Add(this.watchThreadStop);
            this.tabWatch.Location = new System.Drawing.Point(4, 22);
            this.tabWatch.Name = "tabWatch";
            this.tabWatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabWatch.Size = new System.Drawing.Size(564, 403);
            this.tabWatch.TabIndex = 2;
            this.tabWatch.Text = "Watched Folders";
            this.tabWatch.UseVisualStyleBackColor = true;
            // 
            // watchThreadRun
            // 
            this.watchThreadRun.Enabled = false;
            this.watchThreadRun.Location = new System.Drawing.Point(400, 346);
            this.watchThreadRun.Name = "watchThreadRun";
            this.watchThreadRun.Size = new System.Drawing.Size(75, 23);
            this.watchThreadRun.TabIndex = 7;
            this.watchThreadRun.Text = "Run";
            this.watchThreadRun.UseVisualStyleBackColor = true;
            this.watchThreadRun.Click += new System.EventHandler(this.watchThreadRun_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_watchType);
            this.groupBox1.Controls.Add(this.label_watchPath);
            this.groupBox1.Controls.Add(this.addWatchType);
            this.groupBox1.Controls.Add(this.addWatchFolder);
            this.groupBox1.Controls.Add(this.addWatchPath);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 71);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add a watched folder";
            // 
            // label_watchType
            // 
            this.label_watchType.AutoSize = true;
            this.label_watchType.Location = new System.Drawing.Point(325, 22);
            this.label_watchType.Name = "label_watchType";
            this.label_watchType.Size = new System.Drawing.Size(56, 13);
            this.label_watchType.TabIndex = 10;
            this.label_watchType.Text = "Foldertype";
            // 
            // label_watchPath
            // 
            this.label_watchPath.AutoSize = true;
            this.label_watchPath.Location = new System.Drawing.Point(6, 22);
            this.label_watchPath.Name = "label_watchPath";
            this.label_watchPath.Size = new System.Drawing.Size(139, 13);
            this.label_watchPath.TabIndex = 9;
            this.label_watchPath.Text = "Folder to watch for changes";
            // 
            // addWatchType
            // 
            this.addWatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addWatchType.FormattingEnabled = true;
            this.addWatchType.Location = new System.Drawing.Point(328, 38);
            this.addWatchType.Name = "addWatchType";
            this.addWatchType.Size = new System.Drawing.Size(134, 21);
            this.addWatchType.TabIndex = 7;
            this.addWatchType.TextChanged += new System.EventHandler(this.addWatchFolder_Changed);
            this.addWatchType.SelectedValueChanged += new System.EventHandler(this.addWatchFolder_Changed);
            // 
            // addWatchFolder
            // 
            this.addWatchFolder.Enabled = false;
            this.addWatchFolder.Location = new System.Drawing.Point(466, 36);
            this.addWatchFolder.Name = "addWatchFolder";
            this.addWatchFolder.Size = new System.Drawing.Size(75, 23);
            this.addWatchFolder.TabIndex = 8;
            this.addWatchFolder.Text = "Add Folder";
            this.addWatchFolder.UseVisualStyleBackColor = true;
            this.addWatchFolder.Click += new System.EventHandler(this.watchAddTest_Click);
            // 
            // addWatchPath
            // 
            this.addWatchPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.addWatchPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.addWatchPath.Location = new System.Drawing.Point(9, 38);
            this.addWatchPath.Name = "addWatchPath";
            this.addWatchPath.Size = new System.Drawing.Size(313, 20);
            this.addWatchPath.TabIndex = 6;
            this.addWatchPath.TextChanged += new System.EventHandler(this.addWatchFolder_Changed);
            // 
            // watchedFolders
            // 
            this.watchedFolders.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.watchedFolders.FormattingEnabled = true;
            this.watchedFolders.ItemHeight = 36;
            this.watchedFolders.Location = new System.Drawing.Point(7, 84);
            this.watchedFolders.Name = "watchedFolders";
            this.watchedFolders.Size = new System.Drawing.Size(549, 256);
            this.watchedFolders.TabIndex = 3;
            this.watchedFolders.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.watchedFolders_DrawItem);
            this.watchedFolders.SelectedIndexChanged += new System.EventHandler(this.watchedFolders_SelectedIndexChanged);
            // 
            // watchThreadStop
            // 
            this.watchThreadStop.Enabled = false;
            this.watchThreadStop.Location = new System.Drawing.Point(481, 346);
            this.watchThreadStop.Name = "watchThreadStop";
            this.watchThreadStop.Size = new System.Drawing.Size(75, 23);
            this.watchThreadStop.TabIndex = 2;
            this.watchThreadStop.Text = "Stop";
            this.watchThreadStop.UseVisualStyleBackColor = true;
            this.watchThreadStop.Click += new System.EventHandler(this.watchThreadStop_Click);
            // 
            // tabOptions
            // 
            this.tabOptions.AutoScroll = true;
            this.tabOptions.Controls.Add(this.optionGroupOthers);
            this.tabOptions.Controls.Add(this.optionGroupMovies);
            this.tabOptions.Controls.Add(this.optionGroupSeries);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Size = new System.Drawing.Size(564, 403);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            this.tabOptions.Click += new System.EventHandler(this.tabOptions_Click);
            // 
            // optionGroupOthers
            // 
            this.optionGroupOthers.Controls.Add(this.label_langUI);
            this.optionGroupOthers.Controls.Add(this.option_langUI);
            this.optionGroupOthers.Controls.Add(this.optionSysTray);
            this.optionGroupOthers.Controls.Add(this.optionWindowsStart);
            this.optionGroupOthers.Location = new System.Drawing.Point(4, 201);
            this.optionGroupOthers.Name = "optionGroupOthers";
            this.optionGroupOthers.Size = new System.Drawing.Size(505, 100);
            this.optionGroupOthers.TabIndex = 3;
            this.optionGroupOthers.TabStop = false;
            this.optionGroupOthers.Text = "General Options";
            // 
            // optionSysTray
            // 
            this.optionSysTray.AutoSize = true;
            this.optionSysTray.Location = new System.Drawing.Point(30, 43);
            this.optionSysTray.Name = "optionSysTray";
            this.optionSysTray.Size = new System.Drawing.Size(219, 17);
            this.optionSysTray.TabIndex = 1;
            this.optionSysTray.Text = "Display icon in system tray (next to clock)";
            this.optionSysTray.UseVisualStyleBackColor = true;
            this.optionSysTray.CheckedChanged += new System.EventHandler(this.optionSysTray_CheckedChanged);
            // 
            // optionWindowsStart
            // 
            this.optionWindowsStart.AutoSize = true;
            this.optionWindowsStart.Location = new System.Drawing.Point(30, 19);
            this.optionWindowsStart.Name = "optionWindowsStart";
            this.optionWindowsStart.Size = new System.Drawing.Size(198, 17);
            this.optionWindowsStart.TabIndex = 0;
            this.optionWindowsStart.Text = "Launch application on windows start";
            this.optionWindowsStart.UseVisualStyleBackColor = true;
            // 
            // optionGroupMovies
            // 
            this.optionGroupMovies.AutoSize = true;
            this.optionGroupMovies.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.optionGroupMovies.Controls.Add(this.option_movieFormat);
            this.optionGroupMovies.Controls.Add(this.labelMovieOutpu);
            this.optionGroupMovies.Location = new System.Drawing.Point(3, 137);
            this.optionGroupMovies.Name = "optionGroupMovies";
            this.optionGroupMovies.Size = new System.Drawing.Size(506, 57);
            this.optionGroupMovies.TabIndex = 2;
            this.optionGroupMovies.TabStop = false;
            this.optionGroupMovies.Text = "Movie Options";
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
            this.option_movieFormat.Size = new System.Drawing.Size(358, 20);
            this.option_movieFormat.TabIndex = 17;
            this.option_movieFormat.Text = "<moviename> (<year><disk:,CD><disk><lang:,><lang>)";
            this.option_movieFormat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.option_movieFormat_MouseDown);
            this.option_movieFormat.Leave += new System.EventHandler(this.option_movieFormat_Leave);
            // 
            // contextProposals
            // 
            this.contextProposals.Name = "contextProposals";
            this.contextProposals.Size = new System.Drawing.Size(61, 4);
            this.contextProposals.Opening += new System.ComponentModel.CancelEventHandler(this.contextProposals_Opening);
            this.contextProposals.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextProposals_ItemClicked);
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
            this.optionGroupSeries.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.optionGroupSeries.Controls.Add(this.pictureBox1);
            this.optionGroupSeries.Controls.Add(this.option_tvSourceEPW);
            this.optionGroupSeries.Controls.Add(this.labelTVSource);
            this.optionGroupSeries.Controls.Add(this.option_seriesFormat);
            this.optionGroupSeries.Controls.Add(this.labelTVOutput);
            this.optionGroupSeries.Location = new System.Drawing.Point(3, 3);
            this.optionGroupSeries.Name = "optionGroupSeries";
            this.optionGroupSeries.Size = new System.Drawing.Size(506, 128);
            this.optionGroupSeries.TabIndex = 1;
            this.optionGroupSeries.TabStop = false;
            this.optionGroupSeries.Text = "TV Series Options";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MediaRenamer.Properties.Resources.EPW_Logo_168;
            this.pictureBox1.InitialImage = global::MediaRenamer.Properties.Resources.EPW_Logo_168;
            this.pictureBox1.Location = new System.Drawing.Point(142, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // option_tvSourceEPW
            // 
            this.option_tvSourceEPW.AutoSize = true;
            this.option_tvSourceEPW.Checked = true;
            this.option_tvSourceEPW.Location = new System.Drawing.Point(142, 43);
            this.option_tvSourceEPW.Name = "option_tvSourceEPW";
            this.option_tvSourceEPW.Size = new System.Drawing.Size(137, 17);
            this.option_tvSourceEPW.TabIndex = 15;
            this.option_tvSourceEPW.TabStop = true;
            this.option_tvSourceEPW.Text = "www.episodeworld.com";
            this.option_tvSourceEPW.UseVisualStyleBackColor = true;
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
            this.option_seriesFormat.Size = new System.Drawing.Size(358, 20);
            this.option_seriesFormat.TabIndex = 13;
            this.option_seriesFormat.Text = "<series> - <season>x<episode><title: - ><title>";
            this.option_seriesFormat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.option_seriesFormat_MouseDown);
            this.option_seriesFormat.Leave += new System.EventHandler(this.option_seriesFormat_Leave);
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
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.sysTrayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MediaRenamer";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // sysTrayMenu
            // 
            this.sysTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysTrayOpen,
            this.toolStripSeparator1,
            this.sysTrayExit});
            this.sysTrayMenu.Name = "sysTrayMenu";
            this.sysTrayMenu.Size = new System.Drawing.Size(171, 54);
            // 
            // sysTrayOpen
            // 
            this.sysTrayOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.sysTrayOpen.Name = "sysTrayOpen";
            this.sysTrayOpen.Size = new System.Drawing.Size(170, 22);
            this.sysTrayOpen.Text = "Show Application";
            this.sysTrayOpen.Click += new System.EventHandler(this.sysTrayOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // sysTrayExit
            // 
            this.sysTrayExit.Name = "sysTrayExit";
            this.sysTrayExit.Size = new System.Drawing.Size(170, 22);
            this.sysTrayExit.Text = "Exit";
            this.sysTrayExit.Click += new System.EventHandler(this.sysTrayExit_Click);
            // 
            // option_langUI
            // 
            this.option_langUI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.option_langUI.FormattingEnabled = true;
            this.option_langUI.Location = new System.Drawing.Point(141, 66);
            this.option_langUI.Name = "option_langUI";
            this.option_langUI.Size = new System.Drawing.Size(229, 21);
            this.option_langUI.TabIndex = 2;
            // 
            // label_langUI
            // 
            this.label_langUI.Location = new System.Drawing.Point(5, 64);
            this.label_langUI.Name = "label_langUI";
            this.label_langUI.Size = new System.Drawing.Size(130, 23);
            this.label_langUI.TabIndex = 16;
            this.label_langUI.Text = "UI Language";
            this.label_langUI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 429);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.Name = "mainForm";
            this.Text = "MediaRenamer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabSeries.ResumeLayout(false);
            this.contextRename.ResumeLayout(false);
            this.groupSeries.ResumeLayout(false);
            this.groupSeries.PerformLayout();
            this.tabMovies.ResumeLayout(false);
            this.groupMovies.ResumeLayout(false);
            this.groupMovies.PerformLayout();
            this.tabWatch.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSeries;
        private System.Windows.Forms.TabPage tabMovies;
        private System.Windows.Forms.TabPage tabWatch;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.ListBox infoLog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button watchThreadStop;
        private System.Windows.Forms.GroupBox optionGroupSeries;
        private System.Windows.Forms.TextBox option_seriesFormat;
        private System.Windows.Forms.Label labelTVOutput;
        private System.Windows.Forms.ContextMenuStrip contextProposals;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton option_tvSourceEPW;
        private System.Windows.Forms.Label labelTVSource;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ListBox watchedFolders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addWatchFolder;
        private System.Windows.Forms.TextBox addWatchPath;
        private System.Windows.Forms.Label label_watchType;
        private System.Windows.Forms.Label label_watchPath;
        private System.Windows.Forms.ComboBox addWatchType;
        private System.Windows.Forms.Button watchThreadRun;
        private System.Windows.Forms.GroupBox groupMovies;
        private System.Windows.Forms.ComboBox movieScanPath;
        private System.Windows.Forms.ProgressBar scanMovieProgressbar;
        private System.Windows.Forms.Button btnMovieScan;
        private System.Windows.Forms.Label moviePathLabel;
        private System.Windows.Forms.ListBox scanMovieList;
        private System.Windows.Forms.GroupBox groupSeries;
        private System.Windows.Forms.ComboBox seriesScanPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeriesScan;
        private System.Windows.Forms.ProgressBar scanSeriesProgressbar;
        private System.Windows.Forms.ListBox scanSeriesList;
        private System.Windows.Forms.ContextMenuStrip contextRename;
        private System.Windows.Forms.ToolStripMenuItem contextOptionRename;
        private System.Windows.Forms.GroupBox optionGroupMovies;
        private System.Windows.Forms.TextBox option_movieFormat;
        private System.Windows.Forms.Label labelMovieOutpu;
        private System.Windows.Forms.GroupBox optionGroupOthers;
        private System.Windows.Forms.CheckBox optionWindowsStart;
        private System.Windows.Forms.CheckBox optionSysTray;
        private System.Windows.Forms.ContextMenuStrip sysTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem sysTrayExit;
        private System.Windows.Forms.ToolStripMenuItem sysTrayOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label_langUI;
        private System.Windows.Forms.ComboBox option_langUI;
    }
}

