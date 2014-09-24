using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
namespace zsi.PhotoFingCapture
{
    public partial class frmSettings : Form
    {
        XmlDocument doc;
        XmlNode node;
        string AppConfigFile = Util.GetConfigFileName;

        public frmSettings()
        {
            InitializeComponent();
            doc = new XmlDocument();
            doc.Load(AppConfigFile);

            XmlNodeList _nodes;
            _nodes = doc.SelectNodes("//applicationSettings");
            node = _nodes.Item(0).ChildNodes.Item(0).ChildNodes.Item(0).ChildNodes.Item(0);

        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtWebRef.Text = node.InnerText;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            node.InnerText = txtWebRef.Text;
            doc.Save(AppConfigFile);            
            this.Close();            
        }
    }
}