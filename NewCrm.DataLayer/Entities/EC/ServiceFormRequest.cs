using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class ServiceFormRequest
    {
        public long Id { get; set; }
        public DateTime? ServiceFormContractDate { get; set; }
        public string ServiceFormContractNo { get; set; }
        public long? ServiceFormParameterId { get; set; }
        public long? SubsBuildingId { get; set; }
        public string SubscriptionContractNo { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public long? UniId { get; set; }
        public byte[] FinalSignedForm { get; set; }
        public byte[] Letter { get; set; }
        public byte[] PostReceipt { get; set; }
        public byte[] SignedForm { get; set; }
        public int? StatusVal { get; set; }
    }
}
