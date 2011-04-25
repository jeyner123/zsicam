namespace zsi.Biometrics
{
    partial class frmVerification
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
            System.Windows.Forms.Label lblPrompt;
            System.Windows.Forms.Button CloseButton;
            this.pbFinger = new System.Windows.Forms.PictureBox();
            this.lblPlsWait = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdRT = new System.Windows.Forms.RadioButton();
            this.rdRI = new System.Windows.Forms.RadioButton();
            this.rdRM = new System.Windows.Forms.RadioButton();
            this.rdRR = new System.Windows.Forms.RadioButton();
            this.rdRS = new System.Windows.Forms.RadioButton();
            this.rdLT = new System.Windows.Forms.RadioButton();
            this.rdLI = new System.Windows.Forms.RadioButton();
            this.rdLM = new System.Windows.Forms.RadioButton();
            this.rdLR = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdLS = new System.Windows.Forms.RadioButton();
            this.cbVerificationPurpose = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            lblPrompt = new System.Windows.Forms.Label();
            CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(235)))), ((int)(((byte)(226)))));
            lblPrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblPrompt.Location = new System.Drawing.Point(177, 26);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Padding = new System.Windows.Forms.Padding(5);
            lblPrompt.Size = new System.Drawing.Size(338, 128);
            lblPrompt.TabIndex = 6;
            lblPrompt.Text = "To verify your identity, touch fingerprint reader with any enrolled finger.";
            // 
            // CloseButton
            // 
            CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            CloseButton.Location = new System.Drawing.Point(38, 313);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(75, 23);
            CloseButton.TabIndex = 5;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // pbFinger
            // 
            this.pbFinger.BackColor = System.Drawing.SystemColors.Window;
            this.pbFinger.Location = new System.Drawing.Point(12, 26);
            this.pbFinger.Name = "pbFinger";
            this.pbFinger.Size = new System.Drawing.Size(146, 189);
            this.pbFinger.TabIndex = 9;
            this.pbFinger.TabStop = false;
            // 
            // lblPlsWait
            // 
            this.lblPlsWait.AutoSize = true;
            this.lblPlsWait.Location = new System.Drawing.Point(31, 119);
            this.lblPlsWait.Name = "lblPlsWait";
            this.lblPlsWait.Size = new System.Drawing.Size(101, 13);
            this.lblPlsWait.TabIndex = 22;
            this.lblPlsWait.Text = "Verifying... Pls. wait.";
            this.lblPlsWait.Visible = false;
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
            this.groupBox1.Location = new System.Drawing.Point(177, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 164);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fingers";
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
            // cbVerificationPurpose
            // 
            this.cbVerificationPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVerificationPurpose.FormattingEnabled = true;
            this.cbVerificationPurpose.Items.AddRange(new object[] {
            "User Login",
            "Profile Info",
            "Verify Finger"});
            this.cbVerificationPurpose.Location = new System.Drawing.Point(15, 259);
            this.cbVerificationPurpose.Name = "cbVerificationPurpose";
            this.cbVerificationPurpose.Size = new System.Drawing.Size(143, 21);
            this.cbVerificationPurpose.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Verification Purpose:";
            // 
            // frmVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 351);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbVerificationPurpose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPlsWait);
            this.Controls.Add(this.pbFinger);
            this.Controls.Add(lblPrompt);
            this.Controls.Add(CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVerification";
            this.ReaderSerialNumber = "5ae3d8ed-eb2f-dc46-9b30-e88a5998ea74";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finger\'s Indentification";
            this.Load += new System.EventHandler(this.frmVerification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFinger;
        private System.Windows.Forms.Label lblPlsWait;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdRT;
        private System.Windows.Forms.RadioButton rdRI;
        private System.Windows.Forms.RadioButton rdRM;
        private System.Windows.Forms.RadioButton rdRR;
        private System.Windows.Forms.RadioButton rdRS;
        private System.Windows.Forms.RadioButton rdLT;
        private System.Windows.Forms.RadioButton rdLI;
        private System.Windows.Forms.RadioButton rdLM;
        private System.Windows.Forms.RadioButton rdLR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdLS;
        private System.Windows.Forms.ComboBox cbVerificationPurpose;
        private System.Windows.Forms.Label label3;

    }
}