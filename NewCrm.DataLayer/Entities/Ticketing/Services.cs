using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewCrm.DataLayer.Entities.Ticketing
{
   public class Services
    {
        [Key]
        public int Services_ID { get; set; }
        public int ServiceType_ID { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string EnName { get; set; }
        [MaxLength(100)]
        public string FaName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastEditTime { get; set; }
        #region Relation
        public virtual ServiceType  ServiceType { get; set; }
        #endregion
    }
}
