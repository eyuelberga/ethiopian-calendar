using System;
namespace EthiopianCalendar
{
    public class InvalidMonthException : Exception
    {
        public InvalidMonthException()
            : base("Invalid Month Range; valid range is 1-13")
        {
        }
    }
    public class InvalidDayException : Exception
    {
        public InvalidDayException()
            : base("Invalid Day Range; valid range is 1-30")
        {
        }
    }
    public class InvalidPagumeDayException : Exception
    {
        public InvalidPagumeDayException()
            : base("Invalid Pagume Day Range; valid range is 1-6")
        {
        }
    }
    public class InvalidGMonthException : Exception
    {
        public InvalidGMonthException()
            : base("Invalid Month Range; valid range is 1-12")
        {
        }
    }
    public class InvalidDateArray : Exception
    {
        public InvalidDateArray()
            : base("Invalid Date Array Length; valid length is 3")
        {
        }
    }
}
