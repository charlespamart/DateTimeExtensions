using System;
using Xunit;

namespace DateTimeExtensions.Tests
{
    public class HolidaysShould
    {
        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2021), MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2022), MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2023), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsTrueOnHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var result = Holidays.IsHoliday(dateTime);

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetNoHolidayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsFalseOnNonHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var result = Holidays.IsHoliday(dateTime);

            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetSundayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsTrueOnSunday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var result = Holidays.IsSunday(dateTime);

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetNoHolidayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsFalseOnNotSunday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var result = Holidays.IsSunday(dateTime);

            Assert.False(result);
        }
        
        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2021), MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2022), MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2023), MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetSundayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsTrueOnSundayOrHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var result = Holidays.IsHolidayOrSunday(dateTime);
            
            Assert.True(result);
        }
        
        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetNoHolidayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsFalseOnNonSundayOrNonHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var result = Holidays.IsHolidayOrSunday(dateTime);
            
            Assert.False(result);
        }

        [Theory]
        [InlineData(2021)]
        [InlineData(2022)]
        [InlineData(2023)]
        public void ReturnsEasterDayForAYear(int year)
        {
            var result = Holidays.GetEasterDay(year);
            
            var expected = DateTimeExtensionsHelpers.GetEasterDateByYear[year];

            Assert.Equal(result.Year, expected.Year);
            Assert.Equal(result.Month, expected.Month);
            Assert.Equal(result.Day, expected.Day);
        }

        [Theory]
        [InlineData(2021)]
        [InlineData(2022)]
        [InlineData(2023)]
        public void ReturnsAscensionDayForAYear(int year)
        {
            var result = Holidays.GetAscensionDay(year);
            
            var expected = DateTimeExtensionsHelpers.GetAscensionDateByYear[year];

            Assert.Equal(result.Year, expected.Year);
            Assert.Equal(result.Month, expected.Month);
            Assert.Equal(result.Day, expected.Day);
        }

        [Theory]
        [InlineData(2021)]
        [InlineData(2022)]
        [InlineData(2023)]
        public void ReturnsWhitDayForAYear(int year)
        {
            var result = Holidays.GetWhitDay(year);
            
            var expected = DateTimeExtensionsHelpers.GetWhitDateByYear[year];

            Assert.Equal(result.Year, expected.Year);
            Assert.Equal(result.Month, expected.Month);
            Assert.Equal(result.Day, expected.Day);
        }
    }
}