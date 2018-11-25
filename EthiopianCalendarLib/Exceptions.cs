using System;
namespace EthiopianCalendar
{
    /// <summary>
    /// Invalid month exception.
    /// </summary>
    public class InvalidMonthException : Exception
    {
        public InvalidMonthException()
            : base("Invalid Month Range; valid range is 1-13")
        {
        }
    }
    /// <summary>
    /// Invalid day exception.
    /// </summary>
    public class InvalidDayException : Exception
    {
        public InvalidDayException()
            : base("Invalid Day Range; valid range is 1-30")
        {
        }
    }
    /// <summary>
    /// Invalid pagume day exception.
    /// </summary>
    public class InvalidPagumeDayException : Exception
    {
        public InvalidPagumeDayException()
            : base("Invalid Pagume Day Range; valid range is 1-6")
        {
        }
    }
    /// <summary>
    /// Invalid gregorian month exception.
    /// </summary>
    public class InvalidGMonthException : Exception
    {
        public InvalidGMonthException()
            : base("Invalid Month Range; valid range is 1-12")
        {
        }
    }
    /// <summary>
    /// Invalid date array exception.
    /// </summary>
    public class InvalidDateArrayException : Exception
    {
        public InvalidDateArrayException()
            : base("Invalid Date Array Length; valid length is 3")
        {
        }
    }
    /// <summary>
    /// Invalid week index exception.
    /// </summary>
    public class InvalidWeekIndexException : Exception
    {
        public InvalidWeekIndexException()
            :base("Week index out of bounds")
        {

        }
    }
    /// <summary>
    /// Invalid month index exception.
    /// </summary>
    public class InvalidMonthIndexException : Exception
    {
        public InvalidMonthIndexException()
            : base("Month index out of bounds")
        {

        }
    }
}
