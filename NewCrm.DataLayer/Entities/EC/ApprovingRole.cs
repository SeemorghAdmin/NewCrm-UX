using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class ApprovingRole
    {
        public long Id { get; set; }
        public long? RoleId { get; set; }
        public long? StateId { get; set; }
        public int? UniTypeVal { get; set; }
        public int? SubSystemVal { get; set; }
        public long? UniId { get; set; }
    }
}
