using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class JobWorkHistory
    {
        public long Id { get; set; }
        public string CompanyField { get; set; }
        public string CompanyName { get; set; }
        public string EndReason { get; set; }
        public string JobPost { get; set; }
        public string LastSalary { get; set; }
        public long? PersonalId { get; set; }
    }
}
