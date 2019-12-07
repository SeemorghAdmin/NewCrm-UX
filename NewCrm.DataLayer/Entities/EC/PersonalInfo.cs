using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class PersonalInfo
    {
        public long NationalId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string FatherName { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string NationalCardNo { get; set; }
        public string ShenasNo { get; set; }
        public string ShenasSerial { get; set; }
        public string SiteEmail { get; set; }
        public bool? NeedChangePass { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool? LegalPersonality { get; set; }
        public bool? Active { get; set; }
    }
}
