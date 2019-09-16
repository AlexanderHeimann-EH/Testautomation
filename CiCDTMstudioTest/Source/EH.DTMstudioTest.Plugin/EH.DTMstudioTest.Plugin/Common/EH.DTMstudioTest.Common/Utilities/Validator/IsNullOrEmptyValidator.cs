// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringValidator.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The string validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.Utilities.Validator
{
    using System.Globalization;
    using System.Windows.Controls;

    /// <summary>
    /// The string validator.
    /// </summary>
    public class IsNullOrEmptyValidator : ValidationRule
    {
        #region Public Methods and Operators

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// The <see cref="ValidationResult"/>.
        /// </returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var valueFromSource = value.ToString();

            if (string.IsNullOrEmpty(valueFromSource))
            {
                return new ValidationResult(false, "Das Feld darf nicht leer sein!");
            }

            return new ValidationResult(true, null);
        }

        #endregion
    }
}