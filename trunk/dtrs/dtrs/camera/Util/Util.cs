using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
namespace zsi.dtrs.camera
{

    public class Util
    {
        public static void SaveBmpToFile(Bitmap bmp, string filename)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            bmp.Save(filename, GetEncoder(ImageFormat.Jpeg), encoderParameters);
        }

        public static Stream BmpToStream(Image img)
        {
            MemoryStream _ms= new MemoryStream();
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            img.Save(_ms, GetEncoder(ImageFormat.Jpeg), encoderParameters);            
            return _ms;
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }


        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static byte[] LoadImage(string FilePath)
        {
            try
            {
                FileStream fs = new FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] Image = new byte[fs.Length];
                fs.Read(Image, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                return Image;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Image CropImage(Bitmap bmpSource, int width, int height)
        {
            try
            {
                Rectangle cropRect = new Rectangle(0, 0, width, height);


                //resize
                Bitmap _resizedImg = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(_resizedImg);
                g.DrawImage(bmpSource, cropRect, new Rectangle(0, 0, bmpSource.Width, bmpSource.Height), GraphicsUnit.Pixel);

                //crop
                Bitmap _CropImg = new Bitmap(270, height - 10);
                g = Graphics.FromImage(_CropImg);
                g.DrawImage(_resizedImg, cropRect, new Rectangle(18, 10, width, height), GraphicsUnit.Pixel);

                return (Image)_CropImg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetConfigFileName
        {
            get
            {
                return "zsi.dtrs.camera.exe.config";
            }
        }
 
        public static string GetWebServiceURL
        {
            get
            {

                XmlDocument _doc;
                XmlNode _node;
                string AppConfigFile = Util.GetConfigFileName;
                _doc = new XmlDocument();
                _doc.Load(AppConfigFile);
                XmlNodeList _nodes;
                _nodes = _doc.SelectNodes("//applicationSettings");
                _node = _nodes.Item(0).ChildNodes.Item(0).ChildNodes.Item(0).ChildNodes.Item(0);
                return _node.InnerText;
            }
        }


        public static byte[] StreamToByte(System.IO.Stream stream)
        {
            long originalPosition = stream.Position;
            stream.Position = 0;

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                stream.Position = originalPosition;
            }

        }


        public static void LogError(string ErrorMessage) {
            try
            {
                StreamWriter log;
                string FileName = "logfile.txt";
                if (!File.Exists("logfile.txt"))
                {
                    log = new StreamWriter(FileName);
                }
                else
                {
                    log = File.AppendText(FileName);
                }

                // Write to the file:
                log.WriteLine("---[ " + DateTime.Now.ToUniversalTime().AddHours(8).ToString() + "]----");
                log.WriteLine(ErrorMessage);
                log.WriteLine();

                // Close the stream:
                log.Close();
            }
            catch{} 
            
        }

 
        public static string GetMacAddress()
        {
            string macAddresses = "";
            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {

                //if (nic.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Ethernet) continue;
                 if (nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    if (macAddresses != "") break;
                }
            }
            return macAddresses;
        }
 
        public static string GetAllMacAddress()
        {
             
            string macAddresses = "";

            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                string macAddress = nic.GetPhysicalAddress().ToString();
                if (macAddress != "" && macAddress.Contains("000E0")==false)
                {
                    if (macAddresses != "") macAddresses += ",";
                    macAddresses += string.Format("'{0}'", macAddress);
                }
            }
            return macAddresses;
        }


        public static Boolean IsOnline
        {
            get
            {
                try
                {
                    var ping = new System.Net.NetworkInformation.Ping();
                    var result = ping.Send("www.google.com");
                    if (result.Status == System.Net.NetworkInformation.IPStatus.Success)
                        return true;
                    else
                        return false;
                }
                catch { return false; }
            }
        }

        public static Image GetNoPhoto()
        {
            try
            {
                Image img;
                string FileName = "nophoto.jpg";
                if (File.Exists(FileName))
                {
                    img = Image.FromFile(FileName);
                }
                else
                {
                    img = null;
                }
                return img;

            }
            catch (Exception ex) { throw ex; }

        }
    }

    public class About {
        #region Assembly Attribute Accessors

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

 

      
    }

}
