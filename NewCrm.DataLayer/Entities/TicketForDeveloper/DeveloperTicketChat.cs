using NewCrm.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewCrm.DataLayer.Entities.TicketForDeveloper
{
  public  class DeveloperTicketChat
    {
        [Key]
        public int DeveloperTicketChat_ID { get; set; }
        public int DeveloperTicket_ID { get; set; }
        public string Comment { get; set; }
        public string CommentTime { get; set; }
        public string PersonNational_ID { get; set; }
        public bool Confidential { get; set; }
        public string Resiver { get; set; }
        public string Sender { get; set; }
        public bool Seen { get; set; }
        #region Relation
        [ForeignKey("Resiver")]
        public virtual Person ResiverInformation { get; set; }
        [ForeignKey("Sender")]
        public virtual Person SenderInformation { get; set; }
        [ForeignKey("DeveloperTicket_ID")]
        public virtual DeveloperTicket  DeveloperTicket { get; set; }
        [ForeignKey("PersonNational_ID")]
        public virtual Person Person { get; set; }
        #endregion
    }
}
