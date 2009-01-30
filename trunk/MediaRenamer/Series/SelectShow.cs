// *******************************************************************************
//  Title:			SelectShow.cs
//  Description:	Dialog to select the best matching series if there are several
//					matches on episodeworld.com
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MediaRenamer;
using MediaRenamer.Common;

namespace MediaRenamer.Series
{
	/// <summary>
	/// Zusammenfassung für SelectShow.
	/// </summary>
	public class SelectShow : System.Windows.Forms.Form
	{
		public showClass selectedShow = null;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.ListBox showList;
		private System.Windows.Forms.Button btnSkip;
        private Label label1;
        private Label label2;
        private Label labelSeries;
        private Label labelEpisode;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectShow()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            this.btnOk = new System.Windows.Forms.Button();
            this.showList = new System.Windows.Forms.ListBox();
            this.btnSkip = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSeries = new System.Windows.Forms.Label();
            this.labelEpisode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(299, 261);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // showList
            // 
            this.showList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.showList.Location = new System.Drawing.Point(8, 47);
            this.showList.Name = "showList";
            this.showList.Size = new System.Drawing.Size(366, 199);
            this.showList.TabIndex = 1;
            this.showList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.showList_DrawItem);
            this.showList.SelectedIndexChanged += new System.EventHandler(this.showList_SelectedIndexChanged);
            this.showList.DoubleClick += new System.EventHandler(this.showList_DoubleClick);
            // 
            // btnSkip
            // 
            this.btnSkip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSkip.Location = new System.Drawing.Point(179, 261);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(112, 23);
            this.btnSkip.TabIndex = 2;
            this.btnSkip.Text = "Skip";
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Series";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Episode";
            // 
            // labelSeries
            // 
            this.labelSeries.AutoSize = true;
            this.labelSeries.Location = new System.Drawing.Point(67, 9);
            this.labelSeries.Name = "labelSeries";
            this.labelSeries.Size = new System.Drawing.Size(0, 13);
            this.labelSeries.TabIndex = 5;
            // 
            // labelEpisode
            // 
            this.labelEpisode.AutoSize = true;
            this.labelEpisode.Location = new System.Drawing.Point(67, 30);
            this.labelEpisode.Name = "labelEpisode";
            this.labelEpisode.Size = new System.Drawing.Size(0, 13);
            this.labelEpisode.TabIndex = 6;
            // 
            // SelectShow
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnSkip;
            this.ClientSize = new System.Drawing.Size(386, 296);
            this.Controls.Add(this.labelEpisode);
            this.Controls.Add(this.labelSeries);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.showList);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select the Show from the list";
            this.Load += new System.EventHandler(this.SelectShow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        public void setEpisodeData(Episode ep)
        {
            labelSeries.Text = ep.series;
            labelEpisode.Text = ep.season + "x" + ep.episode + ": " + ep.title;
        }

		public void addShow(showClass sc)
		{
			bool add=true;
			for (int i=0; i<showList.Items.Count; i++)
			{
				showClass sci = (showList.Items[i] as showClass);
				if (sci.ID == sc.ID) add = false;
				
			}
			if (add)
				showList.Items.Add( sc );
		}

		private void showList_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			if (e.Index < 0 || e.Index > showList.Items.Count)
				return;
			try
			{
				showClass sc = (showList.Items[e.Index] as showClass);
				e.DrawBackground();
				Brush b = Brushes.Black;
				e.Graphics.DrawString( sc.Name+" ("+sc.Year.ToString()+")", e.Font, b, e.Bounds);
				e.DrawFocusRectangle();
			}
			catch (Exception E)
			{
				Log.Add("DrawItem Error:\n"+E.Message);
			}
		}

		private void SelectShow_Load(object sender, System.EventArgs e)
		{
			if (showList.Items.Count > 0)
			{
				selectedShow = showList.Items[0] as showClass;
				showList.SelectedIndex = 0;
			}
			//btnOk.Text = i18n.t("btn_ok");
			//btnSkip.Text = i18n.t("btn_skip");
		}

		private void showList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			selectedShow = showList.SelectedItem as showClass;
		}

		private void showList_DoubleClick(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void btnSkip_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
    }
}
