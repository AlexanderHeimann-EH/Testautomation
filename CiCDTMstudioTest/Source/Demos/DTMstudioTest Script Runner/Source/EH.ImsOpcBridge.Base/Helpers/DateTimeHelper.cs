// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Helpers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    /// Helper class for date time conversions.
    /// </summary>
    public static class DateTimeHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts a string to a date.
        /// </summary>
        /// <param name="value">String to be converted to a date.</param>
        /// <returns>Date value.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"Is OK here.")]
        public static DateTime ConvertFromString(string value)
        {
            if (value == null)
            {
                return DateTime.MinValue;
            }

            try
            {
                // ReSharper disable LocalizableElement
                return DateTime.ParseExact(value, "MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);

                // ReSharper restore LocalizableElement
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Converts date to a string.
        /// </summary>
        /// <param name="date">Date to be converted.</param>
        /// <returns>String representation of the date.</returns>
        public static string ConvertToString(DateTime date)
        {
            // ReSharper disable LocalizableElement
            return date.ToString(@"MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);

            // ReSharper restore LocalizableElement
        }

        /// <summary>
        /// Converts date to a short date format which can be used to sort on file system.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>String representation of the date.</returns>
        public static string ConvertToSortableDateString(DateTime date)
        {
            // ReSharper disable LocalizableElement
            return date.ToString(@"yyyyMMdd", CultureInfo.InvariantCulture);

            // ReSharper restore LocalizableElement
        }

        #endregion
    }
}
