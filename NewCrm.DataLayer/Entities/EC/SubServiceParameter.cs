using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class SubServiceParameter
    {
        public long Id { get; set; }
        public double? BronzeValue { get; set; }
        public double? DiamondValue { get; set; }
        public string FaName { get; set; }
        public double? GoldValue { get; set; }
        public double? SilverValue { get; set; }
        public long? SubServiceId { get; set; }
        public int? UnitVal { get; set; }
    }
}
