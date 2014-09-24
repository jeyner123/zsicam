using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using zsi.Framework.Data.DataProvider.SQLServer;
using zsi.Framework.Data;
using zsi.NetProfile.Models;
using System.Data;
using System.Data.SqlClient;
using zsi.NetProfile.Util;
namespace zsi.NetProfile.Models.DataControllers
{
    public class dcPlaceWorkStations: MasterDataController<PlaceWorkStations>
    {

        public override void InitDataController()
        {
            this.DBConn = new SqlConnection(DBConnection.ConnectionString);
            this.Procedures.Add(new Procedure("dbo.SelectPlaceWorkStations", SQLCommandType.GetSingleInfo));
            this.Procedures.Add(new Procedure("dbo.SelectPlaceWorkStations", SQLCommandType.Select));
            this.Procedures.Add(new Procedure("dbo.UpdatePlaceWorkStations", SQLCommandType.Update));
        }
    }

}
