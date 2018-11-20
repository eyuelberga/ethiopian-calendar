using System;
namespace EthiopianCalendar
{
    public class TextCalendar : Calendar
    {
        public string FormatWeekHeader()
        {
            string header = "";
            foreach (int x in IterWeekDays())
            {
                header += $"{EthiopianLocalized.GetWeekDayName(x)}\t";
            }
            return header;
        }
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
        public string FormatMonthHeader(int month, int year)
        {
            return $"{EthiopianLocalized.GetMonthName(month)}, {year}";
        }
        public string PrintMonthCalendar(int month, int year)
        {
            return $"{FormatMonthHeader(month, year)}\n\n{FormatWeekHeader()}\n{FormatMonthDate(month, year)}\n";
        }
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