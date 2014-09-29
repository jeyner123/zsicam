using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using System.Linq;
using System.Text;

namespace zsi.dtrs.Models
{
        public class Employee
        {
            public Employee(){}
          
            public Employee(OracleDataReader reader)
            {
                this.DataReader = reader;
            }


             public int Empl_Id_No { get; set; }   
             public string Empl_Name  { get; set; }   
             public string Empl_Deptname { get; set; }
             public int Shift_Id     { get; set; } 
             public string Created_By { get; set; }   
             public string Modified_By { get; set; }
             public DateTime Date_Created { get; set; }
             public DateTime Date_Modified { get; set; }

             public OracleDataReader DataReader
             {
                 set
                 {
                     OracleDataReader reader = value;
                     if (reader["Empl_Id_No"] != DBNull.Value)
                     {
                         this.Empl_Id_No = Convert.ToInt32(reader["Empl_Id_No"]);
                     }
                     if (reader["Empl_Name"] != DBNull.Value)
                     {
                         this.Empl_Name = (string)reader["Empl_Name"];
                     }

                     if (reader["Empl_Deptname"] != DBNull.Value)
                     {
                         this.Empl_Deptname = (string)reader["Empl_Deptname"];
                     }

                     if (reader["Shift_Id"] != DBNull.Value)
                     {
                         this.Shift_Id = Convert.ToInt32(reader["Shift_Id"]);
                     }

                     if (reader["Created_By"] != DBNull.Value)
                     {
                         this.Created_By = (string)reader["Created_By"];
                     }

                     if (reader["Modified_By"] != DBNull.Value)
                     {
                         this.Modified_By = (string)reader["Modified_By"];
                     }

                     if (reader["Date_Created"] != DBNull.Value)
                     {
                         this.Date_Created = (DateTime)reader["Date_Created"];
                     }
                     if (reader["Date_Modified"] != DBNull.Value)
                     {
                         this.Date_Modified = (DateTime)reader["Date_Modified"];
                     }


                 }
             }
        }

}
 