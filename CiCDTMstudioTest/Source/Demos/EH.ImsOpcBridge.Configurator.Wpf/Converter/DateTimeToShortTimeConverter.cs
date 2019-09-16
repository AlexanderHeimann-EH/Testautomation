// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeToShortTimeConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.Converter
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Data;

    /// <summary>
    /// DateTime To ShortTime converter.
    /// </summary>
    public class DateTimeToShortTimeConverter : IValueConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The Date time to Short time convert.
        /// </summary>
        /// <param name="value">The Date Time value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The Date Time parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The convert.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value != null) && (targetType != null))
            {
                var now = (DateTime)value;
                return now.ToShortTimeString();
            }

            return null;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        /// <exception cref="NotImplementedException">
        /// Not Implemented Exception
        /// </exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
