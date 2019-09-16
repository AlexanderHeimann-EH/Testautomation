// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InverseVisibilityConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Converts anything to inverse visibility
//   I know the VisibilityConvert supports the input parameter !. But it's easier to have two converters
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.ScriptConfiguratorTree.Converter
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;

    /// <summary> 
    /// Converts anything to inverse visibility 
    /// I know the VisibilityConvert supports the input parameter !. But it's easier to have two converters 
    /// </summary> 
    public class InverseVisibilityConverter : IValueConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The convert.
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
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool visible = true;
            if (value is Visibility)
            {
                visible = Visibility.Visible == (Visibility)value;
            }
            else if (value is bool)
            {
                visible = (bool)value;
            }
            else if (value is int || value is short || value is long)
            {
                visible = 0 != (int)value;
            }
            else if (value is float || value is double)
            {
                visible = 0.0 != (double)value;
            }
            else if (value is string && string.IsNullOrEmpty((string)value))
            {
                visible = false;
            }
            else if (value is IEnumerable<object>)
            {
                visible = ((IEnumerable<object>)value).Any();
            }
            else if (value is IEnumerable)
            {
                visible = ((IEnumerable)value).GetEnumerator().MoveNext();
            }
            else if (value == null)
            {
                visible = false;
            }

            if ((string)parameter == "!")
            {
                visible = !visible;
            }

            return visible ? Visibility.Visible : Visibility.Collapsed;
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