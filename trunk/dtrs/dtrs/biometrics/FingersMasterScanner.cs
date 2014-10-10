using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
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
        //private properties
        private PictureBox PBox { get; set; }
        private TextBox EventStatus { get; set; }
        private TextBox PromptText { get; set; }
        private Label StatusLine { get; set; }
        private Control Control { get; set; }
        
        //public properties
        public DPFP.Processing.Enrollment Enroller;
        public DPFP.Capture.Capture Capturer;
        public DPFP.Sample Sample{get;set;}
        public bool IsAutoClose { get; set; }
        public int FingerPosition { get; set; }
        public int SampleIndex { get; set; }
        public FingersBiometrics Data { get; set; }
        public bool IsComplete { get; set; } 
        public string ReaderSerialNumber{get;set;}

        public void SetControls(PictureBox PBox, TextBox EventStatus, TextBox PromptText, Label StatusLine)
        {
            this.PBox = PBox;
            this.EventStatus = EventStatus;
            this.PromptText = PromptText;
            this.StatusLine = StatusLine;
        }
        public void SetControls(PictureBox PBox)
        {
            this.PBox = PBox;
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
 
        public virtual void Process(DPFP.Sample Sample){
            if (this.SampleIndex > 3) this.SampleIndex = 3;
            this.Data.Samples[this.FingerPosition, this.SampleIndex] = Sample;                
            DrawPicture(zsi.dtrs.Util.ConvertSampleToBitmap(Sample));
            this.SampleIndex++;
        }
       

      
        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            this.ReaderSerialNumber = ReaderSerialNumber;
            MakeReport("The fingerprint sample was captured.");
            SetPrompt("Scan the same fingerprint again.");            
            this.Process(Sample);
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

 
        public void DrawPicture(Bitmap bitmap)
        {
            //resize
            Rectangle cropRect = new Rectangle(0, 0, 200, 220);
            Bitmap _resizedImg = new Bitmap(200, 220);
            Graphics g = Graphics.FromImage(_resizedImg);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            g.DrawImage(bitmap, cropRect, new Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);


            //crop
            Bitmap _CropImg = new Bitmap(200, 200);
            g = Graphics.FromImage(_CropImg);
            g.DrawImage(_resizedImg, cropRect, new Rectangle(0, 20,200,200), GraphicsUnit.Pixel);

            //this.Data.Images[this.FingerPosition] = _CropImg;
            if (this.PBox != null) this.PBox.Image = new Bitmap(_CropImg, PBox.Size);
 
        }
    }
}
