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
                System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
                Sample.Serialize(_MemoryStream);
                byte[] _byte = zsi.PhotoFingCapture.Util.StreamToByte(_MemoryStream);
                string data=  _frm.WebFileMgr.VerifyBiometricsData(_frm.UserId, _byte);


                Profile _profile = (Profile)new JavaScriptSerializer().Deserialize<Profile>(data);

                if (_profile.ProfileId > 0)
                {
                    MessageBox.Show("verified");
                }
                else {
                    MessageBox.Show("not verified");                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }     
    }
}
