// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotNullOrEmptyRule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Validates an entry that cannot be null or empty.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.Rules
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.Properties;

    /// <summary>
    /// Class NotNullOrEmptyRule
    /// </summary>
    public class NotNullOrEmptyRule : ValidationRule
    {
        #region Public Methods and Operators

        /// <summary>
        /// When overridden in a derived class, performs validation checks on a value.
        /// </summary>
        /// <param name="value">The value from the binding target to check.</param>
        /// <param name="cultureInfo">The culture to use in this rule.</param>
        /// <returns>A <see cref="T:System.Windows.Controls.ValidationResult" /> object.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var errorMessage = Resources.ThisEntryCannotBeNullOrEmpty;

            try
            {
                var text = (string)value;
                if (string.IsNullOrEmpty(text))
                {
                    return new ValidationResult(false, errorMessage);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, Resources.IllegalCharactersOr + @" " + e.Message);
            }

            return new ValidationResult(true, null);
        }

        #endregion
    }
}