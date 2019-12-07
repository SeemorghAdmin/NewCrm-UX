using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class Job
    {
        public long Id { get; set; }
        public bool? Active { get; set; }
        public string Education { get; set; }
        public string Expection { get; set; }
        public string JobCode { get; set; }
        public int? JobLevel { get; set; }
        public string JobName { get; set; }
        public int? JobSeekerNumbers { get; set; }
        public long? JobTitle { get; set; }
        public int? MinimiumDegree { get; set; }
        public int? NeededRecord { get; set; }
        public string Skills { get; set; }
        public long? SubJob { get; set; }
    }
}
