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
            public int ClientEmployeeId { get; set; }
            public string EmployeeNo { get; set; }
            public int ShiftId { get; set; }
            public bool IsZSIAdmin { get; set; }
            public string PositionDesc { get; set; }
            public string DepartmentDesc { get; set; }
            public string SectionDesc { get; set; }
            public string RankDesc { get; set; }

            public byte[] LeftTF { get; set; }
            public byte[] LeftIF { get; set; }
            public byte[] LeftMF { get; set; }
            public byte[] LeftRF { get; set; }
            public byte[] LeftSF { get; set; }
            public byte[] RightTF { get; set; }
            public byte[] RightIF { get; set; }
            public byte[] RightMF { get; set; }
            public byte[] RightRF { get; set; }
            public byte[] RightSF { get; set; }
            public byte[] FrontImg { get; set; }

            public DateTime CreatedDate { get; set; }
            public DateTime UpdatedDate { get; set; }

        }

}
