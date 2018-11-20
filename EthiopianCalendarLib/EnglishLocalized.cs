using System;
namespace EthiopianCalendar
{
    /// <summary>
    /// Contains methods to get the names of week days and months in English
    /// </summary>
    public static class EnglishLocalized
    {
        /// <summary>
        /// Gets the name of the week day.
        /// </summary>
        /// <returns>The week day name.</returns>
        /// <param name="weekDay">Week day.</param>
        public static string GetWeekDayName(int weekDay)
        {
            string[] WEEK_NAMES = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            if (weekDay > WEEK_NAMES.Length)
            {
                //TODO error exception
                return null;
            }
            else
            {
                return WEEK_NAMES[weekDay];
            }
        }
        /// <summary>
        /// Gets the name of the month.
        /// </summary>
        /// <returns>The month name.</returns>
        /// <param name="month">Month.</param>
        public static string GetMonthName(int month)
        {
            string[] MONTH_NAMES = {
                                        null,
                                      "January",
                                      "Febuary",
                                      "March",
                                      "April",
                                      "May",
                                      "June",
                                      "July",
                                      "August",
                                      "September",
                                      "October",
                                      "November",
                                      "December"

            };

            if (month > MONTH_NAMES.Length)
            {
                //TODO error exception
                return null;
            }
            else
            {
                return MONTH_NAMES[month];
            }


        }
        /// <summary>
        /// Gets the month name short version.
        /// </summary>
        /// <returns>The month name short.</returns>
        /// <param name="month">Month.</param>
        public static string GetMonthNameShort(int month)
        {
            string[] MONTH_NAMES = {
                                       null,
                                      "Jan",
                                      "Feb",
                                      "Mar",
                                      "Apr",
                                      "May",
                                      "Jun",
                                      "Jul",
                                      "Aug",
                                      "Sep",
                                      "Oct",
                                      "Nov",
                                      "Dec"
            };

            if (month > MONTH_NAMES.Length)
            {
                //TODO error exception
                return null;
            }
            else
            {
                return MONTH_NAMES[month];
            }
        }

    }
}