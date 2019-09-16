// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisibilityInverterConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   A converter to invert visibility.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// A converter to invert visibility.
    /// </summary>
    public class VisibilityInverterConverter : IValueConverter
    {
        #region Public Methods

        /// <summary>
        /// The converter method.
        /// </summary>
        /// <param name="value">The value (Visibility).</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>returns a Visibility.</returns>
        /// <exception cref="InvalidOperationException">
        /// thrown if wrong type is passed
        /// </exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility retVal = Visibility.Visible;

            if ((value != null) && (targetType != null))
            {
                if (targetType != typeof(Visibility))
                {
                    throw new InvalidOperationException("The target must be of type 'Visibility'");
                }

                switch ((Visibility)value)
                {
                    case Visibility.Collapsed:
                        retVal = Visibility.Visible;
                        break;

                    case Visibility.Hidden:
                        retVal = Visibility.Visible;
                        break;

                    case Visibility.Visible:
                        retVal = Visibility.Collapsed;
                        break;
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
