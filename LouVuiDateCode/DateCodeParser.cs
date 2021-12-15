using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LouVuiDateCode
{
    public static class DateCodeParser
    {
        /// <summary>
        /// Parses a date code and returns a <see cref="manufacturingYear"/> and <see cref="manufacturingMonth"/>.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            manufacturingYear = 0;
            manufacturingMonth = 0;

            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            uint.TryParse("19" + dateCode[..2], out manufacturingYear);
            uint.TryParse(dateCode[2..], out manufacturingMonth);

            if (manufacturingYear < 1980 || manufacturingYear > 1989 || manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentException("dateCode is wrong!", nameof(dateCode));
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            factoryLocationCountry = Array.Empty<Country>();
            factoryLocationCode = string.Empty;
            manufacturingYear = 0;
            manufacturingMonth = 0;

            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            uint.TryParse("19" + dateCode[..2], out manufacturingYear);
            uint.TryParse(dateCode[2..^2], out manufacturingMonth);

            factoryLocationCode = dateCode[^2..];
            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);

            if (manufacturingYear < 1980 || manufacturingYear > 1989 || manufacturingMonth < 1 ||
                manufacturingMonth > 12 || factoryLocationCountry.Length == 0)
            {
                throw new ArgumentException("dateCode is wrong!", nameof(dateCode));
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            factoryLocationCountry = Array.Empty<Country>();
            factoryLocationCode = string.Empty;
            manufacturingYear = 0;
            manufacturingMonth = 0;

            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (!new Regex(@"^\D{2}\d{4}$").IsMatch(dateCode))
            {
                throw new ArgumentException("factoryLocationCode is wrong!", nameof(factoryLocationCode));
            }

            factoryLocationCode = dateCode[..2];
            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
            string century = dateCode[3] == '0' ? "20" : "19";

            uint.TryParse(century + dateCode[3] + dateCode[5], out manufacturingYear);
            uint.TryParse(string.Empty + dateCode[2] + dateCode[4], out manufacturingMonth);

            if (manufacturingYear < 1990 || manufacturingYear > 2006 || manufacturingMonth < 1 ||
                manufacturingMonth > 12 || factoryLocationCountry.Length == 0)
            {
                throw new ArgumentException("dateCode is wrong!", nameof(dateCode));
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingWeek"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingWeek">A manufacturing month to return.</param>
        public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
        {
            factoryLocationCountry = Array.Empty<Country>();
            factoryLocationCode = string.Empty;
            manufacturingYear = 0;
            manufacturingWeek = 0;

            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (!new Regex(@"^\D{2}\d{4}$").IsMatch(dateCode))
            {
                throw new ArgumentException("factoryLocationCode is wrong!", nameof(factoryLocationCode));
            }

            factoryLocationCode = dateCode[..2];
            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);

            uint.TryParse("20" + dateCode[3] + dateCode[5], out manufacturingYear);
            uint.TryParse(string.Empty + dateCode[2] + dateCode[4], out manufacturingWeek);

            Calendar calendar = CultureInfo.InvariantCulture.Calendar;

            if (factoryLocationCountry.Length == 0 || manufacturingYear < 2007 || manufacturingWeek < 1 ||
                manufacturingWeek > calendar.GetWeekOfYear(new DateTime((int)manufacturingYear, 12, 31), CalendarWeekRule.FirstFullWeek, DayOfWeek.Thursday))
            {
                throw new ArgumentException("dateCode is wrong!", nameof(dateCode));
            }
        }
    }
}
