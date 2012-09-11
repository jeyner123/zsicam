using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using zsi.PhotoFingCapture;
using zsi.PhotoFingCapture.Models;
using System.Web.Script.Serialization;
using zsi.PhotoFingCapture.Properties;
using zsi.PhotoFingCapture.Models.DataControllers;
using System.Data.OleDb;

namespace zsi.PhotoFingCapture
{

    public partial class test : Form
    {
        public OleDbConnection DBConn { get; set; }
        public test()
        {
            InitializeComponent();
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.AccessDBConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            this.DBConn = new OleDbConnection(_ConnectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {

 
        }

        private void OpenDB()
        {
            if (this.DBConn.State != ConnectionState.Open)
            {
                this.DBConn.Open();
            }
        }
        private void CloseDB()
        {
            if (this.DBConn.State != ConnectionState.Closed)
            {
                this.DBConn.Close();
            }
        }

        void SetParameterValue(OleDbParameterCollection Params, object value, OleDbType type)
        {
            if (value != null)
            {
                Params.Add("?", type).Value = value;
            }
            else
            {
                Params.AddWithValue("?", DBNull.Value);
            }

        }
    }
}
