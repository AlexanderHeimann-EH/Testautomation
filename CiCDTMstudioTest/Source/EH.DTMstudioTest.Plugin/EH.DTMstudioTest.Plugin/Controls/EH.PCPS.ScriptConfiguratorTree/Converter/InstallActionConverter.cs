// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstallActionConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The install action converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using EH.PCPS.ScriptConfiguratorTree.Model;
    using EH.PCPS.SelectionTree.Controls;

    /// <summary>
    ///     The install action converter.
    /// </summary>
    internal class InstallActionConverter : IValueConverter
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
            var feature = o as TestScriptItem;
            return feature != null ? feature.TestType : TestType.eIndeterminate;
        }

        /// <summary>
        /// The convert back.
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
        /// The <see cref="object"/>.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}