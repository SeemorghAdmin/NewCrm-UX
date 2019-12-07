using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class Equipment
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string EquipmentNo1 { get; set; }
        public string EquipmentNo2 { get; set; }
        public string EquipmentShoaNo { get; set; }
        public long? EquipmentTypeId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string SerialNo { get; set; }
        public bool? ShoaOwner { get; set; }
    }
}
