using System;
namespace EthiopianCalendar
{
    public class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int WeekDayNumber { get; set; }
        public string Special { get; set; }

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
            else
            {
                //TODO exeption error invalid date 
            }

        }
        public string Print()
        {
            return $"---{WeekDayNumber},{Day},{Month},{Year}";
        }
        public string PrintDay()
        {
            return $"{Day}";
        }
        public string PrintDayName()
        {
            return $"{EthiopianLocalized.GetWeekDayName(WeekDayNumber)}";
        }
        public string PrintDateH()
        {
            return Special == null ? $"{Day}" : $"*";
        }
    }
}