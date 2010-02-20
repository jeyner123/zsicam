using System;
using System.Collections.Generic;
using System.Text;

namespace WebCamService
{
   public class WebCamManager
    {

         WebCamLibrary.WebCam cam;

       public WebCamManager()
        {
            try
            {

                cam = WebCamLibrary.WebCam.NewWebCam();
            }
            catch (Exception ex) {
               
            }
        }
 
    public byte[] GrabFrame()
    {
        return cam.GrabFrame();
    }
 
    public string[] GetConnectedCameras()
    {
        return cam.GetConnectedCameras();
    }
    }
}


