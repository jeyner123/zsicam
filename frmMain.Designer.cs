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
            this.txtProfileNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnRegisterFP = new System.Windows.Forms.Button();
            this.btnVerifyFP = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
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
            this.btnUploadFG = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tab.SuspendLayout();
            this.tabPhoto.SuspendLayout();
            this.gbImageType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.tabFingers.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProfileNo
            // 
            this.txtProfileNo.Enabled = false;
            this.txtProfileNo.Location = new System.Drawing.Point(168, 14);
            this.txtProfileNo.Name = "txtProfileNo";
            this.txtProfileNo.Size = new System.Drawing.Size(158, 20);
            this.txtProfileNo.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Enter Profile No.:";
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileName.Location = new System.Drawing.Point(169, 48);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(14, 20);
            this.lblProfileName.TabIndex = 25;
            this.lblProfileName.Text = " ";
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(332, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(41, 21);
            this.btnFind.TabIndex = 26;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnRegisterFP
            // 
            this.btnRegisterFP.Enabled = false;
            this.btnRegisterFP.Location = new System.Drawing.Point(220, 134);
            this.btnRegisterFP.Name = "btnRegisterFP";
            this.btnRegisterFP.Size = new System.Drawing.Size(139, 53);
            this.btnRegisterFP.TabIndex = 27;
            this.btnRegisterFP.Text = "Register Finger Prints";
            this.btnRegisterFP.UseVisualStyleBackColor = true;
            this.btnRegisterFP.Click += new System.EventHandler(this.btnRegisterFP_Click);
            // 
            // btnVerifyFP
            // 
            this.btnVerifyFP.Enabled = false;
            this.btnVerifyFP.Location = new System.Drawing.Point(363, 134);
            this.btnVerifyFP.Name = "btnVerifyFP";
            this.btnVerifyFP.Size = new System.Drawing.Size(139, 53);
            this.btnVerifyFP.TabIndex = 28;
            this.btnVerifyFP.Text = "Verify Finger Prints";
            this.btnVerifyFP.UseVisualStyleBackColor = true;
            this.btnVerifyFP.Click += new System.EventHandler(this.btnVerifyFP_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Profile Name:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(24, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 30;
            this.button3.Text = "Test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPhoto);
            this.tab.Controls.Add(this.tabFingers);
            this.tab.Location = new System.Drawing.Point(26, 78);
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
            this.tabFingers.Controls.Add(this.btnUploadFG);
            this.tabFingers.Controls.Add(this.btnRegisterFP);
            this.tabFingers.Controls.Add(this.button3);
            this.tabFingers.Controls.Add(this.btnVerifyFP);
            this.tabFingers.Location = new System.Drawing.Point(4, 22);
            this.tabFingers.Name = "tabFingers";
            this.tabFingers.Padding = new System.Windows.Forms.Padding(3);
            this.tabFingers.Size = new System.Drawing.Size(706, 365);
            this.tabFingers.TabIndex = 1;
            this.tabFingers.Text = "Fingers Capture";
            this.tabFingers.UseVisualStyleBackColor = true;
            // 
            // btnUploadFG
            // 
            this.btnUploadFG.Enabled = false;
            this.btnUploadFG.Location = new System.Drawing.Point(220, 66);
            this.btnUploadFG.Name = "btnUploadFG";
            this.btnUploadFG.Size = new System.Drawing.Size(68, 23);
            this.btnUploadFG.TabIndex = 31;
            this.btnUploadFG.Text = "Upload";
            this.btnUploadFG.UseVisualStyleBackColor = true;
            this.btnUploadFG.Click += new System.EventHandler(this.btnUploadFG_Click);
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
            this.ClientSize = new System.Drawing.Size(756, 485);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblProfileName);
            this.Controls.Add(this.txtProfileNo);
            this.Controls.Add(this.label5);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProfileNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnRegisterFP;
        private System.Windows.Forms.Button btnVerifyFP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
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
    }
}

