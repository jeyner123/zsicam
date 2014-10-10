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
using zsi.dtrs.Properties;
using zsi.dtrs.Models.DataControllers;
namespace zsi.Biometrics
{
    public partial class frmVerification:FingersMasterScanner
    {
        private Label label3;
        private ComboBox cbVerificationPurpose;
        private Label label2;
        private RadioButton rdRT;
        private RadioButton rdRI;
        private RadioButton rdRM;
        private RadioButton rdRR;
        private Label lblPlsWait;
        private PictureBox pbFinger;
        private RadioButton rdRS;
        private RadioButton rdLT;
        private RadioButton rdLI;
        private RadioButton rdLM;
        private RadioButton rdLR;
        private Label label1;
        private RadioButton rdLS;
        private GroupBox groupBox1;
    
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
                    //Wait Start
                    this.Invoke(new Function(delegate()
                    {
                        this.lblPlsWait.Visible = true;                     
                    }));

                    Employee info = zsi.dtrs.Models.DataControllers.dcEmployee.VerifyBiometricsData(GetFingNo(), Sample);
                   

                    //WaitStop
                    this.Invoke(new Function(delegate()
                    {
                        this.lblPlsWait.Visible = false; 
                    }));

                  
                    if (info!=null)
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


        private void ProcessProfile(Employee info)
        {
            try
            {
                this.ClientAction = "";
                string _ClientRequestCode = string.Empty;
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                //dcUser _dc = new dcUser();
                //zsi.Framework.Security.Cryptography _crypt = new zsi.Framework.Security.Cryptography();

                this.Invoke(new Function(delegate()
                {
                    if(this.cbVerificationPurpose.SelectedItem!=null)
                        this.ClientAction = this.cbVerificationPurpose.SelectedItem.ToString().ToLower();
                }));
                switch (this.ClientAction)
                {

                    case "user login":
                        //ClientSettings.UserInfo = _dc.GetUserInfo(info.ProfileId);
                        /*ClientSettings.UserInfo = new User();
                        ClientSettings.UserInfo.UserId = info.UserId;
                        ClientSettings.UserInfo.WSMacAddress = "add";
                        if (ClientSettings.UserInfo.UserId != 0)
                        {
                            this.Invoke(new Function(delegate()
                            {
                                //    this.ParentForm.EnableControls(true);
                                this._ParentForm.CheckPermission(true);
                                this.Close();

                            }));
                        }
                        else
                        {
                            MessageBox.Show("User not login.");
                        }
                         */
                        break;
                    
                    default:
                        MessageBox.Show("Finger identified: (" + info.Empl_Id_No + ") - " + info.Empl_Name);

                        break;


                }
                return;
 
            }
            catch (Exception ex)
            {
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

        private void InitializeComponent()
        {
            System.Windows.Forms.Button CloseButton;
            System.Windows.Forms.Label lblPrompt;
            this.label3 = new System.Windows.Forms.Label();
            this.cbVerificationPurpose = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdRT = new System.Windows.Forms.RadioButton();
            this.rdRI = new System.Windows.Forms.RadioButton();
            this.rdRM = new System.Windows.Forms.RadioButton();
            this.rdRR = new System.Windows.Forms.RadioButton();
            this.lblPlsWait = new System.Windows.Forms.Label();
            this.pbFinger = new System.Windows.Forms.PictureBox();
            this.rdRS = new System.Windows.Forms.RadioButton();
            this.rdLT = new System.Windows.Forms.RadioButton();
            this.rdLI = new System.Windows.Forms.RadioButton();
            this.rdLM = new System.Windows.Forms.RadioButton();
            this.rdLR = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdLS = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            CloseButton = new System.Windows.Forms.Button();
            lblPrompt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            CloseButton.Location = new System.Drawing.Point(45, 307);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(75, 23);
            CloseButton.TabIndex = 26;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // lblPrompt
            // 
            lblPrompt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(235)))), ((int)(((byte)(226)))));
            lblPrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblPrompt.Location = new System.Drawing.Point(184, 20);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Padding = new System.Windows.Forms.Padding(5);
            lblPrompt.Size = new System.Drawing.Size(338, 128);
            lblPrompt.TabIndex = 27;
            lblPrompt.Text = "To verify your identity, touch fingerprint reader with any enrolled finger.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Verification Purpose:";
            // 
            // cbVerificationPurpose
            // 
            this.cbVerificationPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVerificationPurpose.FormattingEnabled = true;
            this.cbVerificationPurpose.Items.AddRange(new object[] {
            "User Login",
            "Verify Finger"});
            this.cbVerificationPurpose.Location = new System.Drawing.Point(22, 253);
            this.cbVerificationPurpose.Name = "cbVerificationPurpose";
            this.cbVerificationPurpose.Size = new System.Drawing.Size(143, 21);
            this.cbVerificationPurpose.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "Right Fingers:";
            // 
            // rdRT
            // 
            this.rdRT.AutoSize = true;
            this.rdRT.Checked = true;
            this.rdRT.Location = new System.Drawing.Point(247, 117);
            this.rdRT.Name = "rdRT";
            this.rdRT.Size = new System.Drawing.Size(58, 17);
            this.rdRT.TabIndex = 32;
            this.rdRT.TabStop = true;
            this.rdRT.Text = "Thumb";
            this.rdRT.UseVisualStyleBackColor = true;
            // 
            // rdRI
            // 
            this.rdRI.AutoSize = true;
            this.rdRI.Location = new System.Drawing.Point(191, 117);
            this.rdRI.Name = "rdRI";
            this.rdRI.Size = new System.Drawing.Size(51, 17);
            this.rdRI.TabIndex = 31;
            this.rdRI.Text = "Index";
            this.rdRI.UseVisualStyleBackColor = true;
            // 
            // rdRM
            // 
            this.rdRM.AutoSize = true;
            this.rdRM.Location = new System.Drawing.Point(135, 117);
            this.rdRM.Name = "rdRM";
            this.rdRM.Size = new System.Drawing.Size(56, 17);
            this.rdRM.TabIndex = 30;
            this.rdRM.Text = "Middle";
            this.rdRM.UseVisualStyleBackColor = true;
            // 
            // rdRR
            // 
            this.rdRR.AutoSize = true;
            this.rdRR.Location = new System.Drawing.Point(79, 117);
            this.rdRR.Name = "rdRR";
            this.rdRR.Size = new System.Drawing.Size(47, 17);
            this.rdRR.TabIndex = 29;
            this.rdRR.Text = "Ring";
            this.rdRR.UseVisualStyleBackColor = true;
            // 
            // lblPlsWait
            // 
            this.lblPlsWait.AutoSize = true;
            this.lblPlsWait.Location = new System.Drawing.Point(38, 113);
            this.lblPlsWait.Name = "lblPlsWait";
            this.lblPlsWait.Size = new System.Drawing.Size(101, 13);
            this.lblPlsWait.TabIndex = 29;
            this.lblPlsWait.Text = "Verifying... Pls. wait.";
            this.lblPlsWait.Visible = false;
            // 
            // pbFinger
            // 
            this.pbFinger.BackColor = System.Drawing.SystemColors.Window;
            this.pbFinger.Location = new System.Drawing.Point(19, 20);
            this.pbFinger.Name = "pbFinger";
            this.pbFinger.Size = new System.Drawing.Size(146, 189);
            this.pbFinger.TabIndex = 28;
            this.pbFinger.TabStop = false;
            // 
            // rdRS
            // 
            this.rdRS.AutoSize = true;
            this.rdRS.Location = new System.Drawing.Point(23, 117);
            this.rdRS.Name = "rdRS";
            this.rdRS.Size = new System.Drawing.Size(50, 17);
            this.rdRS.TabIndex = 28;
            this.rdRS.Text = "Small";
            this.rdRS.UseVisualStyleBackColor = true;
            // 
            // rdLT
            // 
            this.rdLT.AutoSize = true;
            this.rdLT.Location = new System.Drawing.Point(247, 57);
            this.rdLT.Name = "rdLT";
            this.rdLT.Size = new System.Drawing.Size(58, 17);
            this.rdLT.TabIndex = 27;
            this.rdLT.Text = "Thumb";
            this.rdLT.UseVisualStyleBackColor = true;
            // 
            // rdLI
            // 
            this.rdLI.AutoSize = true;
            this.rdLI.Location = new System.Drawing.Point(191, 57);
            this.rdLI.Name = "rdLI";
            this.rdLI.Size = new System.Drawing.Size(51, 17);
            this.rdLI.TabIndex = 26;
            this.rdLI.Text = "Index";
            this.rdLI.UseVisualStyleBackColor = true;
            // 
            // rdLM
            // 
            this.rdLM.AutoSize = true;
            this.rdLM.Location = new System.Drawing.Point(135, 57);
            this.rdLM.Name = "rdLM";
            this.rdLM.Size = new System.Drawing.Size(56, 17);
            this.rdLM.TabIndex = 25;
            this.rdLM.Text = "Middle";
            this.rdLM.UseVisualStyleBackColor = true;
            // 
            // rdLR
            // 
            this.rdLR.AutoSize = true;
            this.rdLR.Location = new System.Drawing.Point(79, 57);
            this.rdLR.Name = "rdLR";
            this.rdLR.Size = new System.Drawing.Size(47, 17);
            this.rdLR.TabIndex = 24;
            this.rdLR.Text = "Ring";
            this.rdLR.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Left Fingers:";
            // 
            // rdLS
            // 
            this.rdLS.AutoSize = true;
            this.rdLS.Location = new System.Drawing.Point(23, 57);
            this.rdLS.Name = "rdLS";
            this.rdLS.Size = new System.Drawing.Size(50, 17);
            this.rdLS.TabIndex = 22;
            this.rdLS.Text = "Small";
            this.rdLS.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdRT);
            this.groupBox1.Controls.Add(this.rdRI);
            this.groupBox1.Controls.Add(this.rdRM);
            this.groupBox1.Controls.Add(this.rdRR);
            this.groupBox1.Controls.Add(this.rdRS);
            this.groupBox1.Controls.Add(this.rdLT);
            this.groupBox1.Controls.Add(this.rdLI);
            this.groupBox1.Controls.Add(this.rdLM);
            this.groupBox1.Controls.Add(this.rdLR);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdLS);
            this.groupBox1.Location = new System.Drawing.Point(184, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 164);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fingers";
            // 
            // frmVerification
            // 
            this.ClientSize = new System.Drawing.Size(541, 351);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbVerificationPurpose);
            this.Controls.Add(this.lblPlsWait);
            this.Controls.Add(this.pbFinger);
            this.Controls.Add(CloseButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(lblPrompt);
            this.Name = "frmVerification";
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
