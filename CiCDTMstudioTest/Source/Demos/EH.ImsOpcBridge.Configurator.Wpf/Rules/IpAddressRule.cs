// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IpAddressRule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class IpAddressRule
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configurator.Rules
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.Properties;

    /// <summary>
    /// Class IpAddressRule
    /// </summary>
    public class IpAddressRule : ValidationRule
    {
        #region Public Methods and Operators

        /// <summary>
        /// When overridden in a derived class, performs validation checks on a value.
        /// </summary>
        /// <param name="value">
        /// The value from the binding target to check.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture to use in this rule.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.Windows.Controls.ValidationResult"/> object.
        /// </returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var addressValue = (string)value;

                // Validate against regular expression for IP address.
                const string ValidIpAddressRegex = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
                var rx = new Regex(ValidIpAddressRegex);

                if ((!rx.IsMatch(addressValue)) || (addressValue == "0.0.0.0"))
                {
                    var message = string.Format("{0} ", addressValue) + Resources.IsNotAValidEntry;
                    return new ValidationResult(false, message);
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