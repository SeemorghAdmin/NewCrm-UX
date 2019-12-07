using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class AdminAccess
    {
        public long Id { get; set; }
        public int? AccessVal { get; set; }
        public long? AdminId { get; set; }
        public int? SubAccessVal { get; set; }
    }
}
