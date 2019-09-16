// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringCombine.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Tools
{
    using System.IO;

    /// <summary>
    /// The string combine.
    /// </summary>
    public class StringCombine
    {
        /// <summary>
        /// The combine.
        /// </summary>
        /// <param name="folders">
        /// The folders.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Combine(string[] folders)
        {
            string result = string.Empty;
            foreach (var folder in folders)
            {
                result = Path.Combine(result, folder);
            }

            return result;
        }
    }
}
