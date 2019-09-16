// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Information.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods to process the status information text of the HISTOROM module
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Historom.Functions.StatusArea.Usermessages.Execution
{
    using System.Collections;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.StatusArea.Usermessages.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Historom.GUI.Resources;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Historom.GUI.StatusArea.Usermessages;

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
            bool result = true;
            string actualInfo = new InformationElements().InfoText;
            string actualInfoLowerCase = actualInfo.ToLower();

            ResourceSet messages = UsermessageTranslations.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry message in messages)
            {
                if (actualInfoLowerCase.Contains(message.ToString()))
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "HistoROM module reports: \"" + actualInfo + "\"");
                    result = false;
                    break;
                }
            }

            return result;
        }

        #endregion
    }
}