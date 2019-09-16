// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WidthConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// The width converter.
    /// </summary>
    public class WidthConverter : IValueConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The <see cref="object" />.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = (double)value;

            if (!double.IsNaN(result))
            {
                result = result * 0.2;
            }
            else
            {
                result = 100D;
            }

            return result;
        }

        /// <summary>
        /// The convert back.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The <see cref="object" />.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ReSharper disable LocalizableElement
            throw new NotImplementedException("Not implemented.");

            // ReSharper restore LocalizableElement
        }

        #endregion
    }
}
