using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using zsi.WebCamServices;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using zsi.PhotoFingCapture;
namespace zsi.WebCamServices
{

    public class WebCamera
    {
        private Thread CameraThread { get; set; }
        private PictureBox PBox { get; set; }

        public void Close() {
            this.CameraThread.Abort();
        }
        public WebCamera(PictureBox PBox)
        {
            this.PBox = PBox;
        }

        public void Show()
        {
            MotionImages _montionImages = new MotionImages(this.PBox);
            // Create the thread object, passing in the Alpha.Beta method
            // via a ThreadStart delegate. This does not start the thread.
           // form.CameraThread = new Thread(new ThreadStart(_montionImages.Run));
           this.CameraThread = new Thread(new ThreadStart(_montionImages.Run));

            try
            {
                // Start the thread
                this.CameraThread.Start();

                // Spin for a while waiting for the started thread to become
                // alive:
                while (!this.CameraThread.IsAlive) ;

                // Put the Main thread to sleep for 1 millisecond to allow oThread
                // to do some work:
                Thread.Sleep(1);

                // Request that oThread be stopped
                // oThread.Abort();

                // Wait until oThread finishes. Join also has overloads
                // that take a millisecond interval or a TimeSpan object.
                //this.CameraThread.Join();
            }
            catch (ThreadStateException ex)
            {
                Console.Write(ex);
            }
        }

   
    }
    
    public class MotionImages
    {

        public WebCamManager WebCam { get; set; }
        private PictureBox PBox { get; set; }


        public MotionImages(PictureBox PBox)
        {
            this.PBox = PBox;
        }
 
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
                        Image _img = System.Drawing.Image.FromStream(st);
                        this.PBox.Image = Util.CropImage((Bitmap)_img, 310, 233);

                    }
                }

            }
        }
    }

}
