using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            //Application.Run(new zsi.Biometrics.frmTimInOut());

        }
    }
}