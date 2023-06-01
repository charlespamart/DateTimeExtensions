using System;
using Xunit;

namespace DateTimeExtensions.Tests
{
    public class HolidaysShould
    {
        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2021),
            MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2022),
            MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2023),
            MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnTrueOnHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);

            var sut = dateTime.IsHoliday();

            Assert.True(sut);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetNoHolidayDates),
            MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnFalseOnNonHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);

            var sut = dateTime.IsHoliday();

            Assert.False(sut);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetSundayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnTrueOnSunday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);

            var sut = dateTime.IsSunday();

            Assert.True(sut);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetNoHolidayDates),
            MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnFalseOnNotSunday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);

            var sut = dateTime.IsSunday();

            Assert.False(sut);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2021),
            MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2022),
            MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetHolidayDatesIn2023),
            MemberType = typeof(DateTimeExtensionsHelpers))]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetSundayDates), MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnTrueOnSundayOrHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);

            var sut = dateTime.IsHolidayOrSunday();

            Assert.True(sut);
        }

        [Theory]
        [MemberData(nameof(DateTimeExtensionsHelpers.GetNoHolidayDates),
            MemberType = typeof(DateTimeExtensionsHelpers))]
        public void ReturnFalseOnNonSundayOrNonHoliday(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);

            var sut = dateTime.IsHolidayOrSunday();

            Assert.False(sut);
        }

        [Theory]
        [InlineData(2021)]
        [InlineData(2022)]
        [InlineData(2023)]
        public void ReturnEasterDayForAGivenYear(int year)
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
        public void ReturnAscensionDayForAGivenYear(int year)
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
        public void ReturnWhitDayForAGivenYear(int year)
        {
            var sut = Holidays.Whit(year);

            var expected = DateTimeExtensionsHelpers.GetWhitDateByYear[year];

            Assert.Equal(expected.Year, sut.Year);
            Assert.Equal(expected.Month, sut.Month);
            Assert.Equal(expected.Day, sut.Day);
        }
    }
}