using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OleDb = zsi.Framework.Data.DataProvider.OleDb;
using SQLServer = zsi.Framework.Data.DataProvider.SQLServer;
using zsi.Framework.Data;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using zsi.Framework.Common;
namespace zsi.PhotoFingCapture.Models.DataControllers
{

    public class dcTimeInOutLog_SQL : SQLServer.MasterDataController<TimeInOutLog>
    {
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");

            this.DBConn = new SqlConnection(_ConnectionString);
            this.Procedures.Add(new SQLServer.Procedure("dbo.SelectTimeInOutLogs", SQLCommandType.Select));
            this.Procedures.Add(new SQLServer.Procedure("dbo.UpdateTimeInOutLog", SQLCommandType.Update));
        }


    }

    public class dcTimeInOutLog_OleDb : OleDb.MasterDataController<TimeInOutLog>
    {
        private OleDbTransaction Trans { get; set; }
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.AccessDBConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            this.DBConn = new OleDbConnection(_ConnectionString);
        }


    
        public void TimeInOut(Profile info, DateTime TimeValue,out DateTime TimeIn,out DateTime TimeOut )
        {
            try
            {
                string dtrDate = DateTime.Now.ToShortDateString();
                TimeOut = new DateTime(1, 1, 1);
                string sql = "Select top 1 * from TimeInOutLog where ClientEmployeeId=" + info.ClientEmployeeId + " and DTRDate=#" + dtrDate + "# ORDER BY LogInOutId desc";               
                List<TimeInOutLog> list =    this.GetDataSource(sql);

                if (list.Count==0)
                {
                    InsertTimeIn(info, TimeValue, dtrDate, out TimeOut, out TimeIn);
                    goto Finish;
                } 
                if (list[0].TimeOut != new DateTime(1, 1, 1))
                {
                    InsertTimeIn(info, TimeValue, dtrDate,out TimeOut, out TimeIn);                    
                }
                else
                {
                    //update
                    TimeIn = list[0].TimeIn;
                    TimeOut = TimeValue;
                    TimeSpan ts = TimeOut - TimeIn;
                    //MessageBox.Show(ts.Minutes + ":" + TimeIn.ToString() + "==" + TimeOut.ToString());
                    if (ts.Minutes < 1)
                    {
                        TimeOut = new DateTime(1, 1, 1);
                        return;
                    }

                    int LogInOutId = list[0].LogInOutId;
                    this.OpenDB();
                    OleDbCommand _cmd = new OleDbCommand("update TimeInOutLog set TimeOut=?,TimeOutWSId=?,UploadedDate=null where ProfileId='" + info.ProfileId + "' and DTRDate=#" + dtrDate + "# and LogInOutId=" + LogInOutId, this.DBConn);
                    var _params = _cmd.Parameters;
                    SetParameterValue(_params, TimeValue, OleDbType.Date);
                    SetParameterValue(_params, ClientSettings.ClientWorkStationInfo.WorkStationId, OleDbType.Integer);
                    _cmd.ExecuteNonQuery();
                    _cmd.Dispose();
                    this.CloseDB();
                    
                }
            }           
            catch (Exception ex)
            {
                throw ex;
            }
        Finish:;            
        }
        private void InsertTimeIn(Profile info, DateTime TimeValue, string DtrDate, out DateTime TimeOut, out DateTime TimeIn)
        {

            //INSERT
            this.OpenDB();
            string sql = "Select top 1 * from TimeInOutLog where ClientEmployeeId=" + info.ClientEmployeeId + " and DTRDate=#" + DtrDate + "# ORDER BY LogInOutId desc";
            List<TimeInOutLog> list = this.GetDataSource(sql);
            if (list.Count()==1) {
                TimeSpan ts = TimeValue - list[0].TimeOut;
                if (ts.Minutes < 1)
                {
                    TimeIn = list[0].TimeIn; ;
                    TimeOut = list[0].TimeOut;
                    return;
                }
            }
            TimeOut = new DateTime(1, 1, 1);
            TimeIn = TimeValue;

            this.OpenDB();
            //System.Windows.Forms.MessageBox.Show("insert");
            OleDbCommand _cmd = new OleDbCommand("Insert into TimeInOutLog(ProfileId,ClientId,WorkStationId,ClientEmployeeId,ShiftId,TimeIn,DTRDate,TimeInWSId) Values(?,?,?,?,?,?,?,?)", this.DBConn);
            var _params = _cmd.Parameters;
            SetParameterValue(_params, info.ProfileId, OleDbType.VarChar);
            SetParameterValue(_params, ClientSettings.ClientWorkStationInfo.ClientId, OleDbType.VarChar);
            SetParameterValue(_params, ClientSettings.ClientWorkStationInfo.WorkStationId, OleDbType.VarChar);
            SetParameterValue(_params, info.ClientEmployeeId, OleDbType.Integer);
            SetParameterValue(_params, info.ShiftId, OleDbType.Integer);
            SetParameterValue(_params, TimeValue, OleDbType.Date);
            SetParameterValue(_params, DtrDate, OleDbType.Date);
            SetParameterValue(_params, ClientSettings.ClientWorkStationInfo.WorkStationId, OleDbType.Integer);
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            this.CloseDB();
        }


        #region "Synchronize Update"
        
        private List<TimeInOutLog> GetNewDataFromServer(DateTime CreatedDate)
        {
            dcTimeInOutLog_SQL dc = new dcTimeInOutLog_SQL();
           // SQLServer.Procedure p = new SQLServer.Procedure("dbo.SelectTimeInOutLogs");
              dc.SelectParameters.Add("p_ClientId", ClientSettings.ClientWorkStationInfo.ClientId);
              dc.SelectParameters.Add("p_UploadedDate", CreatedDate);
            return dc.GetDataSource();
        }

        private List<TimeInOutLog> GetUpdatedDataFromServer(DateTime UpdatedDate)
        { 
            dcTimeInOutLog_SQL dc = new dcTimeInOutLog_SQL();
            dc.SelectParameters.Add("p_ClientId", ClientSettings.ClientWorkStationInfo.ClientId);
            dc.SelectParameters.Add("p_UpdatedDate", UpdatedDate);
            return dc.GetDataSource();
        }

        private void UploadDataToServer()
        {
            try
            {
                List<TimeInOutLog> list = new List<TimeInOutLog>();
                dcTimeInOutLog_OleDb _dcOLEDb = new dcTimeInOutLog_OleDb();
                list = _dcOLEDb.GetDataSource("Select * from TimeInOutLog where UploadedDate is null");

                foreach (TimeInOutLog info in list)
                {
                    string LogInfo = string.Empty;
                    try
                    {
                        LogInfo = "ProfileId:" + info.ProfileId + ";ClientEmployeeId:" + info.ClientEmployeeId;
                        dcTimeInOutLog_SQL _dcSQL = new dcTimeInOutLog_SQL();
                        _dcSQL.UpdateParameters.Add("p_ServerLogInOutId", info.ServerLogInOutId, SqlDbType.Int, ParameterDirection.InputOutput);
                        _dcSQL.UpdateParameters.Add("p_ClientId", info.ClientId);
                        _dcSQL.UpdateParameters.Add("p_ClientEmployeeId", info.ClientEmployeeId);
                        _dcSQL.UpdateParameters.Add("p_DTRDate", info.DTRDate, SqlDbType.Date);
                        _dcSQL.UpdateParameters.Add("p_ShiftId", info.ShiftId);
                        _dcSQL.UpdateParameters.Add("p_TimeIn", info.TimeIn, SqlDbType.DateTime);
                        if (info.TimeOut != new DateTime(1, 1, 1)) _dcSQL.UpdateParameters.Add("p_TimeOut", info.TimeOut, SqlDbType.DateTime);
                        _dcSQL.UpdateParameters.Add("p_WorkStationId", info.WorkStationId);
                        _dcSQL.UpdateParameters.Add("p_TimeInWSId", info.TimeInWSId);
                        _dcSQL.UpdateParameters.Add("p_TimeOutWSId", info.TimeOutWSId);
                        _dcSQL.UpdateParameters.Add("p_LogInOutId", info.LogInOutId);
                        _dcSQL.Update();
                        //update local db
                        this.DBConn.Open();
                        string sql = "Update TimeInOutLog set UploadedDate=#" + DateTime.Now + "#,ServerLogInOutId=" + _dcSQL.UpdateParameters.GetItem("p_ServerLogInOutId").Value.ToString()
                        + "  where UploadedDate is null"
                        + "  and LogInOutId=" + info.LogInOutId
                        + "  and ClientEmployeeId=" + info.ClientEmployeeId
                        + "  and WorkStationId=" + info.WorkStationId;
                        OleDbCommand _cmd = new OleDbCommand(sql, this.DBConn);
                        _cmd.ExecuteNonQuery();
                        this.DBConn.Close();
                        _dcSQL = null;
                    } 
                    catch (Exception ex)
                    {
                        string ErrorMsg = "(loginfo:" + LogInfo + ")" + ex.ToString();
                        ConsoleApp.WriteLine(Application.ProductName, "[Error]," + ErrorMsg);
                        zsi.PhotoFingCapture.Util.LogError(ErrorMsg);
                    }

                }
            }
            catch (Exception ex) {
                throw ex;
            }


        }

        public void TimeInOutSync()
        {
            try
            {
                UploadDataToServer();
            }
            catch (Exception ex)
            {                 
                ConsoleApp.WriteLine(Application.ProductName, "[Error]," + ex.ToString());
                zsi.PhotoFingCapture.Util.LogError(ex.ToString());
            }
        }

        private void DownloadNewData(List<TimeInOutLog> list)
        {
            try
            {

                foreach (TimeInOutLog item in list)
                {
                    OleDbCommand _cmd2 = new OleDbCommand(
                    "Insert into TimeInOutLog(LogInOutId,ClientId,ProfileId,ClientEmployeeId,DTRDate,TimeIn,TimeOut,LogTypeId,LogRemarks,UpdatedBy,UpdatedDate) "
                    + "Values(?,?,?,?,?,?,?,?,?,?,?)"
                    , this.DBConn, Trans);

                    var _params = _cmd2.Parameters;
                    SetParameterValue(_params, item.LogInOutId, OleDbType.Integer);
                    SetParameterValue(_params, item.ClientId, OleDbType.Integer);
                    SetParameterValue(_params, item.ProfileId, OleDbType.VarChar);
                    SetParameterValue(_params, item.ClientEmployeeId, OleDbType.Integer);
                    SetParameterValue(_params, item.DTRDate, OleDbType.Date);
                    SetParameterValue(_params, item.TimeIn, OleDbType.Date);
                    SetParameterValue(_params, item.TimeOut, OleDbType.Date);
                    SetParameterValue(_params, item.LogTypeId, OleDbType.Integer);
                    SetParameterValue(_params, item.LogRemarks, OleDbType.VarChar);
                    SetParameterValue(_params, item.UpdatedBy, OleDbType.Integer);
                    SetParameterValue(_params, item.UpdatedDate, OleDbType.Date);
                    _cmd2.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void DownloadUpdatedData(List<TimeInOutLog> list)
        {
            try
            {
                foreach (TimeInOutLog item in list)
                {
                    OleDbCommand _cmd2 = new OleDbCommand(
                    "Update TimeInOutLog set DTRDate=?,TimeIn=?,TimeOut=?,LogTypeId=?,LogRemarks=?,UpdatedBy=?,UpdatedDate=?"
                   + " where LogInOutId='" + item.LogInOutId + "'"
                    , this.DBConn, Trans);
                    var _params = _cmd2.Parameters;
                    SetParameterValue(_params, item.DTRDate, OleDbType.Date);
                    SetParameterValue(_params, item.TimeIn, OleDbType.Date);
                    SetParameterValue(_params, item.TimeOut, OleDbType.Date);
                    SetParameterValue(_params, item.LogTypeId, OleDbType.Integer);
                    SetParameterValue(_params, item.LogRemarks, OleDbType.VarChar);
                    SetParameterValue(_params, item.UpdatedBy, OleDbType.Integer);
                    SetParameterValue(_params, item.UpdatedDate, OleDbType.Date);

                    _cmd2.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void UpdateLastUpdate()
        {

          
            OleDbCommand _cmd = new OleDbCommand("select * from updatelog", this.DBConn);
            this.DBConn.Open();
            OleDbDataReader _dr = _cmd.ExecuteReader();
            if (!_dr.HasRows)
            {
                _cmd = new OleDbCommand(
                "Insert Into UpdateLog(TimeInOutLastUpdate) values(?)", this.DBConn, Trans);
                _cmd.Parameters.AddWithValue("?", GetDbDate().ToString());
                _cmd.ExecuteNonQuery();
            }
            else
            {
                _cmd = new OleDbCommand(
                "Update UpdateLog set TimeInOutLastUpdate=?", this.DBConn, Trans);
                _cmd.Parameters.AddWithValue("?", GetDbDate().ToString());
                _cmd.ExecuteNonQuery();
            }
            this.DBConn.Close();
        }



        private DateTime GetDbDate()
        {
            try
            {   dcClientWorkStation2  dc = new dcClientWorkStation2();
                DateTime _resultDate = DateTime.Now;
                System.Data.SqlClient.SqlCommand _cmd = new System.Data.SqlClient.SqlCommand("dbo.SelectDBDate", dc.DBConn);
                _cmd.CommandType = CommandType.StoredProcedure;
                dc.DBConn.Open();
                SqlDataReader _dr = _cmd.ExecuteReader(CommandBehavior.CloseConnection);
                _dr.Read();
                _resultDate = (DateTime)_dr[0];
                dc.DBConn.Close();
                return _resultDate;
            }
            catch (Exception e) { throw e; }
        }

        #endregion


 

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
