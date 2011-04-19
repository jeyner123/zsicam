using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OleDb =zsi.Framework.Data.DataProvider.OleDb;
using SQLServer = zsi.Framework.Data.DataProvider.SQLServer;
using zsi.Framework.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace zsi.PhotoFingCapture.Models.DataControllers
{
    public class dcFingersTemplate : SQLServer.MasterDataController<FingerTemplate>
    {
        private dcFingersTemplate2 dcFTemplate{get;set;}
        private OleDbTransaction Trans { get; set; }
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            
            this.DBConn = new SqlConnection(_ConnectionString);
            this.Procedures.Add(new SQLServer.Procedure("dbo.SelectProfileFPT",SQLCommandType.Select));
        }

        private List<FingerTemplate> GetNewFingerData(DateTime CreatedDate) {
            dcFingersTemplate _dc = new dcFingersTemplate();
            SQLServer.Procedure p = new SQLServer.Procedure("dbo.SelectProfileFPT");
            p.Parameters.Add("p_CreatedDate", CreatedDate);
            _dc.GetDataSource(p);
            return _dc.List;
        }

        private List<FingerTemplate> GetUpdatedFingerData(DateTime UpdatedDate)
        {
            dcFingersTemplate _dc = new dcFingersTemplate();
            SQLServer.Procedure p = new SQLServer.Procedure("dbo.SelectProfileFPT");
            p.Parameters.Add("p_UpdatedDate",UpdatedDate);
            _dc.GetDataSource(p);
            return _dc.List;
        }

        public void FingerTemplatesUpdate()
        {
            try
            {
                DateTime _lastUpdatedDate;
                dcFTemplate = new dcFingersTemplate2();
                dcFTemplate.DBConn.Open();
                OleDbCommand _cmd2 = new OleDbCommand("select * from updatelog", dcFTemplate.DBConn);
                OleDbDataReader _dr2 = _cmd2.ExecuteReader(CommandBehavior.CloseConnection);
                
                Trans = dcFTemplate.DBConn.BeginTransaction();
                if (_dr2.HasRows == false)
                {
                   this.MigrateNewData(this.GetDataSource());
                   UpdateLastUpdate(); 
                }
                else {
                    _dr2.Read();
                    _lastUpdatedDate = Convert.ToDateTime(_dr2[1]);

                    List<FingerTemplate> _NewList = this.GetNewFingerData(_lastUpdatedDate);
                    List<FingerTemplate> _UpdatedList = this.GetUpdatedFingerData(_lastUpdatedDate);

                    this.MigrateNewData(_NewList);
                    this.MigrateUpdatedData(_UpdatedList);

                    if (_NewList.Count > 0 || _UpdatedList.Count > 0)
                    {
                        UpdateLastUpdate();
                    }

                }
                Trans.Commit();
                dcFTemplate.DBConn.Close();

            }
            catch (Exception ex)
            {
                try
                {
                    Trans.Rollback();
                }
                catch{}
                 throw ex;
            }
        }

        private void MigrateNewData(List<FingerTemplate> list) {
            try
            {

                foreach (FingerTemplate item in list)
                {
                        OleDbCommand _cmd2 = new OleDbCommand(
                        "Insert into FingersData(ProfileId,FullName,LeftTF,LeftIF,LeftMF,LeftRF,LeftSF,RightTF,RightIF,RightMF,RightRF,RightSF,CreatedDate,UpdatedDate) "
                        + "Values(?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                        , dcFTemplate.DBConn, Trans);

                        var _params =_cmd2.Parameters;
                        SetParameterValue(_params, item.ProfileId,OleDbType.VarChar);
                        SetParameterValue(_params, item.FullName,OleDbType.VarChar);
                        SetParameterValue(_params, item.LeftTF,OleDbType.VarBinary);
                        SetParameterValue(_params, item.LeftIF,OleDbType.VarBinary);
                        SetParameterValue(_params, item.LeftMF,OleDbType.VarBinary);
                        SetParameterValue(_params, item.LeftRF,OleDbType.VarBinary);
                        SetParameterValue(_params, item.LeftSF,OleDbType.VarBinary);
                        SetParameterValue(_params, item.RightTF,OleDbType.VarBinary);
                        SetParameterValue(_params, item.RightIF,OleDbType.VarBinary);
                        SetParameterValue(_params, item.RightMF,OleDbType.VarBinary);
                        SetParameterValue(_params, item.RightRF,OleDbType.VarBinary);
                        SetParameterValue(_params, item.RightSF,OleDbType.VarBinary);
                        SetParameterValue(_params, item.CreatedDate,OleDbType.Date);
                        SetParameterValue(_params, item.UpdatedDate,OleDbType.Date);

                        _cmd2.ExecuteNonQuery();
              }           
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void MigrateUpdatedData(List<FingerTemplate> list)
        {
            try
            {
                foreach (FingerTemplate item in list)
                {
                    OleDbCommand _cmd2 = new OleDbCommand(
                    "Update FingersData set LeftTF=?,LeftIF=?,LeftMF=?,LeftRF=?,LeftSF=?,RightTF=?,RightIF=?,RightMF=?,RightRF=?,RightSF=?,UpdatedDate=?"
                   + " where profileId='" + item.ProfileId + "'"
                    , dcFTemplate.DBConn,Trans);
                    var _params = _cmd2.Parameters;


                    SetParameterValue(_params, item.LeftTF, OleDbType.VarBinary);
                    SetParameterValue(_params, item.LeftIF, OleDbType.VarBinary);
                    SetParameterValue(_params, item.LeftMF, OleDbType.VarBinary);
                    SetParameterValue(_params, item.LeftRF, OleDbType.VarBinary);
                    SetParameterValue(_params, item.LeftSF, OleDbType.VarBinary);
                    SetParameterValue(_params, item.RightTF, OleDbType.VarBinary);
                    SetParameterValue(_params, item.RightIF, OleDbType.VarBinary);
                    SetParameterValue(_params, item.RightMF, OleDbType.VarBinary);
                    SetParameterValue(_params, item.RightRF, OleDbType.VarBinary);
                    SetParameterValue(_params, item.RightSF, OleDbType.VarBinary);
                    SetParameterValue(_params, item.UpdatedDate,OleDbType.Date);
                    _cmd2.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void UpdateLastUpdate(){

            dcFingersTemplate2 _dc = new dcFingersTemplate2();
            OleDbCommand _cmd = new OleDbCommand("select * from updatelog", _dc.DBConn);
            _dc.DBConn.Open();
            OleDbDataReader _dr = _cmd.ExecuteReader();
            if (!_dr.HasRows)
            {
                _cmd = new OleDbCommand(
                "Insert Into UpdateLog(LastUpdatedDate) values(?)", dcFTemplate.DBConn, Trans);
                _cmd.Parameters.AddWithValue("?", DateTime.Now.ToString());
                _cmd.ExecuteNonQuery();
            }
            else {
                _cmd = new OleDbCommand(
                "Update UpdateLog set LastUpdatedDate=?", dcFTemplate.DBConn, Trans);
                _cmd.Parameters.AddWithValue("?", DateTime.Now.ToString());
                _cmd.ExecuteNonQuery();            
            }
            _dc.DBConn.Close();   
        }
 
        void SetParameterValue(OleDbParameterCollection Params, object value,OleDbType type)
        {
            if (value != null)
            {
                Params.Add("?", type).Value=value;
            }
            else {
                Params.AddWithValue("?",DBNull.Value);            
            }

        }
    }
}
