using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using zsi.PhotoFingCapture;
using zsi.PhotoFingCapture.Models;
using System.Web.Script.Serialization;
using zsi.PhotoFingCapture.Properties;
using zsi.PhotoFingCapture.Models.DataControllers;
namespace zsi.Biometrics
{
    public partial class frmTimInOut:FingersMasterScanner
    {
        private frmMain ParentForm { get; set; }
        private string ClientAction { get; set; }
        private string InOut { get; set; }        
        //p_clientId,p_ClientEmployeeId,p_TimeInOut        
        public frmTimInOut()
        {

            InitializeComponent();
            this.SetControls(pbFinger);
            txtDay.Text = DateTime.Now.ToLongDateString();
            var clientid = 0;
            //var url = "http://localhost:5445/ads?p_clientid=" + clientid;
            var url = "http://zprofile.info/ads?p_clientid=" + clientid;
            webBrowser1.Navigate(new Uri(url));
            int sceenwidth = Screen.PrimaryScreen.WorkingArea.Width;
            int sceenheight = Screen.PrimaryScreen.WorkingArea.Height;
            pnlMain.Left= (sceenwidth - (sceenwidth / 2)) - (pnlMain.Width - (pnlMain.Width/ 2)); 
            pnlMain.Top= (sceenheight - (sceenheight/ 2)) - (pnlMain.Height- (pnlMain.Height/ 2));
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
        }

        public frmTimInOut(frmMain MainForm)
        {
            InitializeComponent();
            this.ParentForm = MainForm;
            this.SetControls(pbFinger);
        } 
        public override void Process(DPFP.Sample Sample)
        {
            try
            {
 
                    base.Process(Sample);
                    frmMain _frm = this.ParentForm;
                    byte[] _byte = null;
                    Sample.Serialize(ref _byte);

                    //Wait Start

                    this.Invoke(new Function(delegate()
                    {
                        this.lblPlsWait.Visible = true;                     
                    }));


                    Profile info = zsi.PhotoFingCapture.Models.DataControllers.dcFingersTemplate.VerifyBiometricsData(0, _byte);

                    //WaitStop
                    this.Invoke(new Function(delegate()
                    {
                        this.lblPlsWait.Visible = false; 
                    }));


                    if (info.ProfileId > 0)
                    {
                        ProcessProfile(info);
                    }
                    else
                    {
                        this.Invoke(new Function(delegate()
                        {
                            txtName.Text = "Finger not identified";
                            pbProfileImage.Image = null; 
                        }));
                         
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ProcessProfile(Profile info)
        {
            try
            {
                string _ClientRequestCode = string.Empty;
               // System.Diagnostics.Process p = new System.Diagnostics.Process();
                dcUser _dc = new dcUser();
                zsi.Framework.Security.Cryptography _crypt = new zsi.Framework.Security.Cryptography();
                pbProfileImage.Image = zsi.PhotoFingCapture.Util.ByteArrayToImage(info.FrontImg);
                this.Invoke(new Function(delegate()
                {
                    txtName.Text = "(" + info.ProfileId + ") - " + info.FullName;


                    dcTimeInOutLog dc = new dcTimeInOutLog();
                   DateTime TimeIn; DateTime TimeOut;
                    dc.TimeInOut(info, DateTime.Now,out TimeIn,out TimeOut);
  
                        lblActualTimeIn.Text = TimeIn.ToShortTimeString();

                        if (TimeOut == new DateTime(1, 1, 1))
                            lblActualTimeOut.Text = "00:00";
                        else
                            lblActualTimeOut.Text = TimeOut.ToShortTimeString();
  
                }));

               
                
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void frmTimInOut_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimInOut_Load(object sender, EventArgs e)
        {

        }

     

    }
}
