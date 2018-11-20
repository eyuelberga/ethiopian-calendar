using System;
namespace EthiopianCalendar
{
    /// <summary>
    /// contains methods to check if a date is valid according to the Ethiopian calendar standard.
    /// </summary>
    static public class EtDateValidator
    {
        /// <summary>
        /// Check if the day is in a valid range
        /// </summary>
        /// <returns><c>true</c>, if valid day range was used, <c>false</c> otherwise.</returns>
        public static bool IsValidDayRange(int day)
        {
            return day >= (int)DATE_CONFIG.FIRST_DAY &&
            day <= (int)DATE_CONFIG.LAST_DAY;
        }


        /// <summary>
        /// check if the month is in a valid range
        /// </summary>
        /// <returns><c>true</c>, if valid month range was used, <c>false</c> otherwise.</returns>
        /// <param name="month">Month.</param>
        public static bool IsValidMonthRange(int month)
        {
            return month >= (int)DATE_CONFIG.FIRST_MONTH &&
            month <= (int)DATE_CONFIG.LAST_MONTH;
        }

        /// <summary>
        /// Check if the day is in the valid range, considering it is the pagume month(the 13th month in the calendar)
        /// </summary>
        /// <returns><c>true</c>, if valid pagume day range was used, <c>false</c> otherwise.</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        public static bool IsValidPagumeDayRange(int day, int month)
        {
            return month == (int)DATE_CONFIG.LAST_MONTH ? day <= (int)DATE_CONFIG.PAGUME_LEAP_YEAR_LAST_DAY : IsValidDayRange(day);
        }

        /// <summary>
        /// Check if it is a leap year.
        /// </summary>
        /// <returns><c>true</c>, if leap year was used, <c>false</c> otherwise.</returns>
        /// <param name="year">Year.</param>
        public static bool IsLeapYear(int year)
        {
            return (year + 1) % 4 == 0;
        }

    }
}