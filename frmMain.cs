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
using zsi.Biometrics;
using zsi.PhotoFingCapture;
using zsi.PhotoFingCapture.WebCam;
using zsi.Framework.Common;
using zsi.PhotoFingCapture.Properties;
using System.Threading;
using zsi.PhotoFingCapture.Models;
using zsi.PhotoFingCapture.Models.DataControllers;
using zsi.Framework.Data.DataProvider.SQLServer;

using TouchlessLib;

namespace zsi.PhotoFingCapture
{

    public partial class frmMain : Form
    {
        public FingersBiometrics FingerBiometrics { get; set; }
        public DPFP.Template[] Templates = new DPFP.Template[10];
        private WebCamService _WebCam;
        public frmMain()
        {
            try
            {
                this.InitializeComponent();
                InitFingerPrintSettings();


                StartUpApplication();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StartUpApplication() {
            
            ClientWorkStation info = new dcClientWorkStation().GetLocalClientWorkStation();
            ClientSettings.ClientWorkStationInfo = info;
          //  if (Util.IsOnline)//get online data
          //  {
                ClientWorkStation _info = new dcClientWorkStation().GetClientWorkStation(info.ClientId, info.WorkStationId);
                if (_info.WorkStationId > 0 && _info.ClientId > 0)
                {
                    new dcClientWorkStation().UpdateLocalClientWorkStation(_info);
                    //replace new value
                    info = _info;
                    ClientSettings.ClientWorkStationInfo = info;
                }
          //  }


            if (info.ApplicationId == 1) {
                new zsi.Biometrics.frmTimInOut().Show();            
            }
        }
       
        private void InitFingerPrintSettings(){
            this.FingerBiometrics = new FingersBiometrics();
            this.FingerBiometrics.DataChanged += new OnChangeHandler(OnFingerBiometricsChange);  
            

        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (this._WebCam.CurrentCamera==null) return;
            pbResult.Image = Util.CropImage(this._WebCam.CurrentCamera.GetCurrentImage(),310,233);
        }

    

        private string GetImageFileNameByPosition()
        {
            string _ImagePosition = cbImagePosition.SelectedItem.ToString().ToLower();
            string _fileName = string.Empty;
            switch (_ImagePosition)
            {
                case "front": _fileName = ".jpg"; break;
                case "left": _fileName = "-left.jpg"; break;
                case "right": _fileName = "-right.jpg"; break;
                case "back": _fileName = "-back.jpg"; break;
                default: break;
            }

            _fileName = ClientSettings.ProfileInfo.ProfileId + _fileName;
            if (rdbITProfile.Checked != true) _fileName = "case-" + _fileName;
            return _fileName;
        }
        private void OnFingerBiometricsChange()
        {
            int _registeredFingers = CountRegisteredFingers(this.FingerBiometrics);
            if (_registeredFingers > 0 ) 
            {
             this.Invoke(new Function(delegate{   
                btnUploadFG.Enabled = true; 
             }));
            }
            else{
            
             this.Invoke(new Function(delegate{   
                    btnUploadFG.Enabled = false;
             }));
            
            }
        }

        private int CountRegisteredFingers(FingersBiometrics fb)
        {
            int _result=0;
            foreach (DPFP.Template item in fb.Templates)
            {
                if (item != null) _result += 1;
            }
            return _result;
        }

        public void EnableControls(Boolean IsEnable)
        {
            btnCapture.Enabled = IsEnable;           
            btnUploadPhoto.Enabled = IsEnable;
            btnUploadSig.Enabled = IsEnable;
            btnUpdateClient.Enabled = IsEnable;
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            btnUploadPhoto.Enabled = false;
            ClientSettings.ProfileInfo = new zsi.PhotoFingCapture.Models.Profile();
            btnLogOut.Enabled = false;
            btnLogin.Enabled = true;
            gbClientReg.Visible = false;
            tab.Visible = false;
            btnOpenWebsite.Enabled = false;
            lUser.Text = "";
            btnUpdateClient.Visible = false;
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            zsi.PhotoFingCapture.frmSettings frmSettings = new zsi.PhotoFingCapture.frmSettings();
            frmSettings.ShowDialog();
        }
       
 
 
        private void btnVerifyFP_Click(object sender, EventArgs e)
        {
            zsi.Biometrics.frmVerification _frmVerify = new frmVerification(this);
            _frmVerify.ShowDialog();

        }
        private void btnUploadFG_Click(object sender, EventArgs e)
        {
            UploadFingerTemplates();
        }
        private void UploadFingerTemplates(){
            try
            {
                btnUploadFG.Text = "Uploading...";
                btnUploadFG.Enabled = false;
                DPFP.Template[] tmps = this.FingerBiometrics.Templates;
                for (int i = 0; i < tmps.Length; i++)
                {
                    if (this.FingerBiometrics.Templates[i] != null)
                    {
                        System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();                        
                        byte[] _template = null;
                        this.FingerBiometrics.Templates[i].Serialize(ref _template); 
                        byte[] _sample = Util.StreamToByte(Util.BmpToStream((Bitmap)this.FingerBiometrics.Images[i]));
                        string _ColName = GetTemplateColumnName(i);
                        new dcUserProfileFP().UpdateUserProfileFP(ClientSettings.UserInfo.UserId, _ColName + "F", _template);
                        new dcUserProfileFP().UpdateUserProfileFP(ClientSettings.UserInfo.UserId, _ColName + "S", _sample);
                    }
                }
                MessageBox.Show("Finger prints has been uploaded to the server.");
                ClearFingerBiometrics();
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{
                btnUploadFG.Text = "Upload";
                btnUploadFG.Enabled = true;
            }
        
        }
        private string GetTemplateColumnName(int x) {
            string _result = "";
            switch(x){
                //right
                case 0: _result = "RightT"; break;
                case 1: _result = "RightI"; break;
                case 2: _result = "RightM"; break;
                case 3: _result = "RightR"; break;
                case 4: _result = "RightS"; break;
                //left
                case 5: _result = "leftT"; break;
                case 6: _result = "leftI"; break;
                case 7: _result = "leftM"; break;
                case 8: _result = "leftR"; break;
                case 9: _result = "leftS"; break;
                default: break;            
            }
            return _result;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin _frmLogin = new frmLogin(this);

            _frmLogin.ShowDialog();
            this.CheckPermission(_frmLogin.AccessGranted);
            
        }

        public void CheckPermission(bool IsAccessGranted){
            if (IsAccessGranted == true)
            {
                if (ClientSettings.UserInfo.WSMacAddress == null)
                {
                    if (ClientSettings.UserInfo.IsZSIAdmin == true || ClientSettings.UserInfo.IsWriteManage == true)
                    {
                        gbClientReg.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("This is not a registered workstation.\r\nPlease contact your local administrator.");
                        this.Close();
                    }
                }
                else
                {
                    btnOpenWebsite.Enabled = true;
                    tab.Visible = true;
                    EnableControls(true);
                    btnUpdateClient.Visible = true;
                }
                btnLogOut.Enabled = true;
                btnLogin.Enabled = false;
                lUser.Text = "LOGON: " + ClientSettings.UserInfo.FullName;
            }
        
        
        }


        private void frmMain_Load(object sender, EventArgs e)
        {

            this.Text = String.Format("{0} {1} - {2}"
                , zsi.PhotoFingCapture.About.AssemblyProduct
                , zsi.PhotoFingCapture.About.AssemblyVersion
                , zsi.PhotoFingCapture.About.AssemblyCompany
            );

            cbImagePosition.SelectedIndex = 0;

            if (!DesignMode)
            {
                _WebCam = new WebCamService(picture, comboBoxCameras);
            }


        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _WebCam.Stop();
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
                 btnUploadPhoto.Text = "Uploading...";
                 btnUploadPhoto.Enabled = false;
                 if (pbResult.Image == null)
                 {
                     MessageBox.Show("Sorry, No photo has been captured.");
                     return;
                 }
                 string _ColumnName =  cbImagePosition.SelectedItem.ToString() + "Img";
                 byte[] _byteImage = Util.ImageToByte(pbResult.Image);

                 
                 dcUserProfileImages dc = new dcUserProfileImages();
                 dc.UpdateUserProfileImages(ClientSettings.UserInfo.UserId, _ColumnName, _byteImage);
                 MessageBox.Show("Photo has been uploaded to the server.");
                 _WebCam.Start();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 btnUploadPhoto.Text = "Upload";
                 btnUploadPhoto.Enabled = true;
             }
         }

       
        private void ShowScanForm(object sender, int FingerPosition) {
            if (ClientSettings.UserInfo == null) goto NotYetLogin;
            if (ClientSettings.UserInfo.UserId == 0) goto NotYetLogin;

            Color _bcolor =((Control)sender).BackColor;
            DialogResult result=DialogResult.None;

            if (_bcolor == Color.Green)
            {
                result = MessageBox.Show("Do you want to delete data?", "Confirmation!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            }
            if (result == DialogResult.Cancel) return;

            zsi.Biometrics.frmScanFinger scanf = new frmScanFinger(sender, this.FingerBiometrics, FingerPosition);
            scanf.IsAutoClose = chkAutoClose.Checked;
            scanf.ShowDialog();
            return;
            NotYetLogin:
            MessageBox.Show("Please login first.", "Sorry!");
        }
        private void ResetColor(object sender) 
        {
            Control Ctrl =((Control)sender);
            Ctrl.BackColor =Color.White;
            Ctrl.ForeColor =Color.Black;
        }

        private void ClearFingerBiometrics(){        
            ResetColor(btnLSF);
            ResetColor(btnLRF);
            ResetColor(btnLMF);
            ResetColor(btnLIF);
            ResetColor(btnLTF);
            ResetColor(btnRSF);
            ResetColor(btnRRF);
            ResetColor(btnRMF);
            ResetColor(btnRIF);
            ResetColor(btnRTF);
            FingerBiometrics.Templates = new DPFP.Template[10];
            FingerBiometrics.Samples = new DPFP.Sample[10];
            FingerBiometrics.Images = new Image[10];

        }

        private void btnLSF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender, 9);
        }

        private void btnLRF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender, 8);

        }

        private void btnLMF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender, 7);

        }

        private void btnLIF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender,6);

        }

        private void btnLTF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender, 5);

        }

        private void btnRSF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender,4);

        }

        private void btnRRF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender, 3);

        }

        private void btnRMF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender, 2);

        }

        private void btnRIF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender, 1);

        }

        private void btnRTF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender, 0);

        }

        private void btnClearSig_Click(object sender, EventArgs e)
        {
            signature1.Clear();            
        }

        private void signature1_MouseMove(object sender, MouseEventArgs e)
        {
          
       
        }


        private void btnUploadSig_Click(object sender, EventArgs e)
        {
            try
            {   
                btnUploadSig.Text = "Uploading...";
                btnUploadSig.Enabled = false;                
                //UpdateProfileNo();                
                System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
                this.signature1.bmp.Save(_MemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] _byte = Util.StreamToByte(_MemoryStream);
                dcUserProfileImages dc = new dcUserProfileImages();
                dc.UpdateUserProfileImages(ClientSettings.UserInfo.UserId, "SigImg", _byte);
                MessageBox.Show("Signature has been uploaded to the server.");
                signature1.Clear();
            }
                      
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{
                btnUploadSig.Text = "Upload";
                btnUploadSig.Enabled = true;
            }
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

        private void RunFingerUpdate()
        {

            ssStatus1.Text = "Updating Fingers Templates...";
            Application.DoEvents();
            dcProfile_SQL _dc = new dcProfile_SQL();
            ProcessMaster _pm = new ProcessMaster(_dc.FingerTemplatesUpdate);
            _pm.OnProcessStop = delegate()
            {
                ssStatus1.Text = "Fingers Templates processing is done.";
                Application.DoEvents();
                Thread.Sleep(1000);                 
                ssStatus1.Text = "";
                Application.DoEvents();                
            };
            _pm.Start();
        }

        private void RunTimeInOutSync()
        {

            ssStatus1.Text = "synchronizing  time(in/out) logs";
            Application.DoEvents();
            dcTimeInOutLog_OleDb _dc = new dcTimeInOutLog_OleDb();
            ProcessMaster _pm = new ProcessMaster(_dc.TimeInOutSync);
            _pm.OnProcessStop = delegate()
            {
                ssStatus1.Text = "time(in/out) synchronizing is done.";
                Application.DoEvents();
                Thread.Sleep(1000);                 
                ssStatus1.Text = "";
                Application.DoEvents();                
            };
            _pm.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // RunFingerUpdate();
           // RunTimeInOutSync();
            timer1.Enabled=false;
        }

        private void btnFingerUpdate_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.RunFingerUpdate();
        }

        private void btnOpenWebsite_Click(object sender, EventArgs e)
        {
            if (ClientSettings.UserInfo == null) goto NotLogged;
            if (ClientSettings.UserInfo.UserId == 0) goto NotLogged;
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                string _guID = Guid.NewGuid().ToString();
                dcUser _dc = new dcUser();
                _dc.UpdateRequestCode(ClientSettings.UserInfo.UserId, _guID);
                p.StartInfo.FileName = Settings.Default.DefaultWebsite + "Client?p_ClientAction=User Login&p_ClientRequestCode=" + _guID;
                p.Start();
                return;
            
            NotLogged:
            MessageBox.Show("Please login first to open a website.");
        }

        private void btnDisplayConsolList_Click(object sender, EventArgs e)
        {
             txtConsoleList.Text= zsi.Framework.Common.ConsoleApp.ToString(Application.ProductName);
        }

        private void btnClearConsoleList_Click(object sender, EventArgs e)
        {
            zsi.Framework.Common.ConsoleApp.ClearAll();
            txtConsoleList.Text = "";
        }

        private void btnCodeSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRegCode.Text)) {
                    MessageBox.Show("Please enter registration code.");
                    return;
                }

                ClientWorkStation _Client = new dcClientWorkStation2().GetClientByRegCode(txtRegCode.Text);

                if (_Client.ClientId == 0)
                {
                    MessageBox.Show("Registration code is invalid, Please check your code and try again.");
                }
                else {
                    int WorkStationId= new dcClientWorkStation().UpdateWorkStation(_Client.ClientId);
                    if (WorkStationId > 0)
                    {
                        gbClientReg.Visible = false;
                        tab.Visible = true;
                        btnOpenWebsite.Enabled = true;
                        btnUpdateClient.Visible = true;
                        btnUpdateClient.Enabled = true;
                        _Client.WorkStationId = WorkStationId;
                        ClientWorkStation info = new dcClientWorkStation().GetClientWorkStation(_Client.ClientId,_Client.WorkStationId);
                        new dcClientWorkStation().UpdateLocalClientWorkStation(info);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAbout _frm = new frmAbout();
            _frm.ShowDialog();            
        }

        private void frmMain_DoubleClick(object sender, EventArgs e)
        {
            new zsi.Biometrics.frmTimInOut().Show();
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {

        }      

        
    }

}