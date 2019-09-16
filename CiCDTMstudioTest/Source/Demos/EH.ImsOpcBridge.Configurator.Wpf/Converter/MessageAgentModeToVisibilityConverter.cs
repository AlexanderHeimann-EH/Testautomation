// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageAgentModeToVisibilityConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   A converter to convert a WizardStep to a visibility state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    using EH.ImsOpcBridge.Configurator.Properties;

    /// <summary>
    /// A converter to convert a percentage (double) to a visibility state.
    /// </summary>
    public partial class MessageAgentModeToVisibilityConverter : IValueConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The converter method.
        /// </summary>
        /// <param name="value">The value (bool).</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>returns a Brush.</returns>
        /// <exception cref="InvalidOperationException">
        /// thrown if wrong type is passed
        /// </exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(@"parameter");
            }
            
            // ReSharper disable LocalizableElement
            var retVal = Visibility.Collapsed;

            if ((value != null) && (targetType != null))
            {
                if (targetType != typeof(Visibility))
                {
                    throw new InvalidOperationException(Resources.TheTargetMustBeOfTypeVisibility);
                }

                switch (value.ToString())
                {
                    case "List":
                        if (parameter.ToString() == "AgentControl" || parameter.ToString() == "MessageListBox")
                        {
                            retVal = Visibility.Visible;
                        }
                        else
                        {
                            retVal = Visibility.Collapsed;
                        }

                        break;
                    case "Single":
                        if (parameter.ToString() == "AgentControl" || parameter.ToString() == "MessageTextBox")
                        {
                            retVal = Visibility.Visible;
                        }
                        else
                        {
                            retVal = Visibility.Collapsed;
                        }

                        break;
                    case "None":
                        retVal = Visibility.Collapsed;

                        break;
                }
            }

            // ReSharper restore LocalizableElement
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
