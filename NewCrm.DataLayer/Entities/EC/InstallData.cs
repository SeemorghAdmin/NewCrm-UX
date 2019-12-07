using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class InstallData
    {
        public long Id { get; set; }
        public long? EquipmentId { get; set; }
        public long? TelecomCenterId { get; set; }
        public long? ParentEquipmentId { get; set; }
    }
}
