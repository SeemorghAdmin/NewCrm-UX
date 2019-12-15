using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewCrm.DataLayer.Entities.User
{
    public class Staff
    {
        [Key]
        public int Staff_ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string StaffNumber { get; set; }

        [Required]
        public string PositionId { get; set; }

        public string Address { get; set; }

        [MaxLength(12)]
        public string TeleNumber { get; set; }

        [MaxLength(50)]
        public string EduDegree { get; set; }

        [MaxLength(50)]
        public string EduField { get; set; }

        public string PersonNational_ID { get; set; }

        #region Relations
        [ForeignKey("PersonNational_ID")]
        public virtual Person Person { get; set; }
        #endregion
      
    }
}
