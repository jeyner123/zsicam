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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnVerifyFP = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPhoto = new System.Windows.Forms.TabPage();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.cbImagePosition = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbImageType = new System.Windows.Forms.GroupBox();
            this.rdbITProfile = new System.Windows.Forms.RadioButton();
            this.rdbITCase = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.btnUploadPhoto = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.PictureBox();
            this.tabFingers = new System.Windows.Forms.TabPage();
            this.btnFingerUpdate = new System.Windows.Forms.Button();
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
            this.tabSign = new System.Windows.Forms.TabPage();
            this.signature1 = new zsi.Controls.Signature();
            this.btnUploadSig = new System.Windows.Forms.Button();
            this.btnClearSig = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnClearConsoleList = new System.Windows.Forms.Button();
            this.btnDisplayConsolList = new System.Windows.Forms.Button();
            this.txtConsoleList = new System.Windows.Forms.TextBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssStatus1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrProfileUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnOpenWebsite = new System.Windows.Forms.Button();
            this.gbClientReg = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRegCode = new System.Windows.Forms.TextBox();
            this.btnCodeSubmit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lUser = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnUpdateClient = new System.Windows.Forms.Button();
            this.bgwProfiles = new System.ComponentModel.BackgroundWorker();
            this.tmrAppFocusChecker = new System.Windows.Forms.Timer(this.components);
            this.tab.SuspendLayout();
            this.tabPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbImageType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.tabFingers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSign.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.gbClientReg.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVerifyFP
            // 
            this.btnVerifyFP.Location = new System.Drawing.Point(535, 8);
            this.btnVerifyFP.Name = "btnVerifyFP";
            this.btnVerifyFP.Size = new System.Drawing.Size(87, 23);
            this.btnVerifyFP.TabIndex = 28;
            this.btnVerifyFP.Text = "Scan Finger(s)";
            this.btnVerifyFP.UseVisualStyleBackColor = true;
            this.btnVerifyFP.Click += new System.EventHandler(this.btnVerifyFP_Click);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPhoto);
            this.tab.Controls.Add(this.tabFingers);
            this.tab.Controls.Add(this.tabSign);
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Location = new System.Drawing.Point(18, 42);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(778, 391);
            this.tab.TabIndex = 31;
            this.tab.Visible = false;
            // 
            // tabPhoto
            // 
            this.tabPhoto.Controls.Add(this.pictureBox4);
            this.tabPhoto.Controls.Add(this.cbImagePosition);
            this.tabPhoto.Controls.Add(this.pictureBox3);
            this.tabPhoto.Controls.Add(this.pictureBox2);
            this.tabPhoto.Controls.Add(this.pictureBox1);
            this.tabPhoto.Controls.Add(this.comboBoxCameras);
            this.tabPhoto.Controls.Add(this.btnConfig);
            this.tabPhoto.Controls.Add(this.btnStop);
            this.tabPhoto.Controls.Add(this.btnStart);
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
            this.tabPhoto.Size = new System.Drawing.Size(770, 365);
            this.tabPhoto.TabIndex = 0;
            this.tabPhoto.Text = "Photo Capture";
            this.tabPhoto.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox4.Location = new System.Drawing.Point(313, 121);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1, 216);
            this.pictureBox4.TabIndex = 36;
            this.pictureBox4.TabStop = false;
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
            this.cbImagePosition.Location = new System.Drawing.Point(446, 69);
            this.cbImagePosition.Name = "cbImagePosition";
            this.cbImagePosition.Size = new System.Drawing.Size(63, 21);
            this.cbImagePosition.TabIndex = 17;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox3.Location = new System.Drawing.Point(24, 121);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1, 216);
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox2.Location = new System.Drawing.Point(24, 336);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(290, 1);
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox1.Location = new System.Drawing.Point(24, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 1);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(168, 17);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(156, 21);
            this.comboBoxCameras.TabIndex = 31;
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Location = new System.Drawing.Point(675, 8);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(81, 44);
            this.btnConfig.TabIndex = 30;
            this.btnConfig.Text = "Camera Settings";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(249, 44);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 29;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(168, 44);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 28;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbImageType
            // 
            this.gbImageType.Controls.Add(this.rdbITProfile);
            this.gbImageType.Controls.Add(this.rdbITCase);
            this.gbImageType.Location = new System.Drawing.Point(14, 10);
            this.gbImageType.Name = "gbImageType";
            this.gbImageType.Size = new System.Drawing.Size(148, 62);
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
            this.label3.Location = new System.Drawing.Point(11, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Preview:";
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(515, 67);
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
            this.pbResult.Location = new System.Drawing.Point(376, 107);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(281, 240);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResult.TabIndex = 24;
            this.pbResult.TabStop = false;
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.Enabled = false;
            this.btnUploadPhoto.Location = new System.Drawing.Point(589, 67);
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
            this.picture.Location = new System.Drawing.Point(8, 107);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(321, 240);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 23;
            this.picture.TabStop = false;
            // 
            // tabFingers
            // 
            this.tabFingers.Controls.Add(this.btnFingerUpdate);
            this.tabFingers.Controls.Add(this.groupBox1);
            this.tabFingers.Location = new System.Drawing.Point(4, 22);
            this.tabFingers.Name = "tabFingers";
            this.tabFingers.Padding = new System.Windows.Forms.Padding(3);
            this.tabFingers.Size = new System.Drawing.Size(770, 365);
            this.tabFingers.TabIndex = 1;
            this.tabFingers.Text = "Register Finger(s)";
            this.tabFingers.UseVisualStyleBackColor = true;
            // 
            // btnFingerUpdate
            // 
            this.btnFingerUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFingerUpdate.Location = new System.Drawing.Point(84, 227);
            this.btnFingerUpdate.Name = "btnFingerUpdate";
            this.btnFingerUpdate.Size = new System.Drawing.Size(146, 35);
            this.btnFingerUpdate.TabIndex = 45;
            this.btnFingerUpdate.Text = "Update Fingers Templates";
            this.btnFingerUpdate.UseVisualStyleBackColor = true;
            this.btnFingerUpdate.Click += new System.EventHandler(this.btnFingerUpdate_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(20, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 166);
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
            // tabSign
            // 
            this.tabSign.Controls.Add(this.signature1);
            this.tabSign.Controls.Add(this.btnUploadSig);
            this.tabSign.Controls.Add(this.btnClearSig);
            this.tabSign.Location = new System.Drawing.Point(4, 22);
            this.tabSign.Name = "tabSign";
            this.tabSign.Size = new System.Drawing.Size(770, 365);
            this.tabSign.TabIndex = 2;
            this.tabSign.Text = "Signature";
            this.tabSign.UseVisualStyleBackColor = true;
            // 
            // signature1
            // 
            this.signature1.Background = null;
            this.signature1.bmp = ((System.Drawing.Bitmap)(resources.GetObject("signature1.bmp")));
            this.signature1.Location = new System.Drawing.Point(145, 110);
            this.signature1.Name = "signature1";
            this.signature1.Size = new System.Drawing.Size(307, 116);
            this.signature1.TabIndex = 3;
            this.signature1.Text = "signature1";
            this.signature1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.signature1_MouseMove);
            // 
            // btnUploadSig
            // 
            this.btnUploadSig.Enabled = false;
            this.btnUploadSig.Location = new System.Drawing.Point(458, 203);
            this.btnUploadSig.Name = "btnUploadSig";
            this.btnUploadSig.Size = new System.Drawing.Size(75, 23);
            this.btnUploadSig.TabIndex = 2;
            this.btnUploadSig.Text = "Upload";
            this.btnUploadSig.UseVisualStyleBackColor = true;
            this.btnUploadSig.Click += new System.EventHandler(this.btnUploadSig_Click);
            // 
            // btnClearSig
            // 
            this.btnClearSig.Location = new System.Drawing.Point(458, 110);
            this.btnClearSig.Name = "btnClearSig";
            this.btnClearSig.Size = new System.Drawing.Size(75, 23);
            this.btnClearSig.TabIndex = 1;
            this.btnClearSig.Text = "Clear";
            this.btnClearSig.UseVisualStyleBackColor = true;
            this.btnClearSig.Click += new System.EventHandler(this.btnClearSig_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnClearConsoleList);
            this.tabPage1.Controls.Add(this.btnDisplayConsolList);
            this.tabPage1.Controls.Add(this.txtConsoleList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(770, 365);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Console Service";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnClearConsoleList
            // 
            this.btnClearConsoleList.Location = new System.Drawing.Point(183, 9);
            this.btnClearConsoleList.Name = "btnClearConsoleList";
            this.btnClearConsoleList.Size = new System.Drawing.Size(100, 23);
            this.btnClearConsoleList.TabIndex = 2;
            this.btnClearConsoleList.Text = "Clear Console List";
            this.btnClearConsoleList.UseVisualStyleBackColor = true;
            this.btnClearConsoleList.Click += new System.EventHandler(this.btnClearConsoleList_Click);
            // 
            // btnDisplayConsolList
            // 
            this.btnDisplayConsolList.Location = new System.Drawing.Point(16, 9);
            this.btnDisplayConsolList.Name = "btnDisplayConsolList";
            this.btnDisplayConsolList.Size = new System.Drawing.Size(161, 23);
            this.btnDisplayConsolList.TabIndex = 1;
            this.btnDisplayConsolList.Text = "Display Console List";
            this.btnDisplayConsolList.UseVisualStyleBackColor = true;
            this.btnDisplayConsolList.Click += new System.EventHandler(this.btnDisplayConsolList_Click);
            // 
            // txtConsoleList
            // 
            this.txtConsoleList.Location = new System.Drawing.Point(6, 38);
            this.txtConsoleList.Multiline = true;
            this.txtConsoleList.Name = "txtConsoleList";
            this.txtConsoleList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsoleList.Size = new System.Drawing.Size(694, 321);
            this.txtConsoleList.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Enabled = false;
            this.btnLogOut.Location = new System.Drawing.Point(688, 8);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(54, 23);
            this.btnLogOut.TabIndex = 35;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(621, 8);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(68, 23);
            this.btnLogin.TabIndex = 34;
            this.btnLogin.Text = "Log-in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssStatus1});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 475);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(808, 22);
            this.StatusStrip1.TabIndex = 37;
            this.StatusStrip1.Text = "statusStrip1";
            // 
            // ssStatus1
            // 
            this.ssStatus1.Name = "ssStatus1";
            this.ssStatus1.Size = new System.Drawing.Size(19, 17);
            this.ssStatus1.Text = "    ";
            // 
            // tmrProfileUpdate
            // 
            this.tmrProfileUpdate.Enabled = true;
            this.tmrProfileUpdate.Interval = 20000;
            this.tmrProfileUpdate.Tick += new System.EventHandler(this.tmrProfileUpdate_Tick);
            // 
            // btnOpenWebsite
            // 
            this.btnOpenWebsite.Enabled = false;
            this.btnOpenWebsite.Location = new System.Drawing.Point(448, 8);
            this.btnOpenWebsite.Name = "btnOpenWebsite";
            this.btnOpenWebsite.Size = new System.Drawing.Size(88, 23);
            this.btnOpenWebsite.TabIndex = 38;
            this.btnOpenWebsite.Text = "Open Website";
            this.btnOpenWebsite.UseVisualStyleBackColor = true;
            this.btnOpenWebsite.Click += new System.EventHandler(this.btnOpenWebsite_Click);
            // 
            // gbClientReg
            // 
            this.gbClientReg.Controls.Add(this.label7);
            this.gbClientReg.Controls.Add(this.label6);
            this.gbClientReg.Controls.Add(this.txtRegCode);
            this.gbClientReg.Controls.Add(this.btnCodeSubmit);
            this.gbClientReg.Controls.Add(this.label5);
            this.gbClientReg.Location = new System.Drawing.Point(21, 64);
            this.gbClientReg.Name = "gbClientReg";
            this.gbClientReg.Size = new System.Drawing.Size(714, 369);
            this.gbClientReg.TabIndex = 39;
            this.gbClientReg.TabStop = false;
            this.gbClientReg.Text = "Client Registration";
            this.gbClientReg.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(172, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Please enter your registration code.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(172, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(283, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "This workstation is currently not registered. ";
            // 
            // txtRegCode
            // 
            this.txtRegCode.Location = new System.Drawing.Point(273, 113);
            this.txtRegCode.Name = "txtRegCode";
            this.txtRegCode.Size = new System.Drawing.Size(163, 20);
            this.txtRegCode.TabIndex = 2;
            // 
            // btnCodeSubmit
            // 
            this.btnCodeSubmit.Location = new System.Drawing.Point(273, 139);
            this.btnCodeSubmit.Name = "btnCodeSubmit";
            this.btnCodeSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnCodeSubmit.TabIndex = 1;
            this.btnCodeSubmit.Text = "Submit";
            this.btnCodeSubmit.UseVisualStyleBackColor = true;
            this.btnCodeSubmit.Click += new System.EventHandler(this.btnCodeSubmit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Registration Code:";
            // 
            // lUser
            // 
            this.lUser.AutoSize = true;
            this.lUser.BackColor = System.Drawing.Color.Transparent;
            this.lUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUser.ForeColor = System.Drawing.Color.Gray;
            this.lUser.Location = new System.Drawing.Point(24, 13);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(0, 17);
            this.lUser.TabIndex = 40;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(741, 8);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(54, 23);
            this.btnAbout.TabIndex = 41;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnUpdateClient
            // 
            this.btnUpdateClient.Enabled = false;
            this.btnUpdateClient.Location = new System.Drawing.Point(711, 439);
            this.btnUpdateClient.Name = "btnUpdateClient";
            this.btnUpdateClient.Size = new System.Drawing.Size(88, 23);
            this.btnUpdateClient.TabIndex = 42;
            this.btnUpdateClient.Text = "Update Client";
            this.btnUpdateClient.UseVisualStyleBackColor = true;
            this.btnUpdateClient.Visible = false;
            this.btnUpdateClient.Click += new System.EventHandler(this.btnUpdateClient_Click);
            // 
            // bgwProfiles
            // 
            this.bgwProfiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProfiles_DoWork);
            this.bgwProfiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProfiles_RunWorkerCompleted);
            // 
            // tmrAppFocusChecker
            // 
            this.tmrAppFocusChecker.Enabled = true;
            this.tmrAppFocusChecker.Interval = 2000;
            this.tmrAppFocusChecker.Tick += new System.EventHandler(this.tmrAppFocusChecker_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::zsi.PhotoFingCapture.Properties.Resources.photofingcapturemain;
            this.ClientSize = new System.Drawing.Size(808, 497);
            this.Controls.Add(this.btnUpdateClient);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lUser);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.gbClientReg);
            this.Controls.Add(this.btnOpenWebsite);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnVerifyFP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotoFingCapture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DoubleClick += new System.EventHandler(this.frmMain_DoubleClick);
            this.tab.ResumeLayout(false);
            this.tabPhoto.ResumeLayout(false);
            this.tabPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbImageType.ResumeLayout(false);
            this.gbImageType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.tabFingers.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSign.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.gbClientReg.ResumeLayout(false);
            this.gbClientReg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TabPage tabSign;
        private System.Windows.Forms.Button btnUploadSig;
        private System.Windows.Forms.Button btnClearSig;
        private System.Windows.Forms.ComboBox comboBoxCameras;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private zsi.Controls.Signature signature1;
        private System.Windows.Forms.StatusStrip StatusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ssStatus1;
        private System.Windows.Forms.Timer tmrProfileUpdate;
        private System.Windows.Forms.Button btnFingerUpdate;
        private System.Windows.Forms.Button btnOpenWebsite;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnClearConsoleList;
        private System.Windows.Forms.Button btnDisplayConsolList;
        private System.Windows.Forms.TextBox txtConsoleList;
        private System.Windows.Forms.GroupBox gbClientReg;
        private System.Windows.Forms.TextBox txtRegCode;
        private System.Windows.Forms.Button btnCodeSubmit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lUser;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnUpdateClient;
        private System.ComponentModel.BackgroundWorker bgwProfiles;
        private System.Windows.Forms.Timer tmrAppFocusChecker;
    }
}

