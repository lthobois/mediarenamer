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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MediaRenamer;
using MediaRenamer.Common;

namespace MediaRenamer.Movies {
    /// <summary>
    /// Zusammenfassung für SelectMovie.
    /// </summary>
    public class SelectMovie : System.Windows.Forms.Form {
        public String selectedMovie = null;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.ListBox movieList;
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public SelectMovie() {
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
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code
        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMovie));
            this.btnOk = new System.Windows.Forms.Button();
            this.movieList = new System.Windows.Forms.ListBox();
            this.btnSkip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.AccessibleDescription = null;
            this.btnOk.AccessibleName = null;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.BackgroundImage = null;
            this.btnOk.Font = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // movieList
            // 
            this.movieList.AccessibleDescription = null;
            this.movieList.AccessibleName = null;
            resources.ApplyResources(this.movieList, "movieList");
            this.movieList.BackgroundImage = null;
            this.movieList.Font = null;
            this.movieList.Name = "movieList";
            this.movieList.SelectedIndexChanged += new System.EventHandler(this.showList_SelectedIndexChanged);
            this.movieList.DoubleClick += new System.EventHandler(this.showList_DoubleClick);
            // 
            // btnSkip
            // 
            this.btnSkip.AccessibleDescription = null;
            this.btnSkip.AccessibleName = null;
            resources.ApplyResources(this.btnSkip, "btnSkip");
            this.btnSkip.BackgroundImage = null;
            this.btnSkip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSkip.Font = null;
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // SelectMovie
            // 
            this.AcceptButton = this.btnOk;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.CancelButton = this.btnSkip;
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.movieList);
            this.Controls.Add(this.btnOk);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = null;
            this.Name = "SelectMovie";
            this.Load += new System.EventHandler(this.SelectMovie_Load);
            this.ResumeLayout(false);

        }
        #endregion

        public void addMovie(String movieName) {
            movieList.Items.Add(movieName);
        }

        private void SelectMovie_Load(object sender, System.EventArgs e) {
            //btnOk.Text = i18n.t("btn_ok");
            //btnSkip.Text = i18n.t("btn_skip");
        }

        private void showList_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (selectedMovie != null) {
                selectedMovie = movieList.SelectedItem.ToString();
            }
        }

        private void showList_DoubleClick(object sender, System.EventArgs e) {
            if (movieList.SelectedItems.Count > 0) {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnSkip_Click(object sender, System.EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, System.EventArgs e) {
            DialogResult = DialogResult.OK;
        }
    }
}
