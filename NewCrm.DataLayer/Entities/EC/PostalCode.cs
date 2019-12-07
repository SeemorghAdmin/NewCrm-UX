using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class PostalCode
    {
        public long Id { get; set; }
        public long? CityId { get; set; }
        public long? EndCode { get; set; }
        public long? StartCode { get; set; }
    }
}
