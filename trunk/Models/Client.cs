using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class Client:UserStamp
    {
        #region "Constructor"
        public Client() { }
        #endregion

//        public int WorkStationId { get; set; }
        public int	ClientId {get;set;}
        public int ClientTypeId { get; set; }
        public String ClientName { get; set; }
        public String CompanyCode { get; set; }
        public String CompanyName { get; set; }
        public String CompanyTelNo { get; set; }
        public String CompanyTIN { get; set; }
        public byte[] CompanyLogo { get; set; }
        public int RegionId { get; set; }
        public int ProvinceId { get; set; }
        public int CityMunicipalityId { get; set; }
        public int BarangayId { get; set; }
        public String Address { get; set; }
        public bool IsAutoId { get; set; }
        public bool IsActive { get; set; }
        public int ClientMainId { get; set; }
        public int ClientGroupId { get; set; }
        public int LastEmployeeNo { get; set; }
        public String RegCode { get; set; }
        public String EmailAdd { get; set; }

//        public int ApplicationId { get; set; }

    }

}
