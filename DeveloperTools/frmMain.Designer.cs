namespace DeveloperTools
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modemSimulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modemInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qVCSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readTestDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(558, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modemSimulatorToolStripMenuItem,
            this.modemInterfaceToolStripMenuItem,
            this.qVCSToolStripMenuItem,
            this.logViewToolStripMenuItem,
            this.tCPIPToolStripMenuItem,
            this.readTestDocumentationToolStripMenuItem,
            this.xMLToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // modemSimulatorToolStripMenuItem
            // 
            this.modemSimulatorToolStripMenuItem.Name = "modemSimulatorToolStripMenuItem";
            this.modemSimulatorToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.modemSimulatorToolStripMenuItem.Text = "Modem Simulator";
            this.modemSimulatorToolStripMenuItem.Click += new System.EventHandler(this.modemSimulatorToolStripMenuItem_Click);
            // 
            // modemInterfaceToolStripMenuItem
            // 
            this.modemInterfaceToolStripMenuItem.Name = "modemInterfaceToolStripMenuItem";
            this.modemInterfaceToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.modemInterfaceToolStripMenuItem.Text = "Modem Interface";
            this.modemInterfaceToolStripMenuItem.Click += new System.EventHandler(this.modemInterfaceToolStripMenuItem_Click);
            // 
            // qVCSToolStripMenuItem
            // 
            this.qVCSToolStripMenuItem.Name = "qVCSToolStripMenuItem";
            this.qVCSToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.qVCSToolStripMenuItem.Text = "QVCS";
            this.qVCSToolStripMenuItem.Click += new System.EventHandler(this.qVCSToolStripMenuItem_Click);
            // 
            // logViewToolStripMenuItem
            // 
            this.logViewToolStripMenuItem.Name = "logViewToolStripMenuItem";
            this.logViewToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.logViewToolStripMenuItem.Text = "Log View";
            this.logViewToolStripMenuItem.Click += new System.EventHandler(this.logViewToolStripMenuItem_Click);
            // 
            // tCPIPToolStripMenuItem
            // 
            this.tCPIPToolStripMenuItem.Name = "tCPIPToolStripMenuItem";
            this.tCPIPToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.tCPIPToolStripMenuItem.Text = "TCPIP";
            this.tCPIPToolStripMenuItem.Click += new System.EventHandler(this.tCPIPToolStripMenuItem_Click);
            // 
            // readTestDocumentationToolStripMenuItem
            // 
            this.readTestDocumentationToolStripMenuItem.Name = "readTestDocumentationToolStripMenuItem";
            this.readTestDocumentationToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.readTestDocumentationToolStripMenuItem.Text = "Read Test Documentation";
            this.readTestDocumentationToolStripMenuItem.Click += new System.EventHandler(this.readTestDocumentationToolStripMenuItem_Click);
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.xMLToolStripMenuItem.Text = "XML";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.xMLToolStripMenuItem_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(12, 27);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(524, 50);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = resources.GetString("txtInput.Text");
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(12, 83);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(524, 59);
            this.txtOutput.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 346);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Developer Tools";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modemSimulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modemInterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qVCSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCPIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readTestDocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
    }
}

