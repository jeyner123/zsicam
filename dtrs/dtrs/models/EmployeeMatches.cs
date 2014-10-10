using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Text;

namespace zsi.dtrs.Models
{
        public class EmployeeMatches
        {
            public EmployeeMatches(){}

            public EmployeeMatches(OracleDataReader reader)
            {
                this.DataReader = reader;
            }

            public int Empl_Id_No { get; set; }
            public string RTF { get; set; }
            public string RIF { get; set; }
            public string RMF { get; set; }
            public string RRF { get; set; }
            public string RSF { get; set; }
            public string LTF { get; set; }
            public string LIF { get; set; }
            public string LMF { get; set; }
            public string LRF { get; set; }
            public string LSF { get; set; }

             public OracleDataReader DataReader
             {
                 set
                 {
                     OracleDataReader reader = value;
                     if (reader["Empl_Id_No"] != DBNull.Value)
                     {
                         this.Empl_Id_No = Convert.ToInt32(reader["Empl_Id_No"]);
                     }

                     if (reader["RTF"] != DBNull.Value)
                     {
                         this.RTF = (string)reader["RTF"];
                     }

                     if (reader["RIF"] != DBNull.Value)
                     {
                         this.RIF = (string)reader["RIF"];
                     }

                     if (reader["RMF"] != DBNull.Value)
                     {
                         this.RMF = (string)reader["RMF"];
                     }

                     if (reader["RRF"] != DBNull.Value)
                     {
                         this.RRF = (string)reader["RRF"];
                     }

                     if (reader["RSF"] != DBNull.Value)
                     {
                         this.RSF = (string)reader["RSF"];
                     }


                     if (reader["LTF"] != DBNull.Value)
                     {
                         this.LTF = (string)reader["LTF"];
                     }

                     if (reader["LIF"] != DBNull.Value)
                     {
                         this.LIF = (string)reader["LIF"];
                     }

                     if (reader["LMF"] != DBNull.Value)
                     {
                         this.LMF = (string)reader["LMF"];
                     }

                     if (reader["LRF"] != DBNull.Value)
                     {
                         this.LRF = (string)reader["LRF"];
                     }

                     if (reader["LSF"] != DBNull.Value)
                     {
                         this.LSF = (string)reader["LSF"];
                     }

                 }
             }

         
        }

}
 