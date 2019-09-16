// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringToStringArrayConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class StringToStringArrayConverter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Tools
{
    /// <summary>
    /// Class StringToStringArrayConverter.
    /// </summary>
    public class StringToStringArrayConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts a semicolon separated input string (xxxx;xxxx;xxxx xx; xxxx) to an array.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <returns>
        /// An array with the separated elements of the input string.
        /// </returns>
        public static string[] Run(string input)
        {
            return StringToListConverter.Run(input).ToArray();
        }

        #endregion
    }
}