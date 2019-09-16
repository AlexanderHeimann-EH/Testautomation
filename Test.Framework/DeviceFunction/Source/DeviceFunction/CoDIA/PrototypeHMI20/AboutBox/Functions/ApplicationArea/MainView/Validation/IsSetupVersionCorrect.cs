// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsSetupVersionCorrect.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Validates whether a setup version matches a certain pattern
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.AboutBox.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;
    using System.Text.RegularExpressions;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    /// Validates whether a setup version matches a certain pattern
    /// </summary>
    public class IsSetupVersionCorrect : IIsSetupVersionCorrect
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks whether a setup version matches the pattern digit(s).digit(s).digit(s).digit(s);
        /// </summary>
        /// <param name="setupVersion">
        /// The setup version.
        /// </param>
        /// <returns>
        /// True: if setup version matches pattern; False: otherwise
        /// </returns>
        public bool Run(string setupVersion)
        {
            // const string SetupVersionPattern = @"(\d{1,2}\.\d{1,2}\.\d{1,2}\.\d{4,5})$";
            const string SetupVersionPattern = @"(\d{1,}\.\d{1,}\.\d{1,}\.\d{1,})$";
            var regex = new Regex(SetupVersionPattern);
            bool result = regex.IsMatch(setupVersion);
            if (result)
            {
                // Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The setup version: " + setupVersion + " does match the pattern: <x>x.<x>x.<x>x.xxxx.");
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The setup version: " + setupVersion + " does match the pattern: digit(s).digit(s).digit(s).digit(s);");
            }
            else
            {
                // Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The setup version: " + setupVersion + " does not match the pattern: <x>x.<x>x.<x>x.xxxx.");
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The setup version: " + setupVersion + " does not match the pattern: digit(s).digit(s).digit(s).digit(s);");
            }

            return result;
        }

        #endregion
    }
}