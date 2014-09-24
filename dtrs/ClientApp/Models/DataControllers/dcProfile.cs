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


    public class dcProfile_OleDb : OleDb.MasterDataController<Profile>
    {
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.AccessDBConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            this.DBConn = new OleDbConnection(_ConnectionString);
        }

    }

    public class dcProfile_SQL : SQLServer.MasterDataController<Profile>
    {
        private dcProfile_OleDb _dcProfile_OleDb { get; set; }
        private OleDbTransaction Trans { get; set; }
        public  _CallBackFunction CallBackFunction {get;set;}
        public delegate void _CallBackFunction();
        public SQLServer.RecordIndexChangedHandler RecordIndexChangedHandler { get; set; }
        public void RunTest(){
            CallBackFunction();

        }
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            
            this.DBConn = new SqlConnection(_ConnectionString);
            this.Procedures.Add(new SQLServer.Procedure("dbo.SelectProfileFPT", SQLCommandType.Select));
            this.Procedures.Add(new SQLServer.Procedure("dbo.SelectProfileFPT", SQLCommandType.Count));
        }


        private List<Profile> GetNewDataFromServer(DateTime ProfileLastUpdate)
        {
            //get total records
            this.CountParameters.Add("p_ClientId", ClientSettings.ClientWorkStationInfo.ClientId);
            this.CountParameters.Add("p_ApplicationId", ClientSettings.ClientWorkStationInfo.ApplicationId);
            this.CountParameters.Add("p_CreatedDate", ProfileLastUpdate);
            this.CountParameters.Add("p_RecordCount", SqlDbType.Int, ParameterDirection.Output);
            this.CountParameters.Add("p_IsCount", true);
            this.DataRowPosition.TotalRecords = this.GetRecordCount("p_RecordCount");         
            //---------------
            this.SelectParameters = null;
            this.SelectParameters.Add("p_ApplicationId", ClientSettings.ClientWorkStationInfo.ApplicationId);
            this.SelectParameters.Add("p_ClientId", ClientSettings.ClientWorkStationInfo.ClientId);
            this.SelectParameters.Add("p_CreatedDate", ProfileLastUpdate);
            this.GetDataSource();
            return this.List;
        }

        private List<Profile> GetUpdatedDataFromServer(DateTime ProfileLastUpdate)
        {
            //get total records
            this.CountParameters.Add("p_ClientId", ClientSettings.ClientWorkStationInfo.ClientId);
            this.CountParameters.Add("p_ApplicationId", ClientSettings.ClientWorkStationInfo.ApplicationId);
            this.CountParameters.Add("p_UpdatedDate", ProfileLastUpdate);
            this.CountParameters.Add("p_RecordCount", SqlDbType.Int, ParameterDirection.Output);
            this.CountParameters.Add("p_IsCount", true);
            this.DataRowPosition.TotalRecords = this.GetRecordCount("p_RecordCount");
            ////---------------

            this.SelectParameters = null;
            this.SelectParameters.Add("p_ApplicationId", ClientSettings.ClientWorkStationInfo.ApplicationId);
            this.SelectParameters.Add("p_ClientId", ClientSettings.ClientWorkStationInfo.ClientId);
            this.SelectParameters.Add("p_UpdatedDate", ProfileLastUpdate);
            this.GetDataSource();
            return this.List;
        }

        private DateTime GetDbDate() {
            try
            {
                DateTime _resultDate = DateTime.Now;
                SqlCommand _cmd = new SqlCommand("dbo.SelectDBDate", this.DBConn);
                _cmd.CommandType = CommandType.StoredProcedure;
                this.DBConn.Open();
                SqlDataReader _dr = _cmd.ExecuteReader(CommandBehavior.CloseConnection);
                _dr.Read();
                _resultDate = (DateTime)_dr[0];
                this.DBConn.Close();
                return _resultDate;
            }
            catch (Exception e) { throw e; }
        }

        public void Test() {

            Console.Write("test");
        }
        public void FingerTemplatesUpdate()
        {
            try
            {
               //if (Util.IsOnline==false )return;
                ConsoleApp.WriteLine(Application.ProductName, "Start uploading data to server.");

                DateTime _ProfileLastUpdate;
                _dcProfile_OleDb = new dcProfile_OleDb();
                _dcProfile_OleDb.DBConn.Open();
                OleDbCommand _cmd2 = new OleDbCommand("select * from updatelog", _dcProfile_OleDb.DBConn);
                OleDbDataReader _dr2 = _cmd2.ExecuteReader(CommandBehavior.CloseConnection);

                Trans = _dcProfile_OleDb.DBConn.BeginTransaction();
                if (_dr2.HasRows == false)
                {
                    this.SelectParameters.Add("p_ClientId", ClientSettings.ClientWorkStationInfo.ClientId);
                    this.SelectParameters.Add("p_ApplicationId", ClientSettings.ClientWorkStationInfo.ApplicationId);

                    this.CountParameters.Add("p_ClientId", ClientSettings.ClientWorkStationInfo.ClientId);
                    this.CountParameters.Add("p_ApplicationId", ClientSettings.ClientWorkStationInfo.ApplicationId);
                    this.CountParameters.Add("p_RecordCount", SqlDbType.Int, ParameterDirection.Output);
                    this.CountParameters.Add("p_IsCount", true);
                    this.DataRowPosition.TotalRecords = this.GetRecordCount("p_RecordCount");                    
                    
                    this.GetDataSource();
                    ConsoleApp.WriteLine(Application.ProductName, "Get new records from the live server");
                    this.InsertNewDataLocalDB(this.List);
                   UpdateLastUpdate(); 

                    
                }
                else {
                    _dr2.Read();
                    _ProfileLastUpdate = Convert.ToDateTime(_dr2["ProfileLastUpdate"]);

                    ConsoleApp.WriteLine(Application.ProductName, "Get newest created and updated records from the live server");
                    List<Profile> _NewList = this.GetNewDataFromServer(_ProfileLastUpdate);
                    List<Profile> _UpdatedList = this.GetUpdatedDataFromServer(_ProfileLastUpdate);

                    this.InsertNewDataLocalDB(_NewList);
                    this.UpdateLocalDB(_UpdatedList);

                    if (_NewList.Count > 0 || _UpdatedList.Count > 0)
                    {
                        UpdateLastUpdate();
                    }

                }
                Trans.Commit();
                _dcProfile_OleDb.DBConn.Close();
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

        private void InsertNewDataLocalDB(List<Profile> list)
        {
            string errorProfileInfo = string.Empty;
            try
            {
                foreach (Profile item in list)
                {

                        errorProfileInfo = "";
                        errorProfileInfo = "ProfileId:" + item.ProfileId; 
                        OleDbCommand _cmd2 = new OleDbCommand(
                        "Insert into Profiles(ProfileId,FullName,LeftTF,LeftIF,LeftMF,LeftRF,LeftSF,RightTF,RightIF,RightMF,RightRF,RightSF,CreatedDate,UpdatedDate,ProfileImg,ClientEmployeeId,EmployeeNo,ShiftId,UserId,IsZSIAdmin,PositionDesc,DepartmentDesc,SectionDesc,RankDesc) "
                        + "Values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                        , _dcProfile_OleDb.DBConn, Trans);

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
                        SetParameterValue(_params, item.FrontImg, OleDbType.VarBinary);                        
                        SetParameterValue(_params, item.ClientEmployeeId, OleDbType.Integer);
                        SetParameterValue(_params, item.EmployeeNo, OleDbType.VarChar);
                        SetParameterValue(_params, item.ShiftId, OleDbType.Integer);
                        SetParameterValue(_params, item.UserId, OleDbType.Integer);
                        SetParameterValue(_params, item.IsZSIAdmin, OleDbType.Boolean);
                        SetParameterValue(_params, item.PositionDesc, OleDbType.VarChar);
                        SetParameterValue(_params, item.DepartmentDesc, OleDbType.VarChar);
                        SetParameterValue(_params, item.SectionDesc, OleDbType.VarChar);
                        SetParameterValue(_params, item.RankDesc, OleDbType.VarChar);

                        _cmd2.ExecuteNonQuery();
              }           
            }
            catch (Exception ex)
            {
                string errorMsg = "[Error]," + ex.ToString() + "\n" + errorProfileInfo;
                ConsoleApp.WriteLine(Application.ProductName, errorMsg);
                zsi.PhotoFingCapture.Util.LogError(errorMsg);
                //throw ex;
            }

        }

        private void UpdateLocalDB(List<Profile> list)
        {
            try
            {
                foreach (Profile item in list)
                {
                    OleDbCommand _cmd2 = new OleDbCommand(
                    "Update Profiles set LeftTF=?,LeftIF=?,LeftMF=?,LeftRF=?,LeftSF=?,RightTF=?,RightIF=?,RightMF=?,RightRF=?,RightSF=?,UpdatedDate=?,ProfileImg=?,ClientEmployeeId=?,EmployeeNo=?,ShiftId=?,UserId=?,IsZSIAdmin=?,PositionDesc=?,DepartmentDesc=?,SectionDesc=?,RankDesc=?"
                   + " where profileId='" + item.ProfileId + "'"
                    , _dcProfile_OleDb.DBConn, Trans);
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
                    SetParameterValue(_params, item.FrontImg, OleDbType.VarBinary);
                    SetParameterValue(_params, item.ClientEmployeeId, OleDbType.Integer);
                    SetParameterValue(_params, item.EmployeeNo, OleDbType.VarChar);
                    SetParameterValue(_params, item.ShiftId, OleDbType.Integer);
                    SetParameterValue(_params, item.UserId, OleDbType.Integer);
                    SetParameterValue(_params, item.IsZSIAdmin, OleDbType.Boolean);
                    SetParameterValue(_params, item.PositionDesc, OleDbType.VarChar);
                    SetParameterValue(_params, item.DepartmentDesc, OleDbType.VarChar);
                    SetParameterValue(_params, item.SectionDesc, OleDbType.VarChar);
                    SetParameterValue(_params, item.RankDesc, OleDbType.VarChar);                    
                    _cmd2.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void UpdateLastUpdate(){

            dcProfile_OleDb _dc = new dcProfile_OleDb();
            OleDbCommand _cmd = new OleDbCommand("select * from updatelog", _dc.DBConn);
            _dc.DBConn.Open();
            OleDbDataReader _dr = _cmd.ExecuteReader();
            if (!_dr.HasRows)
            {
                _cmd = new OleDbCommand(
                "Insert Into UpdateLog(ProfileLastUpdate) values(?)", _dcProfile_OleDb.DBConn, Trans);
                _cmd.Parameters.AddWithValue("?", GetDbDate().ToString());
                _cmd.ExecuteNonQuery();
            }
            else {
                _cmd = new OleDbCommand(
                "Update UpdateLog set ProfileLastUpdate=?", _dcProfile_OleDb.DBConn, Trans);
                _cmd.Parameters.AddWithValue("?", GetDbDate().ToString());
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


        public static Profile VerifyBiometricsData(byte[] data)
        {
            try
            {
                string _result = string.Empty;
                string _Finger = string.Empty;
                Profile _info = new Profile();
                dcProfile_OleDb _dc = new dcProfile_OleDb();
                //DPFP.Template _template = null;
                Stream _msSample = new MemoryStream(data);
                DPFP.Sample _sample = new DPFP.Sample();
                //deserialize
                _sample.DeSerialize(_msSample);
                OleDbCommand _cmd = new OleDbCommand("select * from Profiles", _dc.DBConn);
                _dc.DBConn.Open();
                OleDbDataReader _dr = _cmd.ExecuteReader();
                bool IsFound = false;
                if (_dr.HasRows)
                {
                    while (_dr.Read())
                    {
                        if (_dr[2] != DBNull.Value)
                        {
                            IsFound = Verify(_dr, _sample);
                        }
                        if (IsFound == true)
                        {
                            _info.ProfileId = Convert.ToInt64(_dr["ProfileId"]);
                            _info.FullName = Convert.ToString(_dr["FullName"]);
                            _info.FrontImg = (byte[])_dr["ProfileImg"];
                            if (_info.FrontImg == null) _info.FrontImg = Util.ImageToByte(zsi.PhotoFingCapture.Util.GetNoPhoto()); 
                             _info.ClientEmployeeId = Convert.ToInt32(_dr["ClientEmployeeId"]);
                              if(_dr["EmployeeNo"]!=DBNull.Value) _info.EmployeeNo = _dr["EmployeeNo"].ToString();
                              _info.ShiftId = Convert.ToInt32(_dr["ShiftId"]);
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


        public static Profile VerifyBiometricsData(int FingNo, byte[] data)
        {
            try
            {
                string _result = string.Empty;
                string _Finger = string.Empty;
                Profile _info = new Profile();
                dcProfile_OleDb _dc = new dcProfile_OleDb();
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
                OleDbCommand _cmd = new OleDbCommand("select * from Profiles", _dc.DBConn);
                _dc.DBConn.Open();
                OleDbDataReader _dr = _cmd.ExecuteReader();
                bool IsFound =false;
                if (_dr.HasRows)
                {
                    while (_dr.Read())
                    {
                        if (_dr[2] != DBNull.Value)
                        {
                            _template = ProcessDBTemplate((byte[])_dr[_Finger]);
                            IsFound = Verify(_sample, _template);
                        }
                        if (IsFound == true)
                        {
                            _info.ProfileId = Convert.ToInt64(_dr["ProfileId"]);
                            _info.FullName = Convert.ToString(_dr["FullName"]);
                            _info.FrontImg = (byte[])_dr["ProfileImg"];
                            _info.ClientEmployeeId = Convert.ToInt32(_dr["ClientEmployeeId"]);
                            _info.EmployeeNo = Convert.ToString(_dr["EmployeeNo"]);
                            _info.ShiftId = Convert.ToInt32(_dr["ShiftId"]);
                            _info.UserId = (_dr["UserId"] == DBNull.Value ? 0 : Convert.ToInt32(_dr["UserId"]));

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
        
 
        private static bool Verify(OleDbDataReader dr, DPFP.Sample sample)
        {
            try
            {
                DPFP.Template _template=null;

                //right fingers
                if (dr["RightTF"] != DBNull.Value)
                {
                    _template = ProcessDBTemplate((byte[])dr["RightTF"]);
                    if (Verify(sample, _template)) goto Found;
                }
                if (dr["RightIF"] != DBNull.Value)
                {
                    _template = ProcessDBTemplate((byte[])dr["RightIF"]);
                    if (Verify(sample, _template)) goto Found;
                }
                if (dr["RightMF"] != DBNull.Value)
                {
                    _template = ProcessDBTemplate((byte[])dr["RightMF"]);
                    if (Verify(sample, _template)) goto Found;
                }

                if (dr["RightRF"] != DBNull.Value)
                {
                    _template = ProcessDBTemplate((byte[])dr["RightRF"]);
                    if (Verify(sample, _template)) goto Found;
                }
                if (dr["RightSF"] != DBNull.Value)
                {
                    _template = ProcessDBTemplate((byte[])dr["RightSF"]);
                    if (Verify(sample, _template)) goto Found;
                }

                
                //left fingers
                if (dr["LeftTF"] != DBNull.Value)
                {
                    _template = ProcessDBTemplate((byte[])dr["LeftTF"]);
                    if (Verify(sample, _template)) goto Found;
                }
                if (dr["LeftIF"] != DBNull.Value)
                {
                    _template = ProcessDBTemplate((byte[])dr["LeftIF"]);
                    if (Verify(sample, _template)) goto Found;
                }
                if (dr["LeftMF"] != DBNull.Value)
                {
                    _template = ProcessDBTemplate((byte[])dr["LeftMF"]);
                    if (Verify(sample, _template)) goto Found;
                }
                if (dr["LeftRF"] != DBNull.Value)
                {
                    _template = ProcessDBTemplate((byte[])dr["LeftRF"]);
                    if (Verify(sample, _template)) goto Found;
                }
                if (dr["LeftSF"] != DBNull.Value) 
                {
                    _template = ProcessDBTemplate((byte[])dr["LeftSF"]);
                    if(Verify(sample, _template)) goto Found;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        Found: 
            return true;

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

        /*
        public byte[] GetFrontImageByProfileId(Int64 p_ProfileId)
        {
            Profile p = new Profile();
            SQLServer.Procedure _proc = new SQLServer.Procedure("dbo.SelectProfileImage");
            this.SelectInfoParameters.Add("p_ProfileId", p_ProfileId);
            p = this.GetInfo(_proc);
            return p.FrontImg;
        }
        */

    }
}
