using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO; 
using System.Drawing.Imaging;
using zsi.dtrs.camera;
using zsi.dtrs.camera.WebCam;
using zsi.dtrs.camera.Properties;
using System.Threading;
using TouchlessLib;
using System.Diagnostics;
namespace zsi.dtrs.camera
{

    public partial class frmMain : Form
    {
        private WebCamService _WebCam;
        private string FileName = "tmp.jpg";
     
        private void Start() {
            try
            {
                this.InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public frmMain()
        {
            Start();
        }
        public frmMain(string FileName) {
            this.FileName=FileName;            
            Start();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (this._WebCam.CurrentCamera==null) return;
            pbResult.Image = Util.CropImage(this._WebCam.CurrentCamera.GetCurrentImage(),310,233); 
            pbResult.Image.Save(this.FileName);
        }

 
        public void EnableControls(Boolean IsEnable)
        {
            btnCapture.Enabled = IsEnable;           
         
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            lUser.Text = "";
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin _frmLogin = new frmLogin(this);
            _frmLogin.ShowDialog();            
        }

 


        private void frmMain_Load(object sender, EventArgs e)
        {

            this.Text = String.Format("{0} {1} - {2}"
                , zsi.dtrs.camera.About.AssemblyProduct
                , zsi.dtrs.camera.About.AssemblyVersion
                , zsi.dtrs.camera.About.AssemblyCompany
            );

          

            if (!DesignMode)
            {
                _WebCam = new WebCamService(picture, comboBoxCameras);
            }


        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _WebCam.Stop();

        }

     
        
        private void ResetColor(object sender) 
        {
            Control Ctrl =((Control)sender);
            Ctrl.BackColor =Color.White;
            Ctrl.ForeColor =Color.Black;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {

            _WebCam.Start();
        }
 
        private void btnStop_Click(object sender, EventArgs e)
        {
            _WebCam.Stop();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {

            if (this._WebCam.CurrentCamera != null) this._WebCam.CurrentCamera.ShowPropertiesDialog(this.Handle);

        }



        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAbout _frm = new frmAbout();
            _frm.ShowDialog();            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }
  
    }

}