using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class Request
    {
        public long Id { get; set; }
        public long? JobId { get; set; }
        public long? PersonId { get; set; }
        public int? Status { get; set; }
    }
}
