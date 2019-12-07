using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class EquipmentTypePort
    {
        public long Id { get; set; }
        public long? EquipmentTypeId { get; set; }
        public int? PortNo { get; set; }
        public int? PortUnitVal { get; set; }
        public double? Value { get; set; }
    }
}
