using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.dtrs.Models
{
    public class UserStamp
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }


    }
}
