using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class JobSkill
    {
        public long Id { get; set; }
        public byte[] ImgMadrak { get; set; }
        public string InstituteName { get; set; }
        public int? MadrakScore { get; set; }
        public long? PersonalId { get; set; }
        public bool? SelfLearn { get; set; }
        public string TutName { get; set; }
    }
}
