using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class UserProfileImages
    {
        #region "Constructor"
        public UserProfileImages() { }
        #endregion
        public int UserId { get; set; }
        public byte[] FrontImg { get; set; }
        public byte[] LeftImg { get; set; }
        public byte[] RightImg { get; set; }
        public byte[] BackImg { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }

}
