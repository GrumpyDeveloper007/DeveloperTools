namespace DeveloperTools
{
    partial class frmModemInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModemInterface));
            this.txtData = new System.Windows.Forms.TextBox();
            this.ModemserialPort = new System.IO.Ports.SerialPort(this.components);
            this.butStart = new System.Windows.Forms.Button();
            this.chkLoop = new System.Windows.Forms.CheckBox();
            this.txtCommPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSendCommand = new System.Windows.Forms.ComboBox();
            this.butSam3gBaud = new System.Windows.Forms.Button();
            this.butSam3GConfigure = new System.Windows.Forms.Button();
            this.butTest = new System.Windows.Forms.Button();
            this.butKF2VersionTest = new System.Windows.Forms.Button();
            this.butKF2VersionTest2 = new System.Windows.Forms.Button();
            this.timerCheckRSSI = new System.Windows.Forms.Timer(this.components);
            this.chkCSQ = new System.Windows.Forms.CheckBox();
            this.txtCSQInterval = new System.Windows.Forms.TextBox();
            this.butClear = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.butNetwork = new System.Windows.Forms.Button();
            this.lblConnected = new System.Windows.Forms.Label();
            this.timerConnected = new System.Windows.Forms.Timer(this.components);
            this.butOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Location = new System.Drawing.Point(12, 39);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(428, 298);
            this.txtData.TabIndex = 1;
            this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // ModemserialPort
            // 
            this.ModemserialPort.DtrEnable = true;
            this.ModemserialPort.PortName = "COM6";
            this.ModemserialPort.RtsEnable = true;
            this.ModemserialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ModemserialPort_DataReceived);
            // 
            // butStart
            // 
            this.butStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butStart.Location = new System.Drawing.Point(446, 341);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(75, 23);
            this.butStart.TabIndex = 2;
            this.butStart.Text = "Read Status";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // chkLoop
            // 
            this.chkLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLoop.AutoSize = true;
            this.chkLoop.Location = new System.Drawing.Point(12, 347);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(50, 17);
            this.chkLoop.TabIndex = 3;
            this.chkLoop.Text = "Loop";
            this.chkLoop.UseVisualStyleBackColor = true;
            // 
            // txtCommPort
            // 
            this.txtCommPort.Location = new System.Drawing.Point(68, 12);
            this.txtCommPort.Name = "txtCommPort";
            this.txtCommPort.Size = new System.Drawing.Size(100, 20);
            this.txtCommPort.TabIndex = 5;
            this.txtCommPort.TextChanged += new System.EventHandler(this.txtCommPort_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Comm port";
            // 
            // cboSendCommand
            // 
            this.cboSendCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboSendCommand.FormattingEnabled = true;
            this.cboSendCommand.Items.AddRange(new object[] {
            "AT+GSN;+CIMI;+CCID",
            "AT$GETLOG",
            "at^ifcg?",
            "atd 0417619191"});
            this.cboSendCommand.Location = new System.Drawing.Point(68, 345);
            this.cboSendCommand.Name = "cboSendCommand";
            this.cboSendCommand.Size = new System.Drawing.Size(271, 21);
            this.cboSendCommand.TabIndex = 7;
            this.cboSendCommand.SelectedIndexChanged += new System.EventHandler(this.cboSendCommand_SelectedIndexChanged);
            this.cboSendCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSendCommand_KeyPress);
            // 
            // butSam3gBaud
            // 
            this.butSam3gBaud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSam3gBaud.Location = new System.Drawing.Point(446, 39);
            this.butSam3gBaud.Name = "butSam3gBaud";
            this.butSam3gBaud.Size = new System.Drawing.Size(88, 23);
            this.butSam3gBaud.TabIndex = 8;
            this.butSam3gBaud.Text = "Sam3G Baud";
            this.butSam3gBaud.UseVisualStyleBackColor = true;
            this.butSam3gBaud.Click += new System.EventHandler(this.butSam3gBaud_Click);
            // 
            // butSam3GConfigure
            // 
            this.butSam3GConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSam3GConfigure.Location = new System.Drawing.Point(446, 68);
            this.butSam3GConfigure.Name = "butSam3GConfigure";
            this.butSam3GConfigure.Size = new System.Drawing.Size(88, 23);
            this.butSam3GConfigure.TabIndex = 9;
            this.butSam3GConfigure.Text = "Sam3G Config";
            this.butSam3GConfigure.UseVisualStyleBackColor = true;
            this.butSam3GConfigure.Click += new System.EventHandler(this.butSam3GConfigure_Click);
            // 
            // butTest
            // 
            this.butTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTest.Location = new System.Drawing.Point(345, 343);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(75, 23);
            this.butTest.TabIndex = 10;
            this.butTest.Text = "Test";
            this.butTest.UseVisualStyleBackColor = true;
            this.butTest.Click += new System.EventHandler(this.butTest_Click);
            // 
            // butKF2VersionTest
            // 
            this.butKF2VersionTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butKF2VersionTest.Location = new System.Drawing.Point(446, 146);
            this.butKF2VersionTest.Name = "butKF2VersionTest";
            this.butKF2VersionTest.Size = new System.Drawing.Size(88, 23);
            this.butKF2VersionTest.TabIndex = 11;
            this.butKF2VersionTest.Text = "KF2VersionTest";
            this.butKF2VersionTest.UseVisualStyleBackColor = true;
            this.butKF2VersionTest.Click += new System.EventHandler(this.butKF2VersionTest_Click);
            // 
            // butKF2VersionTest2
            // 
            this.butKF2VersionTest2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butKF2VersionTest2.Location = new System.Drawing.Point(446, 175);
            this.butKF2VersionTest2.Name = "butKF2VersionTest2";
            this.butKF2VersionTest2.Size = new System.Drawing.Size(88, 23);
            this.butKF2VersionTest2.TabIndex = 12;
            this.butKF2VersionTest2.Text = "KF2Version2";
            this.butKF2VersionTest2.UseVisualStyleBackColor = true;
            this.butKF2VersionTest2.Click += new System.EventHandler(this.butKF2VersionTest2_Click);
            // 
            // timerCheckRSSI
            // 
            this.timerCheckRSSI.Interval = 60000;
            this.timerCheckRSSI.Tick += new System.EventHandler(this.timerCheckRSSI_Tick);
            // 
            // chkCSQ
            // 
            this.chkCSQ.AutoSize = true;
            this.chkCSQ.Location = new System.Drawing.Point(445, 12);
            this.chkCSQ.Name = "chkCSQ";
            this.chkCSQ.Size = new System.Drawing.Size(48, 17);
            this.chkCSQ.TabIndex = 13;
            this.chkCSQ.Text = "CSQ";
            this.chkCSQ.UseVisualStyleBackColor = true;
            this.chkCSQ.CheckedChanged += new System.EventHandler(this.chkCSQ_CheckedChanged);
            // 
            // txtCSQInterval
            // 
            this.txtCSQInterval.Location = new System.Drawing.Point(499, 12);
            this.txtCSQInterval.Name = "txtCSQInterval";
            this.txtCSQInterval.Size = new System.Drawing.Size(34, 20);
            this.txtCSQInterval.TabIndex = 14;
            this.txtCSQInterval.Text = "1";
            this.txtCSQInterval.TextChanged += new System.EventHandler(this.txtCSQInterval_TextChanged);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(376, 7);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(63, 24);
            this.butClear.TabIndex = 15;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(446, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // butNetwork
            // 
            this.butNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butNetwork.Location = new System.Drawing.Point(446, 279);
            this.butNetwork.Name = "butNetwork";
            this.butNetwork.Size = new System.Drawing.Size(88, 23);
            this.butNetwork.TabIndex = 18;
            this.butNetwork.Text = "Network";
            this.butNetwork.UseVisualStyleBackColor = true;
            this.butNetwork.Click += new System.EventHandler(this.butNetwork_Click);
            // 
            // lblConnected
            // 
            this.lblConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(451, 94);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(70, 13);
            this.lblConnected.TabIndex = 30;
            this.lblConnected.Text = "<connected>";
            // 
            // timerConnected
            // 
            this.timerConnected.Tick += new System.EventHandler(this.timerConnected_Tick);
            // 
            // butOpen
            // 
            this.butOpen.Location = new System.Drawing.Point(174, 8);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(63, 24);
            this.butOpen.TabIndex = 31;
            this.butOpen.Text = "Open";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // frmModemInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 378);
            this.Controls.Add(this.butOpen);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.butNetwork);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.txtCSQInterval);
            this.Controls.Add(this.chkCSQ);
            this.Controls.Add(this.butKF2VersionTest2);
            this.Controls.Add(this.butKF2VersionTest);
            this.Controls.Add(this.butTest);
            this.Controls.Add(this.butSam3GConfigure);
            this.Controls.Add(this.butSam3gBaud);
            this.Controls.Add(this.cboSendCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCommPort);
            this.Controls.Add(this.chkLoop);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.txtData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmModemInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modem Interface";
            this.Load += new System.EventHandler(this.frmModemInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtData;
        private System.IO.Ports.SerialPort ModemserialPort;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.CheckBox chkLoop;
        private System.Windows.Forms.TextBox txtCommPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSendCommand;
        private System.Windows.Forms.Button butSam3gBaud;
        private System.Windows.Forms.Button butSam3GConfigure;
        private System.Windows.Forms.Button butTest;
        private System.Windows.Forms.Button butKF2VersionTest;
        private System.Windows.Forms.Button butKF2VersionTest2;
        private System.Windows.Forms.Timer timerCheckRSSI;
        private System.Windows.Forms.CheckBox chkCSQ;
        private System.Windows.Forms.TextBox txtCSQInterval;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button butNetwork;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Timer timerConnected;
        private System.Windows.Forms.Button butOpen;
    }
}