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
        private NotifyIcon  trayIcon;
        private ContextMenu trayMenu;
        private bool IsApplicationExit;
        private void OnExit(object sender, EventArgs e)
        {
            _WebCam.Stop();
            DialogResult result = MessageBox.Show("Are you sure, you want to close this application?", "PhotofingCapture: Confirm!", MessageBoxButtons.YesNo);
             if (result == DialogResult.Yes)
             {
                 IsApplicationExit = true;
                 Application.Exit();
                  
             }
             
        }
        public frmMain()
        {
            try
            {
                this.InitializeComponent();
                        
               // SysTray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (this._WebCam.CurrentCamera==null) return;
            pbResult.Image = Util.CropImage(this._WebCam.CurrentCamera.GetCurrentImage(),310,233);
        }

 
        public void EnableControls(Boolean IsEnable)
        {
            btnCapture.Enabled = IsEnable;           
            btnOK.Enabled = IsEnable;
         
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            btnOK.Enabled = false;
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
            //this.WindowState = FormWindowState.Minimized;
            //if(IsApplicationExit==false) e.Cancel = true;
        }

         private void btnUploadPhoto_Click(object sender, EventArgs e)
        {

            uploadphoto();
        }

         private void uploadphoto()
         {
             try
             {
                 _WebCam.Stop();
                 btnOK.Text = "Processing...";
                 btnOK.Enabled = false;
                 if (pbResult.Image == null)
                 {
                     MessageBox.Show("Sorry, No photo has been captured.");
                     return;
                 }
                 byte[] _byteImage = Util.ImageToByte(pbResult.Image);
                 MessageBox.Show("Photo has been uploaded to the server.");
                 _WebCam.Start();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 btnOK.Text = "OK";
                 btnOK.Enabled = true;
             }
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
  
    }

}