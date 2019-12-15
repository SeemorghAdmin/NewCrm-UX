using System;
using System.Collections.Generic;
using System.Text;

namespace NewCrm.Core.DTOs
{
  public  class UniStatusLogViewModel
    {
        public long UniNationalId { get; set; }
        public int UniStatus { get; set; }
        public int UniSubStatus { get; set; }
        public string msg { get; set; }
    }
}
