using System;
using System.Windows.Forms;

using System.Xml;

namespace DeveloperTools
{
    public partial class frmXML : Form
    {
        public frmXML()
        {
            InitializeComponent();
        }

        private void frmXML_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string xml;
            xml = System.IO.File.ReadAllText(@"C:\2\FT100Configuration.xmltest");
            doc.LoadXml(xml);

        }
    }
}
