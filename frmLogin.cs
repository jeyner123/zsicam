using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zsi.PhotoFingCapture
{
    public partial class frmLogin : Form
    {
        public frmMain ParentForm { get; set; }

        public frmLogin(frmMain ParentForm)
        {
            this.ParentForm = ParentForm;
            InitializeComponent();
        }

        private void login() {

            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Enter UserName and Password.", "Try Again.", MessageBoxButtons.OK);
                return;
            }
            btnLogin.Text = "Wait...";
            btnLogin.Enabled = false;
            zsi.PhotoFingCapture.WebFileService.WebFileManager fm = new zsi.PhotoFingCapture.WebFileService.WebFileManager();

            ClientInfo.UserInfo = new zsi.PhotoFingCapture.Models.User();
            ClientInfo.UserInfo.UserId=Convert.ToInt32( fm.GetUserId(txtUserName.Text, txtPassword.Text).ToString());
            if (ClientInfo.UserInfo.UserId< 1)
            {
                MessageBox.Show("Invalid User, Please Login.");
                btnLogin.Text = "Login";
                return;
            }
            EnableControls(true);
            this.Close();
        
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                login();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Login";
            }
        }

        private void EnableControls(Boolean IsEnable)
        {
            txtUserName.Enabled = IsEnable;
            txtPassword.Enabled = IsEnable;
            this.ParentForm.EnableControls(IsEnable);
        }

 

        private void btnSettings_Click(object sender, EventArgs e)
        {
            zsi.PhotoFingCapture.frmSettings frmSettings = new zsi.PhotoFingCapture.frmSettings();
            frmSettings.ShowDialog();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue  == 13)
            {
                login();
            }
        }

    }
}
