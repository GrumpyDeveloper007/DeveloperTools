using System;
using System.Windows.Forms;

namespace DeveloperTools
{
    public partial class frmMain : Form
    {
        private bool closing = false;

        public frmMain()
        {
            InitializeComponent();
        }


        private void modemSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModemSimulator fModem = new frmModemSimulator();
            fModem.Show();

        }

        private void modemInterfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModemInterface fModem = new frmModemInterface();
            fModem.Show();
        }

        private void qVCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQVCS fQVCS = new frmQVCS();
            fQVCS.Show();
        }


        private void logViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLog fLog = new frmLog();
            fLog.Show();
        }

        private void tCPIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTCPIP fTCP = new frmTCPIP();
            fTCP.Show();
        }

        delegate void SetTextCallback(string text);
        private void UpdateOutput(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtOutput.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(UpdateOutput);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                txtOutput.Text += text;
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            txtOutput.Text = "";
            while (i + 2 < txtInput.Text.Length)
            {
                txtOutput.Text += ",0x" + txtInput.Text.Substring(i, 2);
                i += 3;
            }
        }

        private void readTestDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXMLComments fXMLComment = new frmXMLComments();
            fXMLComment.Show();
        }

        private void butTest_Click(object sender, EventArgs e)
        {

            /*
            clsDataAccessDriver oData=new clsDataAccessDriver ();

            oData.Connect();
            DateTime dtTest=DateTime.Now.AddYears (-30);

            oData.GetXMLFile("U1300", dtTest,"");
            */


            /*
            clsEmpFrameWork cTest = new clsEmpFrameWork();
            clsMeterCommsSL.MeterCommRef.Password = "30 30 30 30 30 30 30 30 00 00 00 00 00 00 00 00 00 00 00 00";
            clsMeterCommsSL.MeterCommRef.Key = "00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F";
            clsMeterCommsSL.MeterCommRef.User = Landisgyr.au.MeterSuite.Components.CommonDefine.User.Full  ;
            cTest.MeterComms  = clsMeterCommsSL.MeterCommRef;
            sError=cTest.CommThreadExecute(clsEmpFrameWork.CommOption.TryConnection, clsEmpFrameWork.enuMeterType.U1300);
            if (sError.Length > 0)
            {
                MessageBox.Show(sError);
            }
            sError=cTest.CommThreadExecute(clsEmpFrameWork.CommOption.ProgramRead, clsEmpFrameWork.enuMeterType.U1300);
            if (sError.Length > 0)
            {
                MessageBox.Show(sError);
            }
            sError = cTest.CommThreadExecute(clsEmpFrameWork.CommOption.DeleteSession, clsEmpFrameWork.enuMeterType.U1300);
            if (sError.Length > 0)
            {
                MessageBox.Show(sError);
            }


            sError=cTest.CommThreadExecute(clsEmpFrameWork.CommOption.TryConnection, clsEmpFrameWork.enuMeterType.U1300);
            cTest.GenericReadWriteFilePath = @"C:\APATS\Frameworks\Logs\testprofile.mlr";
            if (sError.Length > 0)
            {
                MessageBox.Show(sError);
            }
            sError = cTest.CommThreadExecute(clsEmpFrameWork.CommOption.LPRead, clsEmpFrameWork.enuMeterType.U1300);
            if (sError.Length > 0)
            {
                MessageBox.Show(sError);
            }
            sError = cTest.CommThreadExecute(clsEmpFrameWork.CommOption.DeleteSession, clsEmpFrameWork.enuMeterType.U1300);
            if (sError.Length > 0)
            {
                MessageBox.Show(sError);
            }*/
            Cursor = Cursors.Default;

        }

 
        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXML fXml = new frmXML();
            fXml.Show();
        }

        private void butClose_Click(object sender, EventArgs e)
        {

        }
    }
}