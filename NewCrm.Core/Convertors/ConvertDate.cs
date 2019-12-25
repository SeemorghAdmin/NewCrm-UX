using System;
using System.Globalization;

namespace NewCrm.Core.Convertors
{
    public class ConvertDate
    {
        // تبدیل تاریخ به شمسی
        public static string ConvertSha(DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();

            string da = $"{pc.GetYear(dateTime)  }/{pc.GetMonth(dateTime)}" +
                $"/{ pc.GetDayOfMonth(dateTime)} {pc.GetHour(dateTime)}:{ pc.GetMinute(dateTime) }";
                       
            return da;
        }
        // تبدیل تاریخ به میلادی
        public static DateTime ConvetMil(DateTime year)
        {
            PersianCalendar pc = new PersianCalendar();

            DateTime dateTime = new DateTime(pc.GetYear(year), 1, 1);

            return dateTime;
        }
    }
}
