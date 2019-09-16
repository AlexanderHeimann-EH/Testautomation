// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ColorConverter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// Class ColorConverter.
    /// </summary>
    internal class ColorConverter : IMultiValueConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Convert(object[] o, Type type, object parameter, CultureInfo culture)
        {
            var color = o[0] as Brush;
            var focusColor = o[1] as Brush;
            var errorColor = o[2] as Brush;
            var isInFocusChain = (bool)o[3];
            var isValid = (bool)o[4];

            if (!isValid)
            {
                return errorColor;
            }

            if (isInFocusChain)
            {
                return focusColor;
            }

            return color;
        }

        /// <summary>
        /// The convert back.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetTypes">
        /// The target types.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}