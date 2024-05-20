using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.Business
{
    public static class DateTimExtension
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static bool IsEarly(this DateTime d1, DateTime d2)
        {
            var thisMonth = new DateTime(d1.Year, d1.Month, 01);
            var selectedMonth = new DateTime(d2.Year, d2.Month, 01);
            if (thisMonth <= selectedMonth) return true;
            else return false;
        }
    }
}
