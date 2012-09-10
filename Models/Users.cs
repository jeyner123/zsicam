using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class User : UserStamp
    {
        #region "Constructor"
        public User() { }
        #endregion

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public bool IsActive { get; set; }
        public int PlaceId { get; set; }
        public bool IsCertifier { get; set; }
        public bool IsVerifier { get; set; }
        public int DesignationId { get; set; }
        public Int64 ProfileId { get; set; }
        public int RegionId { get; set; }
        public int ProvinceId { get; set; }
        public int CityMunicipalityId { get; set; }
        public int BarangayId { get; set; }
        public string RegionName { get; set; }
        public int ProvinceName { get; set; }
        public string CityMunicipalityName { get; set; }
        public string BarangayName { get; set; }
        public string DesignationDesc { get; set; }
        public string UserLevel { get; set; }
        public bool IsLoginActive { get; set; }
        public string UserLocation { get; set; }
        public string RankDesc { get; set; }
        public bool IsWriteCase { get; set; }
        public bool IsWriteManage { get; set; }
        public bool IsWriteProfile { get; set; }
        public bool IsReport { get; set; }
        public bool IsWriteClearance { get; set; }
        public bool IsReleaseClearance { get; set; }
        public bool IsPoliceOnly { get; set; }
        public bool IsManageUser { get; set; }
        public string ClientRequestCode { get; set; }
        public string WSMacAddress { get; set; }
        public int ClientId {get;set;}
        public bool IsZSIAdmin {get;set;}
        public int PositionId {get;set;}
        public int RankId {get;set;} 


    }
}
