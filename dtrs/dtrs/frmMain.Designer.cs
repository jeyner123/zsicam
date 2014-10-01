namespace zsi.dtrs
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
            this.tab.SuspendLayout();
            this.tabPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.tabFingers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPhoto);
            this.tab.Controls.Add(this.tabFingers);
            this.tab.Location = new System.Drawing.Point(12, 12);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(778, 391);
            this.tab.TabIndex = 32;
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
            this.comboBoxCameras.Location = new System.Drawing.Point(14, 8);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(156, 21);
            this.comboBoxCameras.TabIndex = 31;
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Location = new System.Drawing.Point(176, 8);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(99, 23);
            this.btnConfig.TabIndex = 30;
            this.btnConfig.Text = "Camera Settings";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(95, 35);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 29;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(14, 35);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 28;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
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
            this.tabFingers.Controls.Add(this.groupBox1);
            this.tabFingers.Location = new System.Drawing.Point(4, 22);
            this.tabFingers.Name = "tabFingers";
            this.tabFingers.Padding = new System.Windows.Forms.Padding(3);
            this.tabFingers.Size = new System.Drawing.Size(770, 365);
            this.tabFingers.TabIndex = 1;
            this.tabFingers.Text = "Register Finger(s)";
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 422);
            this.Controls.Add(this.tab);
            this.Name = "frmMain";
            this.Text = "DTR - Monitoring";
            this.tab.ResumeLayout(false);
            this.tabPhoto.ResumeLayout(false);
            this.tabPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.tabFingers.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPhoto;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ComboBox cbImagePosition;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxCameras;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.TabPage tabFingers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAutoClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLTF;
        private System.Windows.Forms.Button btnUploadFG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLIF;
        private System.Windows.Forms.Button btnRTF;
        private System.Windows.Forms.Button btnLMF;
        private System.Windows.Forms.Button btnRSF;
        private System.Windows.Forms.Button btnRIF;
        private System.Windows.Forms.Button btnLRF;
        private System.Windows.Forms.Button btnRRF;
        private System.Windows.Forms.Button btnRMF;
        private System.Windows.Forms.Button btnLSF;


    }
}

