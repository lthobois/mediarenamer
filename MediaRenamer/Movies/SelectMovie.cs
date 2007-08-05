// *******************************************************************************
//  Title:			SelectMovie.cs
//  Description:	Dialog to select the Movie from a list of possible matches
//  Author:			Benjamin Schirmer (www.codename-matrix.de)
// *******************************************************************************

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MediaRenamer;
using MediaRenamer.Common;

namespace MovieRenamer
{
	/// <summary>
	/// Zusammenfassung für SelectMovie.
	/// </summary>
	public class SelectMovie : System.Windows.Forms.Form
	{
		public String selectedMovie = null;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnSkip;
		private System.Windows.Forms.ListBox movieList;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectMovie()
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
			this.movieList = new System.Windows.Forms.ListBox();
			this.btnSkip = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(304, 176);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// movieList
			// 
			this.movieList.Location = new System.Drawing.Point(8, 8);
			this.movieList.Name = "movieList";
			this.movieList.Size = new System.Drawing.Size(368, 160);
			this.movieList.TabIndex = 1;
			this.movieList.DoubleClick += new System.EventHandler(this.showList_DoubleClick);
			this.movieList.SelectedIndexChanged += new System.EventHandler(this.showList_SelectedIndexChanged);
			// 
			// btnSkip
			// 
			this.btnSkip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSkip.Location = new System.Drawing.Point(184, 176);
			this.btnSkip.Name = "btnSkip";
			this.btnSkip.Size = new System.Drawing.Size(112, 23);
			this.btnSkip.TabIndex = 2;
			this.btnSkip.Text = "Skip";
			this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
			// 
			// SelectMovie
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnSkip;
			this.ClientSize = new System.Drawing.Size(384, 208);
			this.Controls.Add(this.btnSkip);
			this.Controls.Add(this.movieList);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SelectMovie";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select the Movie from the list";
			this.Load += new System.EventHandler(this.SelectMovie_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public void addMovie(String movieName)
		{
			movieList.Items.Add( movieName );
		}

		private void SelectMovie_Load(object sender, System.EventArgs e)
		{
			btnOk.Text = i18n.t("btn_ok");
			btnSkip.Text = i18n.t("btn_skip");
		}

		private void showList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			selectedMovie = movieList.SelectedItem.ToString();
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
