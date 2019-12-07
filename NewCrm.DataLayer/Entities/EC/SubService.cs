using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class SubService
    {
        public long Id { get; set; }
        public string ApproveSessionNo { get; set; }
        public int? ApproveTypeVal { get; set; }
        public string Code { get; set; }
        public string EnName { get; set; }
        public string ExclusiveTerms { get; set; }
        public string FaName { get; set; }
        public string CostTitle { get; set; }
        public long? ServiceId { get; set; }
        public string SlaMeasurement { get; set; }
    }
}
