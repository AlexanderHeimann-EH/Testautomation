// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntRangeRule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Validates an int.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.Rules
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.Properties;

    /// <summary>
    /// Validates an int.
    /// </summary>
    public class IntRangeRule : ValidationRule
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets Max.
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Gets or sets Min.
        /// </summary>
        public int Min { get; set; }

        #endregion

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
            var number = 0;

            try
            {
                if (((string)value).Length > 0)
                {
                    number = int.Parse((string)value);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, Resources.IllegalCharactersOr + @" " + e.Message);
            }

            if ((number < this.Min) || (number > this.Max))
            {
                return new ValidationResult(false, Resources.PleaseEnterANumberInTheRange + @" " + this.Min + " - " + this.Max + ".");
            }

            return new ValidationResult(true, null);
        }

        #endregion
    }
}