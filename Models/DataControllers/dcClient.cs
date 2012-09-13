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
        private OleDbTransaction Trans { get; set; }
        private OleDbConnection OleDbconn { get; set; }
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");

            this.DBConn = new SqlConnection(_ConnectionString);

            //oledb connection
            string _OLEDbConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.AccessDBConnection;
            _OLEDbConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_OLEDbConnectionString, "{p}.*.{p}", "{p}");
            this.OleDbconn = new OleDbConnection(_OLEDbConnectionString);

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


        public Client GetClientInfo(int ClientId)
        {
            try
            {

                dcClient _dc = new dcClient();
                SQLServer.Procedure p = new SQLServer.Procedure("dbo.SelectClients");
                p.Parameters.Add("p_ClientId", ClientId);
                return _dc.GetInfo(p);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 11001)
                    return new Client();
                else
                    throw ex;
            }
        }
        public Client GetClientInfo(int ClientId,int WorkStationId)
        {
            try
            {
                dcClient _dc = new dcClient();
                SQLServer.Procedure p = new SQLServer.Procedure("dbo.SelectClientWorkStations");
                if (ClientId > 0) p.Parameters.Add("p_ClientId", ClientId);
                if (WorkStationId > 0)  p.Parameters.Add("p_WorkStationId", WorkStationId);
                if (WorkStationId == 0) p.Parameters.Add("p_WSMacAddress", Util.GetMacAddress());
                return _dc.GetInfo(p);
            }

            catch (SqlException ex)
            {
                if (ex.Number == 11001)
                    return new Client();
                else
                    throw ex;
            }

        }

        public Client GetLocalClientInfo()
        {
            try
            {
                dcClient2 dc = new dcClient2();                
                List<Client> list =  dc.GetDataSource("Select * from ClientInfo");
                if (list.Count==0) return new Client(); 
                return list[0]; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

 

        public void UpdateLocalClientInfo(Client info)
        {
            try
            {
                if (info.WorkStationId > 0)
                {

                    this.OpenDB();
                    OleDbCommand cmd = new OleDbCommand("select count(*) from ClientInfo", OleDbconn);
                    var _params = cmd.Parameters;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();

                    //insert new
                    if (count == 0)
                    {
                        cmd = new OleDbCommand("Insert into ClientInfo(WorkStationId) Values(?)", OleDbconn);
                        _params = cmd.Parameters;
                        SetParameterValue(_params, info.WorkStationId, OleDbType.Integer);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }

                    UpdateParams(info);
                }
            }
    

            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void UpdateParams(Client info)
        {
            try
            {
                this.OpenDB();

                //update info
                OleDbCommand cmd = new OleDbCommand("update ClientInfo set "
                           + " ClientId=?,ClientName=?,CompanyCode=?,ClientTypeId=?,CompanyName=?,CompanyTelNo=?,CompanyTIN=?,CompanyLogo=?"
                           + ",RegionId=?,ProvinceId=?,CityMunicipalityId=?,BarangayId=?,Address=?,IsAutoId=?,ClientMainId=?,ClientGroupId=?"
                           + ",LastEmployeeNo=?,ApplicationId=? where WorkStationId=" + info.WorkStationId
                          , OleDbconn);
                var _params = cmd.Parameters;
                SetParameterValue(_params, info.ClientId, OleDbType.Integer);
                SetParameterValue(_params, info.ClientName, OleDbType.VarChar);
                SetParameterValue(_params, info.CompanyCode, OleDbType.VarChar);
                SetParameterValue(_params, info.ClientTypeId, OleDbType.Integer);
                SetParameterValue(_params, info.CompanyName, OleDbType.VarChar);
                SetParameterValue(_params, info.CompanyTelNo, OleDbType.VarChar);
                SetParameterValue(_params, info.CompanyTIN, OleDbType.VarChar);
                SetParameterValue(_params, info.CompanyLogo, OleDbType.Binary);
                SetParameterValue(_params, info.RegionId, OleDbType.Integer);
                SetParameterValue(_params, info.ProvinceId, OleDbType.Integer);
                SetParameterValue(_params, info.CityMunicipalityId, OleDbType.Integer);
                SetParameterValue(_params, info.BarangayId, OleDbType.Integer);
                SetParameterValue(_params, info.Address, OleDbType.VarChar);
                SetParameterValue(_params, info.IsAutoId, OleDbType.Boolean);
                SetParameterValue(_params, info.ClientMainId, OleDbType.Integer);
                SetParameterValue(_params, info.ClientGroupId, OleDbType.Integer);
                SetParameterValue(_params, info.LastEmployeeNo, OleDbType.VarChar);
                SetParameterValue(_params, info.ApplicationId, OleDbType.Integer);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

 
        private void OpenDB()
        {
            if (this.OleDbconn.State != ConnectionState.Open)
            {
                this.OleDbconn.Open();
            }
        }
        private void CloseDB()
        {
            if (this.OleDbconn.State != ConnectionState.Closed)
            {
                this.OleDbconn.Close();
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


    public class dcClient2 : OleDb.MasterDataController<Client>
    {
        private OleDbTransaction Trans { get; set; }
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.AccessDBConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            this.DBConn = new OleDbConnection(_ConnectionString);
          
        }
    }
}
