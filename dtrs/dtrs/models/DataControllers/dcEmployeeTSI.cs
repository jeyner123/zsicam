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


    public class dcEmployeeTSI
    {
        private static string ConStr { get { return ConfigurationManager.AppSettings["Constr"].ToString(); } }
 

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
                
                string sql = "Insert into EmpTSI(Empl_Id_No,IMG,RTF,RIF,RMF,RRF,RSF,LTF,LIF,LMF,LRF,LSF,Date_Created,Date_Modified) "
                + "Values(:Empl_Id_No,:IMG,:RTF,:RIF,:RMF,:RRF,:RSF,:LTF,:LIF,:LMF,:LRF,:LSF,:Date_Created,:Date_Modified)";       
        
                OracleCommand command = new OracleCommand(sql, conn);
                var _params = command.Parameters;

                conn.Open();

                SetParameterValue(_params,"Empl_Id_No", info.Empl_Id_No, OracleDbType.Int32);
                SetParameterValue(_params,"IMG", info.IMG, OracleDbType.Blob);
                SetParameterValue(_params,"RTF", info.RTF, OracleDbType.Blob);                
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



   
        public static Employee VerifyBiometricsData(int FingNo, DPFP.Sample Sample)
        {
            OracleConnection conn = new OracleConnection(ConStr);
            Employee _info = new Employee();
            try
            {


                string _result = string.Empty;
                string _Finger = string.Empty;
                DPFP.Template _template = null;
                switch (FingNo)
                {
                    case 9: _Finger = "LSF"; break;
                    case 8: _Finger = "LRF"; break;
                    case 7: _Finger = "LMF"; break;
                    case 6: _Finger = "LIF"; break;
                    case 5: _Finger = "LTF"; break;
                    case 4: _Finger = "RSF"; break;
                    case 3: _Finger = "RRF"; break;
                    case 2: _Finger = "RMF"; break;
                    case 1: _Finger = "RIF"; break;
                    case 0: _Finger = "RTF"; break;
                    default: break;
                }

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
                            _template = ProcessDBTemplate((byte[])reader[_Finger]);
                            IsFound = Verify(Sample, _template);
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


        private static DPFP.Template ProcessDBTemplate(byte[] _data)
        {
            DPFP.Template _template = null;
            Stream _ms = new MemoryStream(_data);
            _template = new DPFP.Template();
            //deserialize
            _template.DeSerialize(_ms);
            return _template;
        }

        private static bool Verify(DPFP.Sample _sample, DPFP.Template _template)
        {
            try
            {
                bool _result = false;
                DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
                DPFP.FeatureSet features = zsi.dtrs.Util.ExtractFeatures(_sample, DPFP.Processing.DataPurpose.Verification);

                // Check quality of the sample and start verification if it's good
                // TODO: move to a separate task
                if (features != null)
                {
                    // Compare the feature set with our template
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, _template, ref result);

                    if (result.Verified)
                        _result = true;
                    else
                        _result = false;

                }
                return _result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
 
}


 