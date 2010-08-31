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
            catch (Exception ) {}
        }
 
    public byte[] GrabFrame()
    {
        try
        {
            return cam.GrabFrame();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
 
    public string[] GetConnectedCameras()
    {
        return cam.GetConnectedCameras();
    }
    }
}


