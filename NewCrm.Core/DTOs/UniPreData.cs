using System;
using System.Collections.Generic;
using System.Text;



// ویو مدل های لازم برای اضافه کردن اطلاعات دانشگاه های پیش فرض
namespace NewCrm.Core.DTOs
{
    public class UniPreData
    {
        public int UniType { get; set; }

        public string Unicode { get; set; }

        public string Uniname { get; set; }

        public string Address { get; set; }
    }
}
