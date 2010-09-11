using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
namespace zsi.Biometrics
{
    delegate void Function();
    public delegate void CompeletedHandler();
    public class FingersMasterScanner:Form,DPFP.Capture.EventHandler
    {        
        public delegate void OnCloseHandler();	
        public event CompeletedHandler Completed;
        
        public FingersMasterScanner() {
            this.Load +=new EventHandler(delegate{
                this.Enroller = new DPFP.Processing.Enrollment();
                this.Init();
                this.Start();
            });
            this.FormClosing += new FormClosingEventHandler(delegate {
                this.Stop(); 
            });

        }
        private PictureBox PBox { get; set; }
        private TextBox EventStatus { get; set; }
        private TextBox PromptText { get; set; }
        private Label StatusLine { get; set; }

        public DPFP.Processing.Enrollment Enroller;
        public DPFP.Capture.Capture Capturer;
        public DPFP.Sample Sample{get;set;}
        public bool IsAutoClose { get; set; }
        public int FingerPosition { get; set; }
        public FingersData Data { get; set; }
        public bool IsComplete { get; set; } 
        public string ReaderSerialNumber{get;set;}
        private Control Control { get; set; }

        public void SetControls(PictureBox PBox, TextBox EventStatus, TextBox PromptText, Label StatusLine)
        {
            this.PBox = PBox;
            this.EventStatus = EventStatus;
            this.PromptText = PromptText;
            this.StatusLine = StatusLine;
        }

        public void OnCompleted()
        {
            if (Completed != null) this.Completed();
        }
 
        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();

                }
                catch
                {

                }
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {

                }
            }
        }
        protected void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void Process(DPFP.Sample Sample)
        {
            this.Data.UpdateSamples(this.FingerPosition, Sample);
            
            DrawPicture(Util.ConvertSampleToBitmap(Sample));
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
                            if (IsAutoClose == true) {

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

      
        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            this.ReaderSerialNumber = ReaderSerialNumber;
            MakeReport("The fingerprint sample was captured.");
            SetPrompt("Scan the same fingerprint again.");            
            this.Process(Sample);
            this.Sample = Sample;
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            this.ReaderSerialNumber = ReaderSerialNumber;
            MakeReport("The finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            this.ReaderSerialNumber = ReaderSerialNumber;
            MakeReport("The fingerprint reader was touched.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            this.ReaderSerialNumber = ReaderSerialNumber;
            MakeReport("The fingerprint reader was connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader was disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            this.ReaderSerialNumber = ReaderSerialNumber;
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                MakeReport("The quality of the fingerprint sample is good.");
            else
                MakeReport("The quality of the fingerprint sample is poor.");
        }
        #endregion

        private void UpdateStatus()
        {
            // Show number of samples needed.
            SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded));
        }

        protected void SetStatus(string status)
        {
             this.Invoke(new Function(delegate()
             {
                if (this.StatusLine != null) this.StatusLine.Text = status;
             }));
        }

        protected void SetPrompt(string prompt)
        {
             this.Invoke(new Function(delegate()
             {
                 if (this.PromptText != null) this.PromptText.Text = prompt;
             }));
        }
        protected void MakeReport(string message)
        {
              this.Invoke(new Function(delegate()
             {
                if (this.EventStatus != null) EventStatus.AppendText(message + "\r\n");
             }));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            this.Data.Image = bitmap;
            if(this.PBox!=null) this.PBox.Image = new Bitmap(bitmap, PBox.Size);
        }
    }
}
