using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zsi.Framework.Data;
using System.Data;
using System.Data.SqlClient;
using zsi.PhotoFingCapture.Models;
using System.IO;
using System.Configuration;
using Oracle.DataAccess.Client;
namespace zsi.PhotoFingCapture.Models.DataControllers
{


    public class dcEmployeeTSI
    {
        private string ConStr { get { return ConfigurationManager.AppSettings["Constr"].ToString(); } }
 

        public List<EmployeeTSI> SelectAll()
        {
	            try
	            {
                    string sql = "select * from employeesTSI"; 
                    OracleConnection conn = new OracleConnection(ConStr);
                    OracleCommand command = new OracleCommand(sql, conn);
                    command.CommandType = CommandType.Text;
                       conn.Open();
		               OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                       List<EmployeeTSI> _list = new List<EmployeeTSI>();
		              while (reader.Read())
		              {
                          _list.Add(new EmployeeTSI(reader));
		             }
		             reader.Close();
                     conn.Close();
		             return _list;
	         }
	        catch (Exception ex)
	         {
		             throw ex;
	         }
         }


        public bool Insert(EmployeeTSI info)
        {
            OracleConnection conn = new OracleConnection(ConStr);
            OracleCommand command = new OracleCommand("EmpTSI_Update", conn);

            try
            {
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@param1", info.field1);
                //RowsAffected = command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       




    }
 
}


 