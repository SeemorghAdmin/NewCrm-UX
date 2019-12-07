using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class Service
    {
        public long Id { get; set; }
        public long? CategoryId { get; set; }
        public string Code { get; set; }
        public string EnName { get; set; }
        public string FaName { get; set; }
    }
}
