using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class InfoDoc
    {
        public long DocId { get; set; }
        public string Description { get; set; }
        public int? DocDest { get; set; }
        public string Url { get; set; }
        public string Owner { get; set; }
        public DateTime? PubDate { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
    }
}
