namespace zsi.Biometrics
{
    partial class frmScanFinger
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
            System.Windows.Forms.Label StatusLabel;
            System.Windows.Forms.Label PromptLabel;
            this.CloseButton = new System.Windows.Forms.Button();
            this.StatusLine = new System.Windows.Forms.Label();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.Prompt = new System.Windows.Forms.TextBox();
            this.Picture = new System.Windows.Forms.PictureBox();
            StatusLabel = new System.Windows.Forms.Label();
            PromptLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new System.Drawing.Point(282, 65);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new System.Drawing.Size(40, 13);
            StatusLabel.TabIndex = 11;
            StatusLabel.Text = "Status:";
            // 
            // PromptLabel
            // 
            PromptLabel.AutoSize = true;
            PromptLabel.Location = new System.Drawing.Point(282, 12);
            PromptLabel.Name = "PromptLabel";
            PromptLabel.Size = new System.Drawing.Size(43, 13);
            PromptLabel.TabIndex = 9;
            PromptLabel.Text = "Prompt:";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(466, 337);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 14;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // StatusLine
            // 
            this.StatusLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLine.Location = new System.Drawing.Point(9, 343);
            this.StatusLine.Name = "StatusLine";
            this.StatusLine.Size = new System.Drawing.Size(342, 29);
            this.StatusLine.TabIndex = 13;
            this.StatusLine.Text = "[Status line]";
            // 
            // StatusText
            // 
            this.StatusText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusText.BackColor = System.Drawing.SystemColors.Window;
            this.StatusText.Location = new System.Drawing.Point(285, 81);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusText.Size = new System.Drawing.Size(256, 240);
            this.StatusText.TabIndex = 12;
            // 
            // Prompt
            // 
            this.Prompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Prompt.Location = new System.Drawing.Point(285, 28);
            this.Prompt.Name = "Prompt";
            this.Prompt.ReadOnly = true;
            this.Prompt.Size = new System.Drawing.Size(256, 20);
            this.Prompt.TabIndex = 10;
            // 
            // Picture
            // 
            this.Picture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.Picture.BackColor = System.Drawing.SystemColors.Window;
            this.Picture.Location = new System.Drawing.Point(12, 28);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(248, 293);
            this.Picture.TabIndex = 8;
            this.Picture.TabStop = false;
            // 
            // frmScanFinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 372);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StatusLine);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(StatusLabel);
            this.Controls.Add(this.Prompt);
            this.Controls.Add(PromptLabel);
            this.Controls.Add(this.Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmScanFinger";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fingerprint Enrollment";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label StatusLine;
        private System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.TextBox Prompt;
        private System.Windows.Forms.PictureBox Picture;

    }
}