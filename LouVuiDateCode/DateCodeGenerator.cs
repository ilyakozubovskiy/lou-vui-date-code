using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LouVuiDateCode
{
    public static class DateCodeGenerator
    {
        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1980 || manufacturingYear > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            return manufacturingYear.ToString(CultureInfo.InvariantCulture)[2..] +
                   manufacturingMonth.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            if (manufacturingDate < new DateTime(1980, 1, 1) || manufacturingDate > new DateTime(1989, 12, 31))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            return manufacturingDate.Year.ToString(CultureInfo.InvariantCulture)[2..] +
                   manufacturingDate.Month.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!new Regex(@"^\D{2}$").IsMatch(factoryLocationCode))
            {
                throw new ArgumentException("factoryLocationCode is wrong!", nameof(factoryLocationCode));
            }

            if (manufacturingYear < 1980 || manufacturingYear > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            return manufacturingYear.ToString(CultureInfo.InvariantCulture)[2..] +
                   manufacturingMonth.ToString(CultureInfo.InvariantCulture) + factoryLocationCode.ToUpperInvariant();
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!new Regex(@"^\D{2}$").IsMatch(factoryLocationCode))
            {
                throw new ArgumentException("factoryLocationCode is wrong!", nameof(factoryLocationCode));
            }

            if (manufacturingDate < new DateTime(1980, 1, 1) || manufacturingDate > new DateTime(1989, 12, 31))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            return manufacturingDate.Year.ToString(CultureInfo.InvariantCulture)[2..] +
                   manufacturingDate.Month.ToString(CultureInfo.InvariantCulture) +
                   factoryLocationCode.ToUpperInvariant();
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!new Regex(@"^\D{2}$").IsMatch(factoryLocationCode))
            {
                throw new ArgumentException("factoryLocationCode is wrong!", nameof(factoryLocationCode));
            }

            if (manufacturingYear < 1990 || manufacturingYear > 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            return factoryLocationCode.ToUpperInvariant() +
                   manufacturingMonth.ToString("00", CultureInfo.InvariantCulture)[0] +
                   manufacturingYear.ToString(CultureInfo.InvariantCulture)[2] +
                   manufacturingMonth.ToString("00", CultureInfo.InvariantCulture)[1] +
                   manufacturingYear.ToString(CultureInfo.InvariantCulture)[3];
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!new Regex(@"^\D{2}$").IsMatch(factoryLocationCode))
            {
                throw new ArgumentException("factoryLocationCode is wrong!", nameof(factoryLocationCode));
            }

            if (manufacturingDate < new DateTime(1990, 1, 1) || manufacturingDate > new DateTime(2006, 12, 31))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            return factoryLocationCode.ToUpperInvariant() +
                   manufacturingDate.Month.ToString("00", CultureInfo.InvariantCulture)[0] +
                   manufacturingDate.Year.ToString(CultureInfo.InvariantCulture)[2] +
                   manufacturingDate.Month.ToString("00", CultureInfo.InvariantCulture)[1] +
                   manufacturingDate.Year.ToString(CultureInfo.InvariantCulture)[3];
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingWeek">A manufacturing week number.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!new Regex(@"^\D{2}$").IsMatch(factoryLocationCode))
            {
                throw new ArgumentException("factoryLocationCode is wrong!", nameof(factoryLocationCode));
            }

            if (manufacturingYear < 2007)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            Calendar calendar = CultureInfo.InvariantCulture.Calendar;

            if (manufacturingWeek < 1 || manufacturingWeek > calendar.GetWeekOfYear(new DateTime((int)manufacturingYear, 12, 31), CalendarWeekRule.FirstFullWeek, DayOfWeek.Thursday))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek));
            }

            return factoryLocationCode.ToUpperInvariant() +
                   manufacturingWeek.ToString("00", CultureInfo.InvariantCulture)[0] +
                   manufacturingYear.ToString(CultureInfo.InvariantCulture)[2] +
                   manufacturingWeek.ToString("00", CultureInfo.InvariantCulture)[1] +
                   manufacturingYear.ToString(CultureInfo.InvariantCulture)[3];
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (!new Regex(@"^\D{2}$").IsMatch(factoryLocationCode))
            {
                throw new ArgumentException("factoryLocationCode is wrong!", nameof(factoryLocationCode));
            }

            if (manufacturingDate < new DateTime(2007, 1, 1))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            Calendar calendar = CultureInfo.InvariantCulture.Calendar;

            int manufacturingWeek = calendar.GetWeekOfYear(manufacturingDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            return factoryLocationCode.ToUpperInvariant() +
                  manufacturingWeek.ToString("00", CultureInfo.InvariantCulture)[0] +
                  manufacturingDate.Year.ToString(CultureInfo.InvariantCulture)[2] +
                  manufacturingWeek.ToString("00", CultureInfo.InvariantCulture)[1] +
                  manufacturingDate.Year.ToString(CultureInfo.InvariantCulture)[3];
        }
    }
}
