using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class City
    {
        public long CityId { get; set; }
        public long? CountryId { get; set; }
        public double? MapCenterLat { get; set; }
        public double? MapCenterLng { get; set; }
        public int? MapZoom { get; set; }
        public string Name { get; set; }
        public long? StateId { get; set; }
    }
}
