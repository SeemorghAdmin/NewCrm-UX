using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class TelecomCenter
    {
        public long Id { get; set; }
        public string CenterAgentName { get; set; }
        public string CenterTel { get; set; }
        public long? CityId { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public string Address { get; set; }
        public double? CenterLat { get; set; }
        public double? CenterLng { get; set; }
        public long? TelCityId { get; set; }
    }
}
