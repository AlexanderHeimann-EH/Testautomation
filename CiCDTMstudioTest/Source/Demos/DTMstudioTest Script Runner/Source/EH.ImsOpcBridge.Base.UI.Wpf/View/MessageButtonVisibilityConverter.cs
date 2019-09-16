// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageButtonVisibilityConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.UI.Wpf.View
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// A converter to convert a MessageButton to the visibility of the message box buttons.
    /// </summary>
    public class MessageButtonVisibilityConverter : IValueConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value (MessageButton) produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">Specifies the message box button to convert for</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value (Visibility). If the method returns null, the valid null value is used.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = @"OK here.")]
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(@"parameter");
            }
            
            var messageButtonValue = (MessageButton)value;

            // ReSharper disable RedundantAssignment
            var buttonVisibility = Visibility.Hidden;

            // ReSharper restore RedundantAssignment
            switch (parameter.ToString())
            {
                case "Ok":
                    switch (messageButtonValue)
                    {
                        case MessageButton.ButtonsOk:
                            buttonVisibility = Visibility.Visible;
                            break;
                        case MessageButton.ButtonsOkCancel:
                            buttonVisibility = Visibility.Visible;
                            break;
                        case MessageButton.ButtonsRetryCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsAbortRetryIgnore:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsYesNo:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsYesNoCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(@"value");
                    }

                    break;

                case "Abort":
                    switch (messageButtonValue)
                    {
                        case MessageButton.ButtonsOk:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsOkCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsRetryCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsAbortRetryIgnore:
                            buttonVisibility = Visibility.Visible;
                            break;
                        case MessageButton.ButtonsYesNo:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsYesNoCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(@"value");
                    }

                    break;

                case "Cancel":
                    switch (messageButtonValue)
                    {
                        case MessageButton.ButtonsOk:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsOkCancel:
                            buttonVisibility = Visibility.Visible;
                            break;
                        case MessageButton.ButtonsRetryCancel:
                            buttonVisibility = Visibility.Visible;
                            break;
                        case MessageButton.ButtonsAbortRetryIgnore:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsYesNo:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsYesNoCancel:
                            buttonVisibility = Visibility.Visible;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(@"value");
                    }

                    break;

                case "Ignore":
                    switch (messageButtonValue)
                    {
                        case MessageButton.ButtonsOk:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsOkCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsRetryCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsAbortRetryIgnore:
                            buttonVisibility = Visibility.Visible;
                            break;
                        case MessageButton.ButtonsYesNo:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsYesNoCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(@"value");
                    }

                    break;

                case "No":
                    switch (messageButtonValue)
                    {
                        case MessageButton.ButtonsOk:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsOkCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsRetryCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsAbortRetryIgnore:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsYesNo:
                            buttonVisibility = Visibility.Visible;
                            break;
                        case MessageButton.ButtonsYesNoCancel:
                            buttonVisibility = Visibility.Visible;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(@"value");
                    }

                    break;

                case "Retry":
                    switch (messageButtonValue)
                    {
                        case MessageButton.ButtonsOk:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsOkCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsRetryCancel:
                            buttonVisibility = Visibility.Visible;
                            break;
                        case MessageButton.ButtonsAbortRetryIgnore:
                            buttonVisibility = Visibility.Visible;
                            break;
                        case MessageButton.ButtonsYesNo:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsYesNoCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(@"value");
                    }

                    break;

                case "Yes":
                    switch (messageButtonValue)
                    {
                        case MessageButton.ButtonsOk:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsOkCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsRetryCancel:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsAbortRetryIgnore:
                            buttonVisibility = Visibility.Collapsed;
                            break;
                        case MessageButton.ButtonsYesNo:
                            buttonVisibility = Visibility.Visible;
                            break;
                        case MessageButton.ButtonsYesNoCancel:
                            buttonVisibility = Visibility.Visible;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(@"value");
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(@"parameter");
            }

            return buttonVisibility;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ReSharper disable LocalizableElement
            throw new NotImplementedException("Will never be implemented.");

            // ReSharper restore LocalizableElement
        }

        #endregion
    }
}
