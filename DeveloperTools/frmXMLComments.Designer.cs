namespace DeveloperTools
{
    partial class frmXMLComments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMLComments));
            this.butScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butScan
            // 
            this.butScan.Location = new System.Drawing.Point(12, 227);
            this.butScan.Name = "butScan";
            this.butScan.Size = new System.Drawing.Size(75, 23);
            this.butScan.TabIndex = 0;
            this.butScan.Text = "Scan";
            this.butScan.UseVisualStyleBackColor = true;
            this.butScan.Click += new System.EventHandler(this.butScan_Click);
            // 
            // frmXMLComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.butScan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXMLComments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "XML Comments";
            this.Load += new System.EventHandler(this.frmXMLComments_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butScan;
    }
}