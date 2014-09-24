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
        private Control Control { get; set; }
 
        public frmScanFinger(Object sender,FingersBiometrics Data,int FingerPosition)
        {

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
            this.Data.UpdateSamples(FingerPosition, null);

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
            this.Data.Images[this.FingerPosition] = Picture.Image;
            this.Data.UpdateSamples(this.FingerPosition, Sample);
           
            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = Util.ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
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

    }
}
