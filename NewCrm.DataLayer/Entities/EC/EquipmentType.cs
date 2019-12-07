using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class EquipmentType
    {
        public long Id { get; set; }
        public bool? IranManufactured { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public int? TypeVal { get; set; }
        public int? Ampere { get; set; }
        public int? ElectronicSourceVal { get; set; }
        public int? Watt { get; set; }
        public int? Capacity { get; set; }
        public int? CapacityUse { get; set; }
    }
}
