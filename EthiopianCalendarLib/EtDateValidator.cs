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

        /// <summary>
        /// Check if date is valid for a leap day. Leap days happen every leap year, when the 13th month extends from its 5 day range to 6 days.
        /// </summary>
        /// <returns><c>true</c>, if the date is valid, <c>false</c>if the date chossen was a leap day on the 13th month, but on a non-leap year </returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public static bool IsValidLeapDay(int day, int month, int year)
        {
            return month != (int)DATE_CONFIG.LAST_MONTH || day != (int)DATE_CONFIG.PAGUME_LEAP_YEAR_LAST_DAY
 || IsLeapYear(year)
;
        }
    }
}