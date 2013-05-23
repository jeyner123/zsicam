using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using zsi.PhotoFingCapture.Models;
using zsi.PhotoFingCapture.Models.DataControllers;
namespace zsi.PhotoFingCapture
{
    public partial class frmLogin : Form
    {
        private frmMain _ParentForm { get; set; }
        public Boolean AccessGranted { get; set; }


        public frmLogin(frmMain ParentForm)
        {
            this._ParentForm = ParentForm;
            InitializeComponent();
        }

        private void login() {
            try
            {
                if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Enter UserName and Password.", "Try Again.", MessageBoxButtons.OK);
                    return;
                }
                btnLogin.Text = "Wait...";
                btnLogin.Enabled = false;
                //zsi.PhotoFingCapture.WebFileService.WebFileManager fm = new zsi.PhotoFingCapture.WebFileService.WebFileManager();
                ClientSettings.UserInfo = new zsi.PhotoFingCapture.Models.User();
                dcUser dc = new dcUser();
                User info = dc.GetUserLogon(txtUserName.Text);
                string _decryptedPassword = string.Empty;
                _decryptedPassword = new zsi.Framework.Security.Cryptography().Decrypt(info.Password);

                if (txtPassword.Text == _decryptedPassword)
                {
                    

                    //store static user info
                    ClientSettings.UserInfo = info;
                    AccessGranted = true;


                    if (info.ClientId > 0)
                    {
                        //store static client info
                        ClientSettings.ClientWorkStationInfo = new dcClientWorkStation().GetLocalClientWorkStation();

                        //update client workstation
                        new dcClientWorkStation().UpdateLocalClientWorkStation(ClientSettings.ClientWorkStationInfo);
                    }
                    //EnableControls(true);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid User, Please Login.");
                    btnLogin.Text = "Login";
                    btnLogin.Enabled = true;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                btnLogin.Enabled = true;
            }
        }

    

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                login();

            }
            catch (InvalidOperationException ex) {

                MessageBox.Show(ex.Message);
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
            this._ParentForm.EnableControls(IsEnable);
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
