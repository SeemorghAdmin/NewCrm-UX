using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class PersonalDoc
    {
        public long NationalId { get; set; }
        public byte[] IntroCert { get; set; }
        public byte[] NationalCard { get; set; }
        public byte[] ShenasFpage { get; set; }
        public byte[] StudentCard { get; set; }
    }
}
