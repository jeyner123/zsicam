using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zsi.Framework.Data;
using System.Data;
using System.Data.SqlClient;
using zsi.dtrs.Models;
using System.IO;
using System.Configuration;
using Oracle.DataAccess.Client;
namespace zsi.dtrs.Models.DataControllers
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


        public void Insert(EmployeeTSI info)
        {
            OracleConnection conn = new OracleConnection(ConStr);

            try
            {
                /*
                string sql = "Insert into EmpTSI(Empl_Id_No,IMG,RTF,RIF,RMF,RRF,RSF,LTF,LIF,LMF,LRF,LSF,Date_Created,Date_Modified) "
                + "Values(:Empl_Id_No,:IMG,:RTF,:RIF,:RMF,:RRF,:RSF,:LTF,:LIF,:LMF,:LRF,:LSF,:Date_Created,:Date_Modified)";
                */
                string sql = "Insert into EmpTSI(Empl_Id_No,RTF) Values(:Empl_Id_No,:RTF)";

                OracleCommand command = new OracleCommand(sql, conn);

                var _params = command.Parameters;
                conn.Open();


                SetParameterValue(_params, "Empl_Id_No", info.Empl_Id_No, OracleDbType.Int32);

                //SetParameterValue(_params, info.IMG, OracleDbType.Blob);
                SetParameterValue(_params, "RTF", info.RTF, OracleDbType.Blob);
                /*
                SetParameterValue(_params,"RIF", info.RIF, OracleDbType.Blob);
                SetParameterValue(_params,"RMF", info.RMF, OracleDbType.Blob);
                SetParameterValue(_params,"RRF", info.RRF, OracleDbType.Blob);
                SetParameterValue(_params,"RSF", info.RSF, OracleDbType.Blob);
                SetParameterValue(_params,"LTF", info.LTF, OracleDbType.Blob);
                SetParameterValue(_params,"LIF", info.LIF, OracleDbType.Blob);
                SetParameterValue(_params,"LMF", info.LMF, OracleDbType.Blob);
                SetParameterValue(_params,"LRF", info.LRF, OracleDbType.Blob);
                SetParameterValue(_params,"LSF", info.LSF, OracleDbType.Blob);
                SetParameterValue(_params,"Date_Created", info.Date_Created, OracleDbType.Date);
                SetParameterValue(_params,"Date_Modified", info.Date_Modified, OracleDbType.Date);
                 */

                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void SetParameterValue(OracleParameterCollection Params,string ColumnName, object value, OracleDbType type)
        {
            if (value != null)
            {
                Params.Add(":" + ColumnName, type).Value = value;
            }
            else
            {
                Params.Add(":" + ColumnName, DBNull.Value);
            }

        }



    }
 
}


 