using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class JobEducationalInfo
    {
        public long Id { get; set; }
        public float? Avg { get; set; }
        public string Gerayesh { get; set; }
        public int? Madrak { get; set; }
        public long? PersonalId { get; set; }
        public string Reshte { get; set; }
        public int? StateEdu { get; set; }
        public string UniCity { get; set; }
        public string UniCountry { get; set; }
        public string UniName { get; set; }
        public int? UniType { get; set; }
    }
}
