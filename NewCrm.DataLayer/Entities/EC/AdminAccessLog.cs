using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class AdminAccessLog
    {
        public long Id { get; set; }
        public int? AdminAccessVal { get; set; }
        public long? AdminId { get; set; }
        public string Message { get; set; }
        public int? PageAccessVal { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
