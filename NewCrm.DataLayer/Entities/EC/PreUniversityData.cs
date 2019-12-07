using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class PreUniversityData
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public long? UniInternalCode { get; set; }
        public long? UniNationalCode { get; set; }
        public int? SourceVal { get; set; }
    }
}
