﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewCrm.Core.DTOs
{
  public  class DeveloperTicketigViewModel
    {
        public int DeveloperTicket_ID { get; set; }
        public string Comment { get; set; }
        public string Sender { get; set; }
        public string Resiver { get; set; }
        public int Conf { get; set; }
    }
}
