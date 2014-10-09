using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using zsi.dtrs;
using zsi.dtrs.Models;
//using System.Web.Script.Serialization;
using zsi.dtrs.Properties;
using zsi.dtrs.Models.DataControllers;
using System.Threading;
namespace zsi.Biometrics
{
    public partial class frmTimInOut:FingersMasterScanner
    {
        private System.Windows.Forms.Timer tmrTimeInOut;
        private IContainer components;
        private Label lblProcessStatus;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pbCompanyLogo;
        private TextBox txtName;
        private PictureBox pbProfileImage;
        private PictureBox pbFinger;
        private Label lblActualTimeOut;
        private GroupBox groupBox1;
        private Label lblActualTimeIn;
        private WebBrowser webBrowser1;
        private TextBox txtDay;
        private TextBox txtTime;
        private Label lblPlsWait;
        private GroupBox groupBox2;
        private Panel pnlMain;
    
        private frmMain _ParentForm { get; set; }
        private string ClientAction { get; set; }
        private string InOut { get; set; }        
        //p_clientId,p_ClientEmployeeId,p_TimeInOut        
        public frmTimInOut()
        {


            InitializeComponent();
            this.SetControls(pbFinger);            
            var url = "http://localhost:5445/ads?p_clientid=1" ;
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
           // pbProfileImage.Image = zsi.dtrs.Util.GetNoPhoto();
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
                    //Profile info = zsi.dtrs.Models.DataControllers.dcProfile_SQL.VerifyBiometricsData(_byte);


                    //WaitStop
                    this.Invoke(new Function(delegate()
                    {
                        this.lblPlsWait.Visible = false; 
                    }));

                /*
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
                */
                //base.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ProcessProfile(object info)
        {
             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void GetTime()
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
        }
        private void RunTimer()
        {

           // ssStatus1.Text = "Updating Fingers Templates...";
            Application.DoEvents();
            object _dc = new object();
            /*
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
            */
        }

        private void frmTimInOut_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimInOut_Load(object sender, EventArgs e)
        {
           // pbCompanyLogo.Image = zsi.PhotoFingCapture.Util.ByteArrayToImage(ClientSettings.ClientWorkStationInfo.CompanyLogo);
            pbCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void bgwTimeInOut_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgwTimeInOut_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void tmrTimeInOut_Tick(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimInOut));
            this.tmrTimeInOut = new System.Windows.Forms.Timer(this.components);
            this.lblProcessStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbCompanyLogo = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pbProfileImage = new System.Windows.Forms.PictureBox();
            this.pbFinger = new System.Windows.Forms.PictureBox();
            this.lblActualTimeOut = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblActualTimeIn = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblPlsWait = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfileImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrTimeInOut
            // 
            this.tmrTimeInOut.Enabled = true;
            this.tmrTimeInOut.Interval = 10000;
            // 
            // lblProcessStatus
            // 
            this.lblProcessStatus.AutoSize = true;
            this.lblProcessStatus.Location = new System.Drawing.Point(410, 138);
            this.lblProcessStatus.Name = "lblProcessStatus";
            this.lblProcessStatus.Size = new System.Drawing.Size(40, 13);
            this.lblProcessStatus.TabIndex = 55;
            this.lblProcessStatus.Text = "           ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1016, 678);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "                 www.zetta-solutions.net                   ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1016, 608);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // pbCompanyLogo
            // 
            this.pbCompanyLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCompanyLogo.BackColor = System.Drawing.SystemColors.Window;
            this.pbCompanyLogo.Location = new System.Drawing.Point(1017, 3);
            this.pbCompanyLogo.Name = "pbCompanyLogo";
            this.pbCompanyLogo.Size = new System.Drawing.Size(230, 187);
            this.pbCompanyLogo.TabIndex = 34;
            this.pbCompanyLogo.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.DarkBlue;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(15, 197);
            this.txtName.Margin = new System.Windows.Forms.Padding(0);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(1231, 53);
            this.txtName.TabIndex = 41;
            this.txtName.TabStop = false;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbProfileImage
            // 
            this.pbProfileImage.BackColor = System.Drawing.SystemColors.Window;
            this.pbProfileImage.Location = new System.Drawing.Point(15, 3);
            this.pbProfileImage.Name = "pbProfileImage";
            this.pbProfileImage.Size = new System.Drawing.Size(236, 188);
            this.pbProfileImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfileImage.TabIndex = 36;
            this.pbProfileImage.TabStop = false;
            // 
            // pbFinger
            // 
            this.pbFinger.BackColor = System.Drawing.SystemColors.Window;
            this.pbFinger.Location = new System.Drawing.Point(257, 3);
            this.pbFinger.Name = "pbFinger";
            this.pbFinger.Size = new System.Drawing.Size(146, 186);
            this.pbFinger.TabIndex = 9;
            this.pbFinger.TabStop = false;
            // 
            // lblActualTimeOut
            // 
            this.lblActualTimeOut.AutoSize = true;
            this.lblActualTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualTimeOut.Location = new System.Drawing.Point(18, 69);
            this.lblActualTimeOut.Name = "lblActualTimeOut";
            this.lblActualTimeOut.Size = new System.Drawing.Size(149, 39);
            this.lblActualTimeOut.TabIndex = 50;
            this.lblActualTimeOut.Text = "00:00:00";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblActualTimeIn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1015, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 143);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actual Time In";
            // 
            // lblActualTimeIn
            // 
            this.lblActualTimeIn.AutoSize = true;
            this.lblActualTimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualTimeIn.Location = new System.Drawing.Point(18, 59);
            this.lblActualTimeIn.Name = "lblActualTimeIn";
            this.lblActualTimeIn.Size = new System.Drawing.Size(158, 39);
            this.lblActualTimeIn.TabIndex = 50;
            this.lblActualTimeIn.Text = "00:00:00 ";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(15, 253);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(995, 441);
            this.webBrowser1.TabIndex = 48;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // txtDay
            // 
            this.txtDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDay.ForeColor = System.Drawing.Color.White;
            this.txtDay.Location = new System.Drawing.Point(409, 100);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(601, 31);
            this.txtDay.TabIndex = 47;
            this.txtDay.TabStop = false;
            this.txtDay.Text = "January Wednesday, 01/11/2012";
            this.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTime
            // 
            this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime.BackColor = System.Drawing.Color.Black;
            this.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.ForeColor = System.Drawing.Color.White;
            this.txtTime.Location = new System.Drawing.Point(409, 3);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(601, 91);
            this.txtTime.TabIndex = 46;
            this.txtTime.TabStop = false;
            this.txtTime.Text = "8:30:01 AM";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPlsWait
            // 
            this.lblPlsWait.AutoSize = true;
            this.lblPlsWait.Location = new System.Drawing.Point(276, 81);
            this.lblPlsWait.Name = "lblPlsWait";
            this.lblPlsWait.Size = new System.Drawing.Size(101, 13);
            this.lblPlsWait.TabIndex = 22;
            this.lblPlsWait.Text = "Verifying... Pls. wait.";
            this.lblPlsWait.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblActualTimeOut);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1015, 437);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 143);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actual Time Out";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Silver;
            this.pnlMain.Controls.Add(this.lblProcessStatus);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Controls.Add(this.webBrowser1);
            this.pnlMain.Controls.Add(this.pbCompanyLogo);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.txtName);
            this.pnlMain.Controls.Add(this.txtDay);
            this.pnlMain.Controls.Add(this.txtTime);
            this.pnlMain.Controls.Add(this.pbProfileImage);
            this.pnlMain.Controls.Add(this.pbFinger);
            this.pnlMain.Controls.Add(this.lblPlsWait);
            this.pnlMain.Location = new System.Drawing.Point(12, 23);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1254, 703);
            this.pnlMain.TabIndex = 54;
            // 
            // frmTimInOut
            // 
            this.ClientSize = new System.Drawing.Size(1278, 749);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmTimInOut";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfileImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }
    }

 
}
