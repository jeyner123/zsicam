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
        private dcFingersTemplate2 dcFTemplate{get;set;}
        private OleDbTransaction Trans { get; set; }
        public  _CallBackFunction CallBackFunction {get;set;}
        public delegate void _CallBackFunction();
       
        public void RunTest(){
            CallBackFunction();

        }
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

                OleDbCommand _cmd2 = new OleDbCommand(
                "Insert into TimeInOutLog(ProfileId,TimeValue)"
                + "Values(?,?)"
                , this.DBConn);
                this.OpenDB();
                var _params = _cmd2.Parameters;
                SetParameterValue(_params, info.ProfileId, OleDbType.VarChar);
                SetParameterValue(_params, TimeValue, OleDbType.Date);
                _cmd2.ExecuteNonQuery();
                this.CloseDB();

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
