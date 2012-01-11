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
        public frmTimInOut()
        {
            InitializeComponent();
            this.SetControls(pbFinger);
            txtDay.Text = DateTime.Now.ToLongDateString();
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


                byte[] img = new dcProfile().GetFrontImageByProfileId(info.ProfileId);

                pbProfileImage.Image = zsi.PhotoFingCapture.Util.ByteArrayToImage(img);
                this.Invoke(new Function(delegate()
                {
                    txtName.Text = "(" + info.ProfileId + ") - " + info.FullName;
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

      
 

     

    }
}
