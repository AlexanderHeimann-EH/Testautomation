// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WizardStepToVisibilityConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   A converter to convert a WizardStep to a visibility state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Converter
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    using EH.ImsOpcBridge.Configurator.ViewModel;

    /// <summary>
    /// A converter to convert a WizardStep to a visibility state.
    /// </summary>
    public class WizardStepToVisibilityConverter : IValueConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The converter method.
        /// </summary>
        /// <param name="value">
        /// The value (bool).
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// returns a Visibility.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// thrown if wrong type is passed
        /// </exception>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "OK here.")]
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility retVal = Visibility.Visible;

            if ((value != null) && (targetType != null))
            {
                if (targetType != typeof(Visibility))
                {
                    throw new InvalidOperationException("The target must be of type 'Visibility'");
                }

                WizardStep wizardStep = (WizardStep)value;
                string target = (string)parameter;

                switch (wizardStep)
                {
                    case WizardStep.Home:
                        if (target == "Home")
                        {
                            retVal = Visibility.Visible;
                        }
                        else
                        {
                            retVal = Visibility.Collapsed;
                        }

                        break;
                    case WizardStep.HowToUse:
                        if (target == "HowToUse")
                        {
                            retVal = Visibility.Visible;
                        }
                        else
                        {
                            retVal = Visibility.Collapsed;
                        }

                        break;
                    case WizardStep.RestrictionWindow:
                        if (target == "RestrictionWindow")
                        {
                            retVal = Visibility.Visible;
                        }
                        else
                        {
                            retVal = Visibility.Collapsed;
                        }

                        break;
                    case WizardStep.Settings:
                        if (target == "Settings")
                        {
                            retVal = Visibility.Visible;
                        }
                        else
                        {
                            retVal = Visibility.Collapsed;
                        }

                        break;

                    case WizardStep.DisplayMessage:
                        if (target == "DisplayMessage")
                        {
                            retVal = Visibility.Visible;
                        }
                        else
                        {
                            retVal = Visibility.Collapsed;
                        }

                        break;
                    case WizardStep.DisplayTextBox:
                        if (target == "DisplayTextBox")
                        {
                            retVal = Visibility.Visible;
                        }
                        else
                        {
                            retVal = Visibility.Collapsed;
                        }

                        break;
                    case WizardStep.Unknown:
                        if (target == "Home")
                        {
                            retVal = Visibility.Visible;
                        }
                        else
                        {
                            retVal = Visibility.Collapsed;
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(@"value", value, @"Value is out of range");
                }
            }

            return retVal;
        }

        /// <summary>
        /// The backwards converter (not implemented)
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The convert back.
        /// </returns>
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
