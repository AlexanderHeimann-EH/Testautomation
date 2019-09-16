// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpcItemIdRule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Validates an opc item id.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.Rules
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.Properties;

    /// <summary>
    /// Validates an opc item id.
    /// </summary>
    public class OpcItemIdRule : ValidationRule
    {
        #region Public Methods and Operators

        /// <summary>
        /// Validates the input value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// The validation result.
        /// </returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var errorMessage = Resources.AValidOPCItemIdEntryCannotBeEmptyOrContain + string.Format(" '{0}', '{1}' or '{2}'", ".", "/", "\\");

            try
            {
                var text = (string)value;
                if (string.IsNullOrEmpty(text))
                {
                    return new ValidationResult(false, errorMessage);
                }

                if (text.Contains(".") || text.Contains("/") || text.Contains("\\"))
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