using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class JobPersonalInfo
    {
        public long Id { get; set; }
        public string Addres { get; set; }
        public DateTime? Birthday { get; set; }
        public string City { get; set; }
        public string CodeMeli { get; set; }
        public string Email { get; set; }
        public string Family { get; set; }
        public bool? Gender { get; set; }
        public string HomeNo { get; set; }
        public byte[] ImgPerson { get; set; }
        public bool? Marriage { get; set; }
        public string MobileNo { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }
        public long? RoleId { get; set; }
        public string ShenasNo { get; set; }
        public string State { get; set; }
        public long? UseraccId { get; set; }
    }
}
