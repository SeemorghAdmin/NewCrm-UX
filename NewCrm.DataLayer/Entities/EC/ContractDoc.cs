using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class ContractDoc
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public byte[] Document { get; set; }
        public string Extension { get; set; }
        public string Title { get; set; }
    }
}
