using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class AdminStateListRole
    {
        public long Id { get; set; }
        public long? AdminId { get; set; }
        public long? StateId { get; set; }
    }
}
