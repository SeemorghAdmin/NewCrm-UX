using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class State
    {
        public long StateId { get; set; }
        public long? CountryId { get; set; }
        public string Name { get; set; }
        public int? PhoneCode { get; set; }
    }
}
