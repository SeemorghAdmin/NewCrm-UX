using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewCrm.DataLayer.Entities.User
{
    public class Developer
    {

        [Key]
        public int Developer_ID { get; set; }

        [MaxLength(10)]
        public string PersonNational_ID { get; set; }

        [MaxLength(12)]
        public string MobileNumber { get; set; }

        
        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        public DateTime LastEditTime { get; set; }


        #region Relations
        [ForeignKey("PersonNational_ID")]
        public virtual Person Person { get; set; }
        #endregion

    }
}
