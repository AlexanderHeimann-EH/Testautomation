// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringToBoolConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   A converter to convert a SettingsSection to a visibility state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// A converter to convert a SettingsSection to a visibility state.
    /// </summary>
    public class StringToBoolConverter : IValueConverter
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
            bool retVal = true;

            if (value == null)
            {
                retVal = false;
            }
            else if (targetType != null)
            {
                if (targetType != typeof(bool))
                {
                    throw new InvalidOperationException("The target must be of type 'bool'");
                }

                if (value == DependencyProperty.UnsetValue)
                {
                    retVal = false;
                }

                var text = (string)value;

                if (value == DependencyProperty.UnsetValue || string.IsNullOrEmpty(text))
                {
                    retVal = false;
                }
                else
                {
                    retVal = true;
                }
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
