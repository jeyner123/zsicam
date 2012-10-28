using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OleDb = zsi.Framework.Data.DataProvider.OleDb;
using SQLServer = zsi.Framework.Data.DataProvider.SQLServer;
using zsi.Framework.Data;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using zsi.PhotoFingCapture.Models;
using System.IO;
using zsi.Framework.Common;
using System.Collections.ObjectModel;
namespace zsi.PhotoFingCapture.Models.DataControllers
{
    public class dcUser : SQLServer.MasterDataController<User>
    {
 
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");

            this.DBConn = new SqlConnection(_ConnectionString);
            this.Procedures.Add(new SQLServer.Procedure("dbo.SelectProfileFPT", SQLCommandType.Select));
            this.Procedures.Add(new SQLServer.Procedure("dbo.SelectUserInfo", SQLCommandType.SingleRecord));
            this.Procedures.Add(new SQLServer.Procedure("dbo.UpdateRequestCode", SQLCommandType.Update));

        }

        public User GetUserInfo(Int64 ProfileId)
        {
            string _MacAddress = new dcClientWorkStation().GetRegisteredMacAddress();
            this.SelectInfoParameters.Add("p_ProfileId", ProfileId);
            this.SelectInfoParameters.Add("p_WSMacAddress", _MacAddress);
            User _info = this.GetInfo();
            return _info;
        }

        public void UpdateRequestCode(int UserId,string ClientRequestCode)
        {
            this.UpdateParameters.Add("p_UserId", UserId);
            this.UpdateParameters.Add("p_ClientRequestCode", ClientRequestCode);
            this.Update();
        }
  
        public User GetUserLogon(string UserName)
        {
            try
            {
                string _MacAddress = new dcClientWorkStation().GetRegisteredMacAddress();
                SQLServer.Procedure p = new SQLServer.Procedure("dbo.SelectLogon");
                p.Parameters.Add("p_UserName", UserName);
                p.Parameters.Add("p_WSMacAddress", _MacAddress);
                return new dcUser().GetInfo(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      


    }
}
