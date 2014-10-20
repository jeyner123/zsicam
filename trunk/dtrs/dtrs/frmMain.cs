using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zsi.Biometrics;
using zsi.dtrs.Models;
using zsi.dtrs.Models.DataControllers;


namespace zsi.dtrs
{
    public partial class frmMain : Form
    {
        private string ImageLocation { get { return ConfigurationManager.AppSettings["ImageLocation"].ToString(); } }
        private string FileName { get; set; }
        public FingersBiometrics FingerBiometrics { get; set; }
        
        public frmMain()
        {
            try
            {
                InitializeComponent();
                InitFingerPrintSettings();
                //temporary filename;
                this.FileName = "emp54321.jpg";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void ShowScanForm(object sender, int FingerPosition)
        {
            Color _bcolor = ((Control)sender).BackColor;
            DialogResult result = DialogResult.None;
            
            if (_bcolor == Color.Green)
            {
                result = MessageBox.Show("Do you want to delete data?", "Confirmation!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            }
            if (result == DialogResult.Cancel) return;

            zsi.Biometrics.frmScanFinger scanf = new frmScanFinger(sender, this.FingerBiometrics, FingerPosition);
            scanf.IsAutoClose = chkAutoClose.Checked;           
            scanf.ShowDialog();
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
            ShowScanForm(sender, 6);

        }

        private void btnLTF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender, 5);

        }

        private void btnRSF_Click(object sender, EventArgs e)
        {
            ShowScanForm(sender, 4);

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

        private void btnUploadFG_Click(object sender, EventArgs e)
        {
            UploadFingerTemplates();
        }
        private byte[] LoadImgFile(string FileName) {
            byte[] bImg=null;
            if (File.Exists(FileName))
            {
                Image img = Image.FromFile(FileName);
               
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bImg = ms.ToArray();
                }
            }
            return bImg;
        }
        private void UploadFingerTemplates()
        {
            try
            {
                FingersBiometrics f = this.FingerBiometrics;
                EmployeeTSI info = new EmployeeTSI();
                info.Empl_Id_No = 1;
                info.TSI = f.TSI;
                info.IMG = this.LoadImgFile(this.ImageLocation + @"\" + this.FileName);
                info.RTF = f.ByteTemplate.RTF;
                info.RIF = f.ByteTemplate.RIF;
                info.RMF = f.ByteTemplate.RMF;
                info.RRF = f.ByteTemplate.RRF;
                info.RSF = f.ByteTemplate.RSF;
                info.LTF = f.ByteTemplate.LTF;
                info.LIF = f.ByteTemplate.LIF;
                info.LMF = f.ByteTemplate.LMF;
                info.LRF = f.ByteTemplate.LRF;
                info.LSF = f.ByteTemplate.LSF;
                dcEmployeeTSI dc = new dcEmployeeTSI();
                int EmployeeId =dc.Insert(info);
                dc.UpdateEmployeeMatches(EmployeeId, f);

                ClearFingerBiometrics();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                MessageBox.Show("Data has been saved.");
            }
        }

        private string GetTemplateColumnName(int x)
        {
            string _result = "";
            switch (x)
            {
                //right
                case 0: _result = "RT"; break;
                case 1: _result = "RI"; break;
                case 2: _result = "RM"; break;
                case 3: _result = "RR"; break;
                case 4: _result = "RS"; break;
                //left
                case 5: _result = "LT"; break;
                case 6: _result = "LI"; break;
                case 7: _result = "LM"; break;
                case 8: _result = "LR"; break;
                case 9: _result = "LS"; break;
                default: break;
            }
            return _result;
        }

        private void ClearFingerBiometrics()
        {
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
            FingerBiometrics.Clear();
        }
        private void ResetColor(object sender)
        {
            Control Ctrl = ((Control)sender);
            Ctrl.BackColor = Color.White;
            Ctrl.ForeColor = Color.Black;
        }
        private void InitFingerPrintSettings()
        {
            this.FingerBiometrics = new FingersBiometrics();
            this.FingerBiometrics.DataChanged += new OnChangeHandler(OnFingerBiometricsChange);


        }

        private void OnFingerBiometricsChange()
        {
            int _registeredFingers =this.FingerBiometrics.RecordCount;
            if (_registeredFingers > 0)
            {
                this.Invoke(new Function(delegate
                {
                    btnUploadFG.Enabled = true;
                }));
            }
            else
            {

                this.Invoke(new Function(delegate
                {
                    btnUploadFG.Enabled = false;
                }));

            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            zsi.Biometrics.frmVerification _frmVerify = new frmVerification(this);
            _frmVerify.ShowDialog();
        }
        private void testverify()
        {
            zsi.Biometrics.frmVerification _frmVerify = new frmVerification(this);
            _frmVerify.ShowDialog();
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(this.ImageLocation)) System.IO.Directory.CreateDirectory(this.ImageLocation);


            Process p = new Process();
            p.StartInfo.FileName = @"camera\zsi.dtrs.camera.exe";
            p.StartInfo.Arguments = this.ImageLocation + @"\" + this.FileName;
            p.Start();
            p.WaitForExit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void RegisterMe() {
            dcClient dc = new dcClient();           
            dc.Register("1");
        }

    }
}
