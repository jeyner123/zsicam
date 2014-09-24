using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.PhotoFingCapture.Models
{
    public class UserProfileFP
    {
        #region "Constructor"
        public UserProfileFP () { }
        #endregion
            public Int64 UserId { get; set; }
            public byte[]	RightTF { get; set; }
            public byte[]	LeftTF { get; set; }
            public byte[]	RightIF { get; set; }
            public byte[]	LeftIF{ get; set; }
            public byte[]	RightMF{ get; set; }
            public byte[]	LeftMF{ get; set; }
            public byte[]	RightRF{ get; set; }
            public byte[]	LeftRF{ get; set; }
            public byte[]	RightSF{ get; set; }
            public byte[]	LeftSF{ get; set; }
            public byte[]	RightTS{ get; set; }
            public byte[]	LeftTS{ get; set; }
            public byte[]	RightIS{ get; set; }
            public byte[]	LeftIS{ get; set; }
            public byte[]	RightMS{ get; set; }
            public byte[]	LeftMS{ get; set; }
            public byte[]	RightRS{ get; set; }
            public byte[]	LeftRS{ get; set; }
            public byte[]	RightSS{ get; set; }
            public byte[]	LeftSS{ get; set; }
            public DateTime	CreatedDate {get;set;}

    }

}
