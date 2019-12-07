using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class TelecomCenterPreFix
    {
        public long Id { get; set; }
        public string PreFixNo { get; set; }
        public long? TelecomCenterId { get; set; }
    }
}
