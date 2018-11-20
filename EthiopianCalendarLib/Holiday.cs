namespace EthiopianCalendar
{
    /// <summary>
    /// Used for checking if a date is a holiday or a special day
    /// </summary>
    public static class Holiday
    {
        /// <summary>
        /// Check if the date is a new year.
        /// </summary>
        /// <returns><c>true</c>, if it is a new year <c>false</c> otherwise.</returns>
        /// <param name="date">Date.</param>
        public static bool IsNewYear(Date date)
        {
            return date.Month == 1 && date.Day == 1;
        }
        /// <summary>
        /// Check if the date is Meskel( Finding of the True Cross)
        /// </summary>
        /// <returns><c>true</c>,if the date is Meskel( Finding of the True Cross),<c>false</c> otherwise.</returns>
        /// <param name="date">Date.</param>
        public static bool IsTrueCross(Date date)
        {
            return date.Month == 1 && date.Day == 17;
        }
        /// <summary>
        /// Check if the date is Christmas
        /// </summary>
        /// <returns><c>true</c>, if the date is Christmas, <c>false</c> otherwise.</returns>
        /// <param name="date">Date.</param>
        public static bool ISChristmas(Date date)
        {
            return EtDateValidator.IsLeapYear(date.Year) ? date.Month == 4 && date.Day == 29 : date.Month == 4 && date.Day == 28;
        }
        /// <summary>
        /// Check if the date is Epiphany
        /// </summary>
        /// <returns><c>true</c>, if the date is Epiphany, <c>false</c> otherwise.</returns>
        /// <param name="date">Date.</param>
        public static bool IsEpiphany(Date date)
        {
            return date.Month == 5 && date.Day == 11;
        }
        /// <summary>
        /// Check if the date is the victory if Adwa
        /// </summary>
        /// <returns><c>true</c>, if the date is the victory if Adwa, <c>false</c> otherwise.</returns>
        /// <param name="date">Date.</param>
        public static bool IsAdwa(Date date)
        {
            return date.Month == 6 && date.Day == 23;
        }
        /// <summary>
        /// Check if the date is Ethiopian Patriots Day
        /// </summary>
        /// <returns><c>true</c>, if the date is Ethiopian Patriots Day, <c>false</c> otherwise.</returns>
        /// <param name="date">Date.</param>
        public static bool IsPatriots(Date date)
        {
            return date.Month == 8 && date.Day == 27;
        }
        /// <summary>
        /// Check if the date is International Labour Day
        /// </summary>
        /// <returns><c>true</c>, if the date is International Labour Day, <c>false</c> otherwise.</returns>
        /// <param name="date">Date.</param>
        public static bool IsLabour(Date date)
        {
            return date.Month == 8 && date.Day == 23;
        }
        /// <summary>
        /// Check if the date is Downfall of Dergue
        /// </summary>
        /// <returns><c>true</c>, if the date is Downfall of Dergue, <c>false</c> otherwise.</returns>
        /// <param name="date">Date.</param>
        public static bool IsDerg(Date date)
        {
            return date.Month == 9 && date.Day == 20;
        }
        /// <summary>
        /// Check if the date is a Holiday in general
        /// </summary>
        /// <returns><c>true</c>, if the date is a Holiday, <c>false</c> otherwise.</returns>
        /// <param name="date">Date.</param>
        public static bool IsHoliday(Date date)
        {
            return IsAdwa(date) || IsDerg(date) || IsLabour(date) || IsNewYear(date)
                || IsEpiphany(date) || IsPatriots(date) || IsTrueCross(date) || ISChristmas(date);

        }
        /// <summary>
        /// Return the Name if the Holiday in a readable string
        /// </summary>
        /// <returns>The name string</returns>
        /// <param name="date">Date.</param>
        public static string HolidayName(Date date)
        {
            return IsAdwa(date)
                ? "Victory of Adwa"
                : IsDerg(date)
                ? "Downfall of the Dergue"
                : IsLabour(date)
                ? "International Labour Day"
                : IsNewYear(date)
                ? "New Year"
                : IsEpiphany(date)
                ? "Epiphany"
                : IsPatriots(date)
                ? "Ethiopian Patriots Day" : IsTrueCross(date)
                ? "Finding of the True Cross" : ISChristmas(date)
                ? "Christmas" : null;
        }

    }
}