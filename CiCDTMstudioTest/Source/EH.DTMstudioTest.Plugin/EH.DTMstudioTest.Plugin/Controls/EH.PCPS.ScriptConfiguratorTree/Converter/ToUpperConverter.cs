// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToUpperConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ToUpperConverter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Class ToUpperConverter.
    /// </summary>
    internal class ToUpperConverter : IValueConverter
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
        public object Convert(object o, Type type, object parameter, CultureInfo culture)
        {
            return o != null ? ((string)o).ToUpper() : null;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">
        /// The value that is produced by the binding target.
        /// </param>
        /// <param name="targetType">
        /// The type to convert to.
        /// </param>
        /// <param name="parameter">
        /// The converter parameter to use.
        /// </param>
        /// <param name="culture">
        /// The culture to use in the converter.
        /// </param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}