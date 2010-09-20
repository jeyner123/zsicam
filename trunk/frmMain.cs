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
using zsi.WebCamServices;
using zsi.PhotoFingCapture.WebFileService;
namespace zsi.PhotoFingCapture
{

    public partial class frmMain : Form
    {
        public string UserId { get; set; }
        public string ProfileNo{get;set;}
        public FingersData FingersData { get; set; }
        public DPFP.Template[] Templates = new DPFP.Template[10];
        private WebCamera WebCam { get; set; }
        private WebFileManager _WebFileMgr; 


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
                this.WebCam = new WebCamera(this.picture);
                InitFingerPrintSettings();
                  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateProfileNo()
        {
           
            this.ProfileNo = WebFileMgr.GetUserTempProfileId(Convert.ToInt32(this.UserId));
        }
        private void InitFingerPrintSettings(){
            this.FingersData = new FingersData();	
            this.FingersData.DataChanged += new OnChangeHandler(OnFingersDataChange);  
            

        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            
            pbResult.Image = picture.Image;
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

            _fileName = this.ProfileNo + _fileName;
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
            btnVerifyFP.Enabled = IsEnable;
            btnLogin.Enabled = (IsEnable==true?false:true);
            btnLogOut.Enabled = IsEnable;
            btnUploadPhoto.Enabled = IsEnable;
            btnUploadSig.Enabled = IsEnable;
            btnVerifyFP.Enabled = IsEnable;

        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            btnUploadPhoto.Enabled = false;
            this.UserId = "";

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
                        this.FingersData.Templates[i].Serialize(_MemoryStream);
                        byte[] _byte = Util.StreamToByte(_MemoryStream);
                        WebFileMgr.UploadBiometricsData(this.UserId, this.ProfileNo + "-" + i.ToString() + ".fpt", _byte);

 
                        byte[] _byteImage = Util.StreamToByte(Util.BmpToStream((Bitmap)this.FingersData.Images[i]));
                        WebFileMgr.UploadBiometricsData(this.UserId, this.ProfileNo + "-" + i.ToString() + ".jpg", _byteImage);
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
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            cbImagePosition.SelectedIndex = 0;
            this.Show();
         
            WebCam.Show();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            WebCam.Close();
        }

         private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                btnUploadPhoto.Text = "Uploading...";
                btnUploadPhoto.Enabled = false;
                UpdateProfileNo();

                if (pbResult.Image == null) {
                    MessageBox.Show("Sorry, No photo has been captured.");
                    return;
                }
                if (Convert.ToInt64(this.ProfileNo)==0)
                {
                    MessageBox.Show("Sorry, You cannot upload this picture, please go to [Edit Profile] view in order to upload this picture.","No Profile Selected!");
                    return;
                }
                
                string fileName = GetImageFileNameByPosition();
                pbResult.Image.Save(fileName, ImageFormat.Jpeg);
                System.IO.FileInfo oFileInfo = new System.IO.FileInfo(fileName);
                byte[] _byteImage = Util.StreamToByte(Util.BmpToStream(pbResult.Image));
                WebFileMgr.UploadFile(UserId, oFileInfo.Name, _byteImage);
                MessageBox.Show("Photo has been uploaded to the server.");

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
            if (Convert.ToInt32(this.UserId) == 0) {
                MessageBox.Show("Please login first.", "Sorry!");
                return;
            }
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
                WebFileMgr.UploadBiometricsData(this.UserId, this.ProfileNo + "-sig.jpg", _byte);

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

 

    }

}