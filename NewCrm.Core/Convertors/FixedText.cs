using System;
using System.Collections.Generic;
using System.Text;

namespace NewCrm.Core.Convertors
{
    public class FixedText
    {
        // اعتبار سنجی ایمیل
        public static string FixedEmail(string email)
        {
            // حذف فاصله ها
            return email.Trim().ToLower();
        }
    }
}
