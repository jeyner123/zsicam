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
        public string WSMacAddress { get; set; }
       
    }

}
