using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class ClientSetting
    {
        #region "Constructor"
        public ClientSetting() { }
        #endregion
        public int ClientId { get; set; }
        public string ClientName {get;set;}
        public string ClientTypeId {get;set;}
        public string CompanyCode {get;set;}
        public string CompanyName {get;set;}
        public string CompanyTelNo {get;set;}
        public string CompanyTIN {get;set;}
        public string CompanyLogo {get;set;}
        public int RegionId {get;set;}
        public int ProviceId { get; set; }
        public int CityMunicipalityId { get; set; }
        public string Address {get;set;}
        public bool IsAutoId {get;set;}
        public int ClientMainId { get; set; }
        public int ClientGroupId { get; set; }
        public string LastEmployeeNo {get;set;}
        public string ApplicationId { get; set; }
    }

}
