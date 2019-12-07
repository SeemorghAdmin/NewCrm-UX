using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class Agent
    {
        public long AgentId { get; set; }
        public string FaxNo { get; set; }
        public byte[] IntroCert { get; set; }
        public string MobileNo { get; set; }
        public long? NationalId { get; set; }
        public bool? Payment { get; set; }
        public bool? PrimaryAgent { get; set; }
        public long? RoleId { get; set; }
        public int? SubSystemCode { get; set; }
        public string SupportEmail { get; set; }
        public string TeleNo { get; set; }
        public long? UniNationalId { get; set; }
        public string AgentPos { get; set; }
        public string TelNo { get; set; }
        public bool? IsPrimary { get; set; }
    }
}
