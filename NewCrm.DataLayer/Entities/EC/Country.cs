using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class Country
    {
        public string CountryId { get; set; }
        public string EnName { get; set; }
        public string FaName { get; set; }
        public int? NumberCode { get; set; }
    }
}
