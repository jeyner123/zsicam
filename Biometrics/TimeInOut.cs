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
using zsi.Framework.Common;
using System.Threading;
namespace zsi.Biometrics
{
    public partial class frmTimInOut:FingersMasterScanner
    {
        private frmMain _ParentForm { get; set; }
        private string ClientAction { get; set; }
        private string InOut { get; set; }        
        //p_clientId,p_ClientEmployeeId,p_TimeInOut        
        public frmTimInOut()
        {


            InitializeComponent();
            this.SetControls(pbFinger);            
            //var url = "http://localhost:5445/ads?p_clientid=" + clientid;
            var url = "http://zprofile.info/ads?p_clientid=" + ClientSettings.ClientWorkStationInfo.ClientId;
            webBrowser1.Navigate(new Uri(url));

            if (Screen.AllScreens.Count() > 1)
            {
                //EXTENDED SCREEN
                Screen scrn = Screen.AllScreens[1];
                this.Location = Screen.AllScreens[1].WorkingArea.Location;
                int sceenwidth = scrn.WorkingArea.Width;
                int sceenheight = scrn.WorkingArea.Height;
                pnlMain.Left = (sceenwidth - (sceenwidth / 2)) - (pnlMain.Width - (pnlMain.Width / 2));
                // pnlMain.Top= (sceenheight - (sceenheight/ 2)) - (pnlMain.Height- (pnlMain.Height/ 2));

            }
            else {

                int sceenwidth = Screen.PrimaryScreen.WorkingArea.Width;
                int sceenheight = Screen.PrimaryScreen.WorkingArea.Height;
                pnlMain.Left = (sceenwidth - (sceenwidth / 2)) - (pnlMain.Width - (pnlMain.Width / 2));
                // pnlMain.Top= (sceenheight - (sceenheight/ 2)) - (pnlMain.Height- (pnlMain.Height/ 2));

            }



            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            pbProfileImage.Image = zsi.PhotoFingCapture.Util.GetNoPhoto();
        }

        public frmTimInOut(frmMain MainForm)
        {
            InitializeComponent();
            this._ParentForm = MainForm;
            this.SetControls(pbFinger);
        } 
        public override void Process(DPFP.Sample Sample)
        {
            try
            {
 
                    base.Process(Sample);
                    frmMain _frm = this._ParentForm;
                    byte[] _byte = null;
                    Sample.Serialize(ref _byte);

                    //Wait Start

                    this.Invoke(new Function(delegate()
                    {
                        this.lblPlsWait.Visible = true;                     
                    }));


                    //Profile info = zsi.PhotoFingCapture.Models.DataControllers.dcProfile_SQL.VerifyBiometricsData(0, _byte);
                    Profile info = zsi.PhotoFingCapture.Models.DataControllers.dcProfile_SQL.VerifyBiometricsData(_byte);


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
                            pbProfileImage.Image = zsi.PhotoFingCapture.Util.GetNoPhoto(); 
                        }));
                         
                    }
                //base.Dispose();
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
                    txtName.Text = "(" + info.EmployeeNo + ") - " + info.FullName;


                   dcTimeInOutLog_OleDb dc = new dcTimeInOutLog_OleDb();
                   DateTime TimeIn; DateTime TimeOut;
                    dc.TimeInOut(info, DateTime.Now,out TimeIn,out TimeOut);


                    if (TimeIn == new DateTime(1, 1, 1))
                        lblActualTimeIn.Text = "00:00:00";
                    else
                        lblActualTimeIn.Text = TimeIn.ToLongTimeString();


                    if (TimeOut == new DateTime(1, 1, 1))
                        lblActualTimeOut.Text = "00:00:00";
                    else
                        lblActualTimeOut.Text = TimeOut.ToLongTimeString();
  
                }));

               
                
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
            txtDay.Text = DateTime.Now.ToLongDateString();
        }

        private void GetTime()
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
        }
        private void RunTimer()
        {

           // ssStatus1.Text = "Updating Fingers Templates...";
            Application.DoEvents();
            dcProfile_SQL _dc = new dcProfile_SQL();
            ProcessMaster _pm = new ProcessMaster(GetTime);
            _pm.OnProcessStop = delegate()
            {
                //ssStatus1.Text = "Fingers Templates processing is done.";
                Application.DoEvents();
                Thread.Sleep(1000);
               // ssStatus1.Text = "";
                Application.DoEvents();
            };
            _pm.Start();
        }

        private void frmTimInOut_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimInOut_Load(object sender, EventArgs e)
        {
            pbCompanyLogo.Image = zsi.PhotoFingCapture.Util.ByteArrayToImage(ClientSettings.ClientWorkStationInfo.CompanyLogo);
            pbCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void bgwTimeInOut_DoWork(object sender, DoWorkEventArgs e)        
        {
            this.Invoke(new Function(delegate()
               {
                   lblProcessStatus.Text = "synchronizing time(in/out) logs";
               }));
            
            dcTimeInOutLog_OleDb _dc = new dcTimeInOutLog_OleDb();
            _dc.TimeInOutSync();

        }

        private void bgwTimeInOut_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProcessStatus.Text = "";
            tmrTimeInOut.Enabled = true;
        }

        private void tmrTimeInOut_Tick(object sender, EventArgs e)
        {
            tmrTimeInOut.Enabled = false;
            bgwTimeInOut.RunWorkerAsync();
        }
    }

 
}
