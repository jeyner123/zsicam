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
     
    public class dcTimeInOutLog : MasterDataController<TimeInOutLog>
    {
 
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
                string sql = "Select top 1 * from TimeInOutLog where ProfileId='" + info.ProfileId + "' and DTRDate=#" + dtrDate + "# ORDER BY LogInOutId desc";               
                List<TimeInOutLog> list =    this.GetDataSource(sql);

                if (list.Count==0)
                {
                    TimeIn = TimeValue;
                    InsertTimeIn(info, TimeValue, dtrDate);
                    goto Finish;
                } 
                if (list[0].TimeOut != new DateTime(1, 1, 1))
                {
                    TimeIn = TimeValue;
                    InsertTimeIn(info,TimeValue,dtrDate);                    
                }
                else
                {
                    //update
                    TimeIn = list[0].TimeIn;
                    TimeOut = TimeValue;
                    int LogInOutId = list[0].LogInOutId;
                    this.OpenDB();
                    OleDbCommand _cmd = new OleDbCommand("update TimeInOutLog set TimeOut=? where ProfileId='" + info.ProfileId + "' and DTRDate=#" + dtrDate + "# and LogInOutId=" + LogInOutId , this.DBConn);
                    var _params = _cmd.Parameters;
                    SetParameterValue(_params, TimeValue, OleDbType.Date);
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
        private void InsertTimeIn(Profile info,DateTime TimeValue, string DtrDate)
        {

            //INSERT
            this.OpenDB();
            //System.Windows.Forms.MessageBox.Show("insert");
            OleDbCommand _cmd = new OleDbCommand("Insert into TimeInOutLog(ProfileId,ClientId,TimeIn,DTRDate) Values(?,?,?,?)", this.DBConn);
            var _params = _cmd.Parameters;
            SetParameterValue(_params, info.ProfileId, OleDbType.VarChar);
            SetParameterValue(_params, ClientSettings.ClientWorkStationInfo.ClientId, OleDbType.VarChar);
            SetParameterValue(_params, TimeValue, OleDbType.Date);
            SetParameterValue(_params, DtrDate, OleDbType.Date);
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            this.CloseDB();
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
