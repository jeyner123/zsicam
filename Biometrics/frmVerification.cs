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
namespace zsi.Biometrics
{
    public partial class frmVerification:FingersMasterScanner
    {
        private frmMain ParentForm { get; set; }
        public frmVerification(frmMain MainForm)
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


                    Profile info = zsi.PhotoFingCapture.Models.DataControllers.dcFingersTemplate.VerifyBiometricsData(GetFingNo(), _byte);

                    //WaitStop
                    this.Invoke(new Function(delegate()
                    {
                        this.lblPlsWait.Visible = false; 
                    }));


                    if (info.ProfileId > 0)
                    {
                        MessageBox.Show("Finger identified: (" + info.ProfileId + ") - " + info.FullName);
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
