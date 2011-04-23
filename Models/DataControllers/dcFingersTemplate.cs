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
using System.Windows.Forms;
using zsi.PhotoFingCapture.Models;
using System.IO;
using zsi.Framework.Common;
using System.Collections.ObjectModel;
namespace zsi.PhotoFingCapture.Models.DataControllers
{
    public class dcFingersTemplate : SQLServer.MasterDataController<FingerTemplate>
    {
        private dcFingersTemplate2 dcFTemplate{get;set;}
        private OleDbTransaction Trans { get; set; }
        public  _CallBackFunction CallBackFunction {get;set;}
        public delegate void _CallBackFunction();
       
        public void RunTest(){
            CallBackFunction();

        }
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


                ConsoleApp.WriteLine(Application.ProductName, "Starting migrating finger templates.");

                DateTime _lastUpdatedDate;
                dcFTemplate = new dcFingersTemplate2();
                dcFTemplate.DBConn.Open();
                OleDbCommand _cmd2 = new OleDbCommand("select * from updatelog", dcFTemplate.DBConn);
                OleDbDataReader _dr2 = _cmd2.ExecuteReader(CommandBehavior.CloseConnection);
                
                Trans = dcFTemplate.DBConn.BeginTransaction();
                if (_dr2.HasRows == false)
                {
                    this.GetDataSource();

                    ConsoleApp.WriteLine(Application.ProductName, "Get new records from the live server");
                    this.MigrateNewData(this.List);
                   UpdateLastUpdate(); 

                    
                }
                else {
                    _dr2.Read();
                    _lastUpdatedDate = Convert.ToDateTime(_dr2[1]);

                    ConsoleApp.WriteLine(Application.ProductName, "Get newest created and updated records from the live server");
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
                ConsoleApp.WriteLine(Application.ProductName, "Migrating finger templates has been done.");

            }
            catch (Exception ex)
            {
                try
                {
                    Trans.Rollback();
                }
                catch{}
                ConsoleApp.WriteLine(Application.ProductName, "[Error],"  + ex.ToString());
                zsi.PhotoFingCapture.Util.LogError(ex.ToString());
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
                _cmd.Parameters.AddWithValue("?", DateTime.Now.ToUniversalTime().AddHours(8).ToString());
                _cmd.ExecuteNonQuery();
            }
            else {
                _cmd = new OleDbCommand(
                "Update UpdateLog set LastUpdatedDate=?", dcFTemplate.DBConn, Trans);
                _cmd.Parameters.AddWithValue("?", DateTime.Now.ToUniversalTime().AddHours(8).ToString());
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


        public static Profile VerifyBiometricsData(int FingNo, byte[] data)
        {
            try
            {
                string _result = string.Empty;
                string _Finger = string.Empty;
                Profile _info = new Profile();
                dcFingersTemplate2 _dc = new dcFingersTemplate2();
                DPFP.Template _template = null;
                Stream _msSample = new MemoryStream(data);
                DPFP.Sample _sample = new DPFP.Sample();
                //deserialize
                _sample.DeSerialize(_msSample);
                // _list = _dc.GetDataSource();
                switch (FingNo)
                {
                    case 9: _Finger = "LeftSF"; break;
                    case 8: _Finger = "LeftRF"; break;
                    case 7: _Finger = "LeftMF"; break;
                    case 6: _Finger = "LeftIF"; break;
                    case 5: _Finger = "LeftTF"; break;
                    case 4: _Finger = "RightSF"; break;
                    case 3: _Finger = "RightRF"; break;
                    case 2: _Finger = "RightMF"; break;
                    case 1: _Finger = "RightIF"; break;
                    case 0: _Finger = "RightTF"; break;
                    default: break;
                }
                OleDbCommand _cmd = new OleDbCommand("select ProfileId,FullName," + _Finger + " from FingersData", _dc.DBConn);
                _dc.DBConn.Open();
                OleDbDataReader _dr = _cmd.ExecuteReader();
                bool IsFound =false;
                if (_dr.HasRows)
                {
                    while (_dr.Read())
                    {
                        if (_dr[2] != DBNull.Value)
                        {
                            _template = ProcessDBTemplate((byte[])_dr[2]);
                            IsFound = Verify(_sample, _template);
                        }
                        if (IsFound == true)
                        {
                            _info.ProfileId = Convert.ToInt64(_dr[0]);
                            _info.FullName = Convert.ToString(_dr[1]);
                            break;
                        }
                    }
                }
                else
                {
                    _info.ProfileId = 0;
                    _info.FullName = "";
                }
                return _info;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static bool Verify(DPFP.Sample _sample, DPFP.Template _template)
        {
            try
            {
                bool _result = false;
                DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
                DPFP.FeatureSet features = zsi.Biometrics.Util.ExtractFeatures(_sample, DPFP.Processing.DataPurpose.Verification);

                // Check quality of the sample and start verification if it's good
                // TODO: move to a separate task
                if (features != null)
                {
                    // Compare the feature set with our template
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, _template, ref result);

                    if (result.Verified)
                        _result = true;
                    else
                        _result = false;

                }
                return _result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private static DPFP.Template ProcessDBTemplate(byte[] _data)
        {
            DPFP.Template _template = null;
            Stream _ms = new MemoryStream(_data);
            _template = new DPFP.Template();
            //deserialize
            _template.DeSerialize(_ms);
            return _template;
        }
  

    }
}
