using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class UniStatusLog
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime? TimeStamp { get; set; }
        public long? UniNationalId { get; set; }
        public int? UniStatus { get; set; }
        public int? UniSubStatus { get; set; }
        public long? AdminId { get; set; }
        public long? ApprovalAdminId { get; set; }
        public long? ApprovalUniId { get; set; }
    }
}
