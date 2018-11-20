using System;
namespace EthiopianCalendar
{
    /// <summary>
    /// contains methods to check if a date is valid according to the Ethiopian calendar standard.
    /// </summary>
    static public class EtDateValidator
    {
        public static bool IsValidDayRange(int day)
        {
            return day >= (int)DATE_CONFIG.FIRST_DAY &&
            day <= (int)DATE_CONFIG.LAST_DAY;
        }
    }
}