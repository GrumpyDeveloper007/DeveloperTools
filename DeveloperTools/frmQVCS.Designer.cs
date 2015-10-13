namespace DeveloperTools
{
    partial class frmQVCS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQVCS));
            this.GridViewLog = new System.Windows.Forms.DataGridView();
            this.Revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstLabels = new System.Windows.Forms.ListBox();
            this.butCreateSvnArchive = new System.Windows.Forms.Button();
            this.txtStartRevision = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndRevision = new System.Windows.Forms.TextBox();
            this.butShow = new System.Windows.Forms.Button();
            this.butScanQVCS = new System.Windows.Forms.Button();
            this.txtReport = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLog)).BeginInit();
            this.SuspendLayout();
            // 
            // GridViewLog
            // 
            this.GridViewLog.AllowUserToAddRows = false;
            this.GridViewLog.AllowUserToResizeRows = false;
            this.GridViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridViewLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Revision,
            this.Label,
            this.Description});
            this.GridViewLog.Location = new System.Drawing.Point(257, 12);
            this.GridViewLog.Name = "GridViewLog";
            this.GridViewLog.Size = new System.Drawing.Size(460, 238);
            this.GridViewLog.TabIndex = 9;
            // 
            // Revision
            // 
            this.Revision.HeaderText = "Revision";
            this.Revision.Name = "Revision";
            this.Revision.ReadOnly = true;
            this.Revision.Width = 150;
            // 
            // Label
            // 
            this.Label.HeaderText = "Label";
            this.Label.Name = "Label";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 150;
            // 
            // lstLabels
            // 
            this.lstLabels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstLabels.FormattingEnabled = true;
            this.lstLabels.Location = new System.Drawing.Point(12, 12);
            this.lstLabels.Name = "lstLabels";
            this.lstLabels.Size = new System.Drawing.Size(239, 238);
            this.lstLabels.TabIndex = 10;
            this.lstLabels.SelectedIndexChanged += new System.EventHandler(this.lstLabels_SelectedIndexChanged);
            // 
            // butCreateSvnArchive
            // 
            this.butCreateSvnArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCreateSvnArchive.Location = new System.Drawing.Point(958, 12);
            this.butCreateSvnArchive.Name = "butCreateSvnArchive";
            this.butCreateSvnArchive.Size = new System.Drawing.Size(75, 23);
            this.butCreateSvnArchive.TabIndex = 11;
            this.butCreateSvnArchive.Text = "CreateSvn";
            this.butCreateSvnArchive.UseVisualStyleBackColor = true;
            this.butCreateSvnArchive.Click += new System.EventHandler(this.butCreateSvnArchive_Click);
            // 
            // txtStartRevision
            // 
            this.txtStartRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartRevision.Location = new System.Drawing.Point(916, 60);
            this.txtStartRevision.Name = "txtStartRevision";
            this.txtStartRevision.Size = new System.Drawing.Size(117, 20);
            this.txtStartRevision.TabIndex = 12;
            this.txtStartRevision.Text = "S00244-05.05.D65";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(848, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(848, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "End";
            // 
            // txtEndRevision
            // 
            this.txtEndRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndRevision.Location = new System.Drawing.Point(916, 86);
            this.txtEndRevision.Name = "txtEndRevision";
            this.txtEndRevision.Size = new System.Drawing.Size(117, 20);
            this.txtEndRevision.TabIndex = 14;
            this.txtEndRevision.Text = "S00244-05.05.D66";
            // 
            // butShow
            // 
            this.butShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butShow.Location = new System.Drawing.Point(958, 112);
            this.butShow.Name = "butShow";
            this.butShow.Size = new System.Drawing.Size(75, 23);
            this.butShow.TabIndex = 16;
            this.butShow.Text = "Show";
            this.butShow.UseVisualStyleBackColor = true;
            this.butShow.Click += new System.EventHandler(this.butShow_Click);
            // 
            // butScanQVCS
            // 
            this.butScanQVCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butScanQVCS.Location = new System.Drawing.Point(851, 12);
            this.butScanQVCS.Name = "butScanQVCS";
            this.butScanQVCS.Size = new System.Drawing.Size(75, 23);
            this.butScanQVCS.TabIndex = 17;
            this.butScanQVCS.Text = "Scan QVCS";
            this.butScanQVCS.UseVisualStyleBackColor = true;
            this.butScanQVCS.Click += new System.EventHandler(this.butScanQVCS_Click);
            // 
            // txtReport
            // 
            this.txtReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReport.Location = new System.Drawing.Point(723, 144);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(309, 106);
            this.txtReport.TabIndex = 18;
            this.txtReport.Click += new System.EventHandler(this.txtReport_Click);
            // 
            // frmQVCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 262);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.butScanQVCS);
            this.Controls.Add(this.butShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEndRevision);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStartRevision);
            this.Controls.Add(this.butCreateSvnArchive);
            this.Controls.Add(this.lstLabels);
            this.Controls.Add(this.GridViewLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQVCS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmQVCS";
            this.Load += new System.EventHandler(this.frmQVCS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridViewLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.ListBox lstLabels;
        private System.Windows.Forms.Button butCreateSvnArchive;
        private System.Windows.Forms.TextBox txtStartRevision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndRevision;
        private System.Windows.Forms.Button butShow;
        private System.Windows.Forms.Button butScanQVCS;
        private System.Windows.Forms.TextBox txtReport;
    }
}