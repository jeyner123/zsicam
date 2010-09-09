using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;

namespace WebFileService
{
    public class WebFileManager
    {
        public static string FileUploadViaWebService(FileInfo oFileInfo,String UserId)
        {
            FileStream objFileStream;
           
            zsi.PhotoFingCapture.WebFileService.WebFileManager fm = new zsi.PhotoFingCapture.WebFileService.WebFileManager();
            String strReturn = string.Empty;
            bool bolResult = false;
            try
            {
                if (File.Exists(oFileInfo.FullName) == false) throw new Exception("No File found.");

                fm.Url = System.Configuration.ConfigurationSettings.AppSettings["WebFile_URI"];
                
                //fm.Url = zsi.PhotoFingCapture.Properties.Settings.Default["zsi.PhotoFingCapture_WebFileService_WebFileManager"].ToString();
                objFileStream = oFileInfo.Open(FileMode.Open, FileAccess.Read);

                byte[] objFileByte = new Byte[objFileStream.Length];
                objFileStream.Read(objFileByte, 0, Convert.ToInt32(objFileStream.Length));
                bolResult = fm.UploadFile(UserId, oFileInfo.Name, objFileByte, strReturn);
                if (bolResult == false)
                {
                    throw new Exception(strReturn);
                }
                else
                {
                    return "File Uploaded Successfully";
                }
                objFileStream.Close();
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
