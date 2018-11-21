using System;
namespace EthiopianCalendar
{
    /// <summary>
    /// A child class of Calender, used for generating text based calendar on the console.
    /// </summary>
    public class TextCalendar : Calendar
    {
        /// <summary>
        /// Formats the week header.
        /// </summary>
        /// <returns>The week header.</returns>
        public string FormatWeekHeader()
        {
            string header = "";
            foreach (int x in IterWeekDays())
            {
                header += $"{EthiopianLocalized.GetWeekDayName(x)}\t";
            }
            return header;
        }
        /// <summary>
        /// Formats the month dates.
        /// </summary>
        /// <returns>The month date.</returns>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public string FormatMonthDate(int month, int year)
        {
            string dates = "";
            Date[,] matrix = MonthDateCalendar(month, year);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                dates += "\n";
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == null)
                    {
                        dates += "\t";
                    }
                    else
                    {
                        dates += $"{matrix[row, col].PrintDay()}\t";
                    }
                }
            }

            return dates;
        }
        /// <summary>
        /// Formats the month header.
        /// </summary>
        /// <returns>The month header.</returns>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public string FormatMonthHeader(int month, int year)
        {
            return $"{EthiopianLocalized.GetMonthName(month)}, {year}";
        }
        /// <summary>
        /// Prints the month calendar.
        /// </summary>
        /// <returns>The month calendar.</returns>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public string PrintMonthCalendar(int month, int year)
        {
            return $"{FormatMonthHeader(month, year)}\n\n{FormatWeekHeader()}\n{FormatMonthDate(month, year)}\n";
        }
        /// <summary>
        /// Prints the year calendar.
        /// </summary>
        /// <returns>The year calendar.</returns>
        /// <param name="year">Year.</param>
        public string PrintYearCalendar(int year)
        {
            string yearCalendar = "";
            for (int i = 1; i <= 13; i++)
            {
                yearCalendar += $"{PrintMonthCalendar(i, year)}\n";
            }
            return yearCalendar;
        }

    }
}