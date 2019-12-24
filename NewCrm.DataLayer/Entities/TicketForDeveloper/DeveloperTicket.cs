using NewCrm.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewCrm.DataLayer.Entities.TicketForDeveloper
{
    //ایجاد کلاس مربوط به تیکت هایی که کارمندان به برنامه نویسان ارسال میکنند
  public  class DeveloperTicket
    {
        [Key]
        public int DeveloperTicket_ID { get; set; }
        public string PersonNational_ID { get; set; }
        public string DateOfCreation { get; set; }
        public bool Active { get; set; }
        public string Resiver { get; set; }
        public string Closure { get; set; }
        public int UnseenNumber { get; set; }
        [MaxLength(6)]
        public int Status { get; set; }
        #region Relation
        [ForeignKey("PersonNational_ID")]
        public virtual Person Person { get; set; }
        #endregion


    }
}
