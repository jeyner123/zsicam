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
    public class dcProfile : SQLServer.MasterDataController<Profile>
    {

        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");

            this.DBConn = new SqlConnection(_ConnectionString);
            //this.Procedures.Add(new SQLServer.Procedure("dbo.SelectProfiles", SQLCommandType.Select));
            this.Procedures.Add(new SQLServer.Procedure("dbo.SelectProfileInfo", SQLCommandType.GetSingleInfo));
        }

        public byte[] GetFrontImageByProfileId(Int64 p_ProfileId) {
            Profile p = new Profile();
            dcProfile _dc = new dcProfile();
            SQLServer.Procedure _proc = new SQLServer.Procedure("dbo.SelectProfileImage");
            _proc.Parameters.Add("p_ProfileId", p_ProfileId);
            p = _dc.GetInfo(_proc);
            return p.FrontImg;
        }

       


    }
}
