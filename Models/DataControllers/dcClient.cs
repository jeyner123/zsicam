using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OleDb = zsi.Framework.Data.DataProvider.OleDb;
using SQLServer = zsi.Framework.Data.DataProvider.SQLServer;
using zsi.Framework.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using zsi.PhotoFingCapture.Models;
using System.IO;
using zsi.Framework.Common;
using System.Collections.ObjectModel;
namespace zsi.PhotoFingCapture.Models.DataControllers
{
    public class dcClient : SQLServer.MasterDataController<Client>
    {
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");

            this.DBConn = new SqlConnection(_ConnectionString);

        }
        public Client GetClientByRegCode(string RegCode)
        {
            try
            {
                dcClient _dc = new dcClient();
                SQLServer.Procedure _proc = new SQLServer.Procedure("dbo.SelectClients");
                _proc.Parameters.Add("p_RegCode", RegCode);
                return _dc.GetInfo(_proc);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 11001)
                    return new Client();
                else
                    throw ex;
            }
        }

    }
}

 

 