using System;
using System.Text;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace DeveloperTools
{
    public partial class frmTCPIP : Form
    {

        TcpClient _SocketClient;
        Thread TCPWorker;
        private bool _Running = true;
        private string _IPAddress;
        private DateTime _dtLastCommunication;
        private DateTime _dtConnectionTime;

        private int _iSecondCounter=0;
        private string _sLastError;

        delegate void SetTextCallback(string text);
        delegate void CheckBoxCallback(bool text);


        public frmTCPIP()
        {
            InitializeComponent();
        }

        private void m_Console_SetText(string text)
        {
            int iStart;
            int ilength;

            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtConsole.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(m_Console_SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (this.txtConsole.Text.Length > 20000)
                {
                    this.txtConsole.Text = "";
                }

                iStart = txtConsole.SelectionStart;
                ilength = txtConsole.SelectionLength;

                this.txtConsole.Text += text;
                
                if (chkPinConsole.Checked)
                {
                    txtConsole.SelectionStart = txtConsole.Text.Length;
                    txtConsole.ScrollToCaret();
                }
                txtConsole.SelectionStart = iStart;
                txtConsole.SelectionLength = ilength;
            }
        }


        private void m_Console_UpdateConnectionState(bool value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtConsole.InvokeRequired)
            {
                CheckBoxCallback d = new CheckBoxCallback(m_Console_UpdateConnectionState);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                chkConnected.Checked = value;
                if (value == true)
                {
                    timerConnected.Enabled = true;
                }
            }
        }

        public void ThreadProc()
        {
            try
            {
                    _SocketClient = new TcpClient();
                    _SocketClient.Connect(IPAddress.Parse(_IPAddress), int.Parse(txtPort.Text));
                    m_Console_UpdateConnectionState(true);
                    if (chkRepeatTest.Checked == true)
                    {
                        butTest_Click(null, null);
                    }
                    _dtConnectionTime = DateTime.Now;

                if (true)//m_Socket.Connected
                {

                    NetworkStream clientStream = _SocketClient.GetStream();
                    int bytesRead;
                    byte[] message = new byte[4096];

                    //clientStream.ReadTimeout = 1000;
                    while (_Running)
                    {
                        bytesRead = 0;

                        try
                        {
                            //blocks until a client sends a message
                            if (clientStream.DataAvailable)
                            {
                                bytesRead = clientStream.Read(message, 0, 4096);
                                if (message[0] == '+')
                                {
                                    //SendTCPIPMessage("OK\r\n");
                                }
                                if (message[0] == 'A')
                                {
                                    SendTCPIPMessage("+CSQ: 9,99\r\n");
                                }
                                
                            }
                            else
                                System.Threading.Thread.Sleep(100);
                        }
                        catch (System.Threading.ThreadAbortException ex)
                        {
                            _sLastError = ex.Message;
                            return;
                        }

                        catch (Exception ex)
                        {
                            _sLastError = ex.Message;

                            //a socket error has occured
                            //break;
                        }

                        if (bytesRead > 0)
                        {
                            //message has successfully been received
                            ASCIIEncoding encoder = new ASCIIEncoding();
                            if (DateTime.Now.Subtract(_dtLastCommunication).TotalMilliseconds > 2000)
                            {
                                _dtLastCommunication = DateTime.Now;
                                m_Console_SetText( "\r\n" +BitConverter.ToString(message, 0, bytesRead) );//encoder.GetString(message, 0, bytesRead).Replace("\n", "\r\n")
                            }
                            else
                            {
                                m_Console_SetText("-"+BitConverter.ToString(message, 0, bytesRead));//encoder.GetString(message, 0, bytesRead).Replace("\n", "\r\n")
                            }

                            if (encoder.GetString(message, 0, bytesRead).Contains("\r"))
                            {
                                //m_bRX = true;
                            }
                        }
                    }
                    _SocketClient.Close();
                    m_Console_UpdateConnectionState(false);
                }
            }
            catch (Exception ex)
            {
                m_Console_SetText(ex.Message);
            }
        }

        private void SendText(string sParam)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            m_Console_SetText(sParam + "\r\n");
            byte[] buffer = encoder.GetBytes(sParam + "\r\n");

            if (_SocketClient.Connected == true)
            {
                _SocketClient.GetStream().Write(buffer, 0, buffer.Length);
            }
        }

        private void frmTCPIP_Load(object sender, EventArgs e)
        {
            _IPAddress = cboIPAddress.Text;
            lblConnected.Text = "";
            ModemserialPort.PortName = "COM"+txtOptical.Text ;
            ModemserialPort.Open();
        }
        
        private void butTest_Click(object sender, EventArgs e)
        {
            byte[] GetKF2Version = { 0xAC, 0x00, 0x00, 0x74, 0xAA };
            //byte[] GetKF2Version = { 0xDA, 0xDA, 0xDA, 0xDA, 0xDA, 0xAC, 0x00, 0x00, 0x74, 0xAA, 0x00 };

            if (_SocketClient.Connected == true)
            {
                try
                {
                    m_Console_SetText("\r\n" + "TX: " + BitConverter.ToString(GetKF2Version) + "\r\n");
                    timerConnected.Enabled = false;
                    //lblConnected.Text = DateTime.Now.Subtract(m_dtConnectionTime).TotalMilliseconds.ToString ();
                    _dtLastCommunication = DateTime.Now.AddSeconds(-3);
                    _SocketClient.GetStream().Write(GetKF2Version, 0, GetKF2Version.Length);
                }
                catch (Exception ex)
                {
                    m_Console_SetText(ex.Message);
                }
            }
            else
            {
                m_Console_SetText("Not connected");
            }

            //SendText("testing");
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            _Running = true;
            {
                TCPWorker = new Thread(new ThreadStart(ThreadProc));
            }
            TCPWorker.Start();
        }

        private void butDisConnect_Click(object sender, EventArgs e)
        {
            _Running = false;
        }

        private void frmTCPIP_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Running = false;
        }

        private void cboIPAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IPAddress = cboIPAddress.Text;
        }

        private void chkConnected_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboIPAddress_TextChanged(object sender, EventArgs e)
        {
            _IPAddress = cboIPAddress.Text;
        }

  
        private void butClear_Click(object sender, EventArgs e)
        {
            txtConsole.Text = "";
        }

        private void txtConsole_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_SocketClient.Connected == true)
            {
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(e.KeyChar.ToString());
                _dtLastCommunication = DateTime.Now.AddSeconds(-3);
                _SocketClient.GetStream().WriteByte(buffer[0]);
            }

        }

        private void timerConnected_Tick(object sender, EventArgs e)
        {
            lblConnected.Text = DateTime.Now.Subtract(_dtConnectionTime).TotalMilliseconds.ToString();
        }

        private void chkRepeatTest_CheckedChanged(object sender, EventArgs e)
        {
            timerConnectionTest.Enabled = chkRepeatTest.Checked ;
        }

        private void timerConnectionTest_Tick(object sender, EventArgs e)
        {
            _iSecondCounter++;
            if (_iSecondCounter == 60)
            {
                m_Console_SetText("\r\n" + DateTime.Now.ToString() + "Connect" + "\r\n");
                butConnect_Click(sender, e);
                _iSecondCounter++;
            }
            /*if (m_iSecondCounter == 68)
            {
                butTest_Click(sender, e);
                m_iSecondCounter++;
            }*/

            if (_iSecondCounter > 75)
            {
                _iSecondCounter = 0;
                butDisConnect_Click(sender, e);
            }

/*            if (m_iSecondCounter > 60)
            {
                m_Console_SetText("\r\n" + DateTime.Now.ToString() + "Disconnect" + "\r\n");
                m_Running = false;
            }
            if (m_iSecondCounter == 60 * 10)
            {
                m_Console_SetText("\r\n" + DateTime.Now.ToString() + "Connect" + "\r\n");
                butConnect_Click(sender, e);
                m_iSecondCounter = 0;
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConsole_TextChanged(object sender, EventArgs e)
        {

        }

        private void butCSQSend_Click(object sender, EventArgs e)
        {
            SendTCPIPMessage("+CSQ: 9,99\r\n");
        }

        private void SendTCPIPMessage(string sMessage )
        {
            if (_SocketClient.Connected == true)
            {
                try
                {
                    m_Console_SetText("\r\n" + sMessage + "\r\n");
                    timerConnected.Enabled = false;
                    //lblConnected.Text = DateTime.Now.Subtract(m_dtConnectionTime).TotalMilliseconds.ToString ();
                    _dtLastCommunication = DateTime.Now.AddSeconds(-3);
                    byte[] sendbytes = new byte[sMessage.Length];
                    for (int i = 0; i < sMessage.Length; i++)
                    {
                        sendbytes[i] = (byte)sMessage.ToCharArray()[i];
                    }
                    _SocketClient.GetStream().Write(sendbytes, 0, sendbytes.Length);
                }
                catch (Exception ex)
                {
                    m_Console_SetText(ex.Message);
                }
            }
            else
            {
                m_Console_SetText("Not connected");
            }

        }

        private void butOKSend_Click(object sender, EventArgs e)
        {
            SendTCPIPMessage("OK\r\n");
        }

        private void ModemserialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] buffer=new byte [100];
            int iBytesRead;
            iBytesRead= ModemserialPort.Read(buffer, 0, 100);
            m_Console_SetText("Serial RX:" + BitConverter.ToString(buffer, 0, iBytesRead)+ "\r\n");
        }
    }
}
