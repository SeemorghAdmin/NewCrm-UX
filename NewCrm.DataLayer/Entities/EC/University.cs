using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class University
    {
        public long UniNationalId { get; set; }
        public string Address { get; set; }
        public byte[] CancellForm { get; set; }
        public long? CityId { get; set; }
        public byte[] ConfirmForm { get; set; }
        public int? CountryId { get; set; }
        public byte[] EditForm { get; set; }
        public string FaxNo { get; set; }
        public double? MapLocLat { get; set; }
        public double? MapLocLng { get; set; }
        public string PostalCode { get; set; }
        public byte[] ReasonCancellForm { get; set; }
        public byte[] RequestForm { get; set; }
        public string SiteAddress { get; set; }
        public long? StateId { get; set; }
        public byte[] SubscriptionForm { get; set; }
        public string TeleNo { get; set; }
        public string TopManagerName { get; set; }
        public string UniName { get; set; }
        public string UniPublicEmail { get; set; }
        public int? UniStatus { get; set; }
        public long? UniStatusLog { get; set; }
        public int? UniSubStatus { get; set; }
        public int? UniSubCode { get; set; }
        public int? TypeVal { get; set; }
        public byte[] SubscriptionExampleForm { get; set; }
        public string EcoCode { get; set; }
        public bool? JameSeprate { get; set; }
        public string SignatoryName { get; set; }
        public string SignatoryNationalId { get; set; }
        public string SignatoryPos { get; set; }
        public string TopManagerPos { get; set; }
        public DateTime? SubscriptionContractDate { get; set; }
        public string SubscriptionContractNo { get; set; }
        public byte[] SubscriptionFormSigned { get; set; }
        public byte[] SubscriptionLetter { get; set; }
        public byte[] SubscriptionPostTicket { get; set; }
        public bool? Active { get; set; }
    }
}
