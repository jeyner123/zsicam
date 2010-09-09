using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using zsi.WebCamServices;
using System.Windows.Forms;
using System.Drawing;
namespace zsi.PhotoFingCapture
{

    public class MotionImages
    {

        public MotionImages(PictureBox PictureBox)
        {
            this.PictureBox = PictureBox;
        }
        public PictureBox PictureBox { get; set; }
        public WebCamManager WebCam { get; set; }
        // This method that will be called when the thread is started

        public void Run()
        {
            this.WebCam = new WebCamManager();

            while (true)
            {
                if (this.WebCam != null)
                {

                    byte[] _byteimg = this.WebCam.GrabFrame();

                    if (_byteimg != null)
                    {
                        System.IO.MemoryStream st = new System.IO.MemoryStream(_byteimg);
                        // picture.Image = System.Drawing.Image.FromStream(st);
                        Image _img = System.Drawing.Image.FromStream(st);
                        // PictureBox.Image = _img;

                        PictureBox.Image = Util.CropImage((Bitmap)_img, 310, 233);

                    }
                }

            }
        }
    }

}
