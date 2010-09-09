using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;

namespace zsi.WebFileService
{
    public class WebFileManager
    {
        public static void FileUploadViaWebService(FileInfo oFileInfo,String UserId)
        {
            FileStream objFileStream;
           
            zsi.PhotoFingCapture.WebFileService.WebFileManager fm = new zsi.PhotoFingCapture.WebFileService.WebFileManager();
            String strReturn = string.Empty;
            bool bolResult = false;
            try
            {
                if (File.Exists(oFileInfo.FullName) == false) throw new Exception("No File found.");

                fm.Url = zsi.PhotoFingCapture.Util.GetWebServiceURL;                
                objFileStream = oFileInfo.Open(FileMode.Open, FileAccess.Read);
                byte[] objFileByte = new Byte[objFileStream.Length];
                objFileStream.Read(objFileByte, 0, Convert.ToInt32(objFileStream.Length));
                bolResult = fm.UploadFile(UserId, oFileInfo.Name, objFileByte, strReturn);
                if (bolResult == false)
                {
                    throw new Exception(strReturn);
                }
 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //cleanup
                fm = null;
                 
                objFileStream = null;
            }
        }
    }
}
