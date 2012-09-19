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
    public class dcClientWorkStation2 : SQLServer.MasterDataController<ClientWorkStation>
    {
        public override void InitDataController()
        {
            //sql connection
            string _SQLConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _SQLConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_SQLConnectionString, "{u}.*.{u}", "{u}");
            _SQLConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_SQLConnectionString, "{p}.*.{p}", "{p}");
            this.DBConn = new SqlConnection(_SQLConnectionString);

        }
    }

    public class dcClientWorkStation : OleDb.MasterDataController<ClientWorkStation>
    {
       // private OleDbConnection OleDbconn { get; set; }
        private SqlConnection SQLDBConn { get; set; }

        public override void InitDataController()
        {
            //oledb connection
            string _OLEDbConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.AccessDBConnection;
            _OLEDbConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_OLEDbConnectionString, "{p}.*.{p}", "{p}");
            this.DBConn = new OleDbConnection(_OLEDbConnectionString);

            //sql connection
            string _SQLConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _SQLConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_SQLConnectionString, "{u}.*.{u}", "{u}");
            _SQLConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_SQLConnectionString, "{p}.*.{p}", "{p}");

            this.SQLDBConn = new SqlConnection(_SQLConnectionString); 
     
        }

        public ClientWorkStation GetLocalClientInfo()
        {
            try
            {
                
                List<ClientWorkStation> list = this.GetDataSource("Select * from ClientInfo");
                if (list.Count == 0) return new ClientWorkStation();
                return list[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public ClientWorkStation GetClientInfo(int ClientId, int WorkStationId)
        {
            try
            {
                dcClientWorkStation2 dc = new dcClientWorkStation2();
                zsi.Framework.Data.DataProvider.SQLServer.Procedure proc = new zsi.Framework.Data.DataProvider.SQLServer.Procedure("dbo.SelectClientWorkStations");
                var p = proc.Parameters;                
                if (ClientId > 0) p.Add("p_ClientId", ClientId);
                if (WorkStationId > 0) p.Add("p_WorkStationId", WorkStationId);
                if (WorkStationId == 0) p.Add("p_WSMacAddress", Util.GetMacAddress());
                return dc.GetDataSource(proc)[0];
            }

            catch (SqlException ex)
            {
                if (ex.Number == 11001)
                    return new ClientWorkStation();
                else
                    throw ex;
            }

        }
 

        public int UpdateWorkStation(int ClientId){
            try
            {

                dcClientWorkStation2 dc = new dcClientWorkStation2();
                zsi.Framework.Data.DataProvider.SQLServer.Procedure proc = new zsi.Framework.Data.DataProvider.SQLServer.Procedure("dbo.UpdateClientWorkStation");
                var p = proc.Parameters;  
                                
                p.Add("p_WSMacAddress", Util.GetMacAddress());
                p.Add("p_ClientId", ClientId);
                p.Add("p_CreatedUpdatedBy", ClientSettings.UserInfo.UserId);
                p.Add("p_WorkStationId",null,SqlDbType.Int,ParameterDirection.InputOutput);

                dc.Update();

                int _WorkStationId = Convert.ToInt32( p.GetItem("p_WorkStationId").Value);

                return _WorkStationId;
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

                SqlCommand _cmd = new SqlCommand(_sql, this.SQLDBConn);
                this.SQLDBConn.Open();
                object _scalarVal = _cmd.ExecuteScalar();
               this.SQLDBConn.Close();
               if (_scalarVal == null ) return ""; else return _scalarVal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "[]";
            }
        }


        public void UpdateLocalClientInfo(ClientWorkStation info)
        {
            try
            {
                if (info.WorkStationId > 0)
                {

                    this.OpenDB();
                    OleDbCommand cmd = new OleDbCommand("select count(*) from ClientInfo", this.DBConn);
                    var _params = cmd.Parameters;
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();

                    //insert new
                    if (count == 0)
                    {
                        cmd = new OleDbCommand("Insert into ClientInfo(WorkStationId) Values(?)", this.DBConn);
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
                          , this.DBConn);
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

    }


}



