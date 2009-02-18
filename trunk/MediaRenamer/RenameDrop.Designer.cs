namespace MediaRenamer
{
    partial class RenameDrop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.progressTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // progressLayout
            // 
            this.progressLayout.Location = new System.Drawing.Point(0, 64);
            this.progressLayout.Name = "progressLayout";
            this.progressLayout.Size = new System.Drawing.Size(64, 100);
            this.progressLayout.TabIndex = 0;
            // 
            // RenameDrop
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(48, 30);
            this.Controls.Add(this.progressLayout);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(64, 256);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(64, 64);
            this.Name = "RenameDrop";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = " ";
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RenameDrop_Paint);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.RenameDrop_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.RenameDrop_DragEnter);
            this.Resize += new System.EventHandler(this.RenameDrop_Resize);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.RenameDrop_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel progressLayout;
        private System.Windows.Forms.ToolTip progressTooltip;



    }
}