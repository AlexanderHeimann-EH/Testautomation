// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Information.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Functions.StatusArea.Usermessages.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.StatusArea.Usermessages.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.GUI.StatusArea.Usermessages;

    /// <summary>
    ///     Provides methods to process the status information text of the HISTOROM module
    /// </summary>
    public class Information : IInformation
    {
        #region Public Methods and Operators

        /// <summary>
        /// Analysis status information string in down left corner of the module whether it contains a user given string
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// true: if no error or failure was detected
        ///     false: if an error or failure was detected
        /// </returns>
        public bool CheckIfInfoContains(string value)
        {
            string actualInfo = new InformationElements().InfoText;
            string actualInfoLowerCase = actualInfo.ToLower();
            string valueToLowerCase = value.ToLower();
            if (actualInfoLowerCase.Contains(valueToLowerCase) == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HistoROM module actual info message does not contain: '" + value + "'.");
                return false;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HistoROM module actual info says: '" + actualInfo + "'.");
            return true;
        }

        /// <summary>
        ///     Analysis status information string in down left corner of the module
        /// </summary>
        /// <returns>
        ///     true: if no error or failure was detected
        ///     false: if an error or failure was detected
        /// </returns>
        public bool CheckInfo()
        {
            string actualInfo = new InformationElements().InfoText;
            string actualInfoLowerCase = actualInfo.ToLower();
            if (actualInfoLowerCase.Contains("error") || actualInfoLowerCase.Contains("fail") || actualInfoLowerCase.Contains("corrupt"))
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HistoROM module reports: \"" + actualInfo + "\"");
                return false;
            }

            return true;
        }

        #endregion
    }
}