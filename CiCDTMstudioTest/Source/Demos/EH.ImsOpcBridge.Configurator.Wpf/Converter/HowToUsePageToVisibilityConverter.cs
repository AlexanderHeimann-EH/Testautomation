﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HowToUsePageToVisibilityConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   A converter to convert a HowToUsePage to a visibility state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Converter
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    using EH.ImsOpcBridge.Configurator.ViewModel;

    /// <summary>
    /// A converter to convert a HowToUsePage to a visibility state.
    /// </summary>
    public class HowToUsePageToVisibilityConverter : IValueConverter
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
        [Localizable(false)]
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var retVal = Visibility.Visible;

            if ((value != null) && (targetType != null))
            {
                if (targetType != typeof(Visibility))
                {
                    throw new InvalidOperationException("The target must be of type 'Visibility'");
                }

                var page = (HowToUsePage)value;
                var target = (string)parameter;

                switch (page)
                {
                   case HowToUsePage.About:
                        retVal = target == "About" ? Visibility.Visible : Visibility.Collapsed;
                        break;

                   case HowToUsePage.Manual:
                        retVal = target == "Manual" ? Visibility.Visible : Visibility.Collapsed;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(@"parameter", parameter, @"Parameter is out of range");
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
        [Localizable(false)]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Not implemented");
        }

        #endregion
    }
}
