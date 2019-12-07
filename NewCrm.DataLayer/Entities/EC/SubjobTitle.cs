using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class SubjobTitle
    {
        public long Id { get; set; }
        public string SubtitleName { get; set; }
        public long? TitelId { get; set; }
    }
}
