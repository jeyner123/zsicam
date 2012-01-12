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
using zsi.PhotoFingCapture.WebFileService;
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
        public FingersData FingersData { get; set; }
        public DPFP.Template[] Templates = new DPFP.Template[10];
        private WebFileManager _WebFileMgr;
        private WebCamService _WebCam;
        public WebFileManager WebFileMgr
        {
            get { 
            
                if(_WebFileMgr==null) _WebFileMgr = new WebFileManager();
                return _WebFileMgr;
            }
            set {
                _WebFileMgr =value;             
            }
        
        }
     
        public frmMain()
        {
            try
            {
                this.InitializeComponent();
                InitFingerPrintSettings();
                  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateProfileNo()
        {
            ClientInfo.ProfileInfo = new zsi.PhotoFingCapture.Models.Profile();
            ClientInfo.ProfileInfo.ProfileId = Convert.ToInt64( WebFileMgr.GetUserTempProfileId(ClientInfo.UserInfo.UserId));
        }
        private void InitFingerPrintSettings(){
            this.FingersData = new FingersData();	
            this.FingersData.DataChanged += new OnChangeHandler(OnFingersDataChange);  
            

        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (this._WebCam.CurrentCamera==null) return;
            pbResult.Image = Util.CropImage(this._WebCam.CurrentCamera.GetCurrentImage(),310,233);
        }

        private string GetParamenterNameByImagePosition()
        {
            string _ImagePosition = cbImagePosition.SelectedItem.ToString().ToLower();
            string _param = "";
            switch (_ImagePosition)
            {
                case "front": _param = "p_FrontImg"; break;
                case "left": _param = "p_LeftImg"; break;
                case "right": _param = "p_RightImg"; break;
                case "back": _param = "p_BackImg"; break;
                default: break;
            }
            return _param;
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

            _fileName = ClientInfo.ProfileInfo.ProfileId + _fileName;
            if (rdbITProfile.Checked != true) _fileName = "case-" + _fileName;
            return _fileName;
        }
        private void OnFingersDataChange() {
            int _registeredFingers = CountRegisteredFingers(this.FingersData);
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

        private int CountRegisteredFingers(FingersData data) {
            int _result=0;
            foreach(DPFP.Template item in data.Templates)
            {
                if (item != null) _result += 1;
            }
            return _result;
        }

        public void EnableControls(Boolean IsEnable)
        {
            btnCapture.Enabled = IsEnable;
            //btnLogin.Enabled = (IsEnable==true?false:true);
           // btnLogOut.Enabled = IsEnable;
            btnUploadPhoto.Enabled = IsEnable;
            btnUploadSig.Enabled = IsEnable;

        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            btnUploadPhoto.Enabled = false;
            ClientInfo.ProfileInfo = new zsi.PhotoFingCapture.Models.Profile();
            btnLogOut.Enabled = false;
            btnLogin.Enabled = true;
            gbClientReg.Visible = false;
            tab.Visible = false;
            btnOpenWebsite.Enabled = false;
            lUser.Text = "";
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
            try
            {
                btnUploadFG.Text = "Uploading...";
                btnUploadFG.Enabled = false;
                UpdateProfileNo();
                DPFP.Template[] tmps = this.FingersData.Templates;

                for (int i = 0; i < tmps.Length; i++)
                {
                    if(this.FingersData.Templates[i]!=null){
                        System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
                        //this.FingersData.Templates[i].Serialize(_MemoryStream);
                        //byte[] _byte = Util.StreamToByte(_MemoryStream);
                        
                        byte[] _byte = null;
                        this.FingersData.Templates[i].Serialize(ref _byte);


                        WebFileMgr.UploadBiometricsData(ClientInfo.UserInfo.UserId.ToString(), ClientInfo.ProfileInfo.ProfileId + "-" + i.ToString() + ".fpt", _byte);

 
                        byte[] _byteImage = Util.StreamToByte(Util.BmpToStream((Bitmap)this.FingersData.Images[i]));
                        WebFileMgr.UploadBiometricsData(ClientInfo.UserInfo.UserId.ToString(), ClientInfo.ProfileInfo.ProfileId + "-" + i.ToString() + ".jpg", _byteImage);
                    }
                }
                MessageBox.Show("Finger prints has been uploaded to the server.");
                ClearFingersData();
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin _frmLogin = new frmLogin(this);

            _frmLogin.ShowDialog();
            this.CheckPermission(_frmLogin.AccessGranted);
            
        }

        public void CheckPermission(bool IsAccessGranted){
            if (IsAccessGranted == true)
            {
                if (ClientInfo.UserInfo.WSMacAddress == null)
                {
                    if (ClientInfo.UserInfo.DesignationId == 30 || ClientInfo.UserInfo.IsWriteManage == true)
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
                }
                btnLogOut.Enabled = true;
                btnLogin.Enabled = false;
                lUser.Text = "LOGON: " + ClientInfo.UserInfo.FullName;
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

               /* dcFingersTemplate _dc = new dcFingersTemplate();
                ProcessMaster _pm = new ProcessMaster(_dc.FingerTemplatesUpdate);
                _pm.Start();
            */
            }


        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _WebCam.Stop();
        }

         private void btnUploadPhoto_Click(object sender, EventArgs e)
        {

            uploadphoto2();
        }

         private void uploadphoto2()
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
                 string param = GetParamenterNameByImagePosition();
                 byte[] _byteImage = Util.ImageToByte(pbResult.Image);

                 
                 dcUserProfileImages dc = new dcUserProfileImages();
                 dc.UpdateParameters.Add("p_UserId", ClientInfo.UserInfo.UserId);
                 dc.UpdateParameters.Add(param, _byteImage, System.Data.SqlDbType.Image);
                 dc.Update();                 
                 //WebFileMgr.UploadFile2(ClientInfo.UserInfo.UserId, param, _byteImage);
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

        private void uploadphoto(){
            try
            {
                _WebCam.Stop();
                btnUploadPhoto.Text = "Uploading...";
                btnUploadPhoto.Enabled = false;
                UpdateProfileNo();

                if (pbResult.Image == null) {
                    MessageBox.Show("Sorry, No photo has been captured.");
                    return;
                }
                if (ClientInfo.ProfileInfo.ProfileId == 0)
                {
                    MessageBox.Show("Sorry, You cannot upload this picture, please go to [Edit Profile] view in order to upload this picture.","No Profile Selected!");
                    return;
                }
                
                string fileName = GetImageFileNameByPosition();

                pbResult.Image.Save(fileName, ImageFormat.Jpeg);
                System.IO.FileInfo oFileInfo = new System.IO.FileInfo(fileName);
                byte[] _byteImage = Util.StreamToByte(Util.BmpToStream(pbResult.Image));
                WebFileMgr.UploadFile(ClientInfo.UserInfo.UserId.ToString(), oFileInfo.Name, _byteImage);
                MessageBox.Show("Photo has been uploaded to the server.");
                _WebCam.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{
                btnUploadPhoto.Text = "Upload";
                btnUploadPhoto.Enabled = true;
            }
        }
        private void ShowScanForm(object sender, int FingerPosition) {
            if (ClientInfo.UserInfo==null) goto NotYetLogin;            
            if (ClientInfo.UserInfo.UserId == 0) goto NotYetLogin;

            Color _bcolor =((Control)sender).BackColor;
            DialogResult result=DialogResult.None;

            if (_bcolor == Color.Green)
            {
                result = MessageBox.Show("Do you want to delete data?", "Confirmation!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            }
            if (result == DialogResult.Cancel) return;

            zsi.Biometrics.frmScanFinger scanf = new frmScanFinger(sender, this.FingersData, FingerPosition);
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

        private void ClearFingersData(){        
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
            FingersData.Templates = new DPFP.Template[10];
            FingersData.Samples = new DPFP.Sample[10];
            FingersData.Images= new Image[10];

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
                UpdateProfileNo();
                

                DPFP.Template[] tmps = this.FingersData.Templates;

                System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
                this.signature1.bmp.Save(_MemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] _byte = Util.StreamToByte(_MemoryStream);
                WebFileMgr.UploadBiometricsData(ClientInfo.UserInfo.UserId.ToString(), ClientInfo.ProfileInfo.ProfileId + "-sig.jpg", _byte);

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
            dcFingersTemplate _dc = new dcFingersTemplate();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            RunFingerUpdate();
            timer1.Enabled=false;
        }

        private void btnFingerUpdate_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.RunFingerUpdate();
        }

        private void btnOpenWebsite_Click(object sender, EventArgs e)
        {
            if (ClientInfo.UserInfo ==null) goto NotLogged;
            if (ClientInfo.UserInfo.UserId == 0) goto NotLogged;
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                string _guID = Guid.NewGuid().ToString();
                dcUser _dc = new dcUser();
                _dc.UpdateRequestCode(ClientInfo.UserInfo.UserId, _guID);
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

                Places _place = new dcPlaces().GetPlaceByRegCode(txtRegCode.Text);

                if (_place.PlaceId == 0)
                {
                    MessageBox.Show("Registration code is invalid, Please check your code and try again.");
                }
                else {
                    bool IsSuccessUpdate = new dcPlaceWorkStation().UpdateWorkStation(_place.PlaceId);
                    if (IsSuccessUpdate == true) {
                        gbClientReg.Visible = false;
                        tab.Visible = true;
                        btnOpenWebsite.Enabled = true;
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

   

        

        
    }

}