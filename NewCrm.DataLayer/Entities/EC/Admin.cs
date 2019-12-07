using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class Admin
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool? PassChanged { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public long? RoleId { get; set; }
    }
}
