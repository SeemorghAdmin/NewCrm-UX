using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class EquipmentTypeParameters
    {
        public long Id { get; set; }
        public string Amount { get; set; }
        public long? EquipmentParameterId { get; set; }
        public long? EquipmentTypeId { get; set; }
    }
}
