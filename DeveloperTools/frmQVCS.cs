using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;


namespace DeveloperTools
{
    /// <summary>
    /// QVCS test screen
    /// </summary>
    public partial class frmQVCS : Form
    {

        List<stLabel> _stLabels = new List<stLabel>();
        List<stFile> _stFiles = new List<stFile>();
        string _lastFileName;

        int _iFileLimit=10000;
        int _iFileCount=0;


        private struct stLabel
        {
            public string sLabel;
            public string sRevision;
        }

        private struct stHistory
        {
            public string sLabel;
            public string sRevision;
            public string sDescription;
            public string sCheckedInBy;
        }

        private struct stFile
        {
            public string sFileName;
            public string sPath;
            public List<stHistory> stHistorys;
            public List<stLabel> stLabels;
            
        }

        private string FixInvalidXMLTokens(string sXML)
        {
            return sXML.Replace("\"", "&quot").Replace("'", "&apos").Replace("<", "&lt").Replace(">", "&gt").Replace("&", "&amp");
        }

        private void SaveXML(string sFileName)
        {
            string sXML = "";
            string sXML2 = "";
            string sLabels;
            string sHistorys;
            sXML2 += "<QVCSLog>\r\n";

            sXML2 += "\t<Files>\r\n";
            foreach (stFile stTable in _stFiles)
            {
                sXML = "";
                sXML += "\t\t<File>\r\n";
                sXML += "\t\t\t<Name>" + stTable.sFileName + "</Name>\r\n";
                sXML += "\t\t\t<Path>" + stTable.sPath  + "</Path>\r\n";

                sLabels = "";
                sLabels += "\t\t\t<Historys>\r\n";
                for (int i = 0; i < stTable.stHistorys.Count; i++)
                {
                    sLabels += "\t\t\t\t<History>\r\n";
                    sLabels += "\t\t\t\t<Label>" + FixInvalidXMLTokens(stTable.stHistorys[i].sLabel) + "</Label>\r\n";
                    sLabels += "\t\t\t\t<Revision>" + FixInvalidXMLTokens(stTable.stHistorys[i].sRevision) + "</Revision>\r\n";
                    sLabels += "\t\t\t\t<Description>" + FixInvalidXMLTokens(stTable.stHistorys[i].sDescription )+ "</Description>\r\n";
                    sLabels += "\t\t\t\t<CheckedInBy>" + FixInvalidXMLTokens(stTable.stHistorys[i].sCheckedInBy )+ "</CheckedInBy>\r\n";
                    sLabels += "\t\t\t\t</History>\r\n";
                }
                sLabels += "\t\t\t</Historys>\r\n";
                sXML += sLabels;


                sHistorys = "";
                sHistorys += "\t\t\t<Labels>\r\n";
                for (int i = 0; i < stTable.stLabels.Count; i++)
                {
                    sHistorys += "\t\t\t\t<Label>\r\n";
                    sHistorys += "\t\t\t\t<Name>" + FixInvalidXMLTokens(stTable.stLabels[i].sLabel )+ "</Name>\r\n";
                    sHistorys += "\t\t\t\t<Revision>" + FixInvalidXMLTokens(stTable.stLabels[i].sRevision )+ "</Revision>\r\n";
                    sHistorys += "\t\t\t\t</Label>\r\n";
                }
                sHistorys += "\t\t\t</Labels>\r\n";
                sXML += sHistorys;

                sXML += "\t\t</File>\r\n";
                sXML2 += sXML.Replace("&", "&amp;");
            }
            sXML2 += "\t</Files>\r\n";

            sXML2 += "</QVCSLog>\r\n";

            

            System.IO.File.WriteAllText(sFileName, sXML2);
        }


        public void LoadXML(string sFileName)
        {
            XmlDocument docXML = new XmlDocument();
            bool bFirst = true;
            docXML.Load(sFileName);

            _stFiles.Clear();
            foreach (XmlNode node in docXML.SelectNodes("QVCSLog/Files/File"))
            {
                stFile newTable = new stFile();
                newTable.sFileName  = node.SelectSingleNode("Name").InnerText;
                newTable.sPath  = node.SelectSingleNode("Path").InnerText;
                newTable.stHistorys=new List<stHistory>() ;
                newTable.stLabels =new List<stLabel>() ;


                foreach (XmlNode fieldnode in node.SelectNodes("Historys/History"))
                {
                    stHistory newHistory = new stHistory();
                    newHistory.sLabel = fieldnode.SelectSingleNode("Label").InnerText;
                    newHistory.sRevision = fieldnode.SelectSingleNode("Revision").InnerText;
                    newHistory.sDescription = fieldnode.SelectSingleNode("Description").InnerText;
                    newHistory.sCheckedInBy = fieldnode.SelectSingleNode("CheckedInBy").InnerText;
                    newTable.stHistorys.Add(newHistory);
                }

                foreach (XmlNode labelnode in node.SelectNodes("Labels/Label"))
                {
                    stLabel newLabel = new stLabel();
                    newLabel.sLabel = labelnode.SelectSingleNode("Name").InnerText;
                    newLabel.sRevision = labelnode.SelectSingleNode("Revision").InnerText;
                    newTable.stLabels.Add(newLabel);
                }
                if (bFirst == true)
                {
                    _stLabels = newTable.stLabels;
                    bFirst = false;
                }

                _stFiles.Add(newTable);
            }
        }


        private void ReadLog(string sPath , string sFileName, bool bAddToLabels)
        {
            List<stHistory> stHistorys = new List<stHistory>();
            List<stLabel> stLabels = new List<stLabel>();
            bool bProcessingLabels = false;
            bool bProcessingRevision = false;
            bool bProcessingDescription = false;

            string sError;
            string sResponse;
            sResponse = CommandLineHelper.Run(@"C:\QVCSBin\qlog ","\""+ sFileName +"\"" , out sError, sPath);
            if (sError.Length > 0 || (sResponse.Length < 50 && sResponse.Contains( " not found!")==false))
            {
                //sResponse = sResponse;
            }

            string sCurrentRevision = "";
            string sCurrentDescription = "";
            string sCheckedInBy = "";
            string lastLabel = "";

            /*
             *           Labels: 
        Revision 1.47 labeled by *Name* as 'Utilinet_S00237-05.05.E22' 
        Revision 1.50 labeled by *Name* as 'S00244-05.05.D62' 
        Revision 1.50 labeled by *Name* as 'U14 init version' 
        Revision 1.47 labeled by *Name* as 'Utilinet_S00237-
             * 
             * ------------------------------------------- 
Revision 1.50: created by *Name*
   Last file edit: 4/04/2013 3:08:40 PM

Revision inserted: 4/04/2013 3:10:42 PM

 Compressed from: 169376 to 48983 
      Description: 
Removed LoadProf.c from U1300 and added  DynamicLP.c */
            foreach (string sLine in sResponse.Split('\n'))
            {
                if (sLine.Trim().StartsWith("Labels:"))
                {
                    bProcessingLabels = true;
                }

                if (sLine.Trim().StartsWith("Description:"))
                {
                    bProcessingLabels = false;
                }

                if (sLine.Trim().StartsWith("-------------------------------------------"))
                {
                    if (bProcessingDescription == true)
                    {

                        stHistory newHistory = new stHistory();
                        newHistory.sDescription = sCurrentDescription;
                        newHistory.sRevision = sCurrentRevision;
                        newHistory.sCheckedInBy = sCheckedInBy;
                        newHistory.sLabel = "";
                        foreach (stLabel stlab in stLabels)
                        {
                            if (stlab.sRevision == newHistory.sRevision)
                            {
                                newHistory.sLabel = stlab.sLabel;
                                lastLabel = stlab.sLabel;
                            }
                        }
                        if (newHistory.sLabel=="")
                        { newHistory.sLabel = lastLabel; }
                        sCurrentRevision = "";
                        stHistorys.Add(newHistory);
                    }
                    bProcessingRevision = true;
                    bProcessingDescription = false;
                }

                if (bProcessingLabels == true && sLine.Trim().Length > "Revision ".Length)
                {
                    int iRevisionEnd = sLine.Trim().IndexOf(' ', "Revision ".Length);
                    int iLabelEnd = sLine.Trim().LastIndexOf('\'');
                    int iLabelStart = sLine.Trim().LastIndexOf('\'', iLabelEnd - 1);
                    int i = 0;
                    bool bFound = false;
                    stLabel newLabel = new stLabel();
                    newLabel.sLabel = sLine.Trim().Substring(iLabelStart + 1, iLabelEnd - iLabelStart - 1);
                    newLabel.sRevision = sLine.Trim().Substring("Revision ".Length, iRevisionEnd - "Revision ".Length);
                    foreach (stLabel stlab in _stLabels)
                    {
                        if (newLabel.sLabel.Trim().CompareTo (stlab.sLabel.Trim())>0)
                        {
                            i++;
                        }

                        if (stlab.sLabel.Trim() == newLabel.sLabel.Trim())
                        {
                            bFound = true; 
                        }
                    }

                    if (bFound == false)
                    {
                        if (bAddToLabels == true)
                        {
                            _stLabels.Add(newLabel);
                            _lastFileName = sPath + sFileName;
                        }
                    }
                    stLabels.Add(newLabel);
                }

                if (bProcessingDescription == true)
                {
                    sCurrentDescription += sLine + "\r\n";
                }

                if (bProcessingRevision == true)
                {
                    bProcessingLabels = false;
                    if (sLine.Trim().StartsWith("Revision ") && sLine.StartsWith("Revision inserted:") == false)
                    {
                        int iRevisionEnd = sLine.Trim().IndexOf(' ', "Revision ".Length);
                        int iCheckedInStart = sLine.Trim().IndexOf ("created by ");
                        sCurrentRevision = sLine.Trim().Substring("Revision ".Length, iRevisionEnd - "Revision ".Length - 1);
                        sCheckedInBy = sLine.Trim().Substring(iCheckedInStart + "created by ".Length);
                    }
                    if (sLine.Trim().StartsWith("Description:"))
                    {
                        sCurrentDescription = "";
                        bProcessingDescription = true;
                    }
                }
            }

            if (bProcessingDescription == true)
            {

                stHistory newHistory = new stHistory();
                newHistory.sDescription = sCurrentDescription;
                newHistory.sRevision = sCurrentRevision;
                newHistory.sCheckedInBy = sCheckedInBy;
                newHistory.sLabel = "";
                foreach (stLabel stlab in stLabels)
                {
                    if (stlab.sRevision == newHistory.sRevision)
                    {
                        newHistory.sLabel = stlab.sLabel;
                    }
                }
                sCurrentRevision = "";
                stHistorys.Add(newHistory);
            }
            bProcessingRevision = true;
            bProcessingDescription = false;

            stFile newFile=new stFile();
            newFile.sFileName = sFileName;
            newFile.sPath = sPath;
            newFile.stHistorys = stHistorys;
            newFile.stLabels = stLabels;
            _stFiles.Add(newFile);

        }

        private void StartTreeScan(string sDir)
        {
            _stFiles.Clear();
            _stLabels.Clear();
            _iFileCount = 0;
            ReadLog(@"C:\Australis\Utilinet\RadioFirmware\INCLUDE", "partinfo.h", true);
            TreeScan(sDir);
        }


        private void TreeScan(string sDir)
        {
            if (sDir.Contains(".git") == false)
            {
                foreach (string f in System.IO.Directory.GetFiles(sDir))
                {
                    if (_iFileCount > _iFileLimit)
                    {
                        return;
                    }
                    _iFileCount++;
                    ReadLog(sDir, f.Substring(f.LastIndexOf ('\\')),false );
                }
                foreach (string d in System.IO.Directory.GetDirectories(sDir))
                {
                    TreeScan(d);
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public frmQVCS()
        {
            InitializeComponent();
        }

        private void frmQVCS_Load(object sender, EventArgs e)
        {
            GridViewLog.Rows.Clear();
            LoadXML("QVCSLog.xml");

            foreach (stLabel stlab in _stLabels)
            {
                if (stlab.sLabel.Length > 0)
                {
                    lstLabels.Items.Add(stlab.sLabel);
                }
            }
        }

        private string GetDescription(string sLabel)
        {
            string sDescription= sLabel +"\r\n";
            foreach (stFile file in _stFiles)
            {
                foreach (stHistory hist in file.stHistorys)
                {
                    if (hist.sLabel.Contains(sLabel))
                    {
                        sDescription+= file.sFileName + " - " + hist.sCheckedInBy + " - " + hist.sDescription.Replace("\r","").Replace ("\n","") + "\r\n" ;
                    }
                }
            }
            return sDescription;
        }

        private string GetUserName(string sLabel)
        {
            string sUserName = "";
            foreach (stFile file in _stFiles)
            {
                foreach (stHistory hist in file.stHistorys)
                {
                    if (hist.sLabel.Contains(sLabel))
                    {
                        sUserName = hist.sCheckedInBy.Replace (" ","") ;
                    }
                }
            }
            return sUserName;
        }

        private void lstLabels_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewLog.Rows.Clear();
            foreach (stFile file in _stFiles)
            {
                foreach (stHistory hist in file.stHistorys )
                {
                    if (hist.sLabel.Contains  ((string)lstLabels.SelectedItem))
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(GridViewLog);
                        row.Cells[0].Value = hist.sRevision;
                        row.Cells[1].Value = hist.sLabel;
                        row.Cells[2].Value = file.sFileName + " - " + hist.sDescription;
                        GridViewLog.Rows.Add(row);
                    }
                }
            }
        }

        private void butCreateSvnArchive_Click(object sender, EventArgs e)
        {
            string sError = "";
            string sErrorSVN = "";
            string sResponse = "";
            string sResponseSVN = "";
            for (int i = _stLabels.Count - 1; i > 0; i--)
            {
                sResponse = CommandLineHelper.Run(@"c:\qvcsbin\qrecurse", "-archivetree qget -yes -label " + _stLabels[i].sLabel + " *.*", out sError, @"C:\Australis\Utilinet\RadioFirmware\");
                if (sError.Length > 0)
                {
                    sError = sError;
                }


                sResponseSVN = CommandLineHelper.Run("git", " commit -a -m\"" + GetDescription(_stLabels[i].sLabel) + "\"", out sErrorSVN, @"C:\Australis\Utilinet\RadioFirmware\");
                sResponseSVN = CommandLineHelper.Run("git", " tag " + _stLabels[i].sLabel, out sErrorSVN, @"C:\Australis\Utilinet\RadioFirmware\");

            }
        }
        

        private float StringToFloat(string sVersion)
        {
            string[] sSections = sVersion.Split('.');

            string temp = sSections[0] +".";
            for(int i =1; i<sSections.Count();i++)
            {
                for (int t = 3; t > sSections[i].Length;t-- )
                {
                    temp += "0";
                }

                temp+=sSections[i];
            }

            if (sVersion.Length == 0)
            {
                return 0;
            }
            return float.Parse (temp);
        }

        private void butShow_Click(object sender, EventArgs e)
        {
            GridViewLog.Rows.Clear();
            txtReport.Text = "File history for label " + txtStartRevision.Text + " to " + txtEndRevision.Text +"\r\n\r\n";

            foreach (stFile file in _stFiles)
            {
                string sStartRevision="0";
                string sEndRevision="";
                bool bFirstFind = true;

                foreach (stLabel label in file.stLabels)
                {
                    if (txtEndRevision.Text == label.sLabel)
                    {
                        sEndRevision = label.sRevision;
                    }
                    if (txtStartRevision.Text == label.sLabel)
                    {
                        sStartRevision = label.sRevision;
                    }
                }

                if (txtEndRevision.Text.Length == 0)
                {
                    sEndRevision = "99.99";
                }

                foreach (stHistory hist in file.stHistorys)
                {

                    if (StringToFloat(hist.sRevision) > StringToFloat(sStartRevision) && StringToFloat(hist.sRevision) <= StringToFloat(sEndRevision))
                    {
                        if (bFirstFind == true)
                        {
                            txtReport.Text += file.sFileName + "(" + sStartRevision + "-" + sEndRevision + ")\r\n";
                            bFirstFind = false;
                        }
                        
                        txtReport.Text += hist.sCheckedInBy + " - " + hist.sRevision + " - " + hist.sDescription.Replace ("\r"," ").Replace ("\n","") + "\r\n";
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(GridViewLog);
                        row.Cells[0].Value = hist.sRevision;
                        row.Cells[1].Value = hist.sLabel;
                        row.Cells[2].Value = file.sFileName + " - " + hist.sDescription;
                        GridViewLog.Rows.Add(row);
                    }
                }
                if (bFirstFind == false)
                {
                    txtReport.Text += "\r\n";
                }
            }

        }

        private void butScanQVCS_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            GridViewLog.Rows.Clear();
            StartTreeScan(@"C:\Australis\Utilinet\RadioFirmware");
            SaveXML("QVCSLog.xml");
            
            foreach (stLabel stlab in _stLabels)
            {
                if (stlab.sLabel.Length > 0)
                {
                    lstLabels.Items.Add(stlab.sLabel);
                }
            }
            Cursor = Cursors.Default;
        }

        private void txtReport_Click(object sender, EventArgs e)
        {
            txtReport.SelectAll();
        }
    }
}
