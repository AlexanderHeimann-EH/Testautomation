// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PercentageToBrushConverter.cs" company="Endress+Hauser Process Solutions AG">
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
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// A converter to convert a percentage (double) to a visibility state.
    /// </summary>
    public class PercentageToBrushConverter : IValueConverter
    {
        #region Public Methods

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

            Brush retVal = Brushes.LimeGreen;

            if ((value != null) && (targetType != null))
            {
                if (targetType != typeof(Brush))
                {
                    throw new InvalidOperationException("The target must be of type 'Brush'");
                }

                double percentage = double.Parse(value.ToString(), CultureInfo.CurrentCulture);

                switch (parameter.ToString())
                {
                    case "Foreground":
                        if (percentage < 10.0)
                        {
                            retVal = Brushes.Red;
                        }
                        else if (percentage < 30.0)
                        {
                            retVal = Brushes.Orange;
                        }
                        else if (percentage < 50.0)
                        {
                            retVal = Brushes.YellowGreen;
                        }
                        else
                        {
                            retVal = Brushes.LimeGreen;
                        }

                        break;

                    case "Background":
                        if (percentage < 10.0)
                        {
                            retVal = Brushes.Red;
                        }
                        else
                        {
                            retVal = Brushes.Transparent;
                        }

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
