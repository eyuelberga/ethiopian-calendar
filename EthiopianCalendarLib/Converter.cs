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
    }
}
