using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
   public class DateModifier
    {
        public int GetDateDiff(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);
            int days = (int)Math.Abs((start - end).TotalDays);
            
            return days;
        }
    }
}
