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
        private dcFingersTemplate2 dcFTemplate {get;set;}
        private OleDbTransaction Trans { get; set; }
 
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.AccessDBConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            this.DBConn = new OleDbConnection(_ConnectionString);
        }

        public void TimeInOut(Profile info, DateTime TimeValue)
        {
            try
            {

              string sql = "Select top 1 * from TimeInOutLog where ProfileId=" + info.ProfileId + " DTRDate=" + DateTime.Now.ToShortDateString();  
              List<TimeInOutLog> list =    this.GetDataSource(sql);
              if (list[0].TimeIn == null ||  list[0].TimeOut!=null )
              {
                    //INSERT
                  this.OpenDB();
                  OleDbCommand _cmd = new OleDbCommand(
                     "Insert into TimeInOutLog(ProfileId,TimeIn)"
                     + "Values(?,?)"
                     , dcFTemplate.DBConn);

                  var _params = _cmd.Parameters;
                  SetParameterValue(_params, info.ProfileId, OleDbType.VarChar);
                  SetParameterValue(_params, TimeValue, OleDbType.Date);
                  _cmd.ExecuteNonQuery();
                  this.CloseDB();

              }
              else { 
                    //update
                  this.OpenDB();
                  OleDbCommand _cmd = new OleDbCommand("update TimeInOutLog set TimeOut=? where ProfileId=?", dcFTemplate.DBConn);
                  var _params = _cmd.Parameters;
                  SetParameterValue(_params, TimeValue, OleDbType.Date);
                  SetParameterValue(_params, info.ProfileId, OleDbType.VarChar);
                  _cmd.ExecuteNonQuery();
                  this.CloseDB();
              }


            }
            catch (Exception ex)
            {
                throw ex;
            }





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
