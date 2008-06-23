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

namespace TVShowRenamer
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
			// showList
			// 
			this.showList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.showList.Location = new System.Drawing.Point(8, 8);
			this.showList.Name = "showList";
			this.showList.Size = new System.Drawing.Size(368, 160);
			this.showList.TabIndex = 1;
			this.showList.DoubleClick += new System.EventHandler(this.showList_DoubleClick);
			this.showList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.showList_DrawItem);
			this.showList.SelectedIndexChanged += new System.EventHandler(this.showList_SelectedIndexChanged);
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
			// SelectShow
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnSkip;
			this.ClientSize = new System.Drawing.Size(384, 208);
			this.Controls.Add(this.btnSkip);
			this.Controls.Add(this.showList);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SelectShow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select the Show from the list";
			this.Load += new System.EventHandler(this.SelectShow_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public void addShow(showClass sc)
		{
			bool add=true;
			for (int i=0; i<showList.Items.Count; i++)
			{
				showClass sci = (showList.Items[i] as showClass);
				if (sci.showID == sc.showID) add = false;
				
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
				e.Graphics.DrawString( sc.showName+" ("+sc.showYear.ToString()+")", e.Font, b, e.Bounds);
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
