using System;
using System.Collections.Generic;
using System.Text;

namespace NewCrm.Core.DTOs
{
   public class CreatTicketViewModel
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string PersonNationalId { get; set; }

    }
}
