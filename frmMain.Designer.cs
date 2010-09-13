namespace zsi.PhotoFingCapture
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnVerifyFP = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPhoto = new System.Windows.Forms.TabPage();
            this.gbImageType = new System.Windows.Forms.GroupBox();
            this.rdbITProfile = new System.Windows.Forms.RadioButton();
            this.cbImagePosition = new System.Windows.Forms.ComboBox();
            this.rdbITCase = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.PictureBox();
            this.tabFingers = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAutoClose = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLTF = new System.Windows.Forms.Button();
            this.btnUploadFG = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLIF = new System.Windows.Forms.Button();
            this.btnRTF = new System.Windows.Forms.Button();
            this.btnLMF = new System.Windows.Forms.Button();
            this.btnRSF = new System.Windows.Forms.Button();
            this.btnRIF = new System.Windows.Forms.Button();
            this.btnLRF = new System.Windows.Forms.Button();
            this.btnRRF = new System.Windows.Forms.Button();
            this.btnRMF = new System.Windows.Forms.Button();
            this.btnLSF = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tab.SuspendLayout();
            this.tabPhoto.SuspendLayout();
            this.gbImageType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.tabFingers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVerifyFP
            // 
            this.btnVerifyFP.Location = new System.Drawing.Point(20, 253);
            this.btnVerifyFP.Name = "btnVerifyFP";
            this.btnVerifyFP.Size = new System.Drawing.Size(139, 53);
            this.btnVerifyFP.TabIndex = 28;
            this.btnVerifyFP.Text = "Verify Finger Prints";
            this.btnVerifyFP.UseVisualStyleBackColor = true;
            this.btnVerifyFP.Click += new System.EventHandler(this.btnVerifyFP_Click);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPhoto);
            this.tab.Controls.Add(this.tabFingers);
            this.tab.Location = new System.Drawing.Point(21, 42);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(714, 391);
            this.tab.TabIndex = 31;
            // 
            // tabPhoto
            // 
            this.tabPhoto.Controls.Add(this.gbImageType);
            this.tabPhoto.Controls.Add(this.label4);
            this.tabPhoto.Controls.Add(this.label3);
            this.tabPhoto.Controls.Add(this.btnCapture);
            this.tabPhoto.Controls.Add(this.pbResult);
            this.tabPhoto.Controls.Add(this.btnUploadPhoto);
            this.tabPhoto.Controls.Add(this.picture);
            this.tabPhoto.Location = new System.Drawing.Point(4, 22);
            this.tabPhoto.Name = "tabPhoto";
            this.tabPhoto.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhoto.Size = new System.Drawing.Size(706, 365);
            this.tabPhoto.TabIndex = 0;
            this.tabPhoto.Text = "Photo Capture";
            this.tabPhoto.UseVisualStyleBackColor = true;
            // 
            // gbImageType
            // 
            this.gbImageType.Controls.Add(this.rdbITProfile);
            this.gbImageType.Controls.Add(this.cbImagePosition);
            this.gbImageType.Controls.Add(this.rdbITCase);
            this.gbImageType.Location = new System.Drawing.Point(14, 10);
            this.gbImageType.Name = "gbImageType";
            this.gbImageType.Size = new System.Drawing.Size(229, 62);
            this.gbImageType.TabIndex = 27;
            this.gbImageType.TabStop = false;
            this.gbImageType.Text = "Image Type";
            // 
            // rdbITProfile
            // 
            this.rdbITProfile.AutoSize = true;
            this.rdbITProfile.Checked = true;
            this.rdbITProfile.Location = new System.Drawing.Point(10, 27);
            this.rdbITProfile.Name = "rdbITProfile";
            this.rdbITProfile.Size = new System.Drawing.Size(54, 17);
            this.rdbITProfile.TabIndex = 18;
            this.rdbITProfile.TabStop = true;
            this.rdbITProfile.Text = "Profile";
            this.rdbITProfile.UseVisualStyleBackColor = true;
            // 
            // cbImagePosition
            // 
            this.cbImagePosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImagePosition.FormattingEnabled = true;
            this.cbImagePosition.Items.AddRange(new object[] {
            "Front",
            "Left",
            "Right",
            "Back"});
            this.cbImagePosition.Location = new System.Drawing.Point(145, 23);
            this.cbImagePosition.Name = "cbImagePosition";
            this.cbImagePosition.Size = new System.Drawing.Size(59, 21);
            this.cbImagePosition.TabIndex = 17;
            // 
            // rdbITCase
            // 
            this.rdbITCase.AutoSize = true;
            this.rdbITCase.Location = new System.Drawing.Point(90, 25);
            this.rdbITCase.Name = "rdbITCase";
            this.rdbITCase.Size = new System.Drawing.Size(49, 17);
            this.rdbITCase.TabIndex = 19;
            this.rdbITCase.Text = "Case";
            this.rdbITCase.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Actual View:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Preview:";
            // 
            // btnCapture
            // 
            this.btnCapture.Enabled = false;
            this.btnCapture.Location = new System.Drawing.Point(258, 75);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(68, 23);
            this.btnCapture.TabIndex = 15;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pbResult
            // 
            this.pbResult.BackColor = System.Drawing.Color.White;
            this.pbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbResult.Location = new System.Drawing.Point(353, 107);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(320, 240);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResult.TabIndex = 24;
            this.pbResult.TabStop = false;
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.Enabled = false;
            this.btnUploadPhoto.Location = new System.Drawing.Point(605, 75);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(68, 23);
            this.btnUploadPhoto.TabIndex = 14;
            this.btnUploadPhoto.Text = "Upload";
            this.btnUploadPhoto.UseVisualStyleBackColor = true;
            this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.White;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.Location = new System.Drawing.Point(15, 107);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(320, 240);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 23;
            this.picture.TabStop = false;
            // 
            // tabFingers
            // 
            this.tabFingers.Controls.Add(this.groupBox1);
            this.tabFingers.Controls.Add(this.btnVerifyFP);
            this.tabFingers.Location = new System.Drawing.Point(4, 22);
            this.tabFingers.Name = "tabFingers";
            this.tabFingers.Padding = new System.Windows.Forms.Padding(3);
            this.tabFingers.Size = new System.Drawing.Size(706, 365);
            this.tabFingers.TabIndex = 1;
            this.tabFingers.Text = "Fingers Capture";
            this.tabFingers.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAutoClose);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnLTF);
            this.groupBox1.Controls.Add(this.btnUploadFG);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnLIF);
            this.groupBox1.Controls.Add(this.btnRTF);
            this.groupBox1.Controls.Add(this.btnLMF);
            this.groupBox1.Controls.Add(this.btnRSF);
            this.groupBox1.Controls.Add(this.btnRIF);
            this.groupBox1.Controls.Add(this.btnLRF);
            this.groupBox1.Controls.Add(this.btnRRF);
            this.groupBox1.Controls.Add(this.btnRMF);
            this.groupBox1.Controls.Add(this.btnLSF);
            this.groupBox1.Location = new System.Drawing.Point(20, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 140);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Register Fingers";
            // 
            // chkAutoClose
            // 
            this.chkAutoClose.AutoSize = true;
            this.chkAutoClose.Location = new System.Drawing.Point(574, 19);
            this.chkAutoClose.Name = "chkAutoClose";
            this.chkAutoClose.Size = new System.Drawing.Size(77, 17);
            this.chkAutoClose.TabIndex = 44;
            this.chkAutoClose.Text = "Auto Close";
            this.chkAutoClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Left Fingers";
            // 
            // btnLTF
            // 
            this.btnLTF.BackColor = System.Drawing.Color.White;
            this.btnLTF.Location = new System.Drawing.Point(458, 49);
            this.btnLTF.Name = "btnLTF";
            this.btnLTF.Size = new System.Drawing.Size(73, 25);
            this.btnLTF.TabIndex = 36;
            this.btnLTF.Text = "Thumb";
            this.btnLTF.UseVisualStyleBackColor = false;
            this.btnLTF.Click += new System.EventHandler(this.btnLTF_Click);
            // 
            // btnUploadFG
            // 
            this.btnUploadFG.Enabled = false;
            this.btnUploadFG.Location = new System.Drawing.Point(574, 69);
            this.btnUploadFG.Name = "btnUploadFG";
            this.btnUploadFG.Size = new System.Drawing.Size(68, 36);
            this.btnUploadFG.TabIndex = 31;
            this.btnUploadFG.Text = "Upload";
            this.btnUploadFG.UseVisualStyleBackColor = true;
            this.btnUploadFG.Click += new System.EventHandler(this.btnUploadFG_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Right Fingers";
            // 
            // btnLIF
            // 
            this.btnLIF.BackColor = System.Drawing.Color.White;
            this.btnLIF.Location = new System.Drawing.Point(369, 49);
            this.btnLIF.Name = "btnLIF";
            this.btnLIF.Size = new System.Drawing.Size(73, 25);
            this.btnLIF.TabIndex = 35;
            this.btnLIF.Text = "Index";
            this.btnLIF.UseVisualStyleBackColor = false;
            this.btnLIF.Click += new System.EventHandler(this.btnLIF_Click);
            // 
            // btnRTF
            // 
            this.btnRTF.BackColor = System.Drawing.Color.White;
            this.btnRTF.Location = new System.Drawing.Point(458, 80);
            this.btnRTF.Name = "btnRTF";
            this.btnRTF.Size = new System.Drawing.Size(73, 25);
            this.btnRTF.TabIndex = 42;
            this.btnRTF.Text = "Thumb";
            this.btnRTF.UseVisualStyleBackColor = false;
            this.btnRTF.Click += new System.EventHandler(this.btnRTF_Click);
            // 
            // btnLMF
            // 
            this.btnLMF.BackColor = System.Drawing.Color.White;
            this.btnLMF.Location = new System.Drawing.Point(280, 49);
            this.btnLMF.Name = "btnLMF";
            this.btnLMF.Size = new System.Drawing.Size(73, 25);
            this.btnLMF.TabIndex = 34;
            this.btnLMF.Text = "Middle";
            this.btnLMF.UseVisualStyleBackColor = false;
            this.btnLMF.Click += new System.EventHandler(this.btnLMF_Click);
            // 
            // btnRSF
            // 
            this.btnRSF.BackColor = System.Drawing.Color.White;
            this.btnRSF.Location = new System.Drawing.Point(102, 80);
            this.btnRSF.Name = "btnRSF";
            this.btnRSF.Size = new System.Drawing.Size(73, 25);
            this.btnRSF.TabIndex = 38;
            this.btnRSF.Text = "Small ";
            this.btnRSF.UseVisualStyleBackColor = false;
            this.btnRSF.Click += new System.EventHandler(this.btnRSF_Click);
            // 
            // btnRIF
            // 
            this.btnRIF.BackColor = System.Drawing.Color.White;
            this.btnRIF.Location = new System.Drawing.Point(369, 80);
            this.btnRIF.Name = "btnRIF";
            this.btnRIF.Size = new System.Drawing.Size(73, 25);
            this.btnRIF.TabIndex = 41;
            this.btnRIF.Text = "Index";
            this.btnRIF.UseVisualStyleBackColor = false;
            this.btnRIF.Click += new System.EventHandler(this.btnRIF_Click);
            // 
            // btnLRF
            // 
            this.btnLRF.BackColor = System.Drawing.Color.White;
            this.btnLRF.Location = new System.Drawing.Point(191, 49);
            this.btnLRF.Name = "btnLRF";
            this.btnLRF.Size = new System.Drawing.Size(73, 25);
            this.btnLRF.TabIndex = 33;
            this.btnLRF.Text = "Ring";
            this.btnLRF.UseVisualStyleBackColor = false;
            this.btnLRF.Click += new System.EventHandler(this.btnLRF_Click);
            // 
            // btnRRF
            // 
            this.btnRRF.BackColor = System.Drawing.Color.White;
            this.btnRRF.Location = new System.Drawing.Point(191, 80);
            this.btnRRF.Name = "btnRRF";
            this.btnRRF.Size = new System.Drawing.Size(73, 25);
            this.btnRRF.TabIndex = 39;
            this.btnRRF.Text = "Ring";
            this.btnRRF.UseVisualStyleBackColor = false;
            this.btnRRF.Click += new System.EventHandler(this.btnRRF_Click);
            // 
            // btnRMF
            // 
            this.btnRMF.BackColor = System.Drawing.Color.White;
            this.btnRMF.Location = new System.Drawing.Point(280, 80);
            this.btnRMF.Name = "btnRMF";
            this.btnRMF.Size = new System.Drawing.Size(73, 25);
            this.btnRMF.TabIndex = 40;
            this.btnRMF.Text = "Middle";
            this.btnRMF.UseVisualStyleBackColor = false;
            this.btnRMF.Click += new System.EventHandler(this.btnRMF_Click);
            // 
            // btnLSF
            // 
            this.btnLSF.BackColor = System.Drawing.Color.White;
            this.btnLSF.Location = new System.Drawing.Point(102, 49);
            this.btnLSF.Name = "btnLSF";
            this.btnLSF.Size = new System.Drawing.Size(73, 25);
            this.btnLSF.TabIndex = 32;
            this.btnLSF.Text = "Small ";
            this.btnLSF.UseVisualStyleBackColor = false;
            this.btnLSF.Click += new System.EventHandler(this.btnLSF_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Enabled = false;
            this.btnLogOut.Location = new System.Drawing.Point(681, 13);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(54, 23);
            this.btnLogOut.TabIndex = 35;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(614, 13);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(68, 23);
            this.btnLogin.TabIndex = 34;
            this.btnLogin.Text = "Log-in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 448);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotoFingCapture 1.0.0 - Zetta Solutions, Inc.";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.tab.ResumeLayout(false);
            this.tabPhoto.ResumeLayout(false);
            this.tabPhoto.PerformLayout();
            this.gbImageType.ResumeLayout(false);
            this.gbImageType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.tabFingers.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVerifyFP;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPhoto;
        private System.Windows.Forms.TabPage tabFingers;
        private System.Windows.Forms.GroupBox gbImageType;
        private System.Windows.Forms.RadioButton rdbITProfile;
        private System.Windows.Forms.ComboBox cbImagePosition;
        private System.Windows.Forms.RadioButton rdbITCase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button btnUploadFG;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLTF;
        private System.Windows.Forms.Button btnLIF;
        private System.Windows.Forms.Button btnLMF;
        private System.Windows.Forms.Button btnLRF;
        private System.Windows.Forms.Button btnLSF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRTF;
        private System.Windows.Forms.Button btnRIF;
        private System.Windows.Forms.Button btnRMF;
        private System.Windows.Forms.Button btnRSF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRRF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAutoClose;
    }
}
