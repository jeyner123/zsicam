using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OleDb =zsi.Framework.Data.DataProvider.OleDb;
using SQLServer = zsi.Framework.Data.DataProvider.SQLServer;
using zsi.Framework.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using zsi.PhotoFingCapture.Models;
using System.IO;
using zsi.Framework.Common;
using System.Collections.ObjectModel;
namespace zsi.PhotoFingCapture.Models.DataControllers
{
    public class dcUserProfileFP : SQLServer.MasterDataController<UserProfileFP>
    {
         
        
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            
            this.DBConn = new SqlConnection(_ConnectionString);
            this.Procedures.Add(new SQLServer.Procedure("dbo.UpdateUserProfileFP", SQLCommandType.Update));
        }

        public void UpdateUserProfileFP(Int64 p_UserId, string p_ColumnName, byte[] p_FTmp) {
            this.UpdateParameters.Add("p_UserId", ClientSettings.UserInfo.UserId);
            this.UpdateParameters.Add("p_ColumnName", p_ColumnName);
            this.UpdateParameters.Add("p_FTmp", p_FTmp, System.Data.SqlDbType.Image);
            this.Update();              
        }
        
 

    }
}
