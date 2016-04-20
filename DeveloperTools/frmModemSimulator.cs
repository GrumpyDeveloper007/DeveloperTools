using System;
using System.Windows.Forms;

namespace DeveloperTools
{
    /// <summary>
    /// Generates modem AT responses when attached to the meter simulator.
    /// </summary>
    public partial class frmModemSimulator : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmModemSimulator()
        {
            InitializeComponent();
        }

        private void UpdateData(string text)
        {
            Invoke((MethodInvoker)delegate
            {
                txtData.Text += text.Replace ("\n","\r\n");
                txtData.SelectionStart = txtData.Text.Length;
                txtData.ScrollToCaret();

            });
        }

        private void Transmit(string sData)
        {
            ModemserialPort.WriteLine(sData );
            UpdateData(sData);
        }



        private void ModemserialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            UpdateData(ModemserialPort.ReadExisting());
            Transmit("+CSQ: "+ txtRSSI.Text  +"," + txtBER.Text + "\n");
        }

        private void frmModemSimulator_Load(object sender, EventArgs e)
        {
            ModemserialPort.PortName = "COM12";
            ModemserialPort.Open();
        }

        private void butSendLargeDataPacket_Click(object sender, EventArgs e)
        {
            byte[] bBuffer=new byte [256];
            ModemserialPort.Write(bBuffer ,0,255);
            UpdateData("Large Packet");
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            txtData.Text = "";
        }
    }
}
