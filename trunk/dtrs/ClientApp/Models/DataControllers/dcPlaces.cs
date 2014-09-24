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
    public class dcPlaces : SQLServer.MasterDataController<Places>
    {

        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");

            this.DBConn = new SqlConnection(_ConnectionString);
            this.Procedures.Add(new SQLServer.Procedure("dbo.SelectPlaces", SQLCommandType.Select));
            this.Procedures.Add(new SQLServer.Procedure("dbo.GetPlaceName", SQLCommandType.SingleRecord));
        }

     

        public List<Places> GetPlaces(int PlaceId, int ParentPlaceId)
        {
            try
            {
                this.SelectParameters.Add("p_PlaceId", PlaceId);
                this.SelectParameters.Add("p_ParentPlaceId", ParentPlaceId);
                this.SelectParameters.Add("p_IsDDL", 1);
                return this.GetDataSource();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetPlaceName(int PlaceId)
        {
            try
            {
                SqlCommand command = new SqlCommand("select dbo.GetPlaceName(" + PlaceId + ")", this.DBConn);
                command.CommandType = CommandType.Text;
                this.DBConn.Open();
                object _result = command.ExecuteScalar();
                this.DBConn.Close();
                return _result.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
