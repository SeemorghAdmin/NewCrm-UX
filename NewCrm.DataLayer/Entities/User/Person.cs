﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewCrm.DataLayer.Entities.User
{
    public class Person
    {
        [Key]
        [MaxLength(10)]
        public string PersonNational_ID { get; set; }

        [MaxLength(50)]
        [Display(Name = "نام")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string FatherName { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Gender { get; set; }

        [MaxLength(12)]
        public string NationalCardSerial { get; set; }

        [MaxLength(12)]
        public string ShenasNum { get; set; }

        [MaxLength(12)]
        public string ShenasSerial { get; set; }

        [MaxLength(100)]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string Email { get; set; }

        [MaxLength(100)]
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string UserName { get; set; }

        [MaxLength(64)]
        [Required]
        public string Password { get; set; }

        public int Role1 { get; set; }

        public int Role2 { get; set; }

        public int Role3 { get; set; }

        public int Role4 { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateTime { get ; set; }

        public DateTime LastEditTime { get ; set; }

        public string Token { get ; set; }

        public bool NeedChangePassword { get; set; }

        public string AccessCodes { get; set; }


        #region Relations
       
        #endregion
    }
}
