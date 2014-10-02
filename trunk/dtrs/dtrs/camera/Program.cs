using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
namespace zsi.dtrs.camera
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool createdNew;
            Mutex m = new Mutex(true, "ZSI DTR - Camera", out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("PhotoFingCapture is already running! \nYou can close this application at system tray area.", "PhotoFingCapture");
                return;
            }
            else {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if(args.Length>0)
                    Application.Run(new frmMain(args[0]));
                else 
                    Application.Run(new frmMain());
     
                //Application.Run(new zsi.Biometrics.frmTimInOut());
            }

        }
    }
}