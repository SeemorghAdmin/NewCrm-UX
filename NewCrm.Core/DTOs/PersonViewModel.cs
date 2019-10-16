using System;
using System.Collections.Generic;
using System.Text;

namespace NewCrm.Core.DTOs
{
    public class RegisterViewModel
    {
        public string PersonNationalId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Gender { get; set; }

        public string NationalCardSerial { get; set; }

        public string ShenasNum { get; set; }

        public string ShenasSerial { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
