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
    public class dcEmployee:DataController
    {
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
        public static Employee VerifyBiometricsData(int FingNo, DPFP.Sample Sample)
        {
            OracleConnection conn = new OracleConnection(ConStr);
            Employee _info = new Employee();
            try
            {


                string _result = string.Empty;
                string _Finger = Util.GetFingerDesc(FingNo);
                DPFP.Template _template = null;
                string sql = string.Format("select Empl_Id_No, {0} from EMPTSI", _Finger); ;
                OracleCommand command = new OracleCommand(sql, conn);
                command.CommandType = CommandType.Text;
                conn.Open();
                OracleDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                bool IsFound = false;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader[0] != DBNull.Value)
                        {
                            _template = Util.ProcessDBTemplate((byte[])reader[_Finger]);
                            IsFound = Util.Verify(Sample, _template);
                        }
                        if (IsFound == true)
                        {
                            string sqlEmp = "select * from employees where Empl_Id_No=" + reader["Empl_Id_No"];
                            OracleCommand cmd2 = new OracleCommand(sqlEmp, conn);
                            cmd2.CommandType = CommandType.Text;
                            OracleDataReader reader2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
                            if (reader2.HasRows)
                            {
                                _info.Empl_Id_No = Convert.ToInt32(reader["Empl_Id_No"]);
                                _info.Empl_Name = (string)reader2["Empl_Name"];
                                _info.Empl_Deptname = (string)reader2["Empl_Deptname"];
                                _info.Shift_Id = Convert.ToInt32(reader2["Shift_Id"]);
                            }
                            reader2.Dispose();
                            reader.Dispose();
                            cmd2.Dispose();
                            command.Dispose();
                            break;
                        }
                    }
                }
                if (conn.State == ConnectionState.Open) conn.Close();
                return _info;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static Employee GetInfo(OracleDataReader reader, DPFP.Sample Sample, string Finger)
        {

            OracleConnection conn = new OracleConnection(ConStr);
            Employee _info = null;
            DPFP.Template _template = null;
            bool IsFound = false;
            if (reader[Finger] != DBNull.Value)
            {
                _template = Util.ProcessDBTemplate((byte[])reader[Finger]);
                IsFound = Util.Verify(Sample, _template);
            }
            if (IsFound == true)
            {
                string sqlEmp = "select * from employees where Empl_Id_No=" + reader["Empl_Id_No"];
                OracleCommand cmd = new OracleCommand(sqlEmp, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                OracleDataReader odr = cmd.ExecuteReader();
                if (odr.HasRows)
                {
                    _info = new Employee();
                    _info.Empl_Id_No = Convert.ToInt32(reader["Empl_Id_No"]);
                    _info.Empl_Name = (string)odr["Empl_Name"];
                    _info.Empl_Deptname = (string)odr["Empl_Deptname"];
                    _info.Shift_Id = Convert.ToInt32(odr["Shift_Id"]);
                }
                odr.Dispose();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return _info;

        }
        private static bool Verify(OracleDataReader dr, DPFP.Sample sample)
        {
            try
            {
                DPFP.Template _template = null;

                //right fingers
                if (dr["RTF"] != DBNull.Value)
                {
                    _template = Util.ProcessDBTemplate((byte[])dr["RTF"]);
                    if (Util.Verify(sample, _template)) goto Found;
                }
                if (dr["RIF"] != DBNull.Value)
                {
                    _template = Util.ProcessDBTemplate((byte[])dr["RIF"]);
                    if (Util.Verify(sample, _template)) goto Found;
                }
                if (dr["RMF"] != DBNull.Value)
                {
                    _template = Util.ProcessDBTemplate((byte[])dr["RMF"]);
                    if (Util.Verify(sample, _template)) goto Found;
                }

                if (dr["RRF"] != DBNull.Value)
                {
                    _template = Util.ProcessDBTemplate((byte[])dr["RRF"]);
                    if (Util.Verify(sample, _template)) goto Found;
                }
                if (dr["RSF"] != DBNull.Value)
                {
                    _template = Util.ProcessDBTemplate((byte[])dr["RSF"]);
                    if (Util.Verify(sample, _template)) goto Found;
                }


                //left fingers
                if (dr["LTF"] != DBNull.Value)
                {
                    _template = Util.ProcessDBTemplate((byte[])dr["LTF"]);
                    if (Util.Verify(sample, _template)) goto Found;
                }
                if (dr["LIF"] != DBNull.Value)
                {
                    _template = Util.ProcessDBTemplate((byte[])dr["LIF"]);
                    if (Util.Verify(sample, _template)) goto Found;
                }
                if (dr["LMF"] != DBNull.Value)
                {
                    _template = Util.ProcessDBTemplate((byte[])dr["LMF"]);
                    if (Util.Verify(sample, _template)) goto Found;
                }
                if (dr["LRF"] != DBNull.Value)
                {
                    _template = Util.ProcessDBTemplate((byte[])dr["LRF"]);
                    if (Util.Verify(sample, _template)) goto Found;
                }
                if (dr["LSF"] != DBNull.Value)
                {
                    _template = Util.ProcessDBTemplate((byte[])dr["LSF"]);
                    if (Util.Verify(sample, _template)) goto Found;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        Found:
            return true;

        }
    }
}


 