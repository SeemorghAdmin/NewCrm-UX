using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class JobTitle
    {
        public long Id { get; set; }
        public string PicFormat { get; set; }
        public string TitleName { get; set; }
        public byte[] TitlePic { get; set; }
    }
}
