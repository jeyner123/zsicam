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
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public int Age { get; set; }
            public string FullName { get; set; }
            public string FullAddress { get; set; }
        }

}
