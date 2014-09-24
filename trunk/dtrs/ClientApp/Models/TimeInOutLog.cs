using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
namespace zsi.PhotoFingCapture.Models
{
    public class TimeInOutLog
    {
        #region "Constructor"
        public TimeInOutLog() { }
        public TimeInOutLog(OleDbDataReader reader) {
            this.DataReader = reader;
        }
        #endregion
        public int WorkStationId { get; set; }
        public int ServerLogInOutId { get; set; }
        public int LogInOutId { get; set; }
        public int ShiftId { get; set; }
        public int TimeInWSId { get; set; }
        public int TimeOutWSId { get; set; }
        public string ProfileId { get; set; }
        public int ClientId { get; set; }
        public Int64 ClientEmployeeId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public DateTime DTRDate { get; set; }
        public int LogTypeId{ get; set; }
        public string LogRemarks{ get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime UploadedDate { get; set; }
        public int UpdatedBy { get; set; }

        public OleDbDataReader DataReader
        {
            set
            {
                OleDbDataReader reader = value;
   
                if (reader["ClientId"] != DBNull.Value)
                {
                    this.ClientId = (int)reader["ClientId"];
                }
                if (reader["ClientEmployeeId"] != DBNull.Value)
                {
                    this.ClientEmployeeId = (Int64)reader["ClientEmployeeId"];
                }
                if (reader["DTRDate"] != DBNull.Value)
                {
                    this.DTRDate = (DateTime)reader["DTRDate"];
                }
                if (reader["TimeIn"] != DBNull.Value)
                {
                    this.TimeIn = (DateTime)reader["TimeIn"];
                }
                if (reader["TimeOut"] != DBNull.Value)
                {
                    this.TimeOut = (DateTime)reader["TimeOut"];
                }
                if (reader["LogTypeId"] != DBNull.Value)
                {
                    this.LogTypeId = (int)reader["LogTypeId"];
                }
                if (reader["LogRemarks"] != DBNull.Value)
                {
                    this.LogRemarks = (string)reader["LogRemarks"];
                }
                if (reader["UpdatedBy"] != DBNull.Value)
                {
                    this.UpdatedBy = (int)reader["UpdatedBy"];
                }
                if (reader["UpdatedDate"] != DBNull.Value)
                {
                    this.UpdatedDate = (DateTime)reader["UpdatedDate"];
                }
                if (reader["ProfileId"] != DBNull.Value)
                {
                    this.ProfileId = (string)reader["ProfileId"];
                }
            }
        }

    }

}
