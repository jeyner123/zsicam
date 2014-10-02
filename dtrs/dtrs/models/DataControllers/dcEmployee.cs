using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using zsi.dtrs.Models;
using System.IO;
using System.Configuration;
using Oracle.DataAccess.Client;
namespace zsi.dtrs.Models.DataControllers
{


    public class dcEmployee
    {
        private string ConStr { get { return ConfigurationManager.AppSettings["Constr"].ToString(); } }
 

        public List<Employee> SelectAll()
        {
	            try
	            {
                    string sql = "select * from employees"; 
                    OracleConnection conn = new OracleConnection(ConStr);
                    OracleCommand command = new OracleCommand(sql, conn);
                    command.CommandType = CommandType.Text;
                       conn.Open();
		               OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                       List<Employee> _list = new List<Employee>();
		              while (reader.Read())
		              {
                          _list.Add(new Employee(reader));
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

      
        public bool Insert(Employee info)
        {
            OracleConnection conn = new OracleConnection(ConStr);
            OracleCommand command = new OracleCommand("Employees_Update", conn);

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


 