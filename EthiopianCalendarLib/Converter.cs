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
            return (1461 * (year + 4800 + (month - 14) / 12)) / 4 + (367 * (month - 2 - 12 * ((month - 14) / 12))) / 12 - (3 * ((year + 4900 + (month - 14) / 12) / 100)) / 4 + day - 32075;

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
    }
}
