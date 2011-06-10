using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class Places
    {
        #region "Constructor"
        public Places() { }
        #endregion
        public int PlaceId { get; set; }
        public int SeqNo { get; set; }
        public string PlaceName { get; set; }
        public string ZipCode { get; set; }
        public int PlaceTypeId { get; set; }
        public int ParentPlaceId { get; set; }
        public Int64 ProfileSeq { get; set; }
        public Int64 ClearanceSeq { get; set; }
        public string ParentPlaceName { get; set; }
        public bool AutoSign { get; set; }
        public string RegCode { get; set; }
        public DateTime RegDate{ get; set; }
    }

}
