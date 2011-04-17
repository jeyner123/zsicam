using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using zsi.Framework.Data.DataProvider.SQLServer;
using System.Data;
using System.Data.SqlClient;
namespace zsi.PhotoFingCapture.Models.DataControllers
{
    public class dcFingersTemplate : MasterDataController<FingerTemplate>
    {
        public override void InitDataController()
        {
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{u}.*.{u}", "{u}");
            _ConnectionString = zsi.PhotoFingCapture.Util.DecryptStringData(_ConnectionString, "{p}.*.{p}", "{p}");
            this.DBConn = new SqlConnection(_ConnectionString);
            this.Procedures.Add(new Procedure("dbo.SelectProfileFPT", SQLCommandType.Select));
        }

        public void FingerTemplatesUpdate()
        {
            try
            {
                List<FingerTemplate> _list = new List<FingerTemplate>();
                _list = this.GetDataSource();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
