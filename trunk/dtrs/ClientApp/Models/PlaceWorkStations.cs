using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using zsi.NetProfile.Models.Common;
namespace zsi.NetProfile.Models
{

    public class PlaceWorkStations : UserStamp
    {
        #region "Constructor"
        public PlaceWorkStations() { }
        #endregion
        public int WorkStationId {get;set;}
        public int PlaceId {get;set;}
        public string WSMacAddress {get;set;}
        public bool IsActive {get;set;}
    }

}