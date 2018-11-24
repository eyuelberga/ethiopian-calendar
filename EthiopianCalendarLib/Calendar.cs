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

        /// <summary>
        /// terator for the month dates.
        /// </summary>
        /// <returns>an iterator for date objects starting from the start of the 
        /// month to the end</returns>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public IEnumerable<Date> IterMonthDates(int month, int year)
        {
            int dayIncrement = 1;
            while (EtDateValidator.IsValid(dayIncrement, month, year))
            {

                Date date = new Date(dayIncrement, month, year);
                yield return date;
                dayIncrement++;
            }
        }

        /// <summary>
        /// Month date Calendar generator for selected month and year.
        /// </summary>
        /// <returns> a matrix (2d array) of date objects representing a month's calendar, with each row representing a week.</returns>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public Date[,] MonthDateCalendar(int month, int year)
        {
            IEnumerable<Date> dates = IterMonthDates(month, year);
            IEnumerator<Date> date = dates.GetEnumerator();
            date.MoveNext();
            Date[,] matrix = new Date[6, 7];
            int weekNum = date.Current.WeekDayNumber;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) && date.MoveNext(); col++)
                {
                    if (row == 0)
                    {
                        if (col < weekNum)
                        {
                            continue;
                        }
                        if (col == weekNum)
                        {
                            date = dates.GetEnumerator();
                            date.MoveNext();
                            matrix[row, col] = date.Current;
                        }

                        if (col > weekNum)
                        {
                            matrix[row, col] = date.Current;
                        }
                    }
                    else
                    {
                        matrix[row, col] = date.Current;
                    }
                }
            }
           
            return matrix;
        }

       
    }
}