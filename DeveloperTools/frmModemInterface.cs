using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeveloperTools
{
    /// <summary>
    /// Provides a simple way to send commands to a modem and see responses
    /// </summary>
    public partial class frmModemInterface : Form
    {
        System.Threading.Thread m_WorkerThread;
        string m_LastCommand="";
        string m_LastResponse="";
        DateTime m_dtLastCommunication;

        string m_sLastError;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;


        private void ATCommandThread()
        {
            Transmit(m_LastCommand);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public frmModemInterface()
        {
            InitializeComponent();
        }

        private void UpdateData(string text)
        {
            Invoke((MethodInvoker)delegate
            {
                if (DateTime.Now.Subtract(m_dtLastCommunication).TotalMilliseconds   > 800)
                {
                    m_dtLastCommunication = DateTime.Now;
                    txtData.Text += DateTime.Now.ToString() + ":" + text.Replace("\n", "") + "\r\n";
                }
                else
                {
                    txtData.Text += text.Replace("\n", "\r\n") ;
                }
                m_LastResponse+=text.Replace("\n", "\r\n");
                SendMessage(txtData.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);

                if (m_LastResponse.Contains("CON"))
                {
                    timerConnected.Enabled = true;
                }

            
            });

            if (m_LastResponse.Contains("OK"))
            {
                m_LastResponse = "";
                if (chkLoop.Checked)
                {
                    Transmit(m_LastCommand);
                }
            }

        }

        private void Transmit(string sData)
        {
            m_LastCommand = sData;
            try
            {
                ModemserialPort.WriteLine(sData + "\r\n");
            }
            catch (Exception ex)
            {
                sData = ex.Message;
            }
            UpdateData("TX:"+sData);
        }



        private void ModemserialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            UpdateData(ModemserialPort.ReadExisting());
        }

        private void frmModemInterface_Load(object sender, EventArgs e)
        {
            try
            {
                timerCheckRSSI.Interval = int.Parse(txtCSQInterval.Text) * 1000;

                txtCommPort.Text = Properties.Settings.Default.ModemCommPort;
                ModemserialPort.PortName = Properties.Settings.Default.ModemCommPort;
                ModemserialPort.Open();
                butOpen.Text = "Close";
            }
            catch (Exception ex)
            {
                m_sLastError = ex.Message;
                txtData.Text = "Unable to open comm port";
            }
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            cboSendCommand.Text = "AT+CSQ;+COPS?;+CPMS?;+CREG?";
            m_LastCommand = "AT+CSQ;+COPS?;+CPMS?;+CREG?";
            m_WorkerThread = new System.Threading.Thread(new System.Threading.ThreadStart(ATCommandThread));

            m_WorkerThread.Start();
        }



        private void txtCommPort_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ModemCommPort = txtCommPort.Text;
            Properties.Settings.Default.Save();
        }

        private void cboSendCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Transmit(cboSendCommand.Text);
            }

        }

        private void butSam3gBaud_Click(object sender, EventArgs e)
        {
            ModemserialPort.Close();
            ModemserialPort.BaudRate = 115200;
            ModemserialPort.Open();

            Transmit("at+ipr=9600");

        }

        private void butSam3GConfigure_Click(object sender, EventArgs e)
        {
            Transmit("atE1"); // local echo
            Transmit("at&s10=14"); // Delay between Loss of Carrier and Hang-Up
            //+CBST: 0,0,1 //Select Bearer Service Type 
            //+CRLP: 61,61,48,6,0 //Radio Link Protocol -IWF to MS window size,MS to IWF window size,Acknowledgment timer T1 (*10 ms),Re-transmission attempts N2,Re-sequencing period T4 (*10 ms),RLP version. When version indication is not present,<ver>=0 is assumed
//+CRLP: 61,61,48,6,1
//+CRLP: 240,240,52,6,2
            //+CR: 0 //Service Reporting Control - Disable reporting. 0Default value 1Enable reporting
            //+CRC: 0 //Cellular Result Code
            //+CMGF: 1 //Message Format - 0PDU mode,1Text mod
            //+CSDH: 0 //AT+CMGD Delete Message
            //+CNMI: 0,0,0,0,1 //New Message Indications to TE
//+IPR: 9600
            //+CMEE: 0 //Mobile Equipment Error - 0Disable +CME ERROR: <err> result code and use ERRORinstead. Default value1Enable +CME ERROR: <err> result code and use numeric<err> values (seepage 13)2Enable +CME ERROR: <err> result code and use verbose<err> values (seepage 13)
            //+CSMS: 0,1,1,1 //Select Message Service <service> Description 0GSM 03.40 and 03.41. The syntax of SMS AT commands iscompatible with GSM 07.05 Phase 2 version 4.7.0; Phase 2+features which do not require new command syntax maybe supported (e.g. correct routing of messages with newPhase 2+ data coding schemes)2..127Reserved<mt> Description 0Mobile terminated messages not supported1Mobile terminated messages supported<mo> Description 0Mobile originated messages not supported1Mobile originated messages supported<bm> Description 0Broadcast messages not supported1Broadcast messages supported
//^SLCC: 0
//^SCKS: 0,0
//^SSET: 0
            //+CREG: 0,0 // Network Registration -<n> Description 0Disable network registration unsolicited result code.Default value1Enable network registration unsolicited result code<stat> Description 0Not registered, ME is not currently searching for a newoperator to register with1Registered, home network2Not registered, but ME is currently searching for a newoperator to register with3Registration denied4Not detailed5Registered, roamin
            //+CLIP: 0 //Calling Line Identification
            //+CAOC: 1 //Advice of Charge -  0Query CCM value1Deactivate the unsolicited reporting of CCM value2Activate the unsolicited reporting of CCM value
            //+COPS: 0 //Operator Selection -  0Automatic (<oper> field is ignored)1Manual (<oper> field present)3Set only <format> (for read command +COPS?), do notattempt registration/de-registration (<oper> field isignored); this value is not applicable in read commandresponse4Manual/automatic (<oper> field present); if manualselection fails, automatic mode (<mode>=0) is entered
            //+CGSMS: 0 //Select Service for MO SMS Messages
        }

        private void cboSendCommand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butTest_Click(object sender, EventArgs e)
        {
            txtData.Text = txtData.Text.Replace ("\r\r","\r");
            m_LastCommand ="+++\r"+ cboSendCommand.Text +"\r\n";
            Transmit(m_LastCommand);
        }

        private void butKF2VersionTest_Click(object sender, EventArgs e)
        {
            byte[] GetKF2Version={0xAC, 0x00, 0x00, 0x74, 0xAA,0x00};
            byte[] ReadBuffer=new byte[200];
            /*
            for (i = 0; i < GetKF2Version.Count(); i++)
            {
                ModemserialPort.Write(GetKF2Version, i,1);
                System.Threading.Thread.Sleep(10);
            }*/


            ModemserialPort.Write (GetKF2Version,0,GetKF2Version.Count() );
            //ModemserialPort.Read(ReadBuffer, 0, 1);
        }

        private void butKF2VersionTest2_Click(object sender, EventArgs e)
        {
            byte[] GetKF2Version = { 0xAC, 0x00, 0x00, 0x74, 0xAA, 0x00 };
            byte[] ReadBuffer = new byte[200];
            ModemserialPort.WriteLine("RING");
            ModemserialPort.WriteLine("CONNECT 9600");
            ModemserialPort.Write(GetKF2Version, 0, GetKF2Version.Count());

        }

        private void timerCheckRSSI_Tick(object sender, EventArgs e)
        {
            Transmit("AT+CSQ");
        }

        private void chkCSQ_CheckedChanged(object sender, EventArgs e)
        {
            timerCheckRSSI.Enabled = chkCSQ.Checked;
        }

        private void txtCSQInterval_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timerCheckRSSI.Interval = int.Parse(txtCSQInterval.Text)*1000;
            }
            catch (Exception ex)
            {
                m_sLastError = ex.Message;
            }
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            txtData.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModemserialPort.WriteLine("+++");
            ModemserialPort.WriteLine("ATH");
            ModemserialPort.WriteLine("AT");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModemserialPort.Write("AT\r");
        }

        private void butNetwork_Click(object sender, EventArgs e)
        {
            byte[] NetworkSearch = { 0xAA ,0x02 ,0x1A ,0x00 ,0xD8 ,0x82 ,0xAA ,0x03 ,0x1A ,0x01 ,0x3F ,0xF3 ,0xEB};
            ModemserialPort.Write(NetworkSearch , 0, NetworkSearch .Count());
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            //atd 0417619191
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            //timerConnected.Enabled = false;
            ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(e.KeyChar.ToString());
                ModemserialPort.Write(buffer,0,1);
        }

        private void timerConnected_Tick(object sender, EventArgs e)
        {
            lblConnected.Text = DateTime.Now.Subtract(m_dtLastCommunication).TotalMilliseconds.ToString();
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (butOpen.Text == "Close")
                {
                    ModemserialPort.Close();
                    butOpen.Text = "Open";
                }
                else
                {
                    ModemserialPort.PortName = txtCommPort.Text;
                    ModemserialPort.Open();
                    butOpen.Text = "Close";
                }
            }
            catch (Exception ex)
            {
                txtData.Text = ex.Message;
            }

        }




    }
}
