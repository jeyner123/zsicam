using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using zsi.Framework.Data.DataProvider.OleDb;
using zsi.Framework.Data;
using System.Data;
using System.Data.OleDb;
namespace zsi.PhotoFingCapture.Models.DataControllers
{
    public class dcClientSetting : MasterDataController<ClientSetting>
    {
        private OleDbTransaction Trans { get; set; }

        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.AccessDBConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            this.DBConn = new OleDbConnection(_ConnectionString);
        }

        
 
        private void OpenDB()
        {
            if (this.DBConn.State!=ConnectionState.Open){
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
