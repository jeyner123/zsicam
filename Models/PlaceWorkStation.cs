using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class PlaceWorkStation:UserStamp
    {
        #region "Constructor"
        public PlaceWorkStation() { }
        #endregion
        public int WorkStationId { get; set; }
        public int PlaceId { get; set; }
        public string WSMacAddress { get; set; }
        public bool IsActive { get; set; }
    }

}
