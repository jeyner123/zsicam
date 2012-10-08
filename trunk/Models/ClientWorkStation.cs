using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace zsi.PhotoFingCapture.Models
{
    public class ClientWorkStation:Client
    {
       
        #region "Constructor"
        public ClientWorkStation() { }

        #endregion
        public int WorkStationId { get; set; }
        public string WSMacAddress { get; set; }
        public int ApplicationId { get; set; }
        public bool IsServer { get; set; }

    }

}
