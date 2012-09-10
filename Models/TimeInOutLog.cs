using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class TimeInOutLog
    {
        #region "Constructor"
        public TimeInOutLog() { }
        #endregion
        public string ProfileId { get; set; }
        public string ClientId { get; set; }
        public string ClientEmployeeId { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public DateTime DTRDate { get; set; }
        public int LogTypeId{ get; set; }
        public string LogRemarks{ get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
        

    }

}
