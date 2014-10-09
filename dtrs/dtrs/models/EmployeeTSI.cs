using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Text;

namespace zsi.dtrs.Models
{
        public class EmployeeTSI
        {
            public EmployeeTSI(){}

            public EmployeeTSI(OracleDataReader reader)
            {
                this.DataReader = reader;
            }

            public int Empl_Id_No { get; set; }
            public byte[] IMG { get; set; }
            public byte[] RTF { get; set; }
            public byte[] RIF { get; set; }
            public byte[] RMF { get; set; }
            public byte[] RRF { get; set; }
            public byte[] RSF { get; set; }
            public byte[] LTF { get; set; }
            public byte[] LIF { get; set; }
            public byte[] LMF { get; set; }
            public byte[] LRF { get; set; }
            public byte[] LSF { get; set; }
            public string TSI { get; set; }
            public string UserId { get; set; }
            public string Created_By { get; set; }
            public string Modified_By { get; set; }
            public DateTime Date_Modified { get; set; }
            public DateTime Date_Created { get; set; }

             public OracleDataReader DataReader
             {
                 set
                 {
                     OracleDataReader reader = value;
                     if (reader["Empl_Id_No"] != DBNull.Value)
                     {
                         this.Empl_Id_No = Convert.ToInt32(reader["Empl_Id_No"]);
                     }
                     if (reader["IMG"] != DBNull.Value)
                     {
                         this.IMG = (byte[])reader["IMG"];
                     }

                     if (reader["RTF"] != DBNull.Value)
                     {
                         this.RTF = (byte[])reader["RTF"];
                     }

                     if (reader["RIF"] != DBNull.Value)
                     {
                         this.RIF = (byte[])reader["RIF"];
                     }

                     if (reader["RMF"] != DBNull.Value)
                     {
                         this.RMF = (byte[])reader["RMF"];
                     }

                     if (reader["RRF"] != DBNull.Value)
                     {
                         this.RRF = (byte[])reader["RRF"];
                     }

                     if (reader["RSF"] != DBNull.Value)
                     {
                         this.RSF = (byte[])reader["RSF"];
                     }


                     if (reader["LTF"] != DBNull.Value)
                     {
                         this.LTF = (byte[])reader["LTF"];
                     }

                     if (reader["LIF"] != DBNull.Value)
                     {
                         this.LIF = (byte[])reader["LIF"];
                     }

                     if (reader["LMF"] != DBNull.Value)
                     {
                         this.LMF = (byte[])reader["LMF"];
                     }

                     if (reader["LRF"] != DBNull.Value)
                     {
                         this.LRF = (byte[])reader["LRF"];
                     }

                     if (reader["LSF"] != DBNull.Value)
                     {
                         this.LSF = (byte[])reader["LSF"];
                     }

                     if (reader["TSI"] != DBNull.Value)
                     {
                         this.TSI = (string)reader["TSI"];
                     }

                     if (reader["Created_By"] != DBNull.Value)
                     {
                         this.Created_By = (string)reader["Created_By"];
                     }

                     if (reader["Modified_By"] != DBNull.Value)
                     {
                         this.Modified_By = (string)reader["Modified_By"];
                     }

                     if (reader["Date_Modified"] != DBNull.Value)
                     {
                         this.Date_Modified = (DateTime)reader["Date_Modified"];
                     }
                     if (reader["Date_Created"] != DBNull.Value)
                     {
                         this.Date_Created = (DateTime)reader["Date_Created"];
                     }   
                 }
             }

         
        }

}
 