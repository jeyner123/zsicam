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
    public class dcPlaceWorkStation : SQLServer.MasterDataController<PlaceWorkStation>
    {

        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");

            this.DBConn = new SqlConnection(_ConnectionString);
            this.Procedures.Add(new SQLServer.Procedure("dbo.SelectPlaces", SQLCommandType.Select));
            this.Procedures.Add(new SQLServer.Procedure("dbo.GetPlaceName", SQLCommandType.GetSingleInfo));
        }
        public bool UpdateWorkStation(int PlaceId){
            try
            {
                dcPlaceWorkStation _dcUpdate = new dcPlaceWorkStation();
                SQLServer.Procedure _procUpdate = new SQLServer.Procedure("dbo.UpdatePlaceWorkStation");
                _procUpdate.Parameters.Add("p_WSMacAddress", Util.GetMacAddress());
                _procUpdate.Parameters.Add("p_PlaceId", PlaceId);
                _procUpdate.Parameters.Add("p_CreatedUpdatedBy", ClientInfo.UserInfo.UserId);
                return _dcUpdate.Update(_procUpdate);
            } 
            catch (Exception ex)
            {
                throw ex;
            }      
        }

    


    }
}
