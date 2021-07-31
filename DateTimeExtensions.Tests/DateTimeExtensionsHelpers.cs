using System;
using System.Collections.Generic;

namespace DateTimeExtensions.Tests
{
    public class DateTimeExtensionsHelpers
    {
        public static IReadOnlyCollection<object[]> GetNoHolidayDates => new List<object[]>
        {
            new object[] {2021, 7, 30},
            new object[] {2021, 8, 2},
            new object[] {2022, 1, 6},
            new object[] {2023, 6, 13},
            new object[] {2023, 6, 20},
            new object[] {2023, 6, 27}
        };

        public static IReadOnlyCollection<object[]> GetSundayDates => new List<object[]>
        {
            new object[] {2021, 1, 3},
            new object[] {2021, 1, 10},
            new object[] {2021, 1, 17},
            new object[] {2021, 1, 24},
            new object[] {2021, 1, 31},
            new object[] {2021, 2, 7},
            new object[] {2021, 2, 14},
            new object[] {2021, 2, 21},
            new object[] {2021, 2, 28},
            new object[] {2021, 3, 7},
            new object[] {2021, 3, 14},
            new object[] {2021, 3, 21},
            new object[] {2021, 3, 28},
            new object[] {2021, 4, 4},
            new object[] {2021, 4, 11},
            new object[] {2021, 4, 18},
            new object[] {2021, 4, 25},
            new object[] {2021, 5, 2},
            new object[] {2021, 5, 09},
            new object[] {2021, 5, 16},
            new object[] {2021, 5, 23},
            new object[] {2021, 5, 30},
            new object[] {2021, 6, 6},
            new object[] {2021, 6, 13},
            new object[] {2021, 6, 20},
            new object[] {2021, 6, 27},
            new object[] {2021, 7, 4},
            new object[] {2021, 7, 11},
            new object[] {2021, 7, 18},
            new object[] {2021, 7, 25},
            new object[] {2021, 8, 1},
            new object[] {2021, 8, 8},
            new object[] {2021, 8, 15},
            new object[] {2021, 8, 22},
            new object[] {2021, 8, 29},
            new object[] {2021, 9, 5},
            new object[] {2021, 9, 12},
            new object[] {2021, 9, 19},
            new object[] {2021, 9, 26},
            new object[] {2021, 10, 3},
            new object[] {2021, 10, 10},
            new object[] {2021, 10, 17},
            new object[] {2021, 10, 24},
            new object[] {2021, 10, 31},
            new object[] {2021, 11, 7},
            new object[] {2021, 11, 14},
            new object[] {2021, 11, 21},
            new object[] {2021, 11, 28},
            new object[] {2021, 12, 5},
            new object[] {2021, 12, 12},
            new object[] {2021, 12, 19},
            new object[] {2021, 12, 26}
        };

        public static IReadOnlyCollection<object[]> GetHolidayDatesIn2021 => new List<object[]>
        {
            new object[] {2021, 1, 1},
            GetEasterDateIn2021,
            new object[] {2021, 5, 1},
            new object[] {2021, 5, 8},
            GetAscensionDateIn2021,
            GetWhitDateIn2021,
            new object[] {2021, 7, 14},
            new object[] {2021, 8, 15},
            new object[] {2021, 11, 1},
            new object[] {2021, 11, 11},
            new object[] {2021, 12, 25}
        };

        public static IReadOnlyCollection<object[]> GetHolidayDatesIn2022 => new List<object[]>
        {
            new object[] {2022, 01, 1},
            GetEasterDateIn2022,
            new object[] {2022, 05, 1},
            new object[] {2022, 05, 8},
            GetAscensionDateIn2022,
            GetWhitDateIn2022,
            new object[] {2022, 07, 14},
            new object[] {2022, 08, 15},
            new object[] {2022, 11, 1},
            new object[] {2022, 11, 11},
            new object[] {2022, 12, 25},
        };

        public static IReadOnlyCollection<object[]> GetHolidayDatesIn2023 => new List<object[]>
        {
            new object[] {2023, 1, 1},
            GetEasterDateIn2023,
            new object[] {2023, 5, 1},
            new object[] {2023, 5, 8},
            GetAscensionDateIn2023,
            GetWhitDateIn2023,
            new object[] {2023, 7, 14},
            new object[] {2023, 8, 15},
            new object[] {2023, 11, 1},
            new object[] {2023, 11, 11},
            new object[] {2023, 12, 25}
        };

        public static object[] GetEasterDateIn2021 => new object[] {2021, 4, 5};
        public static object[] GetEasterDateIn2022 => new object[] {2022, 04, 18};
        public static object[] GetEasterDateIn2023 => new object[] {2023, 4, 10};
        
        public static object[] GetAscensionDateIn2021 => new object[] {2021, 5, 13};
        public static object[] GetAscensionDateIn2022 => new object[] {2022, 5, 26};
        public static object[] GetAscensionDateIn2023 => new object[] {2023, 5, 18};
        
        public static object[] GetWhitDateIn2021 => new object[] {2021, 5, 24};
        public static object[] GetWhitDateIn2022 => new object[] {2022, 6, 6};
        public static object[] GetWhitDateIn2023 => new object[] {2023, 5, 29};

        public static Dictionary<int, DateTime> GetEasterDateByYear => new()
        {
            {2021, new DateTime(2021, 4, 5)},
            {2022, new DateTime(2022, 4, 18)},
            {2023, new DateTime(2023, 4, 10)}
        };
        
        public static Dictionary<int, DateTime> GetAscensionDateByYear => new()
        {
            {2021, new DateTime(2021, 5, 13)},
            {2022, new DateTime(2022, 5, 26)},
            {2023, new DateTime(2023, 5, 18)}
        }; 
        
        public static Dictionary<int, DateTime> GetWhitDateByYear => new()
        {
            {2021, new DateTime(2021, 5, 24)},
            {2022, new DateTime(2022, 6, 6)},
            {2023, new DateTime(2023, 5, 29)}
        }; 
    }
}