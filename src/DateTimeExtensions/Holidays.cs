using System;
using System.Collections.Generic;
using System.Linq;

namespace DateTimeExtensions
{
    public static class Holidays
    {
        public static bool IsSunday(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsHoliday(DateTime dateTime)
        {
            return AllHolidays(dateTime.Year).Any(holiday => DateTime.Compare(holiday, dateTime) == 0);
        }

        public static bool IsHolidayOrSunday(DateTime dateTime)
        {
            return IsSunday(dateTime) || IsHoliday(dateTime);
        }

        private static IReadOnlyCollection<DateTime> AllHolidays(int year)
        {
            return new List<DateTime>()
            {
                Easter(year),
                Ascension(year),
                Whit(year),
                NewYear(year),
                Labor(year),
                WorldWarTwo(year),
                Bastille(year),
                AssumptionOfMary(year),
                AllSaints(year),
                Armistice(year),
                Christmas(year)
            };
        }

        public static DateTime Easter(int year)
        {
            var (month, day) = ExecuteEasterAlgorithm(year);

            return new DateTime(year, month, day);
        }

        public static DateTime Ascension(int year) => Easter(year).AddDays(38);

        public static DateTime Whit(int year) => Easter(year).AddDays(49);

        public static DateTime NewYear(int year) => new(year, 1, 1);

        public static DateTime Labor(int year) => new(year, 5, 1);

        public static DateTime WorldWarTwo(int year) => new(year, 5, 8);

        public static DateTime Bastille(int year) => new(year, 7, 14);

        public static DateTime AssumptionOfMary(int year) => new(year, 8, 15);

        public static DateTime AllSaints(int year) => new(year, 11, 1);

        public static DateTime Armistice(int year) => new(year, 11, 11);

        public static DateTime Christmas(int year) => new(year, 12, 25);

        private static (int month, int day) ExecuteEasterAlgorithm(int year)
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