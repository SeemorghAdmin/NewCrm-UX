using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class UserRole
    {
        public long RoleId { get; set; }
        public long? NationalId { get; set; }
        public int? UserRoleVal { get; set; }
        public int? Validity { get; set; }
    }
}
