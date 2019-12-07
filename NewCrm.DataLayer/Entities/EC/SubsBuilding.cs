using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class SubsBuilding
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string AgentEmail { get; set; }
        public string AgentFname { get; set; }
        public string AgentFax { get; set; }
        public string AgentLname { get; set; }
        public string AgentMobile { get; set; }
        public string AgentNationalId { get; set; }
        public string AgentPos { get; set; }
        public string AgentTel { get; set; }
        public string BuildingName { get; set; }
        public long? CityId { get; set; }
        public string DistanceToTelecom { get; set; }
        public string Fax { get; set; }
        public int? FiberCoreCount { get; set; }
        public string FirstFossContract { get; set; }
        public string FirstTel { get; set; }
        public int? FreeFiberCoreCount { get; set; }
        public bool? HaveFiber { get; set; }
        public bool? HaveFreeFiber { get; set; }
        public double? MapLocLat { get; set; }
        public double? MapLocLng { get; set; }
        public string PostalCode { get; set; }
        public string SecondFossContract { get; set; }
        public string SecondTel { get; set; }
        public long? AgentId { get; set; }
        public string TelecomName { get; set; }
        public long? UniId { get; set; }
    }
}
