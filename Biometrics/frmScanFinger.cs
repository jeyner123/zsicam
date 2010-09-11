using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zsi.Biometrics
{
    public partial class frmScanFinger :FingersMasterScanner
    {
        private Control Control { get; set; }
 
        public frmScanFinger(Object sender,FingersData Data,int FingerPosition)
        {

            InitializeComponent();

            this.FingerPosition = FingerPosition;
            this.Data = Data;
            this.Control = (Control)sender;
            DeleteData();
            this.FormClosing +=new FormClosingEventHandler(delegate{CloseForm();});
            this.SetControls(Picture, StatusText, Prompt, StatusLine);
            this.CloseButton.Click += new EventHandler(delegate { this.Close(); });
        }

        private void DeleteData(){
            this.Control.BackColor = Color.White;
            this.Control.ForeColor = Color.Black;
            this.Data.UpdateTemplates(FingerPosition, null);
            this.Data.UpdateSamples(FingerPosition, null);

        }

        public void CloseForm()
        {
            if (this.IsComplete == true)
            {
                this.Control.BackColor = Color.Green;
                this.Control.ForeColor = Color.White;
            }
      
        }
           
    
    }
}
