using System;
using System.Globalization;

namespace NewCrm.Core.Convertors
{
    public class ConvertDate
    {
        public static string ConvertSha(DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();

            string da = $"Persian Calendar:    { pc.GetDayOfWeek(dateTime)}, { pc.GetMonth(dateTime)}/{pc.GetDayOfMonth(dateTime)}" +
                $"/{ pc.GetYear(dateTime)} {pc.GetHour(dateTime)}:{ pc.GetMinute(dateTime) }:{pc.GetSecond(dateTime)}";
                       
            return da;
        }

        public static DateTime ConvetMil(DateTime year)
        {
            PersianCalendar pc = new PersianCalendar();

            DateTime dateTime = new DateTime(pc.GetYear(year), 1, 1);

            return dateTime;
        }
    }
}
