// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringToListConverter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class StringToListConverter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Class StringToListConverter.
    /// </summary>
    public class StringToListConverter
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts a semicolon separated input string (xxxx;xxxx;xxxx xx; xxxx) to a list
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <returns>
        /// This list with the separated elements of the input string.
        /// </returns>
        public static List<string> Run(string input)
        {
            var result = new List<string>();

            if (input == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The input string is null.");
            }
            else if (input == string.Empty)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The input string is empty.");
            }
            else
            {
                string[] separator = { ";" };
                string[] entriesForList = input.Split(separator, StringSplitOptions.None);
                foreach (var entry in entriesForList)
                {
                    result.Add(entry);
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Input string converted to list.");
            }

            return result;
        }

        #endregion
    }
}