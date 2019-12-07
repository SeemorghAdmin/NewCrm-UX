using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class EquipmentParentRel
    {
        public long Id { get; set; }
        public long? ChildId { get; set; }
        public long? ParentId { get; set; }
    }
}
