using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NewCrm.DataLayer.Entities.User;

namespace NewCrm.DataLayer.Context
{
    public class NewCrmContext : DbContext
    {
        public NewCrmContext(DbContextOptions<NewCrmContext> options) : base(options)
        {

        }

        #region Entitis
        public DbSet<Person> People { get; set; }

        public DbSet<Staff> Staffs { get; set; }
        #endregion
    }
}
