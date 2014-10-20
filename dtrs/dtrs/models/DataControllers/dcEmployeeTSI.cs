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
using zsi.Biometrics;
namespace zsi.dtrs.Models.DataControllers
{
    public class dcEmployeeTSI :DataController
    {
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
        public int Insert(EmployeeTSI info)
        {
            OracleConnection conn = new OracleConnection(ConStr);

            try
            {
                int EmpId=0;
                OracleCommand command = new OracleCommand("EmpTSI_update", conn);
                 command.CommandType = CommandType.StoredProcedure;
                var _params = command.Parameters;
                conn.Open();         
                SetParameterValue(_params, "p_empl_id_no", info.Empl_Id_No, OracleDbType.Int32);
                SetParameterValue(_params, "p_tsi", info.TSI, OracleDbType.Varchar2);
                SetParameterValue(_params, "p_user_id", this.UserId, OracleDbType.Varchar2);
                SetParameterValue(_params, "p_img", info.IMG, OracleDbType.Blob);
                SetParameterValue(_params, "p_rtf", info.RTF, OracleDbType.Blob);
                SetParameterValue(_params, "p_rif", info.RIF, OracleDbType.Blob);                
                SetParameterValue(_params, "p_rmf", info.RMF, OracleDbType.Blob);
                SetParameterValue(_params, "p_rrf", info.RRF, OracleDbType.Blob);
                SetParameterValue(_params, "p_rsf", info.RSF, OracleDbType.Blob);
                SetParameterValue(_params, "p_ltf", info.LTF, OracleDbType.Blob);
                SetParameterValue(_params, "p_lif", info.LIF, OracleDbType.Blob);
                SetParameterValue(_params, "p_lmf", info.LMF, OracleDbType.Blob);
                SetParameterValue(_params, "p_lrf", info.LRF, OracleDbType.Blob);
                SetParameterValue(_params, "p_lsf", info.LSF, OracleDbType.Blob);
                
                command.ExecuteNonQuery();
                conn.Close();
                return EmpId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateEmployeeMatches(int Empl_Id_No, FingersBiometrics fbInfo)
        {
            OracleConnection conn = new OracleConnection(ConStr);
            List<Employee> list = new List<Employee>();
            for (int FingerNo = 0; FingerNo < FingersBiometrics.MaxFingers; FingerNo++)
            {
                for (int x = 0; x < FingersBiometrics.MaxSamples; x++)
                {
                    if (fbInfo.Samples[FingerNo, x] != null)
                    {
                        GetEmployeeMatches(list, fbInfo.Samples[FingerNo, x], FingerNo);
                    }
                }

                foreach (Employee info in list)
                {

                    OracleCommand command = new OracleCommand("EmployeeMatches_update", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    var _params = command.Parameters;
                    conn.Open();
                    SetParameterValue(_params, "p_empl_id_no", Empl_Id_No, OracleDbType.Int32);
                    SetParameterValue(_params, "p_match_id_no", info.Empl_Id_No, OracleDbType.Int32);
                    SetParameterValue(_params, Util.GetFingerDesc(FingerNo), "Y", OracleDbType.Varchar2);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }

 
             
        }      
        private static void AddInfo(List<Employee> list, Employee info) {
            if (info != null)
            {
                bool isFound=false;
                foreach(Employee i in list){
                    if (i.Empl_Id_No == info.Empl_Id_No)
                    {
                        isFound = true;
                        break;
                    }
                }
                if (isFound == false)
                {
                    list.Add(info);
                }
            }
        }
        public static void GetEmployeeMatches(List<Employee> list, DPFP.Sample Sample,int FingerNo)
        {
            OracleConnection conn = new OracleConnection(ConStr);
            Employee info = null;
            string FingerDesc = Util.GetFingerDesc(FingerNo);
            try
            {
                string _result = string.Empty;
                string sql = "select Empl_Id_No,RTF,RIF,RMF,RRF,RSF,LTF,LIF,LMF,LRF,LSF from EMPTSI";
                OracleCommand command = new OracleCommand(sql, conn);
                command.CommandType = CommandType.Text;
                conn.Open();
                OracleDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        info =  dcEmployee.GetInfo(reader, Sample, FingerDesc); 
                        AddInfo(list, info);
                    }
                }
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}


 