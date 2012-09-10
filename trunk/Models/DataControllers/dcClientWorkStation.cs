using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OleDb = zsi.Framework.Data.DataProvider.OleDb;
using SQLServer = zsi.Framework.Data.DataProvider.SQLServer;
using zsi.Framework.Data;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using zsi.PhotoFingCapture.Models;
using System.IO;
using zsi.Framework.Common;
using System.Collections.ObjectModel;
namespace zsi.PhotoFingCapture.Models.DataControllers
{
    public class dcClientWorkStation : SQLServer.MasterDataController<ClientWorkStation>
    {

        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");

            this.DBConn = new SqlConnection(_ConnectionString);
            this.Procedures.Add(new SQLServer.Procedure("dbo.SelectPlaces", SQLCommandType.Select));
            this.Procedures.Add(new SQLServer.Procedure("dbo.GetPlaceName", SQLCommandType.GetSingleInfo));
        }
        public bool UpdateWorkStation(int ClientId){
            try
            {
                dcClientWorkStation _dcUpdate = new dcClientWorkStation();
                SQLServer.Procedure _procUpdate = new SQLServer.Procedure("dbo.UpdateClientWorkStation");
                _procUpdate.Parameters.Add("p_WSMacAddress", Util.GetMacAddress());
                _procUpdate.Parameters.Add("p_ClientId", ClientId);
                _procUpdate.Parameters.Add("p_CreatedUpdatedBy", ClientSettings.UserInfo.UserId);
                return _dcUpdate.Update(_procUpdate);
            } 
            catch (Exception ex)
            {
                throw ex;
            }      
        }

        public string GetRegisteredMacAddress()
        {
            try
            {
                string _addresses = Util.GetAllMacAddress();
                string _str = "select isnull((select top 1 wsmacaddress from dbo.ClientWorkStations where wsmacaddress in ({0})),'') as result";
                string _sql = string.Format(_str, _addresses);

                SqlCommand _SqlCommand = new SqlCommand(_sql, this.DBConn);
                this.DBConn.Open();
	           object _scalarVal = _SqlCommand.ExecuteScalar();
               this.DBConn.Close();
               if (_scalarVal == null ) return ""; else return _scalarVal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "[]";
            }
        }

    


    }
}
