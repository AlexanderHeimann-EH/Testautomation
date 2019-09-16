// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsDeviceTypeNameCorrect.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Validates whether a device type name matches a certain pattern
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.AboutBox.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    /// Validates whether a device type name matches a certain pattern
    /// </summary>
    public class IsDeviceTypeNameCorrect : IIsDeviceTypeNameCorrect
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks whether a device type name matches the pattern DeviceType / OrderCode / Protocol / Firmware / Dev.Rev
        /// </summary>
        /// <param name="deviceTypeName">
        /// The device type name
        /// </param>
        /// <returns>
        /// True: if setup version matches pattern; False: otherwise
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(string deviceTypeName)
        {
            const string DtmInfoPattern = @"^([a-zA-Z0-9 ]+\s/\s[a-zA-Z0-9 ]+\s/\s[A-Z]+\s/\sFW\s\d\.\d{2}\.zz\s/\sDev\.Rev\.\s\d)";
            var regex = new Regex(DtmInfoPattern);
            bool result = regex.IsMatch(deviceTypeName);
            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device type name: " + deviceTypeName + " does match the pattern: DeviceType / OrderCode / Protocol / Firmware / Dev.Rev.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device type name: " + deviceTypeName + " does not match the pattern: DeviceType / OrderCode / Protocol / Firmware / Dev.Rev.");
            }

            return result;
        }

        #endregion
    }
}