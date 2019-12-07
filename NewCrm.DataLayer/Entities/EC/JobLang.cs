using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class JobLang
    {
        public long Id { get; set; }
        public string Language { get; set; }
        public bool? LngQuiz { get; set; }
        public float? Mark { get; set; }
        public long? PersonalId { get; set; }
        public int? ReadCol { get; set; }
        public int? Speech { get; set; }
        public int? WriteCol { get; set; }
    }
}
