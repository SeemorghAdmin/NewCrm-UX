using NewCrm.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewCrm.DataLayer.Entities.Ticketing
{
   public class TicketingChat
    {
        [Key]
        public int TicketingChat_ID { get; set; }
        public int Ticket_ID { get; set; }
        public string Comment { get; set; }
        public string CommentTime { get; set; }
        public string PersonNational_ID { get; set; }
        public bool Confidential { get; set; }
        public string Resiver { get; set; }
        public string Sender { get; set; }
        #region Relation
        [ForeignKey("Resiver")]
        public virtual Person ResiverInformation { get; set; }
        [ForeignKey("Sender")]
        public virtual Person SenderInformation { get; set; }
        [ForeignKey("Ticket_ID")]
        public virtual Ticket Ticket { get; set; }
        [ForeignKey("PersonNational_ID")]
        public virtual Person Person { get; set; }
        #endregion
    }
}
