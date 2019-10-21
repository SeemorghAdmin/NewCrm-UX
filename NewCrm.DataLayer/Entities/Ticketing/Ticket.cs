using NewCrm.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewCrm.DataLayer.Entities.Ticketing
{
   public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int Service_ID { get; set; }
        public  string Title { get; set; }
        public string PersonNationalId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool Active { get; set; }
        public DateTime Closure { get; set; }
        [MaxLength(6)]
        public int Status { get; set; }
        #region Relation
        [ForeignKey("Service_ID")]
        public virtual Services  Services { get; set; }
        [ForeignKey("PersonNationalId")]
        public virtual  Person  Person{ get; set; }
        #endregion


    }
}
