namespace DeveloperTools
{
    partial class frmModemSimulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModemSimulator));
            this.ModemserialPort = new System.IO.Ports.SerialPort(this.components);
            this.txtData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRSSI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBER = new System.Windows.Forms.TextBox();
            this.butSendLargeDataPacket = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ModemserialPort
            // 
            this.ModemserialPort.PortName = "COM5";
            this.ModemserialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ModemserialPort_DataReceived);
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtData.Location = new System.Drawing.Point(12, 30);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(313, 169);
            this.txtData.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "RSSI";
            // 
            // txtRSSI
            // 
            this.txtRSSI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRSSI.Location = new System.Drawing.Point(73, 205);
            this.txtRSSI.Name = "txtRSSI";
            this.txtRSSI.Size = new System.Drawing.Size(39, 20);
            this.txtRSSI.TabIndex = 13;
            this.txtRSSI.Text = "1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "BER";
            // 
            // txtBER
            // 
            this.txtBER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBER.Location = new System.Drawing.Point(181, 205);
            this.txtBER.Name = "txtBER";
            this.txtBER.Size = new System.Drawing.Size(39, 20);
            this.txtBER.TabIndex = 15;
            this.txtBER.Text = "2";
            // 
            // butSendLargeDataPacket
            // 
            this.butSendLargeDataPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSendLargeDataPacket.Location = new System.Drawing.Point(239, 205);
            this.butSendLargeDataPacket.Name = "butSendLargeDataPacket";
            this.butSendLargeDataPacket.Size = new System.Drawing.Size(75, 23);
            this.butSendLargeDataPacket.TabIndex = 17;
            this.butSendLargeDataPacket.Text = "Send Data";
            this.butSendLargeDataPacket.UseVisualStyleBackColor = true;
            this.butSendLargeDataPacket.Click += new System.EventHandler(this.butSendLargeDataPacket_Click);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(262, 0);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(63, 24);
            this.butClear.TabIndex = 18;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // frmModemSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 241);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.butSendLargeDataPacket);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBER);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRSSI);
            this.Controls.Add(this.txtData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmModemSimulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modem Simulator";
            this.Load += new System.EventHandler(this.frmModemSimulator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort ModemserialPort;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRSSI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBER;
        private System.Windows.Forms.Button butSendLargeDataPacket;
        private System.Windows.Forms.Button butClear;
    }
}