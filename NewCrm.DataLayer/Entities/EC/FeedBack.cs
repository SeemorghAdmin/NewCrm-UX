using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class FeedBack
    {
        public long Id { get; set; }
        public long? AdminId { get; set; }
        public byte[] AttachedFile { get; set; }
        public string AttachedFileExtension { get; set; }
        public string Description { get; set; }
        public string PageAddress { get; set; }
        public DateTime? TimeStamp { get; set; }
        public DateTime? RepairTimeStamp { get; set; }
        public int? StatusVal { get; set; }
    }
}
