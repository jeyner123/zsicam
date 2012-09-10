using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using zsi.PhotoFingCapture.Models.DataControllers;
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
            
            this.lbMacAdd.Text = String.Format("Physical Address: {0}", Util.GetMacAddress());
     
            
        }

        private void lbMacAdd_DoubleClick(object sender, EventArgs e)
        {
            string _val = lbMacAdd.Text;
            lbMacAdd.Text = "Please wait...";
            Application.DoEvents();
           string RegAdd = String.Format("Registered Physical Address: {0}", new dcClientWorkStation().GetRegisteredMacAddress());
            lbMacAdd.Text = _val;
           MessageBox.Show(RegAdd);
          
        }
        
    }
}
