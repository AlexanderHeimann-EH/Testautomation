// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EhSerialNumberRule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Validates a E+H serial number.
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
    /// Validates a E+H serial number.
    /// </summary>
    public class EhSerialNumberRule : ValidationRule
    {
        #region Const

        /// <summary>
        /// The character mask to format the production year.
        /// </summary>
        private const string YearMask = "0123456789ACDEFHJKLMNPRSTVWXZ01";

        /// <summary>
        /// The character mask to format the production month.
        /// </summary>
        private const string MonthMask = "123456789ABC";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// When overridden in a derived class, performs validation checks on a value.
        /// </summary>
        /// <param name="value">The value from the binding target to check.</param>
        /// <param name="cultureInfo">The culture to use in this rule.</param>
        /// <returns>A <see cref="T:System.Windows.Controls.ValidationResult" /> object.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var text = (string)value;
                string errorMessage;
                if (!ValidateSerialNumber(text, out errorMessage))
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

        #region Private Methods

        /// <summary>
        /// Validates the serial number.
        /// </summary>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="errorMessage">The resource error string.</param>
        /// <returns><c>true</c> if the serial number is conform the E+H rules, <c>false</c> otherwise.</returns>
        private static bool ValidateSerialNumber(string serialNumber, out string errorMessage)
        {
            errorMessage = null;

            // Validates general existing string.
            if (string.IsNullOrEmpty(serialNumber) || serialNumber.Length != 11)
            {
                errorMessage = Resources.SerialNumberInvalidString;
                return false;
            }

            // Convert to char array for next uses.
            var vector = serialNumber.ToCharArray();

            // Validates production date. It cannot be in the future, compared with the current date.
            var yearIndex = YearMask.IndexOf(vector[0]);
            var monthIndex = MonthMask.IndexOf(vector[1]);
            if (yearIndex < 0 || monthIndex < 0)
            {
                errorMessage = Resources.SerialNumberInvalidProductionDate;
                return false;
            }

            var productionDate = new DateTime(1998 + yearIndex, 1 + monthIndex, 1);
            if (DateTime.Now < productionDate)
            {
                errorMessage = Resources.SerialNumberInvalidProductionDate;
                return false;
            }

            // Validates individual serial number.
            if (!IsHex(serialNumber.Substring(2, 4)))
            {
                errorMessage = Resources.SerialNumberInvalidIndividualSerialNumber;
                return false;
            }

            // Validates production center, in this case Maulburg.
            if (!serialNumber.Substring(6, 2).Equals("01"))
            {
                errorMessage = Resources.SerialNumberInvalidProductCenter;
                return false;
            }

            // Validates product identifier.
            if (!IsHex(serialNumber.Substring(8, 3)))
            {
                errorMessage = Resources.SerialNumberInvalidProductIdentifier;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether the specified text is hexadecimal.
        /// </summary>
        /// <param name="text">The text to check for.</param>
        /// <returns><c>true</c> if the specified text is hexadecimal; otherwise, <c>false</c>.</returns>
        private static bool IsHex(string text)
        {
            return new Regex("^[0-9A-F]+$").IsMatch(text);
        }

        #endregion
    }
}