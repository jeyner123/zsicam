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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUserName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter UserName and Password.", "Try Again.", MessageBoxButtons.OK);
                    return;
                }
                btnLogin.Text = "Wait...";
                zsi.PhotoFingCapture.WebFileService.WebFileManager fm = new zsi.PhotoFingCapture.WebFileService.WebFileManager();
                 this.ParentForm.UserId = fm.GetUserId(txtUserName.Text, txtPassword.Text).ToString();
                if (int.Parse(this.ParentForm.UserId) < 1)
                {
                    MessageBox.Show("Invalid User, Please Login.");
                    btnLogin.Text = "Login";
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                EnableControls(true);
                btnLogin.Text = "Login";
                this.Close();
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

    }
}
