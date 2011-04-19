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
    public class dcFingersTemplate2 : MasterDataController<FingerTemplate>
    {
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.AccessDBConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            this.DBConn = new OleDbConnection(_ConnectionString);
        }
   
    }
}
