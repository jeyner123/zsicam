using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.IO;
using WebCamService;
using WebFileService;
using System.Web;
using System.Threading;
using System.Net;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using zsi.Biometrics;
using zsi.PhotoFingCapture;
namespace WebCamServiceSample
{

    public partial class Form1 : Form
    {
        //WebCamService.WebCamManager WebCam;
        private static string _UserId;
        public string UserId
        {
            set { _UserId = value; }
            get { return _UserId; }
        }
        public string ProfileNo{get;set;}

        public FingersData FingersData { get; set; }

        public Form1()
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
        private void InitFingerPrintSettings(){
            this.FingersData = new FingersData();	
            this.FingersData.EnrolledFingersMask=0;
            this.FingersData.MaxEnrollFingerCount=10;
            this.FingersData.IsEventHandlerSucceeds=true;
        }

        public Thread CameraThread { get; set; }


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

            _fileName = "image" + _fileName;
            if (rdbITProfile.Checked != true) _fileName = "case-" + _fileName;
            return _fileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = GetImageFileNameByPosition();
                pbResult.Image.Save(fileName, ImageFormat.Jpeg);
                System.IO.FileInfo oFileInfo = new System.IO.FileInfo(fileName);
                WebFileManager.FileUploadViaWebService(oFileInfo, this.UserId);
                MessageBox.Show("Photo has been uploaded to the server.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }







        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUserName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter UserName and Password.", "Try Again.", MessageBoxButtons.OK);
                    return;
                }
                btnLogin.Text = "Wait...";
                zsi.PhotoFingCapture.WebFileService.WebFileManager fm = new zsi.PhotoFingCapture.WebFileService.WebFileManager();
                this.UserId = fm.GetUserId(txtUserName.Text, txtPassword.Text).ToString();
                if (int.Parse(this.UserId) < 1)
                {
                    MessageBox.Show("Invalid User, Please Login.");
                    btnLogin.Text = "Login";
                    return;
                }
                EnableControls(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnSave.Enabled = true;
                btnLogin.Text = "Login";
            }


        }

        void EnableControls(Boolean IsEnable){

            btnCapture.Enabled = IsEnable;
            btnLogOut.Enabled = IsEnable;
            btnLogin.Enabled = (IsEnable == false ? true : false);
            btnSave.Enabled = IsEnable;
            txtUserName.Enabled = IsEnable;
            txtPassword.Enabled = IsEnable;
            btnUploadFG.Enabled = IsEnable;
            btnRegisterFP.Enabled = IsEnable;
            btnVerifyFP.Enabled = IsEnable;
            btnFind.Enabled = IsEnable;
            txtProfileNo.Enabled = IsEnable;

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            txtUserName.Text = "";
            txtPassword.Text = "";
            this.UserId = "";
        }
 

        private void btnSettings_Click(object sender, EventArgs e)
        {
            zsi.PhotoFingCapture.frmSettings frmSettings = new zsi.PhotoFingCapture.frmSettings();
            frmSettings.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbImagePosition.SelectedIndex = 0;
            this.Show();
            LoadCamera();
        }

 
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


     


        public void LoadCamera()
        {
            MotionImages _montionImages = new MotionImages(picture);

            // Create the thread object, passing in the Alpha.Beta method
            // via a ThreadStart delegate. This does not start the thread.
            this.CameraThread = new Thread(new ThreadStart(_montionImages.Run));

            try
            {
                // Start the thread
                this.CameraThread.Start();

                // Spin for a while waiting for the started thread to become
                // alive:
                while (!this.CameraThread.IsAlive) ;

                // Put the Main thread to sleep for 1 millisecond to allow oThread
                // to do some work:
                Thread.Sleep(1);

                // Request that oThread be stopped
                // oThread.Abort();

                // Wait until oThread finishes. Join also has overloads
                // that take a millisecond interval or a TimeSpan object.
                //this.CameraThread.Join();
            }
            catch (ThreadStateException ex)
            {
                Console.Write(ex);
            }
        }

 

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CameraThread.Abort();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            zsi.PhotoFingCapture.WebFileService.WebFileManager wfm = new zsi.PhotoFingCapture.WebFileService.WebFileManager();
            string _profileNo = this.txtProfileNo.Text.Trim() ;            
            try
            {
                if(_profileNo.Length<13) throw new Exception();
                Int64.Parse(_profileNo);
                             
            }
            catch{
                MessageBox.Show("Please enter 13 digit numbers.");
                return;
            }
          
            string _result = wfm.GetProfileInfo(this.UserId, _profileNo);
            if (string.IsNullOrEmpty(_result) == false)
            {
                lblProfileName.Text = _result;
                this.ProfileNo = this.txtProfileNo.Text.Trim();
            }
            else {
                lblProfileName.Text  ="Profile Not found";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zsi.Biometrics.MainForm mf = new zsi.Biometrics.MainForm();
            mf.Show();
        }

        private void btnRegisterFP_Click(object sender, EventArgs e)
        {
 
            zsi.Biometrics.frmRegisterFP _frmRegFP = new frmRegisterFP(this.FingersData);
            _frmRegFP.Show();

        }

        private void btnVerifyFP_Click(object sender, EventArgs e)
        {
            zsi.Biometrics.frmVerification _frmVerify = new frmVerification();
            _frmVerify.Show();

        }

        private void btnUploadFG_Click(object sender, EventArgs e)
        {
            zsi.PhotoFingCapture.WebFileService.WebFileManager wf = new zsi.PhotoFingCapture.WebFileService.WebFileManager();
            System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
 
            DPFP.Template[] tmps = this.FingersData.Templates;

            for (int i = 0; i < tmps.Length; i++)
            {

                Stream _stream = this.FingersData.Templates[i].Serialize(_MemoryStream);
                byte[] _byte = Util.StreamToByte(_stream);

                wf.UploadBiometricsData(this.UserId, "fingers-" + i.ToString() + ".fpt", _byte);
            }
        }

 

     

    }

    public class MotionImages
    {

        public MotionImages(PictureBox PictureBox)
        {
            this.PictureBox = PictureBox;
        }
        public PictureBox PictureBox { get; set; }
        public WebCamService.WebCamManager WebCam { get; set; }
        // This method that will be called when the thread is started

        public Image CropImage(Bitmap bmpSource, int width, int height)
        {
            try
            {
                Rectangle cropRect = new Rectangle(0, 0, width, height);


                //resize
                Bitmap _resizedImg = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(_resizedImg);
                g.DrawImage(bmpSource, cropRect, new Rectangle(0, 0, bmpSource.Width, bmpSource.Height), GraphicsUnit.Pixel);


                //crop


                Bitmap _CropImg = new Bitmap(270, height - 10);
                g = Graphics.FromImage(_CropImg);
                g.DrawImage(_resizedImg, cropRect, new Rectangle(18, 10, width, height), GraphicsUnit.Pixel);

                return (Image)_CropImg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Run()
        {
            WebCam = new WebCamManager();
        
            while (true)
            {
                if (this.WebCam != null)
                {

                    byte[] _byteimg = WebCam.GrabFrame();
                    
                    if (_byteimg != null)
                    {
                        System.IO.MemoryStream st = new System.IO.MemoryStream(_byteimg);
                        // picture.Image = System.Drawing.Image.FromStream(st);
                        Image _img = System.Drawing.Image.FromStream(st);
                       // PictureBox.Image = _img;

                        PictureBox.Image =CropImage((Bitmap)_img, 310, 233);

                    }
                }
              
            }
        }
    }
}