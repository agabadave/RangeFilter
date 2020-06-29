using System;
using System.Collections.Generic;
using System.Text;
using RangeFilter.Extensions;
using Xunit;

namespace RangeFilter.Tests.Extensions
{
    public class DateRangeExtensionTests
    {
        [Fact]
        public void FromDateRangeDate_ShouldReturnMinimumDate_WhenFromDateIsNull()
        {
            var dateRange = new RangeFilter<DateTime>();
            var extFromDate = dateRange.FromDateRangeDate();

            Assert.Equal(DateTime.MinValue, extFromDate);
        }

        [Fact]
        public void FromDateRangeDate_ShouldReturnMidnightDateTime_WhenNotNull()
        {
            var dateRange = new RangeFilter<DateTime>
            {
                From = new DateTime(2019, 01, 13, 14, 30, 32)
            };

            var extFromDate = dateRange.FromDateRangeDate();
            var timeOfDayTicks = extFromDate.TimeOfDay.Ticks;

            Assert.Equal(0, timeOfDayTicks);
        }

        [Fact]
        public void ToDateRangeDate_ShouldReturnMaximumDate_WhenToDateIsNull()
        {
            var dateRange = new RangeFilter<DateTime>();

            Assert.Equal(DateTime.MaxValue, dateRange.ToDateRangeDate());
        }

        [Fact]
        public void ToDateRangeDate_ShouldReturnLeastTick_WhenToDateIsNotNull()
        {
            var dateRange = new RangeFilter<DateTime>
            {
                From = new DateTime(2019, 01, 13, 14, 30, 32)
            };

            var extToDate = dateRange.ToDateRangeDate();
            var timeOfDayTicks = extToDate.TimeOfDay.Ticks;

            const long totalMillSeconds = 24 * 60 * 60 * 1000;

            Assert.Equal(totalMillSeconds * 10000 - 1L, timeOfDayTicks);
        }
    }
}
