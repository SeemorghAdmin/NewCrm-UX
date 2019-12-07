using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class EquipmentParameter
    {
        public long Id { get; set; }
        public string ParameterName { get; set; }
        public string UnitName { get; set; }
    }
}
