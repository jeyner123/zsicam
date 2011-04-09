using System;
using System.Collections.Generic;
using System.Text;

using Touchless.Vision.Camera;


using System.IO; 
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
 
namespace zsi.WebCamServices
{
    public class WebCamManager
    {
        public CameraFrameSource FrameSource { get; set; }
        public Bitmap LatestFrame {get;set;}

        private ComboBox ComboBoxCameras { get; set; }
        private PictureBox PictureBox { get; set; }
        public WebCamManager(){
            InitCameras();
        }

        public WebCamManager(PictureBox pictureBox, ComboBox comboBoxCameras){
        
            this.ComboBoxCameras =comboBoxCameras;
            this.PictureBox = pictureBox;
            InitCameras();
        }

        private void InitCameras(){
                        // Refresh the list of available cameras
                ComboBoxCameras.Items.Clear();
                foreach (Camera cam in CameraService.AvailableCameras)
                    ComboBoxCameras.Items.Add(cam);

                if (ComboBoxCameras.Items.Count > 0)
                    ComboBoxCameras.SelectedIndex = 0;

        }
        private  void startCapturing()
        {
            try
            {

                Camera c = (Camera)ComboBoxCameras.SelectedItem;
                setFrameSource(new CameraFrameSource(c));
                //  _frameSource.Camera.CaptureWidth = 320;
                //  _frameSource.Camera.CaptureHeight = 240;
                FrameSource.Camera.Fps = 20;
                FrameSource.NewFrame += OnImageCaptured;

                PictureBox.Paint += new PaintEventHandler(drawLatestImage);
                FrameSource.StartFrameCapture();
            }
            catch (Exception ex)
            {
                ComboBoxCameras.Text = "Select A Camera";
                MessageBox.Show(ex.Message);
            }


        }


        private void drawLatestImage(object sender, PaintEventArgs e)
        {
            if (LatestFrame != null)
            {
                // Draw the latest image from the active camera
                e.Graphics.DrawImage(LatestFrame, 0, 0, PictureBox.Width, PictureBox.Height);
            }
        }


        public void OnImageCaptured(Touchless.Vision.Contracts.IFrameSource frameSource, Touchless.Vision.Contracts.Frame frame, double fps)
        {
            LatestFrame = frame.Image;
            PictureBox.Invalidate();
        }

        private void setFrameSource(CameraFrameSource cameraFrameSource)
        {
            if (FrameSource == cameraFrameSource)
                return;

            FrameSource = cameraFrameSource;
        }

        //

        private void thrashOldCamera()
        {
            // Trash the old camera
            if (FrameSource != null)
            {
                FrameSource.NewFrame -= OnImageCaptured;
                FrameSource.Camera.Dispose();
                setFrameSource(null);
                PictureBox.Paint -= new PaintEventHandler(drawLatestImage);
            }
        }
        public void Start(){
            // Early return if we've selected the current camera
            if (FrameSource != null && FrameSource.Camera == ComboBoxCameras.SelectedItem)
                return;
            thrashOldCamera();
            startCapturing();
        }
        public void Stop() {

            thrashOldCamera();
        }

    }
}


