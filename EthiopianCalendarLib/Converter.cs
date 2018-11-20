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
            int r = (jdn - era) % 1461;
            int n = (int)((r % 365) + 365 * Math.Floor((double)r / 1460));

            int year = (int)(4 * Math.Floor((double)(jdn - era) / 1461) + Math.Floor((double)r / 365) - Math.Floor((double)r / 1460));
            int month = (int)(Math.Floor((double)n / 30) + 1);
            int day = n % 30 + 1;
            int[] date = { day, month, year };
            return date;
        }
    }
}
