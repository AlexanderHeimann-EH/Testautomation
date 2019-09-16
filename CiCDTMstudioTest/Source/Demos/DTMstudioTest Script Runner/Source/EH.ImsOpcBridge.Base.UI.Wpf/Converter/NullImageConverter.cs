// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullImageConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Converts a null or empty string to a non set image.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Converts a null or empty string to a non set image.
    /// </summary>
    public class NullImageConverter : IValueConverter
    {
        #region Public Methods

        /// <summary>
        /// The converter method.
        /// </summary>
        /// <param name="value">The value (bool).</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>returns a Visibility.</returns>
        /// <exception cref="InvalidOperationException">
        /// thrown if wrong type is passed
        /// </exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;
            if (string.IsNullOrEmpty(str))
            {
                return DependencyProperty.UnsetValue;
            }

            return value;
        }

        /// <summary>
        /// The backwards converter (not implemented)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The convert back.</returns>
        /// <exception cref="NotImplementedException">
        /// Thrown as it is not implemented.
        /// </exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Not implemented");
        }

        #endregion
    }
}
