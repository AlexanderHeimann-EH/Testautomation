// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ByteArrayRule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Validates a byte array.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Rules
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.Properties;

    /// <summary>
    /// Class ByteArrayRule
    /// </summary>
    public class ByteArrayRule : ValidationRule
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        /// <value>The separator.</value>
        public char Separator { get; set; }

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
                // No need to extra checks because exceptions are caught.
                var cmdList = (string)value;
                if (cmdList[cmdList.Length - 1] == this.Separator)
                {
                    cmdList = cmdList.Substring(0, cmdList.Length - 1);
                }

                var cmds = cmdList.Split(this.Separator);

                if (cmds.Length > this.Count)
                {
                    var message = Resources.DataBytesCannotBeMoreThan + string.Format("{0}.", this.Count);
                    return new ValidationResult(false, message);
                }

                foreach (string t in cmds)
                {
                    // If Parse raises an exception then we are in the catch clause.
                    byte.Parse(t);
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