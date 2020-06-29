using System;
using System.Collections.Generic;
using System.Text;

namespace RangeFilter.Extensions
{
    public static class DateRangeExtensions
    {
        /// <summary>
        /// Gets the very start of the day.
        /// </summary>
        /// <param name="dateRange"></param>
        /// <returns></returns>
        public static DateTime FromDateRangeDate(this RangeFilter<DateTime> dateRange)
        {
            if (dateRange.From.HasValue)
            {
                return dateRange.From.Value.Date;
            }

            return DateTime.MinValue;
        }

        /// <summary>
        /// Based on ticks in a second. This is the closest I can find in setting the last moment of a day:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.datetime.ticks?view=netframework-4.8#remarks
        /// </summary>
        /// <param name="dateRange">The dateRange element</param>
        /// <returns></returns>
        public static DateTime ToDateRangeDate(this RangeFilter<DateTime> dateRange)
        {
            if (dateRange.To.HasValue)
            {
                return dateRange.To.Value.Date.AddDays(1).AddTicks(-1);
            }

            return DateTime.MaxValue;
        }
    }
}
