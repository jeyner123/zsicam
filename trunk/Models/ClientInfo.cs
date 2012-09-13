using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zsi.PhotoFingCapture.Models;

namespace zsi.PhotoFingCapture
{
    public static class ClientSettings
    {
        public static Profile ProfileInfo { get; set; }
        public static User UserInfo { get; set; }
        public static ClientWorkStation ClientWorkStationInfo { get; set; }
    }

}
