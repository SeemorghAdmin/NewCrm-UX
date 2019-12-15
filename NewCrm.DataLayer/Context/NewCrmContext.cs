using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NewCrm.DataLayer.Entities.TicketForDeveloper;
using NewCrm.DataLayer.Entities.Ticketing;
using NewCrm.DataLayer.Entities.Upload;
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
        public DbSet<ServiceType>  ServiceTypes { get; set; }
        public DbSet<Services>  Services { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketingChat> TicketingChats { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<AccessModifier> AccessModifiers { get; set; }
        public DbSet<DeveloperTicket>  DeveloperTickets { get; set; }
        public DbSet<DeveloperTicketChat>  DeveloperTicketChats { get; set; }
        public DbSet<ServiceFileUpload>   ServiceFileUploads { get; set; }
        #endregion


    }
}
