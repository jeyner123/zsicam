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
    public partial class frmVerification:FingersMasterScanner
    {
        private frmMain _ParentForm { get; set; }
        private string ClientAction { get; set; }
        public frmVerification(frmMain MainForm)
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


                    Profile info = zsi.PhotoFingCapture.Models.DataControllers.dcProfile_SQL.VerifyBiometricsData(GetFingNo(), _byte);

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
                        MessageBox.Show("Finger not identified");
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
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                dcUser _dc = new dcUser();
                zsi.Framework.Security.Cryptography _crypt = new zsi.Framework.Security.Cryptography();

                this.Invoke(new Function(delegate()
                {
                    this.ClientAction = this.cbVerificationPurpose.SelectedItem.ToString().ToLower();
                }));
                    switch (this.ClientAction)
                    {

                        case "user login":
                             //ClientSettings.UserInfo = _dc.GetUserInfo(info.ProfileId);
                            ClientSettings.UserInfo = new User();
                            ClientSettings.UserInfo.UserId = info.UserId;
                            ClientSettings.UserInfo.WSMacAddress = "add";
                            if (ClientSettings.UserInfo.UserId != 0)
                            {
                                this.Invoke(new Function(delegate(){
                                    //    this.ParentForm.EnableControls(true);
                                    this._ParentForm.CheckPermission(true);  
                                    this.Close();

                                }));
                            }
                            else
                            {
                                MessageBox.Show("User not login.");
                            }
                            break;
                        case "profile info":
                            if (ClientSettings.UserInfo == null) goto NotYetLoggedIn;
                            if (ClientSettings.UserInfo.UserId == 0) goto NotYetLoggedIn;
                            if (ClientSettings.UserInfo.UserId != 0)
                            {

                                string _guID = Guid.NewGuid().ToString();
                                _dc.UpdateRequestCode(ClientSettings.UserInfo.UserId, _guID);
                                p.StartInfo.FileName = Settings.Default.DefaultWebsite + "Client?p_ClientAction=Profile Info&p_ClientRequestCode=" + _guID + "&p_ProfileId=" + info.ProfileId;
                                p.Start();
                                this.Invoke(new Function(delegate(){
                                    this.Close();
                                }));
                            }
                            else
                            {
                                MessageBox.Show("User not login.");
                            }
                            break;
                        default:
                            MessageBox.Show("Finger identified: (" + info.ProfileId + ") - " + info.FullName);

                            break;


                    }
                    return;
                NotYetLoggedIn:
                    MessageBox.Show("Please login first.");
            }
            catch (Exception ex) {
                throw ex;
            }
        }
 

        private int GetFingNo() {
            int _result = -1;
            if (rdLS.Checked == true)
                _result = 9;
            else if (rdLR.Checked == true)
                _result = 8;
            else if (rdLM.Checked == true)
                _result = 7;
            else if (rdLI.Checked == true)
                _result = 6;
            else if (rdLT.Checked == true)
                _result = 5;
            else if (rdRS.Checked == true)
                _result = 4;
            else if (rdRR.Checked == true)
                _result = 3;
            else if (rdRM.Checked == true)
                _result = 2;
            else if (rdRI.Checked == true)
                _result = 1;
            else if (rdRT.Checked == true)
                _result = 0;
            return _result; 
        }

        private void frmVerification_Load(object sender, EventArgs e)
        {
            cbVerificationPurpose.SelectedIndex = 0;
        }
    }
}
