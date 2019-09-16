// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="BoolToStretchedConverter.cs">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// A converter to convert a boolean to a horizontal alignment state.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(HorizontalAlignment))]
    public class BoolToStretchedConverter : IValueConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The converter method.
        /// </summary>
        /// <param name="value">The value (bool).</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>returns alignment state stretch or default value given by parameter.</returns>
        /// <exception cref="InvalidOperationException">
        /// thrown if wrong type is passed
        /// </exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HorizontalAlignment retVal = HorizontalAlignment.Left;

            if ((value != null) && (targetType != null))
            {
                if (targetType != typeof(HorizontalAlignment))
                {
                    throw new InvalidOperationException("The target must be of type 'Visibility'");
                }

                var stretched = (bool)value;

                var defaultVal = HorizontalAlignment.Left;
                if (parameter != null)
                {
                    if (!Enum.TryParse(parameter as string, out defaultVal))
                    {
                        defaultVal = HorizontalAlignment.Left;
                    }
                }

                retVal = stretched ? HorizontalAlignment.Stretch : defaultVal;
            }

            return retVal;
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
