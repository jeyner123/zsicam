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

        public Form1()
        {
            try
            {
                this.InitializeComponent();
                //WebCam = new WebCamManager();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Thread CameraThread { get; set; }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
               // System.IO.MemoryStream st = new System.IO.MemoryStream(WebCam.GrabFrame());
                //picture.Image = System.Drawing.Image.FromStream(st);
                //Image _img = System.Drawing.Image.FromStream(st);


                //picture.Image =CropImage((Bitmap)_img, 310, 233);

                //picture.Image = _img;
                //

            }
            catch (Exception)
            {
            }
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
                PhotoCapture.WebFileService.WebFileManager fm = new PhotoCapture.WebFileService.WebFileManager();
                this.UserId = fm.GetUserId(txtUserName.Text, txtPassword.Text).ToString();
                if (int.Parse(this.UserId) < 1)
                {
                    MessageBox.Show("Invalid User, Please Login.");
                    btnLogin.Text = "Login";
                    return;
                }
                btnLogin.Enabled = false;
                btnLogOut.Enabled = true;
                btnCapture.Enabled = true;
                enableUserNamePass(false);
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            enableUserNamePass(true);
            btnCapture.Enabled = false;
            btnLogOut.Enabled = false;
            btnLogin.Enabled = true;
            btnSave.Enabled = false;
            txtUserName.Text = "";
            txtPassword.Text = "";
            this.UserId = "";


        }
        private void enableUserNamePass(bool enable)
        {
            txtUserName.Enabled = enable;
            txtPassword.Enabled = enable;

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            PhotoCapture.frmSettings frmSettings = new PhotoCapture.frmSettings();
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