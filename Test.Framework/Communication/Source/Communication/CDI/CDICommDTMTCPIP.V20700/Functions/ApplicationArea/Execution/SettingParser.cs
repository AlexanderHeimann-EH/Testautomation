// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingParser.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Defines the SettingParser type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.Functions.ApplicationArea.Execution
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// The setting parser.
    /// </summary>
    public class SettingParser
    {
        /// <summary>
        /// The parse.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Parse(string input)
        {
            var pattern = new Regex(@"\W");

            return pattern.Replace(input, string.Empty).ToLower();
        }

        /// <summary>
        /// Checks, after parsing, if two strings are equal
        /// </summary>
        /// <param name="input1">The first string argument</param>
        /// <param name="input2">The second string argument</param>
        /// <returns>
        /// True, if both strings are equal
        /// </returns>
        public bool Compare(string input1, string input2)
        {
            if (this.Parse(input1) == this.Parse(input2))
            {
                return true;
            }
     
            return false;
        }
    }
}
