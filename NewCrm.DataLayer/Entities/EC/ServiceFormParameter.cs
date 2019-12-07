using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class ServiceFormParameter
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long? Deposit { get; set; }
        public long? InitialCost { get; set; }
        public long? OtherCost { get; set; }
        public long? PeriodicPayment { get; set; }
        public long? ServiceFormId { get; set; }
        public string Specs { get; set; }
        public long? Warranty { get; set; }
    }
}
