using System;
namespace EthiopianCalendar
{
    /// <summary>
    /// Contains methods to get the names of week days and months in Amharic(Ethiopian national language)
    /// </summary>
    public static class EthiopianLocalized
    {
        /// <summary>
        /// Gets the name of the week day.
        /// </summary>
        /// <returns>The week day name.</returns>
        /// <param name="weekDay">Week day.</param>
        public static string GetWeekDayName(int weekDay)
        {
            string[] WEEK_NAMES = { "እሑድ", "ሰኞ", "ማክሰኞ", "ረቡዕ", "ሓሙስ", "ዓርብ", "ቅዳሜ" };

            if (weekDay >= WEEK_NAMES.Length)
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
                                      "መስከረም",
                                      "ጥቅምት",
                                      "ኅዳር",
                                      "ታኅሣሥ",
                                      "ጥር",
                                      "የካቲት",
                                      "መጋቢት",
                                      "ሚያዝያ",
                                      "ግንቦት",
                                      "ሰኔ",
                                      "ሐምሌ",
                                      "ነሐሴ",
                                      "ጳጉሜ"
            };

            if (month >= MONTH_NAMES.Length)
            {
                throw new InvalidMonthIndex();
            }

                return MONTH_NAMES[month];


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
                                      "መስከ",
                                      "ጥቅም",
                                      "ኅዳር",
                                      "ታኅሣ",
                                      "ጥር",
                                      "የካቲ",
                                      "መጋቢ",
                                      "ሚያዝ",
                                      "ግንቦ",
                                      "ሰኔ",
                                      "ሐምሌ",
                                      "ነሐሴ",
                                      "ጳጉሜ"
            };

            if (month > MONTH_NAMES.Length)
            {
                throw new InvalidMonthIndex();
            }
                return MONTH_NAMES[month];
        }

    }
}