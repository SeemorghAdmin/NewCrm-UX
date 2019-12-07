using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class ServiceForm
    {
        public long Id { get; set; }
        public string OtherTerms { get; set; }
        public int? PayPeriod { get; set; }
        public int? PayTypeVal { get; set; }
        public int? SlaVal { get; set; }
        public long? SubServiceId { get; set; }
        public int? SubsDuration { get; set; }
        public bool? Active { get; set; }
        public string Version { get; set; }
    }
}
