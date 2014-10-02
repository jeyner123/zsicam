using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace zsi.dtrs.camera
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
               // login();

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

    }
}
