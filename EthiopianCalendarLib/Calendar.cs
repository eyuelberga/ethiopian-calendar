using System.Collections.Generic;

namespace EthiopianCalendar
{
    /// <summary>
    /// Base Calendar class to perform basic calendar functions without any formatting.
    /// </summary>
    public class Calendar
    {
        public int FirstWeekDay = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EthiopianCalendar.Calendar"/> class.
        /// </summary>
        public Calendar()
        {
            //TODO add functionality to specify the first week day; problem on the month ordering
        }

        /// <summary>
        /// Iterator for the week days.
        /// </summary>
        /// <returns>an iterator for one week of weekday numbers starting with the
        ///configured first week day.</returns>
        public IEnumerable<int> IterWeekDays()
        {
            for (int i = FirstWeekDay; i < FirstWeekDay + 7; i++)
            {
                yield return i % 7;
            }
        }
    }
}