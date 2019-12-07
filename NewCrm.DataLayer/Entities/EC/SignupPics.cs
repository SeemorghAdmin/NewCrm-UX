using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class SignupPics
    {
        public long Id { get; set; }
        public byte[] NationalcardPic { get; set; }
        public long? PersonalinfoId { get; set; }
        public byte[] ShenasPic { get; set; }
    }
}
