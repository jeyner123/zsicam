using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class FingerTemplate
    {
        #region "Constructor"
        public FingerTemplate() { }
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
        public byte[] ProfileImg { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        

    }

}
