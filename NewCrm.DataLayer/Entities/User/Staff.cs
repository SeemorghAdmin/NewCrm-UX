using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewCrm.DataLayer.Entities.User
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        [MaxLength(50)]
        public string StaffNumber { get; set; }

        [Required]
        public int PositionId { get; set; }

        public string Address { get; set; }

        [MaxLength(12)]
        public string TeleNumber { get; set; }

        [MaxLength(50)]
        public string EduDegree { get; set; }

        [MaxLength(50)]
        public string EduField { get; set; }

        public string PersonNationalId { get; set; }

        #region Relations
        public virtual Person Person { get; set; }
        #endregion
      
    }
}
