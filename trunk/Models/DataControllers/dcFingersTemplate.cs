using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using zsi.Framework.Data.DataProvider.SQLServer;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using zsi.Framework.Security;
namespace zsi.PhotoFingCapture.Models.DataControllers
{
    public class dcFingersTemplate : MasterDataController<FingerTemplate>
    {
        public override void InitDataController()
        {
           Cryptography _cryp =  new Cryptography();
            string _ConnectionString = zsi.PhotoFingCapture.Properties.Settings.Default.LiveSQLServerConnection;
            string _decryptedUserName =  Regex.Match(_ConnectionString, "{u}.*.{u}").ToString();
            string _decryptedPassword = Regex.Match(_ConnectionString, "{p}.*.{p}").ToString();

            _ConnectionString = _ConnectionString.Replace( _decryptedUserName, _cryp.Decrypt(_decryptedUserName.Replace("{u}","")));
            _ConnectionString = _ConnectionString.Replace(_decryptedPassword, _cryp.Decrypt(_decryptedPassword.Replace("{p}","")));

            this.DBConn = new SqlConnection(_ConnectionString);
            this.Procedures.Add(new Procedure("dbo.SelectProfileFPT", SQLCommandType.Select));

        }

        public void FingerTemplatesUpdate()
        {
            try
            {
                List<FingerTemplate> _list = new List<FingerTemplate>();
                _list = this.GetDataSource();

                //this.SelectInfoParameters.Add("BillingId", BillingId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
