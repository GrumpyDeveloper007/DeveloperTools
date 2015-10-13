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
    public partial class frmXMLComments : Form
    {
        public frmXMLComments()
        {
            InitializeComponent();
        }

        private void frmXMLComments_Load(object sender, EventArgs e)
        {

        }

        struct stComment
        {
            public string sFunctionName;
            public string sComments;
        }

        private void butScan_Click(object sender, EventArgs e)
        {

            List<stComment> sComments=new List<stComment>();
            string sPath = @"C:\Australis\Utilinet\";
            string sComment="";
            bool bFoundComment = false;
            string sOutput="";

            if (System.IO.File.Exists(sPath + @"\UnitTests\UnitTestMeterComms\TestMain.c") == true)
            {
                string[] sTestFile = System.IO.File.ReadAllText(sPath + @"\UnitTests\UnitTestMeterComms\TestMain.c").Split('\n');
                foreach (string sLine in sTestFile)
                {
                    if (sLine.Trim().StartsWith("/// "))
                    {
                        sComment += sLine.Substring(4);
                        bFoundComment = true;
                    }
                    if (bFoundComment == true)
                    {
                        if (sLine.Trim().StartsWith("/// ")==false  && sLine.Trim().Length>0)//(sLine.Trim().ToUpper().StartsWith("static void".ToUpper()))
                        {
                            stComment stNewComment;
                            bFoundComment = false;
                            stNewComment.sFunctionName = sLine ;
                            stNewComment.sComments = sComment;
                            sComments.Add(stNewComment);
                            sComment = "";
                        }
                    }
                }

                foreach (stComment Comment in sComments)
                {
                    sOutput += Comment.sFunctionName ;
                    sOutput += Comment.sComments + "\r\n";
                }
                System.IO.File.WriteAllText(@"c:\dale\test.txt", sOutput);

            }


        }
    }
}
