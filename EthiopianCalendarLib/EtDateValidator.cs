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
    }
}