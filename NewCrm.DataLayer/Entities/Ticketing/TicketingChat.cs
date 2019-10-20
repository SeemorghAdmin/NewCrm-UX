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
        public int TicketingChatId { get; set; }
        public int TicketID { get; set; }
        public string Comment { get; set; }
        public DateTime CommentTime { get; set; }
        public string PersonNationalId { get; set; }
        public bool Confidential { get; set; }
        #region Relation
        [ForeignKey("TicketID")]
        public virtual Ticket Ticket { get; set; }
        [ForeignKey("PersonNationalId")]
        public virtual Person Person { get; set; }
        #endregion
    }
}
