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
  
 
namespace WebCamServiceSample
{
    
    public partial class Form1 : Form
    {
        WebCamService.WebCamManager WebCam;
        private static string _UserId;
        public string UserId{
            set { _UserId = value;}
            get { return _UserId;}
        }

        public Form1()
        {
            try
            {
                this.InitializeComponent();
                WebCam = new WebCamManager();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                System.IO.MemoryStream st = new System.IO.MemoryStream(WebCam.GrabFrame());
                picture.Image = System.Drawing.Image.FromStream(st);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch(Exception )
            {
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            pbResult.Image = picture.Image; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             try
             {
                string fileName = "c:\\image.jpg";

                pbResult.Image.Save(fileName);
                System.IO.FileInfo oFileInfo = new System.IO.FileInfo(fileName);
                WebFileManager.FileUploadViaWebService(oFileInfo,this.UserId);
                MessageBox.Show("Photo has been uploaded to the server.");
           }
             catch (Exception ex ) {
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
                ZSICam.WebFileService.WebFileManager fm = new ZSICam.WebFileService.WebFileManager();
                this.UserId = fm.GetUserId(txtUserName.Text, txtPassword.Text).ToString();
                if (int.Parse(this.UserId) < 1)
                {
                    MessageBox.Show("Invalid User, Please Login.");
                    btnLogin.Text = "Login";
                    return;
                }
                btnLogin.Enabled = false;
                btnLogOut.Enabled = true;
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
            btnLogOut.Enabled = false;
            btnLogin.Enabled = true;
            txtUserName.Text= "";
            txtPassword.Text = "";
            this.UserId = "";
 
 
        }
        private void enableUserNamePass(bool enable) {
            txtUserName.Enabled = enable;
            txtPassword.Enabled = enable;
 
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ZSICam.frmSettings frmSettings = new ZSICam.frmSettings();
            frmSettings.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbImagePosition.SelectedIndex = 0;
        }
    }








       



}