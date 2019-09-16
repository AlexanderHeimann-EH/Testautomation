// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsSectionToVisibilityConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   A converter to convert a SettingsSection to a visibility state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    using EH.ImsOpcBridge.Configurator.ViewModel;

    /// <summary>
    /// A converter to convert a SettingsSection to a visibility state.
    /// </summary>
    public class SettingsSectionToVisibilityConverter : IValueConverter
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
            Visibility retVal = Visibility.Visible;

            if ((value != null) && (targetType != null))
            {
                if (targetType != typeof(Visibility))
                {
                    throw new InvalidOperationException("The target must be of type 'Visibility'");
                }

                var page = (SettingsSection)value;
                SettingsSection target;

                if (Enum.TryParse((string)parameter, out target))
                {
                    retVal = (page == target) ? Visibility.Visible : Visibility.Collapsed;
                }
                else
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, @"Unknown settings section: {0}", parameter));
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
            throw new NotImplementedException("Not implemented");
        }

        #endregion
    }
}
