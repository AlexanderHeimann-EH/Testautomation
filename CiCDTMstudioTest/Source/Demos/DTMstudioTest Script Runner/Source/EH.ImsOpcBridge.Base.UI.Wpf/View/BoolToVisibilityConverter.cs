// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoolToVisibilityConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   A converter to convert a bool to a visibility state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    using EH.ImsOpcBridge.UI.Wpf.Properties;

    /// <summary>
    /// A converter to convert a bool to a visibility state.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
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
            var paramString = (parameter == null) ? "Visible" : parameter.ToString();

            var retVal = Visibility.Visible;

            if ((value != null) && (targetType != null))
            {
                if (targetType != typeof(Visibility))
                {
                    throw new InvalidOperationException(Resources.TheTargetMustBeOfTypeVisibility);
                }

                var boolVal = (bool)value;

                switch (paramString)
                {
                    case "Inverse":
                        retVal = boolVal ? Visibility.Collapsed : Visibility.Visible;
                        break;

                    case "Hidden":
                        retVal = boolVal ? Visibility.Visible : Visibility.Hidden;
                        break;

                    case "InverseHidden":
                        retVal = boolVal ? Visibility.Hidden : Visibility.Visible;
                        break;

                    default:
                        retVal = boolVal ? Visibility.Visible : Visibility.Collapsed;
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
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value != null) && (targetType != null))
            {
                if (targetType != typeof(bool))
                {
                    throw new InvalidOperationException(Resources.TheTargetMustBeOfTypeBool);
                }

                return (Visibility)value == Visibility.Visible;
            }

            return true;
        }

        #endregion
    }
}
