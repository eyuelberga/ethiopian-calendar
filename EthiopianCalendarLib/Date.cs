using System;
namespace EthiopianCalendar
{
    /// <summary>
    /// Date Class. 
    /// </summary>
    public class Date
    {
        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>The day.</value>
        public int Day { get; set; }
        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        /// <value>The month.</value>
        public int Month { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year { get; set; }
        /// <summary>
        /// Gets or sets the week day number.
        /// </summary>
        /// <value>The week day number.</value>
        public int WeekDayNumber { get; set; }
        /// <summary>
        /// Gets or sets the special. This will hold the holiday or other special ocassion 
        /// </summary>
        /// <value>The special.</value>
        public string Special { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EthiopianCalendar.Date"/> class.
        /// </summary>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public Date(int day, int month, int year)
        {
            if (EtDateValidator.IsValid(day, month, year))
            {
                Day = day;
                Month = month;
                Year = year;
                WeekDayNumber = Converter.EthiopianWeekDayNumber(day, month, year);
                Special = Holiday.IsHoliday(this) ? Holiday.HolidayName(this) : null;
            }
            if (!EtDateValidator.IsValidDayRange(day))
            {
                throw new InvalidDayException();
            }
            if (!EtDateValidator.IsValidMonthRange(month))
            {
                throw new InvalidMonthException();
            }
            if (!EtDateValidator.IsValidPagumeDayRange(day, month))
            {
                throw new InvalidPagumeDayException();
            }

        }
        /// <summary>
        /// Print this instance.
        /// </summary>
        /// <returns>The print.</returns>
        public string Print()
        {
            return $"---{WeekDayNumber},{Day},{Month},{Year}";
        }
        /// <summary>
        /// Prints the day.
        /// </summary>
        /// <returns>The day.</returns>
        public string PrintDay()
        {
            return $"{Day}";
        }
        /// <summary>
        /// Prints the name of the day.
        /// </summary>
        /// <returns>The day name.</returns>
        public string PrintDayName()
        {
            return $"{EthiopianLocalized.GetWeekDayName(WeekDayNumber)}";
        }
        /// <summary>
        /// Prints the special.
        /// </summary>
        /// <returns>The special.</returns>
        public string PrintSpecial()
        {
            return Special ?? null;
        }
    }
}