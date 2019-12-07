using System;
using System.Collections.Generic;

namespace NewCrm.DataLayer.Entities.EC
{
    public partial class News
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Emphasize { get; set; }
        public string ImageUrl { get; set; }
        public int? NewsDest { get; set; }
        public string Source { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
