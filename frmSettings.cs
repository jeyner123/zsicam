using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZSICam
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtWebRef.Text = ZSICam.Properties.Settings.Default["ZSICam_WebFileService_WebFileManager"].ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ZSICam.Properties.Settings.Default["ZSICam_WebFileService_WebFileManager"] = txtWebRef.Text;
            ZSICam.Properties.Settings.Default.Save();
            this.Close();


        }
    }
}