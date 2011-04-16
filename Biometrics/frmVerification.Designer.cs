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
            this.rdLS = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdLR = new System.Windows.Forms.RadioButton();
            this.rdLM = new System.Windows.Forms.RadioButton();
            this.rdLI = new System.Windows.Forms.RadioButton();
            this.rdLT = new System.Windows.Forms.RadioButton();
            this.rdRT = new System.Windows.Forms.RadioButton();
            this.rdRI = new System.Windows.Forms.RadioButton();
            this.rdRM = new System.Windows.Forms.RadioButton();
            this.rdRR = new System.Windows.Forms.RadioButton();
            this.rdRS = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pbFinger = new System.Windows.Forms.PictureBox();
            this.lblPlsWait = new System.Windows.Forms.Label();
            lblPrompt = new System.Windows.Forms.Label();
            CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            lblPrompt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(235)))), ((int)(((byte)(226)))));
            lblPrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblPrompt.Location = new System.Drawing.Point(164, 26);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Padding = new System.Windows.Forms.Padding(5);
            lblPrompt.Size = new System.Drawing.Size(402, 93);
            lblPrompt.TabIndex = 6;
            lblPrompt.Text = "To verify your identity, touch fingerprint reader with any enrolled finger.";
            // 
            // CloseButton
            // 
            CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            CloseButton.Location = new System.Drawing.Point(243, 249);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(75, 23);
            CloseButton.TabIndex = 5;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // rdLS
            // 
            this.rdLS.AutoSize = true;
            this.rdLS.Location = new System.Drawing.Point(198, 148);
            this.rdLS.Name = "rdLS";
            this.rdLS.Size = new System.Drawing.Size(50, 17);
            this.rdLS.TabIndex = 10;
            this.rdLS.Text = "Small";
            this.rdLS.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Left Fingers:";
            // 
            // rdLR
            // 
            this.rdLR.AutoSize = true;
            this.rdLR.Location = new System.Drawing.Point(254, 148);
            this.rdLR.Name = "rdLR";
            this.rdLR.Size = new System.Drawing.Size(47, 17);
            this.rdLR.TabIndex = 12;
            this.rdLR.Text = "Ring";
            this.rdLR.UseVisualStyleBackColor = true;
            // 
            // rdLM
            // 
            this.rdLM.AutoSize = true;
            this.rdLM.Location = new System.Drawing.Point(310, 148);
            this.rdLM.Name = "rdLM";
            this.rdLM.Size = new System.Drawing.Size(56, 17);
            this.rdLM.TabIndex = 13;
            this.rdLM.Text = "Middle";
            this.rdLM.UseVisualStyleBackColor = true;
            // 
            // rdLI
            // 
            this.rdLI.AutoSize = true;
            this.rdLI.Location = new System.Drawing.Point(366, 148);
            this.rdLI.Name = "rdLI";
            this.rdLI.Size = new System.Drawing.Size(51, 17);
            this.rdLI.TabIndex = 14;
            this.rdLI.Text = "Index";
            this.rdLI.UseVisualStyleBackColor = true;
            // 
            // rdLT
            // 
            this.rdLT.AutoSize = true;
            this.rdLT.Checked = true;
            this.rdLT.Location = new System.Drawing.Point(422, 148);
            this.rdLT.Name = "rdLT";
            this.rdLT.Size = new System.Drawing.Size(58, 17);
            this.rdLT.TabIndex = 15;
            this.rdLT.TabStop = true;
            this.rdLT.Text = "Thumb";
            this.rdLT.UseVisualStyleBackColor = true;
            // 
            // rdRT
            // 
            this.rdRT.AutoSize = true;
            this.rdRT.Location = new System.Drawing.Point(422, 208);
            this.rdRT.Name = "rdRT";
            this.rdRT.Size = new System.Drawing.Size(58, 17);
            this.rdRT.TabIndex = 20;
            this.rdRT.Text = "Thumb";
            this.rdRT.UseVisualStyleBackColor = true;
            // 
            // rdRI
            // 
            this.rdRI.AutoSize = true;
            this.rdRI.Location = new System.Drawing.Point(366, 208);
            this.rdRI.Name = "rdRI";
            this.rdRI.Size = new System.Drawing.Size(51, 17);
            this.rdRI.TabIndex = 19;
            this.rdRI.Text = "Index";
            this.rdRI.UseVisualStyleBackColor = true;
            // 
            // rdRM
            // 
            this.rdRM.AutoSize = true;
            this.rdRM.Location = new System.Drawing.Point(310, 208);
            this.rdRM.Name = "rdRM";
            this.rdRM.Size = new System.Drawing.Size(56, 17);
            this.rdRM.TabIndex = 18;
            this.rdRM.Text = "Middle";
            this.rdRM.UseVisualStyleBackColor = true;
            // 
            // rdRR
            // 
            this.rdRR.AutoSize = true;
            this.rdRR.Location = new System.Drawing.Point(254, 208);
            this.rdRR.Name = "rdRR";
            this.rdRR.Size = new System.Drawing.Size(47, 17);
            this.rdRR.TabIndex = 17;
            this.rdRR.Text = "Ring";
            this.rdRR.UseVisualStyleBackColor = true;
            // 
            // rdRS
            // 
            this.rdRS.AutoSize = true;
            this.rdRS.Location = new System.Drawing.Point(198, 208);
            this.rdRS.Name = "rdRS";
            this.rdRS.Size = new System.Drawing.Size(50, 17);
            this.rdRS.TabIndex = 16;
            this.rdRS.Text = "Small";
            this.rdRS.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(195, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Right Fingers:";
            // 
            // pbFinger
            // 
            this.pbFinger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pbFinger.BackColor = System.Drawing.SystemColors.Window;
            this.pbFinger.Location = new System.Drawing.Point(12, 26);
            this.pbFinger.Name = "pbFinger";
            this.pbFinger.Size = new System.Drawing.Size(146, 237);
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
            // 
            // frmVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 284);
            this.Controls.Add(this.lblPlsWait);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdRT);
            this.Controls.Add(this.rdRI);
            this.Controls.Add(this.rdRM);
            this.Controls.Add(this.rdRR);
            this.Controls.Add(this.rdRS);
            this.Controls.Add(this.rdLT);
            this.Controls.Add(this.rdLI);
            this.Controls.Add(this.rdLM);
            this.Controls.Add(this.rdLR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdLS);
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
            this.Text = "Verify Your Identity";
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFinger;
        private System.Windows.Forms.RadioButton rdLS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdLR;
        private System.Windows.Forms.RadioButton rdLM;
        private System.Windows.Forms.RadioButton rdLI;
        private System.Windows.Forms.RadioButton rdLT;
        private System.Windows.Forms.RadioButton rdRT;
        private System.Windows.Forms.RadioButton rdRI;
        private System.Windows.Forms.RadioButton rdRM;
        private System.Windows.Forms.RadioButton rdRR;
        private System.Windows.Forms.RadioButton rdRS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPlsWait;

    }
}