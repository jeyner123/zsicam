using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
        public class Profile
        {
            #region "Constructor"
            public Profile() { }
            #endregion
            public Int64 ProfileId { get; set; }
            public int UserId { get; set; }
        }

}
