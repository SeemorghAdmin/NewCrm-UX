using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class Log
    {
        public long LogId { get; set; }
        public string Description { get; set; }
        public long? NationalId { get; set; }
        public DateTime? Time { get; set; }
    }
}
