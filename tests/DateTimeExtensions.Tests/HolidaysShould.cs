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
            
            var sut = Holidays.IsHoliday(dateTime);

            Assert.True(sut);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetNoHolidayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsFalseOnNonHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var sut = Holidays.IsHoliday(dateTime);

            Assert.False(sut);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetSundayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsTrueOnSunday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var sut = Holidays.IsSunday(dateTime);

            Assert.True(sut);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetNoHolidayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsFalseOnNotSunday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var sut = Holidays.IsSunday(dateTime);

            Assert.False(sut);
        }
        
        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2021), MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2022), MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2023), MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetSundayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsTrueOnSundayOrHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var sut = Holidays.IsHolidayOrSunday(dateTime);
            
            Assert.True(sut);
        }
        
        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetNoHolidayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnsFalseOnNonSundayOrNonHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);
            
            var sut = Holidays.IsHolidayOrSunday(dateTime);
            
            Assert.False(sut);
        }

        [Theory]
        [InlineData(2021)]
        [InlineData(2022)]
        [InlineData(2023)]
        public void ReturnsEasterDayForAGivenYear(int year)
        {
            var sut = Holidays.Easter(year);
            
            var expected = DateTimeExtensionsHelpers.GetEasterDateByYear[year];

            Assert.Equal(expected.Year, sut.Year);
            Assert.Equal(expected.Month, sut.Month);
            Assert.Equal(expected.Day, sut.Day);
        }

        [Theory]
        [InlineData(2021)]
        [InlineData(2022)]
        [InlineData(2023)]
        public void ReturnsAscensionDayForAGivenYear(int year)
        {
            var sut = Holidays.Ascension(year);
            
            var expected = DateTimeExtensionsHelpers.GetAscensionDateByYear[year];

            Assert.Equal(expected.Year, sut.Year);
            Assert.Equal(expected.Month, sut.Month);
            Assert.Equal(expected.Day, sut.Day);
        }

        [Theory]
        [InlineData(2021)]
        [InlineData(2022)]
        [InlineData(2023)]
        public void ReturnsWhitDayForAGivenYear(int year)
        {
            var sut = Holidays.Whit(year);
            
            var expected = DateTimeExtensionsHelpers.GetWhitDateByYear[year];

            Assert.Equal(expected.Year, sut.Year);
            Assert.Equal(expected.Month, sut.Month);
            Assert.Equal(expected.Day, sut.Day);
        }
    }
}