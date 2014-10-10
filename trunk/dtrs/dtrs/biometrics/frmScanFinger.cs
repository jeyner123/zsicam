using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zsi.Biometrics
{
    public partial class frmScanFinger :FingersMasterScanner
    {
        private Button CloseButton;
        private Label StatusLine;
        private TextBox StatusText;
        private TextBox Prompt;
        private PictureBox Picture;
       
    
        private Control Control { get; set; }
 
        public frmScanFinger(Object sender,FingersBiometrics Data,int FingerPosition)
        {
            this.SampleIndex = 0;
            InitializeComponent();
            this.FingerPosition = FingerPosition;
            this.Data = Data;
            this.Control = (Control)sender;
           DeleteData();
            this.FormClosing +=new FormClosingEventHandler(delegate{CloseForm();});
            this.SetControls(Picture, StatusText, Prompt, StatusLine);
            this.CloseButton.Click += new EventHandler(delegate { this.Close(); });
        }

        private void DeleteData(){
            this.Control.BackColor = Color.White;
            this.Control.ForeColor = Color.Black;
            this.Data.UpdateTemplates(FingerPosition, null);
        }

        public void CloseForm()
        {
            if (this.IsComplete == true)
            {
                this.Control.BackColor = Color.Green;
                this.Control.ForeColor = Color.White;
            }
      
        }
        public override void Process(DPFP.Sample Sample)
        {

            base.Process(Sample);
            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = zsi.dtrs.Util.ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            // Check quality of the sample and add to enroller if it's good
            if (features != null) try
                {
                    MakeReport("The fingerprint feature set was created.");
                    Enroller.AddFeatures(features);		// Add feature set to template.
                }
                finally
                {
                    UpdateStatus();

                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:	// report success and stop capturing
                            //OnTemplate(Enroller.Template);
                            this.Data.UpdateTemplates(this.FingerPosition, Enroller.Template);

                            this.IsComplete = true;
                            SetPrompt("Click Close, and then click Fingerprint Verification.");
                            Stop();
                            if (IsAutoClose == true)
                            {

                                this.Invoke(new Function(delegate()
                                {
                                    this.Close();
                                }));

                            }
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:	// report failure and restart capturing
                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            //OnTemplate(null);
                            Start();
                            break;
                    }
                }
        }

        private void UpdateStatus()
        {
            // Show number of samples needed.
            SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded));
        }

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
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(475, 331);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // StatusLine
            // 
            this.StatusLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLine.Location = new System.Drawing.Point(18, 337);
            this.StatusLine.Name = "StatusLine";
            this.StatusLine.Size = new System.Drawing.Size(342, 29);
            this.StatusLine.TabIndex = 20;
            this.StatusLine.Text = "[Status line]";
            // 
            // StatusText
            // 
            this.StatusText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusText.BackColor = System.Drawing.SystemColors.Window;
            this.StatusText.Location = new System.Drawing.Point(294, 75);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusText.Size = new System.Drawing.Size(256, 240);
            this.StatusText.TabIndex = 19;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new System.Drawing.Point(291, 59);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new System.Drawing.Size(40, 13);
            StatusLabel.TabIndex = 18;
            StatusLabel.Text = "Status:";
            // 
            // Prompt
            // 
            this.Prompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Prompt.Location = new System.Drawing.Point(294, 22);
            this.Prompt.Name = "Prompt";
            this.Prompt.ReadOnly = true;
            this.Prompt.Size = new System.Drawing.Size(256, 20);
            this.Prompt.TabIndex = 17;
            // 
            // PromptLabel
            // 
            PromptLabel.AutoSize = true;
            PromptLabel.Location = new System.Drawing.Point(291, 6);
            PromptLabel.Name = "PromptLabel";
            PromptLabel.Size = new System.Drawing.Size(43, 13);
            PromptLabel.TabIndex = 16;
            PromptLabel.Text = "Prompt:";
            // 
            // Picture
            // 
            this.Picture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Picture.BackColor = System.Drawing.SystemColors.Window;
            this.Picture.Location = new System.Drawing.Point(21, 22);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(248, 293);
            this.Picture.TabIndex = 15;
            this.Picture.TabStop = false;
            // 
            // frmScanFinger
            // 
            this.ClientSize = new System.Drawing.Size(569, 372);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StatusLine);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(StatusLabel);
            this.Controls.Add(this.Prompt);
            this.Controls.Add(PromptLabel);
            this.Controls.Add(this.Picture);
            this.Name = "frmScanFinger";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
