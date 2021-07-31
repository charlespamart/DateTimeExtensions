using System;
using System.Collections.Generic;
using System.Linq;

namespace DateTimeExtensions
{
    public class Holidays
    {
        public static bool IsSunday(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsHoliday(DateTime dateTime)
        {
            return GetHolidays(dateTime.Year).Any(holiday => DateTime.Compare(holiday, dateTime) == 0);
        }

        public static bool IsHolidayOrSunday(DateTime dateTime)
        {
            return IsSunday(dateTime) || IsHoliday(dateTime);
        }

        private static IReadOnlyCollection<DateTime> GetHolidays(int year)
        {
            return new List<DateTime>()
            {
                GetEasterDay(year),
                GetAscensionDay(year),
                GetWhitDay(year),
                GetNewYearDay(year),
                GetLaborDay(year),
                GetWorldWarTwoDay(year),
                GetBastilleDay(year),
                GetAssumptionOfMaryDay(year),
                GetAllSaintsDay(year),
                GetArmisticeDay(year),
                GetChristmasDay(year)
            };
        }

        public static DateTime GetEasterDay(int year)
        {
            var (month, day) = ExecuteEasterDayAlgorithm(year);

            return new DateTime(year, month, day);
        }

        public static DateTime GetAscensionDay(int year) => GetEasterDay(year).AddDays(38);

        public static DateTime GetWhitDay(int year) => GetEasterDay(year).AddDays(49);

        public static DateTime GetNewYearDay(int year) => new(year, 1, 1);

        public static DateTime GetLaborDay(int year) => new(year, 5, 1);

        public static DateTime GetWorldWarTwoDay(int year) => new(year, 5, 8);

        public static DateTime GetBastilleDay(int year) => new(year, 7, 14);

        public static DateTime GetAssumptionOfMaryDay(int year) => new(year, 8, 15);

        public static DateTime GetAllSaintsDay(int year) => new(year, 11, 1);

        public static DateTime GetArmisticeDay(int year) => new(year, 11, 11);

        public static DateTime GetChristmasDay(int year) => new(year, 12, 25);

        private static (int month, int day) ExecuteEasterDayAlgorithm(int year)
        {
            int g = (year / 100 - (year / 100 + 8) / 25 + 1) / 3;
            int h = (19 * (year % 19) + year / 100 - year / 100 / 4 - g + 15) % 30;
            int l = (32 + 2 * (year / 100 % 4) + 2 * (year % 100 / 4) - h - year % 100 % 4) % 7;
            int m = (year % 19 + 11 * h + 22 - l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = (h + l - 7 * m + 114) % 31 + 2;

            return (month, day);
        }
    }
}