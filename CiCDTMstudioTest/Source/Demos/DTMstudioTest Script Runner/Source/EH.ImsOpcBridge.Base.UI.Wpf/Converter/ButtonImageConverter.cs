// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonImageConverter.cs" company="Endress+Hauser Process Solutions AG">
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
    public class ButtonImageConverter : IValueConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The converter method.
        /// </summary>
        /// <param name="value">The value (bool).</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>returns a Visibility.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object retval;
            var str = (string)value;
            var param = (string)parameter;
            if (string.IsNullOrEmpty(str))
            {
                retval = DependencyProperty.UnsetValue;
            }
            else if (param == "pressed")
            {
                retval = str.Replace("active.png", "pressed.png");
            }
            else if (param == "disabled")
            {
                retval = str.Replace("active.png", "disabled.png");
            }
            else
            {
                retval = value;
            }

            return retval;
        }

        /// <summary>
        /// The backwards converter (not implemented)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The convert back.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Not implemented");
        }

        #endregion
    }
}
