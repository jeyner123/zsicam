namespace WebCamServiceSample
{
    partial class Form1
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
            this.picture = new System.Windows.Forms.PictureBox();
            this.pbResult = new System.Windows.Forms.PictureBox();
            this.bgLogin = new System.Windows.Forms.GroupBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.cbImagePosition = new System.Windows.Forms.ComboBox();
            this.rdbITProfile = new System.Windows.Forms.RadioButton();
            this.rdbITCase = new System.Windows.Forms.RadioButton();
            this.gbImageType = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).BeginInit();
            this.bgLogin.SuspendLayout();
            this.gbImageType.SuspendLayout();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.White;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.Location = new System.Drawing.Point(28, 142);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(320, 240);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // pbResult
            // 
            this.pbResult.BackColor = System.Drawing.Color.White;
            this.pbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbResult.Location = new System.Drawing.Point(366, 142);
            this.pbResult.Name = "pbResult";
            this.pbResult.Size = new System.Drawing.Size(320, 240);
            this.pbResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResult.TabIndex = 2;
            this.pbResult.TabStop = false;
            // 
            // bgLogin
            // 
            this.bgLogin.Controls.Add(this.btnLogOut);
            this.bgLogin.Controls.Add(this.btnSettings);
            this.bgLogin.Controls.Add(this.txtPassword);
            this.bgLogin.Controls.Add(this.label2);
            this.bgLogin.Controls.Add(this.txtUserName);
            this.bgLogin.Controls.Add(this.label1);
            this.bgLogin.Controls.Add(this.btnLogin);
            this.bgLogin.Location = new System.Drawing.Point(28, 12);
            this.bgLogin.Name = "bgLogin";
            this.bgLogin.Size = new System.Drawing.Size(424, 93);
            this.bgLogin.TabIndex = 13;
            this.bgLogin.TabStop = false;
            this.bgLogin.Text = "User Login";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Enabled = false;
            this.btnLogOut.Location = new System.Drawing.Point(165, 59);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(68, 23);
            this.btnLogOut.TabIndex = 18;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(248, 22);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '+';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(90, 21);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "User Name";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(91, 59);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(68, 23);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(136, 59);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Upload";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(28, 388);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(68, 23);
            this.btnCapture.TabIndex = 15;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(359, 59);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(59, 23);
            this.btnSettings.TabIndex = 16;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // cbImagePosition
            // 
            this.cbImagePosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImagePosition.FormattingEnabled = true;
            this.cbImagePosition.Items.AddRange(new object[] {
            "Front",
            "Left",
            "Right",
            "Back",
            "Full"});
            this.cbImagePosition.Location = new System.Drawing.Point(145, 23);
            this.cbImagePosition.Name = "cbImagePosition";
            this.cbImagePosition.Size = new System.Drawing.Size(59, 21);
            this.cbImagePosition.TabIndex = 17;
            // 
            // rdbITProfile
            // 
            this.rdbITProfile.AutoSize = true;
            this.rdbITProfile.Checked = true;
            this.rdbITProfile.Location = new System.Drawing.Point(30, 25);
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
            // gbImageType
            // 
            this.gbImageType.Controls.Add(this.rdbITProfile);
            this.gbImageType.Controls.Add(this.cbImagePosition);
            this.gbImageType.Controls.Add(this.rdbITCase);
            this.gbImageType.Controls.Add(this.btnSave);
            this.gbImageType.Location = new System.Drawing.Point(458, 12);
            this.gbImageType.Name = "gbImageType";
            this.gbImageType.Size = new System.Drawing.Size(228, 93);
            this.gbImageType.TabIndex = 20;
            this.gbImageType.TabStop = false;
            this.gbImageType.Text = "Image Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Preview:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Actual View:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 425);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbImageType);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.bgLogin);
            this.Controls.Add(this.pbResult);
            this.Controls.Add(this.picture);
            this.Name = "Form1";
            this.Text = "PhotoCapture 4.0 - Zetta Solutions, Inc.";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResult)).EndInit();
            this.bgLogin.ResumeLayout(false);
            this.bgLogin.PerformLayout();
            this.gbImageType.ResumeLayout(false);
            this.gbImageType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.GroupBox bgLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ComboBox cbImagePosition;
        private System.Windows.Forms.RadioButton rdbITProfile;
        private System.Windows.Forms.RadioButton rdbITCase;
        private System.Windows.Forms.GroupBox gbImageType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

