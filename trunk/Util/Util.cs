using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
namespace zsi.PhotoFingCapture
{
    public class Util
    {

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
                return "zsi.PhotoFingCapture.exe.config";
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
    }
}
