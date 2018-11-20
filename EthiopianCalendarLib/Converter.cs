using System;
namespace EthiopianCalendar
{
    /// <summary>
    /// Convert Gregorian to Ethiopian and Viceversa, also include methods for JDN(Julian Date Number) calculation.
    /// </summary>
    public static class Converter
    {

        /// <summary>
        /// Convert Gregorian Date into JDN(Julian Date Number). The algorithm is valid for all (possibly proleptic) Gregorian calendar dates after November 23, −4713.
        /// </summary>
        /// <returns>JDN number integer value.</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public static int GregorianToJDN(int day = 1, int month = 1, int year = 1)
        {
            //TODO error exception if not valid gregorian date
            return ((int)JDN_CONST._1461 * (year + (int)JDN_CONST._4800 + (month - (int)JDN_CONST._14) / (int)JDN_CONST._12))
                / (int)JDN_CONST._4 + ((int)JDN_CONST._367 * (month - (int)JDN_CONST._2 - (int)JDN_CONST._12 * ((month - (int)JDN_CONST._14) / (int)JDN_CONST._12))) /
                (int)JDN_CONST._12 - ((int)JDN_CONST._3 * ((year + (int)JDN_CONST._4900 + (month - (int)JDN_CONST._14) / (int)JDN_CONST._12) / (int)JDN_CONST._100)) /
                (int)JDN_CONST._4 + day - (int)JDN_CONST._32075;

        }

        /// <summary>
        /// Convert JDN(Julian Date Number) into Gregorian Date.
        /// This is an algorithm by Richards to convert a Julian Day Number, to a date in the Gregorian calendar. 
        /// Richards states the algorithm is valid for Julian day numbers greater than or equal to 0.
        /// </summary>
        /// <returns>The Gregorian Date array in the format [Day, Month, Year] </returns>
        /// <param name="J">J.</param>
        public static int[] JDNToGregorian(int J)
        {

            int f = (int)(J + (int)RICHARDS_PARA.j + ((int)((int)RICHARDS_PARA.four * J + RICHARDS_PARA.B) / (int)RICHARDS_PARA.hundredthousands) * (int)RICHARDS_PARA.three / (int)RICHARDS_PARA.four + RICHARDS_PARA.C);
            int e = (int)((int)RICHARDS_PARA.r * f + RICHARDS_PARA.v);
            int g = e % (int)RICHARDS_PARA.p / (int)RICHARDS_PARA.r;
            int h = (int)((int)RICHARDS_PARA.u * g + RICHARDS_PARA.w);
            int day = h % (int)RICHARDS_PARA.s / (int)RICHARDS_PARA.u + (int)RICHARDS_PARA.one;
            int month = (h / (int)RICHARDS_PARA.s + (int)RICHARDS_PARA.m) % (int)RICHARDS_PARA.n + (int)RICHARDS_PARA.one;
            int year = (int)((e / (int)RICHARDS_PARA.p) - RICHARDS_PARA.y + (int)(RICHARDS_PARA.n + (int)RICHARDS_PARA.m - month) / (int)RICHARDS_PARA.n);
            int[] date = { day, month, year };
            return date;
        }

        /// <summary>
        /// Convert JDN(Julian Date Number) into Ethiopian Date.
        /// </summary>
        /// <returns>The Ethiopian Date array in the format [Day, Month, Year] </returns>
        /// <param name="jdn">Jdn.</param>
        /// <param name="era">Era. Defines if it is `Amete miheret` or `Amete alem`, 
        /// the Ethiopian equivalents to A.D and B.C respectively.
        /// Possible values are JDN_EPOCH_OFFSET.AMETE_MIHRET or DN_EPOCH_OFFSET.AMETE_ALEM </param>
        public static int[] JDNToEthiopian(int jdn, int era = (int)JDN_EPOCH_OFFSET.AMETE_MIHRET)
        {
            int r = (jdn - era) % (int)JDN_CONST._1461;
            int n = (int)((r % (int)JDN_CONST._365) + (int)JDN_CONST._365 * Math.Floor((double)r / (int)JDN_CONST._1460));

            int year = (int)((int)JDN_CONST._4 * Math.Floor((double)(jdn - era) / (int)JDN_CONST._1461) + Math.Floor((double)r / (int)JDN_CONST._365) - Math.Floor((double)r / (int)JDN_CONST._1460));
            int month = (int)(Math.Floor((double)n / (int)JDN_CONST._30) + (int)JDN_CONST._1);
            int day = n % (int)JDN_CONST._30 + (int)JDN_CONST._1;
            int[] date = { day, month, year };
            return date;
        }

        /// <summary>
        /// Convert Ethiopian Date into JDN(Julian Date Number).
        /// </summary>
        /// <returns>JDN number integer value.</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        /// <param name="era">Era. Defines if it is `Amete miheret` or `Amete alem`, 
        /// the Ethiopian equivalents to A.D and B.C respectively.
        /// Possible values are JDN_EPOCH_OFFSET.AMETE_MIHRET or JDN_EPOCH_OFFSET.AMETE_ALEM </param>
        public static int EthiopianToJDN(int day, int month, int year, int era = (int)JDN_EPOCH_OFFSET.AMETE_MIHRET)
        {
            if (EtDateValidator.IsValid(day, month, year))
            {
                return (int)(era + (int)JDN_CONST._365 + (int)JDN_CONST._365 * 
                             (year - (int)JDN_CONST._1) + Math.Floor((double)year / 
                             (int)JDN_CONST._4) + (int)JDN_CONST._30 * month + day - (int)JDN_CONST._31);
            }
            //TODO error exception
            return 0;

        }

        /// <summary>
        /// Convert Gregorian Date into Ethiopian Date
        /// </summary>
        /// <returns>The Ethiopian Date array in the format [Day, Month, Year]</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public static int[] GregorianToEthiopian(int day, int month, int year)
        {
            int jdn = GregorianToJDN(day, month, year);
            return JDNToEthiopian(jdn);
        }

        /// <summary>
        /// Convert Gregorian Date into Ethiopian Date
        /// </summary>
        /// <returns>The Ethiopian Date array in the format [Day, Month, Year]</returns>
        /// <param name="dateArray">Date array, in the format [Day, Month, Year]</param>
        public static int[] GregorianToEthiopian(int[] dateArray)
        {
            if (dateArray.Length == 3)
            {
                int jdn = GregorianToJDN(dateArray[0], dateArray[1], dateArray[2]);
                return JDNToEthiopian(jdn);
            }
            else
            {
                // TODO Throw an error exception
                return null;
            }
        }

        /// <summary>
        /// Convert Ethiopian Date into Gregorian Date 
        /// </summary>
        /// <returns>The Gregorian Date array in the format [Day, Month, Year]</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        /// <param name="era">Era. Defines if it is `Amete miheret` or `Amete alem`, 
        /// the Ethiopian equivalents to A.D and B.C respectively.
        /// Possible values are JDN_EPOCH_OFFSET.AMETE_MIHRET or JDN_EPOCH_OFFSET.AMETE_ALEM </param>
        public static int[] EthiopianToGregorian(int day, int month, int year, int era = (int)JDN_EPOCH_OFFSET.AMETE_MIHRET)
        {
            int jdn = EthiopianToJDN(day, month, year, era);
            return JDNToGregorian(jdn);
        }

        /// <summary>
        /// Convert Ethiopian Date into Gregorian Date 
        /// </summary>
        /// <returns>he Gregorian Date array in the format [Day, Month, Year].</returns>
        /// <param name="dateArray">Date array, in the format [Day, Month, Year].</param>
        /// <param name="era">Era. Defines if it is `Amete miheret` or `Amete alem`, 
        /// the Ethiopian equivalents to A.D and B.C respectively.
        /// Possible values are JDN_EPOCH_OFFSET.AMETE_MIHRET or JDN_EPOCH_OFFSET.AMETE_ALEM </param>
        public static int[] EthiopianToGregorian(int[] dateArray, int era = (int)JDN_EPOCH_OFFSET.AMETE_MIHRET)
        {
            if (dateArray.Length == 3)
            {
                int jdn = EthiopianToJDN(dateArray[0], dateArray[1], dateArray[2], era);
                return JDNToGregorian(jdn);
            }
            else
            {
                // TODO Throw an error exception
                return null;
            }

        }

        /// <summary>
        /// Calculates the index of the week day, given a Gregorian calendar date
        /// </summary>
        /// <returns>The week day index.</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public static int GetWeekDayNumber(int day, int month, int year)
        {
            //TODO error exception if the date is invalid
            int a = (14 - month) / 12;
            int y = year - a;
            int m = month + 12 * a - 2;
            int d = (day + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;
            return d;
        }


        /// <summary>
        /// Finds the Week day form a Gregorian calendar date.
        /// </summary>
        /// <returns>The week day string</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public static string GregorianWeekDay(int day, int month, int year)
        {
            int index = GetWeekDayNumber(day, month, year);
            return EnglishLocalized.GetWeekDayName(index);
        }

        /// <summary>
        /// Finds the Week day form an Ethiopian calendar date.
        /// </summary>
        /// <returns>The week day string</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public static string EthiopianWeekDay(int day, int month, int year)
        {
            int[] date = EthiopianToGregorian(day, month, year);
            int index = GetWeekDayNumber(date[0], date[1], date[2]);
            return EthiopianLocalized.GetWeekDayName(index);
        }
        /// <summary>
        /// Finds the Week day Number form an Ethiopian calendar date.
        /// </summary>
        /// <returns>The week day number.</returns>
        /// <param name="day">Day.</param>
        /// <param name="month">Month.</param>
        /// <param name="year">Year.</param>
        public static int EthiopianWeekDayNumber(int day, int month, int year)
        {
            int[] date = EthiopianToGregorian(day, month, year);
            return GetWeekDayNumber(date[0], date[1], date[2]);
        }


    }
}
