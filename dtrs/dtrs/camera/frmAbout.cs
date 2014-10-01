using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
namespace zsi.dtrs.camera
{
    partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            
        }
 
        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.lblVersion.Text = String.Format("Version: {0}",zsi.dtrs.camera.About.AssemblyVersion);
            this.lblCopyRight.Text = String.Format("{0} {1} All Rights Reserved."
                , zsi.dtrs.camera.About.AssemblyCopyright
                , zsi.dtrs.camera.About.AssemblyCompany
            );
            
            this.lbMacAdd.Text = String.Format("Physical Address: {0}", Util.GetMacAddress());
     
            
        }

 
        
    }
}
