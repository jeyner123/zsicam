using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
namespace zsi.PhotoFingCapture
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            Mutex m = new Mutex(true, "PhotoFingCapture", out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("PhotoFingCapture is already running! \nYou can close this application at system tray area.", "PhotoFingCapture");
                return;
            }
            else {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
                //Application.Run(new zsi.Biometrics.frmTimInOut());
            }

        }
    }
}