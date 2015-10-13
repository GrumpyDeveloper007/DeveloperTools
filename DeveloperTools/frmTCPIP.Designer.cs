namespace DeveloperTools
{
    partial class frmTCPIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTCPIP));
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkPinConsole = new System.Windows.Forms.CheckBox();
            this.butTest = new System.Windows.Forms.Button();
            this.butConnect = new System.Windows.Forms.Button();
            this.butDisConnect = new System.Windows.Forms.Button();
            this.chkConnected = new System.Windows.Forms.CheckBox();
            this.cboIPAddress = new System.Windows.Forms.ComboBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butClear = new System.Windows.Forms.Button();
            this.lblConnected = new System.Windows.Forms.Label();
            this.timerConnected = new System.Windows.Forms.Timer(this.components);
            this.chkRepeatTest = new System.Windows.Forms.CheckBox();
            this.timerConnectionTest = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtOptical = new System.Windows.Forms.TextBox();
            this.ModemserialPort = new System.IO.Ports.SerialPort(this.components);
            this.butCSQSend = new System.Windows.Forms.Button();
            this.butOKSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.Location = new System.Drawing.Point(72, 39);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(520, 247);
            this.txtConsole.TabIndex = 0;
            this.txtConsole.TextChanged += new System.EventHandler(this.txtConsole_TextChanged);
            this.txtConsole.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsole_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "IP Address";
            // 
            // chkPinConsole
            // 
            this.chkPinConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPinConsole.AutoSize = true;
            this.chkPinConsole.Checked = true;
            this.chkPinConsole.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPinConsole.Location = new System.Drawing.Point(553, 16);
            this.chkPinConsole.Name = "chkPinConsole";
            this.chkPinConsole.Size = new System.Drawing.Size(41, 17);
            this.chkPinConsole.TabIndex = 18;
            this.chkPinConsole.Text = "Pin";
            this.chkPinConsole.UseVisualStyleBackColor = true;
            // 
            // butTest
            // 
            this.butTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butTest.Location = new System.Drawing.Point(598, 125);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(75, 23);
            this.butTest.TabIndex = 19;
            this.butTest.Text = "Test";
            this.butTest.UseVisualStyleBackColor = true;
            this.butTest.Click += new System.EventHandler(this.butTest_Click);
            // 
            // butConnect
            // 
            this.butConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butConnect.Location = new System.Drawing.Point(598, 54);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(75, 23);
            this.butConnect.TabIndex = 20;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // butDisConnect
            // 
            this.butDisConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDisConnect.Location = new System.Drawing.Point(598, 83);
            this.butDisConnect.Name = "butDisConnect";
            this.butDisConnect.Size = new System.Drawing.Size(75, 23);
            this.butDisConnect.TabIndex = 21;
            this.butDisConnect.Text = "Dis-connect";
            this.butDisConnect.UseVisualStyleBackColor = true;
            this.butDisConnect.Click += new System.EventHandler(this.butDisConnect_Click);
            // 
            // chkConnected
            // 
            this.chkConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkConnected.AutoSize = true;
            this.chkConnected.Enabled = false;
            this.chkConnected.Location = new System.Drawing.Point(600, 15);
            this.chkConnected.Name = "chkConnected";
            this.chkConnected.Size = new System.Drawing.Size(81, 17);
            this.chkConnected.TabIndex = 22;
            this.chkConnected.Text = "Connected ";
            this.chkConnected.UseVisualStyleBackColor = true;
            this.chkConnected.CheckedChanged += new System.EventHandler(this.chkConnected_CheckedChanged);
            // 
            // cboIPAddress
            // 
            this.cboIPAddress.FormattingEnabled = true;
            this.cboIPAddress.Items.AddRange(new object[] {
            "59.167.17.245",
            "123.209.161.68",
            "123.209.31.74",
            "123.209.139.138",
            "123.209.162.90",
            "59.167.162.199"});
            this.cboIPAddress.Location = new System.Drawing.Point(72, 12);
            this.cboIPAddress.Name = "cboIPAddress";
            this.cboIPAddress.Size = new System.Drawing.Size(115, 21);
            this.cboIPAddress.TabIndex = 23;
            this.cboIPAddress.Text = "59.167.162.199";
            this.cboIPAddress.SelectedIndexChanged += new System.EventHandler(this.cboIPAddress_SelectedIndexChanged);
            this.cboIPAddress.TextChanged += new System.EventHandler(this.cboIPAddress_TextChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(225, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(38, 20);
            this.txtPort.TabIndex = 24;
            this.txtPort.Text = "7451";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Port";
            // 
            // butClear
            // 
            this.butClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butClear.Location = new System.Drawing.Point(471, 8);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(75, 23);
            this.butClear.TabIndex = 28;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // lblConnected
            // 
            this.lblConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(601, 35);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(70, 13);
            this.lblConnected.TabIndex = 29;
            this.lblConnected.Text = "<connected>";
            // 
            // timerConnected
            // 
            this.timerConnected.Tick += new System.EventHandler(this.timerConnected_Tick);
            // 
            // chkRepeatTest
            // 
            this.chkRepeatTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRepeatTest.AutoSize = true;
            this.chkRepeatTest.Location = new System.Drawing.Point(599, 164);
            this.chkRepeatTest.Name = "chkRepeatTest";
            this.chkRepeatTest.Size = new System.Drawing.Size(85, 17);
            this.chkRepeatTest.TabIndex = 30;
            this.chkRepeatTest.Text = "Repeat Test";
            this.chkRepeatTest.UseVisualStyleBackColor = true;
            this.chkRepeatTest.CheckedChanged += new System.EventHandler(this.chkRepeatTest_CheckedChanged);
            // 
            // timerConnectionTest
            // 
            this.timerConnectionTest.Interval = 1000;
            this.timerConnectionTest.Tick += new System.EventHandler(this.timerConnectionTest_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Optical";
            // 
            // txtOptical
            // 
            this.txtOptical.Location = new System.Drawing.Point(319, 11);
            this.txtOptical.Name = "txtOptical";
            this.txtOptical.Size = new System.Drawing.Size(22, 20);
            this.txtOptical.TabIndex = 31;
            this.txtOptical.Text = "6";
            this.txtOptical.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ModemserialPort
            // 
            this.ModemserialPort.PortName = "COM6";
            this.ModemserialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ModemserialPort_DataReceived);
            // 
            // butCSQSend
            // 
            this.butCSQSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCSQSend.Location = new System.Drawing.Point(598, 187);
            this.butCSQSend.Name = "butCSQSend";
            this.butCSQSend.Size = new System.Drawing.Size(75, 23);
            this.butCSQSend.TabIndex = 33;
            this.butCSQSend.Text = "CSQ Send";
            this.butCSQSend.UseVisualStyleBackColor = true;
            this.butCSQSend.Click += new System.EventHandler(this.butCSQSend_Click);
            // 
            // butOKSend
            // 
            this.butOKSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOKSend.Location = new System.Drawing.Point(599, 216);
            this.butOKSend.Name = "butOKSend";
            this.butOKSend.Size = new System.Drawing.Size(75, 23);
            this.butOKSend.TabIndex = 34;
            this.butOKSend.Text = "OK Send";
            this.butOKSend.UseVisualStyleBackColor = true;
            this.butOKSend.Click += new System.EventHandler(this.butOKSend_Click);
            // 
            // frmTCPIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 306);
            this.Controls.Add(this.butOKSend);
            this.Controls.Add(this.butCSQSend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOptical);
            this.Controls.Add(this.chkRepeatTest);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.cboIPAddress);
            this.Controls.Add(this.chkConnected);
            this.Controls.Add(this.butDisConnect);
            this.Controls.Add(this.butConnect);
            this.Controls.Add(this.butTest);
            this.Controls.Add(this.chkPinConsole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConsole);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTCPIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TCPIP Connection test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTCPIP_FormClosing);
            this.Load += new System.EventHandler(this.frmTCPIP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkPinConsole;
        private System.Windows.Forms.Button butTest;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.Button butDisConnect;
        private System.Windows.Forms.CheckBox chkConnected;
        private System.Windows.Forms.ComboBox cboIPAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Timer timerConnected;
        private System.Windows.Forms.CheckBox chkRepeatTest;
        private System.Windows.Forms.Timer timerConnectionTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOptical;
        private System.IO.Ports.SerialPort ModemserialPort;
        private System.Windows.Forms.Button butCSQSend;
        private System.Windows.Forms.Button butOKSend;
    }
}