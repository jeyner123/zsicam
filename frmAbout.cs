using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace zsi.PhotoFingCapture
{
    partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            
        }
 
        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.lblVersion.Text = String.Format("Version: {0}",zsi.PhotoFingCapture.About.AssemblyVersion);
            this.lblCopyRight.Text = String.Format("{0} {1} All Rights Reserved."
                , zsi.PhotoFingCapture.About.AssemblyCopyright
                , zsi.PhotoFingCapture.About.AssemblyCompany
            );
            
            this.lbMacAdd.Text = String.Format("Mac Address: {0}", Util.GetMacAddress());
            
        }
        
    }
}
