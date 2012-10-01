using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class FingerTemplatex
    {
        #region "Constructor"
        public FingerTemplatex() { }
        #endregion
        public Int64 ProfileId { get; set; }
        public String FullName { get; set; }
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
        public int ClientEmployeeId { get; set; }
        public string EmployeeNo { get; set; }
        public int ShiftId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }

}
