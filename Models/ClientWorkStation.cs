using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class ClientWorkStation:UserStamp
    {
        #region "Constructor"
        public ClientWorkStation() { }
        #endregion
        public int WorkStationId { get; set; }
        public int ClientId { get; set; }
        public string WSMacAddress { get; set; }
        public bool IsActive { get; set; }
    }

}
