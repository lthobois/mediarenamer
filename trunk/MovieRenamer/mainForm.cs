// *******************************************************************************
//  Title:			mainForm.cs
//  Description:	Main Form for the MovieRenamer
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using MediaRenamer;

namespace MovieRenamer
{
	/// <summary>
	/// Zusammenfassung für mainForm.
	/// </summary>
	public class mainForm : System.Windows.Forms.Form
	{
		public static mainForm instance = null;
		private String appFolder = "";
		private System.Windows.Forms.Button seriesPathBtn;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.TextBox details;
		private System.Windows.Forms.ComboBox moviesPath;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.ListBox infoLog;
		private System.Windows.Forms.GroupBox groupRename;
		private System.Windows.Forms.Button renAllBtn;
		private System.Windows.Forms.Button renBtn;
		private System.Windows.Forms.Button scanBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupScan;
		private System.Windows.Forms.ProgressBar progressBar1;
		public System.Windows.Forms.ProgressBar scanProgress;
		private System.Windows.Forms.ToolTip toolTip;
		public System.Windows.Forms.ListBox fileList;
		private System.Windows.Forms.Label labelOutput;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.Button formatInfo;
		private System.Windows.Forms.TextBox outputFormat;
		private System.ComponentModel.IContainer components;

		public mainForm()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
			instance = this;
			appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\MovieRenamer\";
			if (!Directory.Exists(appFolder)) Directory.CreateDirectory(appFolder);
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            this.seriesPathBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileList = new System.Windows.Forms.ListBox();
            this.details = new System.Windows.Forms.TextBox();
            this.moviesPath = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupScan = new System.Windows.Forms.GroupBox();
            this.scanBtn = new System.Windows.Forms.Button();
            this.groupRename = new System.Windows.Forms.GroupBox();
            this.renAllBtn = new System.Windows.Forms.Button();
            this.renBtn = new System.Windows.Forms.Button();
            this.infoLog = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.scanProgress = new System.Windows.Forms.ProgressBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.formatInfo = new System.Windows.Forms.Button();
            this.outputFormat = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupScan.SuspendLayout();
            this.groupRename.SuspendLayout();
            this.SuspendLayout();
            // 
            // seriesPathBtn
            // 
            this.seriesPathBtn.Location = new System.Drawing.Point(632, 32);
            this.seriesPathBtn.Name = "seriesPathBtn";
            this.seriesPathBtn.Size = new System.Drawing.Size(24, 24);
            this.seriesPathBtn.TabIndex = 1;
            this.seriesPathBtn.Text = "...";
            this.seriesPathBtn.Click += new System.EventHandler(this.seriesPathBtn_Click);
            // 
            // fileList
            // 
            this.fileList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.fileList.Location = new System.Drawing.Point(176, 56);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(480, 303);
            this.fileList.Sorted = true;
            this.fileList.TabIndex = 3;
            this.fileList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.fileList_DrawItem);
            this.fileList.SelectedIndexChanged += new System.EventHandler(this.fileList_SelectedIndexChanged);
            this.fileList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fileList_KeyUp);
            // 
            // details
            // 
            this.details.Location = new System.Drawing.Point(176, 360);
            this.details.Name = "details";
            this.details.ReadOnly = true;
            this.details.Size = new System.Drawing.Size(480, 20);
            this.details.TabIndex = 4;
            // 
            // moviesPath
            // 
            this.moviesPath.Location = new System.Drawing.Point(264, 32);
            this.moviesPath.Name = "moviesPath";
            this.moviesPath.Size = new System.Drawing.Size(360, 21);
            this.moviesPath.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupScan);
            this.panel1.Controls.Add(this.groupRename);
            this.panel1.Controls.Add(this.infoLog);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 392);
            this.panel1.TabIndex = 10;
            // 
            // groupScan
            // 
            this.groupScan.Controls.Add(this.scanBtn);
            this.groupScan.Location = new System.Drawing.Point(8, 104);
            this.groupScan.Name = "groupScan";
            this.groupScan.Size = new System.Drawing.Size(152, 48);
            this.groupScan.TabIndex = 17;
            this.groupScan.TabStop = false;
            this.groupScan.Text = "Scanner/Parser";
            // 
            // scanBtn
            // 
            this.scanBtn.BackColor = System.Drawing.SystemColors.Control;
            this.scanBtn.Location = new System.Drawing.Point(8, 16);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Size = new System.Drawing.Size(136, 23);
            this.scanBtn.TabIndex = 12;
            this.scanBtn.Text = "Scan Movies";
            this.scanBtn.UseVisualStyleBackColor = false;
            this.scanBtn.Click += new System.EventHandler(this.scanBtn_Click);
            // 
            // groupRename
            // 
            this.groupRename.Controls.Add(this.renAllBtn);
            this.groupRename.Controls.Add(this.renBtn);
            this.groupRename.Location = new System.Drawing.Point(8, 160);
            this.groupRename.Name = "groupRename";
            this.groupRename.Size = new System.Drawing.Size(152, 80);
            this.groupRename.TabIndex = 16;
            this.groupRename.TabStop = false;
            this.groupRename.Text = "Rename";
            // 
            // renAllBtn
            // 
            this.renAllBtn.BackColor = System.Drawing.SystemColors.Control;
            this.renAllBtn.Enabled = false;
            this.renAllBtn.Location = new System.Drawing.Point(8, 49);
            this.renAllBtn.Name = "renAllBtn";
            this.renAllBtn.Size = new System.Drawing.Size(136, 23);
            this.renAllBtn.TabIndex = 15;
            this.renAllBtn.Text = "all Files and Folders";
            this.renAllBtn.UseVisualStyleBackColor = false;
            this.renAllBtn.Click += new System.EventHandler(this.renAllBtn_Click);
            // 
            // renBtn
            // 
            this.renBtn.BackColor = System.Drawing.SystemColors.Control;
            this.renBtn.Enabled = false;
            this.renBtn.Location = new System.Drawing.Point(8, 17);
            this.renBtn.Name = "renBtn";
            this.renBtn.Size = new System.Drawing.Size(136, 23);
            this.renBtn.TabIndex = 14;
            this.renBtn.Text = "selected File or Folder";
            this.renBtn.UseVisualStyleBackColor = false;
            this.renBtn.Click += new System.EventHandler(this.renBtn_Click);
            // 
            // infoLog
            // 
            this.infoLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoLog.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLog.ItemHeight = 12;
            this.infoLog.Location = new System.Drawing.Point(0, 244);
            this.infoLog.Name = "infoLog";
            this.infoLog.Size = new System.Drawing.Size(168, 148);
            this.infoLog.TabIndex = 15;
            this.toolTip.SetToolTip(this.infoLog, "infoLog");
            this.infoLog.SelectedIndexChanged += new System.EventHandler(this.infoLog_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "MovieRenamer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(360, 720);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // scanProgress
            // 
            this.scanProgress.Location = new System.Drawing.Point(176, 360);
            this.scanProgress.Name = "scanProgress";
            this.scanProgress.Size = new System.Drawing.Size(480, 20);
            this.scanProgress.TabIndex = 12;
            this.scanProgress.Visible = false;
            // 
            // labelOutput
            // 
            this.labelOutput.Location = new System.Drawing.Point(176, 8);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(88, 23);
            this.labelOutput.TabIndex = 16;
            this.labelOutput.Text = "Output Format:";
            this.labelOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPath
            // 
            this.labelPath.Location = new System.Drawing.Point(176, 32);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(88, 23);
            this.labelPath.TabIndex = 15;
            this.labelPath.Text = "Path:";
            this.labelPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formatInfo
            // 
            this.formatInfo.Location = new System.Drawing.Point(632, 8);
            this.formatInfo.Name = "formatInfo";
            this.formatInfo.Size = new System.Drawing.Size(24, 23);
            this.formatInfo.TabIndex = 18;
            this.formatInfo.Text = "?";
            this.formatInfo.Click += new System.EventHandler(this.formatInfo_Click);
            // 
            // outputFormat
            // 
            this.outputFormat.Location = new System.Drawing.Point(264, 8);
            this.outputFormat.Name = "outputFormat";
            this.outputFormat.Size = new System.Drawing.Size(360, 20);
            this.outputFormat.TabIndex = 17;
            this.outputFormat.Text = "<moviename> (<year><disk:,CD><disk><lang:,><lang>)";
            this.outputFormat.Leave += new System.EventHandler(this.outputFormat_Leave);
            // 
            // mainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(664, 392);
            this.Controls.Add(this.formatInfo);
            this.Controls.Add(this.outputFormat);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.scanProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.moviesPath);
            this.Controls.Add(this.details);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.seriesPathBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movie Renamer";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.mainForm_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupScan.ResumeLayout(false);
            this.groupRename.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new mainForm());
		}

		private void seriesPathBtn_Click(object sender, System.EventArgs e)
		{
			folderBrowserDialog.SelectedPath = moviesPath.Text;
			folderBrowserDialog.ShowNewFolderButton = false;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				moviesPath.Text = folderBrowserDialog.SelectedPath;
				if (moviesPath.Items.IndexOf(folderBrowserDialog.SelectedPath) < 0)
				{
					moviesPath.Items.Insert(0, folderBrowserDialog.SelectedPath);
				}
			}
		}

		private void scanBtn_Click(object sender, System.EventArgs e)
		{
			if (moviesPath.Text.Length == 0)
			{
				MessageBox.Show( i18n.t("scan_empty") );
				return;
			}
			if (!Directory.Exists(moviesPath.Text))
			{
				MessageBox.Show( i18n.t("scan_path") );
				moviesPath.Items.Remove( moviesPath.Text );
				return;
			}
			if (moviesPath.Items.IndexOf( moviesPath.Text ) == -1)
			{
				moviesPath.Items.Add( moviesPath.Text );
			}
			details.Text = "";
			fileList.Items.Clear();
			infoLog.Items.Clear();

			scanBtn.Enabled = false;
			renAllBtn.Enabled = false;
			renBtn.Enabled = false;

			Log.Add( i18n.t("scan_start") );
			Parser parse = new Parser(moviesPath.Text);
			parse.startScan();

			scanBtn.Enabled = true;
			renAllBtn.Enabled = (fileList.Items.Count > 0);
			renBtn.Enabled = (fileList.Items.Count > 0);

			Log.Add( i18n.t("scan_end_count", fileList.Items.Count) );
		}

		private void seriesPath_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void fileList_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			if (e.Index < 0 || e.Index > fileList.Items.Count)
				return;
			try
			{
				Movie m = (fileList.Items[e.Index] as Movie);
				e.DrawBackground();
				Brush b = Brushes.Black;
				if (!m.needRenaming())
				{
					b = Brushes.Red;
				}
				else
				{
					b = Brushes.DarkGreen;
				}
				//e.Graphics.DrawString( m.ToString(), e.Font, b, e.Bounds);
				e.Graphics.DrawString( m.modifiedFullName(), e.Font, b, e.Bounds);
				e.DrawFocusRectangle();
			}
			catch (Exception E)
			{
				Log.Add("Drawing Error:"+E.Message);
			}
		}

		private void fileList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				details.Text = (fileList.SelectedItem as Movie).ToString();
				renBtn.Enabled = true;
				renAllBtn.Enabled = true;
			}
			catch
			{
				//
			}
		}

		private void renameMovie(Movie movie)
		{
			if (Directory.Exists(movie.filename))
			{
				Directory.Move(movie.filename, movie.modifiedFullName());
			}
			else
			{
				FileInfo fi = new FileInfo(movie.filename);
				try
				{
					String dir = fi.DirectoryName;
					if (!dir.EndsWith(@"\")) dir += @"\";
					fi.MoveTo(dir+movie.modifiedName()+fi.Extension.ToLower());
				}
				catch (Exception E)
				{
					MessageBox.Show("Cannot rename "+fi.Name+":\n\n"+E.Message);
				}
			}
		}

		private void renBtn_Click(object sender, System.EventArgs e)
		{
			int idx = fileList.SelectedIndex;
			renameMovie(fileList.Items[idx] as Movie);
			fileList.Items.RemoveAt(idx);
			if (fileList.Items.Count > idx)
			{
				fileList.SelectedIndex = idx;
			}
			renAllBtn.Enabled = (fileList.Items.Count > 0);
			renBtn.Enabled = (fileList.Items.Count > 0);
		}

		private void renAllBtn_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<fileList.Items.Count; i++)
			{
				renameMovie(fileList.Items[i] as Movie);
			}
			fileList.Items.Clear();
			renAllBtn.Enabled = (fileList.Items.Count > 0);
			renBtn.Enabled = (fileList.Items.Count > 0);
		}

		private void fileList_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (fileList.Items.Count > 0)
			{
				int idx = fileList.SelectedIndex;
				if (idx < 0 || idx >= fileList.Items.Count) return;
				if (e.KeyCode == Keys.Enter)
				{
					renameMovie(fileList.Items[idx] as Movie);
					fileList.Items.RemoveAt(idx);
					if (fileList.Items.Count > idx)
						fileList.SelectedIndex = idx;
				}
			}
		}

		private void parseDump_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				fileList.BeginUpdate();
				details.Text = "";
				fileList.Items.Clear();
				infoLog.Items.Clear();
				Log.Add( i18n.t("start_scan") );

				FileInfo dumpFile = new FileInfo( openFileDialog.FileName );
				StreamReader strm = new StreamReader(dumpFile.FullName);
				String line = null;
				Parser parser = new Parser( dumpFile.DirectoryName );
				String baseDir = strm.ReadLine();
				while ( (line = strm.ReadLine()) != null)
				{
					Movie movie = parser.parseFile(line);
					if (movie.needRenaming())
						fileList.Items.Add( movie );
				}
				strm.Close();

				Log.Add( i18n.t("scan_end") );
				Log.Add( i18n.t("scan_savedump") );
				StreamWriter strm2 = new StreamWriter(dumpFile.DirectoryName+@"\dump_renamed.txt");
				strm2.WriteLine(baseDir);
				for (int i=0; i<fileList.Items.Count; i++)
				{
					strm2.WriteLine( (fileList.Items[i] as Movie).modifiedFullName() );
				}
				strm2.Close();
				fileList.Sorted = true;
				fileList.EndUpdate();
			}
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void mainForm_Load(object sender, System.EventArgs e)
		{
			if (File.Exists(appFolder+"folders.dat"))
			{
				moviesPath.Items.Clear();
				StreamReader strm = new StreamReader(appFolder+"folders.dat");
				if (strm != null)
				{
					String line = null;
					while ( (line = strm.ReadLine() ) != null)
					{
						if (Directory.Exists( line ))
						{
							moviesPath.Items.Add( line );
						}
					}
					strm.Close();
				}
			}

			if (File.Exists(appFolder+"format.dat"))
			{
				StreamReader strm = new StreamReader( appFolder+"format.dat");
				if (strm != null)
				{
					outputFormat.Text = strm.ReadLine();
					strm.Close();
				}
			}

			labelOutput.Text = i18n.t("dlg_output");
			labelPath.Text = i18n.t("dlg_path");
			groupScan.Text = i18n.t("dlg_scanner");
			groupRename.Text = i18n.t("dlg_rename");
			scanBtn.Text = i18n.t("dlg_scanmovie");
			renBtn.Text = i18n.t("dlg_renmov");
			renAllBtn.Text = i18n.t("dlg_allmov");
		}

		private void mainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			StreamWriter strm = new StreamWriter( appFolder+"folders.dat", false);
			if (strm != null)
			{
				for (int i=0; i<moviesPath.Items.Count; i++)
				{
					strm.WriteLine( moviesPath.Items[i] );
				}
				strm.Close();
			}
		}

		private void pictureBox1_Click_1(object sender, System.EventArgs e)
		{
		
		}

		private void infoLog_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (infoLog.SelectedItem != null)
			{
				toolTip.SetToolTip(infoLog, infoLog.SelectedItem.ToString());
			}
		}

		private void formatInfo_Click(object sender, System.EventArgs e)
		{
			String msg = i18n.t("dlg_info_movie").Replace("%n", "\n");

			MessageBox.Show(msg, "Movie Renamer", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void outputFormat_Leave(object sender, System.EventArgs e)
		{
			StreamWriter strm = new StreamWriter( appFolder+"format.dat", false);
			if (strm != null)
			{
				strm.WriteLine( outputFormat.Text );
				strm.Close();
			}
		}

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }
	}
}
