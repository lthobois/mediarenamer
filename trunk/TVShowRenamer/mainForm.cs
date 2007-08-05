// *******************************************************************************
//  Title:			mainForm.cs
//  Description:	Main Form for TVShowRenamer
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Microsoft.Win32;
using MediaRenamer;

namespace TVShowRenamer
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
		private System.Windows.Forms.ComboBox seriesPath;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.TextBox outputFormat;
		private System.Windows.Forms.Button formatInfo;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.ListBox infoLog;
		private System.Windows.Forms.Button renBtn;
		private System.Windows.Forms.Button renAllBtn;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelOutput;
		private System.Windows.Forms.GroupBox renameGroup;
		public System.Windows.Forms.ListBox fileList;
		private System.Windows.Forms.PictureBox epwLogo;
		private System.Windows.Forms.GroupBox scanGroup;
		private System.Windows.Forms.Button scanBtn;
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
			appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\TVShowRenamer\";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(mainForm));
			this.seriesPathBtn = new System.Windows.Forms.Button();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.fileList = new System.Windows.Forms.ListBox();
			this.details = new System.Windows.Forms.TextBox();
			this.seriesPath = new System.Windows.Forms.ComboBox();
			this.labelPath = new System.Windows.Forms.Label();
			this.labelOutput = new System.Windows.Forms.Label();
			this.outputFormat = new System.Windows.Forms.TextBox();
			this.formatInfo = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.scanGroup = new System.Windows.Forms.GroupBox();
			this.scanBtn = new System.Windows.Forms.Button();
			this.infoLog = new System.Windows.Forms.ListBox();
			this.epwLogo = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.renameGroup = new System.Windows.Forms.GroupBox();
			this.renAllBtn = new System.Windows.Forms.Button();
			this.renBtn = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.scanGroup.SuspendLayout();
			this.renameGroup.SuspendLayout();
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
			this.fileList.TabIndex = 3;
			this.fileList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fileList_KeyUp);
			this.fileList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.fileList_DrawItem);
			this.fileList.SelectedIndexChanged += new System.EventHandler(this.fileList_SelectedIndexChanged);
			// 
			// details
			// 
			this.details.Location = new System.Drawing.Point(176, 360);
			this.details.Name = "details";
			this.details.ReadOnly = true;
			this.details.Size = new System.Drawing.Size(480, 20);
			this.details.TabIndex = 4;
			this.details.Text = "";
			// 
			// seriesPath
			// 
			this.seriesPath.Location = new System.Drawing.Point(264, 32);
			this.seriesPath.Name = "seriesPath";
			this.seriesPath.Size = new System.Drawing.Size(360, 21);
			this.seriesPath.TabIndex = 7;
			// 
			// labelPath
			// 
			this.labelPath.Location = new System.Drawing.Point(176, 32);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(88, 23);
			this.labelPath.TabIndex = 9;
			this.labelPath.Text = "Path:";
			this.labelPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelOutput
			// 
			this.labelOutput.Location = new System.Drawing.Point(176, 8);
			this.labelOutput.Name = "labelOutput";
			this.labelOutput.Size = new System.Drawing.Size(88, 23);
			this.labelOutput.TabIndex = 10;
			this.labelOutput.Text = "Output Format:";
			this.labelOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// outputFormat
			// 
			this.outputFormat.Location = new System.Drawing.Point(264, 8);
			this.outputFormat.Name = "outputFormat";
			this.outputFormat.Size = new System.Drawing.Size(360, 20);
			this.outputFormat.TabIndex = 11;
			this.outputFormat.Text = "<series> - <season>x<episode><title: - ><title>";
			this.outputFormat.Leave += new System.EventHandler(this.outputFormat_Leave);
			// 
			// formatInfo
			// 
			this.formatInfo.Location = new System.Drawing.Point(632, 8);
			this.formatInfo.Name = "formatInfo";
			this.formatInfo.Size = new System.Drawing.Size(24, 23);
			this.formatInfo.TabIndex = 12;
			this.formatInfo.Text = "?";
			this.formatInfo.Click += new System.EventHandler(this.formatInfo_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.scanGroup);
			this.panel1.Controls.Add(this.infoLog);
			this.panel1.Controls.Add(this.epwLogo);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.renameGroup);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(168, 392);
			this.panel1.TabIndex = 13;
			// 
			// scanGroup
			// 
			this.scanGroup.Controls.Add(this.scanBtn);
			this.scanGroup.Location = new System.Drawing.Point(8, 64);
			this.scanGroup.Name = "scanGroup";
			this.scanGroup.Size = new System.Drawing.Size(152, 48);
			this.scanGroup.TabIndex = 23;
			this.scanGroup.TabStop = false;
			this.scanGroup.Text = "Scanner/Parser";
			// 
			// scanBtn
			// 
			this.scanBtn.BackColor = System.Drawing.SystemColors.Control;
			this.scanBtn.Location = new System.Drawing.Point(8, 16);
			this.scanBtn.Name = "scanBtn";
			this.scanBtn.Size = new System.Drawing.Size(136, 23);
			this.scanBtn.TabIndex = 12;
			this.scanBtn.Text = "Scan Series";
			this.scanBtn.Click += new System.EventHandler(this.scanBtn_Click);
			// 
			// infoLog
			// 
			this.infoLog.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.infoLog.Font = new System.Drawing.Font("Arial", 6.75F);
			this.infoLog.ItemHeight = 12;
			this.infoLog.Location = new System.Drawing.Point(0, 204);
			this.infoLog.Name = "infoLog";
			this.infoLog.Size = new System.Drawing.Size(168, 148);
			this.infoLog.TabIndex = 9;
			this.toolTip.SetToolTip(this.infoLog, "InfoLog");
			this.infoLog.SelectedIndexChanged += new System.EventHandler(this.infoLog_SelectedIndexChanged);
			// 
			// epwLogo
			// 
			this.epwLogo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.epwLogo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.epwLogo.Image = ((System.Drawing.Image)(resources.GetObject("epwLogo.Image")));
			this.epwLogo.Location = new System.Drawing.Point(0, 352);
			this.epwLogo.Name = "epwLogo";
			this.epwLogo.Size = new System.Drawing.Size(168, 40);
			this.epwLogo.TabIndex = 22;
			this.epwLogo.TabStop = false;
			this.epwLogo.Click += new System.EventHandler(this.epwLogo_Click);
			this.epwLogo.MouseHover += new System.EventHandler(this.epwLogo_MouseHover);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 48);
			this.label2.TabIndex = 20;
			this.label2.Text = "TV Show Renamer";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// renameGroup
			// 
			this.renameGroup.Controls.Add(this.renAllBtn);
			this.renameGroup.Controls.Add(this.renBtn);
			this.renameGroup.Location = new System.Drawing.Point(8, 120);
			this.renameGroup.Name = "renameGroup";
			this.renameGroup.Size = new System.Drawing.Size(152, 80);
			this.renameGroup.TabIndex = 10;
			this.renameGroup.TabStop = false;
			this.renameGroup.Text = "Rename";
			// 
			// renAllBtn
			// 
			this.renAllBtn.BackColor = System.Drawing.SystemColors.Control;
			this.renAllBtn.Enabled = false;
			this.renAllBtn.Location = new System.Drawing.Point(8, 48);
			this.renAllBtn.Name = "renAllBtn";
			this.renAllBtn.Size = new System.Drawing.Size(136, 23);
			this.renAllBtn.TabIndex = 7;
			this.renAllBtn.Text = "all Episodes";
			this.renAllBtn.Click += new System.EventHandler(this.renAllBtn_Click);
			// 
			// renBtn
			// 
			this.renBtn.BackColor = System.Drawing.SystemColors.Control;
			this.renBtn.Enabled = false;
			this.renBtn.Location = new System.Drawing.Point(8, 16);
			this.renBtn.Name = "renBtn";
			this.renBtn.Size = new System.Drawing.Size(136, 23);
			this.renBtn.TabIndex = 6;
			this.renBtn.Text = "selected Episode";
			this.renBtn.Click += new System.EventHandler(this.renBtn_Click);
			// 
			// mainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 392);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.formatInfo);
			this.Controls.Add(this.outputFormat);
			this.Controls.Add(this.details);
			this.Controls.Add(this.labelOutput);
			this.Controls.Add(this.labelPath);
			this.Controls.Add(this.seriesPath);
			this.Controls.Add(this.fileList);
			this.Controls.Add(this.seriesPathBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "mainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TV Series Renamer";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.mainForm_Closing);
			this.Load += new System.EventHandler(this.mainForm_Load);
			this.panel1.ResumeLayout(false);
			this.scanGroup.ResumeLayout(false);
			this.renameGroup.ResumeLayout(false);
			this.ResumeLayout(false);

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
			folderBrowserDialog.SelectedPath = seriesPath.Text;
			folderBrowserDialog.ShowNewFolderButton = false;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				seriesPath.Text = folderBrowserDialog.SelectedPath;
				if (seriesPath.Items.IndexOf(folderBrowserDialog.SelectedPath) < 0)
				{
					seriesPath.Items.Insert(0, folderBrowserDialog.SelectedPath);
				}
			}
		}

		private void scanBtn_Click(object sender, System.EventArgs e)
		{
			if (seriesPath.Text.Length == 0)
			{
				MessageBox.Show(i18n.t("scan_empty"));
				return;
			}

			if (!Directory.Exists(seriesPath.Text))
			{
				MessageBox.Show(i18n.t("scan_path"));
				seriesPath.Items.Remove( seriesPath.Text );
				return;
			}
			if (seriesPath.Items.IndexOf( seriesPath.Text ) == -1)
			{
				seriesPath.Items.Add( seriesPath.Text );
			}
			fileList.BeginUpdate();
			details.Text = "";
			fileList.Items.Clear();
			infoLog.Items.Clear();

			scanBtn.Enabled = false;
			renAllBtn.Enabled = false;
			renBtn.Enabled = false;

			Log.Add(i18n.t("scan_start"));
			Parser parse = new Parser(seriesPath.Text, fileList);
			parse.startScan();
			
			scanBtn.Enabled = true;
			renAllBtn.Enabled = (fileList.Items.Count > 0);
			renBtn.Enabled = (fileList.Items.Count > 0);

			Log.Add(i18n.t("scan_end"));
			fileList.EndUpdate();
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
				Episode ep = (fileList.Items[e.Index] as Episode);
				e.DrawBackground();
				Brush b = Brushes.Black;
				if (!ep.needRenaming())
				{
					b = Brushes.Red;
				}
				else
				{
					b = Brushes.DarkGreen;
				}
				if (ep.special)
				{
					b = Brushes.DarkRed;
				}
				Font f = new Font(FontFamily.GenericMonospace, e.Font.Size);
				e.Graphics.DrawString( ep.ToString(), f, b, e.Bounds);
				e.DrawFocusRectangle();
			}
			catch (Exception E)
			{
				Log.Add("DrawItem Error:\n"+E.Message);
			}
		}

		private void fileList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (fileList.SelectedItem != null)
			{
				details.Text = (fileList.SelectedItem as Episode).ToString();
				renBtn.Enabled = true;
			}
			else
			{
				renBtn.Enabled = false;
			}
			renAllBtn.Enabled = (fileList.Items.Count > 0);
		}

		private void renameEpisode(Episode ep)
		{
			FileInfo fi = new FileInfo(ep.filename);
			try
			{
				String dir = fi.DirectoryName;
				if (!dir.EndsWith(@"\")) dir += @"\";
				fi.MoveTo(dir+ep.modifiedName()+fi.Extension);
			}
			catch (Exception E)
			{
				Log.Add( i18n.t("dlg_error_io",fi.Name)+":\n\n"+E.Message);
			}
		}

		private void renBtn_Click(object sender, System.EventArgs e)
		{
			int idx = fileList.SelectedIndex;
			renameEpisode(fileList.Items[idx] as Episode);
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
				renameEpisode(fileList.Items[i] as Episode);
			}
			fileList.Items.Clear();
			renAllBtn.Enabled = (fileList.Items.Count > 0);
			renBtn.Enabled = (fileList.Items.Count > 0);
		}

		private void mainForm_Load(object sender, System.EventArgs e)
		{
			if (File.Exists(appFolder+"folders.dat"))
			{
				StreamReader strm = new StreamReader(appFolder+"folders.dat");
				if (strm != null)
				{
					String line = null;
					while ( (line = strm.ReadLine() ) != null)
					{
						seriesPath.Items.Add( line );
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

			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\MediaRenamer", true);
			key.CreateSubKey("Series");
			key.Close();

			labelOutput.Text = i18n.t("dlg_output");
			labelPath.Text = i18n.t("dlg_path");
			scanBtn.Text = i18n.t("dlg_scanseries");
			renameGroup.Text = i18n.t("dlg_rename");
			scanGroup.Text = i18n.t("dlg_scanner");
			renBtn.Text = i18n.t("dlg_renep");
			renAllBtn.Text = i18n.t("dlg_allep");
		}

		private void mainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			StreamWriter strm = new StreamWriter( appFolder+"folders.dat", false);
			if (strm != null)
			{
				for (int i=0; i<seriesPath.Items.Count; i++)
				{
					strm.WriteLine( seriesPath.Items[i] );
				}
				strm.Close();
			}
		}

		private void formatInfo_Click(object sender, System.EventArgs e)
		{
			String msg = i18n.t("dlg_info_show").Replace("%n", "\n");

			MessageBox.Show(msg, "TV Show Renamer", MessageBoxButtons.OK, MessageBoxIcon.Information);			 
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

		private void fileList_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (fileList.Items.Count > 0)
			{
				int idx = fileList.SelectedIndex;
				if (idx < 0 || idx >= fileList.Items.Count) return;
				if (e.KeyCode == Keys.Enter)
				{
					renameEpisode(fileList.Items[idx] as Episode);
					fileList.Items.RemoveAt(idx);
					if (fileList.Items.Count > idx)
						fileList.SelectedIndex = idx;
				}
			}
		}

		private void infoLog_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (infoLog.SelectedItem != null)
			{
				toolTip.SetToolTip(infoLog, infoLog.SelectedItem.ToString());
			}
		}

		private void epwLogo_MouseHover(object sender, System.EventArgs e)
		{
			toolTip.SetToolTip( sender as Control, "EpisodeData provided by episodeworld.com");
		}

		private void epwLogo_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.episodeworld.com/");
		}
	}
}
