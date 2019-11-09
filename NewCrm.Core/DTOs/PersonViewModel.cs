using System;
using System.Collections.Generic;
using System.Text;

namespace NewCrm.Core.DTOs
{
    public class RegisterStaffViewModel
    {
        public string PersonNationalId { get; set; }

        public string FirstName { get; set; }

        public string StaffNumber { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public int BirthDate { get; set; }

        public int PositionId { get; set; }

        public string TeleNumber { get; set; }

        public string Address { get; set; }

        public bool Gender { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

      
        public string EduDegree { get; set; }

       
        public string EduField { get; set; }

        public string NationalCardSerial { get; set; }

        public string ShenasNum { get; set; }

        public string ShenasSerial { get; set; }

        public bool IsAdmin { get; set; }
    }

    public class LoginViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class ChangePassword
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
