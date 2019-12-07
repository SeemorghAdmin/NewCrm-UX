using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class UserRel
    {
        public long RelId { get; set; }
        public long? NationalId { get; set; }
        public string Password { get; set; }
        public int? UserRelStatus { get; set; }
        public int? SubSystemCode { get; set; }
        public long? UniNationalId { get; set; }
        public string Username { get; set; }
        public int? Validity { get; set; }
    }
}
