using System;
using System.Collections.Generic;
using System.Text;

namespace NewCrm.Core.DTOs
{
   public class CreatTicketViewModel
    {
        public int Services_ID { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public string PersonNational_ID { get; set; }

    }
}
