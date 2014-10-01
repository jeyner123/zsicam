using System;
using System.Collections.Generic;
using System.Text;
using TouchlessLib;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;

namespace zsi.dtrs.camera.WebCam
{
    public class WebCamService
    {


        public Camera CurrentCamera { get; set; }

        private ComboBox ComboBoxCameras { get; set; }
        private PictureBox PictureBox { get; set; }
        private Bitmap LatestFrame { get; set; }
        private TouchlessMgr TouchLessWebCamMgr { get; set; }


        public WebCamService()
        {
            InitCameras();
        }

        public WebCamService(PictureBox pictureBox, ComboBox comboBoxCameras)
        {

            this.ComboBoxCameras = comboBoxCameras;
            this.PictureBox = pictureBox;
            InitCameras();
        }

        private void InitCameras()
        {

            TouchlessMgr _mgr = new TouchlessMgr();
            ComboBoxCameras.Items.Clear();
            foreach (Camera c in _mgr.Cameras)
            {
                this.ComboBoxCameras.Items.Add(c.ToString());

            }

            _mgr.Dispose();
            _mgr = null;
            PictureBox.Paint += new PaintEventHandler(PictureBox_Paint);
        }
        void OnImageCaptured(object sender, CameraEventArgs e)
        {

            LatestFrame = e.Image;
            PictureBox.Invalidate();


        }



        void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            lock (this)
            {
                if (LatestFrame != null)
                {
                    e.Graphics.DrawImageUnscaledAndClipped(LatestFrame, PictureBox.ClientRectangle);
                }
            }
        }


        private void thrashOldCamera()
        {
            // Dispose of the TouchlessMgr object
            if (TouchLessWebCamMgr != null)
            {
                TouchLessWebCamMgr.Dispose();
                TouchLessWebCamMgr = null;
            }

        }
        public void Start()
        {
            if (this.ComboBoxCameras.SelectedItem == null) return;

            thrashOldCamera();
            this.TouchLessWebCamMgr = new TouchlessMgr();
            try
            {
                foreach (Camera c in TouchLessWebCamMgr.Cameras)
                {
                    if (this.ComboBoxCameras.SelectedItem.ToString() == c.ToString())
                    {
                        this.CurrentCamera = c;
                    }
                }

                if (this.CurrentCamera != null)
                {
                    TouchLessWebCamMgr.CurrentCamera = this.CurrentCamera;
                    this.CurrentCamera.OnImageCaptured += new EventHandler<CameraEventArgs>(OnImageCaptured);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Stop()
        {

            thrashOldCamera();
        }

    }
}
